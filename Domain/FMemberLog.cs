
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	FMemberLog.cs
* ����:	     ֣��
* ��������:    2011/2/16
* ��������:    �ǻ�Ա��ʷ��

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
    /// **�������ƣ��ǻ�Ա��ʷ��ʵ����
    /// </summary>
    [Serializable]
    [TableMapping("tbFMemberLog")]
    public class FMemberLog : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region ���ݱ����ɱ���
        private decimal _cnnSerialNo;
        private string _cnvcMemberName = String.Empty;
        private string _cnvcPaperNo = String.Empty;
        private string _cnvcCorporation = String.Empty;
        private string _cnvcCompanyAddress = String.Empty;
        private string _cnvcLinkman = String.Empty;
        private string _cnvcLinkPhone = String.Empty;
        private string _cnvcEmail = String.Empty;
        private string _cnvcComments = String.Empty;
        private string _cnvcMemberRight = String.Empty;
        private string _cnvcEnterpriseType = String.Empty;
        private string _cnvcDiscount = String.Empty;
        private string _cnvcProduct = String.Empty;
        private string _cnvcOperName = String.Empty;
        private DateTime _cndOperDate;
        private string _cnvcMobileTelePhone = String.Empty;
        private string _cnvcPostalCode = String.Empty;
        private string _cnvcSales = String.Empty;
        private string _cnvcHandleman = String.Empty;
        private string _cnvcHandlemanPaperNo = String.Empty;
        private string _cnvcTrade = String.Empty;
        private string _cnvcCustomerService = String.Empty;
        private DateTime _cndInNetDate;
        private string _cnvcFax = String.Empty;
        private decimal _cnnPrepay;
        #endregion

        #region ���캯��
        public FMemberLog()
            : base()
        {
        }

        public FMemberLog(DataRow row)
            : base(row)
        {
        }

        public FMemberLog(DataTable table)
            : base(table)
        {
        }

        public FMemberLog(string strXML)
            : base(strXML)
        {
        }
        #endregion

        #region ϵͳ��������

        /// <summary>
        /// ��ˮ
        /// </summary>
        [ColumnMapping("cnnSerialNo", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnSerialNo
        {
            get { return _cnnSerialNo; }
            set { _cnnSerialNo = value; }
        }

        /// <summary>
        /// ��λ����
        /// </summary>
        [ColumnMapping("cnvcMemberName", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcMemberName
        {
            get { return _cnvcMemberName; }
            set { _cnvcMemberName = value; }
        }

        /// <summary>
        /// ����ע���
        /// </summary>
        [ColumnMapping("cnvcPaperNo", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcPaperNo
        {
            get { return _cnvcPaperNo; }
            set { _cnvcPaperNo = value; }
        }

        /// <summary>
        /// ���˴���
        /// </summary>
        [ColumnMapping("cnvcCorporation", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcCorporation
        {
            get { return _cnvcCorporation; }
            set { _cnvcCorporation = value; }
        }

        /// <summary>
        /// ��λ��ַ
        /// </summary>
        [ColumnMapping("cnvcCompanyAddress", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcCompanyAddress
        {
            get { return _cnvcCompanyAddress; }
            set { _cnvcCompanyAddress = value; }
        }

        /// <summary>
        /// ��ϵ��
        /// </summary>
        [ColumnMapping("cnvcLinkman", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcLinkman
        {
            get { return _cnvcLinkman; }
            set { _cnvcLinkman = value; }
        }

        /// <summary>
        /// �칫�绰
        /// </summary>
        [ColumnMapping("cnvcLinkPhone", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcLinkPhone
        {
            get { return _cnvcLinkPhone; }
            set { _cnvcLinkPhone = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        [ColumnMapping("cnvcEmail", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcEmail
        {
            get { return _cnvcEmail; }
            set { _cnvcEmail = value; }
        }

        /// <summary>
        /// ��ע
        /// </summary>
        [ColumnMapping("cnvcComments", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcComments
        {
            get { return _cnvcComments; }
            set { _cnvcComments = value; }
        }

        /// <summary>
        /// ��Ա�ʸ�
        /// </summary>
        [ColumnMapping("cnvcMemberRight", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcMemberRight
        {
            get { return _cnvcMemberRight; }
            set { _cnvcMemberRight = value; }
        }

        /// <summary>
        /// ��ҵ����
        /// </summary>
        [ColumnMapping("cnvcEnterpriseType", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcEnterpriseType
        {
            get { return _cnvcEnterpriseType; }
            set { _cnvcEnterpriseType = value; }
        }

        /// <summary>
        /// �ۿ�
        /// </summary>
        [ColumnMapping("cnvcDiscount", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcDiscount
        {
            get { return _cnvcDiscount; }
            set { _cnvcDiscount = value; }
        }

        /// <summary>
        /// �����Ʒ
        /// </summary>
        [ColumnMapping("cnvcProduct", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcProduct
        {
            get { return _cnvcProduct; }
            set { _cnvcProduct = value; }
        }

        /// <summary>
        /// ����Ա
        /// </summary>
        [ColumnMapping("cnvcOperName", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcOperName
        {
            get { return _cnvcOperName; }
            set { _cnvcOperName = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        [ColumnMapping("cndOperDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public DateTime cndOperDate
        {
            get { return _cndOperDate; }
            set { _cndOperDate = value; }
        }

        /// <summary>
        /// �ֻ�����
        /// </summary>
        [ColumnMapping("cnvcMobileTelePhone", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcMobileTelePhone
        {
            get { return _cnvcMobileTelePhone; }
            set { _cnvcMobileTelePhone = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        [ColumnMapping("cnvcPostalCode", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcPostalCode
        {
            get { return _cnvcPostalCode; }
            set { _cnvcPostalCode = value; }
        }

        /// <summary>
        /// ������Ա
        /// </summary>
        [ColumnMapping("cnvcSales", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcSales
        {
            get { return _cnvcSales; }
            set { _cnvcSales = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        [ColumnMapping("cnvcHandleman", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcHandleman
        {
            get { return _cnvcHandleman; }
            set { _cnvcHandleman = value; }
        }

        /// <summary>
        /// ���������֤��
        /// </summary>
        [ColumnMapping("cnvcHandlemanPaperNo", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcHandlemanPaperNo
        {
            get { return _cnvcHandlemanPaperNo; }
            set { _cnvcHandlemanPaperNo = value; }
        }

        /// <summary>
        /// ��ҵ
        /// </summary>
        [ColumnMapping("cnvcTrade", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcTrade
        {
            get { return _cnvcTrade; }
            set { _cnvcTrade = value; }
        }

        /// <summary>
        /// �ͷ�����
        /// </summary>
        [ColumnMapping("cnvcCustomerService", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcCustomerService
        {
            get { return _cnvcCustomerService; }
            set { _cnvcCustomerService = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cndInNetDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public DateTime cndInNetDate
        {
            get { return _cndInNetDate; }
            set { _cndInNetDate = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcFax", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcFax
        {
            get { return _cnvcFax; }
            set { _cnvcFax = value; }
        }

        /// <summary>
        /// ʵ��
        /// </summary>
        [ColumnMapping("cnnPrepay", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnPrepay
        {
            get { return _cnnPrepay; }
            set { _cnnPrepay = value; }
        }
        #endregion
    }
}
