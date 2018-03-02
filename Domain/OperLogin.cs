
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	OperLogin.cs
* 作者:	     郑华
* 创建日期:    2008-1-20
* 功能描述:    操作员登录表

*                                                           Copyright(C) 2008 zhenghua
*************************************************************************************/
#region Import NameSpace
using System;
using System.Data;
using ynhrMemberManage.ORM;
#endregion

namespace ynhrMemberManage.Domain
{
	/// <summary>
	/// **功能名称：操作员登录表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbOperLogin")]
	public class OperLogin: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region 数据表生成变量
		private decimal _cnnSerialNp;
		private string _cnvcOperName = String.Empty;
		private int _cnnDeptID;
		private string _cnvcCardNo = String.Empty;
		private DateTime _cndLoginDate;
		private string _cnvcHostName = String.Empty;
		private string _cnvcHostAddress = String.Empty;
		private string _cnvcLoginMethod = String.Empty;
		private int _cnnAgainTime;
		#endregion
		
		#region 构造函数
		public OperLogin():base()
		{
		}
		
		public OperLogin(DataRow row):base(row)
		{
		}
		
		public OperLogin(DataTable table):base(table)
		{
		}
		
		public OperLogin(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性
	
		/// <summary>
		/// 流水
		/// </summary>
		[ColumnMapping("cnnSerialNp",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnSerialNp
		{
			get {return _cnnSerialNp;}
			set {_cnnSerialNp = value;}
		}

		/// <summary>
		/// 操作员名称
		/// </summary>
		[ColumnMapping("cnvcOperName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperName
		{
			get {return _cnvcOperName;}
			set {_cnvcOperName = value;}
		}

		/// <summary>
		/// 部门ID
		/// </summary>
		[ColumnMapping("cnnDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnDeptID
		{
			get {return _cnnDeptID;}
			set {_cnnDeptID = value;}
		}

		/// <summary>
		/// 登录卡号
		/// </summary>
		[ColumnMapping("cnvcCardNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCardNo
		{
			get {return _cnvcCardNo;}
			set {_cnvcCardNo = value;}
		}

		/// <summary>
		/// 登录时间
		/// </summary>
		[ColumnMapping("cndLoginDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndLoginDate
		{
			get {return _cndLoginDate;}
			set {_cndLoginDate = value;}
		}

		/// <summary>
		/// 主机名称
		/// </summary>
		[ColumnMapping("cnvcHostName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcHostName
		{
			get {return _cnvcHostName;}
			set {_cnvcHostName = value;}
		}

		/// <summary>
		/// 主机IP
		/// </summary>
		[ColumnMapping("cnvcHostAddress",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcHostAddress
		{
			get {return _cnvcHostAddress;}
			set {_cnvcHostAddress = value;}
		}

		/// <summary>
		/// 登录方式
		/// </summary>
		[ColumnMapping("cnvcLoginMethod",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcLoginMethod
		{
			get {return _cnvcLoginMethod;}
			set {_cnvcLoginMethod = value;}
		}

		/// <summary>
		/// 重试次数
		/// </summary>
		[ColumnMapping("cnnAgainTime",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnAgainTime
		{
			get {return _cnnAgainTime;}
			set {_cnnAgainTime = value;}
		}
		#endregion
	}	
}
