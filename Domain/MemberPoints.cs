
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	MemberPoints.cs
* 作者:	     郑华
* 创建日期:    2011/2/11
* 功能描述:    会员积分表

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
    /// **功能名称：会员积分表实体类
    /// </summary>
    [Serializable]
    [TableMapping("tbMemberPoints")]
    public class MemberPoints : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region 数据表生成变量
        private string _cnvcMemberCardNo = String.Empty;
        private int _cnnPoints;
        #endregion

        #region 构造函数
        public MemberPoints()
            : base()
        {
        }

        public MemberPoints(DataRow row)
            : base(row)
        {
        }

        public MemberPoints(DataTable table)
            : base(table)
        {
        }

        public MemberPoints(string strXML)
            : base(strXML)
        {
        }
        #endregion

        #region 系统生成属性

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcMemberCardNo", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
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
        #endregion
    }
}
