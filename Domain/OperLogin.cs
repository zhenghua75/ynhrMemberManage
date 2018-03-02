
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	OperLogin.cs
* ����:	     ֣��
* ��������:    2008-1-20
* ��������:    ����Ա��¼��

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
	/// **�������ƣ�����Ա��¼��ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbOperLogin")]
	public class OperLogin: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region ���ݱ����ɱ���
		private decimal _cnnSerialNp;
		private string _cnvcOperName = String.Empty;
		private int _cnnDeptID;
		private string _cnvcCardNo = String.Empty;
		private DateTime _cndLoginDate;
		private string _cnvcHostName = String.Empty;
		private string _cnvcHostAddress = String.Empty;
		private string _cnvcLoginMethod = String.Empty;
		private int _cnnAgainTime;
		#endregion
		
		#region ���캯��
		public OperLogin():base()
		{
		}
		
		public OperLogin(DataRow row):base(row)
		{
		}
		
		public OperLogin(DataTable table):base(table)
		{
		}
		
		public OperLogin(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������
	
		/// <summary>
		/// ��ˮ
		/// </summary>
		[ColumnMapping("cnnSerialNp",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnSerialNp
		{
			get {return _cnnSerialNp;}
			set {_cnnSerialNp = value;}
		}

		/// <summary>
		/// ����Ա����
		/// </summary>
		[ColumnMapping("cnvcOperName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperName
		{
			get {return _cnvcOperName;}
			set {_cnvcOperName = value;}
		}

		/// <summary>
		/// ����ID
		/// </summary>
		[ColumnMapping("cnnDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnDeptID
		{
			get {return _cnnDeptID;}
			set {_cnnDeptID = value;}
		}

		/// <summary>
		/// ��¼����
		/// </summary>
		[ColumnMapping("cnvcCardNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCardNo
		{
			get {return _cnvcCardNo;}
			set {_cnvcCardNo = value;}
		}

		/// <summary>
		/// ��¼ʱ��
		/// </summary>
		[ColumnMapping("cndLoginDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndLoginDate
		{
			get {return _cndLoginDate;}
			set {_cndLoginDate = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		[ColumnMapping("cnvcHostName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcHostName
		{
			get {return _cnvcHostName;}
			set {_cnvcHostName = value;}
		}

		/// <summary>
		/// ����IP
		/// </summary>
		[ColumnMapping("cnvcHostAddress",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcHostAddress
		{
			get {return _cnvcHostAddress;}
			set {_cnvcHostAddress = value;}
		}

		/// <summary>
		/// ��¼��ʽ
		/// </summary>
		[ColumnMapping("cnvcLoginMethod",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcLoginMethod
		{
			get {return _cnvcLoginMethod;}
			set {_cnvcLoginMethod = value;}
		}

		/// <summary>
		/// ���Դ���
		/// </summary>
		[ColumnMapping("cnnAgainTime",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnAgainTime
		{
			get {return _cnnAgainTime;}
			set {_cnnAgainTime = value;}
		}
		#endregion
	}	
}
