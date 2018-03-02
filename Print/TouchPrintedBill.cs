
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	Bill.cs
* ����:	     ֣��
* ��������:    2008-01-25
* ��������:    СƱ��ӡ

*                                                           Copyright(C) 2008 zhenghua
*************************************************************************************/
#region Import NameSpace
using System;
using System.Data;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using ynhrMemberManage.Common;
//using MemberManage.Business;
#endregion

namespace ynhrMemberManage.Print
{
	/// <summary>
	/// **�������ƣ�СƱ��ӡʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbBill")]
	public class TouchPrintedBill: ynhrMemberManage.ORM.EntityObjectBase,ITouchPrintable
	{
		#region ���ݱ����ɱ���
		private int _cnnID;
		private string _cnvcMemberCardNo = String.Empty;
		private string _cnvcOldMemberCardNo = String.Empty;
		private string _cnvcMemberPwd = String.Empty;
		private string _cnvcMemberName = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcBillType = String.Empty;
		private int _cnnRepeats;
		private decimal _cnnMemberFee;
		private string _cnvcDiscount = String.Empty;
		private decimal _cnnPrepay;
        private decimal _cnnLastBalance;
        private decimal _cnnBalance;
		private string _cnvcFree = String.Empty;
		private string _cnvcFreeLast = String.Empty;
		private string _cndEndDate = String.Empty;
		private string _cnvcPaperNo = String.Empty;
		private string _cnvcSeat = String.Empty;
		private string _cnvcProduct = String.Empty;
		private string _cnvcMemberRight = String.Empty;
		private string _cnvcShow = String.Empty;
		private string _cnvcJobInfo = String.Empty;
        private string _cnvcSynch = String.Empty;
        private decimal _cnnDonate;
		#endregion
		
		#region ���캯��
		public TouchPrintedBill():base()
		{
		}
		
		public TouchPrintedBill(DataRow row):base(row)
		{
		}
		
		public TouchPrintedBill(DataTable table):base(table)
		{
		}
		
		public TouchPrintedBill(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������
	
		/// <summary>
		/// cnnID
		/// </summary>
		[ColumnMapping("cnnID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public int cnnID
		{
			get {return _cnnID;}
			set {_cnnID = value;}
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
		/// �ϻ�Ա����
		/// </summary>
		[ColumnMapping("cnvcOldMemberCardNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOldMemberCardNo
		{
			get {return _cnvcOldMemberCardNo;}
			set {_cnvcOldMemberCardNo = value;}
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
		/// СƱ����
		/// </summary>
		[ColumnMapping("cnvcBillType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcBillType
		{
			get {return _cnvcBillType;}
			set {_cnvcBillType = value;}
		}

		/// <summary>
		/// �ش����
		/// </summary>
		[ColumnMapping("cnnRepeats",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnRepeats
		{
			get {return _cnnRepeats;}
			set {_cnnRepeats = value;}
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
		/// �ۿ�
		/// </summary>
		[ColumnMapping("cnvcDiscount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDiscount
		{
			get {return _cnvcDiscount;}
			set {_cnvcDiscount = value;}
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
        /// ��ǰ���
        /// </summary>
        [ColumnMapping("cnnBalance", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnBalance
        {
            get { return _cnnBalance; }
            set { _cnnBalance = value; }
        }
        /// <summary>
        /// �ϴ����
        /// </summary>
        [ColumnMapping("cnnLastBalance", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnLastBalance
        {
            get { return _cnnLastBalance; }
            set { _cnnLastBalance = value; }
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
		/// ��ѳ���ʣ��
		/// </summary>
		[ColumnMapping("cnvcFreeLast",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFreeLast
		{
			get {return _cnvcFreeLast;}
			set {_cnvcFreeLast = value;}
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
		/// ����ע���
		/// </summary>
		[ColumnMapping("cnvcPaperNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcPaperNo
		{
			get {return _cnvcPaperNo;}
			set {_cnvcPaperNo = value;}
		}

		/// <summary>
		/// չλ
		/// </summary>
		[ColumnMapping("cnvcSeat",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcSeat
		{
			get {return _cnvcSeat;}
			set {_cnvcSeat = value;}
		}

		/// <summary>
		/// ��Ʒ
		/// </summary>
		[ColumnMapping("cnvcProduct",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcProduct
		{
			get {return _cnvcProduct;}
			set {_cnvcProduct = value;}
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
		/// ��Ա�ʸ�
		/// </summary>
		[ColumnMapping("cnvcShow",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcShow
		{
			get {return _cnvcShow;}
			set {_cnvcShow = value;}
		}
		/// <summary>
		/// ��ʾ
		/// </summary>
		[ColumnMapping("cnvcJobInfo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcJobInfo
		{
			get {return _cnvcJobInfo;}
			set {_cnvcJobInfo = value;}
		}
        /// <summary>
        /// ����
        /// </summary>
        [ColumnMapping("cnnDonate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public decimal cnnDonate
        {
            get { return _cnnDonate; }
            set { _cnnDonate = value; }
        }
        /// <summary>
        /// ͬ����־
        /// </summary>
        [ColumnMapping("cnvcSynch", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcSynch
        {
            get { return _cnvcSynch; }
            set { _cnvcSynch = value; }
        }
		#endregion
		
		// Print...
		public void Print(TouchPrintElement element)
		{
			//element.AddHeader(cnvcBillType);
			element.AddSeat(cnvcBillType);
			if (cnvcJobInfo.Trim().Length > 0)
			{
				element.AddInfo(cnvcJobInfo);
				element.AddInfo("����̨ǩ����Ч");
			}
			element.AddHorizontalRule();

			element.AddData("��Ա����",cnvcMemberCardNo);
			element.AddData("ԭ����",cnvcOldMemberCardNo);
			element.AddData("��Ա����",cnvcMemberPwd);
			element.AddData("��λ����",cnvcMemberName);
			element.AddData("����ע���",cnvcPaperNo);			
			element.AddData("��Ա�ʸ�",cnvcMemberRight);
			//��Ʒ�����ֿ���ʾ�����ŷָ����|���߷ָ������Ʒ
			if (cnvcProduct.Trim().Length > 0)
			{
				string[] strProducts = cnvcProduct.Split('|');
				element.AddHeader("�����Ʒ");
				foreach (string strProduct in strProducts)
				{
					if (strProduct.Trim().Length > 0)
					{
						string[] strItems = strProduct.Split(',');					
						element.AddData("    ����",strItems[0]);
						element.AddData("    ����",strItems[1]);
						//element.AddData("    �ۿ�",strItems[2]);
						element.AddData("    ʵ��",strItems[3]);
						element.AddData("    ����",strItems[4]);
						element.AddData("    ʣ�ೡ��",strItems[5]);
						//strItems[3].
					}
					
				}
				element.AddHorizontalRule();
			}
			else
			{
				element.AddHorizontalRule();
			}
			if (cnvcBillType == ConstApp.Bill_Type_Provide)
			{
				element.AddData("��λ����",cnvcMemberName);
			}
			element.AddData("��Ա��",cnnMemberFee.ToString("F2"));			
			//element.AddData("�ۿ�",cnvcDiscount);
			//element.AddData("ʵ��",cnnPrepay.ToString("F2"));
            element.AddData("�ϴ����", cnnLastBalance.ToString("F2"));
            element.AddData("���", cnnPrepay.ToString("F2"));
            element.AddData("���ͽ��", cnnDonate.ToString("F2"));
            element.AddData("��ǰ���", cnnBalance.ToString("F2"));

			element.AddData("����",cnvcFree);
					
			element.AddData("չ��",cnvcShow);
			element.AddSeatData("չλ",cnvcSeat);
			element.AddData("ʣ�ೡ��",cnvcFreeLast);
			
			//element.AddData("����Ա",cnvcOperName);
			element.AddData("��������",cndEndDate);
            element.AddData("ͬ����־", cnvcSynch);
			element.AddData("����ʱ��",cndOperDate.ToString("yyyy-MM-dd hh:mm"));
//			if (cnvcJobInfo != "")
//			{
//				element.AddText(cnvcJobInfo);
//			}

			if (cnvcBillType == ConstApp.Bill_Type_SignIn)
			{
				element.AddBlack("�뵽�ĺŴ�����ȡ�λ�����");
			}
			//element.AddBlankLine();
		}
	}	
}
