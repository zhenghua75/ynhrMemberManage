
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	SecurityManage.cs
* ����:	     ֣��
* ��������:    2007-12-10
* ��������:    ��ȫ����ҵ��

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

namespace ynhrMemberManage.BusinessFacade
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
		/// ��ǰ���ݿ�����
		/// </summary>
		private SqlTransaction trans = null;
		/// <summary>
		/// ��ǰ���ݿ�����
		/// </summary>
		private SqlConnection conn = null;

		/// <summary>
		/// �����Ƹ��
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
				//������ˮ
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				//��Ƹ����ˮ
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}
		#endregion

		#region չ��
		#region ���չ��
		public void AddShow (Show show)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				//������ˮ
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				//չ����ˮ
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}
		#endregion
		#endregion
		#region ����չλ����
		public void SaveShowPlan (Panel pl,string strJobID,string strJobName,string strOperName,DateTime dtOperDate)
		{
			//����չλ����
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				//������ˮ
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

					//չ����ˮ
					ShowSerialNo showSerial = new ShowSerialNo();
					showSerial.cnvcFill = "0";
					int iSerialNo = (int)EntityMapping.Create(showSerial,trans);

					show.cnnShowID = iSerialNo;
					show.cnnJobID = int.Parse(strJobID);

					EntityMapping.Create(show,trans);

				}
				//չ����־
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
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

				//������ˮ
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
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

				//������ˮ
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				Job oldJob = EntityMapping.Get(job,trans) as Job;
				if (null == oldJob)
				{
					throw new BusinessException("��Ƹ����Ϣ�޸�","δ�ҵ���Ƹ�ᣡ");
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
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
				//					throw new BusinessException("�������쳣",strReturn);
				//				}
				
			}
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
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
            return SqlHelper.ExecuteDataTable(CommandType.Text, "select cnnID as ��Ƹ��ID,cnvcJobName as  ��Ƹ������,cnvcJobTheme as  ��Ƹ������,cndBeginDate as ��Ƹ�Ὺʼʱ��, cndEndDate as ��Ƹ�����ʱ��, cndBookBeginDate as Ԥ����ʼʱ��,cndBookEndDate as Ԥ������ʱ�� from tbJob where cnvcJobName like '%" + job.cnvcJobName + "%'");
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
				//					throw new BusinessException("�������쳣",strReturn);
				//				}
				
			}
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}

        public DataTable GetAllSeat(Job job)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "select cnvcSeat as չλ,cnvcState as ״̬ from tbShowSeat where cnnID = " + job.cnnJobID + " and cnvcSeat is not null order by cnvcSeat");

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
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbShowSeat set cnvcState = 'Ԥ��' where cnnID="+seat.cnnJobID+" and cnvcSeat = '"+seat.cnvcSeat+"'");				
				
				trans.Commit();
				
			}
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}
		/// <summary>
		/// ��ԱչλԤ��
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
						throw new BusinessException("չλԤ��","��չλ�ѱ�ʹ��");
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
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
						throw new BusinessException("չλԤ��","��չλ�ѱ�ʹ��");
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}

		/// <summary>
		/// ��Աȡ��չλԤ��
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
//					throw new BusinessException("չλȡ��Ԥ��","δԤ����չλ"+seat.cnvcSeat);
//				}
				MemberSeat oldMemberSeat = new MemberSeat(dtMemberSeat);
				oldMemberSeat.cnvcOperName = seat.cnvcOperName;
				oldMemberSeat.cndOperDate = seat.cndOperDate;
				SingleCancelMemberSeatBooking(trans,oldMemberSeat);
				trans.Commit();
				
			}
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
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
//					throw new BusinessException("չλȡ��Ԥ��","δԤ��չλ");
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
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
				//					throw new BusinessException("չλȡ��Ԥ��","δԤ��չλ");
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
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
//				throw new BusinessException("չλԤ��","δԤ����չλ"+seat.cnvcSeat);
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
						throw new BusinessException("չλԤ��","ռλʧ�ܣ���չλ�ѱ�ʹ��");
					}
					oldShowSeat.cnvcState = seat.cnvcOperName;
					oldShowSeat.cnvcOperName = seat.cnvcOperName;
					oldShowSeat.cndOperDate = seat.cndOperDate;
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}

		/// <summary>
		/// �ǻ�ԱչλԤ��
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
						throw new BusinessException("չλԤ��","��չλ�ѱ�ʹ��");
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}
		#endregion
		/// <summary>
		/// �ǻ�Աչλȡ��Ԥ��
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
//					throw new BusinessException("�ǻ�Աȡ��չλԤ��","δԤ��չλ");
//				}
				MemberSeat oldMemberSeat = new MemberSeat(dtMemberSeat);
				oldMemberSeat.cnvcOperName = seat.cnvcOperName;
				oldMemberSeat.cndOperDate = seat.cndOperDate;
				SingleCancelFMemberbook(trans,oldMemberSeat);
				trans.Commit();
				
			}
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
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
//					throw new BusinessException("�ǻ�Աȡ��չλԤ��","δԤ��չλ");
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
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
//				throw new BusinessException("չλԤ��","δԤ����չλ"+seat.cnvcSeat);
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
		/// ����λչλȡ��Ԥ��
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
					throw new BusinessException("ȡ��չλԤ��","��չλ����Ԥ��״̬��");
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}

		/// <summary>
		/// �ɷ�
		/// </summary>
		/// <param name="prepay"></param>
		/// <param name="member"></param>
		public void AddPrepay (Prepay prepay,string strMemberName)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();				
				trans = conn.BeginTransaction();
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				Decimal dSerialNo = EntityMapping.Create(serial,trans);

//				string strSql = "select * from tbPrepay where cnnJobID="+prepay.cnnJobID+" and cnvcPaperNo = '"+prepay.cnvcPaperNo+"'";
//				DataTable dtPrepay = SqlHelper.ExecuteDataTable(trans,CommandType.Text,strSql);
//				if (dtPrepay.Rows.Count > 0 )
//				{
//					Prepay oldPrepay = new Prepay(dtPrepay);
//					oldPrepay.cnnPrepay = prepay.cnnPrepay + oldPrepay.cnnPrepay;
//					oldPrepay.cnnBalance = oldPrepay.cnnBalance+prepay.cnnPrepay;
//					oldPrepay.cnvcOperName = prepay.cnvcOperName;
//					oldPrepay.cndOperDate = prepay.cndOperDate;
//					EntityMapping.Update(oldPrepay,trans);
//
//					PrepayLog prepayLog = new PrepayLog(oldPrepay.ToTable());
//					prepayLog.cnnSerialNo = dSerialNo;
//					EntityMapping.Create(prepayLog,trans);
//				}
//				else
//				{
				//prepay.cnnSerialNo = dSerialNo;
				EntityMapping.Create(prepay,trans);	
				PrepayLog prepayLog = new PrepayLog(prepay.ToTable());
				prepayLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(prepayLog,trans);
//					PrepayLog prepayLog = new PrepayLog(prepay.ToTable());
//					prepayLog.cnnSerialNo = dSerialNo;
//					EntityMapping.Create(prepayLog,trans);
				//}

				OperLog operLog = new OperLog(prepay.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_AddPrepay;
				EntityMapping.Create(operLog,trans);

				Bill bill = new Bill(prepay.ToTable());	
				bill.cnvcMemberName = strMemberName;
				bill.cnvcBillType = ConstApp.Bill_Type_AddPrepay;
				bill.cnnRepeats = 0;
				EntityMapping.Create(bill,trans);
						
				trans.Commit();
				
			}
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}

		/// <summary>
		/// չλԤ��
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
						throw new BusinessException("չλԤ��","��չλ�ѱ�ʹ��");
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}

		#endregion
		/// <summary>
		/// ȡ��չλԤ��
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
					throw new BusinessException("չλԤ��","��չλδ��Ԥ��");
					
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
						
		}

		#endregion

		/// <summary>
		/// ��Աչλǩ��
		/// </summary>
		/// <param name="seat"></param>
		/// <param name="strType"></param>
		/// <returns></returns>
		/// 
		#region
		public Member MemberSeatSignIn (MemberSeat seat,PrintedBill pBill)
		{
			//string strSeat = "";
			Member retMember = new Member();
			try
			{

				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();	
				

				Member member = new Member();
				member.cnvcMemberCardNo = seat.cnvcMemberCardNo;
//				member.cnvcMemberName=seat.cnvcMemberName;
				Member oldMember = EntityMapping.Get(member,trans) as Member;
				if (null == oldMember)
				{
					throw new BusinessException("��Աǩ��","δ�ҵ���Ա");
				}
				//��ˮ
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				Decimal dSerial = EntityMapping.Create(serial,trans);

				Decimal d2Serial = dSerial;

				oldMember.cnvcOperName = seat.cnvcOperName;
				oldMember.cndOperDate = seat.cndOperDate;

				string strEndDate = oldMember.cndOperDate.ToString("yyyy-MM-dd");
				if (DateTime.Parse(oldMember.cndEndDate) < DateTime.Parse(strEndDate))
				{
					//���ڻ�Ա��ʹ�ó�ֵ
					throw new BusinessException("ǩ��","��Ա�Ѿ����ڣ������·�����");
//					DataTable dtPrepay = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbPrepay where cnnJobID="+seat.cnnID+" and cnvcMemberCardNo='"+seat.cnvcMemberCardNo+"' and (cnvcState is null or cnvcState <> '"+ConstApp.Show_Seat_State_SignIn+"')");
//					if (dtPrepay.Rows.Count == 0)
//					{
//						throw new BusinessException("ǩ��","���ֵ");
//					}
//					int iPrepay = dtPrepay.Rows.Count;
//					foreach (DataRow drPrepay in dtPrepay.Rows)
//					{
//						if (iPrepay > 1)
//						{
//							d2Serial = EntityMapping.Create(serial,trans);
//						}
//						
//
//						Prepay prepay = new Prepay(drPrepay);
//						prepay.cnvcState = ConstApp.Show_Seat_State_SignIn;
//						prepay.cnvcOperName = seat.cnvcOperName;
//						prepay.cndOperDate = seat.cndOperDate;
//						EntityMapping.Update(prepay,trans);
//
//						PrepayLog prepayLog = new PrepayLog(prepay.ToTable());
//						prepayLog.cnnSerialNo = d2Serial;
//						EntityMapping.Create(prepayLog,trans);
//					}
				}	
				else
				{
				    //δ���ڻ�Աʹ����ѳ���
					retMember.cnvcFree = oldMember.cnvcFree;
					if (oldMember.cnvcFree != ConstApp.Free_Time_NoLimit)
					{					
						if (int.Parse(oldMember.cnvcFree) < 1)
						{
							throw new BusinessException("ǩ��","���ֵ");
							//��ѳ��������ó�ֵ
							//DataTable dtPrepay = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbPrepay where cnnJobID="+seat.cnnID+" and cnvcMemberCardNo='"+seat.cnvcMemberCardNo+"' and (cnvcState is null or cnvcState <> '"+ConstApp.Show_Seat_State_SignIn+"')");
//							if (dtPrepay.Rows.Count == 0)
//							{
//								throw new BusinessException("ǩ��","���ֵ");
//							}
//							int iPrepay = dtPrepay.Rows.Count;
//							foreach (DataRow drPrepay in dtPrepay.Rows)
//							{
//								if (iPrepay > 1)
//								{
//									d2Serial = EntityMapping.Create(serial,trans);
//								}
//								
//								Prepay prepay = new Prepay(drPrepay);
//								prepay.cnvcState = ConstApp.Show_Seat_State_SignIn;
//								prepay.cnvcOperName = seat.cnvcOperName;
//								prepay.cndOperDate = seat.cndOperDate;
//								EntityMapping.Update(prepay,trans);
//
//								PrepayLog prepayLog = new PrepayLog(prepay.ToTable());
//								prepayLog.cnnSerialNo = d2Serial;
//								EntityMapping.Create(prepayLog,trans);
//							}
//							retMember.cnvcFree = "";
						
						}
						else
						{
							//��ѳ���-1
							string strFree = (int.Parse(oldMember.cnvcFree)-1).ToString();
							oldMember.cnvcFree = strFree;					
							EntityMapping.Update(oldMember,trans);	
	
							retMember.cnvcFree = oldMember.cnvcFree;
						}
					
					
					}
				}
				MemberLog memberLog = new MemberLog(oldMember.ToTable());
				memberLog.cnnSerialNo = dSerial;
				EntityMapping.Create(memberLog,trans);

				

				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcMemberCardNo = '"+seat.cnvcMemberCardNo+"' and cnvcState = '"+ConstApp.Show_Seat_State_Booking+"'");	
				DataTable dtMemberSeatSignIn = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcMemberCardNo = '"+seat.cnvcMemberCardNo+"' and cnvcState = '"+ConstApp.Show_Seat_State_SignIn+"'");	
				
				if (dtMemberSeat.Rows.Count == 0)
				{
					if (dtMemberSeatSignIn.Rows.Count > 0)
					{
						throw new BusinessException("��Աǩ��","��ǩ����");
					}
					else
					{
						throw new BusinessException("��Աǩ��","δԤ��չλ��");
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
					memberSeat.cnvcMemberName=pBill.cnvcMemberName;
					memberSeat.cnvcState = ConstApp.Show_Seat_State_SignIn;
					EntityMapping.Update(memberSeat,trans);

					MemberSeatLog memberSeatLog = new MemberSeatLog(memberSeat.ToTable());
					memberSeatLog.cnnSerialNo = d2Serial;
					EntityMapping.Create(memberSeatLog,trans);

					retMember.cnvcSales += memberSeat.cnvcSeat+",";

					DataTable dtShowSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbShowSeat where cnnJobID="+memberSeat.cnnID+" and cnvcSeat = '"+memberSeat.cnvcSeat+"' and cnvcFloor='"+memberSeat.cnvcFloor+"'");	
					if (dtShowSeat.Rows.Count == 0)
					{
						throw new BusinessException("��Աǩ��","δԤ��չλ��");
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
				signInLog.cnvcSeat = retMember.cnvcSales;
				EntityMapping.Create(signInLog,trans);
						
				Bill bill = new Bill(pBill.ToTable());				
				bill.cnvcBillType = ConstApp.Bill_Type_SignIn;
				bill.cnnRepeats = 0;
				bill.cnvcSeat = retMember.cnvcSales;
				bill.cndOperDate = DateTime.Now;
				bill.cnvcMemberName = pBill.cnvcMemberName;
				EntityMapping.Create(bill,trans);

				OperLog operLog = new OperLog(seat.ToTable());
				operLog.cnnSerialNo = dSerial;
				if (operLog.cnvcOperName == operLog.cnvcMemberCardNo)
				{
					operLog.cniSynch = 2;
				}
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_MemberSignIn;
				EntityMapping.Create(operLog,trans);

                //���ִ��� 20110211
                MemberManageFacade mmf = new MemberManageFacade();
                mmf.PointsAdd(trans, ConstApp.PointsMF, oldMember.cnvcMemberRight, oldMember.cnvcMemberCardNo, oldMember.cnvcOperName, oldMember.cndOperDate, 0);
                //////////////////////////////////////////////////
				trans.Commit();
				
			}
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
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
					throw new BusinessException("��Աǩ��","δ�ҵ���Ա");
				}
				//��ˮ
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				Decimal dSerial = EntityMapping.Create(serial,trans);

				Decimal d2Serial = dSerial;

				oldMember.cnvcOperName = seat.cnvcOperName;
				oldMember.cndOperDate = seat.cndOperDate;

				string strEndDate = oldMember.cndOperDate.ToString("yyyy-MM-dd");
				if (DateTime.Parse(oldMember.cndEndDate) < DateTime.Parse(strEndDate))
				{
					//���ڻ�Ա��ʹ�ó�ֵ
					DataTable dtPrepay = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbPrepay where cnnJobID="+seat.cnnID+" and cnvcMemberCardNo='"+seat.cnvcMemberCardNo+"' and (cnvcState is null or cnvcState <> '"+ConstApp.Show_Seat_State_SignIn+"')");
					if (dtPrepay.Rows.Count == 0)
					{
						throw new BusinessException("ǩ��","���ֵ");
					}
					int iPrepay = dtPrepay.Rows.Count;
					foreach (DataRow drPrepay in dtPrepay.Rows)
					{
						if (iPrepay > 1)
						{
							d2Serial = EntityMapping.Create(serial,trans);
						}
						

						Prepay prepay = new Prepay(drPrepay);
						prepay.cnvcState = ConstApp.Show_Seat_State_SignIn;
						prepay.cnvcOperName = seat.cnvcOperName;
						prepay.cndOperDate = seat.cndOperDate;
						EntityMapping.Update(prepay,trans);

						PrepayLog prepayLog = new PrepayLog(prepay.ToTable());
						prepayLog.cnnSerialNo = d2Serial;
						EntityMapping.Create(prepayLog,trans);
					}
				}	
				else
				{
					//δ���ڻ�Աʹ����ѳ���
					if (oldMember.cnvcFree != ConstApp.Free_Time_NoLimit)
					{					
						if (int.Parse(oldMember.cnvcFree) < 1)
						{
							//��ѳ��������ó�ֵ
							DataTable dtPrepay = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbPrepay where cnnJobID="+seat.cnnID+" and cnvcMemberCardNo='"+seat.cnvcMemberCardNo+"' and (cnvcState is null or cnvcState <> '"+ConstApp.Show_Seat_State_SignIn+"')");
							if (dtPrepay.Rows.Count == 0)
							{
								throw new BusinessException("ǩ��","���ֵ");
							}
							int iPrepay = dtPrepay.Rows.Count;
							foreach (DataRow drPrepay in dtPrepay.Rows)
							{
								if (iPrepay > 1)
								{
									d2Serial = EntityMapping.Create(serial,trans);
								}
								
								Prepay prepay = new Prepay(drPrepay);
								prepay.cnvcState = ConstApp.Show_Seat_State_SignIn;
								prepay.cnvcOperName = seat.cnvcOperName;
								prepay.cndOperDate = seat.cndOperDate;
								EntityMapping.Update(prepay,trans);

								PrepayLog prepayLog = new PrepayLog(prepay.ToTable());
								prepayLog.cnnSerialNo = d2Serial;
								EntityMapping.Create(prepayLog,trans);
							}
						
						}
						else
						{
							//��ѳ���-1
							string strFree = (int.Parse(oldMember.cnvcFree)-1).ToString();
							oldMember.cnvcFree = strFree;					
							EntityMapping.Update(oldMember,trans);		
						}
					
					
					}
				}
				MemberLog memberLog = new MemberLog(oldMember.ToTable());
				memberLog.cnnSerialNo = dSerial;
				EntityMapping.Create(memberLog,trans);

				

				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcMemberCardNo = '"+seat.cnvcMemberCardNo+"' and cnvcState = '"+ConstApp.Show_Seat_State_Booking+"'");	
				
				DataTable dtMemberSeatSignIn = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcMemberCardNo = '"+seat.cnvcMemberCardNo+"' and cnvcState = '"+ConstApp.Show_Seat_State_SignIn+"'");	
				
				if (dtMemberSeat.Rows.Count == 0)
				{
					if (dtMemberSeatSignIn.Rows.Count > 0)
					{
						throw new BusinessException("��Աǩ��","��ǩ����");
					}
					else
					{
						throw new BusinessException("��Աǩ��","δԤ��չλ��");
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
						throw new BusinessException("��Աǩ��","δԤ��չλ��");
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
			return strSeat;
						
		}

		#endregion
		/// <summary>
		/// �ǻ�Աǩ��
		/// </summary>
		/// <param name="seat"></param>
		/// <returns></returns>
		/// 
		#region
		public string FMemberSeatSignIn (MemberSeat seat)
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
					throw new BusinessException("�ǻ�Աǩ��","δ�ҵ��ǻ�Ա");
				}
				//��ˮ
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				Decimal dSerial = EntityMapping.Create(serial,trans);

				Decimal d2Serial = dSerial;

				oldFMember.cnvcOperName = seat.cnvcOperName;
				oldFMember.cndOperDate = seat.cndOperDate;

				DataTable dtPrepay = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbPrepay where (cnvcMemberCardNo is null or cnvcMemberCardNo = '') and cnnJobID="+seat.cnnID+" and cnvcPaperNo='"+seat.cnvcPaperNo+"' and (cnvcState is null or cnvcState <> '"+ConstApp.Show_Seat_State_SignIn+"')");
//				if (dtPrepay.Rows.Count == 0)
//				{
//					throw new BusinessException("�ǻ�Աǩ��","��ɷ�");
//				}
				int iPrepay = dtPrepay.Rows.Count;
				foreach (DataRow drPrepay in dtPrepay.Rows)
				{
					if (iPrepay > 1)
					{
						d2Serial = EntityMapping.Create(serial,trans);
					}
					

					Prepay prepay = new Prepay(drPrepay);
					prepay.cnvcState = ConstApp.Show_Seat_State_SignIn;
					EntityMapping.Update(prepay,trans);

					PrepayLog prepayLog = new PrepayLog(prepay.ToTable());
					prepayLog.cnnSerialNo = d2Serial;
					EntityMapping.Create(prepayLog,trans);
				}
				
				
				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcMemberCardNo is null and cnvcPaperNo = '"+seat.cnvcPaperNo+"' and cnvcState = '"+ConstApp.Show_Seat_State_Booking+"'");	
				DataTable dtMemberSeatSignIn = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcMemberCardNo is null and cnvcPaperNo = '"+seat.cnvcPaperNo+"' and cnvcState = '"+ConstApp.Show_Seat_State_SignIn+"'");	
				
				if (dtMemberSeat.Rows.Count == 0)
				{
					if (dtMemberSeatSignIn.Rows.Count > 0)
					{
						throw new BusinessException("�ǻ�Աǩ��","��ǩ����");
					}
					else
					{
						throw new BusinessException("�ǻ�Աǩ��","δԤ��չλ��");
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
						throw new BusinessException("�ǻ�Աǩ��","δԤ��չλ��");
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
//				bill.cnvcMemberName = fmember.cnvcMemberName;
				//bill.cnvcMemberName = seat.cnvcMemberName;
				EntityMapping.Create(bill,trans);

				OperLog operLog = new OperLog(seat.ToTable());
				operLog.cnnSerialNo = dSerial;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_FMemberSignIn;
				EntityMapping.Create(operLog,trans);

				trans.Commit();
				
			}
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
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
					throw new BusinessException("�ǻ�Աǩ��","δ�ҵ��ǻ�Ա");
				}
				//��ˮ
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				Decimal dSerial = EntityMapping.Create(serial,trans);

				Decimal d2Serial = dSerial;

				oldFMember.cnvcOperName = seat.cnvcOperName;
				oldFMember.cndOperDate = seat.cndOperDate;

				DataTable dtPrepay = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbPrepay where (cnvcMemberCardNo is null or cnvcMemberCardNo = '') and cnnJobID="+seat.cnnID+" and cnvcPaperNo='"+seat.cnvcPaperNo+"' and (cnvcState is null or cnvcState <> '"+ConstApp.Show_Seat_State_SignIn+"')");
//				if (dtPrepay.Rows.Count == 0)
//				{
//					throw new BusinessException("�ǻ�Աǩ��","��ɷ�");
//				}
				int iPrepay = dtPrepay.Rows.Count;
				foreach (DataRow drPrepay in dtPrepay.Rows)
				{
					if (iPrepay > 1)
					{
						d2Serial = EntityMapping.Create(serial,trans);
					}
					

					Prepay prepay = new Prepay(drPrepay);
					prepay.cnvcState = ConstApp.Show_Seat_State_SignIn;
					EntityMapping.Update(prepay,trans);

					PrepayLog prepayLog = new PrepayLog(prepay.ToTable());
					prepayLog.cnnSerialNo = d2Serial;
					EntityMapping.Create(prepayLog,trans);
				}
				
				
				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcMemberCardNo is null and cnvcPaperNo = '"+seat.cnvcPaperNo+"' and cnvcState = '"+ConstApp.Show_Seat_State_Booking+"'");	
				DataTable dtMemberSeatSignIn = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcMemberCardNo is null and cnvcPaperNo = '"+seat.cnvcPaperNo+"' and cnvcState = '"+ConstApp.Show_Seat_State_SignIn+"'");	
				
				if (dtMemberSeat.Rows.Count == 0)
				{
					if (dtMemberSeatSignIn.Rows.Count > 0)
					{
						throw new BusinessException("�ǻ�Աǩ��","��ǩ����");
					}
					else
					{
						throw new BusinessException("�ǻ�Աǩ��","δԤ��չλ��");
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
						throw new BusinessException("�ǻ�Աǩ��","δԤ��չλ��");
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
				//LogAdapter.WriteFeaturesException(ex);	
				throw new BusinessException("�����쳣",ex.Message);
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
				string strPrepay = "select * from tbPrepay where cnnJobID="+job.cnnJobID.ToString()+" and cnvcState is null";
				string strMember = "select *  from tbMember where cnvcState ='"+ConstApp.Card_State_InUse+"'";
				DataTable dtMemberSeat = SqlHelper.ExecuteDataTable(trans,CommandType.Text,strMemberSeatSql);
				DataTable dtPrepay = SqlHelper.ExecuteDataTable(trans,CommandType.Text,strPrepay);
				DataTable dtMember = SqlHelper.ExecuteDataTable(trans,CommandType.Text,strMember);
				

				if (dtMemberSeat.Rows.Count > 0)
				{
					foreach (DataRow drMemberSeat in dtMemberSeat.Rows)
					{
						MemberSeat ms = new MemberSeat(drMemberSeat);
						ms.cnvcOperName = job.cnvcOperName;
						ms.cndOperDate = job.cndOperDate;
						if (ms.cnvcMemberCardNo.Length > 0)
						{
							//��Ա
							DataRow[] drMembers = dtMember.Select("cnvcMemberCardNo='"+ms.cnvcMemberCardNo+"'");
							if (drMembers.Length == 1)
							{
								Member member = new Member(drMembers[0]);																
								DateTime dtEndDate = DateTime.Parse(member.cndEndDate);
								if (dtEndDate > DateTime.Now)
								{
									//��ˮ
									SeqSerialNo serial = new SeqSerialNo();
									serial.cnvcFill = "0";
									Decimal dSerial = EntityMapping.Create(serial,trans);
									if (member.cnvcFree != ConstApp.Free_Time_NoLimit)
									{
										int iFree = int.Parse(member.cnvcFree);
										if (iFree > 0 )
										{
											//����ǩ��
											

											//��ѳ���-1									
											string strFree = (iFree-1).ToString();
											member.cnvcFree = strFree;	
											member.cnvcOperName = job.cnvcOperName;
											member.cndOperDate = job.cndOperDate;
											EntityMapping.Update(member,trans);	

											MemberLog memberLog = new MemberLog(member.ToTable());
											memberLog.cnnSerialNo = dSerial;
											EntityMapping.Create(memberLog,trans);
										}
									}																									
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
									//ǩ����־
									SignInLog signInLog = new SignInLog(ms.ToTable());
									signInLog.cnnJobID = ms.cnnID;
									signInLog.cnnSerialNo = dSerial;									
									EntityMapping.Create(signInLog,trans);
									//������־
									OperLog operLog = new OperLog(ms.ToTable());
									operLog.cnnSerialNo = dSerial;									
									operLog.cnvcOperFlag = ConstApp.Oper_Flag_MemberSignIn;
									EntityMapping.Create(operLog,trans);

								}
								
								
								
							}
						}
						else
						{
							//�ǻ�Ա
							DataRow[] drPrepays = dtPrepay.Select("cnvcPaperNo='"+ms.cnvcPaperNo+"'");
							if (drPrepays.Length > 0)
							{
								//����ǩ��
								//��ˮ
								SeqSerialNo serial = new SeqSerialNo();
								serial.cnvcFill = "0";
								Decimal dSerial = EntityMapping.Create(serial,trans);

								Decimal d2Serial = dSerial;
								int iPrepay = drPrepays.Length;
								foreach (DataRow drPrepay in drPrepays)
								{
									if (iPrepay > 1)
									{
										d2Serial = EntityMapping.Create(serial,trans);
									}
					

									Prepay prepay = new Prepay(drPrepay);
									prepay.cnvcOperName = job.cnvcOperName;
									prepay.cndOperDate = job.cndOperDate;
									prepay.cnvcState = ConstApp.Show_Seat_State_SignIn;
									EntityMapping.Update(prepay,trans);

									PrepayLog prepayLog = new PrepayLog(prepay.ToTable());
									prepayLog.cnnSerialNo = d2Serial;
									EntityMapping.Create(prepayLog,trans);									
								}

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
									showSeatLog.cnnSerialNo = d2Serial;
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
			catch (BusinessException bex) //ҵ���쳣
			{	
				//����ع�					
				trans.Rollback();	
				//LogAdapter.WriteBusinessException(bex);
				throw new BusinessException(bex.Type,bex.Message);		
			}
			catch (SqlException sex)   //���ݿ��쳣
			{
				//����ع�					
				trans.Rollback();												
				//LogAdapter.WriteDatabaseException(sex);				
				throw new BusinessException("���ݿ��쳣",sex.Message);
			}
			catch (Exception ex)		 //�����쳣
			{
				//����ع�						
				trans.Rollback();						
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
