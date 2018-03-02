
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	DeptFunc.cs
* 作者:	     郑华
* 创建日期:    2011/2/21
* 功能描述:    部门权限列表

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
    /// **功能名称：部门权限列表实体类
    /// </summary>
    [Serializable]
    [TableMapping("tbDeptFunc")]
    public class DeptFunc : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region 数据表生成变量
        private int _cnnDeptID;
        private string _cnvcFuncCode = String.Empty;
        private string _cnvcCardType = String.Empty;
        #endregion

        #region 构造函数
        public DeptFunc()
            : base()
        {
        }

        public DeptFunc(DataRow row)
            : base(row)
        {
        }

        public DeptFunc(DataTable table)
            : base(table)
        {
        }

        public DeptFunc(string strXML)
            : base(strXML)
        {
        }
        #endregion

        #region 系统生成属性

        /// <summary>
        /// 部门ID
        /// </summary>
        [ColumnMapping("cnnDeptID", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
        public int cnnDeptID
        {
            get { return _cnnDeptID; }
            set { _cnnDeptID = value; }
        }

        /// <summary>
        /// 功能ID
        /// </summary>
        [ColumnMapping("cnvcFuncCode", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcFuncCode
        {
            get { return _cnvcFuncCode; }
            set { _cnvcFuncCode = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcCardType", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcCardType
        {
            get { return _cnvcCardType; }
            set { _cnvcCardType = value; }
        }
        #endregion
    }
}
