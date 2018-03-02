
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	JobLog.cs
* ����:	     ֣��
* ��������:    2008-1-15
* ��������:    ��Ƹ����־��

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
	/// **�������ƣ���Ƹ����־��ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbJobLog")]
	public class JobLog: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region ���ݱ����ɱ���
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
		
		#region ���캯��
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
		[ColumnMapping("cnnJobID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
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
		/// ��Ƹ������
		/// </summary>
		[ColumnMapping("cnvcJobTheme",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcJobTheme
		{
			get {return _cnvcJobTheme;}
			set {_cnvcJobTheme = value;}
		}

		/// <summary>
		/// ��ʼʱ��
		/// </summary>
		[ColumnMapping("cndBeginDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndBeginDate
		{
			get {return _cndBeginDate;}
			set {_cndBeginDate = value;}
		}

		/// <summary>
		/// ����ʱ��
		/// </summary>
		[ColumnMapping("cndEndDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndEndDate
		{
			get {return _cndEndDate;}
			set {_cndEndDate = value;}
		}

		/// <summary>
		/// Ԥ����ʼʱ��
		/// </summary>
		[ColumnMapping("cndBookBeginDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndBookBeginDate
		{
			get {return _cndBookBeginDate;}
			set {_cndBookBeginDate = value;}
		}

		/// <summary>
		/// Ԥ������ʱ��
		/// </summary>
		[ColumnMapping("cndBookEndDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndBookEndDate
		{
			get {return _cndBookEndDate;}
			set {_cndBookEndDate = value;}
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
