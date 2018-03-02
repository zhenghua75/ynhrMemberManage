
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	ShowSeatLog.cs
* ����:	     ֣��
* ��������:    2008-1-17
* ��������:    չ����λ��־��

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
	/// **�������ƣ�չ����λ��־��ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbShowSeatLog")]
	public class ShowSeatLog: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region ���ݱ����ɱ���
		private decimal _cnnSerialNo;
		private int _cnnJobID;
		private string _cnvcJobName = String.Empty;
		private string _cnvcControlName = String.Empty;
		private string _cnvcSeat = String.Empty;
		private string _cnvcDirection = String.Empty;
		private int _cnnX;
		private int _cnnY;
		private int _cnnHeight;
		private int _cnnWidth;
		private string _cnvcFloor = String.Empty;
		private string _cnvcState = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		#endregion
		
		#region ���캯��
		public ShowSeatLog():base()
		{
		}
		
		public ShowSeatLog(DataRow row):base(row)
		{
		}
		
		public ShowSeatLog(DataTable table):base(table)
		{
		}
		
		public ShowSeatLog(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������
	
		/// <summary>
		/// ��ˮ
		/// </summary>
		[ColumnMapping("cnnSerialNo",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnSerialNo
		{
			get {return _cnnSerialNo;}
			set {_cnnSerialNo = value;}
		}

		/// <summary>
		/// ��Ƹ��ID
		/// </summary>
		[ColumnMapping("cnnJobID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public int cnnJobID
		{
			get {return _cnnJobID;}
			set {_cnnJobID = value;}
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
		[ColumnMapping("cnvcControlName",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
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
		/// չ��
		/// </summary>
		[ColumnMapping("cnvcFloor",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFloor
		{
			get {return _cnvcFloor;}
			set {_cnvcFloor = value;}
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
		#endregion
	}	
}
