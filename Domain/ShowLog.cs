
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	ShowLog.cs
* ����:	     ֣��
* ��������:    2008-1-15
* ��������:    չ����־

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
	/// **�������ƣ�չ����־ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbShowLog")]
	public class ShowLog: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region ���ݱ����ɱ���
		private decimal _cnnSerialNo;
		private int _cnnShowID;
		private int _cnnJobID;
		private string _cnvcShowName = String.Empty;
		private int _cnnX;
		private int _cnnY;
		private int _cnnWeight;
		private int _cnnHeight;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		#endregion
		
		#region ���캯��
		public ShowLog():base()
		{
		}
		
		public ShowLog(DataRow row):base(row)
		{
		}
		
		public ShowLog(DataTable table):base(table)
		{
		}
		
		public ShowLog(string  strXML):base(strXML)
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
		/// չ��ID
		/// </summary>
		[ColumnMapping("cnnShowID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnShowID
		{
			get {return _cnnShowID;}
			set {_cnnShowID = value;}
		}

		/// <summary>
		/// ��Ƹ��
		/// </summary>
		[ColumnMapping("cnnJobID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnJobID
		{
			get {return _cnnJobID;}
			set {_cnnJobID = value;}
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
		/// չ��Xλ��
		/// </summary>
		[ColumnMapping("cnnX",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnX
		{
			get {return _cnnX;}
			set {_cnnX = value;}
		}

		/// <summary>
		/// չ��Yλ��
		/// </summary>
		[ColumnMapping("cnnY",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnY
		{
			get {return _cnnY;}
			set {_cnnY = value;}
		}

		/// <summary>
		/// չ�����
		/// </summary>
		[ColumnMapping("cnnWeight",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnWeight
		{
			get {return _cnnWeight;}
			set {_cnnWeight = value;}
		}

		/// <summary>
		/// չ���߶�
		/// </summary>
		[ColumnMapping("cnnHeight",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnHeight
		{
			get {return _cnnHeight;}
			set {_cnnHeight = value;}
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
		/// ����Աʱ��
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
