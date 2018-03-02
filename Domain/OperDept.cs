
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	OperDept.cs
* ����:	     ֣��
* ��������:    2013-3-15
* ��������:    ����Ա����Ȩ��

*                                                           Copyright(C) 2013 zhenghua
*************************************************************************************/
#region Import NameSpace
using System;
using System.Data;
using ynhrMemberManage.ORM;
#endregion

namespace ynhrMemberManage.Domain
{
    /// <summary>
    /// **�������ƣ�����Ա����Ȩ��ʵ����
    /// </summary>
    [Serializable]
    [TableMapping("tbOperDept")]
    public class OperDept : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region ���ݱ����ɱ���
        private int _cnnOperID;
        private int _cnnDeptID;
        #endregion

        #region ���캯��
        public OperDept()
            : base()
        {
        }

        public OperDept(DataRow row)
            : base(row)
        {
        }

        public OperDept(DataTable table)
            : base(table)
        {
        }

        public OperDept(string strXML)
            : base(strXML)
        {
        }
        #endregion

        #region ϵͳ��������

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnnOperID", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
        public int cnnOperID
        {
            get { return _cnnOperID; }
            set { _cnnOperID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnnDeptID", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
        public int cnnDeptID
        {
            get { return _cnnDeptID; }
            set { _cnnDeptID = value; }
        }
        #endregion
    }
}
