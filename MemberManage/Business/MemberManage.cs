
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	MemberManage.cs
* 作者:	     郑华
* 创建日期:    2007-12-10
* 功能描述:    会员管理业务

*                                                           Copyright(C) 2007 zhenghua
*************************************************************************************/

using System;
using ynhrMemberManage.ORM;
using ynhrMemberManage.MemberManage.Common;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using ynhrMemberManage.CardCommon;
using ynhrMemberManage.CardCommon.CardRef;
using ynhrMemberManage.CardCommon.CardDef;
using MemberManage.Print;
namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for MemberManage.
	/// </summary>
	public class MemberManage
	{
		/// <summary>
		/// 当前数据库事务
		/// </summary>
		private SqlTransaction trans = null;
		/// <summary>
		/// 当前数据库连接
		/// </summary>
		private SqlConnection conn = null;
		public MemberManage()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// 发卡
		/// </summary>
		/// <param name="member"></param>
		/// 
		#region
		public void AddMember (Member member,ArrayList alProduct,PrintedBill pBill,bool IsPutCard)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				//会员
				EntityMapping.Create(member,trans);
				//流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);
				//会员日志
				MemberLog memberLog = new MemberLog(member.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(memberLog,trans);
				//充值日志
				//				MemberPrepayLog prepayLog = new MemberPrepayLog(member.ToTable());
				//				prepayLog.cnnSerialNo = dSerialNo;
				//				EntityMapping.Create(prepayLog,trans);

				//服务产品
				for (int i = 0 ; i<alProduct.Count; i ++)
				{
					MemberProduct memberProductNew = (MemberProduct)alProduct[i];
					MemberProduct memberProduct = EntityMapping.Get(memberProductNew,trans) as MemberProduct;
					if (null == memberProduct)
					{
						//throw new BusinessException("会员服务产品消费","请充值");
						memberProduct = new MemberProduct(memberProductNew.ToTable());
						EntityMapping.Create(memberProduct,trans);
					}
					else
					{
						int iNewFree = int.Parse(memberProductNew.cnvcFree);
						int iFree = int.Parse(memberProduct.cnvcFree);
						memberProduct.cnvcFree = (iNewFree+iFree).ToString();
						EntityMapping.Update(memberProduct,trans);
					}
				}
				//操作日志
				//				if (IsPutCard)
				//				{
				//					OperLog operLog = new OperLog(member.ToTable());
				//					//operLog.cnnPrepay = member.cnn
				//					operLog.cnnSerialNo = dSerialNo;
				//					operLog.cnvcOperFlag = ConstApp.Oper_Flag_Provide;
				//					EntityMapping.Create(operLog,trans);
				//					//小票重打				
				//					Bill bill = new Bill(pBill.ToTable());
				//					//bill.cnvcBillType = ConstApp.Bill_Type_Provide;
				//					bill.cnnRepeats = 0;
				//					EntityMapping.Create(bill,trans);
				//					//trans.Commit();
				//					CardM1 m1 = new CardM1();
				//					string strReturn = m1.PutOutCard(member.cnvcMemberCardNo,-1,-1);
				//					if (strReturn.Equals("OPSUCCESS"))
				//					{
				//						trans.Commit();
				//					}
				//					else
				//					{
				//						throw new BusinessException("卡操作异常",strReturn);
				//					}
				//				}
				//				else
				//				{
				OperLog operLog = new OperLog(member.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_NoCard;
				EntityMapping.Create(operLog,trans);
				trans.Commit();
				//}
				
				
			}
			catch (BusinessException bex) //业务异常
			{	
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}
		#endregion

		public void RenewCard (Member Oldmember,PrintedBill pBill)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				//会员
				Member member = EntityMapping.Get(Oldmember,trans) as Member;
				if (null == member)
				{
					throw new BusinessException("重新发卡","未找到会员资料");
				}
				
				//流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);
				//更新会员状态
				member.cnvcState = ConstApp.Card_State_InUse;
				member.cnvcMemberCardNo = Oldmember.cnvcProduct;
				member.cnvcOperName = Oldmember.cnvcOperName;
				member.cndOperDate = Oldmember.cndOperDate;

				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcState='"+ConstApp.Card_State_InUse+"',cnvcMemberCardNo='"+Oldmember.cnvcProduct+"',cnvcOperName='"+Oldmember.cnvcOperName+"',cndOperDate='"+Oldmember.cndOperDate+"' where cnvcMemberCardNo='"+Oldmember.cnvcMemberCardNo+"'");
				//会员日志
				MemberLog memberLog = new MemberLog(member.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(memberLog,trans);

				//服务产品
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMemberProduct set cnvcMemberCardNo='"+Oldmember.cnvcProduct+"',cnvcOperName='"+Oldmember.cnvcOperName+"',cndOperDate='"+Oldmember.cndOperDate+"' where cnvcMemberCardNo='"+Oldmember.cnvcMemberCardNo+"'");

				//充值记录
				MemberPrepayLog prepayLog = new MemberPrepayLog(member.ToTable());
				prepayLog.cnnSerialNo = dSerialNo;
				prepayLog.cnvcOperFlag = ConstApp.Fee_Flag_Card;
				EntityMapping.Create(prepayLog,trans);
				//操作日志

				OperLog operLog = new OperLog(member.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_RenewCard;
				EntityMapping.Create(operLog,trans);
				//小票重打				
				Bill bill = new Bill(pBill.ToTable());
				bill.cnnRepeats = 0;
				EntityMapping.Create(bill,trans);
				//trans.Commit();
				CardM1 m1 = new CardM1();
				string strReturn = m1.PutOutCard(member.cnvcMemberCardNo,-1,-1);
				if (strReturn.Equals("OPSUCCESS"))
				{
					trans.Commit();
				}
				else
				{
					throw new BusinessException("卡操作异常",strReturn);
				}
				
				
				
			}
			catch (BusinessException bex) //业务异常
			{	
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}
		public void NoCardDelete (Member Oldmember)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				//会员
				Member member = EntityMapping.Get(Oldmember,trans) as Member;
				if (null == member)
				{
					throw new BusinessException("删除未发卡会员","未找到未发卡会员资料");
				}
				
				//流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);
				//删除
				EntityMapping.Delete(member,trans);
				//会员日志
				MemberLog memberLog = new MemberLog(member.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				memberLog.cnvcOperName = Oldmember.cnvcOperName;
				memberLog.cndOperDate = Oldmember.cndOperDate;
				EntityMapping.Create(memberLog,trans);

				//服务产品
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"delete from tbMemberProduct where cnvcMemberCardNo = '"+Oldmember.cnvcMemberCardNo+"'");

				
				//操作日志

				OperLog operLog = new OperLog(memberLog.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = "删除未发卡会员";
				EntityMapping.Create(operLog,trans);
				
				trans.Commit();
				
				
			}
			catch (BusinessException bex) //业务异常
			{	
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}
		public void UpdateBillRepeats (Bill bill)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				bill.cnnRepeats = bill.cnnRepeats+1;
				EntityMapping.Update(bill,trans);
				trans.Commit();
				
			}
			catch (BusinessException bex) //业务异常
			{	
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}
		
		/// <summary>
		/// 添加非会员信息
		/// </summary>
		/// <param name="member"></param>
		/// 
		#region 添加非会员信息
		public void AddFMember (FMember member)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Create(member,trans);

				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				Decimal dSerialNo = EntityMapping.Create(serial,trans);

				FMemberLog memberLog = new FMemberLog(member.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(memberLog,trans);


				OperLog operLog = new OperLog(member.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_AddFMember;
				EntityMapping.Create(operLog,trans);
				trans.Commit();
				
			}
			catch (BusinessException bex) //业务异常
			{	
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}

		#endregion
		public void ModifyMember (Member member)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();

				Member oldMember = EntityMapping.Get(member,trans) as Member;
				if (null == oldMember)
				{
					throw new BusinessException("修改会员","未找到相应会员，会员卡号："+oldMember.cnvcMemberCardNo);
				}
				SeqSerialNo serialNo = new SeqSerialNo();
				serialNo.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serialNo,trans);

				oldMember = member;
				EntityMapping.Update(oldMember,trans);

				MemberLog memberLog = new MemberLog(oldMember.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(memberLog,trans);

				OperLog operLog = new OperLog(memberLog.ToTable());
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_ModifyMember;
				EntityMapping.Create(operLog,trans);
				//SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcMemberName='"+member.cnvcMemberName+"' ,cnvcPaperNo = '"+member.cnvcPaperNo+"',cnvcLinkman='"+member.cnvcLinkman+"',cnvcLinkPhone='"+member.cnvcLinkPhone+"',cnvcCompanyAddress = '"+member.cnvcCompanyAddress+"',cnvcEmail='"+member.cnvcEmail+"' ,cnvcMemberPwd='"+member.cnvcMemberPwd+"',cnvcCorporation='"+member.cnvcCorporation+"' where cnvcMemberCardNo = '"+member.cnvcMemberCardNo+"'");
				//EntityMapping.Create(member,trans);

				trans.Commit();				
				
			}
			catch (BusinessException bex) //业务异常
			{	
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}
		public void ModifyFMember (FMember member)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();

				FMember oldMember = EntityMapping.Get(member,trans) as FMember;
				if (null == oldMember)
				{
					throw new BusinessException("修改非会员","未找到相应非会员");
				}
				SeqSerialNo serialNo = new SeqSerialNo();
				serialNo.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serialNo,trans);

				oldMember = member;
				EntityMapping.Update(oldMember,trans);

				FMemberLog memberLog = new FMemberLog(oldMember.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(memberLog,trans);

				OperLog operLog = new OperLog(memberLog.ToTable());
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_ModifyFMember;
				EntityMapping.Create(operLog,trans);
				//SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcMemberName='"+member.cnvcMemberName+"' ,cnvcPaperNo = '"+member.cnvcPaperNo+"',cnvcLinkman='"+member.cnvcLinkman+"',cnvcLinkPhone='"+member.cnvcLinkPhone+"',cnvcCompanyAddress = '"+member.cnvcCompanyAddress+"',cnvcEmail='"+member.cnvcEmail+"' ,cnvcMemberPwd='"+member.cnvcMemberPwd+"',cnvcCorporation='"+member.cnvcCorporation+"' where cnvcMemberCardNo = '"+member.cnvcMemberCardNo+"'");
				//EntityMapping.Create(member,trans);

				trans.Commit();				
				
			}
			catch (BusinessException bex) //业务异常
			{	
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}
		public Member GetMember (Member member)
		{
			Member retMember ;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				DataTable dtMember = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbMember where cnvcMemberCardNo = '"+member.cnvcMemberCardNo+"' or cnvcPaperNo = '"+member.cnvcPaperNo+"' or cnvcMemberName = '"+member.cnvcMemberName+"' and cnvcState = '"+ConstApp.Card_State_InUse+"'");
				if (null == dtMember)
				{
					throw new BusinessException("查询错误","未找到此会员！");
				}
				if (dtMember.Rows.Count == 0)
				{
					throw new BusinessException("查询错误","未找到此会员！");
				}
				retMember = new Member(dtMember);
				
			}
			catch (BusinessException bex) //业务异常
			{		
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
			return retMember;

		}

		public DataTable GetSomeMember (Member member)
		{
			DataTable dtMember ;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				string strSql = "select '会员' as 会员类型, cnvcMemberCardNo as 会员卡号,cnvcMemberName as 单位名称,cnvcPaperNo as 工商注册号,cnvcDiscount as 折扣 from tbMember where cnvcState='"+ConstApp.Card_State_InUse+"' and cndEndDate > getdate() and ( cnvcMemberCardNo like '%"+member.cnvcMemberCardNo+"%' or cnvcMemberName like '%"+member.cnvcMemberName+"%' or cnvcPaperNo like '%"+member.cnvcPaperNo+"') "
					          + " union "
						      + " select '非会员' as 会员类型, null as 会员卡号,cnvcMemberName as 单位名称,cnvcPaperNo as 工商注册号,null as 折扣  from tbFMember where  cnvcMemberName like '%"+member.cnvcMemberName+"%' or cnvcPaperNo like '%"+member.cnvcPaperNo+"%' ";
				dtMember = SqlHelper.ExecuteDataTable(conn,CommandType.Text,strSql);
				
			}
			catch (BusinessException bex) //业务异常
			{		
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
			return dtMember;

		}

		public DataTable GetSomeMemberReturnPrepay (Member member)
		{
			DataTable dtMember ;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				string strSql = "select a.cnnJobID as 招聘会ID,a.cnvcMemberCardNo as 会员卡号,b.cnvcMemberName as 单位名称 ,a.cnvcPaperNo as 工商注册号,a.cnnPrepay-a.cnnReturn as 展位费  "
					          + " from tbPrepay a left outer join  "
							  + " ( "
							  + " select cnvcMemberCardNo,cnvcMemberName,cnvcPaperNo from tbMember where cndEndDate > getdate() and cnvcState='"+ConstApp.Card_State_InUse+"'"
							  + " union "
							  + " select null as cnvcMemberCardNo,cnvcMemberName,cnvcPaperNo from tbFMember "
							  + " ) b "
							  + " on a.cnvcPaperNo=b.cnvcPaperNo "
							  + " where a.cnnPrepay-a.cnnReturn > 0 and (cnvcState is null or cnvcState <> '"+ConstApp.Show_Seat_State_SignIn+"') ";
				if (member.cnvcMemberName != "")
				{
					strSql += "  and b.cnvcMemberName like '%"+member.cnvcMemberName+"%' ";
				}
				if (member.cnvcMemberCardNo != "")
				{
					strSql += " and a.cnvcMemberCardNo like '%"+member.cnvcMemberCardNo+"%'";
				}
				if (member.cnvcPaperNo != "")
				{
					strSql += " and a.cnvcPaperNo like '%"+member.cnvcPaperNo+"%' ";
				}
							  
				dtMember = SqlHelper.ExecuteDataTable(conn,CommandType.Text,strSql);
				
			}
			catch (BusinessException bex) //业务异常
			{		
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
			return dtMember;

		}

		public void ReturnPrepay (Prepay prepay)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				Prepay oldPrepay = EntityMapping.Get(prepay,trans) as Prepay;
				if (null == oldPrepay)
				{
					throw new BusinessException("退费","未查找到可退费展位费");
				}
				if (oldPrepay.cnvcState == ConstApp.Show_Seat_State_SignIn)
				{
					throw new BusinessException("退费","此展位费已被使用，不能进行退费");
				}
				oldPrepay.cnnReturn = oldPrepay.cnnReturn + prepay.cnnReturn;
				oldPrepay.cnnBalance = oldPrepay.cnnBalance - prepay.cnnReturn;
				oldPrepay.cnvcOperName = prepay.cnvcOperName;
				oldPrepay.cndOperDate = prepay.cndOperDate;
				EntityMapping.Update(oldPrepay,trans);

				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				Decimal dSerialNo = EntityMapping.Create(serial,trans);

				PrepayLog prepayLog = new PrepayLog(oldPrepay.ToTable());
				prepayLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(prepayLog,trans);

				OperLog operLog = new OperLog(prepay.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnnPrepay=prepay.cnnReturn;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_ReturnPrepay;
				EntityMapping.Create(operLog,trans);
				trans.Commit();
				
			}
			catch (BusinessException bex) //业务异常
			{	
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}

		public Member GetMemberFree (Member member)
		{
			Member retMember ;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				DataTable dtMember = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbMember where cnvcMemberCardNo = '"+member.cnvcMemberCardNo+"' and cnvcState = '"+ConstApp.Card_State_InUse+"'");
				retMember = new Member(dtMember);
				
			}
			catch (BusinessException bex) //业务异常
			{		
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
			return retMember;

		}

		public Member GetMemberbyCardNo (Member member)
		{
			Member retMember ;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				DataTable dtMember = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbMember where cnvcMemberCardNo = '"+member.cnvcMemberCardNo+"'");
//				if (null == dtMember)
//				{
//					throw new BusinessException("查询错误","未找到此会员！");
//				}
//				if (dtMember.Rows.Count == 0)
//				{
//					throw new BusinessException("查询错误","未找到此会员！");
//				}
				retMember = new Member(dtMember);
				
			}
			catch (BusinessException bex) //业务异常
			{		
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
			return retMember;

		}

		public FMember GetFMemberbyPaperNo (FMember member)
		{
			FMember retMember ;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				DataTable dtMember = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbFMember where cnvcPaperNo = '"+member.cnvcPaperNo+"'");
				//				if (null == dtMember)
				//				{
				//					throw new BusinessException("查询错误","未找到此会员！");
				//				}
				//				if (dtMember.Rows.Count == 0)
				//				{
				//					throw new BusinessException("查询错误","未找到此会员！");
				//				}
				retMember = new FMember(dtMember);
				
			}
			catch (BusinessException bex) //业务异常
			{		
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
			return retMember;

		}

		/// <summary>
		/// 补卡
		/// </summary>
		/// <param name="member"></param>
		/// 
		#region
		public void AddCard (Member member,PrintedBill pBill)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				Member oldMember = EntityMapping.Get(member,trans) as Member;
				if (null == oldMember)
				{
					throw new BusinessException("补卡","老会员不存在，会员卡号："+member.cnvcMemberCardNo);
				}

				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcState = '"+ConstApp.Card_State_InAdd+"' ,cnvcOperName='"+member.cnvcOperName+"',cndOperDate='"+member.cndOperDate+"' where cnvcMemberCardNo = '"+member.cnvcMemberCardNo+"'");

				//流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				//会员日志
				MemberLog memberLog = new MemberLog(oldMember.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				memberLog.cnvcOperName = member.cnvcOperName;
				memberLog.cndOperDate = member.cndOperDate;
				memberLog.cnvcState = ConstApp.Card_State_InAdd;
				EntityMapping.Create(memberLog,trans);
				//操作日志
				OperLog operLog = new OperLog(oldMember.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cndOperDate = member.cndOperDate;
				operLog.cnvcOperName = member.cnvcOperName;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_InAdd;
				EntityMapping.Create(operLog,trans);
				
				Member newMember = new Member(oldMember.ToTable());
				newMember.cnvcMemberCardNo = member.cnvcMemberName;
				newMember.cnvcOperName = member.cnvcOperName;
				newMember.cndOperDate = member.cndOperDate;
				newMember.cnvcState = ConstApp.Card_State_InUse;
				EntityMapping.Create(newMember,trans);

				//充值日志
//				MemberPrepayLog prepayLog = new MemberPrepayLog(newMember.ToTable());
//				prepayLog.cnnSerialNo = dSerialNo;
//				prepayLog.cnvcOperFlag = ConstApp.Fee_Flag_Card;
//				EntityMapping.Create(prepayLog,trans);

				DataTable dtMemberProduct = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberProduct where cnvcMemberCardNo='"+member.cnvcMemberCardNo+"'");
				if (dtMemberProduct.Rows.Count > 0)
				{
					foreach (DataRow drMemberProduct in dtMemberProduct.Rows)
					{
						MemberProduct mp = new MemberProduct(drMemberProduct);
						mp.cnvcMemberCardNo = newMember.cnvcMemberCardNo;
						mp.cndOperDate = newMember.cndOperDate;
						mp.cnvcOperName = newMember.cnvcOperName;
						EntityMapping.Create(mp,trans);
					}
				}

				//流水
				SeqSerialNo serial2 = new SeqSerialNo();
				serial2.cnvcFill = "0";
				decimal dSerialNo2 = EntityMapping.Create(serial2,trans);

				//会员日志
				MemberLog newMemberLog = new MemberLog(newMember.ToTable());
				newMemberLog.cnnSerialNo = dSerialNo2;
				EntityMapping.Create(newMemberLog,trans);
				//操作日志
				OperLog newOperLog = new OperLog(newMember.ToTable());
				newOperLog.cnnSerialNo = dSerialNo2;
				newOperLog.cnvcOperFlag = ConstApp.Oper_Flag_InAdd;
				EntityMapping.Create(newOperLog,trans);				

				//工本费
				if (member.cnnPrepay > 0)
				{
					CostLog costLog = new CostLog(member.ToTable());
					costLog.cnnSerialNo = dSerialNo2;
					costLog.cnvcMemberCardNo = member.cnvcMemberName;
					costLog.cnnCost = member.cnnPrepay;
					EntityMapping.Create(costLog,trans);
				}
				Bill bill = new Bill(pBill.ToTable());
				bill.cnnRepeats = 0;
				EntityMapping.Create(bill,trans);
				//trans.Commit();
				CardM1 m1 = new CardM1();
				string strReturn = m1.PutOutCard(newMember.cnvcMemberCardNo,-1,-1);
				if (strReturn.Equals("OPSUCCESS"))
				{
					trans.Commit();
				}
				else
				{
					throw new BusinessException("卡操作异常",strReturn);
				}
				
			}
			catch (BusinessException bex) //业务异常
			{	
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}
		#endregion
		/// <summary>
		/// 会员卡挂失
		/// </summary>
		/// <param name="member"></param>
		#region
		public void MemberInLose(Member member)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				Member oldMember = EntityMapping.Get(member,trans) as Member;
				if (null == oldMember)
				{
					throw new BusinessException("挂失","挂失会员不存在，会员卡号："+member.cnvcMemberCardNo);
				}

				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcState = '"+ConstApp.Card_State_InLose+"' ,cnvcOperName='"+member.cnvcOperName+"',cndOperDate='"+member.cndOperDate+"' where cnvcMemberCardNo = '"+member.cnvcMemberCardNo+"'");

				//流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				//会员日志
				MemberLog memberLog = new MemberLog(oldMember.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				memberLog.cnvcOperName = member.cnvcOperName;
				memberLog.cndOperDate = member.cndOperDate;
				memberLog.cnvcState = ConstApp.Card_State_InLose;
				EntityMapping.Create(memberLog,trans);
				//操作日志
				OperLog operLog = new OperLog(oldMember.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cndOperDate = member.cndOperDate;
				operLog.cnvcOperName = member.cnvcOperName;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_InLose;
				EntityMapping.Create(operLog,trans);
				
				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}

		}
		#endregion
		/// <summary>
		/// 会员卡解挂
		/// </summary>
		/// <param name="member"></param>
		/// 
		#region
		public void MemberInUse(Member member)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();

				Member oldMember = EntityMapping.Get(member,trans) as Member;
				if (null == oldMember)
				{
					throw new BusinessException("解挂","解挂会员不存在，会员卡号："+member.cnvcMemberCardNo);
				}

				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcState = '"+ConstApp.Card_State_InUse+"' ,cnvcOperName='"+member.cnvcOperName+"',cndOperDate='"+member.cndOperDate+"' where cnvcMemberCardNo = '"+member.cnvcMemberCardNo+"'");

				//流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				//会员日志
				MemberLog memberLog = new MemberLog(oldMember.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				memberLog.cnvcOperName = member.cnvcOperName;
				memberLog.cndOperDate = member.cndOperDate;
				memberLog.cnvcState = ConstApp.Card_State_InUse;
				EntityMapping.Create(memberLog,trans);
				//操作日志
				OperLog operLog = new OperLog(oldMember.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cndOperDate = member.cndOperDate;
				operLog.cnvcOperName = member.cnvcOperName;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_InUse;
				EntityMapping.Create(operLog,trans);
				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}

		}
		#endregion
		/// <summary>
		/// 会员卡充值
		/// </summary>
		/// <param name="member"></param>
		#region
		public void MemberInMoney(Member member,PrintedBill pBill)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				Member oldMember = EntityMapping.Get(member,trans) as Member;
				if (null == oldMember)
				{
					throw new BusinessException("充值","充值会员不存在，会员卡号："+member.cnvcMemberCardNo);
				}
				if (oldMember.cnvcFree == ConstApp.Free_Time_NoLimit)
				{
					oldMember.cnvcFree = "0";
				}
				int iFree = int.Parse(oldMember.cnvcFree)+int.Parse(member.cnvcFree);
				oldMember.cnnPrepay = oldMember.cnnPrepay + member.cnnPrepay;
				oldMember.cnvcFree = iFree.ToString();
				oldMember.cnvcOperName = member.cnvcOperName;
				oldMember.cndOperDate = member.cndOperDate;
				EntityMapping.Update(oldMember,trans);
				//流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				//会员日志
				MemberLog memberLog = new MemberLog(oldMember.ToTable());
				memberLog.cnnSerialNo = dSerialNo;				
				EntityMapping.Create(memberLog,trans);
				//会员充值日志
				MemberPrepayLog prepayLog = new MemberPrepayLog(member.ToTable());
				prepayLog.cnnSerialNo = dSerialNo;
				prepayLog.cnvcOperFlag = ConstApp.Fee_Flag_InMoney;
				EntityMapping.Create(prepayLog,trans);
				//操作日志
				OperLog operLog = new OperLog(member.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_InMoney;
				EntityMapping.Create(operLog,trans);
				//小票
				Bill bill = new Bill(pBill.ToTable());
				//bill.cnvcBillType = ConstApp.Bill_Type_InMoney;
				bill.cnnRepeats = 0;
				EntityMapping.Create(bill,trans);

				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}

		}

		public PrintedBill UserProduct(Product product,PrintedBill pBill,int iCount)
		{
			PrintedBill retBill = pBill;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				//流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				
				if (product.cnvcMemberCardNo != "")
				{
					MemberProduct memberProduct = new MemberProduct(product.ToTable());
					memberProduct.cnvcProductName = product.cnvcProduct;
					memberProduct = EntityMapping.Get(memberProduct,trans) as MemberProduct;
					if (null == memberProduct)
					{
						throw new BusinessException("会员服务产品消费","请充值");
					}
					if (memberProduct.cnvcFree != ConstApp.Free_Time_NoLimit)
					{
					
						int iFree = int.Parse(memberProduct.cnvcFree);
						if (iFree < iCount)//1)
						{
							throw new BusinessException("会员服务产品消费","请充值");
						}
						iFree -= iCount;//1;
						memberProduct.cnvcFree = iFree.ToString();
						retBill.cnvcProduct += memberProduct.cnvcFree;
						EntityMapping.Update(memberProduct,trans);	
					}

				}
				else
				{
					FMemberProduct fmemberProduct = new FMemberProduct(product.ToTable());
					fmemberProduct.cnvcProductName = product.cnvcProduct;
					fmemberProduct = EntityMapping.Get(fmemberProduct,trans) as FMemberProduct;
					if (null == fmemberProduct)
					{
						throw new BusinessException("非会员服务产品消费","请充值");
					}
					if (fmemberProduct.cnvcFree != ConstApp.Free_Time_NoLimit)
					{
						int iFree = int.Parse(fmemberProduct.cnvcFree);
						if (iFree < iCount)//1)
						{
							throw new BusinessException("非会员服务产品消费","请充值");
						}
						iFree -= iCount;//1;
						fmemberProduct.cnvcFree = iFree.ToString();
						retBill.cnvcProduct += fmemberProduct.cnvcFree;
						EntityMapping.Update(fmemberProduct,trans);
					}
				}
				
				//服务产品使用流水				
				product.cnnSerialNo = dSerialNo;
				EntityMapping.Create(product,trans);
				//操作日志
				OperLog operLog = new OperLog(product.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_Product;
				EntityMapping.Create(operLog,trans);
				//小票
				Bill bill = new Bill(pBill.ToTable());
				//bill.cnvcBillType = ConstApp.Bill_Type_Product_Use;
				bill.cnnRepeats = 0;
				EntityMapping.Create(bill,trans);

				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
			return retBill;
		}

		public void ConsumeProduct(ArrayList alProduct,bool bMember,string strProduct,PrintedBill pBill)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				//流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);
				MemberProductLog productLog = null;
				if (bMember)
				{
					productLog = (MemberProductLog)alProduct[0];
					for (int i = 0 ; i<alProduct.Count; i ++)
					{
						MemberProductLog memberProductLog = (MemberProductLog)alProduct[i];
						MemberProduct memberProduct = new MemberProduct(memberProductLog.ToTable());						
						memberProduct = EntityMapping.Get(memberProduct,trans) as MemberProduct;
						if (null == memberProduct)
						{
							//throw new BusinessException("会员服务产品消费","请充值");
							memberProduct = new MemberProduct(memberProductLog.ToTable());
							EntityMapping.Create(memberProduct,trans);
						}
						else
						{
							int iNewFree = int.Parse(memberProductLog.cnvcFree);
							int iFree = int.Parse(memberProduct.cnvcFree);
							memberProduct.cnvcFree = (iNewFree+iFree).ToString();
							EntityMapping.Update(memberProduct,trans);
						}
						SeqSerialNo serial2 = new SeqSerialNo();
						serial2.cnvcFill = "0";
						decimal dSerialNo2 = EntityMapping.Create(serial2,trans);

						memberProductLog.cnnSerialNo = dSerialNo2;
						EntityMapping.Create(memberProductLog,trans);
					}
									

				}
				else
				{
					FMemberProductLog fproductLog = (FMemberProductLog)alProduct[0];
					productLog = new MemberProductLog(fproductLog.ToTable());
					for (int i = 0 ; i<alProduct.Count; i ++)
					{
						FMemberProductLog fmemberProductLog = (FMemberProductLog)alProduct[i];
						FMemberProduct fmemberProduct = new FMemberProduct(fmemberProductLog.ToTable());						
						fmemberProduct = EntityMapping.Get(fmemberProduct,trans) as FMemberProduct;
						if (null == fmemberProduct)
						{
							//throw new BusinessException("会员服务产品消费","请充值");
							fmemberProduct = new FMemberProduct(fmemberProductLog.ToTable());
							EntityMapping.Create(fmemberProduct,trans);
						}
						else
						{
							int iNewFree = int.Parse(fmemberProductLog.cnvcFree);
							int iFree = int.Parse(fmemberProduct.cnvcFree);
							fmemberProduct.cnvcFree = (iNewFree+iFree).ToString();
							EntityMapping.Update(fmemberProduct,trans);
						}
						SeqSerialNo serial2 = new SeqSerialNo();
						serial2.cnvcFill = "0";
						decimal dSerialNo2 = EntityMapping.Create(serial2,trans);

						fmemberProductLog.cnnSerialNo = dSerialNo2;
						EntityMapping.Create(fmemberProductLog,trans);
					}
				}
				
				//服务产品使用流水				
//				product.cnnSerialNo = dSerialNo;
//				EntityMapping.Create(product,trans);
				//操作日志
				OperLog operLog = new OperLog(productLog.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_ConsumeProduct;
				EntityMapping.Create(operLog,trans);
				//小票
				Bill bill = new Bill(pBill.ToTable());
				//bill.cnvcProduct = strProduct;
				//bill.cnvcBillType = ConstApp.Bill_Type_Product_Use;
				bill.cnnRepeats = 0;
				EntityMapping.Create(bill,trans);

				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
		}
		#endregion
		public DataTable SomeInLoseMemeber(Member member)
		{
			DataTable dtMember ;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				dtMember = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select cnvcMemberCardNo as 会员卡号,cnvcMemberName as 会员名称,cnvcPaperNo as 证件号码,cnvcMemberRight as 会员资格,cnnPrepay as 预存款,cnvcFree as 场次  from tbMember where cnvcState='"+ConstApp.Card_State_InLose+"' and ( cnvcMemberCardNo like '%"+member.cnvcMemberCardNo+"%' or cnvcPaperNo = '%"+member.cnvcPaperNo+"%' or cnvcMemberName = '%"+member.cnvcMemberName+"%')");
				if (null == dtMember)
				{
					throw new BusinessException("查询错误","未找相似会员！");
				}
				if (dtMember.Rows.Count == 0)
				{
					throw new BusinessException("查询错误","未找相似会员！");
				}				
				
			}
			catch (BusinessException bex) //业务异常
			{		
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
			return dtMember;

		}


		/// <summary>
		/// 回收
		/// </summary>
		/// <param name="member"></param>
		/// 
		#region
		public void MemberCardCallBack(Member member)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				CardM1 m1=new CardM1();
				string strCardNo = "";
				string strRet = m1.ReadCard(out strCardNo);//,out dtemp,out itemp);

				if (strRet != ConstMsg.RFOK)
				{
					throw new BusinessException("卡操作失败","回收会员卡失败！");
				}		
				//Member member = new Member();
				member.cnvcMemberCardNo = strCardNo;
				Member oldMember = EntityMapping.Get(member,trans) as Member;
				if (null == oldMember)
				{
					throw new BusinessException("卡回收","会员不存在，会员卡号："+member.cnvcMemberCardNo);
				}

				string strRet2 = m1.RecycleCard();
				if (strRet != ConstMsg.RFOK)
				{
					throw new BusinessException("卡操作失败","回收会员卡失败！");
				}	
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcState = '"+ConstApp.Card_State_InCallBack+"' ,cnvcOperName='"+member.cnvcOperName+"',cndOperDate='"+member.cndOperDate+"' where cnvcMemberCardNo = '"+strCardNo+"'");

				//流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				//会员日志
				MemberLog memberLog = new MemberLog(oldMember.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				memberLog.cnvcOperName = member.cnvcOperName;
				memberLog.cndOperDate = member.cndOperDate;
				memberLog.cnvcState = ConstApp.Card_State_InCallBack;
				//memberLog.cnnPrepay = oldMember.cnnPrepay+member.cnnPrepay;
				//memberLog.cnvcFree = iFree.ToString();//oldMember.cnvcFree+member.cnvcFree;
				EntityMapping.Create(memberLog,trans);
				//操作日志
				OperLog operLog = new OperLog(oldMember.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperName = member.cnvcOperName;
				operLog.cndOperDate = member.cndOperDate;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_InCallBack;
				EntityMapping.Create(operLog,trans);

				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}

		}

		#endregion
		public DataTable SomeMemeber(Member member)
		{
			DataTable dtMember ;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				dtMember = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select cnvcMemberCardNo as 会员卡号,cnvcMemberName as 单位名称,cnvcPaperNo as 工商注册号,cnvcMemberRight as 会员资格,cnnPrepay as 预存款,cnvcFree as 场次  from tbMember where cnvcState like '%"+member.cnvcState+"%' and ( cnvcMemberCardNo like '%"+member.cnvcMemberCardNo+"%' or cnvcPaperNo = '%"+member.cnvcPaperNo+"%' or cnvcMemberName = '%"+member.cnvcMemberName+"%')");
				if (null == dtMember)
				{
					throw new BusinessException("查询错误","未找相似会员！");
				}
				if (dtMember.Rows.Count == 0)
				{
					throw new BusinessException("查询错误","未找相似会员！");
				}				
				
			}
			catch (BusinessException bex) //业务异常
			{		
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
			return dtMember;

		}
		public DataTable SomeInUseFMemeber(FMember fmember)
		{
			DataTable dtMember ;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				string strSql = "select cnvcMemberName as 单位名称,cnvcPaperNo as 工商注册号  from tbFMember where  1=1 ";
				if (fmember.cnvcMemberName != "")
				{
					strSql += " and cnvcMemberName like '%"+fmember.cnvcMemberName+"%'";
				}				
				if (fmember.cnvcPaperNo != "")
				{
					strSql += " and cnvcPaperNo like '%"+fmember.cnvcPaperNo+"%'";
				}
				dtMember = SqlHelper.ExecuteDataTable(conn,CommandType.Text,strSql);
				if (null == dtMember)
				{
					throw new BusinessException("查询错误","未找相似非会员！");
				}
				if (dtMember.Rows.Count == 0)
				{
					throw new BusinessException("查询错误","未找相似非会员！");
				}		
		
				dtMember.Columns.Add("已预订展位");
				foreach (DataRow drMember in dtMember.Rows)
				{
					//Member tMember = new Member(drMember);
					string strRet = "";
					DataTable dtSeat  = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select cnvcSeat  from tbMemberSeat where cnvcMemberCardNo is null and cnvcPaperNo = '"+drMember["工商注册号"].ToString()+"' and cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
					foreach (DataRow drSeat in dtSeat.Rows)
					{
						strRet += drSeat["cnvcSeat"].ToString()+",";
					}
					drMember["已预订展位"] = strRet;
				}
				
			}
			catch (BusinessException bex) //业务异常
			{		
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
			return dtMember;

		}

		public DataTable SomeInUseMemeber(Member member)
		{
			DataTable dtMember ;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				string strSql = "select cnvcMemberCardNo as 会员卡号,cnvcMemberName as 单位名称,cnvcPaperNo as 工商注册号,cnvcFree as 场次  from tbMember where cndEndDate >= getdate() and cnvcState='"+ConstApp.Card_State_InUse+"'";
				if (member.cnvcMemberCardNo != "")
				{
					strSql += " and cnvcMemberCardNo like '%"+member.cnvcMemberCardNo+"%'";
				}
				if (member.cnvcMemberName != "")
				{
					strSql += " and cnvcMemberName like '%"+member.cnvcMemberName+"%'";
				}
				if (member.cnvcPaperNo != "")
				{
					strSql += " and cnvcPaperNo like '%"+member.cnvcPaperNo+"%'";
				}
				dtMember = SqlHelper.ExecuteDataTable(conn,CommandType.Text,strSql);
				if (null == dtMember)
				{
					throw new BusinessException("查询错误","未找相似会员！");
				}
				if (dtMember.Rows.Count == 0)
				{
					throw new BusinessException("查询错误","未找相似会员！");
				}	
				dtMember.Columns.Add("已预订展位");
				foreach (DataRow drMember in dtMember.Rows)
				{
					//Member tMember = new Member(drMember);
					string strRet = "";
					DataTable dtSeat  = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select cnvcSeat  from tbMemberSeat where cnvcMemberCardNo = '"+drMember["会员卡号"].ToString()+"' and cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
					foreach (DataRow drSeat in dtSeat.Rows)
					{
						strRet += drSeat["cnvcSeat"].ToString()+",";
					}
					drMember["已预订展位"] = strRet;
				}

				
			}
			catch (BusinessException bex) //业务异常
			{		
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
			return dtMember;

		}

		public string BookSeat(string strPaperNo)
		{
			string strRet = "";
			try
			{
				//
				conn = ConnectionPool.BorrowConnection();
				DataTable dtSeat  = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select cnvcSeat  from tbMemberSeat where cnvcPaperNo = '"+strPaperNo+"' and cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
				foreach (DataRow drSeat in dtSeat.Rows)
				{
					strRet += drSeat["cnvcSeat"].ToString()+",";
				}
				
			}
			catch (BusinessException bex) //业务异常
			{		
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
			return strRet;

		}


//		public DataTable getValue(string strType)
//		{
//			DataTable dtValue ;
//			try
//			{
//				conn = ConnectionPool.BorrowConnection();
//				dtValue = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select cnvcValue from tbNameCode where cnvcType = '"+strType+"'");
//				if (null == dtValue)
//				{
//					throw new BusinessException("查询错误","参数为空，请初始化参数！");
//				}
//				if (dtValue.Rows.Count == 0)
//				{
//					throw new BusinessException("查询错误","参数为空，请初始化参数！");
//				}				
//				
//			}
//			catch (BusinessException bex) //业务异常
//			{		
//				//LogAdapter.WriteBusinessException(bex);
//				throw new BusinessException(bex.Type,bex.Message);		
//			}
//			catch (SqlException sex)   //数据库异常
//			{
//				//事务回滚					
//				//trans.Rollback();												
//				//LogAdapter.WriteDatabaseException(sex);				
//				throw new BusinessException("数据库异常",sex.Message);
//			}
//			catch (Exception ex)		 //其他异常
//			{
//				//事务回滚						
//				//trans.Rollback();						
//				//LogAdapter.WriteFeaturesException(ex);	
//				throw new BusinessException("其它异常",ex.Message);
//			}
//			finally
//			{
//				ConnectionPool.ReturnConnection(conn);
//			}
//			return dtValue;
//		}
//
//		public DataTable getType()
//		{
//			DataTable dtType ;
//			try
//			{
//				conn = ConnectionPool.BorrowConnection();
//				dtType = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select distinct cnvcType as 会员参数 from tbNameCode");
//				if (null == dtType)
//				{
//					throw new BusinessException("查询错误","参数为空，请初始化参数！");
//				}
//				if (dtType.Rows.Count == 0)
//				{
//					throw new BusinessException("查询错误","参数为空，请初始化参数！");
//				}				
//				
//			}
//			catch (BusinessException bex) //业务异常
//			{		
//				//LogAdapter.WriteBusinessException(bex);
//				throw new BusinessException(bex.Type,bex.Message);		
//			}
//			catch (SqlException sex)   //数据库异常
//			{
//				//事务回滚					
//				//trans.Rollback();												
//				//LogAdapter.WriteDatabaseException(sex);				
//				throw new BusinessException("数据库异常",sex.Message);
//			}
//			catch (Exception ex)		 //其他异常
//			{
//				//事务回滚						
//				//trans.Rollback();						
//				//LogAdapter.WriteFeaturesException(ex);	
//				throw new BusinessException("其它异常",ex.Message);
//			}
//			finally
//			{
//				ConnectionPool.ReturnConnection(conn);
//			}
//			return dtType;
//		}
//
//		public DataTable getNameCode()
//		{
//			DataTable dtType ;
//			try
//			{
//				conn = ConnectionPool.BorrowConnection();
//				dtType = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select cnvcCodeID as 代码ID,cnvcType as 代码类型,cnvcValue as 代码值 from tbNameCode where cnvcType <> '"+ConstApp.MemberPara+"' order by cnvcType,cnvcValue");
//				if (null == dtType)
//				{
//					throw new BusinessException("查询错误","参数为空，请初始化参数！");
//				}
//				if (dtType.Rows.Count == 0)
//				{
//					throw new BusinessException("查询错误","参数为空，请初始化参数！");
//				}				
//				
//			}
//			catch (BusinessException bex) //业务异常
//			{		
//				//LogAdapter.WriteBusinessException(bex);
//				throw new BusinessException(bex.Type,bex.Message);		
//			}
//			catch (SqlException sex)   //数据库异常
//			{
//				//事务回滚					
//				//trans.Rollback();												
//				//LogAdapter.WriteDatabaseException(sex);				
//				throw new BusinessException("数据库异常",sex.Message);
//			}
//			catch (Exception ex)		 //其他异常
//			{
//				//事务回滚						
//				//trans.Rollback();						
//				//LogAdapter.WriteFeaturesException(ex);	
//				throw new BusinessException("其它异常",ex.Message);
//			}
//			finally
//			{
//				ConnectionPool.ReturnConnection(conn);
//			}
//			return dtType;
//		}
//
//
//		public DataTable getMemberCode()
//		{
//			DataTable dtNameCode ;
//			try
//			{
//				conn = ConnectionPool.BorrowConnection();
//				dtNameCode = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select cnnMemberCodeID as 参数ID,cnvcMemberName as 会员名称,cnvcMemberType as  参数类型,cnvcMemberValue as 参数值  from tbMemberCode order by 会员名称,参数类型,参数值");
////				if (null == dtNameCode)
////				{
////					throw new BusinessException("查询错误","参数为空，请初始化参数！");
////				}
////				if (dtNameCode.Rows.Count == 0)
////				{
////					throw new BusinessException("查询错误","参数为空，请初始化参数！");
////				}				
//				
//			}
//			catch (BusinessException bex) //业务异常
//			{		
//				//LogAdapter.WriteBusinessException(bex);
//				throw new BusinessException(bex.Type,bex.Message);		
//			}
//			catch (SqlException sex)   //数据库异常
//			{
//				//事务回滚					
//				//trans.Rollback();												
//				//LogAdapter.WriteDatabaseException(sex);				
//				throw new BusinessException("数据库异常",sex.Message);
//			}
//			catch (Exception ex)		 //其他异常
//			{
//				//事务回滚						
//				//trans.Rollback();						
//				//LogAdapter.WriteFeaturesException(ex);	
//				throw new BusinessException("其它异常",ex.Message);
//			}
//			finally
//			{
//				ConnectionPool.ReturnConnection(conn);
//			}
//			return dtNameCode;
//		}

//		public DataTable getMemberType()
//		{
//			DataTable dtNameCode ;
//			try
//			{
//				conn = ConnectionPool.BorrowConnection();
//				dtNameCode = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbNameCode where cnvcType='"+ConstApp.MemberType+"'");
//				if (null == dtNameCode)
//				{
//					throw new BusinessException("查询错误","参数为空，请初始化参数！");
//				}
//				if (dtNameCode.Rows.Count == 0)
//				{
//					throw new BusinessException("查询错误","参数为空，请初始化参数！");
//				}				
//				
//			}
//			catch (BusinessException bex) //业务异常
//			{		
//				//LogAdapter.WriteBusinessException(bex);
//				throw new BusinessException(bex.Type,bex.Message);		
//			}
//			catch (SqlException sex)   //数据库异常
//			{
//				//事务回滚					
//				//trans.Rollback();												
//				//LogAdapter.WriteDatabaseException(sex);				
//				throw new BusinessException("数据库异常",sex.Message);
//			}
//			catch (Exception ex)		 //其他异常
//			{
//				//事务回滚						
//				//trans.Rollback();						
//				//LogAdapter.WriteFeaturesException(ex);	
//				throw new BusinessException("其它异常",ex.Message);
//			}
//			finally
//			{
//				ConnectionPool.ReturnConnection(conn);
//			}
//			return dtNameCode;
//		}

//		public DataTable getMemberPara()
//		{
//			DataTable dtNameCode ;
//			try
//			{
//				conn = ConnectionPool.BorrowConnection();
//				dtNameCode = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbNameCode where cnvcType='"+ConstApp.MemberPara+"'");
//				if (null == dtNameCode)
//				{
//					throw new BusinessException("查询错误","参数为空，请初始化参数！");
//				}
//				if (dtNameCode.Rows.Count == 0)
//				{
//					throw new BusinessException("查询错误","参数为空，请初始化参数！");
//				}				
//				
//			}
//			catch (BusinessException bex) //业务异常
//			{		
//				//LogAdapter.WriteBusinessException(bex);
//				throw new BusinessException(bex.Type,bex.Message);		
//			}
//			catch (SqlException sex)   //数据库异常
//			{
//				//事务回滚					
//				//trans.Rollback();												
//				//LogAdapter.WriteDatabaseException(sex);				
//				throw new BusinessException("数据库异常",sex.Message);
//			}
//			catch (Exception ex)		 //其他异常
//			{
//				//事务回滚						
//				//trans.Rollback();						
//				//LogAdapter.WriteFeaturesException(ex);	
//				throw new BusinessException("其它异常",ex.Message);
//			}
//			finally
//			{
//				ConnectionPool.ReturnConnection(conn);
//			}
//			return dtNameCode;
//		}
		public NameCode getMemberParaByID(NameCode nameCode)
		{
			NameCode oldNameCode = null;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				NameCode memberCode = new NameCode();
				memberCode.cnvcCodeID = nameCode.cnvcCodeID;
				oldNameCode = EntityMapping.Get(memberCode,conn) as NameCode;
				
			}
			catch (BusinessException bex) //业务异常
			{		
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
			return oldNameCode;
		}



		public void AddNameCode(NameCode nameCode)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Create(nameCode,trans);				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}

		}

		public void DeleteNameCode(NameCode nameCode)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();				
				trans = conn.BeginTransaction();
				EntityMapping.Delete(nameCode,trans);				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}

		}

		public void ModifyNameCode(NameCode nameCode)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();					
				trans = conn.BeginTransaction();
				EntityMapping.Update(nameCode,trans);				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}

		}

		public void AddMemberCode(MemberCode memberCode)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Create(memberCode,trans);				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}

		}

		public void ModifyMemberCode(MemberCode memberCode)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Update(memberCode,trans);				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}

		}
		public void DeleteMemberCode(MemberCode memberCode)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Delete(memberCode,trans);				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}

		}

		public void getFree(MemberCode memberCode)
		{
			string strFree = "";
			try
			{
				conn = ConnectionPool.BorrowConnection();
				DataTable dtMemberCode = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbMemberCode where cnvcMemberName='"+memberCode.cnvcMemberName+"' and cnvcMemberType = '"+memberCode.cnvcMemberType+"'");
				strFree = dtMemberCode.Rows[0]["cnvcMemberValue"].ToString();
//				trans = conn.BeginTransaction();
//				EntityMapping.Delete(memberCode,trans);				
//				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}

		}
		/// <summary>
		/// 释放展位
		/// </summary>
		/// <param name="memberSeat"></param>
		public void ReleaseSeat(MemberSeat memberSeat)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				DataTable dtShowSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+memberSeat.cnnID.ToString()+" and cnvcFloor='"+memberSeat.cnvcFloor+"' and cnvcSeat='"+memberSeat.cnvcSeat+"'");
				if (dtShowSeat.Rows.Count == 0)
				{
					throw new BusinessException("释放展位","未找到指定展位！");
				}
				ShowSeat ss = new ShowSeat(dtShowSeat);
				if (ss.cnvcState != ConstApp.Show_Seat_State_SignIn)
				{
					throw new BusinessException("释放展位","展位未签到，不能进行释放展位操作！");
				}
				DataTable dtMemberSeat = null;
				if (memberSeat.cnvcMemberCardNo != "")
				{
				
					dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+memberSeat.cnnID.ToString()+" and cnvcFloor='"+memberSeat.cnvcFloor+"' and cnvcSeat='"+memberSeat.cnvcSeat+"' and cnvcState='"+ConstApp.Show_Seat_State_SignIn+"' and cnvcMemberCardNo='"+memberSeat.cnvcMemberCardNo+"'");
				}
				else
				{
					dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+memberSeat.cnnID.ToString()+" and cnvcFloor='"+memberSeat.cnvcFloor+"' and cnvcSeat='"+memberSeat.cnvcSeat+"' and cnvcState='"+ConstApp.Show_Seat_State_SignIn+"' and cnvcPaperNo='"+memberSeat.cnvcPaperNo+"'");
				}
				if (dtMemberSeat.Rows.Count == 0)
				{
					throw new BusinessException("释放展位","未找到使用此展位的会员或非会员");
				}

				MemberSeat ms = new MemberSeat(dtMemberSeat);

				SeqSerialNo serialNo = new SeqSerialNo();
				serialNo.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serialNo,trans);

				//tbShowSeat
				ss.cnvcState = "";
				ss.cndOperDate = memberSeat.cndOperDate;
				ss.cnvcOperName = memberSeat.cnvcOperName;
				EntityMapping.Update(ss,trans);
				ShowSeatLog ssLog = new ShowSeatLog(ss.ToTable());
				ssLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(ssLog,trans);

				//tbMemberSeat
				ms.cnvcState = ConstApp.Show_Seat_State_Release;
				ms.cndOperDate = memberSeat.cndOperDate;
				ms.cnvcOperName = memberSeat.cnvcOperName;
				EntityMapping.Update(ms,trans);
				MemberSeatLog msLog = new MemberSeatLog(ms.ToTable());
				msLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(msLog,trans);

				OperLog operLog = new OperLog(ms.ToTable());
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_Release;
				operLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(operLog,trans);

				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}

		}
		/// <summary>
		/// 换位
		/// </summary>
		/// <param name="memberSeat"></param>
		public void ChangeSeat(MemberSeat memberSeat)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				DataTable dtShowSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+memberSeat.cnnID.ToString()+" and cnvcFloor='"+memberSeat.cnvcFloor+"' and cnvcSeat = '"+memberSeat.cnvcSeat+"'");
				if (dtShowSeat.Rows.Count == 0)
				{
					throw new BusinessException("换位","未找到指定展位");
				}
				if (dtShowSeat.Rows[0]["cnvcState"].ToString() != "")
				{
					if (dtShowSeat.Rows[0]["cnvcState"].ToString() != memberSeat.cnvcOperName)
					{
						throw new BusinessException("换位","展位已被使用");
					}
					
				}
				DataTable dtMemberSeat = null;
				if (memberSeat.cnvcMemberCardNo != "")
				{				
					dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+memberSeat.cnnID.ToString()+" and cnvcFloor='"+memberSeat.cnvcFloor+"' and cnvcMemberCardNo='"+memberSeat.cnvcMemberCardNo+"' and (cnvcState='"+ConstApp.Show_Seat_State_Release+"' or cnvcState='"+ConstApp.Show_Seat_State_SignIn+"')");
				}
				else
				{				
					dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+memberSeat.cnnID.ToString()+" and cnvcFloor='"+memberSeat.cnvcFloor+"' and cnvcPaperNo='"+memberSeat.cnvcPaperNo+"' and cnvcMemberCardNo is null and (cnvcState='"+ConstApp.Show_Seat_State_Release+"'  or cnvcState='"+ConstApp.Show_Seat_State_SignIn+"')");
				}
				if (null == dtMemberSeat)
				{
					throw new BusinessException("换位","数据异常");
				}
				if (dtMemberSeat.Rows.Count == 0)
				{
					throw new BusinessException("换位","请首先签到展位");
				}
				DataRow[] drSignIns = dtMemberSeat.Select("cnvcState = '"+ConstApp.Show_Seat_State_SignIn+"'");
				DataRow[] drNoSignIns = dtMemberSeat.Select("cnvcState = '"+ConstApp.Show_Seat_State_Release+"'");
				if (drNoSignIns.Length == 0)
				{
					throw new BusinessException("换位","请首先释放展位");
				}
				ShowSeat showSeat = new ShowSeat(dtShowSeat);
				showSeat.cnvcState = ConstApp.Show_Seat_State_SignIn;
				showSeat.cnvcOperName = memberSeat.cnvcOperName;
				showSeat.cndOperDate = memberSeat.cndOperDate;
				EntityMapping.Update(showSeat,trans);

				SeqSerialNo serialNo = new SeqSerialNo();
				serialNo.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serialNo,trans);

				ShowSeatLog showSeatLog = new ShowSeatLog(showSeat.ToTable());
				showSeatLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(showSeatLog,trans);

				MemberSeat UpdateMemberSeat = new MemberSeat(drNoSignIns[0]);
				UpdateMemberSeat.cnvcState = ConstApp.Show_Seat_State_No_SignIn;
				UpdateMemberSeat.cnvcOperName = memberSeat.cnvcOperName;
				UpdateMemberSeat.cndOperDate = memberSeat.cndOperDate;
				EntityMapping.Update(UpdateMemberSeat,trans);

				if (memberSeat.cnvcMemberName == "")
				{
					memberSeat.cnvcMemberName = UpdateMemberSeat.cnvcMemberName;
				}
				if (memberSeat.cnvcPaperNo == "")
				{
					memberSeat.cnvcPaperNo = UpdateMemberSeat.cnvcPaperNo;
				}
				memberSeat.cnvcState = ConstApp.Show_Seat_State_SignIn;
				EntityMapping.Create(memberSeat,trans);

				MemberSeatLog memberSeatLog = new MemberSeatLog(memberSeat.ToTable());
				memberSeatLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(memberSeatLog,trans);

				OperLog operLog = new OperLog(memberSeat.ToTable());
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_ChangeSeat;
				operLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(operLog,trans);

				trans.Commit();
				
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}

		}

		public void InfoWayAudit(string strMemberSeatID)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				string[] strIDs = strMemberSeatID.Split(',');
				foreach (string strID in strIDs)
				{
					if (strID!="")
					{
						string[] strInfoWay = strID.Split('|');
						SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMemberSeat set cnvcAudit='"+ConstApp.IsAudit+"' ,cnvcInfoWay='"+strInfoWay[1]+"' where cnvcMemberSeatID="+strInfoWay[0]);
					}
					
				}

				trans.Commit();
				
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
		}
			public void InfoWayModify(string strMemberSeatID)
			{
				try
				{
					conn = ConnectionPool.BorrowConnection();
					trans = conn.BeginTransaction();
					string[] strIDs = strMemberSeatID.Split(',');
					foreach (string strID in strIDs)
					{
						if (strID!="")
						{
							string[] strInfoWay = strID.Split('|');
							SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMemberSeat set cnvcInfoWay='"+strInfoWay[1]+"' where cnvcMemberSeatID="+strInfoWay[0]);
						}
					
					}

					trans.Commit();
				
				}
				catch (BusinessException bex) //业务异常
				{		
					//事务回滚					
					trans.Rollback();	
					//LogAdapter.WriteBusinessException(bex);
					throw new BusinessException(bex.Type,bex.Message);		
				}
				catch (SqlException sex)   //数据库异常
				{
					//事务回滚					
					trans.Rollback();												
					//LogAdapter.WriteDatabaseException(sex);				
					throw new BusinessException("数据库异常",sex.Message);
				}
				catch (Exception ex)		 //其他异常
				{
					//事务回滚						
					trans.Rollback();						
					//LogAdapter.WriteFeaturesException(ex);	
					throw new BusinessException("其它异常",ex.Message);
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}

		}
		public void CustomerServiceModify(string strMemberCardNo)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				string[] strIDs = strMemberCardNo.Split(',');
				foreach (string strID in strIDs)
				{
					if (strID!="")
					{
						string[] strCustomerService = strID.Split('|');
						SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcCustomerService='"+strCustomerService[1]+"' where cnvcMemberCardNo='"+strCustomerService[0]+"'");
					}
					
				}

				trans.Commit();
				
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}

		}

		public void CustomerServiceReportModify(string strMemberCardNos)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				string[] strIDs = strMemberCardNos.Split(',');
				int i = 0;
				foreach (string strID in strIDs)
				{
					if (strID!="")
					{
						string[] strTemp = strID.Split('|');
						string strMemberCardNo = strTemp[0];
						string strEmail = strTemp[1];
						string strFax = strTemp[2];
						string strMobileTelephone = strTemp[3];
						string strPostalCode = strTemp[4];
						string strCustomerService = strTemp[5];
						if(strMemberCardNo != "")
						{
							if(strEmail != "")
							{
								i+=SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcEmail='"+strEmail+"' where cnvcMemberCardNo='"+strMemberCardNo+"'");
							}
							if(strFax != "")
							{
								i+=SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcFax='"+strFax+"' where cnvcMemberCardNo='"+strMemberCardNo+"'");
							}
							if(strMobileTelephone!="")
							{
								i+=SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcMobileTelephone='"+strMobileTelephone+"' where cnvcMemberCardNo='"+strMemberCardNo+"'");
							}
							if(strPostalCode != "")
							{
								i+=SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcPostalCode='"+strPostalCode+"' where cnvcMemberCardNo='"+strMemberCardNo+"'");
							}
							if(strCustomerService != "")
							{
								i+=SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcCustomerService='"+strCustomerService+"' where cnvcMemberCardNo='"+strMemberCardNo+"'");
							}
						}
						
					}
					
				}
				if(i==0)
					throw new Exception("没有修改记录");
				trans.Commit();
				
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("其它异常",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}

		}

		public void FreeModify(string strMemberCardNo)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				string[] strIDs = strMemberCardNo.Split(',');
				foreach (string strID in strIDs)
				{
					if (strID!="")
					{
						string[] strFree = strID.Split('|');
						SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcFree='"+strFree[1]+"' where cnvcMemberCardNo='"+strFree[0]+"'");
					}
					
				}

				trans.Commit();
				
			}
			catch (BusinessException bex) //业务异常
			{		
				//事务回滚					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //数据库异常
			{
				//事务回滚					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("数据库异常",sex.Message);
			}
			catch (Exception ex)		 //其他异常
			{
				//事务回滚						
				trans.Rollback();						
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
