
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	JobSerialNo.cs
* 作者:	     郑华
* 创建日期:    2008-1-15
* 功能描述:    招聘会ID流水

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
	/// **功能名称：招聘会ID流水实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbJobSerialNo")]
	public class JobSerialNo: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region 数据表生成变量
		private int _ID;
		private string _cnvcFill = String.Empty;
		#endregion
		
		#region 构造函数
		public JobSerialNo():base()
		{
		}
		
		public JobSerialNo(DataRow row):base(row)
		{
		}
		
		public JobSerialNo(DataTable table):base(table)
		{
		}
		
		public JobSerialNo(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性
	
		/// <summary>
		/// ID
		/// </summary>
		[ColumnMapping("ID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public int ID
		{
			get {return _ID;}
			set {_ID = value;}
		}

		/// <summary>
		/// cnvcFill
		/// </summary>
		[ColumnMapping("cnvcFill",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFill
		{
			get {return _cnvcFill;}
			set {_cnvcFill = value;}
		}
		#endregion
	}	
}
