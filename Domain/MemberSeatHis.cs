
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	MemberSeatHis.cs
* ����:	     ֣��
* ��������:    2007-12-23
* ��������:    ��Ա��λ��ʷ��

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
	/// **�������ƣ���Ա��λ��ʷ��ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbMemberSeatHis")]
	public class MemberSeatHis: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region ���ݱ����ɱ���
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
		
		#region ���캯��
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
		
		#region ϵͳ��������
	
		/// <summary>
		/// ��ʷID
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
		/// ��Ա����
		/// </summary>
		[ColumnMapping("cnvcMemberCardNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMemberCardNo
		{
			get {return _cnvcMemberCardNo;}
			set {_cnvcMemberCardNo = value;}
		}

		/// <summary>
		/// ��Ա����
		/// </summary>
		[ColumnMapping("cnvcMemberName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMemberName
		{
			get {return _cnvcMemberName;}
			set {_cnvcMemberName = value;}
		}

		/// <summary>
		/// ֤������
		/// </summary>
		[ColumnMapping("cnvcPaperNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcPaperNo
		{
			get {return _cnvcPaperNo;}
			set {_cnvcPaperNo = value;}
		}

		/// <summary>
		/// ��λ��
		/// </summary>
		[ColumnMapping("cnvcSeat",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcSeat
		{
			get {return _cnvcSeat;}
			set {_cnvcSeat = value;}
		}

		/// <summary>
		/// ��Ƹ������
		/// </summary>
		[ColumnMapping("cnvcJobName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcJobName
		{
			get {return _cnvcJobName;}
			set {_cnvcJobName = value;}
		}

		/// <summary>
		/// ��Ƹ��ID
		/// </summary>
		[ColumnMapping("cnnID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnID
		{
			get {return _cnnID;}
			set {_cnnID = value;}
		}

		/// <summary>
		/// չλ״̬
		/// </summary>
		[ColumnMapping("cnvcState",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcState
		{
			get {return _cnvcState;}
			set {_cnvcState = value;}
		}

		/// <summary>
		/// ��
		/// </summary>
		[ColumnMapping("cnvcFloor",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFloor
		{
			get {return _cnvcFloor;}
			set {_cnvcFloor = value;}
		}

		/// <summary>
		/// ����ʱ��
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
