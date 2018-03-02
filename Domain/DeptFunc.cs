
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	DeptFunc.cs
* ����:	     ֣��
* ��������:    2011/2/21
* ��������:    ����Ȩ���б�

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
    /// **�������ƣ�����Ȩ���б�ʵ����
    /// </summary>
    [Serializable]
    [TableMapping("tbDeptFunc")]
    public class DeptFunc : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region ���ݱ����ɱ���
        private int _cnnDeptID;
        private string _cnvcFuncCode = String.Empty;
        private string _cnvcCardType = String.Empty;
        #endregion

        #region ���캯��
        public DeptFunc()
            : base()
        {
        }

        public DeptFunc(DataRow row)
            : base(row)
        {
        }

        public DeptFunc(DataTable table)
            : base(table)
        {
        }

        public DeptFunc(string strXML)
            : base(strXML)
        {
        }
        #endregion

        #region ϵͳ��������

        /// <summary>
        /// ����ID
        /// </summary>
        [ColumnMapping("cnnDeptID", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
        public int cnnDeptID
        {
            get { return _cnnDeptID; }
            set { _cnnDeptID = value; }
        }

        /// <summary>
        /// ����ID
        /// </summary>
        [ColumnMapping("cnvcFuncCode", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcFuncCode
        {
            get { return _cnvcFuncCode; }
            set { _cnvcFuncCode = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcCardType", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcCardType
        {
            get { return _cnvcCardType; }
            set { _cnvcCardType = value; }
        }
        #endregion
    }
}
