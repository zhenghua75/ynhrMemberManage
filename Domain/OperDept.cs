
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	OperDept.cs
* 作者:	     郑华
* 创建日期:    2013-3-15
* 功能描述:    操作员部门权限

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
    /// **功能名称：操作员部门权限实体类
    /// </summary>
    [Serializable]
    [TableMapping("tbOperDept")]
    public class OperDept : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region 数据表生成变量
        private int _cnnOperID;
        private int _cnnDeptID;
        #endregion

        #region 构造函数
        public OperDept()
            : base()
        {
        }

        public OperDept(DataRow row)
            : base(row)
        {
        }

        public OperDept(DataTable table)
            : base(table)
        {
        }

        public OperDept(string strXML)
            : base(strXML)
        {
        }
        #endregion

        #region 系统生成属性

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnnOperID", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
        public int cnnOperID
        {
            get { return _cnnOperID; }
            set { _cnnOperID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnnDeptID", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
        public int cnnDeptID
        {
            get { return _cnnDeptID; }
            set { _cnnDeptID = value; }
        }
        #endregion
    }
}
