
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	ShowLog.cs
* 作者:	     郑华
* 创建日期:    2008-1-15
* 功能描述:    展厅日志

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
	/// **功能名称：展厅日志实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbShowLog")]
	public class ShowLog: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region 数据表生成变量
		private decimal _cnnSerialNo;
		private int _cnnShowID;
		private int _cnnJobID;
		private string _cnvcShowName = String.Empty;
		private int _cnnX;
		private int _cnnY;
		private int _cnnWeight;
		private int _cnnHeight;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		#endregion
		
		#region 构造函数
		public ShowLog():base()
		{
		}
		
		public ShowLog(DataRow row):base(row)
		{
		}
		
		public ShowLog(DataTable table):base(table)
		{
		}
		
		public ShowLog(string  strXML):base(strXML)
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
		/// 展厅ID
		/// </summary>
		[ColumnMapping("cnnShowID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnShowID
		{
			get {return _cnnShowID;}
			set {_cnnShowID = value;}
		}

		/// <summary>
		/// 招聘会
		/// </summary>
		[ColumnMapping("cnnJobID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnJobID
		{
			get {return _cnnJobID;}
			set {_cnnJobID = value;}
		}

		/// <summary>
		/// 展厅名称
		/// </summary>
		[ColumnMapping("cnvcShowName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcShowName
		{
			get {return _cnvcShowName;}
			set {_cnvcShowName = value;}
		}

		/// <summary>
		/// 展厅X位置
		/// </summary>
		[ColumnMapping("cnnX",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnX
		{
			get {return _cnnX;}
			set {_cnnX = value;}
		}

		/// <summary>
		/// 展厅Y位置
		/// </summary>
		[ColumnMapping("cnnY",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnY
		{
			get {return _cnnY;}
			set {_cnnY = value;}
		}

		/// <summary>
		/// 展厅宽度
		/// </summary>
		[ColumnMapping("cnnWeight",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnWeight
		{
			get {return _cnnWeight;}
			set {_cnnWeight = value;}
		}

		/// <summary>
		/// 展厅高度
		/// </summary>
		[ColumnMapping("cnnHeight",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnHeight
		{
			get {return _cnnHeight;}
			set {_cnnHeight = value;}
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
		/// 操作员时间
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
