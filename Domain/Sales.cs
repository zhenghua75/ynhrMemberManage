
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	Sales.cs
* ����:	     ֣��
* ��������:    2013-3-12
* ��������:    ҵ��Ա

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
    /// **�������ƣ�ҵ��Աʵ����
    /// </summary>
    [Serializable]
    [TableMapping("tbSales")]
    public class Sales : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region ���ݱ����ɱ���
        private int _cnnSales;
        private string _cnvcSales = String.Empty;
        private string _cnvcTel = String.Empty;
        private string _cnvcCredentials = String.Empty;
        private int _cnnDeptID;
        #endregion

        #region ���캯��
        public Sales()
            : base()
        {
        }

        public Sales(DataRow row)
            : base(row)
        {
        }

        public Sales(DataTable table)
            : base(table)
        {
        }

        public Sales(string strXML)
            : base(strXML)
        {
        }
        #endregion

        #region ϵͳ��������

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnnSales", IsPrimaryKey = true, IsIdentity = true, IsVersionNumber = false)]
        public int cnnSales
        {
            get { return _cnnSales; }
            set { _cnnSales = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcSales", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcSales
        {
            get { return _cnvcSales; }
            set { _cnvcSales = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcTel", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcTel
        {
            get { return _cnvcTel; }
            set { _cnvcTel = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcCredentials", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcCredentials
        {
            get { return _cnvcCredentials; }
            set { _cnvcCredentials = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnnDeptID", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public int cnnDeptID
        {
            get { return _cnnDeptID; }
            set { _cnnDeptID = value; }
        }
        #endregion
    }
}
