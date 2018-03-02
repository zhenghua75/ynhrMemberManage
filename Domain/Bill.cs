
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	Bill.cs
* 作者:	     郑华
* 创建日期:    2011/2/18
* 功能描述:    小票表

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
    /// **功能名称：小票表实体类
    /// </summary>
    [Serializable]
    [TableMapping("tbBill")]
    public class Bill : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region 数据表生成变量
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

        #region 构造函数
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

        #region 系统生成属性
        /// <summary>
        /// 同步标志
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
        /// 会员卡号
        /// </summary>
        [ColumnMapping("cnvcMemberCardNo", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcMemberCardNo
        {
            get { return _cnvcMemberCardNo; }
            set { _cnvcMemberCardNo = value; }
        }

        /// <summary>
        /// 会员密码
        /// </summary>
        [ColumnMapping("cnvcMemberPwd", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcMemberPwd
        {
            get { return _cnvcMemberPwd; }
            set { _cnvcMemberPwd = value; }
        }

        /// <summary>
        /// 单位名称
        /// </summary>
        [ColumnMapping("cnvcMemberName", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcMemberName
        {
            get { return _cnvcMemberName; }
            set { _cnvcMemberName = value; }
        }

        /// <summary>
        /// 操作员
        /// </summary>
        [ColumnMapping("cnvcOperName", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcOperName
        {
            get { return _cnvcOperName; }
            set { _cnvcOperName = value; }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        [ColumnMapping("cndOperDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public DateTime cndOperDate
        {
            get { return _cndOperDate; }
            set { _cndOperDate = value; }
        }

        /// <summary>
        /// 小票类型
        /// </summary>
        [ColumnMapping("cnvcBillType", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcBillType
        {
            get { return _cnvcBillType; }
            set { _cnvcBillType = value; }
        }

        /// <summary>
        /// 重打次数
        /// </summary>
        [ColumnMapping("cnnRepeats", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public int cnnRepeats
        {
            get { return _cnnRepeats; }
            set { _cnnRepeats = value; }
        }

        /// <summary>
        /// 会员费
        /// </summary>
        [ColumnMapping("cnnMemberFee", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnMemberFee
        {
            get { return _cnnMemberFee; }
            set { _cnnMemberFee = value; }
        }

        /// <summary>
        /// 折扣
        /// </summary>
        [ColumnMapping("cnvcDiscount", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcDiscount
        {
            get { return _cnvcDiscount; }
            set { _cnvcDiscount = value; }
        }

        /// <summary>
        /// 实收
        /// </summary>
        [ColumnMapping("cnnPrepay", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnPrepay
        {
            get { return _cnnPrepay; }
            set { _cnnPrepay = value; }
        }

        /// <summary>
        /// 免费场次
        /// </summary>
        [ColumnMapping("cnvcFree", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcFree
        {
            get { return _cnvcFree; }
            set { _cnvcFree = value; }
        }

        /// <summary>
        /// 卡使用时限
        /// </summary>
        [ColumnMapping("cndEndDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cndEndDate
        {
            get { return _cndEndDate; }
            set { _cndEndDate = value; }
        }

        /// <summary>
        /// 工商注册号
        /// </summary>
        [ColumnMapping("cnvcPaperNo", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcPaperNo
        {
            get { return _cnvcPaperNo; }
            set { _cnvcPaperNo = value; }
        }

        /// <summary>
        /// 展位
        /// </summary>
        [ColumnMapping("cnvcSeat", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcSeat
        {
            get { return _cnvcSeat; }
            set { _cnvcSeat = value; }
        }

        /// <summary>
        /// 产品
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
        /// 上次余额
        /// </summary>
        [ColumnMapping("cnnLastBalance", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnLastBalance
        {
            get { return _cnnLastBalance; }
            set { _cnnLastBalance = value; }
        }

        /// <summary>
        /// 当前余额
        /// </summary>
        [ColumnMapping("cnnBalance", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnBalance
        {
            get { return _cnnBalance; }
            set { _cnnBalance = value; }
        }

        /// <summary>
        /// 赠送金额
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
