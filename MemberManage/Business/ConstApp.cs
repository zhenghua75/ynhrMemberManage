using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using ynhrMemberManage.MemberManage.Common;
using ynhrMemberManage.ORM;

namespace MemberManage.Business
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
		/// ��Ƹ����ǰ����Ԥ��ʱ��
		/// </summary>
		public int iBookDate = 0;
		public int iTishi = 0;
		public DataTable dtNameCode;
		public DataTable dtMemberCode;

		public int iTouchFlash = 1;
		public string dTouchBookBeginDate = "";
		public string dTouchBookEndDate = "";
		public string dTouchSignInBeginDate = "";
		public string dTouchSignInEndDate = "";

		//��¼����Ա
		public Oper oper;
		//��¼����Ա�����б�
		public ArrayList alOperFunc;
		//��¼����Ա�ۿ�����
		public int iDiscount = 100;

		public const string MemberType = "��Ա�ʸ�";
		public const string EnterpriseType = "��ҵ����";
		//public const string MemberPara = "��Ա����";

		public const string FreeType = "����";
		public const string BookDate = "��ǰ����Ԥ��ʱ��";
		public const string DisabledDate = "����Ч�·�";
		public const string MemberDiscount = "��Ա�ۿ�";
		public const string MemberSeats = "Ԥ��չλ��";
		public const string BookTimes = "Ԥ������";
		public const string MemberFee = "��Ա��";

		public const string ProductPrice = "��Ʒ����";
		public const string ProductDiscount = "��Ʒ�ۿ�";

		public const string Trade = "��ҵ";
		public const string Product = "�����Ʒ";
		public const string tishi = "��Ա��ʼ��ʾ��ʣ�ೡ��";

		public const string TouchFlash = "������ˢ��ʱ��";
		public const string TouchBookBeginDate = "������Ԥ����ʼʱ��";
		public const string TouchBookEndDate = "������Ԥ������ʱ��";
		public const string TouchSignInBeginDate = "������ǩ����ʼʱ��";
		public const string TouchSignInEndDate = "������ǩ������ʱ��";

		public const string IsAudit = "���";
		public const string IsNotAudit = "δ���";


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
		//СƱ����
		/// <summary>
		/// СƱ����-��ֵ
		/// </summary>
		public const string Bill_Type_InMoney = "��ֵ";
		public const string Bill_Type_AddCard = "����";
		public const string Bill_Type_Provide = "����";
		public const string Bill_Type_AddPrepay = "�ɷ�";
		public const string Bill_Type_SignIn = "ǩ��";
		public const string Bill_Type_Product_Use = "��Ʒ����";
		public const string Bill_Type_Product_Consume = "��Ʒ��ֵ�ɷ�";

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
		public const string Oper_Flag_ConsumeProduct = "�����Ʒ��ֵ�ɷ�";

		public const string Fee_Flag_Card = "����";
		public const string Fee_Flag_InMoney = "��ֵ";


		public ConstApp()
		{
			//
			// TODO: Add constructor logic here
			//
			//LoadPara();
		}

		public void LoadPara()
		{	
			SqlConnection conn = null;
			//SqlTransaction trans = null;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				
				dtNameCode = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbNameCode");
				dtMemberCode = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbMemberCode");
				
				alMemberType.Clear();
				alEnterpriseType.Clear();
				alProduct.Clear();
				alTrade.Clear();
				DataRow[] drMemberTypes = dtNameCode.Select("cnvcType='"+MemberType+"'");
				foreach (DataRow drMemberType in drMemberTypes)
				{
					NameCode nameCode = new NameCode(drMemberType);
					alMemberType.Add(nameCode.cnvcValue);
				}

				DataRow[] drEnterpriseTypes = dtNameCode.Select("cnvcType='"+EnterpriseType+"'");
				foreach (DataRow drEnterpriseType in drEnterpriseTypes)
				{
					NameCode nameCode = new NameCode(drEnterpriseType);
					alEnterpriseType.Add(nameCode.cnvcValue);
				}

				DataRow[] drProducts = dtNameCode.Select("cnvcType='"+Product+"'");
				foreach (DataRow drProduct in drProducts)
				{
					NameCode nameCode = new NameCode(drProduct);
					alProduct.Add(nameCode.cnvcValue);
				}

				DataRow[] drTrades = dtNameCode.Select("cnvcType='"+Trade+"'");
				foreach (DataRow drTrade in drTrades)
				{
					NameCode nameCode = new NameCode(drTrade);
					alTrade.Add(nameCode.cnvcValue);
				}

				DataRow[] drJobBookDates = dtNameCode.Select("cnvcType='"+BookDate+"'");
				if (drJobBookDates.Length > 0)
				{
					NameCode nameCode = new NameCode(drJobBookDates[0]);
					iBookDate = int.Parse(nameCode.cnvcValue);
				}
				

				DataRow[] drTishis = dtNameCode.Select("cnvcType='"+tishi+"'");
				if (drTishis.Length > 0)
				{
					NameCode nameCode = new NameCode(drTishis[0]);
					iTishi = int.Parse(nameCode.cnvcValue);
				}

				DataRow[] drTouchFlash = dtNameCode.Select("cnvcType='"+TouchFlash+"'");
				if (drTouchFlash.Length > 0)
				{
					NameCode nameCode = new NameCode(drTouchFlash[0]);
					iTouchFlash = int.Parse(nameCode.cnvcValue);
				}

				DataRow[] drTouchBookBeginDate = dtNameCode.Select("cnvcType='"+TouchBookBeginDate+"'");
				if (drTouchBookBeginDate.Length > 0)
				{
					NameCode nameCode = new NameCode(drTouchBookBeginDate[0]);
					dTouchBookBeginDate = nameCode.cnvcValue;
				}
				DataRow[] drTouchBookEndDate = dtNameCode.Select("cnvcType='"+TouchBookEndDate+"'");
				if (drTouchBookEndDate.Length > 0)
				{
					NameCode nameCode = new NameCode(drTouchBookEndDate[0]);
					dTouchBookEndDate = nameCode.cnvcValue;
				}

				DataRow[] drTouchSignInBeginDate = dtNameCode.Select("cnvcType='"+TouchSignInBeginDate+"'");
				if (drTouchSignInBeginDate.Length > 0)
				{
					NameCode nameCode = new NameCode(drTouchSignInBeginDate[0]);
					dTouchSignInBeginDate = nameCode.cnvcValue;
				}

				DataRow[] drTouchSignInEndDate = dtNameCode.Select("cnvcType='"+TouchSignInEndDate+"'");
				if (drTouchSignInEndDate.Length > 0)
				{
					NameCode nameCode = new NameCode(drTouchSignInEndDate[0]);
					dTouchSignInEndDate = nameCode.cnvcValue;
				}
				htFree.Clear();
				htBookDate.Clear();
				htDisabledDate.Clear();
				htMemberDiscount.Clear();
				htMemberSeats.Clear();
				htDept.Clear();
				htMemberFee.Clear();
				DataRow[] drFreeTypes = dtMemberCode.Select("cnvcMemberType='"+FreeType+"'");
				foreach (DataRow drFreeType in drFreeTypes)
				{
					MemberCode memberCode = new MemberCode(drFreeType);
					htFree.Add(memberCode.cnvcMemberName,memberCode.cnvcMemberValue);
				}
				DataRow[] drBookDates = dtMemberCode.Select("cnvcMemberType='"+BookDate+"'");
				foreach (DataRow drBookDate in drBookDates)
				{
					MemberCode memberCode = new MemberCode(drBookDate);
					htBookDate.Add(memberCode.cnvcMemberName,memberCode.cnvcMemberValue);
				}

				DataRow[] drDisabledDates = dtMemberCode.Select("cnvcMemberType='"+DisabledDate+"'");
				foreach (DataRow drDisabledDate in drDisabledDates)
				{
					MemberCode memberCode = new MemberCode(drDisabledDate);
					htDisabledDate.Add(memberCode.cnvcMemberName,memberCode.cnvcMemberValue);
				}

				DataRow[] drMemberDiscounts = dtMemberCode.Select("cnvcMemberType='"+MemberDiscount+"'");
				foreach (DataRow drMemberDiscount in drMemberDiscounts)
				{
					MemberCode memberCode = new MemberCode(drMemberDiscount);
					htMemberDiscount.Add(memberCode.cnvcMemberName,memberCode.cnvcMemberValue);
				}

				DataRow[] drMemberSeats = dtMemberCode.Select("cnvcMemberType='"+MemberSeats+"'");
				foreach (DataRow drMemberSeat in drMemberSeats)
				{
					MemberCode memberCode = new MemberCode(drMemberSeat);
					htMemberSeats.Add(memberCode.cnvcMemberName,memberCode.cnvcMemberValue);
				}

				DataRow[] drMemberFees = dtMemberCode.Select("cnvcMemberType='"+MemberFee+"'");
				foreach (DataRow drMemberFee in drMemberFees)
				{
					MemberCode memberCode = new MemberCode(drMemberFee);
					htMemberFee.Add(memberCode.cnvcMemberName,memberCode.cnvcMemberValue);
				}
				
				DataTable dtDept = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbDept");
				foreach (DataRow drDept in dtDept.Rows)
				{
					Dept dept = new Dept(drDept);
					htDept.Add(dept.cnnDeptID,dept);
				}
			}
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				//trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				//trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				//trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
	
		}
	}
}
