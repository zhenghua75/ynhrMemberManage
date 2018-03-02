
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	OperFunc.cs
* 作者:	     郑华
* 创建日期:    2011/2/21
* 功能描述:    操作员权限列表

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
    /// **功能名称：操作员权限列表实体类
    /// </summary>
    [Serializable]
    [TableMapping("tbOperFunc")]
    public class OperFunc : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region 数据表生成变量
        private int _cnnOperID;
        private string _cnvcFuncCode = String.Empty;
        private string _cnvcCardType = String.Empty;
        #endregion

        #region 构造函数
        public OperFunc()
            : base()
        {
        }

        public OperFunc(DataRow row)
            : base(row)
        {
        }

        public OperFunc(DataTable table)
            : base(table)
        {
        }

        public OperFunc(string strXML)
            : base(strXML)
        {
        }
        #endregion

        #region 系统生成属性

        /// <summary>
        /// 操作员ID
        /// </summary>
        [ColumnMapping("cnnOperID", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
        public int cnnOperID
        {
            get { return _cnnOperID; }
            set { _cnnOperID = value; }
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
