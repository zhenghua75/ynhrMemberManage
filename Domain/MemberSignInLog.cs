
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	MemberSignInLog.cs
* 作者:	     郑华
* 创建日期:    2008-1-16
* 功能描述:    会员签到流水表

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
	/// **功能名称：会员签到流水表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbMemberSignInLog")]
	public class MemberSignInLog: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region 数据表生成变量
		private decimal _cnnSerialNo;
		private string _cnvcMemberCardNo = String.Empty;
		private int _cnnJobID;
		private string _cnvcSeat = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		#endregion
		
		#region 构造函数
		public MemberSignInLog():base()
		{
		}
		
		public MemberSignInLog(DataRow row):base(row)
		{
		}
		
		public MemberSignInLog(DataTable table):base(table)
		{
		}
		
		public MemberSignInLog(string  strXML):base(strXML)
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
		/// 招聘会
		/// </summary>
		[ColumnMapping("cnnJobID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnJobID
		{
			get {return _cnnJobID;}
			set {_cnnJobID = value;}
		}

		/// <summary>
		/// 展位
		/// </summary>
		[ColumnMapping("cnvcSeat",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcSeat
		{
			get {return _cnvcSeat;}
			set {_cnvcSeat = value;}
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
