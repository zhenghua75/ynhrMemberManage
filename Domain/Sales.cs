
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	Sales.cs
* 作者:	     郑华
* 创建日期:    2013-3-12
* 功能描述:    业务员

*                                                           Copyright(C) 2013 zhenghua
*************************************************************************************/
#region Import NameSpace
using System;
using System.Data;
using ynhrMemberManage.ORM;
#endregion

namespace ynhrMemberManage.Domain
{
    /// <summary>
    /// **功能名称：业务员实体类
    /// </summary>
    [Serializable]
    [TableMapping("tbSales")]
    public class Sales : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region 数据表生成变量
        private int _cnnSales;
        private string _cnvcSales = String.Empty;
        private string _cnvcTel = String.Empty;
        private string _cnvcCredentials = String.Empty;
        private int _cnnDeptID;
        #endregion

        #region 构造函数
        public Sales()
            : base()
        {
        }

        public Sales(DataRow row)
            : base(row)
        {
        }

        public Sales(DataTable table)
            : base(table)
        {
        }

        public Sales(string strXML)
            : base(strXML)
        {
        }
        #endregion

        #region 系统生成属性

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnnSales", IsPrimaryKey = true, IsIdentity = true, IsVersionNumber = false)]
        public int cnnSales
        {
            get { return _cnnSales; }
            set { _cnnSales = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcSales", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcSales
        {
            get { return _cnvcSales; }
            set { _cnvcSales = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcTel", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcTel
        {
            get { return _cnvcTel; }
            set { _cnvcTel = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcCredentials", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcCredentials
        {
            get { return _cnvcCredentials; }
            set { _cnvcCredentials = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnnDeptID", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public int cnnDeptID
        {
            get { return _cnnDeptID; }
            set { _cnnDeptID = value; }
        }
        #endregion
    }
}
