
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	PrepayLog.cs
* 作者:	     郑华
* 创建日期:    2008-1-17
* 功能描述:    缴费日志表

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
	/// **功能名称：缴费日志表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbPrepayLog")]
	public class PrepayLog: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region 数据表生成变量
		private decimal _cnnSerialNo;
		private int _cnnPrepayID;
		private int _cnnJobID;
		private string _cnvcMemberCardNo = String.Empty;
		private string _cnvcPaperNo = String.Empty;
		private decimal _cnnPrepay;
		private decimal _cnnReturn;
		private decimal _cnnBalance;
		private string _cnvcState = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		#endregion
		
		#region 构造函数
		public PrepayLog():base()
		{
		}
		
		public PrepayLog(DataRow row):base(row)
		{
		}
		
		public PrepayLog(DataTable table):base(table)
		{
		}
		
		public PrepayLog(string  strXML):base(strXML)
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
		/// 缴费ID
		/// </summary>
		[ColumnMapping("cnnPrepayID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnPrepayID
		{
			get {return _cnnPrepayID;}
			set {_cnnPrepayID = value;}
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
		/// 缴费
		/// </summary>
		[ColumnMapping("cnnPrepay",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnPrepay
		{
			get {return _cnnPrepay;}
			set {_cnnPrepay = value;}
		}

		/// <summary>
		/// 退费
		/// </summary>
		[ColumnMapping("cnnReturn",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnReturn
		{
			get {return _cnnReturn;}
			set {_cnnReturn = value;}
		}

		/// <summary>
		/// 余额
		/// </summary>
		[ColumnMapping("cnnBalance",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnBalance
		{
			get {return _cnnBalance;}
			set {_cnnBalance = value;}
		}

		/// <summary>
		/// 状态
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
