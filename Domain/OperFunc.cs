
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	OperFunc.cs
* ����:	     ֣��
* ��������:    2011/2/21
* ��������:    ����ԱȨ���б�

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
    /// **�������ƣ�����ԱȨ���б�ʵ����
    /// </summary>
    [Serializable]
    [TableMapping("tbOperFunc")]
    public class OperFunc : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region ���ݱ����ɱ���
        private int _cnnOperID;
        private string _cnvcFuncCode = String.Empty;
        private string _cnvcCardType = String.Empty;
        #endregion

        #region ���캯��
        public OperFunc()
            : base()
        {
        }

        public OperFunc(DataRow row)
            : base(row)
        {
        }

        public OperFunc(DataTable table)
            : base(table)
        {
        }

        public OperFunc(string strXML)
            : base(strXML)
        {
        }
        #endregion

        #region ϵͳ��������

        /// <summary>
        /// ����ԱID
        /// </summary>
        [ColumnMapping("cnnOperID", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
        public int cnnOperID
        {
            get { return _cnnOperID; }
            set { _cnnOperID = value; }
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
