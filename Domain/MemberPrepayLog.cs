
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	MemberPrepayLog.cs
* ����:	     ֣��
* ��������:    2011/2/18
* ��������:    ��Ա��ֵ��־��

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
    /// **�������ƣ���Ա��ֵ��־��ʵ����
    /// </summary>
    [Serializable]
    [TableMapping("tbMemberPrepayLog")]
    public class MemberPrepayLog : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region ���ݱ����ɱ���
        private decimal _cnnSerialNo;
        private string _cnvcMemberCardNo = String.Empty;
        private decimal _cnnPrepay;
        private string _cnvcFree = String.Empty;
        private string _cnvcOperName = String.Empty;
        private DateTime _cndOperDate;
        private string _cnvcOperFlag = String.Empty;
        private decimal _cnnLastBalance;
        private decimal _cnnBalance;
        private decimal _cnnDonate;
        //zhh 20130312
        private string _cnvcSales = String.Empty;
        #endregion

        #region ���캯��
        public MemberPrepayLog()
            : base()
        {
        }

        public MemberPrepayLog(DataRow row)
            : base(row)
        {
        }

        public MemberPrepayLog(DataTable table)
            : base(table)
        {
        }

        public MemberPrepayLog(string strXML)
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
        /// ��Ա����
        /// </summary>
        [ColumnMapping("cnvcMemberCardNo", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcMemberCardNo
        {
            get { return _cnvcMemberCardNo; }
            set { _cnvcMemberCardNo = value; }
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
        /// ��������(���� ��ֵ)
        /// </summary>
        [ColumnMapping("cnvcOperFlag", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcOperFlag
        {
            get { return _cnvcOperFlag; }
            set { _cnvcOperFlag = value; }
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
        /// <summary>
        /// ҵ��Ա zhh 20130312
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
