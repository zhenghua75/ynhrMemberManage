
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	FMemberPrepayLog.cs
* ����:	     ֣��
* ��������:    2011/2/18
* ��������:    �ǻ�Ա��ֵ��־��

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
    /// **�������ƣ��ǻ�Ա��ֵ��־��ʵ����
    /// </summary>
    [Serializable]
    [TableMapping("tbFMemberPrepayLog")]
    public class FMemberPrepayLog : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region ���ݱ����ɱ���
        private decimal _cnnSerialNo;
        private string _cnvcPaperNo = String.Empty;
        private decimal _cnnLastBalance;
        private decimal _cnnPrepay;
        private decimal _cnnBalance;
        private decimal _cnnDonate;
        private string _cnvcOperName = String.Empty;
        private DateTime _cndOperDate;
        private string _cnvcOperFlag = String.Empty;
        //zhh 20130313
        private string _cnvcSales = String.Empty;
        #endregion

        #region ���캯��
        public FMemberPrepayLog()
            : base()
        {
        }

        public FMemberPrepayLog(DataRow row)
            : base(row)
        {
        }

        public FMemberPrepayLog(DataTable table)
            : base(table)
        {
        }

        public FMemberPrepayLog(string strXML)
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
        /// �ϴ����
        /// </summary>
        [ColumnMapping("cnnLastBalance", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnLastBalance
        {
            get { return _cnnLastBalance; }
            set { _cnnLastBalance = value; }
        }

        /// <summary>
        /// ��ֵ���
        /// </summary>
        [ColumnMapping("cnnPrepay", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnPrepay
        {
            get { return _cnnPrepay; }
            set { _cnnPrepay = value; }
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
        /// ��������
        /// </summary>
        [ColumnMapping("cnvcOperFlag", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcOperFlag
        {
            get { return _cnvcOperFlag; }
            set { _cnvcOperFlag = value; }
        }
        /// <summary>
        /// ҵ��Ա zhh 20130313
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
