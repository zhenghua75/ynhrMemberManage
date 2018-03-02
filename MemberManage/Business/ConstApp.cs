using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using ynhrMemberManage.MemberManage.Common;
using ynhrMemberManage.ORM;

namespace MemberManage.Business
{
	/// <summary>
	/// 常量、全局变量
	/// </summary>
	public class ConstApp
	{
		/// <summary>
		/// 会员资格
		/// </summary>		
		public ArrayList alMemberType = new ArrayList();
		/// <summary>
		/// 企业性质
		/// </summary>
		public ArrayList alEnterpriseType = new ArrayList();
		/// <summary>
		/// 服务产品
		/// </summary>
		public ArrayList alProduct = new ArrayList();
		/// <summary>
		/// 行业
		/// </summary>
		public ArrayList alTrade = new ArrayList();
		/// <summary>
		/// 免费场次
		/// </summary>
		public Hashtable htFree = new Hashtable();
		/// <summary>
		/// 提前接受预订时间
		/// </summary>
		public Hashtable htBookDate = new Hashtable();
		/// <summary>
		/// 卡有效月份
		/// </summary>
		public Hashtable htDisabledDate = new Hashtable();
		/// <summary>
		/// 会员折扣
		/// </summary>
		public Hashtable htMemberDiscount = new Hashtable();
		/// <summary>
		/// 展位数
		/// </summary>
		public Hashtable htMemberSeats = new Hashtable();

		/// <summary>
		/// 部门
		/// </summary>
		public Hashtable htDept = new Hashtable();
		/// <summary>
		/// 会员费
		/// </summary>
		public Hashtable htMemberFee = new Hashtable();

		/// <summary>
		/// 招聘会提前接受预订时间
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

		//登录操作员
		public Oper oper;
		//登录操作员功能列表
		public ArrayList alOperFunc;
		//登录操作员折扣上限
		public int iDiscount = 100;

		public const string MemberType = "会员资格";
		public const string EnterpriseType = "企业性质";
		//public const string MemberPara = "会员参数";

		public const string FreeType = "场次";
		public const string BookDate = "提前接受预定时间";
		public const string DisabledDate = "卡有效月份";
		public const string MemberDiscount = "会员折扣";
		public const string MemberSeats = "预订展位数";
		public const string BookTimes = "预订次数";
		public const string MemberFee = "会员费";

		public const string ProductPrice = "产品单价";
		public const string ProductDiscount = "产品折扣";

		public const string Trade = "行业";
		public const string Product = "服务产品";
		public const string tishi = "会员开始提示的剩余场次";

		public const string TouchFlash = "触摸屏刷新时间";
		public const string TouchBookBeginDate = "触摸屏预订开始时间";
		public const string TouchBookEndDate = "触摸屏预订结束时间";
		public const string TouchSignInBeginDate = "触摸屏签到开始时间";
		public const string TouchSignInEndDate = "触摸屏签到结束时间";

		public const string IsAudit = "审核";
		public const string IsNotAudit = "未审核";


		//展位状态
		/// <summary>
		/// 预订 红色
		/// </summary>
		public const string Show_Seat_State_Booking = "预订";
		/// <summary>
		/// 取消预订
		/// </summary>
		public const string Show_Seat_State_No_Booking = "取消预订";
		/// <summary>
		/// 预留 黄色
		/// </summary>
		public const string Show_Seat_State_Remain = "预留";
		/// <summary>
		/// 签到 蓝色
		/// </summary>
		public const string Show_Seat_State_SignIn = "签到";
		public const string Show_Seat_State_Release = "释放";
		public const string Show_Seat_State_No_SignIn = "取消签到";

		//卡状态
		/// <summary>
		/// 正常在用
		/// </summary>
		public const string Card_State_InUse = "正常在用";
		/// <summary>
		/// 已挂失
		/// </summary>
		public const string Card_State_InLose = "已挂失";
		/// <summary>
		/// 已补卡
		/// </summary>
		public const string Card_State_InAdd = "已补卡";
		/// <summary>
		/// 已回收
		/// </summary>
		public const string Card_State_InCallBack = "已回收";
		/// <summary>
		/// 未发卡
		/// </summary>
		public const string Card_State_NoCard = "未发卡";

		/// <summary>
		/// 免费场次-不限制
		/// </summary>
		public const string Free_Time_NoLimit = "不限制";
		//小票类型
		/// <summary>
		/// 小票类型-充值
		/// </summary>
		public const string Bill_Type_InMoney = "充值";
		public const string Bill_Type_AddCard = "补卡";
		public const string Bill_Type_Provide = "发卡";
		public const string Bill_Type_AddPrepay = "缴费";
		public const string Bill_Type_SignIn = "签到";
		public const string Bill_Type_Product_Use = "产品消费";
		public const string Bill_Type_Product_Consume = "产品充值缴费";

		public const string Oper_Flag_Provide = "发卡";
		public const string Oper_Flag_NoCard = "未发卡";
		public const string Oper_Flag_RenewCard = "重新发卡";
		public const string Oper_Flag_InMoney = "充值";
		public const string Oper_Flag_InLose = "挂失";
		public const string Oper_Flag_InUse = "解挂";
		public const string Oper_Flag_InAdd = "补卡";
		public const string Oper_Flag_InCallBack = "回收";
		public const string Oper_Flag_OperInCallBack = "操作员卡回收";
		public const string Oper_Flag_AddJob = "新增招聘会";
		public const string Oper_Flag_ModifyJob = "新增招聘会";
		public const string Oper_Flag_ModifyMember = "修改会员";
		public const string Oper_Flag_ModifyFMember = "修改非会员";
		public const string Oper_Flag_AddShow = "添加展厅";
		public const string Oper_Flag_SaveShowPlan = "保存展厅方案";
		public const string Oper_Flag_DeleteShowPlan = "删除展厅方案";
		public const string Oper_Flag_MemberSeatBooking = "会员展位预订";
		public const string Oper_Flag_MemberSeatRemain = "展位预留";
		public const string Oper_Flag_FMemberSeatBooking = "非会员展位预订";
		public const string Oper_Flag_CancelMemberSeatBooking = "取消会员展位预订";
		public const string Oper_Flag_CancelFMemberSeatBooking = "取消非会员展位预订";
		public const string Oper_Flag_HoldSeat = "占位";
		public const string Oper_Flag_AddFMember = "添加非会员";
		public const string Oper_Flag_CancelMemberSeatRemain = "取消展位预留";
		public const string Oper_Flag_AddPrepay = "缴费";
		public const string Oper_Flag_ReturnPrepay = "退费";
		public const string Oper_Flag_MemberSignIn = "会员签到";
		public const string Oper_Flag_ChangeSeat = "换位";
		public const string Oper_Flag_Release = "释放";
		public const string Oper_Flag_EnMemberSignIn = "强制会员签到";
		public const string Oper_Flag_FMemberSignIn = "非会员签到";
		public const string Oper_Flag_EnFMemberSignIn = "非会员强制签到";
		public const string Oper_Flag_Product = "服务产品消费";
		public const string Oper_Flag_ConsumeProduct = "服务产品充值缴费";

		public const string Fee_Flag_Card = "发卡";
		public const string Fee_Flag_InMoney = "充值";


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
			catch (BusinessException bex) //业务异常
			{	
				//事务回滚					
				//trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				//trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				//trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
	
		}
	}
}
