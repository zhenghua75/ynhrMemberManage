
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	JobLog.cs
* 作者:	     郑华
* 创建日期:    2008-1-15
* 功能描述:    招聘会日志表

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
	/// **功能名称：招聘会日志表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbJobLog")]
	public class JobLog: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region 数据表生成变量
		private decimal _cnnSerialNo;
		private int _cnnJobID;
		private string _cnvcJobName = String.Empty;
		private string _cnvcJobTheme = String.Empty;
		private DateTime _cndBeginDate;
		private DateTime _cndEndDate;
		private DateTime _cndBookBeginDate;
		private DateTime _cndBookEndDate;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		#endregion
		
		#region 构造函数
		public JobLog():base()
		{
		}
		
		public JobLog(DataRow row):base(row)
		{
		}
		
		public JobLog(DataTable table):base(table)
		{
		}
		
		public JobLog(string  strXML):base(strXML)
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
		[ColumnMapping("cnnJobID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
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
		/// 招聘会主题
		/// </summary>
		[ColumnMapping("cnvcJobTheme",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcJobTheme
		{
			get {return _cnvcJobTheme;}
			set {_cnvcJobTheme = value;}
		}

		/// <summary>
		/// 开始时间
		/// </summary>
		[ColumnMapping("cndBeginDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndBeginDate
		{
			get {return _cndBeginDate;}
			set {_cndBeginDate = value;}
		}

		/// <summary>
		/// 结束时间
		/// </summary>
		[ColumnMapping("cndEndDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndEndDate
		{
			get {return _cndEndDate;}
			set {_cndEndDate = value;}
		}

		/// <summary>
		/// 预订开始时间
		/// </summary>
		[ColumnMapping("cndBookBeginDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndBookBeginDate
		{
			get {return _cndBookBeginDate;}
			set {_cndBookBeginDate = value;}
		}

		/// <summary>
		/// 预订结束时间
		/// </summary>
		[ColumnMapping("cndBookEndDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndBookEndDate
		{
			get {return _cndBookEndDate;}
			set {_cndBookEndDate = value;}
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
