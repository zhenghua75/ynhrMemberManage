
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	ShowSeatHis.cs
* ����:	     ֣��
* ��������:    2007-12-23
* ��������:    չλ��λ��ʷ��

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
	/// **�������ƣ�չλ��λ��ʷ��ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbShowSeatHis")]
	public class ShowSeatHis: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region ���ݱ����ɱ���
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
		
		#region ���캯��
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
		/// ��Ƹ��ID
		/// </summary>
		[ColumnMapping("cnnID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnID
		{
			get {return _cnnID;}
			set {_cnnID = value;}
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
		/// �ؼ�����
		/// </summary>
		[ColumnMapping("cnvcControlName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcControlName
		{
			get {return _cnvcControlName;}
			set {_cnvcControlName = value;}
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
		/// ����
		/// </summary>
		[ColumnMapping("cnvcDirection",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDirection
		{
			get {return _cnvcDirection;}
			set {_cnvcDirection = value;}
		}

		/// <summary>
		/// ����X
		/// </summary>
		[ColumnMapping("cnnX",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnX
		{
			get {return _cnnX;}
			set {_cnnX = value;}
		}

		/// <summary>
		/// ����Y
		/// </summary>
		[ColumnMapping("cnnY",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnY
		{
			get {return _cnnY;}
			set {_cnnY = value;}
		}

		/// <summary>
		/// �߶�
		/// </summary>
		[ColumnMapping("cnnHeight",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnHeight
		{
			get {return _cnnHeight;}
			set {_cnnHeight = value;}
		}

		/// <summary>
		/// ���
		/// </summary>
		[ColumnMapping("cnnWidth",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnWidth
		{
			get {return _cnnWidth;}
			set {_cnnWidth = value;}
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
		/// Ĭ����λ����
		/// </summary>
		[ColumnMapping("cnvcDefaultSeat",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDefaultSeat
		{
			get {return _cnvcDefaultSeat;}
			set {_cnvcDefaultSeat = value;}
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
