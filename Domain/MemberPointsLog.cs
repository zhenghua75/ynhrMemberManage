
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	MemberPointsLog.cs
* 作者:	     郑华
* 创建日期:    2011/2/11
* 功能描述:    会员积分历史表

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
    /// **功能名称：会员积分历史表实体类
    /// </summary>
    [Serializable]
    [TableMapping("tbMemberPointsLog")]
    public class MemberPointsLog : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region 数据表生成变量
        private int _cnnSerialNo;
        private string _cnvcMemberCardNo = String.Empty;
        private int _cnnPoints;
        private string _cnvcOperName = String.Empty;
        private DateTime _cnvcOperDate;
        private string _cnvcOperFlag = String.Empty;
        #endregion

        #region 构造函数
        public MemberPointsLog()
            : base()
        {
        }

        public MemberPointsLog(DataRow row)
            : base(row)
        {
        }

        public MemberPointsLog(DataTable table)
            : base(table)
        {
        }

        public MemberPointsLog(string strXML)
            : base(strXML)
        {
        }
        #endregion

        #region 系统生成属性

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnnSerialNo", IsPrimaryKey = true, IsIdentity = true, IsVersionNumber = false)]
        public int cnnSerialNo
        {
            get { return _cnnSerialNo; }
            set { _cnnSerialNo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcMemberCardNo", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcMemberCardNo
        {
            get { return _cnvcMemberCardNo; }
            set { _cnvcMemberCardNo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnnPoints", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public int cnnPoints
        {
            get { return _cnnPoints; }
            set { _cnnPoints = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcOperName", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcOperName
        {
            get { return _cnvcOperName; }
            set { _cnvcOperName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcOperDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public DateTime cnvcOperDate
        {
            get { return _cnvcOperDate; }
            set { _cnvcOperDate = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcOperFlag", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcOperFlag
        {
            get { return _cnvcOperFlag; }
            set { _cnvcOperFlag = value; }
        }
        #endregion
    }
}
