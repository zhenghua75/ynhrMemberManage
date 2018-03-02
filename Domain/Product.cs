
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	Product.cs
* 作者:	     郑华
* 创建日期:    2008-1-23
* 功能描述:    服务产品消费流水表

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
	/// **功能名称：服务产品消费流水表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbProduct")]
	public class Product: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region 数据表生成变量
		private decimal _cnnSerialNo;
		private string _cnvcMemberCardNo = String.Empty;
		private string _cnvcPaperNo = String.Empty;
		private string _cnvcMemberName = String.Empty;
		private string _cnvcProduct = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		#endregion
		
		#region 构造函数
		public Product():base()
		{
		}
		
		public Product(DataRow row):base(row)
		{
		}
		
		public Product(DataTable table):base(table)
		{
		}
		
		public Product(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性
	
		/// <summary>
		/// 流水
		/// </summary>
		[ColumnMapping("cnnSerialNo",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnSerialNo
		{
			get {return _cnnSerialNo;}
			set {_cnnSerialNo = value;}
		}

		/// <summary>
		/// 会员卡号
		/// </summary>
		[ColumnMapping("cnvcMemberCardNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMemberCardNo
		{
			get {return _cnvcMemberCardNo;}
			set {_cnvcMemberCardNo = value;}
		}

		/// <summary>
		/// 工商注册号
		/// </summary>
		[ColumnMapping("cnvcPaperNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcPaperNo
		{
			get {return _cnvcPaperNo;}
			set {_cnvcPaperNo = value;}
		}

		/// <summary>
		/// 单位名称
		/// </summary>
		[ColumnMapping("cnvcMemberName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMemberName
		{
			get {return _cnvcMemberName;}
			set {_cnvcMemberName = value;}
		}

		/// <summary>
		/// 服务产品
		/// </summary>
		[ColumnMapping("cnvcProduct",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcProduct
		{
			get {return _cnvcProduct;}
			set {_cnvcProduct = value;}
		}

		/// <summary>
		/// 操作员
		/// </summary>
		[ColumnMapping("cnvcOperName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperName
		{
			get {return _cnvcOperName;}
			set {_cnvcOperName = value;}
		}

		/// <summary>
		/// 操作时间
		/// </summary>
		[ColumnMapping("cndOperDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndOperDate
		{
			get {return _cndOperDate;}
			set {_cndOperDate = value;}
		}
		#endregion
	}	
}
