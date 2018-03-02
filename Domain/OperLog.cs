
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	OperLog.cs
* 作者:	     郑华
* 创建日期:    2008-1-13
* 功能描述:    操作日志表

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
	/// **功能名称：操作日志表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbOperLog")]
	public class OperLog: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region 数据表生成变量
		private decimal _cnnSerialNo;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcMemberCardNo = String.Empty;
		private string _cnvcPaperNo = String.Empty;
		private string _cnvcFree = String.Empty;
		private decimal _cnnPrepay;
		private string _cnvcOperFlag = String.Empty;
		private int _cniSynch;
		#endregion
		
		#region 构造函数
		public OperLog():base()
		{
		}
		
		public OperLog(DataRow row):base(row)
		{
		}
		
		public OperLog(DataTable table):base(table)
		{
		}
		
		public OperLog(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性
	
		/// <summary>
		/// 流水号
		/// </summary>
		[ColumnMapping("cnnSerialNo",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnSerialNo
		{
			get {return _cnnSerialNo;}
			set {_cnnSerialNo = value;}
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
		/// 会员
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
		/// 免费场次
		/// </summary>
		[ColumnMapping("cnvcFree",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFree
		{
			get {return _cnvcFree;}
			set {_cnvcFree = value;}
		}

		/// <summary>
		/// 预存
		/// </summary>
		[ColumnMapping("cnnPrepay",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnPrepay
		{
			get {return _cnnPrepay;}
			set {_cnnPrepay = value;}
		}

		/// <summary>
		/// 操作
		/// </summary>
		[ColumnMapping("cnvcOperFlag",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperFlag
		{
			get {return _cnvcOperFlag;}
			set {_cnvcOperFlag = value;}
		}
		/// <summary>
		/// 同步标志
		/// </summary>
		[ColumnMapping("cniSynch",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cniSynch
		{
			get {return _cniSynch;}
			set {_cniSynch = value;}
		}
		#endregion
	}	
}
