using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration.Provider;
using System.Collections.Specialized;
using Microsoft.Samples;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Web;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Web.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using ynhrMemberManage.Domain;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Common;
using ynhrMemberManage.CardCommon.CardRef;
using ynhrMemberManage.Business;

namespace ynhrMemeberManage.Security
{
    public class MyMembershipProvider : MembershipProvider//ProviderBase
    {
        ////////////////////////////////////////////////////////////
        #region Public properties

        public override bool EnablePasswordRetrieval { get { return _EnablePasswordRetrieval; } }

        public override bool EnablePasswordReset { get { return _EnablePasswordReset; } }

        public override bool RequiresQuestionAndAnswer { get { return _RequiresQuestionAndAnswer; } }

        public override bool RequiresUniqueEmail { get { return _RequiresUniqueEmail; } }

        public override MembershipPasswordFormat PasswordFormat { get { return _PasswordFormat; } }
        public override int MaxInvalidPasswordAttempts { get { return _MaxInvalidPasswordAttempts; } }

        public override int PasswordAttemptWindow { get { return _PasswordAttemptWindow; } }

        public override int MinRequiredPasswordLength
        {
            get { return _MinRequiredPasswordLength; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return _MinRequiredNonalphanumericCharacters; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { return _PasswordStrengthRegularExpression; }
        }
        
        #endregion

        #region private field
        //private string _sqlConnectionString;
        private bool _EnablePasswordRetrieval;
        private bool _EnablePasswordReset;
        private bool _RequiresQuestionAndAnswer;
        //private string _AppName;
        private bool _RequiresUniqueEmail;
        private int _MaxInvalidPasswordAttempts;
        //private int _CommandTimeout;
        private int _PasswordAttemptWindow;
        private int _MinRequiredPasswordLength;
        private int _MinRequiredNonalphanumericCharacters;
        private string _PasswordStrengthRegularExpression;

        private MembershipPasswordFormat _PasswordFormat;

        private const int PASSWORD_SIZE = 14;
        #endregion


        public override  void Initialize(string name, NameValueCollection config)
        {
            // Remove CAS from sample: HttpRuntime.CheckAspNetHostingPermission (AspNetHostingPermissionLevel.Low, SR.Feature_not_supported_at_this_level);
            if (config == null)
                throw new ArgumentNullException("config");
            if (String.IsNullOrEmpty(name))
                name = "MyMembershipProvider";
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", SR.GetString(SR.MembershipSqlProvider_description));
            }
            base.Initialize(name, config);


            _EnablePasswordRetrieval = SecUtility.GetBooleanValue(config, "enablePasswordRetrieval", false);
            _EnablePasswordReset = SecUtility.GetBooleanValue(config, "enablePasswordReset", true);
            _RequiresQuestionAndAnswer = SecUtility.GetBooleanValue(config, "requiresQuestionAndAnswer", true);
            _RequiresUniqueEmail = SecUtility.GetBooleanValue(config, "requiresUniqueEmail", true);
            _MaxInvalidPasswordAttempts = SecUtility.GetIntValue(config, "maxInvalidPasswordAttempts", 5, false, 0);
            _PasswordAttemptWindow = SecUtility.GetIntValue(config, "passwordAttemptWindow", 10, false, 0);
            _MinRequiredPasswordLength = SecUtility.GetIntValue(config, "minRequiredPasswordLength", 7, false, 128);
            _MinRequiredNonalphanumericCharacters = SecUtility.GetIntValue(config, "minRequiredNonalphanumericCharacters", 1, true, 128);

            _PasswordStrengthRegularExpression = config["passwordStrengthRegularExpression"];
            if (_PasswordStrengthRegularExpression != null)
            {
                _PasswordStrengthRegularExpression = _PasswordStrengthRegularExpression.Trim();
                if (_PasswordStrengthRegularExpression.Length != 0)
                {
                    try
                    {
                        Regex regex = new Regex(_PasswordStrengthRegularExpression);
                    }
                    catch (ArgumentException e)
                    {
                        throw new ProviderException(e.Message, e);
                    }
                }
            }
            else
            {
                _PasswordStrengthRegularExpression = string.Empty;
            }
            if (_MinRequiredNonalphanumericCharacters > _MinRequiredPasswordLength)
                throw new HttpException(SR.GetString(SR.MinRequiredNonalphanumericCharacters_can_not_be_more_than_MinRequiredPasswordLength));

            

            config.Remove("connectionStringName");
            config.Remove("enablePasswordRetrieval");
            config.Remove("enablePasswordReset");
            config.Remove("requiresQuestionAndAnswer");
            config.Remove("applicationName");
            config.Remove("requiresUniqueEmail");
            config.Remove("maxInvalidPasswordAttempts");
            config.Remove("passwordAttemptWindow");
            config.Remove("commandTimeout");
            config.Remove("passwordFormat");
            config.Remove("name");
            config.Remove("minRequiredPasswordLength");
            config.Remove("minRequiredNonalphanumericCharacters");
            config.Remove("passwordStrengthRegularExpression");
            if (config.Count > 0)
            {
                string attribUnrecognized = config.GetKey(0);
                if (!String.IsNullOrEmpty(attribUnrecognized))
                    throw new ProviderException(SR.GetString(SR.Provider_unrecognized_attribute, attribUnrecognized));
            }
        }       

        public string CreateUser(Oper oper)
        {
            string password = oper.cnvcPwd;
            string username = oper.cnvcOperName;
            if (!SecUtility.ValidateParameter(ref password, true, true, false, 128))
            {
                return MyMembershipCreateStatus.InvalidPassword;
            }

            //string salt = GenerateSalt();
            string pass = EncodePassword(oper.cnvcPwd);            
            if (pass.Length > 128)
            {
                return MyMembershipCreateStatus.InvalidPassword;                
            }

            if (!SecUtility.ValidateParameter(ref username, true, true, true, 256))
            {
                return MyMembershipCreateStatus.InvalidUserName;                
            }

            if (oper.cnvcPwd.Length < MinRequiredPasswordLength)
            {
                return MyMembershipCreateStatus.InvalidPassword;                
            }

            int count = 0;

            for (int i = 0; i < oper.cnvcPwd.Length; i++)
            {
                if (!char.IsLetterOrDigit(oper.cnvcPwd, i))
                {
                    count++;
                }
            }

            if (count < MinRequiredNonAlphanumericCharacters)
            {
                return MyMembershipCreateStatus.InvalidPassword;                
            }

            if (PasswordStrengthRegularExpression.Length > 0)
            {
                if (!Regex.IsMatch(oper.cnvcPwd, PasswordStrengthRegularExpression))
                {
                    return MyMembershipCreateStatus.InvalidPassword;                    
                }
            }
            oper.cnvcPwd = pass;
            DataTable dtOper = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbOper where cnvcOperName = '" + oper.cnvcOperName + "'");
            if (dtOper.Rows.Count > 0)
            {
                return MyMembershipCreateStatus.DuplicateUserName;
            }
            if (oper.cnvcCardNo.Length > 0)
            {
                DataTable dtCard = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbOper where cnvcCardNo = 'aaa" + oper.cnvcCardNo + "'");
                if (dtCard.Rows.Count > 0)
                {
                    return MyMembershipCreateStatus.DuplicateCardNo;
                }
                CardM1 m1 = new CardM1();
                string strReturn = m1.PutOutCard("aaa" + oper.cnvcCardNo);
                if (strReturn.Equals("OPSUCCESS"))
                {
                    oper.cnvcCardNo = "aaa" + oper.cnvcCardNo;
                    EntityMapping.Create(oper);
                }
                else
                {
                    return MyMembershipCreateStatus.CardOperException;
                }
            }
            else
            {
                EntityMapping.Create(oper);
            }

            return MyMembershipCreateStatus.Success;
        }

        public override  bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            SecUtility.CheckParameter(ref username, true, true, true, 256, "username");
            SecUtility.CheckParameter(ref oldPassword, true, true, false, 128, "oldPassword");
            SecUtility.CheckParameter(ref newPassword, true, true, false, 128, "newPassword");

            //if (!CheckPassword(username, oldPassword, false))
            //{
            //    return false;
            //}

            if (newPassword.Length < MinRequiredPasswordLength)
            {
                throw new ArgumentException(SR.GetString(
                              SR.Password_too_short,
                              "newPassword",
                              MinRequiredPasswordLength.ToString(CultureInfo.InvariantCulture)));
            }

            int count = 0;

            for (int i = 0; i < newPassword.Length; i++)
            {
                if (!char.IsLetterOrDigit(newPassword, i))
                {
                    count++;
                }
            }

            if (count < MinRequiredNonAlphanumericCharacters)
            {
                throw new ArgumentException(SR.GetString(
                              SR.Password_need_more_non_alpha_numeric_chars,
                              "newPassword",
                              MinRequiredNonAlphanumericCharacters.ToString(CultureInfo.InvariantCulture)));
            }

            if (PasswordStrengthRegularExpression.Length > 0)
            {
                if (!Regex.IsMatch(newPassword, PasswordStrengthRegularExpression))
                {
                    throw new ArgumentException(SR.GetString(SR.Password_does_not_match_regular_expression,
                                                             "newPassword"));
                }
            }

            string pass = EncodePassword(newPassword);
            if (pass.Length > 128)
            {
                throw new ArgumentException(SR.GetString(SR.Membership_password_too_long), "newPassword");
            }

            return SqlHelper.ExecuteNonQuery(CommandType.Text, "update tbOper set cnvcPwd = '" + pass + "' where cnvcOperName = '" + username + "'")>0;								
                
        }

        public  void UpdateUser(Oper user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            EntityMapping.Update(user);
        }


        public override bool ValidateUser(string username, string password)
        {
            if (SecUtility.ValidateParameter(ref username, true, true, true, 256) &&
                    SecUtility.ValidateParameter(ref password, true, true, false, 128) &&
                    CheckPassword(username, password, true))
            {
                // Comment out perf counters in sample: PerfCounters.IncrementCounter(AppPerfCounter.MEMBER_SUCCESS);
                // Comment out events in sample: WebBaseEvent.RaiseSystemEvent(null, WebEventCodes.AuditMembershipAuthenticationSuccess, username);
                return true;
            }
            else
            {
                // Comment out perf counters in sample: PerfCounters.IncrementCounter(AppPerfCounter.MEMBER_FAIL);
                // Comment out events in sample: WebBaseEvent.RaiseSystemEvent(null, WebEventCodes.AuditMembershipAuthenticationFailure, username);
                return false;
            }
        }

        public  Oper GetUser(int userid, bool userIsOnline)
        {
            Oper oper = new Oper();
            oper.cnnOperID = userid;
            oper = EntityMapping.Get(oper) as Oper;
            if (userIsOnline)
            {
                oper.LastActivityDate = DateTime.Now;
                EntityMapping.Update(oper);
            }
            return oper;
        }
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public Oper  GetUser2(string username, bool userIsOnline)
        {
            SecUtility.CheckParameter(
                            ref username,
                            true,
                            false,
                            true,
                            256,
                            "username");
            DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text,"select * from tbOper where cnvcOperName='"+username+"'");
            if (dt.Rows.Count == 0) throw new BusinessException("查找操作员", "操作员没找到");
            Oper oper = new Oper(dt);
            if (userIsOnline)
            {
                oper.LastActivityDate = DateTime.Now;
                EntityMapping.Update(oper);
            }
            return oper;
        }

        public  bool DeleteUser(string username)
        {
            SecUtility.CheckParameter(ref username, true, true, true, 256, "username");
            int count=SqlHelper.ExecuteNonQuery(CommandType.Text, "delete from tbOper where cnvcOperName='"+username+"'");
            return count > 0 ? true : false;
        }

        public  DataTable GetAllUsers()
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbOper");
        }

        public override int GetNumberOfUsersOnline()
        {
            DateTime dt = DateTime.Now;
            dt.AddMinutes(-Membership.UserIsOnlineTimeWindow);
            object strcount = SqlHelper.ExecuteScalar(CommandType.Text, "select count(*) from tbOper where LastActivityDate>'"+dt.ToString()+"'");
            return Convert.ToInt32(strcount);            
        }
        
        private bool CheckPassword(string username, string password, bool updateLastLoginActivityDate)
        {
            string passwdFromDB;
            int failedPasswordAttemptCount;
            bool isPasswordCorrect;
            DateTime lastLoginDate, lastActivityDate;

            DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbOper where cnvcOperName='" + username + "'");
            if (dt.Rows.Count == 0) throw new BusinessException("操作员登录", "未找到操作员！");
            Oper oper = new Oper(dt);

            GetPasswordWithFormat(oper, updateLastLoginActivityDate, out passwdFromDB, out failedPasswordAttemptCount,
                                  out lastLoginDate, out lastActivityDate);                       

            //string encodedPasswd = EncodePassword(password);

            isPasswordCorrect = UnEncodePassword(passwdFromDB).Equals(password);

            if (isPasswordCorrect)
                return true;
            oper.FailedPasswordAttemptCount = oper.FailedPasswordAttemptCount + 1;
            oper.FailedPasswordAttemptWindowStart = DateTime.Now;

            EntityMapping.Update(oper);            
            return isPasswordCorrect;
        }
        private void GetPasswordWithFormat(Oper oper,
                                            bool updateLastLoginActivityDate,
                                            out string password,                            
                                            out int failedPasswordAttemptCount,
                                            out DateTime lastLoginDate,
                                            out DateTime lastActivityDate)
        {
            
            failedPasswordAttemptCount = oper.FailedPasswordAttemptCount;
            lastActivityDate = oper.LastActivityDate;
            lastLoginDate = oper.LastLoginDate;
            password = oper.cnvcPwd;

            if (updateLastLoginActivityDate)
            {
                oper.LastLoginDate = DateTime.Now;
                oper.LastActivityDate = DateTime.Now;
                EntityMapping.Update(oper);
            }
        }        
        
        internal string EncodePassword(string pass)
        {
            byte[] bIn = Encoding.UTF8.GetBytes(pass);
            byte[] bRet = Cryptographer.EncryptSymmetric("Custom Symmetric Cryptography Provider", bIn);
            return Convert.ToBase64String(bRet);
            //return Cryptographer.EncryptSymmetric("RijndaelManaged", pass);
        }
        internal string UnEncodePassword(string pass)
        {
            byte[] bIn = Convert.FromBase64String(pass);
            byte[] bRet = Cryptographer.DecryptSymmetric("Custom Symmetric Cryptography Provider", bIn);
            if (bRet == null)
                return null;
            return Encoding.UTF8.GetString(bRet);
            //return Cryptographer.DecryptSymmetric("RijndaelManaged",pass);
        }
        protected override byte[] EncryptPassword(byte[] password)
        {
            return Cryptographer.EncryptSymmetric("Custom Symmetric Cryptography Provider", password);
        }
        protected override byte[] DecryptPassword(byte[] encodedPassword)
        {
            return Cryptographer.DecryptSymmetric("Custom Symmetric Cryptography Provider", encodedPassword);
        }

        public override string ApplicationName
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string GetPassword(string username, string answer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        //public override MembershipPasswordFormat PasswordFormat
        //{
        //    get { throw new Exception("The method or operation is not implemented."); }
        //}

        public override string ResetPassword(string username, string answer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool UnlockUser(string userName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
