
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	NameCode.cs
* 作者:	     郑华
* 创建日期:    2007-12-23
* 功能描述:    代码表

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
	/// **功能名称：代码表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbNameCode")]
	public class NameCode: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region 数据表生成变量
		private int _cnvcCodeID;
		private string _cnvcType = String.Empty;
		private string _cnvcValue = String.Empty;
		#endregion
		
		#region 构造函数
		public NameCode():base()
		{
		}
		
		public NameCode(DataRow row):base(row)
		{
		}
		
		public NameCode(DataTable table):base(table)
		{
		}
		
		public NameCode(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性
	
		/// <summary>
		/// 代码ID
		/// </summary>
		[ColumnMapping("cnvcCodeID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public int cnvcCodeID
		{
			get {return _cnvcCodeID;}
			set {_cnvcCodeID = value;}
		}

		/// <summary>
		/// 代码类型
		/// </summary>
		[ColumnMapping("cnvcType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcType
		{
			get {return _cnvcType;}
			set {_cnvcType = value;}
		}

		/// <summary>
		/// 代码值
		/// </summary>
		[ColumnMapping("cnvcValue",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcValue
		{
			get {return _cnvcValue;}
			set {_cnvcValue = value;}
		}
		#endregion
	}	
}
