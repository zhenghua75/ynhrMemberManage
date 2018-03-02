
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	Oper.cs
* ����:	     ֣��
* ��������:    2011/2/6
* ��������:    ����Ա��ʵ����

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
    /// **�������ƣ�����Ա��ʵ����ʵ����
    /// </summary>
    [Serializable]
    [TableMapping("tbOper")]
    public class Oper : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region ���ݱ����ɱ���
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

        #region ���캯��
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

        #region ϵͳ��������

        /// <summary>
        /// ����ԱID
        /// </summary>
        [ColumnMapping("cnnOperID", IsPrimaryKey = true, IsIdentity = true, IsVersionNumber = false)]
        public int cnnOperID
        {
            get { return _cnnOperID; }
            set { _cnnOperID = value; }
        }

        /// <summary>
        /// ����Ա����
        /// </summary>
        [ColumnMapping("cnvcOperName", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcOperName
        {
            get { return _cnvcOperName; }
            set { _cnvcOperName = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        [ColumnMapping("cnvcPwd", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcPwd
        {
            get { return _cnvcPwd; }
            set { _cnvcPwd = value; }
        }

        /// <summary>
        /// ����ID
        /// </summary>
        [ColumnMapping("cnnDeptID", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public int cnnDeptID
        {
            get { return _cnnDeptID; }
            set { _cnnDeptID = value; }
        }

        /// <summary>
        /// ��¼����
        /// </summary>
        [ColumnMapping("cnvcCardNo", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcCardNo
        {
            get { return _cnvcCardNo; }
            set { _cnvcCardNo = value; }
        }

        /// <summary>
        /// �û����һ�λʱ��
        /// </summary>
        [ColumnMapping("LastActivityDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public DateTime LastActivityDate
        {
            get { return _LastActivityDate; }
            set { _LastActivityDate = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        [ColumnMapping("CreateDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

        /// <summary>
        /// ����¼ʱ��
        /// </summary>
        [ColumnMapping("LastLoginDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public DateTime LastLoginDate
        {
            get { return _LastLoginDate; }
            set { _LastLoginDate = value; }
        }

        /// <summary>
        /// ��������޸�ʱ��
        /// </summary>
        [ColumnMapping("LastPasswordChangedDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public DateTime LastPasswordChangedDate
        {
            get { return _LastPasswordChangedDate; }
            set { _LastPasswordChangedDate = value; }
        }

        /// <summary>
        /// ���ǳ���ʱ��
        /// </summary>
        [ColumnMapping("LastLockoutDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public DateTime LastLockoutDate
        {
            get { return _LastLockoutDate; }
            set { _LastLockoutDate = value; }
        }

        /// <summary>
        /// ������¼ʧ�ܴ���
        /// </summary>
        [ColumnMapping("FailedPasswordAttemptCount", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public int FailedPasswordAttemptCount
        {
            get { return _FailedPasswordAttemptCount; }
            set { _FailedPasswordAttemptCount = value; }
        }

        /// <summary>
        /// ����¼ʧ�ܵ�ʱ��
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
