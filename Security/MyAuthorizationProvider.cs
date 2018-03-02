using System;
using System.Configuration;
//using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Microsoft.Practices.EnterpriseLibrary.Security.Instrumentation;
//using Microsoft.Practices.EnterpriseLibrary.Security.Authorization;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using ynhrMemberManage.ORM;
using System.Data;
using ynhrMemberManage.Domain;


namespace ynhrMemeberManage.Security
{
    /// <summary>
    /// Authentication provider for rules stored in a database table.
    /// </summary>
    /// <remarks>
    /// This provider uses the same Authentication rules provided in the default
    /// AuthorizationRuleProvider, except it stores them in a database table rather than
    /// the configuration Xml file.
    /// 
    /// </remarks>
    /// 
    [ConfigurationElementType(typeof(CustomAuthorizationProviderData))]
    public class MyAuthorizationProvider : AuthorizationProvider
    {

        public MyAuthorizationProvider()
        {
            // No constructor logic needed
        }

        #region IAuthorizationProvider Members

        /// <summary>
        /// Checks a user's authorization against a given rule
        /// </summary>
        /// <param name="principal">The user to authorize</param>
        /// <param name="context">The name of the rule to check</param>
        /// <returns>boolean indicating whether the user is authorized</returns>
        public override bool Authorize(System.Security.Principal.IPrincipal principal, string context)
        {
            if (principal == null)
            {
                throw new ArgumentNullException("principal");
            }
            if (context == null || context.Length == 0)
            {
                throw new ArgumentNullException("context");
            }            

            //SecurityAuthorizationCheckEvent.Fire(principal.Identity.Name, context);
            InstrumentationProvider.FireAuthorizationCheckPerformed(principal.Identity.Name, context);

            DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbOper where cnvcOperName='"+principal.Identity.Name+"'");
            if (dt.Rows.Count == 0) return false;
            Oper oper = new Oper(dt);
            object objOperFunc = SqlHelper.ExecuteScalar(CommandType.Text, "select count(*) from tbOperFunc where cnnOperID="+oper.cnnOperID+" and cnvcFuncCode='"+context+"'");
            object objDeptFunc = SqlHelper.ExecuteScalar(CommandType.Text, "select count(*) from tbDeptFunc where cnnDeptID=" + oper.cnnDeptID + " and cnvcFuncCode='" + context + "'");
            int iOperFunc = Convert.ToInt32(objOperFunc);
            int iDeptFunc = Convert.ToInt32(objDeptFunc);

            bool result = iOperFunc + iDeptFunc > 0 ? true : false;

            if (result == false)
            {
                //SecurityAuthorizationFailedEvent.Fire(principal.Identity.Name, context);
                InstrumentationProvider.FireAuthorizationCheckFailed(principal.Identity.Name, context);
            }
            return result;

        }

        #endregion

    }
}
