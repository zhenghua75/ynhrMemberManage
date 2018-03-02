
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	MemberSeatLog.cs
* 作者:	     郑华
* 创建日期:    2008-1-17
* 功能描述:    会员展位日志表

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
	/// **功能名称：会员展位日志表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbMemberSeatLog")]
	public class MemberSeatLog: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region 数据表生成变量
		private decimal _cnnSerialNo;
		private int _cnvcMemberSeatID;
		private string _cnvcMemberCardNo = String.Empty;
		private string _cnvcMemberName = String.Empty;
		private string _cnvcPaperNo = String.Empty;
		private string _cnvcSeat = String.Empty;
		private string _cnvcJobName = String.Empty;
		private int _cnnID;
		private string _cnvcState = String.Empty;
		private string _cnvcFloor = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		private int _cniSynch;
		private string _cnvcShowName = String.Empty;
		private string _cnvcInfoWay = String.Empty;
		private string _cnvcAudit = String.Empty;

		#endregion
		
		#region 构造函数
		public MemberSeatLog():base()
		{
		}
		
		public MemberSeatLog(DataRow row):base(row)
		{
		}
		
		public MemberSeatLog(DataTable table):base(table)
		{
		}
		
		public MemberSeatLog(string  strXML):base(strXML)
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
		/// ID
		/// </summary>
		[ColumnMapping("cnvcMemberSeatID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
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
		/// <summary>
		/// 同步标志，0默认1网站2触摸屏
		/// </summary>
		[ColumnMapping("cniSynch",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cniSynch
		{
			get {return _cniSynch;}
			set {_cniSynch = value;}
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
		/// 信息提交方式
		/// </summary>
		[ColumnMapping("cnvcInfoWay",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcInfoWay
		{
			get {return _cnvcInfoWay;}
			set {_cnvcInfoWay = value;}
		}

		/// <summary>
		/// 信息提交审核
		/// </summary>
		[ColumnMapping("cnvcAudit",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcAudit
		{
			get {return _cnvcAudit;}
			set {_cnvcAudit = value;}
		}
		#endregion
	}	
}
