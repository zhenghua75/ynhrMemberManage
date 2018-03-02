
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	FMemberProductLog.cs
* 作者:	     郑华
* 创建日期:    2011/2/19
* 功能描述:    非会员产品消费日志表

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
    /// **功能名称：非会员产品消费日志表实体类
    /// </summary>
    [Serializable]
    [TableMapping("tbFMemberProductLog")]
    public class FMemberProductLog : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region 数据表生成变量
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

        #region 构造函数
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

        #region 系统生成属性

        /// <summary>
        /// 流水
        /// </summary>
        [ColumnMapping("cnnSerialNo", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnSerialNo
        {
            get { return _cnnSerialNo; }
            set { _cnnSerialNo = value; }
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
        /// 单位名称
        /// </summary>
        [ColumnMapping("cnvcMemberName", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcMemberName
        {
            get { return _cnvcMemberName; }
            set { _cnvcMemberName = value; }
        }

        /// <summary>
        /// 服务产品
        /// </summary>
        [ColumnMapping("cnvcProductName", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcProductName
        {
            get { return _cnvcProductName; }
            set { _cnvcProductName = value; }
        }

        /// <summary>
        /// 产品单价
        /// </summary>
        [ColumnMapping("cnnProductPrice", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnProductPrice
        {
            get { return _cnnProductPrice; }
            set { _cnnProductPrice = value; }
        }

        /// <summary>
        /// 产品折扣
        /// </summary>
        [ColumnMapping("cnvcProductDiscount", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcProductDiscount
        {
            get { return _cnvcProductDiscount; }
            set { _cnvcProductDiscount = value; }
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
        /// 数量
        /// </summary>
        [ColumnMapping("cnnCount", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnCount
        {
            get { return _cnnCount; }
            set { _cnnCount = value; }
        }
        /// <summary>
        /// 业务员 zhh 20130326
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
