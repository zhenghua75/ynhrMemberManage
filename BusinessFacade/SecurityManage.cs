

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
using System.Net;
using ynhrMemberManage.CardCommon.CardRef;
using ynhrMemberManage.CardCommon.CardDef;
using ynhrMemberManage.Common;
using System.Collections.Generic;

namespace ynhrMemberManage.Business
{
	/// <summary>
	/// 安全管理
	/// </summary>
	public class SecurityManage
	{
		/// <summary>
		/// 当前数据库事务
		/// </summary>
		private SqlTransaction trans = null;
		/// <summary>
		/// 当前数据库连接
		/// </summary>
		private SqlConnection conn = null;
		/// <summary>
		/// 操作员权限列表
		/// </summary>
		public ArrayList alOperFunc = null;
		public Oper oper = null;
		public int iDiscount = 100;		

		public SecurityManage()
		{
		}
		/// <summary>
		/// 操作员登录
		/// </summary>
		/// <param name="OperName"></param>
		/// <param name="PWD"></param>
        public void OperLogin(string OperName)
        {
            alOperFunc = new ArrayList();
            oper = new Oper();

            //安全比对			
            DataTable dtOper = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbOper where cnvcOperName = '" + OperName + "'");
            if (null == dtOper)
            {
                throw new BusinessException("操作员登录", "操作员名称或密码错误！");
            }
            if (dtOper.Rows.Count == 0)
            {
                throw new BusinessException("操作员登录", "操作员名称或密码错误！");
            }
            oper = new Oper(dtOper);
            //操作员功能列表
            if (oper.cnnDeptID != 0)//=0为系统管理员
            {
                //系统管理员具有所有权限				
                //否则比对权限列表
                DataTable dtOperFunc = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbOperFunc where cnnOperID = " + oper.cnnOperID);

                foreach (DataRow dr in dtOperFunc.Rows)
                {
                    FuncList funcList = new FuncList(dr);
                    alOperFunc.Add(funcList.cnvcFuncCode);
                }
                DataTable dtDeptFunc = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbDeptFunc where cnnDeptID = " + oper.cnnDeptID);
                foreach (DataRow dr in dtDeptFunc.Rows)
                {
                    FuncList funcList = new FuncList(dr);
                    if(!alOperFunc.Contains(funcList.cnvcFuncCode))
                    alOperFunc.Add(funcList.cnvcFuncCode);
                }
                if (alOperFunc.Count == 0)
                {
                    throw new BusinessException("操作员登录", "操作员无任何权限！");
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
                Dept oldDept = EntityMapping.Get(dept) as Dept;
                iDiscount = oldDept.cnnDiscount;
            }

            //折扣上限

        }
        public Oper GetOperByName(string strOperName)
        {
            DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbOper where cnvcOperName='"+strOperName+"'");
            if (dt.Rows.Count == 0) throw new BusinessException("操作员", "获取操作员错误！");
            return new Oper(dt);
        }
        public Dept GetDeptById(int deptid)
        {
            Dept dept = new Dept();
            dept.cnnDeptID = deptid;
            return EntityMapping.Get(dept) as Dept;            
        }
        public List<string> GetFuncById(int operid, int deptid, string strCardType, string strL6Name, string strL8Name)
        {
            List<string> lFunc = new List<string>();
            //系统管理员具有所有权限				
            //否则比对权限列表
            string strdeptsql = "";
            string stropersql = "";
            switch (strCardType)
            {
                case "l6":
                    strdeptsql = "select * from tbDeptFunc where cnnDeptID = " + deptid + " and cnvcCardType in('l6','l6l8')";
                    stropersql = "select * from tbOperFunc where cnnOperID = " + operid + " and cnvcCardType in('l6','l6l8')";
                    break;
                case "l8":
                    strdeptsql = "select * from tbDeptFunc where cnnDeptID = " + deptid + " and cnvcCardType in('l8','l6l8')";
                    stropersql = "select * from tbOperFunc where cnnOperID = " + operid + " and cnvcCardType in('l8','l6l8')";
                    break;
                case "l6l8":
                    strdeptsql = "select * from tbDeptFunc where cnnDeptID = " + deptid + " and cnvcCardType in('l6','l8','l6l8')";
                    stropersql = "select * from tbOperFunc where cnnOperID = " + operid + " and cnvcCardType in('l6','l8','l6l8')";
                    break;
            }
            DataTable dtOperFunc = SqlHelper.ExecuteDataTable(CommandType.Text, stropersql);//"select * from tbOperFunc where cnnOperID = " + operid+" and cnvcCardType='"+strCardType+"'");

            foreach (DataRow dr in dtOperFunc.Rows)
            {
                FuncList funcList = new FuncList(dr);
                funcList.cnvcFuncCode = funcList.cnvcFuncCode.Replace("一通卡", strL6Name);
                funcList.cnvcFuncCode = funcList.cnvcFuncCode.Replace("记次卡", strL8Name);
                lFunc.Add(funcList.cnvcFuncCode);
            }
            DataTable dtDeptFunc = SqlHelper.ExecuteDataTable(CommandType.Text, strdeptsql);//"select * from tbDeptFunc where cnnDeptID = " + deptid+" and cnvcCardtype='"+strCardType+"'");
            foreach (DataRow dr in dtDeptFunc.Rows)
            {
                FuncList funcList = new FuncList(dr);
                funcList.cnvcFuncCode = funcList.cnvcFuncCode.Replace("一通卡", strL6Name);
                funcList.cnvcFuncCode = funcList.cnvcFuncCode.Replace("计次卡", strL8Name);

                if (!lFunc.Contains(funcList.cnvcFuncCode))
                    lFunc.Add(funcList.cnvcFuncCode);
            }
            if (lFunc.Count == 0 && deptid != 0)
            {
                throw new BusinessException("操作员登录", "操作员无任何权限！");
            }
            return lFunc;
        }
        public List<string> GetAllFunc(string strCardType, string strL6Name, string strL8Name)
        {
            string strsql = "";
            switch (strCardType)
            {
                case "l6":
                    strsql = "select * from tbFuncList where cnvcCardType in('l6','l6l8')";
                    break;
                case "l8":
                    strsql = "select * from tbFuncList where cnvcCardType in('l8','l6l8')";
                    break;
                case "l6l8":
                    strsql = "select * from tbFuncList where cnvcCardType in('l6','l8','l6l8')";
                    break;
            }
            DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text,strsql);

            List<string> lAllFunc = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                string strFuncCode = dr["cnvcFuncCode"].ToString();
                strFuncCode = strFuncCode.Replace("一通卡", strL6Name);
                strFuncCode = strFuncCode.Replace("记次卡", strL8Name);
                lAllFunc.Add(strFuncCode);
            }
            return lAllFunc;
        }
		public string OperCardCallBack(string strOperName)
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
					strRet3 += " 读卡失败";
				}		
				DataTable dtOper = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbOper where cnvcCardNo is not null and cnvcCardNo='"+strCardNo+"'");
				
				if (dtOper.Rows.Count == 0)
				{
					strRet3 += " 操作员不存在";
				}
				else
				{
					Oper oldOper = new Oper(dtOper);
					oldOper.cnvcCardNo = "";
					EntityMapping.Update(oldOper,trans);
					//流水
					SeqSerialNo serial = new SeqSerialNo();
					serial.cnvcFill = "0";
					decimal dSerialNo = EntityMapping.Create(serial,trans);

					//操作日志
					OperLog operLog = new OperLog();
					operLog.cnnSerialNo = dSerialNo;
					operLog.cnvcOperName = strOperName;//member.cnvcOperName;
					operLog.cndOperDate = DateTime.Now;
					operLog.cnvcOperFlag = ConstApp.Oper_Flag_OperInCallBack;
					EntityMapping.Create(operLog,trans);
				}	
				trans.Commit();
				string strRet2 = m1.RecycleCard();
				if (strRet != ConstMsg.RFOK)
				{
					strRet3 += " 操作员卡回收失败";
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
			return strRet3;

		}

		public void LoginLog(OperLogin login)
		{			
			try
			{

				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();

				string strHostName = Environment.MachineName;
                IPHostEntry oIPHost = Dns.GetHostEntry(Environment.MachineName);//Dns.Resolve(Environment.MachineName);
				string strHostIP = "";
				if(oIPHost.AddressList.Length>0)
					strHostIP=oIPHost.AddressList[0].ToString();	
			
				login.cnvcHostName = strHostName;
				login.cnvcHostAddress = strHostIP;

				SeqSerialNo serialNo = new SeqSerialNo();
				serialNo.cnvcFill = "0";
				login.cnnSerialNp = EntityMapping.Create(serialNo,trans);
				EntityMapping.Create(login,trans);
				//折扣上限
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
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
		public void SetDeptManager(Dept dept)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbDept set cnvcManager = '"+dept.cnvcManager+"' where cnnDeptID = "+dept.cnnDeptID);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

		public void DragOper(Oper oper)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbOper set cnnDeptID = "+oper.cnnDeptID+" where cnnOperID = "+oper.cnnOperID);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

		public void DragDept(Dept dept)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbDept set cnnParentDeptID = "+dept.cnnParentDeptID+" where cnnDeptID = "+dept.cnnDeptID);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

		public void ModifyPwdByOperID(Oper opers)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbOper set cnvcPwd = '"+opers.cnvcPwd+"' where cnnOperID = "+opers.cnnOperID.ToString());				
				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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
		
		public void ModifyPwd(Oper opers)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbOper set cnvcPwd = '"+opers.cnvcPwd+"' where cnvcOperName = '"+opers.cnvcOperName+"'");				
				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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
		
		public void AddOper(Oper opers)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				
				trans = conn.BeginTransaction();
				DataTable dtOper = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbOper where cnvcOperName = '"+opers.cnvcOperName+"'");
				if (dtOper.Rows.Count > 0)
				{
					throw new BusinessException("操作员管理","操作员已存在！");
				}
				if (opers.cnvcCardNo.Length > 0)
				{
					DataTable dtCard = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbOper where cnvcCardNo = 'aaa"+opers.cnvcCardNo+"'");
					if (dtCard.Rows.Count > 0)
					{
						throw new BusinessException("操作员管理","操作员卡号已存在！");
					}
					CardM1 m1 = new CardM1();
					string strReturn = m1.PutOutCard("aaa"+opers.cnvcCardNo);
					if (strReturn.Equals("OPSUCCESS"))
					{
						opers.cnvcCardNo = "aaa"+opers.cnvcCardNo;
						EntityMapping.Create(opers,trans);	
						trans.Commit();
					}
					else
					{
						throw new BusinessException("卡操作异常",strReturn);
					}
				}
				else
				{
					EntityMapping.Create(opers,trans);	
					trans.Commit();
				}
						
				
				
			}
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

		public void AddCard(Oper opers)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				
				trans = conn.BeginTransaction();
				
				DataTable dtOper = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbOper where cnvcCardNo is not null and cnvcCardNo = 'aaa"+opers.cnvcCardNo+"'");
				if (dtOper.Rows.Count > 0)
				{
					throw new BusinessException("操作员管理","操作员卡号已存在！");
				}
				CardM1 m1 = new CardM1();
				string strReturn = m1.PutOutCard("aaa"+opers.cnvcCardNo);
				if (strReturn.Equals("OPSUCCESS"))
				{
					SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbOper set cnvcCardNo = 'aaa"+opers.cnvcCardNo+"' where cnnOperID="+opers.cnnOperID.ToString());
					trans.Commit();
				}
				else
				{
					throw new BusinessException("卡操作异常",strReturn);
				}
			}
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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
					throw new BusinessException("操作员管理","未找到操作员！");
				}
				oldOper.cnvcCardNo = "";
				EntityMapping.Update(opers,trans);
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

		public void DeleteOper(Oper opers)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Delete(opers,trans);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

        public DataTable getOper(Oper opers)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "select a.cnnOperID as 操作员ID,a.cnvcOperName as 操作员名称,b.cnvcDeptName as 部门名称 from tbOper a left outer join tbDept b on a.cnnDeptID=b.cnnDeptID where a.cnvcOperName<>'admin' and ( a.cnvcOperName like '%" + opers.cnvcOperName + "%' or cnvcDeptName like '%" + opers.cnvcPwd + "%')");
        }

        public DataTable getOpers()
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbOper where cnvcOperName <> 'admin'");
        }
        public DataTable getAllOper()
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "select a.cnnOperID as 操作员ID,a.cnvcOperName as 操作员名称,b.cnvcDeptName as 部门名称 from tbOper a left outer join tbDept b on a.cnnDeptID=b.cnnDeptID where a.cnvcOperName <> 'admin'");
        }
        public DataTable getAllOperByDept(string strDeptID)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbOper where cnnDeptID = " + strDeptID);
        }

		public DataTable getAllOperNoSys(Oper opers)
		{
			DataTable dtOper = null;
				if (opers.cnnDeptID == 0)
				{
					dtOper = SqlHelper.ExecuteDataTable(CommandType.Text,"select * from tbOper where cnnDeptID <> 0");
				}
				else
				{

					DataTable dtManage = SqlHelper.ExecuteDataTable(CommandType.Text,"select * from tbDept where cnvcManager = '"+opers.cnvcOperName+"'");
					if (dtManage.Rows.Count != 1)
					{
						dtOper = SqlHelper.ExecuteDataTable(CommandType.Text,"select * from tbOper where cnnDeptID = "+opers.cnnDeptID);
					}
					else
					{
						Dept dept = new Dept(dtManage);
						dtOper = SqlHelper.ExecuteDataTable(CommandType.Text,"select * from tbOper where cnnDeptID = "+dept.cnnDeptID.ToString());
					}
					
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
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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
		public void ModifyDept(Dept dept)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Update(dept,trans);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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
		public void DeleteDept(Dept dept)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Delete(dept,trans);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

        public DataTable getDept(Dept dept)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "select cnnDeptID as 部门ID,cnvcDeptName as 部门名称,cnnParentDeptID as 上级部门ID,cnvcManager as 部门管理员,cnnDiscount as 部门折扣上限,cnvcComments as 描述 from tbDept where cnvcDeptName like '%" + dept.cnvcDeptName + "%' or cnnParentDeptID like '%" + dept.cnnParentDeptID.ToString() + "%'");
        }

        public DataTable getAllDept()
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "select cnnDeptID as 部门ID,cnvcDeptName as 部门名称,cnnParentDeptID as 上级部门ID,cnvcManager as 部门管理员,cnnDiscount as 部门折扣上限 from tbDept");
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
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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
        public void AddDeptFunc(List<FuncList> lfunc, string deptid)//,string strCardType)
        {

            try
            {
                conn = ConnectionPool.BorrowConnection();
                trans = conn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, "delete from tbDeptFunc where cnnDeptID = " + deptid);// +" and cnvcCardType='"+strCardType+"'");
                for (int i = 0; i < lfunc.Count; i++)
                {
                    //string strFuncCode = lfunc[i];
                    FuncList fl = lfunc[i] as FuncList;
                    DeptFunc func = new DeptFunc();
                    func.cnnDeptID = Convert.ToInt32(deptid);
                    func.cnvcFuncCode = fl.cnvcFuncCode;//strFuncCode;
                    func.cnvcCardType = fl.cnvcCardType;//strCardType;
                    EntityMapping.Create(func, trans);
                }

                trans.Commit();
            }
            catch (BusinessException bex) //业务异常
            {
                //LogAdapter.WriteBusinessException(bex);
                trans.Rollback();
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
		public void ModifyOperFunc(List<FuncList> alOperFuncList,string iOperID)//,string strCardType)
		{

			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"delete from tbOperFunc where cnnOperID = "+iOperID);//+" and cnvcCardType='"+strCardType+"'");
				for (int i = 0;i<alOperFuncList.Count;i++)
				{
					//string strFuncCode = alOperFuncList[i];
                    FuncList fl = alOperFuncList[i] as FuncList;
					OperFunc func = new OperFunc();
					func.cnnOperID = Convert.ToInt32(iOperID);
                    func.cnvcFuncCode = fl.cnvcFuncCode;//strFuncCode;
                    func.cnvcCardType = fl.cnvcCardType;//strCardType;
					EntityMapping.Create(func,trans);
				}			
				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

        public void ModifyOperDept(List<Dept> alOperDeptList, string iOperID)
        {
            try
            {
                conn = ConnectionPool.BorrowConnection();
                trans = conn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, "delete from tbOperDept where cnnOperID = " + iOperID);
                for (int i = 0; i < alOperDeptList.Count; i++)
                {
                    Dept dept = alOperDeptList[i] as Dept;
                    OperDept operdept = new OperDept();
                    operdept.cnnOperID = Convert.ToInt32(iOperID);
                    operdept.cnnDeptID = dept.cnnDeptID;

                    EntityMapping.Create(operdept, trans);
                }

                trans.Commit();
            }
            catch (BusinessException bex) //业务异常
            {
                //LogAdapter.WriteBusinessException(bex);
                trans.Rollback();
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
		public void DeleteOperFunc(OperFunc func)
		{

			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Delete(func,trans);				
				
				trans.Commit();
			}
			catch (BusinessException bex) //业务异常
			{		
				//LogAdapter.WriteBusinessException(bex);
				trans.Rollback();
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

        public DataTable QueryOperFunc(int iOperID)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbOperFunc where cnnOperID = " + iOperID.ToString());
        }

        public void AddSales(Sales opers)
        {
            try
            {
                conn = ConnectionPool.BorrowConnection();

                trans = conn.BeginTransaction();
                DataTable dtOper = SqlHelper.ExecuteDataTable(trans, CommandType.Text, "select * from tbSales where cnvcSales = '" + opers.cnvcSales + "'");
                if (dtOper.Rows.Count > 0)
                {
                    throw new BusinessException("业务员管理", "业务员已存在！");
                }

                EntityMapping.Create(opers, trans);
                trans.Commit();

            }
            catch (BusinessException bex) //业务异常
            {
                //LogAdapter.WriteBusinessException(bex);
                trans.Rollback();
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

        public void ModifySales(Sales opers)
        {
            try
            {
                conn = ConnectionPool.BorrowConnection();
                trans = conn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, "update tbSales set "
                    + "cnvcSales = '" + opers.cnvcSales + "',"
                    + "cnvcTel='" + opers.cnvcTel + "',"
                    + "cnvcCredentials='" + opers.cnvcCredentials + "',"
                    + "cnnDeptID=" + opers.cnnDeptID.ToString()
                    + " where cnnSales=" + opers.cnnSales.ToString());
                trans.Commit();
            }
            catch (BusinessException bex) //业务异常
            {
                //LogAdapter.WriteBusinessException(bex);
                trans.Rollback();
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

        public void DeleteSales(Sales opers)
        {
            try
            {
                conn = ConnectionPool.BorrowConnection();
                trans = conn.BeginTransaction();
                EntityMapping.Delete(opers, trans);

                trans.Commit();
            }
            catch (BusinessException bex) //业务异常
            {
                //LogAdapter.WriteBusinessException(bex);
                trans.Rollback();
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
	}
}
