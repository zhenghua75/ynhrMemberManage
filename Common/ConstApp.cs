using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
//using ynhrMemberManage.Domain;
//using ynhrMemberManage.ORM;

namespace ynhrMemberManage.Common
{
	/// <summary>
	/// ������ȫ�ֱ���
	/// </summary>
	public class ConstApp
	{
		/// <summary>
		/// ��Ա�ʸ�
		/// </summary>		
		public ArrayList alMemberType = new ArrayList();
		/// <summary>
		/// ��ҵ����
		/// </summary>
		public ArrayList alEnterpriseType = new ArrayList();
		/// <summary>
		/// �����Ʒ
		/// </summary>
		public ArrayList alProduct = new ArrayList();
		/// <summary>
		/// ��ҵ
		/// </summary>
		public ArrayList alTrade = new ArrayList();
		/// <summary>
		/// ��ѳ���
		/// </summary>
		public Hashtable htFree = new Hashtable();
		/// <summary>
		/// ��ǰ����Ԥ��ʱ��
		/// </summary>
		public Hashtable htBookDate = new Hashtable();
		/// <summary>
		/// ����Ч�·�
		/// </summary>
		public Hashtable htDisabledDate = new Hashtable();
        /// <summary>
        /// ����Ч�·���ͳ�ֵ���
        /// </summary>
        public Hashtable htDisabledDateMinAmount = new Hashtable();
		/// <summary>
		/// ��Ա�ۿ�
		/// </summary>
		public Hashtable htMemberDiscount = new Hashtable();
		/// <summary>
		/// չλ��
		/// </summary>
		public Hashtable htMemberSeats = new Hashtable();

		/// <summary>
		/// ����
		/// </summary>
		public Hashtable htDept = new Hashtable();
		/// <summary>
		/// ��Ա��
		/// </summary>
		public Hashtable htMemberFee = new Hashtable();
        /// <summary>
        /// ��ֵ�ۿ�
        /// </summary>
        public ArrayList alInMoneyDiscount = new ArrayList();
        
		/// <summary>
		/// ��Ƹ����ǰ����Ԥ��ʱ��
		/// </summary>
		public int iBookDate = 0;
		public int iTishi = 0;
		public DataTable dtNameCode;
		public DataTable dtMemberCode;

		public int iTouchFlash = 30;
		public string dTouchBookBeginDate = "";
		public string dTouchBookEndDate = "";
		public string dTouchSignInBeginDate = "";
		public string dTouchSignInEndDate = "";

        public string strJobBeginDate = "";
        public string strJobEndDate = "";

        public string strJobBookingBeginDate = "";
        public string strJobBookingEndDate = "";

        public string strJobRemainBeginDate = "";
        public string strJobRemainEndDate = "";

        public bool bInMoneyDonate = false;
		//��¼����Ա
		//public Oper oper;
		//��¼����Ա�����б�
		//public ArrayList alOperFunc;
		//��¼����Ա�ۿ�����
		//public int iDiscount = 100;

		public const string MemberType = "��Ա�ʸ�";
		public const string EnterpriseType = "��ҵ����";
		//public const string MemberPara = "��Ա����";

		public const string FreeType = "����";
		public const string BookDate = "��ǰ����Ԥ��ʱ��";
		public const string DisabledDate = "����Ч�·�";
        public const string DisabledDateMinAmount = "����Ч�·���ͳ�ֵ���";
		public const string MemberDiscount = "��Ա�ۿ�";
		public const string MemberSeats = "Ԥ��չλ��";
		public const string BookTimes = "Ԥ������";
		public const string MemberFee = "��Ա��";

        public const string PointsBK = "�쿨����������";
        public const string PointsCZ = "��ֵ100Ԫ������";
        public const string PointsXF = "����100Ԫ������";
        public const string PointsJF = "��������1Ԫ�������";
        public const string PointsMF = "��ѳ��λ�����";

		public const string ProductPrice = "��Ʒ����";
		public const string ProductDiscount = "��Ʒ�ۿ�";
        public const string ProductPoints = "�һ�����";

		public const string Trade = "��ҵ";
		public const string Product = "�����Ʒ";
		public const string tishi = "��Ա��ʼ��ʾ�����";
        //public const string ValueAddedServices = "��ֵ����";
        public const string IsJob = "�Ƿ�μ���Ƹ��(��/��)Ĭ����";
        public const string IsMemberFee = "�Ƿ��л�Ա��(��/��)Ĭ�Ϸ�";
        public const string IsInMoney = "�Ƿ��ֵ(��/��)Ĭ����";
        public const string IsProduct = "�Ƿ����ѷ����Ʒ(��/��)Ĭ����";
        public const string IsProductSelect = "�Ƿ��������ѷ����Ʒ(��/��)Ĭ�Ϸ�";
        public const string IsFeeType = "�Ƿ񳡴�(��/��)Ĭ�Ϸ�";
        public const string IsDisabledDate = "�Ƿ���Ĭ������(��/��)Ĭ�Ϸ�";

        public Hashtable htIsJob = new Hashtable();
        public Hashtable htIsMemberFee = new Hashtable();
        public Hashtable htIsInMoney = new Hashtable();
        public Hashtable htIsProduct = new Hashtable();
        public Hashtable htIsProductSelect = new Hashtable();
        public Hashtable htIsFeeType = new Hashtable();
        public Hashtable htIsDisabledDate = new Hashtable();

		public const string TouchFlash = "������ˢ��ʱ��(��)";
		public const string TouchBookBeginDate = "������Ԥ����ʼʱ��";
		public const string TouchBookEndDate = "������Ԥ������ʱ��";
		public const string TouchSignInBeginDate = "������ǩ����ʼʱ��";
		public const string TouchSignInEndDate = "������ǩ������ʱ��";

        public const string JobListBeginDate = "��Ƹ��ǩ���б���ʾ��Χ��ʼ����";
        public const string JobListEndDate = "��Ƹ��ǩ���б���ʾ��Χ��������";

        public const string JobBookingListBeginDate = "��Ƹ��Ԥ���б���ʾ��Χ��ʼ����";
        public const string JobBookingListEndDate = "��Ƹ��Ԥ���б���ʾ��Χ��������";

        public const string JobRemainListBeginDate = "��Ƹ��Ԥ���б���ʾ��Χ��ʼ����";
        public const string JobRemainListEndDate = "��Ƹ��Ԥ���б���ʾ��Χ��������";

        public const string NetBookBeforeDate = "������ǰԤ������";
        public const string InMoneySetting = "��ֵ����";
		public const string IsAudit = "���";
		public const string IsNotAudit = "δ���";

        public const string InMoneyDiscount = "��ֵ�ۿ�";

		//չλ״̬
		/// <summary>
		/// Ԥ�� ��ɫ
		/// </summary>
		public const string Show_Seat_State_Booking = "Ԥ��";
		/// <summary>
		/// ȡ��Ԥ��
		/// </summary>
		public const string Show_Seat_State_No_Booking = "ȡ��Ԥ��";
		/// <summary>
		/// Ԥ�� ��ɫ
		/// </summary>
		public const string Show_Seat_State_Remain = "Ԥ��";
		/// <summary>
		/// ǩ�� ��ɫ
		/// </summary>
		public const string Show_Seat_State_SignIn = "ǩ��";
		public const string Show_Seat_State_Release = "�ͷ�";
		public const string Show_Seat_State_No_SignIn = "ȡ��ǩ��";

		//��״̬
		/// <summary>
		/// ��������
		/// </summary>
		public const string Card_State_InUse = "��������";
		/// <summary>
		/// �ѹ�ʧ
		/// </summary>
		public const string Card_State_InLose = "�ѹ�ʧ";
		/// <summary>
		/// �Ѳ���
		/// </summary>
		public const string Card_State_InAdd = "�Ѳ���";
		/// <summary>
		/// �ѻ���
		/// </summary>
		public const string Card_State_InCallBack = "�ѻ���";
		/// <summary>
		/// δ����
		/// </summary>
		public const string Card_State_NoCard = "δ����";

		/// <summary>
		/// ��ѳ���-������
		/// </summary>
		public const string Free_Time_NoLimit = "������";
        public const string YesNo_Yes = "��";
        public const string YesNo_No = "��";

		//СƱ����
		/// <summary>
		/// СƱ����-��ֵ
		/// </summary>
		public const string Bill_Type_InMoney = "��ֵ";
		public const string Bill_Type_AddCard = "����";
		public const string Bill_Type_Provide = "����";
        public const string Bill_Type_AddPrepay = "�ǻ�Ա��ֵ";//�ɷ�
		public const string Bill_Type_SignIn = "ǩ��";
		public const string Bill_Type_Product_Use = "��Ʒ����";
		public const string Bill_Type_Product_Consume = "��Ʒ����";//"��Ʒ��ֵ�ɷ�";

		public const string Oper_Flag_Provide = "����";
		public const string Oper_Flag_NoCard = "δ����";
		public const string Oper_Flag_RenewCard = "���·���";
		public const string Oper_Flag_InMoney = "��ֵ";
		public const string Oper_Flag_InLose = "��ʧ";
		public const string Oper_Flag_InUse = "���";
		public const string Oper_Flag_InAdd = "����";
		public const string Oper_Flag_InCallBack = "����";
		public const string Oper_Flag_OperInCallBack = "����Ա������";
		public const string Oper_Flag_AddJob = "������Ƹ��";
		public const string Oper_Flag_ModifyJob = "������Ƹ��";
		public const string Oper_Flag_ModifyMember = "�޸Ļ�Ա";
		public const string Oper_Flag_ModifyFMember = "�޸ķǻ�Ա";
		public const string Oper_Flag_AddShow = "���չ��";
		public const string Oper_Flag_SaveShowPlan = "����չ������";
		public const string Oper_Flag_DeleteShowPlan = "ɾ��չ������";
		public const string Oper_Flag_MemberSeatBooking = "��ԱչλԤ��";
		public const string Oper_Flag_MemberSeatRemain = "չλԤ��";
		public const string Oper_Flag_FMemberSeatBooking = "�ǻ�ԱչλԤ��";
		public const string Oper_Flag_CancelMemberSeatBooking = "ȡ����ԱչλԤ��";
		public const string Oper_Flag_CancelFMemberSeatBooking = "ȡ���ǻ�ԱչλԤ��";
		public const string Oper_Flag_HoldSeat = "ռλ";
		public const string Oper_Flag_AddFMember = "��ӷǻ�Ա";
		public const string Oper_Flag_CancelMemberSeatRemain = "ȡ��չλԤ��";
		public const string Oper_Flag_AddPrepay = "�ɷ�";
		public const string Oper_Flag_ReturnPrepay = "�˷�";
		public const string Oper_Flag_MemberSignIn = "��Աǩ��";
		public const string Oper_Flag_ChangeSeat = "��λ";
		public const string Oper_Flag_Release = "�ͷ�";
		public const string Oper_Flag_EnMemberSignIn = "ǿ�ƻ�Աǩ��";
		public const string Oper_Flag_FMemberSignIn = "�ǻ�Աǩ��";
		public const string Oper_Flag_EnFMemberSignIn = "�ǻ�Աǿ��ǩ��";
		public const string Oper_Flag_Product = "�����Ʒ����";
        public const string Oper_Flag_ConsumeProduct = "�����Ʒ����";

        //public const string Oper_Flag_ConsumeProduct_1 = "�����Ʒ����";

		public const string Fee_Flag_Card = "����";
		public const string Fee_Flag_InMoney = "��ֵ";
        public const string Fee_Flag_Donate = "����";
        public const string Fee_Flag_SignIn = "ǩ��";
        public const string Fee_Flag_Product = "����";
        //public const string Fee_Flag_Product = "��������";
        public const string Fee_Flag_Cost = "������";
        public const string CardType = "����ѡ��";
        public const string CardType_L6 = "l6";
        public const string CardType_L8 = "l8";
        public string strCardType = "l6";
        public string strCardTypeL6Name = "һͨ��";
        public string strCardTypeL8Name = "�Ǵο�";
		public ConstApp()
		{
			//
			// TODO: Add constructor logic here
			//
			//LoadPara();
		}

		
	}
}
