
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	Oper.cs
* 作者:	     郑华
* 创建日期:    2011/2/6
* 功能描述:    操作员表实体类

*                                                           Copyright(C) 2011 zhenghua
*************************************************************************************/
#region Import NameSpace
using System;
using System.Data;
using ynhrMemberManage.ORM;
#endregion

namespace ynhrMemberManage.Domain
{
    /// <summary>
    /// **功能名称：操作员表实体类实体类
    /// </summary>
    [Serializable]
    [TableMapping("tbOper")]
    public class Oper : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region 数据表生成变量
        private int _cnnOperID;
        private string _cnvcOperName = String.Empty;
        private string _cnvcPwd = String.Empty;
        private int _cnnDeptID;
        private string _cnvcCardNo = String.Empty;
        private DateTime _LastActivityDate;
        private DateTime _CreateDate;
        private DateTime _LastLoginDate;
        private DateTime _LastPasswordChangedDate;
        private DateTime _LastLockoutDate;
        private int _FailedPasswordAttemptCount;
        private DateTime _FailedPasswordAttemptWindowStart;
        #endregion

        #region 构造函数
        public Oper()
            : base()
        {
        }

        public Oper(DataRow row)
            : base(row)
        {
        }

        public Oper(DataTable table)
            : base(table)
        {
        }

        public Oper(string strXML)
            : base(strXML)
        {
        }
        #endregion

        #region 系统生成属性

        /// <summary>
        /// 操作员ID
        /// </summary>
        [ColumnMapping("cnnOperID", IsPrimaryKey = true, IsIdentity = true, IsVersionNumber = false)]
        public int cnnOperID
        {
            get { return _cnnOperID; }
            set { _cnnOperID = value; }
        }

        /// <summary>
        /// 操作员名称
        /// </summary>
        [ColumnMapping("cnvcOperName", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcOperName
        {
            get { return _cnvcOperName; }
            set { _cnvcOperName = value; }
        }

        /// <summary>
        /// 密码
        /// </summary>
        [ColumnMapping("cnvcPwd", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcPwd
        {
            get { return _cnvcPwd; }
            set { _cnvcPwd = value; }
        }

        /// <summary>
        /// 部门ID
        /// </summary>
        [ColumnMapping("cnnDeptID", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public int cnnDeptID
        {
            get { return _cnnDeptID; }
            set { _cnnDeptID = value; }
        }

        /// <summary>
        /// 登录卡号
        /// </summary>
        [ColumnMapping("cnvcCardNo", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcCardNo
        {
            get { return _cnvcCardNo; }
            set { _cnvcCardNo = value; }
        }

        /// <summary>
        /// 用户最后一次活动时间
        /// </summary>
        [ColumnMapping("LastActivityDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public DateTime LastActivityDate
        {
            get { return _LastActivityDate; }
            set { _LastActivityDate = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        [ColumnMapping("CreateDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        [ColumnMapping("LastLoginDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public DateTime LastLoginDate
        {
            get { return _LastLoginDate; }
            set { _LastLoginDate = value; }
        }

        /// <summary>
        /// 密码最后修改时间
        /// </summary>
        [ColumnMapping("LastPasswordChangedDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public DateTime LastPasswordChangedDate
        {
            get { return _LastPasswordChangedDate; }
            set { _LastPasswordChangedDate = value; }
        }

        /// <summary>
        /// 最后登出的时间
        /// </summary>
        [ColumnMapping("LastLockoutDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public DateTime LastLockoutDate
        {
            get { return _LastLockoutDate; }
            set { _LastLockoutDate = value; }
        }

        /// <summary>
        /// 连续登录失败次数
        /// </summary>
        [ColumnMapping("FailedPasswordAttemptCount", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public int FailedPasswordAttemptCount
        {
            get { return _FailedPasswordAttemptCount; }
            set { _FailedPasswordAttemptCount = value; }
        }

        /// <summary>
        /// 最后登录失败的时间
        /// </summary>
        [ColumnMapping("FailedPasswordAttemptWindowStart", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public DateTime FailedPasswordAttemptWindowStart
        {
            get { return _FailedPasswordAttemptWindowStart; }
            set { _FailedPasswordAttemptWindowStart = value; }
        }
        #endregion
    }
}
