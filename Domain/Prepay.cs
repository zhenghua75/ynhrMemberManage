
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	Prepay.cs
* ����:	     ֣��
* ��������:    2008-1-17
* ��������:    �ɷѱ�

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
	/// **�������ƣ��ɷѱ�ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbPrepay")]
	public class Prepay: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region ���ݱ����ɱ���
		private int _cnnPrepayID;
		private int _cnnJobID;
		private string _cnvcMemberCardNo = String.Empty;
		private string _cnvcPaperNo = String.Empty;
		private decimal _cnnPrepay;
		private decimal _cnnReturn;
		private decimal _cnnBalance;
		private string _cnvcState = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		#endregion
		
		#region ���캯��
		public Prepay():base()
		{
		}
		
		public Prepay(DataRow row):base(row)
		{
		}
		
		public Prepay(DataTable table):base(table)
		{
		}
		
		public Prepay(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������
	
		/// <summary>
		/// �ɷ�ID
		/// </summary>
		[ColumnMapping("cnnPrepayID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public int cnnPrepayID
		{
			get {return _cnnPrepayID;}
			set {_cnnPrepayID = value;}
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
		/// ��Ա����
		/// </summary>
		[ColumnMapping("cnvcMemberCardNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMemberCardNo
		{
			get {return _cnvcMemberCardNo;}
			set {_cnvcMemberCardNo = value;}
		}

		/// <summary>
		/// ����ע���
		/// </summary>
		[ColumnMapping("cnvcPaperNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcPaperNo
		{
			get {return _cnvcPaperNo;}
			set {_cnvcPaperNo = value;}
		}

		/// <summary>
		/// �ɷ�
		/// </summary>
		[ColumnMapping("cnnPrepay",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnPrepay
		{
			get {return _cnnPrepay;}
			set {_cnnPrepay = value;}
		}

		/// <summary>
		/// �˷�
		/// </summary>
		[ColumnMapping("cnnReturn",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnReturn
		{
			get {return _cnnReturn;}
			set {_cnnReturn = value;}
		}

		/// <summary>
		/// ���
		/// </summary>
		[ColumnMapping("cnnBalance",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnBalance
		{
			get {return _cnnBalance;}
			set {_cnnBalance = value;}
		}

		/// <summary>
		/// ״̬
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