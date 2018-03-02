
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	FMemberProductLog.cs
* ����:	     ֣��
* ��������:    2011/2/19
* ��������:    �ǻ�Ա��Ʒ������־��

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
    /// **�������ƣ��ǻ�Ա��Ʒ������־��ʵ����
    /// </summary>
    [Serializable]
    [TableMapping("tbFMemberProductLog")]
    public class FMemberProductLog : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region ���ݱ����ɱ���
        private decimal _cnnSerialNo;
        private string _cnvcPaperNo = String.Empty;
        private string _cnvcMemberName = String.Empty;
        private string _cnvcProductName = String.Empty;
        private decimal _cnnProductPrice;
        private string _cnvcProductDiscount = String.Empty;
        private decimal _cnnPrepay;
        private string _cnvcFree = String.Empty;
        private string _cnvcOperName = String.Empty;
        private DateTime _cndOperDate;
        private decimal _cnnLastBalance;
        private decimal _cnnBalance;
        private decimal _cnnCount;
        //20130326
        private string _cnvcSales = String.Empty;
        #endregion

        #region ���캯��
        public FMemberProductLog()
            : base()
        {
        }

        public FMemberProductLog(DataRow row)
            : base(row)
        {
        }

        public FMemberProductLog(DataTable table)
            : base(table)
        {
        }

        public FMemberProductLog(string strXML)
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
        /// ����ע���
        /// </summary>
        [ColumnMapping("cnvcPaperNo", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcPaperNo
        {
            get { return _cnvcPaperNo; }
            set { _cnvcPaperNo = value; }
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
        /// �����Ʒ
        /// </summary>
        [ColumnMapping("cnvcProductName", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcProductName
        {
            get { return _cnvcProductName; }
            set { _cnvcProductName = value; }
        }

        /// <summary>
        /// ��Ʒ����
        /// </summary>
        [ColumnMapping("cnnProductPrice", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnProductPrice
        {
            get { return _cnnProductPrice; }
            set { _cnnProductPrice = value; }
        }

        /// <summary>
        /// ��Ʒ�ۿ�
        /// </summary>
        [ColumnMapping("cnvcProductDiscount", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcProductDiscount
        {
            get { return _cnvcProductDiscount; }
            set { _cnvcProductDiscount = value; }
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
        /// ����
        /// </summary>
        [ColumnMapping("cnnCount", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnCount
        {
            get { return _cnnCount; }
            set { _cnnCount = value; }
        }
        /// <summary>
        /// ҵ��Ա zhh 20130326
        /// </summary>
        [ColumnMapping("cnvcSales", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcSales
        {
            get { return _cnvcSales; }
            set { _cnvcSales = value; }
        }
        #endregion
    }
}
