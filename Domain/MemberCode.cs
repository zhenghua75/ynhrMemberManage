
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	MemberCode.cs
* 作者:	     郑华
* 创建日期:    2007-12-25
* 功能描述:    会员代码表

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
	/// **功能名称：会员代码表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbMemberCode")]
	public class MemberCode: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region 数据表生成变量
		private int _cnnMemberCodeID;
		private string _cnvcMemberName = String.Empty;
		private string _cnvcMemberType = String.Empty;
		private string _cnvcMemberValue = String.Empty;
		#endregion
		
		#region 构造函数
		public MemberCode():base()
		{
		}
		
		public MemberCode(DataRow row):base(row)
		{
		}
		
		public MemberCode(DataTable table):base(table)
		{
		}
		
		public MemberCode(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性
	
		/// <summary>
		/// 会员代码ID
		/// </summary>
		[ColumnMapping("cnnMemberCodeID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public int cnnMemberCodeID
		{
			get {return _cnnMemberCodeID;}
			set {_cnnMemberCodeID = value;}
		}

		/// <summary>
		/// 会员名称
		/// </summary>
		[ColumnMapping("cnvcMemberName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMemberName
		{
			get {return _cnvcMemberName;}
			set {_cnvcMemberName = value;}
		}

		/// <summary>
		/// 会员代码类型
		/// </summary>
		[ColumnMapping("cnvcMemberType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMemberType
		{
			get {return _cnvcMemberType;}
			set {_cnvcMemberType = value;}
		}

		/// <summary>
		/// 会员代码类型值
		/// </summary>
		[ColumnMapping("cnvcMemberValue",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMemberValue
		{
			get {return _cnvcMemberValue;}
			set {_cnvcMemberValue = value;}
		}
		#endregion
	}	
}
