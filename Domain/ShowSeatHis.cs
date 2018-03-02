
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	ShowSeatHis.cs
* 作者:	     郑华
* 创建日期:    2007-12-23
* 功能描述:    展位座位历史表

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
	/// **功能名称：展位座位历史表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbShowSeatHis")]
	public class ShowSeatHis: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region 数据表生成变量
		private int _cnnHisID;
		private int _cnnID;
		private string _cnvcJobName = String.Empty;
		private string _cnvcControlName = String.Empty;
		private string _cnvcSeat = String.Empty;
		private string _cnvcDirection = String.Empty;
		private int _cnnX;
		private int _cnnY;
		private int _cnnHeight;
		private int _cnnWidth;
		private string _cnvcFloor = String.Empty;
		private string _cnvcDefaultSeat = String.Empty;
		private string _cnvcState = String.Empty;
		private string _cnvcEndDate = String.Empty;
		#endregion
		
		#region 构造函数
		public ShowSeatHis():base()
		{
		}
		
		public ShowSeatHis(DataRow row):base(row)
		{
		}
		
		public ShowSeatHis(DataTable table):base(table)
		{
		}
		
		public ShowSeatHis(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性
	
		/// <summary>
		/// 历史ID
		/// </summary>
		[ColumnMapping("cnnHisID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public int cnnHisID
		{
			get {return _cnnHisID;}
			set {_cnnHisID = value;}
		}

		/// <summary>
		/// 招聘会ID
		/// </summary>
		[ColumnMapping("cnnID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnID
		{
			get {return _cnnID;}
			set {_cnnID = value;}
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
		[ColumnMapping("cnvcControlName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
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
		/// 层
		/// </summary>
		[ColumnMapping("cnvcFloor",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFloor
		{
			get {return _cnvcFloor;}
			set {_cnvcFloor = value;}
		}

		/// <summary>
		/// 默认座位设置
		/// </summary>
		[ColumnMapping("cnvcDefaultSeat",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDefaultSeat
		{
			get {return _cnvcDefaultSeat;}
			set {_cnvcDefaultSeat = value;}
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
		/// 结束时间
		/// </summary>
		[ColumnMapping("cnvcEndDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcEndDate
		{
			get {return _cnvcEndDate;}
			set {_cnvcEndDate = value;}
		}
		#endregion
	}	
}
