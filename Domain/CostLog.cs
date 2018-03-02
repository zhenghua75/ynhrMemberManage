
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	CostLog.cs
* 作者:	     郑华
* 创建日期:    2008-1-17
* 功能描述:    工本费清单表

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
	/// **功能名称：工本费清单表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbCostLog")]
	public class CostLog: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region 数据表生成变量
		private decimal _cnnSerialNo;
		private string _cnvcMemberCardNo = String.Empty;
		private decimal _cnnCost;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		#endregion
		
		#region 构造函数
		public CostLog():base()
		{
		}
		
		public CostLog(DataRow row):base(row)
		{
		}
		
		public CostLog(DataTable table):base(table)
		{
		}
		
		public CostLog(string  strXML):base(strXML)
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
		/// 工本费
		/// </summary>
		[ColumnMapping("cnnCost",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnCost
		{
			get {return _cnnCost;}
			set {_cnnCost = value;}
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
