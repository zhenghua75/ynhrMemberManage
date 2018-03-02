
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	Bill.cs
* ����:	     ֣��
* ��������:    2011/2/18
* ��������:    СƱ��

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
    /// **�������ƣ�СƱ��ʵ����
    /// </summary>
    [Serializable]
    [TableMapping("tbBill")]
    public class Bill : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region ���ݱ����ɱ���
        private int _cnnID;
        private string _cnvcMemberCardNo = String.Empty;
        private string _cnvcMemberPwd = String.Empty;
        private string _cnvcMemberName = String.Empty;
        private string _cnvcOperName = String.Empty;
        private DateTime _cndOperDate;
        private string _cnvcBillType = String.Empty;
        private int _cnnRepeats;
        private decimal _cnnMemberFee;
        private string _cnvcDiscount = String.Empty;
        private decimal _cnnPrepay;
        private string _cnvcFree = String.Empty;
        private string _cndEndDate = String.Empty;
        private string _cnvcPaperNo = String.Empty;
        private string _cnvcSeat = String.Empty;
        private string _cnvcProduct = String.Empty;
        private string _cnvcMemberRight = String.Empty;
        private string _cnvcShow = String.Empty;
        private string _cnvcJobInfo = String.Empty;
        private decimal _cnnLastBalance;
        private decimal _cnnBalance;
        private decimal _cnnDonate;
        private string _cnvcSynch = String.Empty;
        #endregion

        #region ���캯��
        public Bill()
            : base()
        {
        }

        public Bill(DataRow row)
            : base(row)
        {
        }

        public Bill(DataTable table)
            : base(table)
        {
        }

        public Bill(string strXML)
            : base(strXML)
        {
        }
        #endregion

        #region ϵͳ��������
        /// <summary>
        /// ͬ����־
        /// </summary>
        [ColumnMapping("cnvcSynch", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcSynch
        {
            get { return _cnvcSynch; }
            set { _cnvcSynch = value; }
        }

        /// <summary>
        /// cnnID
        /// </summary>
        [ColumnMapping("cnnID", IsPrimaryKey = true, IsIdentity = true, IsVersionNumber = false)]
        public int cnnID
        {
            get { return _cnnID; }
            set { _cnnID = value; }
        }

        /// <summary>
        /// ��Ա����
        /// </summary>
        [ColumnMapping("cnvcMemberCardNo", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcMemberCardNo
        {
            get { return _cnvcMemberCardNo; }
            set { _cnvcMemberCardNo = value; }
        }

        /// <summary>
        /// ��Ա����
        /// </summary>
        [ColumnMapping("cnvcMemberPwd", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcMemberPwd
        {
            get { return _cnvcMemberPwd; }
            set { _cnvcMemberPwd = value; }
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
        /// СƱ����
        /// </summary>
        [ColumnMapping("cnvcBillType", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcBillType
        {
            get { return _cnvcBillType; }
            set { _cnvcBillType = value; }
        }

        /// <summary>
        /// �ش����
        /// </summary>
        [ColumnMapping("cnnRepeats", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public int cnnRepeats
        {
            get { return _cnnRepeats; }
            set { _cnnRepeats = value; }
        }

        /// <summary>
        /// ��Ա��
        /// </summary>
        [ColumnMapping("cnnMemberFee", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnMemberFee
        {
            get { return _cnnMemberFee; }
            set { _cnnMemberFee = value; }
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
        /// ʵ��
        /// </summary>
        [ColumnMapping("cnnPrepay", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnPrepay
        {
            get { return _cnnPrepay; }
            set { _cnnPrepay = value; }
        }

        /// <summary>
        /// ��ѳ���
        /// </summary>
        [ColumnMapping("cnvcFree", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcFree
        {
            get { return _cnvcFree; }
            set { _cnvcFree = value; }
        }

        /// <summary>
        /// ��ʹ��ʱ��
        /// </summary>
        [ColumnMapping("cndEndDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cndEndDate
        {
            get { return _cndEndDate; }
            set { _cndEndDate = value; }
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
        /// չλ
        /// </summary>
        [ColumnMapping("cnvcSeat", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcSeat
        {
            get { return _cnvcSeat; }
            set { _cnvcSeat = value; }
        }

        /// <summary>
        /// ��Ʒ
        /// </summary>
        [ColumnMapping("cnvcProduct", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcProduct
        {
            get { return _cnvcProduct; }
            set { _cnvcProduct = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcMemberRight", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcMemberRight
        {
            get { return _cnvcMemberRight; }
            set { _cnvcMemberRight = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcShow", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcShow
        {
            get { return _cnvcShow; }
            set { _cnvcShow = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcJobInfo", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcJobInfo
        {
            get { return _cnvcJobInfo; }
            set { _cnvcJobInfo = value; }
        }

        /// <summary>
        /// �ϴ����
        /// </summary>
        [ColumnMapping("cnnLastBalance", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnLastBalance
        {
            get { return _cnnLastBalance; }
            set { _cnnLastBalance = value; }
        }

        /// <summary>
        /// ��ǰ���
        /// </summary>
        [ColumnMapping("cnnBalance", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnBalance
        {
            get { return _cnnBalance; }
            set { _cnnBalance = value; }
        }

        /// <summary>
        /// ���ͽ��
        /// </summary>
        [ColumnMapping("cnnDonate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnDonate
        {
            get { return _cnnDonate; }
            set { _cnnDonate = value; }
        }
        #endregion
    }
}