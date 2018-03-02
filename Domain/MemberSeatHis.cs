
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	MemberSeatHis.cs
* 作者:	     郑华
* 创建日期:    2007-12-23
* 功能描述:    会员座位历史表

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
	/// **功能名称：会员座位历史表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbMemberSeatHis")]
	public class MemberSeatHis: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region 数据表生成变量
		private int _cnnHisID;
		private int _cnvcMemberSeatID;
		private string _cnvcMemberCardNo = String.Empty;
		private string _cnvcMemberName = String.Empty;
		private string _cnvcPaperNo = String.Empty;
		private string _cnvcSeat = String.Empty;
		private string _cnvcJobName = String.Empty;
		private int _cnnID;
		private string _cnvcState = String.Empty;
		private string _cnvcFloor = String.Empty;
		private string _cnvcEndDate = String.Empty;
		#endregion
		
		#region 构造函数
		public MemberSeatHis():base()
		{
		}
		
		public MemberSeatHis(DataRow row):base(row)
		{
		}
		
		public MemberSeatHis(DataTable table):base(table)
		{
		}
		
		public MemberSeatHis(string  strXML):base(strXML)
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
		/// ID
		/// </summary>
		[ColumnMapping("cnvcMemberSeatID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnvcMemberSeatID
		{
			get {return _cnvcMemberSeatID;}
			set {_cnvcMemberSeatID = value;}
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
		/// 会员名称
		/// </summary>
		[ColumnMapping("cnvcMemberName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMemberName
		{
			get {return _cnvcMemberName;}
			set {_cnvcMemberName = value;}
		}

		/// <summary>
		/// 证件号码
		/// </summary>
		[ColumnMapping("cnvcPaperNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcPaperNo
		{
			get {return _cnvcPaperNo;}
			set {_cnvcPaperNo = value;}
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
		/// 招聘会名称
		/// </summary>
		[ColumnMapping("cnvcJobName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcJobName
		{
			get {return _cnvcJobName;}
			set {_cnvcJobName = value;}
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
		/// 展位状态
		/// </summary>
		[ColumnMapping("cnvcState",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcState
		{
			get {return _cnvcState;}
			set {_cnvcState = value;}
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
