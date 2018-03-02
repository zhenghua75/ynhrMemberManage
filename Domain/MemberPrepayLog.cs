
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	MemberPrepayLog.cs
* 作者:	     郑华
* 创建日期:    2011/2/18
* 功能描述:    会员充值日志表

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
    /// **功能名称：会员充值日志表实体类
    /// </summary>
    [Serializable]
    [TableMapping("tbMemberPrepayLog")]
    public class MemberPrepayLog : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region 数据表生成变量
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

        #region 构造函数
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
        /// 会员卡号
        /// </summary>
        [ColumnMapping("cnvcMemberCardNo", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcMemberCardNo
        {
            get { return _cnvcMemberCardNo; }
            set { _cnvcMemberCardNo = value; }
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
        /// 操作类型(发卡 充值)
        /// </summary>
        [ColumnMapping("cnvcOperFlag", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcOperFlag
        {
            get { return _cnvcOperFlag; }
            set { _cnvcOperFlag = value; }
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
        /// <summary>
        /// 业务员 zhh 20130312
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
