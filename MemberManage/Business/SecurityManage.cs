

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
using ynhrMemberManage.MemberManage.Common;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Net;
using ynhrMemberManage.CardCommon.CardRef;
using ynhrMemberManage.CardCommon.CardDef;

namespace MemberManage.Business
{
	/// <summary>
	/// ��ȫ����
	/// </summary>
	public class SecurityManage
	{
		/// <summary>
		/// ��ǰ���ݿ�����
		/// </summary>
		private SqlTransaction trans = null;
		/// <summary>
		/// ��ǰ���ݿ�����
		/// </summary>
		private SqlConnection conn = null;
		/// <summary>
		/// ����ԱȨ���б�
		/// </summary>
		public ArrayList alOperFunc = null;
		public Oper oper = null;
		public int iDiscount = 100;		

		public SecurityManage()
		{
			//
			// TODO: Add constructor logic here
			//
			//OperLogin(OperName,PWD);
		}
		/// <summary>
		/// ����Ա��¼
		/// </summary>
		/// <param name="OperName"></param>
		/// <param name="PWD"></param>
		public void OperLogin(string OperName,string PWD)
		{
			alOperFunc = new ArrayList();	
			oper = new Oper();
			try
			{

				conn = ConnectionPool.BorrowConnection();
				//trans = conn.BeginTransaction();
				//��ȫ�ȶ�			
				DataTable dtOper = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbOper where cnvcOperName = '"+OperName+"' and cnvcPwd = '"+PWD+"'");
				if (null == dtOper)
				{
					throw new BusinessException("����Ա��¼","����Ա���ƻ��������");
				}
				if (dtOper.Rows.Count == 0)
				{
					throw new BusinessException("����Ա��¼","����Ա���ƻ��������");
				}
				oper = new Oper(dtOper);
				//����Ա�����б�
				if (oper.cnnDeptID != 0)//=0Ϊϵͳ����Ա
				{
					//ϵͳ����Ա��������Ȩ��				
					//����ȶ�Ȩ���б�
					DataTable dtOperFunc = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbOperFunc where cnnOperID = "+oper.cnnOperID);
				
					foreach (DataRow dr in dtOperFunc.Rows)
					{
						FuncList funcList = new FuncList(dr);
						alOperFunc.Add(funcList.cnvcFuncCode);
					}
					if (alOperFunc.Count == 0)
					{
						throw new BusinessException("����Ա��¼","����Ա���κ�Ȩ�ޣ�");
					}
				}
				if (oper.cnnDeptID == 0)
				{
					iDiscount = 0;
				}
				else
				{
					Dept dept = new Dept();
					dept.cnnDeptID = oper.cnnDeptID;
					Dept oldDept = EntityMapping.Get(dept,conn) as Dept;
					iDiscount = oldDept.cnnDiscount;
				}
				
				//�ۿ�����
				//trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
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
		public string OperCardCallBack()
		{
			string strRet3 = "";
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				CardM1 m1=new CardM1();
				string strCardNo = "";
				string strRet = m1.ReadCard(out strCardNo);//,out dtemp,out itemp);

				if (strRet != ConstMsg.RFOK)
				{
					strRet3 += " ����ʧ��";
				}		
				DataTable dtOper = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbOper where cnvcCardNo is not null and cnvcCardNo='"+strCardNo+"'");
				
				if (dtOper.Rows.Count == 0)
				{
					strRet3 += " ����Ա������";
				}
				else
				{
					Oper oldOper = new Oper(dtOper);
					oldOper.cnvcCardNo = "";
					EntityMapping.Update(oldOper,trans);
					//��ˮ
					SeqSerialNo serial = new SeqSerialNo();
					serial.cnvcFill = "0";
					decimal dSerialNo = EntityMapping.Create(serial,trans);

					//������־
					OperLog operLog = new OperLog();
					operLog.cnnSerialNo = dSerialNo;
					operLog.cnvcOperName = Login.constApp.oper.cnvcOperName;//member.cnvcOperName;
					operLog.cndOperDate = DateTime.Now;
					operLog.cnvcOperFlag = ConstApp.Oper_Flag_OperInCallBack;
					EntityMapping.Create(operLog,trans);
				}	
				trans.Commit();
				string strRet2 = m1.RecycleCard();
				if (strRet != ConstMsg.RFOK)
				{
					strRet3 += " ����Ա������ʧ��";
				}					
				
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
			return strRet3;

		}

		public void LoginLog(OperLogin login)
		{			
			try
			{

				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();

				string strHostName = Environment.MachineName;
				IPHostEntry oIPHost=Dns.Resolve(Environment.MachineName);
				string strHostIP = "";
				if(oIPHost.AddressList.Length>0)
					strHostIP=oIPHost.AddressList[0].ToString();	
			
				login.cnvcHostName = strHostName;
				login.cnvcHostAddress = strHostIP;

				SeqSerialNo serialNo = new SeqSerialNo();
				serialNo.cnvcFill = "0";
				login.cnnSerialNp = EntityMapping.Create(serialNo,trans);
				EntityMapping.Create(login,trans);
				//�ۿ�����
				trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
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
		public void SetDeptManager(Dept dept)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbDept set cnvcManager = '"+dept.cnvcManager+"' where cnnDeptID = "+dept.cnnDeptID);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

		public void DragOper(Oper oper)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbOper set cnnDeptID = "+oper.cnnDeptID+" where cnnOperID = "+oper.cnnOperID);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

		public void DragDept(Dept dept)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbDept set cnnParentDeptID = "+dept.cnnParentDeptID+" where cnnDeptID = "+dept.cnnDeptID);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

		public void ModifyPwdByOperID(Oper opers)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbOper set cnvcPwd = '"+opers.cnvcPwd+"' where cnnOperID = "+opers.cnnOperID.ToString());				
				
				trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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
		
		public void ModifyPwd(Oper opers)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbOper set cnvcPwd = '"+opers.cnvcPwd+"' where cnvcOperName = '"+opers.cnvcOperName+"'");				
				
				trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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
		
		public void AddOper(Oper opers)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				
				trans = conn.BeginTransaction();
				DataTable dtOper = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbOper where cnvcOperName = '"+opers.cnvcOperName+"'");
				if (dtOper.Rows.Count > 0)
				{
					throw new BusinessException("����Ա����","����Ա�Ѵ��ڣ�");
				}
				if (opers.cnvcCardNo.Length > 0)
				{
					DataTable dtCard = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbOper where cnvcCardNo = 'aaa"+opers.cnvcCardNo+"'");
					if (dtCard.Rows.Count > 0)
					{
						throw new BusinessException("����Ա����","����Ա�����Ѵ��ڣ�");
					}
					CardM1 m1 = new CardM1();
					string strReturn = m1.PutOutCard("aaa"+opers.cnvcCardNo,-1,-1);
					if (strReturn.Equals("OPSUCCESS"))
					{
						opers.cnvcCardNo = "aaa"+opers.cnvcCardNo;
						EntityMapping.Create(opers,trans);	
						trans.Commit();
					}
					else
					{
						throw new BusinessException("�������쳣",strReturn);
					}
				}
				else
				{
					EntityMapping.Create(opers,trans);	
					trans.Commit();
				}
						
				
				
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

		public void AddCard(Oper opers)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				
				trans = conn.BeginTransaction();
				
				DataTable dtOper = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbOper where cnvcCardNo is not null and cnvcCardNo = 'aaa"+opers.cnvcCardNo+"'");
				if (dtOper.Rows.Count > 0)
				{
					throw new BusinessException("����Ա����","����Ա�����Ѵ��ڣ�");
				}
				CardM1 m1 = new CardM1();
				string strReturn = m1.PutOutCard("aaa"+opers.cnvcCardNo,-1,-1);
				if (strReturn.Equals("OPSUCCESS"))
				{
					SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbOper set cnvcCardNo = 'aaa"+opers.cnvcCardNo+"' where cnnOperID="+opers.cnnOperID.ToString());
					trans.Commit();
				}
				else
				{
					throw new BusinessException("�������쳣",strReturn);
				}
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

		public void CancelCard(Oper opers)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				
				trans = conn.BeginTransaction();
				Oper oldOper = EntityMapping.Get(opers,trans) as Oper;
				//DataTable dtOper = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbOper where cnvcCardNo is not null and cnvcCardNo = 'aaa"+opers.cnvcCardNo+"'");
				if (null == oldOper)
				{
					throw new BusinessException("����Ա����","δ�ҵ�����Ա��");
				}
				oldOper.cnvcCardNo = "";
				EntityMapping.Update(opers,trans);
				trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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


		public void ModifyOper(Oper opers)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbOper set cnvcOperName = '"+opers.cnvcOperName+"' where cnnOperID="+opers.cnnOperID.ToString());
				//SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update");
				//EntityMapping.Update(opers,trans);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

		public void DeleteOper(Oper opers)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Delete(opers,trans);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

		public DataTable getOper(Oper opers)
		{
			DataTable dtOper = null;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				dtOper = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select a.cnnOperID as ����ԱID,a.cnvcOperName as ����Ա����,b.cnvcDeptName as �������� from tbOper a left outer join tbDept b on a.cnnDeptID=b.cnnDeptID where a.cnvcOperName<>'admin' and ( a.cnvcOperName like '%"+opers.cnvcOperName+"%' or cnvcDeptName like '%"+opers.cnvcPwd+"%')");
				//trans = conn.BeginTransaction();
				//EntityMapping.Create(opers,trans);				
				
				//trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
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
			return dtOper;

		}

		public DataTable getOpers()
		{
			DataTable dtOper = null;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				dtOper = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbOper where cnvcOperName <> 'admin'");
				//trans = conn.BeginTransaction();
				//EntityMapping.Create(opers,trans);				
				
				//trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
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
			return dtOper;

		}
		public DataTable getAllOper()
		{
			DataTable dtOper = null;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				dtOper = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select a.cnnOperID as ����ԱID,a.cnvcOperName as ����Ա����,b.cnvcDeptName as �������� from tbOper a left outer join tbDept b on a.cnnDeptID=b.cnnDeptID where a.cnvcOperName <> 'admin'");
				//trans = conn.BeginTransaction();
				//EntityMapping.Create(opers,trans);				
				
				//trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
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
			return dtOper;

		}
		public DataTable getAllOperByDept(string strDeptID)
		{
			DataTable dtOper = null;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				dtOper = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbOper where cnnDeptID = "+strDeptID);
				//trans = conn.BeginTransaction();
				//EntityMapping.Create(opers,trans);				
				
				//trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
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
			return dtOper;

		}

		public DataTable getAllOperNoSys(Oper opers)
		{
			DataTable dtOper = null;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				if (opers.cnnDeptID == 0)
				{
					dtOper = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbOper where cnnDeptID <> 0");
				}
				else
				{

					DataTable dtManage = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbDept where cnvcManager = '"+opers.cnvcOperName+"'");
					if (dtManage.Rows.Count != 1)
					{
						dtOper = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbOper where cnnDeptID = "+opers.cnnDeptID);
					}
					else
					{
						Dept dept = new Dept(dtManage);
						dtOper = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbOper where cnnDeptID = "+dept.cnnDeptID.ToString());
					}
					
				}
				
				//trans = conn.BeginTransaction();
				//EntityMapping.Create(opers,trans);				
				
				//trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
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
			return dtOper;

		}

		public void AddDept(Dept dept)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Create(dept,trans);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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
		public void ModifyDept(Dept dept)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Update(dept,trans);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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
		public void DeleteDept(Dept dept)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Delete(dept,trans);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

		public DataTable getDept(Dept dept)
		{
			DataTable dtDept;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				dtDept = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select cnnDeptID as ����ID,cnvcDeptName as ��������,cnnParentDeptID as �ϼ�����ID,cnvcManager as ���Ź���Ա,cnnDiscount as �����ۿ�����,cnvcComments as ���� from tbDept where cnvcDeptName like '%"+dept.cnvcDeptName+"%' or cnnParentDeptID like '%"+dept.cnnParentDeptID.ToString()+"%'");
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				//trans.Rollback();
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

			return dtDept;
		}

		public DataTable getAllDept()
		{
			DataTable dtDept = null;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				dtDept = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select cnnDeptID as ����ID,cnvcDeptName as ��������,cnnParentDeptID as �ϼ�����ID,cnvcManager as ���Ź���Ա,cnnDiscount as �����ۿ����� from tbDept");
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				//trans.Rollback();
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
			return dtDept;

		}


		public void AddOperFunc(OperFunc func)
		{

			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Create(func,trans);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

		public void AddOperFunc(ArrayList alOperFuncList,int iOperID)
		{

			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				for (int i = 0;i<alOperFuncList.Count;i++)
				{
					string strFuncCode = alOperFuncList[i].ToString();
					OperFunc func = new OperFunc();
					func.cnnOperID = iOperID;
					func.cnvcFuncCode = strFuncCode;
					OperFunc oldFunc = EntityMapping.Get(func,trans) as OperFunc;
					if (null == oldFunc)
					{
						EntityMapping.Create(func,trans);
					}					
				}
				
				trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

		public void ModifyOperFunc(ArrayList alOperFuncList,int iOperID)
		{

			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"delete from tbOperFunc where cnnOperID = "+iOperID.ToString());
				for (int i = 0;i<alOperFuncList.Count;i++)
				{
					string strFuncCode = alOperFuncList[i].ToString();
					OperFunc func = new OperFunc();
					func.cnnOperID = iOperID;
					func.cnvcFuncCode = strFuncCode;
					EntityMapping.Create(func,trans);
				}			
				
				trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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
		public void DeleteOperFunc(OperFunc func)
		{

			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Delete(func,trans);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

		public DataTable QueryOperFunc(int iOperID)
		{
			DataTable dtOperFunc = null;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				dtOperFunc = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbOperFunc where cnnOperID = "+iOperID.ToString());
				//trans = conn.BeginTransaction();
				//EntityMapping.Delete(func,trans);				
				
				//trans.Commit();
			}
			catch (BusinessException bex) //ҵ���쳣
			{		
				//LogAdapter.WriteBusinessException(bex);
				//trans.Rollback();
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
			return dtOperFunc;
		}
	}
}
