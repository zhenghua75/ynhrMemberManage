
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	MemberSeat.cs
* ����:	     ֣��
* ��������:    2008-1-5
* ��������:    ��Ա��λ��

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
	/// **�������ƣ���Ա��λ��ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbMemberSeat")]
	public class MemberSeat: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region ���ݱ����ɱ���
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
		
		#region ���캯��
		public MemberSeat():base()
		{
		}
		
		public MemberSeat(DataRow row):base(row)
		{
		}
		
		public MemberSeat(DataTable table):base(table)
		{
		}
		
		public MemberSeat(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������
	
		/// <summary>
		/// ID
		/// </summary>
		[ColumnMapping("cnvcMemberSeatID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
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
		/// ����Ա
		/// </summary>
		[ColumnMapping("cnvcOperName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperName
		{
			get {return _cnvcOperName;}
			set {_cnvcOperName = value;}
		}

		/// <summary>
		/// ����ʱ��
		/// </summary>
		[ColumnMapping("cndOperDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndOperDate
		{
			get {return _cndOperDate;}
			set {_cndOperDate = value;}
		}
		/// <summary>
		/// ͬ����־��0Ĭ��1��վ2������
		/// </summary>
		[ColumnMapping("cniSynch",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cniSynch
		{
			get {return _cniSynch;}
			set {_cniSynch = value;}
		}
		/// <summary>
		/// չ������
		/// </summary>
		[ColumnMapping("cnvcShowName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcShowName
		{
			get {return _cnvcShowName;}
			set {_cnvcShowName = value;}
		}

		/// <summary>
		/// ��Ϣ�ύ��ʽ
		/// </summary>
		[ColumnMapping("cnvcInfoWay",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcInfoWay
		{
			get {return _cnvcInfoWay;}
			set {_cnvcInfoWay = value;}
		}

		/// <summary>
		/// ��Ϣ�ύ���
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
