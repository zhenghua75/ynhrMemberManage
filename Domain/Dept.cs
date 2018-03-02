
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	Dept.cs
* 作者:	     郑华
* 创建日期:    2007-12-25
* 功能描述:    部门表

*                                                           Copyright(C) 2007 zhenghua
*************************************************************************************/
#region Import NameSpace
using System;
using System.Data;
using ynhrMemberManage.ORM;
#endregion

namespace ynhrMemberManage.Domain
{
	/// <summary>
	/// **功能名称：部门表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbDept")]
	public class Dept: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region 数据表生成变量
		private int _cnnDeptID;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcManager = String.Empty;
		private int _cnnParentDeptID;
		private string _cnvcComments = String.Empty;
		private int _cnnDiscount;
		#endregion
		
		#region 构造函数
		public Dept():base()
		{
		}
		
		public Dept(DataRow row):base(row)
		{
		}
		
		public Dept(DataTable table):base(table)
		{
		}
		
		public Dept(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性
	
		/// <summary>
		/// 部门ID
		/// </summary>
		[ColumnMapping("cnnDeptID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public int cnnDeptID
		{
			get {return _cnnDeptID;}
			set {_cnnDeptID = value;}
		}

		/// <summary>
		/// 部门名称
		/// </summary>
		[ColumnMapping("cnvcDeptName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptName
		{
			get {return _cnvcDeptName;}
			set {_cnvcDeptName = value;}
		}

		/// <summary>
		/// 管理员
		/// </summary>
		[ColumnMapping("cnvcManager",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcManager
		{
			get {return _cnvcManager;}
			set {_cnvcManager = value;}
		}

		/// <summary>
		/// 上级部门
		/// </summary>
		[ColumnMapping("cnnParentDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnParentDeptID
		{
			get {return _cnnParentDeptID;}
			set {_cnnParentDeptID = value;}
		}

		/// <summary>
		/// 描述
		/// </summary>
		[ColumnMapping("cnvcComments",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcComments
		{
			get {return _cnvcComments;}
			set {_cnvcComments = value;}
		}

		/// <summary>
		/// 折扣
		/// </summary>
		[ColumnMapping("cnnDiscount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnDiscount
		{
			get {return _cnnDiscount;}
			set {_cnnDiscount = value;}
		}
		#endregion
	}	
}
