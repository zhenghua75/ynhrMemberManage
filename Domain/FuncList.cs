
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	FuncList.cs
* ����:	     ֣��
* ��������:    2011/2/21
* ��������:    �����б�

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
    /// **�������ƣ������б�ʵ����
    /// </summary>
    [Serializable]
    [TableMapping("tbFuncList")]
    public class FuncList : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region ���ݱ����ɱ���
        private string _cnvcFuncCode = String.Empty;
        private string _cnvcFuncName = String.Empty;
        private string _cnvcCardType = String.Empty;
        #endregion

        #region ���캯��
        public FuncList()
            : base()
        {
        }

        public FuncList(DataRow row)
            : base(row)
        {
        }

        public FuncList(DataTable table)
            : base(table)
        {
        }

        public FuncList(string strXML)
            : base(strXML)
        {
        }
        #endregion

        #region ϵͳ��������

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
        /// ��������
        /// </summary>
        [ColumnMapping("cnvcFuncName", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcFuncName
        {
            get { return _cnvcFuncName; }
            set { _cnvcFuncName = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        [ColumnMapping("cnvcCardType", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcCardType
        {
            get { return _cnvcCardType; }
            set { _cnvcCardType = value; }
        }
        #endregion
    }
}
