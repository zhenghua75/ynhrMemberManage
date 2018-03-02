
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	ShowSeatLog.cs
* 作者:	     郑华
* 创建日期:    2008-1-17
* 功能描述:    展厅座位日志表

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
	/// **功能名称：展厅座位日志表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbShowSeatLog")]
	public class ShowSeatLog: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region 数据表生成变量
		private decimal _cnnSerialNo;
		private int _cnnJobID;
		private string _cnvcJobName = String.Empty;
		private string _cnvcControlName = String.Empty;
		private string _cnvcSeat = String.Empty;
		private string _cnvcDirection = String.Empty;
		private int _cnnX;
		private int _cnnY;
		private int _cnnHeight;
		private int _cnnWidth;
		private string _cnvcFloor = String.Empty;
		private string _cnvcState = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		#endregion
		
		#region 构造函数
		public ShowSeatLog():base()
		{
		}
		
		public ShowSeatLog(DataRow row):base(row)
		{
		}
		
		public ShowSeatLog(DataTable table):base(table)
		{
		}
		
		public ShowSeatLog(string  strXML):base(strXML)
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
		/// 招聘会ID
		/// </summary>
		[ColumnMapping("cnnJobID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public int cnnJobID
		{
			get {return _cnnJobID;}
			set {_cnnJobID = value;}
		}

		/// <summary>
		/// 招聘会名称
		/// </summary>
		[ColumnMapping("cnvcJobName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcJobName
		{
			get {return _cnvcJobName;}
			set {_cnvcJobName = value;}
		}

		/// <summary>
		/// 控件名称
		/// </summary>
		[ColumnMapping("cnvcControlName",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcControlName
		{
			get {return _cnvcControlName;}
			set {_cnvcControlName = value;}
		}

		/// <summary>
		/// 座位号
		/// </summary>
		[ColumnMapping("cnvcSeat",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcSeat
		{
			get {return _cnvcSeat;}
			set {_cnvcSeat = value;}
		}

		/// <summary>
		/// 朝向
		/// </summary>
		[ColumnMapping("cnvcDirection",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDirection
		{
			get {return _cnvcDirection;}
			set {_cnvcDirection = value;}
		}

		/// <summary>
		/// 坐标X
		/// </summary>
		[ColumnMapping("cnnX",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnX
		{
			get {return _cnnX;}
			set {_cnnX = value;}
		}

		/// <summary>
		/// 坐标Y
		/// </summary>
		[ColumnMapping("cnnY",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnY
		{
			get {return _cnnY;}
			set {_cnnY = value;}
		}

		/// <summary>
		/// 高度
		/// </summary>
		[ColumnMapping("cnnHeight",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnHeight
		{
			get {return _cnnHeight;}
			set {_cnnHeight = value;}
		}

		/// <summary>
		/// 宽度
		/// </summary>
		[ColumnMapping("cnnWidth",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnWidth
		{
			get {return _cnnWidth;}
			set {_cnnWidth = value;}
		}

		/// <summary>
		/// 展厅
		/// </summary>
		[ColumnMapping("cnvcFloor",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFloor
		{
			get {return _cnvcFloor;}
			set {_cnvcFloor = value;}
		}

		/// <summary>
		/// 展位状态
		/// </summary>
		[ColumnMapping("cnvcState",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcState
		{
			get {return _cnvcState;}
			set {_cnvcState = value;}
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
