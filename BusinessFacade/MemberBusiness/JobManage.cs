
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	SecurityManage.cs
* 作者:	     郑华
* 创建日期:    2007-12-10
* 功能描述:    安全管理业务

*                                                           Copyright(C) 2007 zhenghua
*************************************************************************************/
using System;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Windows;
using System.Windows.Forms;
using ynhrMemberManage.Print;
using ynhrMemberManage.Common;

namespace ynhrMemberManage.BusinessFacade.MemberBusiness
{
	/// <summary>
	/// Summary description for JobManage.
	/// </summary>
	public class JobManage
	{
		public JobManage()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// 当前数据库事务
		/// </summary>
		private SqlTransaction trans = null;
		/// <summary>
		/// 当前数据库连接
		/// </summary>
		private SqlConnection conn = null;

		/// <summary>
		/// 添加招聘会
		/// </summary>
		/// <param name="job"></param>
		/// 
		#region
		public void AddJob (Job job)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				//操作流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				//招聘会流水
				JobSerialNo JobSerial = new JobSerialNo();
				JobSerial.cnvcFill = "0";
				int iSerialNo = (int)EntityMapping.Create(JobSerial,trans);

				job.cnnJobID = iSerialNo;
				EntityMapping.Create(job,trans);

				JobLog jobLog = new JobLog(job.ToTable());
				jobLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(jobLog,trans);

				OperLog operLog = new OperLog(job.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_AddJob;
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

		#region 展厅
		#region 添加展厅
		public void AddShow (Show show)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				//操作流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				//展厅流水
				ShowSerialNo showSerial = new ShowSerialNo();
				showSerial.cnvcFill = "0";
				int iSerialNo = (int)EntityMapping.Create(showSerial,trans);

				show.cnnShowID = iSerialNo;
				EntityMapping.Create(show,trans);

				ShowLog showLog = new ShowLog(show.ToTable());
				showLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(showLog,trans);

				OperLog operLog = new OperLog(show.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_AddShow;
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
		#endregion
		#region 保存展位方案
		public void SaveShowPlan (Panel pl,string strJobID,string strJobName,string strOperName,DateTime dtOperDate)
		{
			//保存展位方案
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				//操作流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				string strShowName = pl.Name.Substring(5);
				DataTable dtShow = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShow where cnnJobID="+strJobID+" and cnvcShowName = '"+strShowName+"'");				
				Show show = null;
				if (dtShow.Rows.Count > 0)
				{
					show = new Show(dtShow);
					show.cnnX = pl.Left;
					show.cnnY = pl.Top;
					show.cnnHeight = pl.Height;
					show.cnnWeight = pl.Width;
					show.cndOperDate = dtOperDate;
					show.cnvcOperName = strOperName;
					show.cnvcShowName = strShowName;
					EntityMapping.Update(show,trans);
				
				}
				else
				{
					show = new Show();
					show.cnnX = pl.Left;
					show.cnnY = pl.Top;
					show.cnnHeight = pl.Height;
					show.cnnWeight = pl.Width;
					show.cndOperDate = dtOperDate;
					show.cnvcOperName = strOperName;
					show.cnvcShowName = strShowName;

					//展厅流水
					ShowSerialNo showSerial = new ShowSerialNo();
					showSerial.cnvcFill = "0";
					int iSerialNo = (int)EntityMapping.Create(showSerial,trans);

					show.cnnShowID = iSerialNo;
					show.cnnJobID = int.Parse(strJobID);

					EntityMapping.Create(show,trans);

				}
				//展厅日志
				ShowLog showLog = new ShowLog(show.ToTable());
				showLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(showLog,trans);

				DataTable dtShowSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+strJobID+" and cnvcFloor = '"+show.cnnShowID.ToString()+"'");
				
				Hashtable htShowSeat = new Hashtable();
				for(int i = 0; i < pl.Controls.Count; i++)
				{
					Control ctrl = pl.Controls[i];
					ShowSeat seat = new ShowSeat();
					seat.cnnJobID = int.Parse(strJobID);
					seat.cnvcJobName = strJobName;
					seat.cnnX = ctrl.Left;
					seat.cnnY = ctrl.Top;
					seat.cnnHeight = ctrl.Height;
					seat.cnnWidth = ctrl.Width;
					seat.cnvcDirection = Helper.getlblDirection(ctrl as zhhLabel);
					if (Helper.IsNumber(ctrl.Text))
					{
						seat.cnvcSeat = ctrl.Text;
					}
					seat.cnvcControlName = ctrl.Name.Substring(3);
					seat.cnvcFloor = show.cnnShowID.ToString();
					seat.cnvcOperName = strOperName;
					seat.cndOperDate = dtOperDate;

					ShowSeat oldSeat = EntityMapping.Get(seat,trans) as ShowSeat;
					if (null == oldSeat)
					{
						EntityMapping.Create(seat,trans);
					}
					else
					{
						EntityMapping.Update(seat,trans);
					}
					htShowSeat.Add(seat.cnvcControlName,seat);
					
				}

				if (dtShowSeat.Rows.Count > 0)
				{
					foreach (DataRow drShowSeat in dtShowSeat.Rows)
					{
						ShowSeat OldSeat = new ShowSeat(drShowSeat);
						if (!htShowSeat.ContainsKey(OldSeat.cnvcControlName))
						{
							if (OldSeat.cnvcState.Length == 0)
							{
								EntityMapping.Delete(OldSeat,trans);
							}
							
						}
					}
				}
				


				OperLog operLog = new OperLog(show.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_SaveShowPlan;
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

		public void DeleteShowSeat(string strJobID,string strShowID,string strOperName ,DateTime dtOperDate)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();

				//操作流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				Show show = new Show();
				show.cnnShowID = int.Parse(strShowID);
				show = EntityMapping.Get(show,trans) as Show;
				if (show != null)
				{
					EntityMapping.Delete(show,trans);
					ShowLog showLog = new ShowLog(show.ToTable());
					showLog.cnvcOperName = strOperName;
					showLog.cndOperDate = dtOperDate;
					showLog.cnnSerialNo = dSerialNo;
					EntityMapping.Create(showLog,trans);
				}

				DataTable dtShowSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+strJobID+" and cnvcFloor='"+strShowID+"'");
				if (dtShowSeat.Rows.Count > 0)
				{
					foreach (DataRow drShowSeat in dtShowSeat.Rows)
					{
						ShowSeat seat = new ShowSeat(drShowSeat);
						EntityMapping.Delete(seat,trans);
					}
				}

				OperLog operLog = new OperLog();
				operLog.cnvcOperName = strOperName;
				operLog.cndOperDate = dtOperDate;
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_DeleteShowPlan;
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
		public void ModifyJob (Job job)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();

				//操作流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				Job oldJob = EntityMapping.Get(job,trans) as Job;
				if (null == oldJob)
				{
					throw new BusinessException("招聘会信息修改","未找到招聘会！");
				}
				oldJob.cndBeginDate = job.cndBeginDate;
				oldJob.cndBookBeginDate = job.cndBookBeginDate;
				oldJob.cndBookEndDate = job.cndBookEndDate;
				oldJob.cndEndDate = job.cndEndDate;
				oldJob.cndOperDate = job.cndOperDate;
				oldJob.cnvcJobName = job.cnvcJobName;
				oldJob.cnvcJobTheme = job.cnvcJobTheme;
				oldJob.cnvcOperName = job.cnvcOperName;
				EntityMapping.Update(oldJob,trans);
				

				JobLog jobLog = new JobLog(job.ToTable());
				jobLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(jobLog,trans);

				OperLog operLog = new OperLog(jobLog.ToTable());
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_ModifyJob;
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


		public void EndJob (Job job)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				DataTable dtShowSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnID = "+job.cnnJobID);
				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID = "+job.cnnJobID);

				foreach (DataRow drShowSeat in dtShowSeat.Rows)
				{
					ShowSeatHis showSeatHis = new ShowSeatHis(drShowSeat);
					//showSeatHis.cnvcEndDate = job.cnvcJobCycleEnd;
					EntityMapping.Create(showSeatHis,trans);

					ShowSeat showSeat = new ShowSeat(drShowSeat);
					EntityMapping.Delete(showSeat,trans);
				}
				foreach (DataRow drMemberSeat in dtMemberSeat.Rows)
				{
					MemberSeatHis memberSeatHis = new MemberSeatHis(drMemberSeat);
					//memberSeatHis.cnvcEndDate = job.cnvcJobCycleEnd;
					EntityMapping.Create(memberSeatHis,trans);

					MemberSeat memberSeat = new MemberSeat(drMemberSeat);
					EntityMapping.Delete(memberSeat,trans);
				}
				//EntityMapping.Update(job,trans);

				trans.Commit();
				//				CardM1 m1 = new CardM1();
				//				string strReturn = m1.PutOutCard(member.cnvcMemberCardNo,-1,-1);
				//				if (strReturn.Equals("OPSUCCESS"))
				//				{
				//					trans.Commit();
				//				}
				//				else
				//				{
				//					throw new BusinessException("卡操作异常",strReturn);
				//				}
				
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

        public Job GetJobByID(Job job)
        {
            return EntityMapping.Get(job) as Job;
        }

        public DataTable GetSomeJob(Job job)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "select cnnID as 招聘会ID,cnvcJobName as  招聘会名称,cnvcJobTheme as  招聘会主题,cndBeginDate as 招聘会开始时间, cndEndDate as 招聘会结束时间, cndBookBeginDate as 预订开始时间,cndBookEndDate as 预订结束时间 from tbJob where cnvcJobName like '%" + job.cnvcJobName + "%'");
        }

        public DataTable GetAllJob()
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbJob");
        }

        public DataTable GetAll2DefaultSeat(string strID)
        {
            DataTable dtSeat = null;

            dtSeat = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbShowSeat where cnnID=" + strID + " and cnvcFloor='2'");
            if (dtSeat.Rows.Count == 0)
            {
                dtSeat = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbDefaultShowSeat where cnvcFloor='2'");
            }
            return dtSeat;
        }
        public DataTable GetAll3DefaultSeat(string strID)
        {
            DataTable dtSeat = null;

            dtSeat = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbShowSeat where cnnID=" + strID + " and cnvcFloor='3'");
            if (dtSeat.Rows.Count == 0)
            {
                dtSeat = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbDefaultShowSeat where cnvcFloor='3'");
            }
            return dtSeat;
        }
		public void AddSeat (ShowSeat seat)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				ShowSeat oldSeat = EntityMapping.Get(seat,trans) as ShowSeat;
				if (null != oldSeat)
				{
					EntityMapping.Update(seat,trans);
				}
				else
				{
					EntityMapping.Create(seat,trans);
				}
				
				trans.Commit();
				//				CardM1 m1 = new CardM1();
				//				string strReturn = m1.PutOutCard(member.cnvcMemberCardNo,-1,-1);
				//				if (strReturn.Equals("OPSUCCESS"))
				//				{
				//					trans.Commit();
				//				}
				//				else
				//				{
				//					throw new BusinessException("卡操作异常",strReturn);
				//				}
				
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

        public DataTable GetAllSeat(Job job)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "select cnvcSeat as 展位,cnvcState as 状态 from tbShowSeat where cnnID = " + job.cnnJobID + " and cnvcSeat is not null order by cnvcSeat");

        }

        public DataTable GetFloorSeat(ShowSeat seat)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbShowSeat where cnnID = " + seat.cnnJobID + " and cnvcFloor = '" + seat.cnvcFloor + "'");
        }


		public void AddLeaveSeat (ShowSeat seat)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbShowSeat set cnvcState = '预留' where cnnID="+seat.cnnJobID+" and cnvcSeat = '"+seat.cnvcSeat+"'");				
				
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

		public void CancelLeaveSeat (ShowSeat seat)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbShowSeat set cnvcState = null where cnnID="+seat.cnnJobID+" and cnvcSeat = '"+seat.cnvcSeat+"'");				
				
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
		/// 会员展位预订
		/// </summary>
		/// <param name="seat"></param>
		public void MemberSeatBooking (MemberSeat seat,PrintedBill pBill)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				
				trans = conn.BeginTransaction();

				DataTable dtSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+seat.cnnID+" and cnvcSeat = '"+seat.cnvcSeat+"' and cnvcFloor = '"+seat.cnvcFloor+"'");
				ShowSeat oldSeat = new ShowSeat(dtSeat);
				if (oldSeat.cnvcState.Length > 0)
				{
					if (oldSeat.cnvcState != seat.cnvcOperName)
					{
						throw new BusinessException("展位预订","此展位已被使用");
					}
					
				}
				oldSeat.cnvcState = ConstApp.Show_Seat_State_Booking;
				oldSeat.cnvcOperName = seat.cnvcOperName;
				oldSeat.cndOperDate = seat.cndOperDate;                
				EntityMapping.Update(oldSeat,trans);

				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				Decimal dSerialNo = EntityMapping.Create(serial,trans);

				ShowSeatLog showSeatLog = new ShowSeatLog(oldSeat.ToTable());
				showSeatLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(showSeatLog,trans);

				EntityMapping.Create(seat,trans);

				MemberSeatLog memberSeatLog = new MemberSeatLog(seat.ToTable());
				memberSeatLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(memberSeatLog,trans);

				OperLog operLog = new OperLog(seat.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				if (operLog.cnvcOperName == operLog.cnvcMemberCardNo)
				{
					operLog.cniSynch = 2;
				}
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_MemberSeatBooking;
				EntityMapping.Create(operLog,trans);

				Bill bill = new Bill(pBill.ToTable());
				//bill.cnvcBillType = ConstApp.Bill_Type_SignIn;
				bill.cnnRepeats = 0;
				//bill.cnvcSeat = retMember.cnvcSales;
				bill.cndOperDate = DateTime.Now;
				//bill.cnvcMemberName = oldMember.cnvcMemberName;
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

		public void MemberSeatBooking (MemberSeat seat)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				
				trans = conn.BeginTransaction();

				DataTable dtSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+seat.cnnID+" and cnvcSeat = '"+seat.cnvcSeat+"' and cnvcFloor = '"+seat.cnvcFloor+"'");
				ShowSeat oldSeat = new ShowSeat(dtSeat);
				if (oldSeat.cnvcState.Length > 0)
				{
					if (oldSeat.cnvcState != seat.cnvcOperName)
					{
						throw new BusinessException("展位预订","此展位已被使用");
					}
					
				}
				oldSeat.cnvcState = ConstApp.Show_Seat_State_Booking;
				oldSeat.cnvcOperName = seat.cnvcOperName;
				oldSeat.cndOperDate = seat.cndOperDate;
				EntityMapping.Update(oldSeat,trans);

				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				Decimal dSerialNo = EntityMapping.Create(serial,trans);

				ShowSeatLog showSeatLog = new ShowSeatLog(oldSeat.ToTable());
				showSeatLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(showSeatLog,trans);

				EntityMapping.Create(seat,trans);

				MemberSeatLog memberSeatLog = new MemberSeatLog(seat.ToTable());
				memberSeatLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(memberSeatLog,trans);

				OperLog operLog = new OperLog(seat.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				if (operLog.cnvcOperName == operLog.cnvcMemberCardNo)
				{
					operLog.cniSynch = 2;
				}
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_MemberSeatBooking;
				EntityMapping.Create(operLog,trans);

//				Bill bill = new Bill(pBill.ToTable());
//				//bill.cnvcBillType = ConstApp.Bill_Type_SignIn;
//				bill.cnnRepeats = 0;
//				//bill.cnvcSeat = retMember.cnvcSales;
//				bill.cndOperDate = DateTime.Now;
//				//bill.cnvcMemberName = oldMember.cnvcMemberName;
//				EntityMapping.Create(bill,trans);
				
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
		/// 会员取消展位预订
		/// </summary>
		/// <param name="seat"></param>
		/// 
		#region
		public void CancelMemberSeatBooking (MemberSeat seat)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();				
				trans = conn.BeginTransaction();
				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnvcMemberCardNo='"+seat.cnvcMemberCardNo+"' and cnnID="+seat.cnnID+" and cnvcSeat='"+seat.cnvcSeat+"' and cnvcFloor='"+seat.cnvcFloor+"' and cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
//				if (dtMemberSeat.Rows.Count == 0)
//				{
//					throw new BusinessException("展位取消预订","未预订此展位"+seat.cnvcSeat);
//				}
				MemberSeat oldMemberSeat = new MemberSeat(dtMemberSeat);
				oldMemberSeat.cnvcOperName = seat.cnvcOperName;
				oldMemberSeat.cndOperDate = seat.cndOperDate;
				SingleCancelMemberSeatBooking(trans,oldMemberSeat);
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
		public void CancelSeatBooking (MemberSeat seat)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();				
				trans = conn.BeginTransaction();
				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcSeat='"+seat.cnvcSeat+"' and cnvcFloor='"+seat.cnvcFloor+"' and cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
				MemberSeat oldMemberSeat = new MemberSeat(dtMemberSeat);
				oldMemberSeat.cnvcOperName = seat.cnvcOperName;
				oldMemberSeat.cndOperDate = seat.cndOperDate;
				SingleCancelMemberSeatBooking(trans,oldMemberSeat);
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
		public void CancelMemberSeatBooking (MemberSeat seat,string strBatch)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();				
				trans = conn.BeginTransaction();
				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnvcMemberCardNo='"+seat.cnvcMemberCardNo+"' and cnnID="+seat.cnnID+" and cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
//				if (dtMemberSeat.Rows.Count == 0)
//				{
//					throw new BusinessException("展位取消预订","未预订展位");
//				}
				foreach (DataRow drMemberSeat in dtMemberSeat.Rows)
				{
					MemberSeat oldMemberSeat = new MemberSeat(drMemberSeat);
					oldMemberSeat.cnvcOperName = seat.cnvcOperName;
					oldMemberSeat.cndOperDate = seat.cndOperDate;
					SingleCancelMemberSeatBooking(trans,oldMemberSeat);
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

		public void CancelSeatBooking (MemberSeat seat,string strBatch)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();				
				trans = conn.BeginTransaction();
				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
				//				if (dtMemberSeat.Rows.Count == 0)
				//				{
				//					throw new BusinessException("展位取消预订","未预订展位");
				//				}
				foreach (DataRow drMemberSeat in dtMemberSeat.Rows)
				{
					MemberSeat oldMemberSeat = new MemberSeat(drMemberSeat);
					oldMemberSeat.cnvcOperName = seat.cnvcOperName;
					oldMemberSeat.cndOperDate = seat.cndOperDate;
					SingleCancelMemberSeatBooking(trans,oldMemberSeat);
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


		private void SingleCancelMemberSeatBooking(SqlTransaction trans,MemberSeat seat)
		{
			
			MemberSeat oldSeat = new MemberSeat(seat.ToTable());
			oldSeat.cnvcState = ConstApp.Show_Seat_State_No_Booking;
			oldSeat.cnvcOperName = seat.cnvcOperName;
			oldSeat.cndOperDate = seat.cndOperDate;
			EntityMapping.Update(oldSeat,trans);

			SeqSerialNo serial = new SeqSerialNo();
			serial.cnvcFill = "0";
			Decimal dSeralNo = EntityMapping.Create(serial,trans);

			MemberSeatLog oldSeatLog = new MemberSeatLog(oldSeat.ToTable());
			oldSeatLog.cnnSerialNo = dSeralNo;
			EntityMapping.Create(oldSeatLog,trans);

			DataTable dtShowSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+seat.cnnID+" and cnvcSeat = '"+seat.cnvcSeat+"' and cnvcFloor='"+seat.cnvcFloor+"'");									
//			if (dtShowSeat.Rows.Count == 0)
//			{
//				throw new BusinessException("展位预订","未预订此展位"+seat.cnvcSeat);
//			}
			ShowSeat oldShowSeat = new ShowSeat(dtShowSeat);
			oldShowSeat.cnvcState = "";
			oldShowSeat.cnvcOperName = seat.cnvcOperName;
			oldShowSeat.cndOperDate = seat.cndOperDate;
			EntityMapping.Update(oldShowSeat,trans);

			ShowSeatLog oldShowSeatLog = new ShowSeatLog(oldShowSeat.ToTable());
			oldShowSeatLog.cnnSerialNo = dSeralNo;
			EntityMapping.Create(oldShowSeatLog,trans);

			OperLog operLog = new OperLog(oldSeat.ToTable());
			operLog.cnnSerialNo = dSeralNo;
			operLog.cnvcOperFlag = ConstApp.Oper_Flag_CancelMemberSeatBooking;
			EntityMapping.Create(operLog,trans);
		}
		#endregion
		public void HoldSeat (ShowSeat seat)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();				
				trans = conn.BeginTransaction();									

				DataTable dtShowSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+seat.cnnJobID+" and cnvcSeat = '"+seat.cnvcSeat+"' and cnvcFloor='"+seat.cnvcFloor+"'");									
				if (dtShowSeat.Rows.Count > 0)
				{

					

					ShowSeat oldShowSeat = new ShowSeat(dtShowSeat);
					if (oldShowSeat.cnvcState.Length > 0)
					{
						throw new BusinessException("展位预订","占位失败，此展位已被使用");
					}
					oldShowSeat.cnvcState = seat.cnvcOperName;
					oldShowSeat.cnvcOperName = seat.cnvcOperName;
					oldShowSeat.cndOperDate = seat.cndOperDate;
                    oldShowSeat.cniSynch = 0;
					EntityMapping.Update(oldShowSeat,trans);

					SeqSerialNo serial = new SeqSerialNo();
					serial.cnvcFill = "0";
					Decimal dSeralNo = EntityMapping.Create(serial,trans);		

					ShowSeatLog oldShowSeatLog = new ShowSeatLog(oldShowSeat.ToTable());
					oldShowSeatLog.cnnSerialNo = dSeralNo;
					EntityMapping.Create(oldShowSeatLog,trans);

					OperLog operLog = new OperLog(oldShowSeat.ToTable());
					operLog.cnnSerialNo = dSeralNo;
					operLog.cnvcOperFlag = ConstApp.Oper_Flag_HoldSeat;
					EntityMapping.Create(operLog,trans);
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

		/// <summary>
		/// 非会员展位预订
		/// </summary>
		/// <param name="seat"></param>
		/// 
		#region
		public void NoMemberSeatBooking (MemberSeat seat,PrintedBill pBill)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				
				trans = conn.BeginTransaction();
				DataTable dtSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+seat.cnnID+" and cnvcSeat = '"+seat.cnvcSeat+"' and cnvcFloor = '"+seat.cnvcFloor+"'");
				ShowSeat oldSeat = new ShowSeat(dtSeat);
				if (oldSeat.cnvcState.Length > 0)
				{
					if (oldSeat.cnvcState != seat.cnvcOperName)
					{
						throw new BusinessException("展位预订","此展位已被使用");
					}
					
				}
				oldSeat.cnvcState = ConstApp.Show_Seat_State_Booking;
				oldSeat.cnvcOperName = seat.cnvcOperName;
				oldSeat.cndOperDate = seat.cndOperDate;
				EntityMapping.Update(oldSeat,trans);

				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				Decimal dSerialNo = EntityMapping.Create(serial,trans);

				ShowSeatLog showSeatLog = new ShowSeatLog(oldSeat.ToTable());
				showSeatLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(showSeatLog,trans);

				EntityMapping.Create(seat,trans);

				MemberSeatLog memberSeatLog = new MemberSeatLog(seat.ToTable());
				memberSeatLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(memberSeatLog,trans);

				OperLog operLog = new OperLog(seat.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_FMemberSeatBooking;
				EntityMapping.Create(operLog,trans);

				Bill bill = new Bill(pBill.ToTable());
				//bill.cnvcBillType = ConstApp.Bill_Type_SignIn;
				bill.cnnRepeats = 0;
				//bill.cnvcSeat = retMember.cnvcSales;
				bill.cndOperDate = DateTime.Now;
				//bill.cnvcMemberName = oldMember.cnvcMemberName;
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
		/// <summary>
		/// 非会员展位取消预订
		/// </summary>
		/// <param name="seat"></param>
		public void CancelNoMemberSeatBooking (MemberSeat seat)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();				
				trans = conn.BeginTransaction();
				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnvcMemberCardNo is null and cnvcPaperNo='"+seat.cnvcPaperNo+"' and cnnID="+seat.cnnID+" and cnvcSeat='"+seat.cnvcSeat+"' and cnvcFloor='"+seat.cnvcFloor+"' and cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");//"select * from tbMemberSeat where cnvcMemberCardNo is null and cnvcPaperNo='"+seat.cnvcPaperNo+"' and cnnID="+seat.cnnID+" and cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
//				if (dtMemberSeat.Rows.Count == 0)
//				{
//					throw new BusinessException("非会员取消展位预订","未预订展位");
//				}
				MemberSeat oldMemberSeat = new MemberSeat(dtMemberSeat);
				oldMemberSeat.cnvcOperName = seat.cnvcOperName;
				oldMemberSeat.cndOperDate = seat.cndOperDate;
				SingleCancelFMemberbook(trans,oldMemberSeat);
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
		public void CancelNoMemberSeatBooking (MemberSeat seat,string strBatch)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();				
				trans = conn.BeginTransaction();
				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnvcMemberCardNo is null and cnvcPaperNo='"+seat.cnvcPaperNo+"' and cnnID="+seat.cnnID+" and cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
//				if (dtMemberSeat.Rows.Count == 0)
//				{
//					throw new BusinessException("非会员取消展位预订","未预订展位");
//				}
				foreach (DataRow drMemberSeat in dtMemberSeat.Rows)
				{
					MemberSeat oldMemberSeat = new MemberSeat(drMemberSeat);
					oldMemberSeat.cnvcOperName = seat.cnvcOperName;
					oldMemberSeat.cndOperDate = seat.cndOperDate;
					SingleCancelFMemberbook(trans,oldMemberSeat);
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
		private void SingleCancelFMemberbook(SqlTransaction trans,MemberSeat seat)
		{
			MemberSeat oldSeat = new MemberSeat(seat.ToTable());
			oldSeat.cnvcState = ConstApp.Show_Seat_State_No_Booking;
			oldSeat.cnvcOperName = seat.cnvcOperName;
			oldSeat.cndOperDate = seat.cndOperDate;
			EntityMapping.Update(oldSeat,trans);

			SeqSerialNo serial = new SeqSerialNo();
			serial.cnvcFill = "0";
			Decimal dSeralNo = EntityMapping.Create(serial,trans);

			MemberSeatLog oldSeatLog = new MemberSeatLog(oldSeat.ToTable());
			oldSeatLog.cnnSerialNo = dSeralNo;
			EntityMapping.Create(oldSeatLog,trans);

			DataTable dtShowSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+seat.cnnID+" and cnvcSeat = '"+seat.cnvcSeat+"' and cnvcFloor='"+seat.cnvcFloor+"'");									
//			if (dtShowSeat.Rows.Count == 0)
//			{
//				throw new BusinessException("展位预订","未预订此展位"+seat.cnvcSeat);
//			}
			ShowSeat oldShowSeat = new ShowSeat(dtShowSeat);
			oldShowSeat.cnvcState = "";
			oldShowSeat.cnvcOperName = seat.cnvcOperName;
			oldShowSeat.cndOperDate = seat.cndOperDate;
			EntityMapping.Update(oldShowSeat,trans);

			ShowSeatLog oldShowSeatLog = new ShowSeatLog(oldShowSeat.ToTable());
			oldShowSeatLog.cnnSerialNo = dSeralNo;
			EntityMapping.Create(oldShowSeatLog,trans);
			

			OperLog operLog = new OperLog(oldSeat.ToTable());
			operLog.cnnSerialNo = dSeralNo;
			operLog.cnvcOperFlag = ConstApp.Oper_Flag_CancelFMemberSeatBooking;
			EntityMapping.Create(operLog,trans);
		}
		/// <summary>
		/// 按座位展位取消预订
		/// </summary>
		/// <param name="seat"></param>
		public void cCancelSeatBooking (MemberSeat seat)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();				
				trans = conn.BeginTransaction();
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbShowSeat set cnvcState = null where cnnID="+seat.cnnID+" and cnvcSeat = '"+seat.cnvcSeat+"'");									
				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select *  from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcSeat = '"+seat.cnvcSeat+"' and cnvcState = '"+ConstApp.Show_Seat_State_Booking+"'");
				if (dtMemberSeat.Rows.Count == 0)
				{
					throw new BusinessException("取消展位预订","此展位不在预订状态！");
				}
				MemberSeat memberSeat = new MemberSeat(dtMemberSeat);
				string strUpdateSql = "update tbMemberSeat set cnvcState = '"+ConstApp.Show_Seat_State_No_Booking +"',cnvcOperName='"+seat.cnvcOperName+"',cndOperDate=getdate() where cnnID="+seat.cnnID+" and cnvcSeat = '"+seat.cnvcSeat+"'";				
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,strUpdateSql);
				string strUpdateSql2 = "update tbPrepay set cnvcState = '"+ConstApp.Show_Seat_State_No_Booking+"' where cnnJobID="+seat.cnnID+" and cnvcState = '"+ConstApp.Show_Seat_State_Booking+"' and cnvcPaperNo='"+memberSeat.cnvcPaperNo+"'";
				if (memberSeat.cnvcMemberCardNo != "")
				{
					strUpdateSql += " and cnvcMemberCardNo='"+memberSeat.cnvcMemberCardNo+"'";
				}				
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,strUpdateSql2);					
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
		/// 缴费
		/// </summary>
		/// <param name="prepay"></param>
		/// <param name="member"></param>
		public void AddPrepay (FMember fmember)
		{
            try
            {
                conn = ConnectionPool.BorrowConnection();
                trans = conn.BeginTransaction();
                SeqSerialNo serial = new SeqSerialNo();
                serial.cnvcFill = "0";
                Decimal dSerialNo = EntityMapping.Create(serial, trans);

                FMember oldmember = EntityMapping.Get(fmember, trans) as FMember;
                if (oldmember == null) throw new BusinessException("非会员充值", "未找到非会员信息");

                decimal dlastbalance = oldmember.cnnPrepay;
                oldmember.cnnPrepay = fmember.cnnPrepay + oldmember.cnnPrepay;
                EntityMapping.Update(oldmember, trans);

                FMemberPrepayLog pl = new FMemberPrepayLog(fmember.ToTable());
                pl.cnnSerialNo = dSerialNo;
                pl.cnvcOperFlag = ConstApp.Fee_Flag_InMoney;
                pl.cnnLastBalance = dlastbalance;
                pl.cnnBalance = oldmember.cnnPrepay;
                EntityMapping.Create(pl, trans);


                OperLog operLog = new OperLog(fmember.ToTable());
                operLog.cnnSerialNo = dSerialNo;
                operLog.cnvcOperFlag = ConstApp.Oper_Flag_AddPrepay;
                EntityMapping.Create(operLog, trans);

                Bill bill = new Bill(fmember.ToTable());
                bill.cnvcMemberName = fmember.cnvcMemberName;
                bill.cnvcBillType = ConstApp.Bill_Type_AddPrepay;
                bill.cnnRepeats = 0;
                EntityMapping.Create(bill, trans);

                trans.Commit();

            }
            catch (BusinessException bex) //业务异常
            {
                //事务回滚					
                trans.Rollback();
                //LogAdapter.WriteBusinessException(bex);
                throw new BusinessException(bex.Type, bex.Message);
            }
            catch (SqlException sex)   //数据库异常
            {
                //事务回滚					
                trans.Rollback();
                //LogAdapter.WriteDatabaseException(sex);				
                throw new BusinessException("数据库异常", sex.Message);
            }
            catch (Exception ex)		 //其他异常
            {
                //事务回滚						
                trans.Rollback();
                //LogAdapter.WriteFeaturesException(ex);	
                throw new BusinessException("其它异常", ex.Message);
            }
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}

		/// <summary>
		/// 展位预留
		/// </summary>
		/// <param name="seat"></param>
		/// 
		#region
		public void SeatRemain (ShowSeat seat)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				
				trans = conn.BeginTransaction();

				DataTable dtSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+seat.cnnJobID+" and cnvcSeat = '"+seat.cnvcSeat+"' and cnvcFloor = '"+seat.cnvcFloor+"'");
				ShowSeat oldSeat = new ShowSeat(dtSeat);
				if (oldSeat.cnvcState.Length > 0)
				{
					if (oldSeat.cnvcState != seat.cnvcOperName)
					{
						throw new BusinessException("展位预留","此展位已被使用");
					}
					
				}
				oldSeat.cnvcState = ConstApp.Show_Seat_State_Remain;
				oldSeat.cnvcOperName = seat.cnvcOperName;
				oldSeat.cndOperDate = seat.cndOperDate;
				EntityMapping.Update(oldSeat,trans);

				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				Decimal dSerialNo = EntityMapping.Create(serial,trans);

				ShowSeatLog showSeatLog = new ShowSeatLog(oldSeat.ToTable());
				showSeatLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(showSeatLog,trans);


				OperLog operLog = new OperLog(seat.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_MemberSeatRemain;
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
		/// 取消展位预留
		/// </summary>
		/// <param name="seat"></param>
		/// 
		#region
		public void CancelSeatRemain (ShowSeat seat)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				
				trans = conn.BeginTransaction();

				DataTable dtSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+seat.cnnJobID+" and cnvcSeat = '"+seat.cnvcSeat+"' and cnvcFloor = '"+seat.cnvcFloor+"'");
				ShowSeat oldSeat = new ShowSeat(dtSeat);
				if (!oldSeat.cnvcState.Equals(ConstApp.Show_Seat_State_Remain))
				{
					throw new BusinessException("展位预留","此展位未被预留");
					
				}
				oldSeat.cnvcState = "";//ConstApp.Show_Seat_State_Remain;
				oldSeat.cnvcOperName = seat.cnvcOperName;
				oldSeat.cndOperDate = seat.cndOperDate;
				EntityMapping.Update(oldSeat,trans);

				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				Decimal dSerialNo = EntityMapping.Create(serial,trans);

				ShowSeatLog showSeatLog = new ShowSeatLog(oldSeat.ToTable());
				showSeatLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(showSeatLog,trans);


				OperLog operLog = new OperLog(seat.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_CancelMemberSeatRemain;
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
		/// 会员展位签到
		/// </summary>
		/// <param name="seat"></param>
		/// <param name="strType"></param>
		/// <returns></returns>
		/// 
		#region
        private string GetSynch(int iSynch)
        {
            string strSynch = "";
            switch (iSynch)
            {
                case 0:
                    strSynch = "会员系统";
                    break;
                case 1:
                    strSynch = "网站操作";
                    break;
                case 2:
                    strSynch = "触摸屏操作";
                    break;
                case 3:
                    strSynch = "客服预定";
                    break;
            }
            return strSynch;
        }
		public Member MemberSeatSignIn (MemberSeat seat,PrintedBill pBill,out Bill bill)
		{
			Member retMember = new Member();
            try
            {

                conn = ConnectionPool.BorrowConnection();
                trans = conn.BeginTransaction();


                Member member = new Member();
                member.cnvcMemberCardNo = seat.cnvcMemberCardNo;
                Member oldMember = EntityMapping.Get(member, trans) as Member;
                if (null == oldMember)
                {
                    throw new BusinessException("会员签到", "未找到会员");
                }
                #region IsFeeType
                string strIsFeeType = "select cnvcMemberValue from tbMemberCode where cnvcMemberName='" + oldMember.cnvcMemberRight + "' and cnvcMemberType='" + ConstApp.IsFeeType + "'";
                bool bFeeType = false;
                object objFeeType = SqlHelper.ExecuteScalar(CommandType.Text, strIsFeeType);
                string strFeeType = "否";
                if (objFeeType != null)
                {
                    strFeeType = objFeeType.ToString() ;
                }
                if (strFeeType.Equals("是"))
                {
                    bFeeType = true;
                }
                #endregion

                #region IsDisabledDate
                string strIsDisabledDate = "select cnvcMemberValue from tbMemberCode where cnvcMemberName='" + oldMember.cnvcMemberRight + "' and cnvcMemberType='" + ConstApp.IsDisabledDate + "'";
                bool bDisabledDate = false;
                object objDisableDate = SqlHelper.ExecuteScalar(CommandType.Text, strIsDisabledDate);

                string strDisabledDate = "否";
                if (objDisableDate != null)
                {
                    strDisabledDate = objDisableDate.ToString();
                }
                if (strDisabledDate.Equals("是"))
                {
                    bDisabledDate = true;
                }
                #endregion

                string strIsInMoney = "select cnvcMemberValue from tbMemberCode where cnvcMemberName='" + oldMember.cnvcMemberRight + "' and cnvcMemberType='" + ConstApp.IsInMoney + "'";
                bool bInMoney = true;
                object objInMoney = SqlHelper.ExecuteScalar(CommandType.Text, strIsInMoney);

                string strInMoney = "是";
                if (objInMoney != null)
                {
                    strInMoney = objInMoney.ToString();
                }
                if (strInMoney.Equals("否"))
                {
                    bInMoney = false;
                }
                //流水
                SeqSerialNo serial = new SeqSerialNo();
                serial.cnvcFill = "0";
                Decimal dSerial = EntityMapping.Create(serial, trans);

                Decimal d2Serial = dSerial;

                oldMember.cnvcOperName = seat.cnvcOperName;
                oldMember.cndOperDate = seat.cndOperDate;

                string strEndDate = oldMember.cndOperDate.ToString("yyyy-MM-dd");
                //MemberProductLog ml = null;
                if (bDisabledDate)
                {
                    if (DateTime.Parse(oldMember.cndEndDate) < DateTime.Parse(strEndDate))
                    {
                        //过期会员，使用充值
                        throw new BusinessException("签到","会员已经过期，请重新发卡！");
                    }	
                    //else
                    //{
                    //产品单价
                }
                Job oldJob = new Job();
                oldJob.cnnJobID = seat.cnnID;
                oldJob = EntityMapping.Get(oldJob, trans) as Job;
                if (oldJob == null) throw new BusinessException("会员签到", "未找到招聘会信息");
                string strsql = "select * from tbMemberCode where cnvcMemberName='" + oldJob.cnvcJobTheme + "' and cnvcMemberType='" + ConstApp.ProductPrice + "'";
                DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);
                if (dt.Rows.Count == 0) throw new BusinessException("会员签到", "无产品单价信息");
                MemberCode mc = new MemberCode(dt);
                decimal dprice = Convert.ToDecimal(mc.cnvcMemberValue);
                decimal ddiscount = GetDiscount(oldJob.cnvcJobTheme, oldMember.cnvcMemberRight,oldMember.cnvcDiscount);

                string strcount = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select count(*) from tbMemberSeat where cnnID=" + seat.cnnID + " and cnvcMemberCardNo = '" + seat.cnvcMemberCardNo + "' and cnvcState = '" + ConstApp.Show_Seat_State_Booking + "'").ToString();
                int icount = Convert.ToInt32(strcount);
                MemberProductLog ml = null;
                decimal dlastbalance = oldMember.cnnPrepay;
                //未过期会员使用免费场次
                if (bFeeType)
                {
                    retMember.cnvcFree = oldMember.cnvcFree;
                    if (oldMember.cnvcFree != ConstApp.Free_Time_NoLimit)
                    {
                        if (int.Parse(oldMember.cnvcFree) <1)
                        {
                            if (!bInMoney)
                            {
                                throw new BusinessException("签到", "场次已用完");
                            }
                            else
                            {
                                throw new BusinessException("签到", "请充值");
                            }
                            //免费场次用完用充值						
                        }
                        //免费场次-1
                        string strFree = (int.Parse(oldMember.cnvcFree) - 1).ToString();
                        oldMember.cnvcFree = strFree;
                        retMember.cnvcFree = oldMember.cnvcFree;
                    }                    
                }
                else
                {				
                    if (oldMember.cnnPrepay < dprice * ddiscount / 100 * icount)
                    {
                        throw new BusinessException("签到", "请充值");				
                    }

                    
                    oldMember.cnnPrepay = oldMember.cnnPrepay - dprice * ddiscount / 100 * icount;                    
                    //MemberPrepayLog ml = new MemberPrepayLog(oldMember.ToTable());
                    //ml.cnnSerialNo = dSerial;
                    //ml.cnvcOperFlag = ConstApp.Fee_Flag_SignIn;
                    //ml.cnnPrepay = dprice * ddiscount / 100;
                    //ml.cnnBalance = oldMember.cnnPrepay;
                    //ml.cnnDonate = 0;
                    //ml.cnnLastBalance = dlastbalance;
                    //EntityMapping.Create(ml, trans);

                    
                }
                EntityMapping.Update(oldMember, trans);
                ml = new MemberProductLog(oldMember.ToTable());
                ml.cnnSerialNo = dSerial;
                ml.cnnProductPrice = dprice;
                ml.cnnCount = 1;
                if (!bFeeType)
                {
                    ml.cnnPrepay = dprice * ddiscount / 100 * icount;
                }
                ml.cnvcProductDiscount = ddiscount.ToString();
                ml.cnnLastBalance = dlastbalance;
                ml.cnnBalance = oldMember.cnnPrepay;
                ml.cnvcProductName = oldJob.cnvcJobTheme;
                ml.cnvcFree = oldMember.cnvcFree;                
                EntityMapping.Create(ml, trans);
                //}
                //}
                MemberLog memberLog = new MemberLog(oldMember.ToTable());
                memberLog.cnnSerialNo = dSerial;
                EntityMapping.Create(memberLog, trans);



                DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans, CommandType.Text, "select * from tbMemberSeat where cnnID=" + seat.cnnID + " and cnvcMemberCardNo = '" + seat.cnvcMemberCardNo + "' and cnvcState = '" + ConstApp.Show_Seat_State_Booking + "'");
                DataTable dtMemberSeatSignIn = SqlHelper.ExecuteDataTable(trans, CommandType.Text, "select * from tbMemberSeat where cnnID=" + seat.cnnID + " and cnvcMemberCardNo = '" + seat.cnvcMemberCardNo + "' and cnvcState = '" + ConstApp.Show_Seat_State_SignIn + "'");

                if (dtMemberSeat.Rows.Count == 0)
                {
                    if (dtMemberSeatSignIn.Rows.Count > 0)
                    {
                        throw new BusinessException("会员签到", "已签到！");
                    }
                    else
                    {
                        throw new BusinessException("会员签到", "未预订展位！");
                    }

                }
                int iMemberSeat = dtMemberSeat.Rows.Count;
                bill = new Bill(pBill.ToTable());
                foreach (DataRow drSeat in dtMemberSeat.Rows)
                {
                    if (iMemberSeat > 1)
                    {
                        d2Serial = EntityMapping.Create(serial, trans);
                    }


                    MemberSeat memberSeat = new MemberSeat(drSeat);
                    bill.cnvcSynch = GetSynch(memberSeat.cniSynch);
                    memberSeat.cnvcOperName = seat.cnvcOperName;
                    memberSeat.cndOperDate = seat.cndOperDate;
                    memberSeat.cnvcMemberName = pBill.cnvcMemberName;
                    memberSeat.cnvcState = ConstApp.Show_Seat_State_SignIn;
                    EntityMapping.Update(memberSeat, trans);

                    MemberSeatLog memberSeatLog = new MemberSeatLog(memberSeat.ToTable());
                    memberSeatLog.cnnSerialNo = d2Serial;
                    EntityMapping.Create(memberSeatLog, trans);

                    retMember.cnvcSales += memberSeat.cnvcSeat + ",";

                    DataTable dtShowSeat = SqlHelper.ExecuteDataTable(trans, CommandType.Text, "select * from tbShowSeat where cnnJobID=" + memberSeat.cnnID + " and cnvcSeat = '" + memberSeat.cnvcSeat + "' and cnvcFloor='" + memberSeat.cnvcFloor + "'");
                    if (dtShowSeat.Rows.Count == 0)
                    {
                        throw new BusinessException("会员签到", "未预订展位！");
                    }
                    ShowSeat showSeat = new ShowSeat(dtShowSeat);
                    showSeat.cnvcState = ConstApp.Show_Seat_State_SignIn;
                    EntityMapping.Update(showSeat, trans);

                    ShowSeatLog showSeatLog = new ShowSeatLog(showSeat.ToTable());
                    showSeatLog.cnnSerialNo = d2Serial;
                    EntityMapping.Create(showSeatLog, trans);
                }
                SignInLog signInLog = new SignInLog(seat.ToTable());
                signInLog.cnnJobID = seat.cnnID;
                signInLog.cnnSerialNo = dSerial;
                signInLog.cnvcSeat = retMember.cnvcSales;
                EntityMapping.Create(signInLog, trans);


                bill.cnvcBillType = ConstApp.Bill_Type_SignIn;
                bill.cnnRepeats = 0;
                bill.cnvcSeat = retMember.cnvcSales;
                bill.cndOperDate = DateTime.Now;
                bill.cnvcMemberName = pBill.cnvcMemberName;
                bill.cnnPrepay = ml.cnnPrepay;
                bill.cnnLastBalance = ml.cnnLastBalance;
                bill.cnnBalance = ml.cnnBalance;
                EntityMapping.Create(bill, trans);

                OperLog operLog = new OperLog(seat.ToTable());
                operLog.cnnSerialNo = dSerial;
                if (operLog.cnvcOperName == operLog.cnvcMemberCardNo)
                {
                    operLog.cniSynch = 2;
                }
                operLog.cnnPrepay = oldMember.cnnPrepay;
                operLog.cnvcOperFlag = ConstApp.Oper_Flag_MemberSignIn;
                EntityMapping.Create(operLog, trans);

                //积分处理 20110211
                MemberManageFacade mmf = new MemberManageFacade();
                mmf.PointsAdd(trans, ConstApp.PointsMF, oldMember.cnvcMemberRight, oldMember.cnvcMemberCardNo, oldMember.cnvcOperName, oldMember.cndOperDate, 0);
                //////////////////////////////////////////////////
                trans.Commit();

            }
            catch (BusinessException bex) //业务异常
            {
                //事务回滚					
                trans.Rollback();
                //LogAdapter.WriteBusinessException(bex);
                throw new BusinessException(bex.Type, bex.Message);
            }
            catch (SqlException sex)   //数据库异常
            {
                //事务回滚					
                trans.Rollback();
                //LogAdapter.WriteDatabaseException(sex);				
                throw new BusinessException("数据库异常", sex.Message);
            }
            catch (Exception ex)		 //其他异常
            {
                //事务回滚						
                trans.Rollback();
                //LogAdapter.WriteFeaturesException(ex);	
                throw new BusinessException("其它异常", ex.Message);
            }
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
			return retMember;
						
		}

		public string EnMemberSeatSignIn (MemberSeat seat)
		{
			string strSeat = "";
			try
			{

				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();	
				

				Member member = new Member();
				member.cnvcMemberCardNo = seat.cnvcMemberCardNo;
				Member oldMember = EntityMapping.Get(member,trans) as Member;
				if (null == oldMember)
				{
					throw new BusinessException("会员签到","未找到会员");
				}
				//流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				Decimal dSerial = EntityMapping.Create(serial,trans);

				Decimal d2Serial = dSerial;

				oldMember.cnvcOperName = seat.cnvcOperName;
				oldMember.cndOperDate = seat.cndOperDate;

				string strEndDate = oldMember.cndOperDate.ToString("yyyy-MM-dd");

                Job oldJob = new Job();
                oldJob.cnnJobID = seat.cnnID;
                oldJob = EntityMapping.Get(oldJob, trans) as Job;
                if (oldJob == null) throw new BusinessException("强制会员签到", "未找到招聘会信息");
                string strsql = "select * from tbMemberCode where cnvcMemberName=" + oldJob.cnvcJobTheme + " and cnvcMemberType='" + ConstApp.ProductPrice + "'";
                DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);
                if (dt.Rows.Count == 0) throw new BusinessException("强制会员签到", "无产品单价信息");
                MemberCode mc = new MemberCode(dt);
                decimal dprice = Convert.ToDecimal(mc.cnvcMemberValue);
                decimal ddiscount = GetDiscount(oldJob.cnvcJobTheme, oldMember.cnvcMemberRight, oldMember.cnvcDiscount);

                //if (DateTime.Parse(oldMember.cndEndDate) < DateTime.Parse(strEndDate))
                //{
					//过期会员，使用充值
                    //DataTable dtPrepay = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbPrepay where cnnJobID="+seat.cnnID+" and cnvcMemberCardNo='"+seat.cnvcMemberCardNo+"' and (cnvcState is null or cnvcState <> '"+ConstApp.Show_Seat_State_SignIn+"')");
                    //if (dtPrepay.Rows.Count == 0)
                    //{
                    //    throw new BusinessException("签到","请充值");
                    //}
                    //int iPrepay = dtPrepay.Rows.Count;
                    //foreach (DataRow drPrepay in dtPrepay.Rows)
                    //{
                    //    if (iPrepay > 1)
                    //    {
                    //        d2Serial = EntityMapping.Create(serial,trans);
                    //    }
						

                    //    Prepay prepay = new Prepay(drPrepay);
                    //    prepay.cnvcState = ConstApp.Show_Seat_State_SignIn;
                    //    prepay.cnvcOperName = seat.cnvcOperName;
                    //    prepay.cndOperDate = seat.cndOperDate;
                    //    EntityMapping.Update(prepay,trans);

                    //    PrepayLog prepayLog = new PrepayLog(prepay.ToTable());
                    //    prepayLog.cnnSerialNo = d2Serial;
                    //    EntityMapping.Create(prepayLog,trans);
                    //}
				//}	
                //else
                //{
                    if (oldMember.cnnPrepay < dprice * ddiscount / 100) throw new BusinessException("强制会员签到", "请充值");
					//未过期会员使用免费场次
                    //if (oldMember.cnvcFree != ConstApp.Free_Time_NoLimit)
                    //{					
                        //if (int.Parse(oldMember.cnvcFree) < 1)
                        //{
                        //    //免费场次用完用充值
                        //    DataTable dtPrepay = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbPrepay where cnnJobID="+seat.cnnID+" and cnvcMemberCardNo='"+seat.cnvcMemberCardNo+"' and (cnvcState is null or cnvcState <> '"+ConstApp.Show_Seat_State_SignIn+"')");
                        //    if (dtPrepay.Rows.Count == 0)
                        //    {
                        //        throw new BusinessException("签到","请充值");
                        //    }
                        //    int iPrepay = dtPrepay.Rows.Count;
                        //    foreach (DataRow drPrepay in dtPrepay.Rows)
                        //    {
                        //        if (iPrepay > 1)
                        //        {
                        //            d2Serial = EntityMapping.Create(serial,trans);
                        //        }
								
                        //        Prepay prepay = new Prepay(drPrepay);
                        //        prepay.cnvcState = ConstApp.Show_Seat_State_SignIn;
                        //        prepay.cnvcOperName = seat.cnvcOperName;
                        //        prepay.cndOperDate = seat.cndOperDate;
                        //        EntityMapping.Update(prepay,trans);

                        //        PrepayLog prepayLog = new PrepayLog(prepay.ToTable());
                        //        prepayLog.cnnSerialNo = d2Serial;
                        //        EntityMapping.Create(prepayLog,trans);
                        //    }
						
                        //}
                        //else
                        //{
							//免费场次-1
							//string strFree = (int.Parse(oldMember.cnvcFree)-1).ToString();
                    oldMember.cnnPrepay = oldMember.cnnPrepay - dprice * ddiscount / 100;//strFree;					
							EntityMapping.Update(oldMember,trans);

                            MemberPrepayLog ml = new MemberPrepayLog(oldMember.ToTable());
                            ml.cnnSerialNo = dSerial;
                            ml.cnnPrepay = dprice * ddiscount / 100;
                            ml.cnvcOperFlag = ConstApp.Fee_Flag_SignIn;
                            EntityMapping.Create(ml, trans);
						//}
					
					
					//}
				//}
				MemberLog memberLog = new MemberLog(oldMember.ToTable());
				memberLog.cnnSerialNo = dSerial;
				EntityMapping.Create(memberLog,trans);

				

				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcMemberCardNo = '"+seat.cnvcMemberCardNo+"' and cnvcState = '"+ConstApp.Show_Seat_State_Booking+"'");	
				
				DataTable dtMemberSeatSignIn = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcMemberCardNo = '"+seat.cnvcMemberCardNo+"' and cnvcState = '"+ConstApp.Show_Seat_State_SignIn+"'");	
				
				if (dtMemberSeat.Rows.Count == 0)
				{
					if (dtMemberSeatSignIn.Rows.Count > 0)
					{
						throw new BusinessException("会员签到","已签到！");
					}
					else
					{
						throw new BusinessException("会员签到","未预订展位！");
					}
					
				}	
				int iMemberSeat = dtMemberSeat.Rows.Count;
				foreach (DataRow drSeat in dtMemberSeat.Rows)
				{
					if (iMemberSeat > 1)
					{
						d2Serial = EntityMapping.Create(serial,trans);
					}
					

					MemberSeat memberSeat = new MemberSeat(drSeat);
					memberSeat.cnvcOperName = seat.cnvcOperName;
					memberSeat.cndOperDate = seat.cndOperDate;
					memberSeat.cnvcState = ConstApp.Show_Seat_State_SignIn;
					EntityMapping.Update(memberSeat,trans);

					MemberSeatLog memberSeatLog = new MemberSeatLog(memberSeat.ToTable());
					memberSeatLog.cnnSerialNo = d2Serial;
					EntityMapping.Create(memberSeatLog,trans);

					strSeat += memberSeat.cnvcSeat+" ";

					DataTable dtShowSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+memberSeat.cnnID+" and cnvcSeat = '"+memberSeat.cnvcSeat+"' and cnvcFloor='"+memberSeat.cnvcFloor+"'");	
					if (dtShowSeat.Rows.Count == 0)
					{
						throw new BusinessException("会员签到","未预订展位！");
					}
					ShowSeat showSeat = new ShowSeat(dtShowSeat);
					showSeat.cnvcState = ConstApp.Show_Seat_State_SignIn;
					EntityMapping.Update(showSeat,trans);

					ShowSeatLog showSeatLog = new ShowSeatLog(showSeat.ToTable());
					showSeatLog.cnnSerialNo = d2Serial;
					EntityMapping.Create(showSeatLog,trans);
				}
				SignInLog signInLog = new SignInLog(seat.ToTable());
				signInLog.cnnJobID = seat.cnnID;
				signInLog.cnnSerialNo = dSerial;
				signInLog.cnvcSeat = strSeat;
				EntityMapping.Create(signInLog,trans);
						
				Bill bill = new Bill(seat.ToTable());				
				bill.cnvcBillType = ConstApp.Bill_Type_SignIn;
				bill.cnnRepeats = 0;
				bill.cnvcSeat = strSeat;
				bill.cndOperDate = DateTime.Now;
				bill.cnvcMemberName = oldMember.cnvcMemberName;
				EntityMapping.Create(bill,trans);

				OperLog operLog = new OperLog(seat.ToTable());
				operLog.cnnSerialNo = dSerial;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_EnMemberSignIn;
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
			return strSeat;
						
		}

		#endregion
		/// <summary>
		/// 非会员签到
		/// </summary>
		/// <param name="seat"></param>
		/// <returns></returns>
		/// 
		#region
		public string FMemberSeatSignIn (MemberSeat seat,out Bill bill)
		{
			string strSeat = "";
			try
			{

				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();	
				

				FMember fmember = new FMember();
				fmember.cnvcPaperNo = seat.cnvcPaperNo;
				fmember.cnvcMemberName=seat.cnvcMemberName;
				FMember oldFMember = EntityMapping.Get(fmember,trans) as FMember;
				if (null == oldFMember)
				{
					throw new BusinessException("非会员签到","未找到非会员");
				}
				//流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				Decimal dSerial = EntityMapping.Create(serial,trans);

				Decimal d2Serial = dSerial;

				oldFMember.cnvcOperName = seat.cnvcOperName;
				oldFMember.cndOperDate = seat.cndOperDate;

                Job oldJob = new Job();
                oldJob.cnnJobID = seat.cnnID;
                oldJob = EntityMapping.Get(oldJob, trans) as Job;
                if (oldJob == null) throw new BusinessException("非会员签到", "未找到招聘会信息");
                //产品单价
                string strsql = "select * from tbMemberCode where cnvcMemberName='" + oldJob.cnvcJobTheme + "' and cnvcMemberType='" + ConstApp.ProductPrice + "'";
                DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);
                if (dt.Rows.Count == 0) throw new BusinessException("非会员签到", "无产品单价信息");
                MemberCode mc = new MemberCode(dt);
                decimal dprice = Convert.ToDecimal(mc.cnvcMemberValue);
                decimal ddiscount = GetDiscount(oldJob.cnvcJobTheme, "", "100");

                string strcount = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select count(*) from tbMemberSeat where cnnID=" + seat.cnnID + " and cnvcMemberCardNo is null and cnvcPaperNo = '" + seat.cnvcPaperNo + "' and cnvcState = '" + ConstApp.Show_Seat_State_Booking + "'").ToString();
                int icount = Convert.ToInt32(strcount);
                if (oldFMember.cnnPrepay < dprice * ddiscount / 100*icount)
                    throw new BusinessException("非会员签到", "请充值");

                decimal dlastbalance = oldFMember.cnnPrepay;
                oldFMember.cnnPrepay = oldFMember.cnnPrepay - dprice * ddiscount / 100*icount;
                EntityMapping.Update(oldFMember, trans);

                //FMemberPrepayLog fl = new FMemberPrepayLog(oldFMember.ToTable());
                //fl.cnnSerialNo = dSerial;
                //fl.cnvcOperFlag = ConstApp.Fee_Flag_SignIn;
                //fl.cnnPrepay = dprice * ddiscount / 100;
                //EntityMapping.Create(fl, trans);

                FMemberProductLog fl = new FMemberProductLog(oldFMember.ToTable());
                fl.cnnSerialNo = dSerial;
                fl.cnnProductPrice = dprice;
                fl.cnnCount = 1;
                fl.cnnPrepay = dprice * ddiscount / 100*icount;
                fl.cnvcProductDiscount = ddiscount.ToString();
                fl.cnnLastBalance = dlastbalance;
                fl.cnnBalance = oldFMember.cnnPrepay;
                fl.cnvcProductName = oldJob.cnvcJobTheme;
                EntityMapping.Create(fl, trans);
				
				
				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcMemberCardNo is null and cnvcPaperNo = '"+seat.cnvcPaperNo+"' and cnvcState = '"+ConstApp.Show_Seat_State_Booking+"'");	
				DataTable dtMemberSeatSignIn = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcMemberCardNo is null and cnvcPaperNo = '"+seat.cnvcPaperNo+"' and cnvcState = '"+ConstApp.Show_Seat_State_SignIn+"'");	
				
				if (dtMemberSeat.Rows.Count == 0)
				{
					if (dtMemberSeatSignIn.Rows.Count > 0)
					{
						throw new BusinessException("非会员签到","已签到！");
					}
					else
					{
						throw new BusinessException("非会员签到","未预订展位！");
					}
					
				}				
				int iMemberSeat = dtMemberSeat.Rows.Count;
				foreach (DataRow drSeat in dtMemberSeat.Rows)
				{
					if (iMemberSeat > 1)
					{
						d2Serial = EntityMapping.Create(serial,trans);
					}
					

					MemberSeat memberSeat = new MemberSeat(drSeat);
					memberSeat.cnvcOperName = seat.cnvcOperName;
					memberSeat.cndOperDate = seat.cndOperDate;
					memberSeat.cnvcState = ConstApp.Show_Seat_State_SignIn;
					EntityMapping.Update(memberSeat,trans);

					MemberSeatLog memberSeatLog = new MemberSeatLog(memberSeat.ToTable());
					memberSeatLog.cnnSerialNo = d2Serial;
					EntityMapping.Create(memberSeatLog,trans);

					strSeat += memberSeat.cnvcSeat+",";

					DataTable dtShowSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+memberSeat.cnnID+" and cnvcSeat = '"+memberSeat.cnvcSeat+"' and cnvcFloor='"+memberSeat.cnvcFloor+"'");	
					if (dtShowSeat.Rows.Count == 0)
					{
						throw new BusinessException("非会员签到","未预订展位！");
					}
					ShowSeat showSeat = new ShowSeat(dtShowSeat);
					showSeat.cnvcState = ConstApp.Show_Seat_State_SignIn;
					EntityMapping.Update(showSeat,trans);

					ShowSeatLog showSeatLog = new ShowSeatLog(showSeat.ToTable());
					showSeatLog.cnnSerialNo = d2Serial;
					EntityMapping.Create(showSeatLog,trans);
				}

				SignInLog signInLog = new SignInLog(seat.ToTable());
				signInLog.cnnJobID = seat.cnnID;
				signInLog.cnnSerialNo = dSerial;
				signInLog.cnvcSeat = strSeat;
				EntityMapping.Create(signInLog,trans);
						
				bill = new Bill(seat.ToTable());				
				bill.cnvcBillType = ConstApp.Bill_Type_SignIn;
				bill.cnnRepeats = 0;
				bill.cnvcSeat = strSeat;
				bill.cndOperDate = DateTime.Now;

                bill.cnnPrepay = fl.cnnPrepay;
                bill.cnnBalance = fl.cnnBalance;
                bill.cnnLastBalance = fl.cnnLastBalance;
//				bill.cnvcMemberName = fmember.cnvcMemberName;
				//bill.cnvcMemberName = seat.cnvcMemberName;
				EntityMapping.Create(bill,trans);

				OperLog operLog = new OperLog(seat.ToTable());
				operLog.cnnSerialNo = dSerial;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_FMemberSignIn;
                operLog.cnnPrepay = oldFMember.cnnPrepay;
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
			return strSeat;
						
		}

		public string EnFMemberSeatSignIn (MemberSeat seat)
		{
			string strSeat = "";
			try
			{

				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();	
				

				FMember fmember = new FMember();
				fmember.cnvcPaperNo = seat.cnvcPaperNo;
				FMember oldFMember = EntityMapping.Get(fmember,trans) as FMember;
				if (null == oldFMember)
				{
					throw new BusinessException("非会员签到","未找到非会员");
				}
				//流水
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				Decimal dSerial = EntityMapping.Create(serial,trans);

				Decimal d2Serial = dSerial;

				oldFMember.cnvcOperName = seat.cnvcOperName;
				oldFMember.cndOperDate = seat.cndOperDate;

                Job oldJob = new Job();
                oldJob.cnnJobID = seat.cnnID;
                oldJob = EntityMapping.Get(oldJob, trans) as Job;
                if (oldJob == null) throw new BusinessException("强制非会员签到", "未找到招聘会信息");
                string strsql = "select * from tbMemberCode where cnvcMemberName=" + oldJob.cnvcJobTheme + " and cnvcMemberType='" + ConstApp.ProductPrice + "'";
                DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);
                if (dt.Rows.Count == 0) throw new BusinessException("强制非会员签到", "无产品单价信息");
                MemberCode mc = new MemberCode(dt);
                decimal dprice = Convert.ToDecimal(mc.cnvcMemberValue);
                decimal ddiscount = GetDiscount(oldJob.cnvcJobTheme, "", "100");

//                DataTable dtPrepay = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbPrepay where (cnvcMemberCardNo is null or cnvcMemberCardNo = '') and cnnJobID="+seat.cnnID+" and cnvcPaperNo='"+seat.cnvcPaperNo+"' and (cnvcState is null or cnvcState <> '"+ConstApp.Show_Seat_State_SignIn+"')");
////				if (dtPrepay.Rows.Count == 0)
////				{
////					throw new BusinessException("非会员签到","请缴费");
////				}
//                int iPrepay = dtPrepay.Rows.Count;
//                foreach (DataRow drPrepay in dtPrepay.Rows)
//                {
//                    if (iPrepay > 1)
//                    {
//                        d2Serial = EntityMapping.Create(serial,trans);
//                    }
					

//                    Prepay prepay = new Prepay(drPrepay);
//                    prepay.cnvcState = ConstApp.Show_Seat_State_SignIn;
//                    EntityMapping.Update(prepay,trans);

//                    PrepayLog prepayLog = new PrepayLog(prepay.ToTable());
//                    prepayLog.cnnSerialNo = d2Serial;
//                    EntityMapping.Create(prepayLog,trans);
//                }
                if (oldFMember.cnnPrepay < dprice * ddiscount / 100) throw new BusinessException("强制非会员签到", "请充值");

                oldFMember.cnnPrepay = oldFMember.cnnPrepay - dprice * ddiscount / 100;
                EntityMapping.Update(oldFMember, trans);

                FMemberPrepayLog fl = new FMemberPrepayLog(fmember.ToTable());
                fl.cnnPrepay = dprice * ddiscount / 100;
                fl.cnnSerialNo = dSerial;
                fl.cnvcOperFlag = ConstApp.Fee_Flag_SignIn;
                EntityMapping.Create(fl, trans);

				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcMemberCardNo is null and cnvcPaperNo = '"+seat.cnvcPaperNo+"' and cnvcState = '"+ConstApp.Show_Seat_State_Booking+"'");	
				DataTable dtMemberSeatSignIn = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcMemberCardNo is null and cnvcPaperNo = '"+seat.cnvcPaperNo+"' and cnvcState = '"+ConstApp.Show_Seat_State_SignIn+"'");	
				
				if (dtMemberSeat.Rows.Count == 0)
				{
					if (dtMemberSeatSignIn.Rows.Count > 0)
					{
						throw new BusinessException("非会员签到","已签到！");
					}
					else
					{
						throw new BusinessException("非会员签到","未预订展位！");
					}
					
				}	
						
				int iMemberSeat = dtMemberSeat.Rows.Count;
				foreach (DataRow drSeat in dtMemberSeat.Rows)
				{
					if (iMemberSeat > 1)
					{
						d2Serial = EntityMapping.Create(serial,trans);
					}
					

					MemberSeat memberSeat = new MemberSeat(drSeat);
					memberSeat.cnvcOperName = seat.cnvcOperName;
					memberSeat.cndOperDate = seat.cndOperDate;
					memberSeat.cnvcState = ConstApp.Show_Seat_State_SignIn;
					EntityMapping.Update(memberSeat,trans);

					MemberSeatLog memberSeatLog = new MemberSeatLog(memberSeat.ToTable());
					memberSeatLog.cnnSerialNo = d2Serial;
					EntityMapping.Create(memberSeatLog,trans);

					strSeat += memberSeat.cnvcSeat+" ";

					DataTable dtShowSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+memberSeat.cnnID+" and cnvcSeat = '"+memberSeat.cnvcSeat+"' and cnvcFloor='"+memberSeat.cnvcFloor+"'");	
					if (dtShowSeat.Rows.Count == 0)
					{
						throw new BusinessException("非会员签到","未预订展位！");
					}
					ShowSeat showSeat = new ShowSeat(dtShowSeat);
					showSeat.cnvcState = ConstApp.Show_Seat_State_SignIn;
					EntityMapping.Update(showSeat,trans);

					ShowSeatLog showSeatLog = new ShowSeatLog(showSeat.ToTable());
					showSeatLog.cnnSerialNo = d2Serial;
					EntityMapping.Create(showSeatLog,trans);
				}

				SignInLog signInLog = new SignInLog(seat.ToTable());
				signInLog.cnnJobID = seat.cnnID;
				signInLog.cnnSerialNo = dSerial;
				signInLog.cnvcSeat = strSeat;
				EntityMapping.Create(signInLog,trans);
						
				Bill bill = new Bill(seat.ToTable());				
				bill.cnvcBillType = ConstApp.Bill_Type_SignIn;
				bill.cnnRepeats = 0;
				bill.cnvcSeat = strSeat;
				bill.cndOperDate = DateTime.Now;
				//bill.cnvcMemberName = seat.cnvcMemberName;
				EntityMapping.Create(bill,trans);

				OperLog operLog = new OperLog(seat.ToTable());
				operLog.cnnSerialNo = dSerial;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_EnFMemberSignIn;
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
			return strSeat;
						
		}

		#endregion

		public void BatchSignIn(Job job)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();

				string strMemberSeatSql = "select * from tbMemberSeat where cnnID="+job.cnnJobID.ToString()+" and cnvcState = '"+ConstApp.Show_Seat_State_Booking+"' ";
				//string strPrepay = "select * from tbPrepay where cnnJobID="+job.cnnJobID.ToString()+" and cnvcState is null";
				string strMember = "select *  from tbMember where cnvcState ='"+ConstApp.Card_State_InUse+"'";
                string strFMember = "select * from tbFMember";
				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,strMemberSeatSql);
				//DataTable dtPrepay = SqlHelper.ExecuteDataTable(trans,CommandType.Text,strPrepay);
				DataTable dtMember = SqlHelper.ExecuteDataTable(trans,CommandType.Text,strMember);
                DataTable dtFMember = SqlHelper.ExecuteDataTable(trans, CommandType.Text, strFMember);

                Job oldJob = EntityMapping.Get(job,trans) as Job;
                //产品单价
                string strsql = "select * from tbMemberCode where cnvcMemberName=" + oldJob.cnvcJobTheme + " and cnvcMemberType='" + ConstApp.ProductPrice + "'";
                DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);
                if (dt.Rows.Count == 0) throw new BusinessException("批量签到", "无产品单价信息");
                MemberCode mc = new MemberCode(dt);
                decimal dprice = Convert.ToDecimal(mc.cnvcMemberValue);
                decimal ddiscount = GetDiscount(oldJob.cnvcJobTheme, "", "100");
				if (dtMemberSeat.Rows.Count > 0)
				{
					foreach (DataRow drMemberSeat in dtMemberSeat.Rows)
					{
						MemberSeat ms = new MemberSeat(drMemberSeat);
						ms.cnvcOperName = job.cnvcOperName;
						ms.cndOperDate = job.cndOperDate;
						if (ms.cnvcMemberCardNo.Length > 0)
						{
							//会员
							DataRow[] drMembers = dtMember.Select("cnvcMemberCardNo='"+ms.cnvcMemberCardNo+"'");
							if (drMembers.Length == 1)
							{
								Member member = new Member(drMembers[0]);
                                ddiscount = GetDiscount(oldJob.cnvcJobTheme, member.cnvcMemberRight, member.cnvcDiscount);						
								DateTime dtEndDate = DateTime.Parse(member.cndEndDate);
								if (dtEndDate > DateTime.Now)
								{
                                    if (member.cnnPrepay < dprice * ddiscount / 100)
                                    {
                                        continue;
                                    }
									//流水
									SeqSerialNo serial = new SeqSerialNo();
									serial.cnvcFill = "0";
									Decimal dSerial = EntityMapping.Create(serial,trans);

                                        member.cnnPrepay = member.cnnPrepay - dprice * ddiscount / 100;
                                        member.cnvcOperName = job.cnvcOperName;
                                        member.cndOperDate = job.cndOperDate;
                                        EntityMapping.Update(member, trans);

                                        MemberLog memberLog = new MemberLog(member.ToTable());
                                        memberLog.cnnSerialNo = dSerial;
                                        EntityMapping.Create(memberLog, trans);
                                        //}
                                        MemberPrepayLog ml = new MemberPrepayLog(member.ToTable());
                                        ml.cnnSerialNo = dSerial;
                                        ml.cnnPrepay = dprice * ddiscount / 100;
                                        ml.cnvcOperFlag = ConstApp.Fee_Flag_SignIn;
                                        EntityMapping.Create(ml, trans);

                                    //}																									
									ms.cnvcState = ConstApp.Show_Seat_State_SignIn;
									ms.cniSynch = 0;
									EntityMapping.Update(ms,trans);

									MemberSeatLog memberSeatLog = new MemberSeatLog(ms.ToTable());
									memberSeatLog.cnnSerialNo = dSerial;
									EntityMapping.Create(memberSeatLog,trans);


									DataTable dtShowSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+ms.cnnID+" and cnvcSeat = '"+ms.cnvcSeat+"' and cnvcFloor='"+ms.cnvcFloor+"'");	
									if (dtShowSeat.Rows.Count > 0)
									{
									
										ShowSeat showSeat = new ShowSeat(dtShowSeat);
										showSeat.cnvcOperName = job.cnvcOperName;
										showSeat.cndOperDate = job.cndOperDate;
										showSeat.cniSynch = 0;
										showSeat.cnvcState = ConstApp.Show_Seat_State_SignIn;
										EntityMapping.Update(showSeat,trans);

										ShowSeatLog showSeatLog = new ShowSeatLog(showSeat.ToTable());
										showSeatLog.cnnSerialNo = dSerial;
										EntityMapping.Create(showSeatLog,trans);
									}
									//签到日志
									SignInLog signInLog = new SignInLog(ms.ToTable());
									signInLog.cnnJobID = ms.cnnID;
									signInLog.cnnSerialNo = dSerial;									
									EntityMapping.Create(signInLog,trans);
									//操作日志
									OperLog operLog = new OperLog(ms.ToTable());
									operLog.cnnSerialNo = dSerial;									
									operLog.cnvcOperFlag = ConstApp.Oper_Flag_MemberSignIn;
									EntityMapping.Create(operLog,trans);

								}
								
								
								
							}
						}
						else
						{
							//非会员
                            DataRow[] drFMembers = dtFMember.Select("cnvcPaperNo='" + ms.cnvcPaperNo + "'");
                            if (drFMembers.Length == 1)
							{
                                FMember fmember = new FMember(drFMembers[0]);
                                if (fmember.cnnPrepay < dprice * ddiscount / 100) continue;
								//可以签到
								//流水
								SeqSerialNo serial = new SeqSerialNo();
								serial.cnvcFill = "0";
								Decimal dSerial = EntityMapping.Create(serial,trans);

                                fmember.cnnPrepay = fmember.cnnPrepay - dprice * ddiscount / 100;
                                EntityMapping.Update(fmember, trans);

                                FMemberPrepayLog fl = new FMemberPrepayLog(fmember.ToTable());
                                fl.cnnSerialNo = dSerial;
                                fl.cnnPrepay = dprice * ddiscount / 100;
                                fl.cnvcOperFlag = ConstApp.Fee_Flag_SignIn;
                                fl.cnvcOperName = job.cnvcOperName;
                                fl.cndOperDate = job.cndOperDate;
                                EntityMapping.Create(fl, trans);

								ms.cnvcState = ConstApp.Show_Seat_State_SignIn;
								ms.cniSynch = 0;
								EntityMapping.Update(ms,trans);

								MemberSeatLog memberSeatLog = new MemberSeatLog(ms.ToTable());
								memberSeatLog.cnnSerialNo = dSerial;
								EntityMapping.Create(memberSeatLog,trans);


								DataTable dtShowSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+ms.cnnID+" and cnvcSeat = '"+ms.cnvcSeat+"' and cnvcFloor='"+ms.cnvcFloor+"'");	
								if (dtShowSeat.Rows.Count > 0)
								{
									
									ShowSeat showSeat = new ShowSeat(dtShowSeat);
									showSeat.cnvcState = ConstApp.Show_Seat_State_SignIn;
									showSeat.cnvcOperName = job.cnvcOperName;
									showSeat.cndOperDate = job.cndOperDate;
									showSeat.cniSynch = 0;
									EntityMapping.Update(showSeat,trans);

									ShowSeatLog showSeatLog = new ShowSeatLog(showSeat.ToTable());
									showSeatLog.cnnSerialNo = dSerial;
									EntityMapping.Create(showSeatLog,trans);

									
								}
						
								SignInLog signInLog = new SignInLog(ms.ToTable());
								signInLog.cnnJobID = ms.cnnID;
								signInLog.cnnSerialNo = dSerial;
								EntityMapping.Create(signInLog,trans);

								OperLog operLog = new OperLog(ms.ToTable());
								operLog.cnnSerialNo = dSerial;
								operLog.cnvcOperFlag = ConstApp.Oper_Flag_FMemberSignIn;
								EntityMapping.Create(operLog,trans);
							}
						}
						
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

        public decimal GetDiscount(string strProductName, string strMemberRight, string strMemberDiscount)
        {
            //会员折扣、充值折扣、产品折扣 3者择最小值
            decimal ddiscount = 100;
            decimal dmdiscount = 100;
            decimal dMemberDiscount = 100;

            string strsql = "";
            DataTable dt = null;
            MemberCode mc = null;

            if (!string.IsNullOrEmpty(strMemberDiscount))
            {
                dMemberDiscount = Convert.ToDecimal(strMemberDiscount);
            }            
            else if (strMemberRight != "")
            {
                strsql = "select * from tbMemberCode where cnvcMemberName='"+strMemberRight+"' and cnvcMemberType='"+ConstApp.MemberDiscount+"'";
                dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);
                if (dt.Rows.Count > 0)
                {
                    mc = new MemberCode(dt);
                    dmdiscount = Convert.ToDecimal(mc.cnvcMemberValue);
                    //return ddiscount;
                }
            }
            //产品折扣
            strsql = "select * from tbMemberCode where cnvcMemberName='" + strProductName + "' and cnvcMemberType='" + ConstApp.ProductDiscount + "'";
            dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);
            if (dt.Rows.Count > 0)
            {
                mc = new MemberCode(dt);
                ddiscount = Convert.ToDecimal(mc.cnvcMemberValue);
                //return ddiscount;
            }
            return GetMin(ddiscount, dmdiscount, dMemberDiscount);
            //return ddiscount>dmdiscount?dmdiscount:ddiscount;
        }
        public int GetBookCount(int jobId, string strMemberCardNo)
        {
            string strcount = SqlHelper.ExecuteScalar(CommandType.Text, "select count(*) from tbMemberSeat where cnnID=" + jobId + " and cnvcMemberCardNo = '" + strMemberCardNo + "' and cnvcState = '" + ConstApp.Show_Seat_State_Booking + "'").ToString();
            int icount = 0;
            if (!string.IsNullOrEmpty(strcount))
            {
                icount = Convert.ToInt32(strcount);
            }
            return icount;
        }
        private decimal GetMin(decimal d1, decimal d2, decimal d3)
        {
            decimal d = d1 <d2 ? d1 : d2;
            return d < d3 ? d : d3;
        }
        
	}
}
