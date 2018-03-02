
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	Member.cs
* ����:	     ֣��
* ��������:    2008-01-31
* ��������:    ��Ա��

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
	/// **�������ƣ���Ա��ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbMember")]
	public class Member: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region ���ݱ����ɱ���
		private string _cnvcMemberCardNo = String.Empty;
		private string _cnvcMemberPwd = String.Empty;
		private string _cnvcMemberName = String.Empty;
		private string _cnvcPaperNo = String.Empty;
		private string _cnvcCorporation = String.Empty;
		private string _cnvcCompanyAddress = String.Empty;
		private string _cnvcLinkman = String.Empty;
		private string _cnvcLinkPhone = String.Empty;
		private string _cnvcEmail = String.Empty;
		private string _cnvcComments = String.Empty;
		private string _cnvcMemberRight = String.Empty;
		private string _cnvcEnterpriseType = String.Empty;
		private string _cnvcDiscount = String.Empty;
		private string _cnvcFree = String.Empty;
		private string _cnvcProduct = String.Empty;
		private string _cnvcState = String.Empty;
		private decimal _cnnMemberFee;
		private decimal _cnnPrepay;
		private string _cndEndDate = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcMobileTelePhone = String.Empty;
		private string _cnvcPostalCode = String.Empty;
		private string _cnvcSales = String.Empty;
		private string _cnvcHandleman = String.Empty;
		private string _cnvcHandlemanPaperNo = String.Empty;
		private string _cnvcTrade = String.Empty;
		private string _cnvcCustomerService = String.Empty;
		private DateTime _cndInNetDate;
		private int _cniSynch;
		private string _cnvcFax = String.Empty;
		#endregion
		
		#region ���캯��
		public Member():base()
		{
		}
		
		public Member(DataRow row):base(row)
		{
		}
		
		public Member(DataTable table):base(table)
		{
		}
		
		public Member(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������
	
		/// <summary>
		/// ��Ա����
		/// </summary>
		[ColumnMapping("cnvcMemberCardNo",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMemberCardNo
		{
			get {return _cnvcMemberCardNo;}
			set {_cnvcMemberCardNo = value;}
		}

		/// <summary>
		/// ��Ա����
		/// </summary>
		[ColumnMapping("cnvcMemberPwd",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMemberPwd
		{
			get {return _cnvcMemberPwd;}
			set {_cnvcMemberPwd = value;}
		}

		/// <summary>
		/// ��λ����
		/// </summary>
		[ColumnMapping("cnvcMemberName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMemberName
		{
			get {return _cnvcMemberName;}
			set {_cnvcMemberName = value;}
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
		/// ���˴���
		/// </summary>
		[ColumnMapping("cnvcCorporation",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCorporation
		{
			get {return _cnvcCorporation;}
			set {_cnvcCorporation = value;}
		}

		/// <summary>
		/// ��λ��ַ
		/// </summary>
		[ColumnMapping("cnvcCompanyAddress",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCompanyAddress
		{
			get {return _cnvcCompanyAddress;}
			set {_cnvcCompanyAddress = value;}
		}

		/// <summary>
		/// ��ϵ��
		/// </summary>
		[ColumnMapping("cnvcLinkman",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcLinkman
		{
			get {return _cnvcLinkman;}
			set {_cnvcLinkman = value;}
		}

		/// <summary>
		/// �칫�绰
		/// </summary>
		[ColumnMapping("cnvcLinkPhone",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcLinkPhone
		{
			get {return _cnvcLinkPhone;}
			set {_cnvcLinkPhone = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		[ColumnMapping("cnvcEmail",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcEmail
		{
			get {return _cnvcEmail;}
			set {_cnvcEmail = value;}
		}

		/// <summary>
		/// ��ע
		/// </summary>
		[ColumnMapping("cnvcComments",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcComments
		{
			get {return _cnvcComments;}
			set {_cnvcComments = value;}
		}

		/// <summary>
		/// ��Ա�ʸ�
		/// </summary>
		[ColumnMapping("cnvcMemberRight",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMemberRight
		{
			get {return _cnvcMemberRight;}
			set {_cnvcMemberRight = value;}
		}

		/// <summary>
		/// ��ҵ����
		/// </summary>
		[ColumnMapping("cnvcEnterpriseType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcEnterpriseType
		{
			get {return _cnvcEnterpriseType;}
			set {_cnvcEnterpriseType = value;}
		}

		/// <summary>
		/// �ۿ�
		/// </summary>
		[ColumnMapping("cnvcDiscount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDiscount
		{
			get {return _cnvcDiscount;}
			set {_cnvcDiscount = value;}
		}

		/// <summary>
		/// ��ѳ���
		/// </summary>
		[ColumnMapping("cnvcFree",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFree
		{
			get {return _cnvcFree;}
			set {_cnvcFree = value;}
		}

		/// <summary>
		/// �����Ʒ
		/// </summary>
		[ColumnMapping("cnvcProduct",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcProduct
		{
			get {return _cnvcProduct;}
			set {_cnvcProduct = value;}
		}

		/// <summary>
		/// ��Ա��״̬
		/// </summary>
		[ColumnMapping("cnvcState",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcState
		{
			get {return _cnvcState;}
			set {_cnvcState = value;}
		}

		/// <summary>
		/// ��Ա��
		/// </summary>
		[ColumnMapping("cnnMemberFee",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnMemberFee
		{
			get {return _cnnMemberFee;}
			set {_cnnMemberFee = value;}
		}

		/// <summary>
		/// ʵ��
		/// </summary>
		[ColumnMapping("cnnPrepay",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnPrepay
		{
			get {return _cnnPrepay;}
			set {_cnnPrepay = value;}
		}

		/// <summary>
		/// ��ʹ��ʱ��
		/// </summary>
		[ColumnMapping("cndEndDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cndEndDate
		{
			get {return _cndEndDate;}
			set {_cndEndDate = value;}
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
		/// �ֻ�����
		/// </summary>
		[ColumnMapping("cnvcMobileTelePhone",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMobileTelePhone
		{
			get {return _cnvcMobileTelePhone;}
			set {_cnvcMobileTelePhone = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		[ColumnMapping("cnvcPostalCode",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcPostalCode
		{
			get {return _cnvcPostalCode;}
			set {_cnvcPostalCode = value;}
		}

		/// <summary>
		/// ������Ա
		/// </summary>
		[ColumnMapping("cnvcSales",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcSales
		{
			get {return _cnvcSales;}
			set {_cnvcSales = value;}
		}

		/// <summary>
		/// ������
		/// </summary>
		[ColumnMapping("cnvcHandleman",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcHandleman
		{
			get {return _cnvcHandleman;}
			set {_cnvcHandleman = value;}
		}

		/// <summary>
		/// ���������֤��
		/// </summary>
		[ColumnMapping("cnvcHandlemanPaperNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcHandlemanPaperNo
		{
			get {return _cnvcHandlemanPaperNo;}
			set {_cnvcHandlemanPaperNo = value;}
		}

		/// <summary>
		/// ��ҵ
		/// </summary>
		[ColumnMapping("cnvcTrade",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcTrade
		{
			get {return _cnvcTrade;}
			set {_cnvcTrade = value;}
		}

		/// <summary>
		/// �ͷ�����
		/// </summary>
		[ColumnMapping("cnvcCustomerService",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCustomerService
		{
			get {return _cnvcCustomerService;}
			set {_cnvcCustomerService = value;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		[ColumnMapping("cndInNetDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndInNetDate
		{
			get {return _cndInNetDate;}
			set {_cndInNetDate = value;}
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
		/// ����
		/// </summary>
		[ColumnMapping("cnvcFax",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFax
		{
			get {return _cnvcFax;}
			set {_cnvcFax = value;}
		}
		#endregion
	}	
}
