
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	MemberManage.cs
* ����:	     ֣��
* ��������:    2007-12-10
* ��������:    ��Ա����ҵ��

*                                                           Copyright(C) 2007 zhenghua
*************************************************************************************/

using System;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using ynhrMemberManage.CardCommon;
using ynhrMemberManage.CardCommon.CardRef;
using ynhrMemberManage.CardCommon.CardDef;
using ynhrMemberManage.Print;
using ynhrMemberManage.Common;
using System.Collections.Generic;
namespace ynhrMemberManage.BusinessFacade.MemberBusiness
{
	/// <summary>
	/// Summary description for MemberManage.
	/// </summary>
	public class MemberManageFacade
	{
		/// <summary>
		/// ��ǰ���ݿ�����
		/// </summary>
		private SqlTransaction trans = null;
		/// <summary>
		/// ��ǰ���ݿ�����
		/// </summary>
		private SqlConnection conn = null;
        public MemberManageFacade()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// ����
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
				//��Ա
                Member fm = EntityMapping.Get(member, trans) as Member;
                if (fm != null) throw new BusinessException("��Ա��¼��", "�����Ա�����ѱ�ռ�ã�������");
				EntityMapping.Create(member,trans);
				//��ˮ
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);
				//��Ա��־
				MemberLog memberLog = new MemberLog(member.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(memberLog,trans);
				//��ֵ��־
				//				MemberPrepayLog prepayLog = new MemberPrepayLog(member.ToTable());
				//				prepayLog.cnnSerialNo = dSerialNo;
				//				EntityMapping.Create(prepayLog,trans);

				//�����Ʒ
                if (alProduct.Count > 0)
                {
                    for (int i = 0; i < alProduct.Count; i++)
                    {
                        MemberProduct memberProductNew = (MemberProduct)alProduct[i];
                        MemberProduct memberProduct = EntityMapping.Get(memberProductNew, trans) as MemberProduct;
                        if (null == memberProduct)
                        {
                            //throw new BusinessException("��Ա�����Ʒ����","���ֵ");
                            memberProduct = new MemberProduct(memberProductNew.ToTable());
                            EntityMapping.Create(memberProduct, trans);
                        }
                        else
                        {
                            int iNewFree = int.Parse(memberProductNew.cnvcFree);
                            int iFree = int.Parse(memberProduct.cnvcFree);
                            memberProduct.cnvcFree = (iNewFree + iFree).ToString();
                            EntityMapping.Update(memberProduct, trans);
                        }
                    }
                }
				//������־
				//				if (IsPutCard)
				//				{
				//					OperLog operLog = new OperLog(member.ToTable());
				//					//operLog.cnnPrepay = member.cnn
				//					operLog.cnnSerialNo = dSerialNo;
				//					operLog.cnvcOperFlag = ConstApp.Oper_Flag_Provide;
				//					EntityMapping.Create(operLog,trans);
				//					//СƱ�ش�				
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
				//						throw new BusinessException("�������쳣",strReturn);
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

		public void RenewCard (Member Oldmember,PrintedBill pBill)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				//��Ա
				Member member = EntityMapping.Get(Oldmember,trans) as Member;
				if (null == member)
				{
					throw new BusinessException("���·���","δ�ҵ���Ա����");
				}
				
				//��ˮ
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);
				//���»�Ա״̬
				member.cnvcState = ConstApp.Card_State_InUse;
				member.cnvcMemberCardNo = Oldmember.cnvcProduct;
				member.cnvcOperName = Oldmember.cnvcOperName;
				member.cndOperDate = Oldmember.cndOperDate;

				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcState='"+ConstApp.Card_State_InUse+"',cnvcMemberCardNo='"+Oldmember.cnvcProduct+"',cnvcOperName='"+Oldmember.cnvcOperName+"',cndOperDate='"+Oldmember.cndOperDate+"' where cnvcMemberCardNo='"+Oldmember.cnvcMemberCardNo+"'");
				//��Ա��־
				MemberLog memberLog = new MemberLog(member.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				EntityMapping.Create(memberLog,trans);

				//�����Ʒ
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMemberProduct set cnvcMemberCardNo='"+Oldmember.cnvcProduct+"',cnvcOperName='"+Oldmember.cnvcOperName+"',cndOperDate='"+Oldmember.cndOperDate+"' where cnvcMemberCardNo='"+Oldmember.cnvcMemberCardNo+"'");

				//��ֵ��¼

                //string strIsMemberFee = "select cnvcMemberValue from tbMemberCode where cnvcMemberName='" + member.cnvcMemberRight + "' and cnvcMemberType='" + ConstApp.IsMemberFee + "'";
                //bool bMemberFee = false;
                //object objMemberFee = SqlHelper.ExecuteScalar(CommandType.Text, strIsMemberFee);
                //string strMemberFee = "��";
                //if (objMemberFee != null)
                //{
                //    strMemberFee = objMemberFee.ToString();
                //}
                //if (strMemberFee.Equals("��"))
                //{
                //    bMemberFee = true;
                //}
                
                MemberPrepayLog prepayLog = new MemberPrepayLog(member.ToTable());
				prepayLog.cnnSerialNo = dSerialNo;
				prepayLog.cnvcOperFlag = ConstApp.Fee_Flag_Card;
                //if (bMemberFee)
                //{
                //    prepayLog.cnnPrepay = member.cnnMemberFee;
                //}
				EntityMapping.Create(prepayLog,trans);
				//������־

				OperLog operLog = new OperLog(member.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_RenewCard;
				EntityMapping.Create(operLog,trans);
				//СƱ�ش�				
				Bill bill = new Bill(pBill.ToTable());
				bill.cnnRepeats = 0;
				EntityMapping.Create(bill,trans);

                //���ִ���
                PointsAdd(trans, ConstApp.PointsBK, member.cnvcMemberRight, member.cnvcMemberCardNo, member.cnvcOperName, member.cndOperDate, 0);         
#if DEBUG
				trans.Commit();
#else
                CardM1 m1 = new CardM1();
                string strReturn = m1.PutOutCard(member.cnvcMemberCardNo);
                if (strReturn.Equals("OPSUCCESS"))
                {
                    trans.Commit();
                }
                else
                {
                    throw new BusinessException("�������쳣", strReturn);
                }
#endif
				
				
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
		public void NoCardDelete (Member Oldmember)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				//��Ա
				Member member = EntityMapping.Get(Oldmember,trans) as Member;
				if (null == member)
				{
					throw new BusinessException("ɾ��δ������Ա","δ�ҵ�δ������Ա����");
				}
				
				//��ˮ
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);
				//ɾ��
				EntityMapping.Delete(member,trans);
				//��Ա��־
				MemberLog memberLog = new MemberLog(member.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				memberLog.cnvcOperName = Oldmember.cnvcOperName;
				memberLog.cndOperDate = Oldmember.cndOperDate;
				EntityMapping.Create(memberLog,trans);

				//�����Ʒ
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"delete from tbMemberProduct where cnvcMemberCardNo = '"+Oldmember.cnvcMemberCardNo+"'");

				
				//������־

				OperLog operLog = new OperLog(memberLog.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = "ɾ��δ������Ա";
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
		/// ��ӷǻ�Ա��Ϣ
		/// </summary>
		/// <param name="member"></param>
		/// 
		#region ��ӷǻ�Ա��Ϣ
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
		public void ModifyMember (Member member)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();

				Member oldMember = EntityMapping.Get(member,trans) as Member;
				if (null == oldMember)
				{
					throw new BusinessException("�޸Ļ�Ա","δ�ҵ���Ӧ��Ա����Ա���ţ�"+oldMember.cnvcMemberCardNo);
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
		public void ModifyFMember (FMember member)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();

				FMember oldMember = EntityMapping.Get(member,trans) as FMember;
				if (null == oldMember)
				{
					throw new BusinessException("�޸ķǻ�Ա","δ�ҵ���Ӧ�ǻ�Ա");
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
		public Member GetMember (Member member)
		{
			Member retMember ;
				DataTable dtMember = SqlHelper.ExecuteDataTable(CommandType.Text,"select * from tbMember where cnvcMemberCardNo = '"+member.cnvcMemberCardNo+"' or cnvcPaperNo = '"+member.cnvcPaperNo+"' or cnvcMemberName = '"+member.cnvcMemberName+"' and cnvcState = '"+ConstApp.Card_State_InUse+"'");
				if (null == dtMember)
				{
					throw new BusinessException("��ѯ����","δ�ҵ��˻�Ա��");
				}
				if (dtMember.Rows.Count == 0)
				{
					throw new BusinessException("��ѯ����","δ�ҵ��˻�Ա��");
				}
				retMember = new Member(dtMember);
				
			
			return retMember;

		}

        public DataTable GetSomeMember(Member member)
        {
            DataTable dtMember;
            string strSql = "select '��Ա' as ��Ա����, cnvcMemberCardNo as ��Ա����,cnvcMemberName as ��λ����,cnvcPaperNo as ����ע���,cnvcDiscount as �ۿ� from tbMember where cnvcState='" + ConstApp.Card_State_InUse + "' and cndEndDate > getdate() and ( cnvcMemberCardNo like '%" + member.cnvcMemberCardNo + "%' or cnvcMemberName like '%" + member.cnvcMemberName + "%' or cnvcPaperNo like '%" + member.cnvcPaperNo + "') "
                          + " union "
                          + " select '�ǻ�Ա' as ��Ա����, null as ��Ա����,cnvcMemberName as ��λ����,cnvcPaperNo as ����ע���,null as �ۿ�  from tbFMember where  cnvcMemberName like '%" + member.cnvcMemberName + "%' or cnvcPaperNo like '%" + member.cnvcPaperNo + "%' ";
            dtMember = SqlHelper.ExecuteDataTable(CommandType.Text, strSql);


            return dtMember;
        }

        public DataTable GetSomeMemberReturnPrepay(Member member)
        {
            DataTable dtMember;

            string strSql = "select a.cnnJobID as ��Ƹ��ID,a.cnvcMemberCardNo as ��Ա����,b.cnvcMemberName as ��λ���� ,a.cnvcPaperNo as ����ע���,a.cnnPrepay-a.cnnReturn as չλ��  "
                          + " from tbPrepay a left outer join  "
                          + " ( "
                          + " select cnvcMemberCardNo,cnvcMemberName,cnvcPaperNo from tbMember where cndEndDate > getdate() and cnvcState='" + ConstApp.Card_State_InUse + "'"
                          + " union "
                          + " select null as cnvcMemberCardNo,cnvcMemberName,cnvcPaperNo from tbFMember "
                          + " ) b "
                          + " on a.cnvcPaperNo=b.cnvcPaperNo "
                          + " where a.cnnPrepay-a.cnnReturn > 0 and (cnvcState is null or cnvcState <> '" + ConstApp.Show_Seat_State_SignIn + "') ";
            if (member.cnvcMemberName != "")
            {
                strSql += "  and b.cnvcMemberName like '%" + member.cnvcMemberName + "%' ";
            }
            if (member.cnvcMemberCardNo != "")
            {
                strSql += " and a.cnvcMemberCardNo like '%" + member.cnvcMemberCardNo + "%'";
            }
            if (member.cnvcPaperNo != "")
            {
                strSql += " and a.cnvcPaperNo like '%" + member.cnvcPaperNo + "%' ";
            }

            dtMember = SqlHelper.ExecuteDataTable(CommandType.Text, strSql);


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
					throw new BusinessException("�˷�","δ���ҵ����˷�չλ��");
				}
				if (oldPrepay.cnvcState == ConstApp.Show_Seat_State_SignIn)
				{
					throw new BusinessException("�˷�","��չλ���ѱ�ʹ�ã����ܽ����˷�");
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

        public Member GetMemberFree(Member member)
        {
            Member retMember;

            DataTable dtMember = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbMember where cnvcMemberCardNo = '" + member.cnvcMemberCardNo + "' and cnvcState = '" + ConstApp.Card_State_InUse + "'");
            retMember = new Member(dtMember);

            return retMember;
        }

        public Member GetMemberbyCardNo(Member member)
        {
            Member retMember;

            DataTable dtMember = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbMember where cnvcMemberCardNo = '" + member.cnvcMemberCardNo + "'");
            retMember = new Member(dtMember);

            return retMember;
        }

        public FMember GetFMemberbyPaperNo(FMember member)
        {
            FMember retMember;
            DataTable dtMember = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbFMember where cnvcPaperNo = '" + member.cnvcPaperNo + "'");
            retMember = new FMember(dtMember);
            return retMember;
        }

		/// <summary>
		/// ����
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
					throw new BusinessException("����","�ϻ�Ա�����ڣ���Ա���ţ�"+member.cnvcMemberCardNo);
				}

				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcState = '"
                    +ConstApp.Card_State_InAdd+"' ,cnvcOperName='"
                    +member.cnvcOperName+"',cndOperDate='"
                    + member.cndOperDate + "',cnvcComments='�¿��ţ�"+member.cnvcMemberName+"',cnnPrepay=0 where cnvcMemberCardNo = '" + member.cnvcMemberCardNo + "'");

				//��ˮ
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				//��Ա��־
				MemberLog memberLog = new MemberLog(oldMember.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				memberLog.cnvcOperName = member.cnvcOperName;
				memberLog.cndOperDate = member.cndOperDate;
				memberLog.cnvcState = ConstApp.Card_State_InAdd;
                memberLog.cnvcComments = "�¿��ţ�" + member.cnvcMemberName;
				EntityMapping.Create(memberLog,trans);
				//������־
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
                newMember.cnvcComments = "�Ͽ��ţ�"+member.cnvcMemberCardNo;
				EntityMapping.Create(newMember,trans);

				//��ֵ��־
                //MemberPrepayLog prepayLog = new MemberPrepayLog(newMember.ToTable());
                //prepayLog.cnnSerialNo = dSerialNo;
                //prepayLog.cnvcOperFlag = ConstApp.Fee_Flag_Cost;
                //prepayLog.cnnPrepay = member.cnnPrepay;
                //prepayLog.cnnBalance = oldMember.cnnPrepay;
                //prepayLog.cnnLastBalance = oldMember.cnnPrepay;

                //EntityMapping.Create(prepayLog,trans);

                //DataTable dtMemberProduct = SqlHelper.ExecuteDataTable(trans,CommandType.Text,"select * from tbMemberProduct where cnvcMemberCardNo='"+member.cnvcMemberCardNo+"'");
                //if (dtMemberProduct.Rows.Count > 0)
                //{
                //    foreach (DataRow drMemberProduct in dtMemberProduct.Rows)
                //    {
                //        MemberProduct mp = new MemberProduct(drMemberProduct);
                //        mp.cnvcMemberCardNo = newMember.cnvcMemberCardNo;
                //        mp.cndOperDate = newMember.cndOperDate;
                //        mp.cnvcOperName = newMember.cnvcOperName;
                //        EntityMapping.Create(mp,trans);
                //    }
                //}

				//��ˮ
				SeqSerialNo serial2 = new SeqSerialNo();
				serial2.cnvcFill = "0";
				decimal dSerialNo2 = EntityMapping.Create(serial2,trans);

				//��Ա��־
				MemberLog newMemberLog = new MemberLog(newMember.ToTable());
				newMemberLog.cnnSerialNo = dSerialNo2;
				EntityMapping.Create(newMemberLog,trans);
				//������־
				OperLog newOperLog = new OperLog(newMember.ToTable());
				newOperLog.cnnSerialNo = dSerialNo2;
				newOperLog.cnvcOperFlag = ConstApp.Oper_Flag_InAdd;
				EntityMapping.Create(newOperLog,trans);				

				//������
                //if (member.cnnPrepay > 0)
                //{
                //    CostLog costLog = new CostLog(member.ToTable());
                //    costLog.cnnSerialNo = dSerialNo2;
                //    costLog.cnvcMemberCardNo = member.cnvcMemberName;
                //    costLog.cnnCost = member.cnnPrepay;
                //    EntityMapping.Create(costLog,trans);
                //}
				Bill bill = new Bill(pBill.ToTable());
				bill.cnnRepeats = 0;
				EntityMapping.Create(bill,trans);
				//trans.Commit();
                CardM1 m1 = new CardM1();
                string strReturn = m1.PutOutCard(newMember.cnvcMemberCardNo);
                if (strReturn.Equals("OPSUCCESS"))
                {
                    trans.Commit();
                }
                else
                {
                    throw new BusinessException("�������쳣", strReturn);
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
						
		}
		#endregion
		/// <summary>
		/// ��Ա����ʧ
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
					throw new BusinessException("��ʧ","��ʧ��Ա�����ڣ���Ա���ţ�"+member.cnvcMemberCardNo);
				}

				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcState = '"+ConstApp.Card_State_InLose+"' ,cnvcOperName='"+member.cnvcOperName+"',cndOperDate='"+member.cndOperDate+"' where cnvcMemberCardNo = '"+member.cnvcMemberCardNo+"'");

				//��ˮ
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				//��Ա��־
				MemberLog memberLog = new MemberLog(oldMember.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				memberLog.cnvcOperName = member.cnvcOperName;
				memberLog.cndOperDate = member.cndOperDate;
				memberLog.cnvcState = ConstApp.Card_State_InLose;
				EntityMapping.Create(memberLog,trans);
				//������־
				OperLog operLog = new OperLog(oldMember.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cndOperDate = member.cndOperDate;
				operLog.cnvcOperName = member.cnvcOperName;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_InLose;
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
		/// ��Ա�����
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
					throw new BusinessException("���","��һ�Ա�����ڣ���Ա���ţ�"+member.cnvcMemberCardNo);
				}

				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcState = '"+ConstApp.Card_State_InUse+"' ,cnvcOperName='"+member.cnvcOperName+"',cndOperDate='"+member.cndOperDate+"' where cnvcMemberCardNo = '"+member.cnvcMemberCardNo+"'");

				//��ˮ
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				//��Ա��־
				MemberLog memberLog = new MemberLog(oldMember.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				memberLog.cnvcOperName = member.cnvcOperName;
				memberLog.cndOperDate = member.cndOperDate;
				memberLog.cnvcState = ConstApp.Card_State_InUse;
				EntityMapping.Create(memberLog,trans);
				//������־
				OperLog operLog = new OperLog(oldMember.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cndOperDate = member.cndOperDate;
				operLog.cnvcOperName = member.cnvcOperName;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_InUse;
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
		/// ��Ա����ֵ
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
					throw new BusinessException("��ֵ","��ֵ��Ա�����ڣ���Ա���ţ�"+member.cnvcMemberCardNo);
				}
                //if (oldMember.cnvcFree == ConstApp.Free_Time_NoLimit)
                //{
                //    oldMember.cnvcFree = "0";
                //}
                decimal dDonate = GetInMoneySetting(trans, member.cnnPrepay);

				//int iFree = int.Parse(oldMember.cnvcFree)+int.Parse(member.cnvcFree);
                decimal dbalance = oldMember.cnnPrepay + member.cnnPrepay + dDonate;
                decimal dlastbalance = oldMember.cnnPrepay;
                oldMember.cnnPrepay = dbalance;
                //zhh
                oldMember.cnvcDiscount = member.cnvcDiscount;
                //20141129

				//oldMember.cnvcFree = iFree.ToString();
				oldMember.cnvcOperName = member.cnvcOperName;
				oldMember.cndOperDate = member.cndOperDate;
                oldMember.cndEndDate = member.cndEndDate;

				EntityMapping.Update(oldMember,trans);
				//��ˮ
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				//��Ա��־
				MemberLog memberLog = new MemberLog(oldMember.ToTable());
				memberLog.cnnSerialNo = dSerialNo;				
				EntityMapping.Create(memberLog,trans);
				//��Ա��ֵ��־
                //if (dDonate > 0)
                //{
                //    serial = new SeqSerialNo();
                //    serial.cnvcFill = "0";
                //    decimal dSerialNo2 = EntityMapping.Create(serial, trans);

                //    MemberPrepayLog prepayLog2 = new MemberPrepayLog(member.ToTable());
                //    prepayLog2.cnnSerialNo = dSerialNo2;
                //    prepayLog2.cnnPrepay = dDonate;
                //    prepayLog2.cnnLastBalance = oldMember.cnnPrepay;
                //    prepayLog2.cnnBalance = oldMember.cnnPrepay + dDonate;
                //    prepayLog2.cnvcOperFlag = ConstApp.Fee_Flag_Donate;
                //    EntityMapping.Create(prepayLog2, trans);
                //}
                MemberPrepayLog prepayLog = new MemberPrepayLog(member.ToTable());
                prepayLog.cnnSerialNo = dSerialNo;
                prepayLog.cnnLastBalance = dlastbalance;// +dDonate;
                prepayLog.cnnPrepay = member.cnnPrepay;
                prepayLog.cnnBalance = dbalance;
                prepayLog.cnnDonate = dDonate;
                prepayLog.cnvcOperFlag = ConstApp.Fee_Flag_InMoney;                
                EntityMapping.Create(prepayLog, trans);
				//������־
				OperLog operLog = new OperLog(member.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_InMoney;
				EntityMapping.Create(operLog,trans);
                //if (dDonate > 0)
                //{
                //    serial = new SeqSerialNo();
                //    serial.cnvcFill = "0";
                //    dSerialNo = EntityMapping.Create(serial, trans);

                //    prepayLog = new MemberPrepayLog(member.ToTable());
                //    prepayLog.cnnSerialNo = dSerialNo;
                //    prepayLog.cnnPrepay = dDonate;
                //    prepayLog.cnvcOperFlag = ConstApp.Fee_Flag_Donate;
                //    EntityMapping.Create(prepayLog, trans);
                //}
				//СƱ
				Bill bill = new Bill(pBill.ToTable());                
				//bill.cnvcBillType = ConstApp.Bill_Type_InMoney;
				bill.cnnRepeats = 0;
				EntityMapping.Create(bill,trans);


                /////���ִ��� 20110211
                PointsAdd(trans, ConstApp.Fee_Flag_InMoney, oldMember.cnvcMemberRight, oldMember.cnvcMemberCardNo, oldMember.cnvcOperName, oldMember.cndOperDate, member.cnnPrepay);
                ///////////////////////////
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

		public PrintedBill UserProduct(Product product,PrintedBill pBill,int iCount)
		{
			PrintedBill retBill = pBill;
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				//��ˮ
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
						throw new BusinessException("��Ա�����Ʒ����","���ֵ");
					}
					if (memberProduct.cnvcFree != ConstApp.Free_Time_NoLimit)
					{
					
						int iFree = int.Parse(memberProduct.cnvcFree);
						if (iFree < iCount)//1)
						{
							throw new BusinessException("��Ա�����Ʒ����","���ֵ");
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
						throw new BusinessException("�ǻ�Ա�����Ʒ����","���ֵ");
					}
					if (fmemberProduct.cnvcFree != ConstApp.Free_Time_NoLimit)
					{
						int iFree = int.Parse(fmemberProduct.cnvcFree);
						if (iFree < iCount)//1)
						{
							throw new BusinessException("�ǻ�Ա�����Ʒ����","���ֵ");
						}
						iFree -= iCount;//1;
						fmemberProduct.cnvcFree = iFree.ToString();
						retBill.cnvcProduct += fmemberProduct.cnvcFree;
						EntityMapping.Update(fmemberProduct,trans);
					}
				}
				
				//�����Ʒʹ����ˮ				
				product.cnnSerialNo = dSerialNo;
				EntityMapping.Create(product,trans);
				//������־
				OperLog operLog = new OperLog(product.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_Product;
				EntityMapping.Create(operLog,trans);
				//СƱ
				Bill bill = new Bill(pBill.ToTable());
				//bill.cnvcBillType = ConstApp.Bill_Type_Product_Use;
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
			return retBill;
		}

		public void ConsumeProduct(ArrayList alProduct,bool bMember,string strProduct,PrintedBill pBill)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				//��ˮ
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);
				MemberProductLog productLog = null;
				if (bMember)
				{
					productLog = (MemberProductLog)alProduct[0];
                    Member oldMember = new Member();
                    oldMember.cnvcMemberCardNo = productLog.cnvcMemberCardNo;
                    oldMember = EntityMapping.Get(oldMember, trans) as Member;
                    if (oldMember == null) throw new BusinessException("�����Ʒ����", "δ�ҵ���Ա��Ϣ");
                    decimal dfee = 0;
                    //JobManage jm = new JobManage();
                    pBill.cnnLastBalance = oldMember.cnnPrepay;
					for (int i = 0 ; i<alProduct.Count; i ++)
					{
						MemberProductLog memberProductLog = (MemberProductLog)alProduct[i];
                        //decimal ddiscount = jm.GetDiscount(trans, memberProductLog.cnvcProductName, oldMember.cnvcMemberRight);
                        //MemberProduct memberProduct = new MemberProduct(memberProductLog.ToTable());						
                        //memberProduct = EntityMapping.Get(memberProduct,trans) as MemberProduct;
                        //if (null == memberProduct)
                        //{
                        //    //throw new BusinessException("��Ա�����Ʒ����","���ֵ");
                        //    memberProduct = new MemberProduct(memberProductLog.ToTable());
                        //    EntityMapping.Create(memberProduct,trans);
                        //}
                        //else
                        //{
                        //    int iNewFree = int.Parse(memberProductLog.cnvcFree);
                        //    int iFree = int.Parse(memberProduct.cnvcFree);
                        //    memberProduct.cnvcFree = (iNewFree+iFree).ToString();
                        //    EntityMapping.Update(memberProduct,trans);
                        //}
						SeqSerialNo serial2 = new SeqSerialNo();
						serial2.cnvcFill = "0";
						decimal dSerialNo2 = EntityMapping.Create(serial2,trans);

                        //dfee += memberProductLog.cnnProductPrice * ddiscount / 100;

						memberProductLog.cnnSerialNo = dSerialNo2;
                        //memberProductLog.cnvcProductDiscount = ddiscount.ToString();
                        //memberProductLog.cnnPrepay = memberProductLog.cnnProductPrice * ddiscount / 100;
                        memberProductLog.cnnLastBalance = oldMember.cnnPrepay-dfee;
                        memberProductLog.cnnBalance = oldMember.cnnPrepay-dfee-memberProductLog.cnnPrepay;
						EntityMapping.Create(memberProductLog,trans);

                        dfee += memberProductLog.cnnPrepay;
                        
					}
                    //���� 20110211
                    //Member oldMember = new Member();
                    //oldMember.cnvcMemberCardNo = productLog.cnvcMemberCardNo;
                    //oldMember = EntityMapping.Get(oldMember, trans) as Member;
                    if (oldMember.cnnPrepay < dfee) throw new BusinessException("�����Ʒ����", "�������ֵ");
                    oldMember.cnnPrepay = oldMember.cnnPrepay - dfee;
                    EntityMapping.Update(oldMember, trans);
                    pBill.cnnPrepay = dfee;
                    pBill.cnnBalance = oldMember.cnnPrepay;
                    PointsAdd(trans, ConstApp.Fee_Flag_Product, oldMember.cnvcMemberRight, productLog.cnvcMemberCardNo, productLog.cnvcOperName, productLog.cndOperDate, dfee);
                    /////////////////////////////////		

				}
				else
				{
					FMemberProductLog fproductLog = (FMemberProductLog)alProduct[0];
					productLog = new MemberProductLog(fproductLog.ToTable());
                    FMember foldMember = new FMember();
                    foldMember.cnvcPaperNo = fproductLog.cnvcPaperNo;
                    foldMember = EntityMapping.Get(foldMember, trans) as FMember;
                    if (foldMember == null) throw new BusinessException("�����Ʒ����", "δ�ҵ��ǻ�Ա��Ϣ");
                    //JobManage jm = new JobManage();
                    pBill.cnnLastBalance = foldMember.cnnPrepay;
                    decimal dfee = 0;
					for (int i = 0 ; i<alProduct.Count; i ++)
					{
						FMemberProductLog fmemberProductLog = (FMemberProductLog)alProduct[i];
                        //decimal ddiscount = jm.GetDiscount(trans, fmemberProductLog.cnvcProductName, "");
                        //FMemberProduct fmemberProduct = new FMemberProduct(fmemberProductLog.ToTable());						
                        //fmemberProduct = EntityMapping.Get(fmemberProduct,trans) as FMemberProduct;
                        //if (null == fmemberProduct)
                        //{
                        //    //throw new BusinessException("��Ա�����Ʒ����","���ֵ");
                        //    fmemberProduct = new FMemberProduct(fmemberProductLog.ToTable());
                        //    EntityMapping.Create(fmemberProduct,trans);
                        //}
                        //else
                        //{
                        //    int iNewFree = int.Parse(fmemberProductLog.cnvcFree);
                        //    int iFree = int.Parse(fmemberProduct.cnvcFree);
                        //    fmemberProduct.cnvcFree = (iNewFree+iFree).ToString();
                        //    EntityMapping.Update(fmemberProduct,trans);
                        //}
						SeqSerialNo serial2 = new SeqSerialNo();
						serial2.cnvcFill = "0";
						decimal dSerialNo2 = EntityMapping.Create(serial2,trans);

						fmemberProductLog.cnnSerialNo = dSerialNo2;

                        //fmemberProductLog.cnvcProductDiscount = ddiscount.ToString();
                        //fmemberProductLog.cnnPrepay = fmemberProductLog.cnnProductPrice * ddiscount / 100;
                        fmemberProductLog.cnnLastBalance = foldMember.cnnPrepay-dfee;
                        fmemberProductLog.cnnBalance = foldMember.cnnPrepay-dfee - fmemberProductLog.cnnPrepay;

						EntityMapping.Create(fmemberProductLog,trans);

                        dfee += fmemberProductLog.cnnPrepay;
					}
                    if (foldMember.cnnPrepay < dfee) throw new BusinessException("�����Ʒ����", "�������ֵ");
                    foldMember.cnnPrepay = foldMember.cnnPrepay - dfee;
                    EntityMapping.Update(foldMember, trans);
                    pBill.cnnBalance = foldMember.cnnPrepay;
                    pBill.cnnPrepay = dfee;
				}
				
				//�����Ʒʹ����ˮ				
//				product.cnnSerialNo = dSerialNo;
//				EntityMapping.Create(product,trans);
				//������־
				OperLog operLog = new OperLog(productLog.ToTable());
				operLog.cnnSerialNo = dSerialNo;
                operLog.cnnPrepay = pBill.cnnPrepay;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_ConsumeProduct;
				EntityMapping.Create(operLog,trans);
				//СƱ
				Bill bill = new Bill(pBill.ToTable());
				//bill.cnvcProduct = strProduct;
				//bill.cnvcBillType = ConstApp.Bill_Type_Product_Use;
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
		#endregion
        public DataTable SomeInLoseMemeber(Member member)
        {
            DataTable dtMember;
            dtMember = SqlHelper.ExecuteDataTable(CommandType.Text, "select cnvcMemberCardNo as ��Ա����,cnvcMemberName as ��Ա����,cnvcPaperNo as ֤������,cnvcMemberRight as ��Ա�ʸ�,cnnPrepay as Ԥ���,cnvcFree as ����  from tbMember where cnvcState='" + ConstApp.Card_State_InLose + "' and ( cnvcMemberCardNo like '%" + member.cnvcMemberCardNo + "%' or cnvcPaperNo = '%" + member.cnvcPaperNo + "%' or cnvcMemberName = '%" + member.cnvcMemberName + "%')");
            if (null == dtMember)
            {
                throw new BusinessException("��ѯ����", "δ�����ƻ�Ա��");
            }
            if (dtMember.Rows.Count == 0)
            {
                throw new BusinessException("��ѯ����", "δ�����ƻ�Ա��");
            }
            return dtMember;
        }


		/// <summary>
		/// ����
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
					throw new BusinessException("������ʧ��","���ջ�Ա��ʧ�ܣ�");
				}		
				//Member member = new Member();
				member.cnvcMemberCardNo = strCardNo;
				Member oldMember = EntityMapping.Get(member,trans) as Member;
				if (null == oldMember)
				{
					throw new BusinessException("������","��Ա�����ڣ���Ա���ţ�"+member.cnvcMemberCardNo);
				}

				string strRet2 = m1.RecycleCard();
				if (strRet != ConstMsg.RFOK)
				{
					throw new BusinessException("������ʧ��","���ջ�Ա��ʧ�ܣ�");
				}	
				SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMember set cnvcState = '"+ConstApp.Card_State_InCallBack+"' ,cnvcOperName='"+member.cnvcOperName+"',cndOperDate='"+member.cndOperDate+"' where cnvcMemberCardNo = '"+strCardNo+"'");

				//��ˮ
				SeqSerialNo serial = new SeqSerialNo();
				serial.cnvcFill = "0";
				decimal dSerialNo = EntityMapping.Create(serial,trans);

				//��Ա��־
				MemberLog memberLog = new MemberLog(oldMember.ToTable());
				memberLog.cnnSerialNo = dSerialNo;
				memberLog.cnvcOperName = member.cnvcOperName;
				memberLog.cndOperDate = member.cndOperDate;
				memberLog.cnvcState = ConstApp.Card_State_InCallBack;
				//memberLog.cnnPrepay = oldMember.cnnPrepay+member.cnnPrepay;
				//memberLog.cnvcFree = iFree.ToString();//oldMember.cnvcFree+member.cnvcFree;
				EntityMapping.Create(memberLog,trans);
				//������־
				OperLog operLog = new OperLog(oldMember.ToTable());
				operLog.cnnSerialNo = dSerialNo;
				operLog.cnvcOperName = member.cnvcOperName;
				operLog.cndOperDate = member.cndOperDate;
				operLog.cnvcOperFlag = ConstApp.Oper_Flag_InCallBack;
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
        public DataTable SomeMemeber(Member member)
        {
            DataTable dtMember;
            dtMember = SqlHelper.ExecuteDataTable(CommandType.Text, "select cnvcMemberCardNo as ��Ա����,cnvcMemberName as ��λ����,cnvcPaperNo as ����ע���,cnvcMemberRight as ��Ա�ʸ�,cnnPrepay as Ԥ���,cnvcFree as ����  from tbMember where cnvcState like '%" + member.cnvcState + "%' and ( cnvcMemberCardNo like '%" + member.cnvcMemberCardNo + "%' or cnvcPaperNo = '%" + member.cnvcPaperNo + "%' or cnvcMemberName = '%" + member.cnvcMemberName + "%')");
            if (null == dtMember)
            {
                throw new BusinessException("��ѯ����", "δ�����ƻ�Ա��");
            }
            if (dtMember.Rows.Count == 0)
            {
                throw new BusinessException("��ѯ����", "δ�����ƻ�Ա��");
            }
            return dtMember;
        }
        public DataTable SomeInUseFMemeber(FMember fmember)
        {
            DataTable dtMember;
            string strSql = "select cnvcMemberName as ��λ����,cnvcPaperNo as ����ע���  from tbFMember where  1=1 ";
            if (fmember.cnvcMemberName != "")
            {
                strSql += " and cnvcMemberName like '%" + fmember.cnvcMemberName + "%'";
            }
            if (fmember.cnvcPaperNo != "")
            {
                strSql += " and cnvcPaperNo like '%" + fmember.cnvcPaperNo + "%'";
            }
            dtMember = SqlHelper.ExecuteDataTable(CommandType.Text, strSql);
            if (null == dtMember)
            {
                throw new BusinessException("��ѯ����", "δ�����Ʒǻ�Ա��");
            }
            if (dtMember.Rows.Count == 0)
            {
                throw new BusinessException("��ѯ����", "δ�����Ʒǻ�Ա��");
            }

            dtMember.Columns.Add("��Ԥ��չλ");
            foreach (DataRow drMember in dtMember.Rows)
            {
                //Member tMember = new Member(drMember);
                string strRet = "";
                DataTable dtSeat = SqlHelper.ExecuteDataTable(CommandType.Text, "select cnvcSeat  from tbMemberSeat where cnvcMemberCardNo is null and cnvcPaperNo = '" + drMember["����ע���"].ToString() + "' and cnvcState='" + ConstApp.Show_Seat_State_Booking + "'");
                foreach (DataRow drSeat in dtSeat.Rows)
                {
                    strRet += drSeat["cnvcSeat"].ToString() + ",";
                }
                drMember["��Ԥ��չλ"] = strRet;
            }
            return dtMember;
        }

        public DataTable SomeInUseMemeber(Member member)
        {
            DataTable dtMember;
            string strSql = "select cnvcMemberCardNo as ��Ա����,cnvcMemberName as ��λ����,cnvcPaperNo as ����ע���,cnvcFree as ����  from tbMember where cndEndDate >= getdate() and cnvcState='" + ConstApp.Card_State_InUse + "'";
            if (member.cnvcMemberCardNo != "")
            {
                strSql += " and cnvcMemberCardNo like '%" + member.cnvcMemberCardNo + "%'";
            }
            if (member.cnvcMemberName != "")
            {
                strSql += " and cnvcMemberName like '%" + member.cnvcMemberName + "%'";
            }
            if (member.cnvcPaperNo != "")
            {
                strSql += " and cnvcPaperNo like '%" + member.cnvcPaperNo + "%'";
            }
            dtMember = SqlHelper.ExecuteDataTable(CommandType.Text, strSql);
            if (null == dtMember)
            {
                throw new BusinessException("��ѯ����", "δ�����ƻ�Ա��");
            }
            if (dtMember.Rows.Count == 0)
            {
                throw new BusinessException("��ѯ����", "δ�����ƻ�Ա��");
            }
            dtMember.Columns.Add("��Ԥ��չλ");
            foreach (DataRow drMember in dtMember.Rows)
            {
                //Member tMember = new Member(drMember);
                string strRet = "";
                DataTable dtSeat = SqlHelper.ExecuteDataTable(CommandType.Text, "select cnvcSeat  from tbMemberSeat where cnvcMemberCardNo = '" + drMember["��Ա����"].ToString() + "' and cnvcState='" + ConstApp.Show_Seat_State_Booking + "'");
                foreach (DataRow drSeat in dtSeat.Rows)
                {
                    strRet += drSeat["cnvcSeat"].ToString() + ",";
                }
                drMember["��Ԥ��չλ"] = strRet;
            }
            return dtMember;
        }

        public string BookSeat(string strPaperNo)
        {
            string strRet = "";
            DataTable dtSeat = SqlHelper.ExecuteDataTable(CommandType.Text, "select cnvcSeat  from tbMemberSeat where cnvcPaperNo = '" + strPaperNo + "' and cnvcState='" + ConstApp.Show_Seat_State_Booking + "'");
            foreach (DataRow drSeat in dtSeat.Rows)
            {
                strRet += drSeat["cnvcSeat"].ToString() + ",";
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
//					throw new BusinessException("��ѯ����","����Ϊ�գ����ʼ��������");
//				}
//				if (dtValue.Rows.Count == 0)
//				{
//					throw new BusinessException("��ѯ����","����Ϊ�գ����ʼ��������");
//				}				
//				
//			}
//			catch (BusinessException bex) //ҵ���쳣
//			{		
//				//LogAdapter.WriteBusinessException(bex);
//				throw new BusinessException(bex.Type,bex.Message);		
//			}
//			catch (SqlException sex)   //���ݿ��쳣
//			{
//				//����ع�					
//				//trans.Rollback();												
//				//LogAdapter.WriteDatabaseException(sex);				
//				throw new BusinessException("���ݿ��쳣",sex.Message);
//			}
//			catch (Exception ex)		 //�����쳣
//			{
//				//����ع�						
//				//trans.Rollback();						
//				//LogAdapter.WriteFeaturesException(ex);	
//				throw new BusinessException("�����쳣",ex.Message);
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
//				dtType = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select distinct cnvcType as ��Ա���� from tbNameCode");
//				if (null == dtType)
//				{
//					throw new BusinessException("��ѯ����","����Ϊ�գ����ʼ��������");
//				}
//				if (dtType.Rows.Count == 0)
//				{
//					throw new BusinessException("��ѯ����","����Ϊ�գ����ʼ��������");
//				}				
//				
//			}
//			catch (BusinessException bex) //ҵ���쳣
//			{		
//				//LogAdapter.WriteBusinessException(bex);
//				throw new BusinessException(bex.Type,bex.Message);		
//			}
//			catch (SqlException sex)   //���ݿ��쳣
//			{
//				//����ع�					
//				//trans.Rollback();												
//				//LogAdapter.WriteDatabaseException(sex);				
//				throw new BusinessException("���ݿ��쳣",sex.Message);
//			}
//			catch (Exception ex)		 //�����쳣
//			{
//				//����ع�						
//				//trans.Rollback();						
//				//LogAdapter.WriteFeaturesException(ex);	
//				throw new BusinessException("�����쳣",ex.Message);
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
//				dtType = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select cnvcCodeID as ����ID,cnvcType as ��������,cnvcValue as ����ֵ from tbNameCode where cnvcType <> '"+ConstApp.MemberPara+"' order by cnvcType,cnvcValue");
//				if (null == dtType)
//				{
//					throw new BusinessException("��ѯ����","����Ϊ�գ����ʼ��������");
//				}
//				if (dtType.Rows.Count == 0)
//				{
//					throw new BusinessException("��ѯ����","����Ϊ�գ����ʼ��������");
//				}				
//				
//			}
//			catch (BusinessException bex) //ҵ���쳣
//			{		
//				//LogAdapter.WriteBusinessException(bex);
//				throw new BusinessException(bex.Type,bex.Message);		
//			}
//			catch (SqlException sex)   //���ݿ��쳣
//			{
//				//����ع�					
//				//trans.Rollback();												
//				//LogAdapter.WriteDatabaseException(sex);				
//				throw new BusinessException("���ݿ��쳣",sex.Message);
//			}
//			catch (Exception ex)		 //�����쳣
//			{
//				//����ع�						
//				//trans.Rollback();						
//				//LogAdapter.WriteFeaturesException(ex);	
//				throw new BusinessException("�����쳣",ex.Message);
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
//				dtNameCode = SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select cnnMemberCodeID as ����ID,cnvcMemberName as ��Ա����,cnvcMemberType as  ��������,cnvcMemberValue as ����ֵ  from tbMemberCode order by ��Ա����,��������,����ֵ");
////				if (null == dtNameCode)
////				{
////					throw new BusinessException("��ѯ����","����Ϊ�գ����ʼ��������");
////				}
////				if (dtNameCode.Rows.Count == 0)
////				{
////					throw new BusinessException("��ѯ����","����Ϊ�գ����ʼ��������");
////				}				
//				
//			}
//			catch (BusinessException bex) //ҵ���쳣
//			{		
//				//LogAdapter.WriteBusinessException(bex);
//				throw new BusinessException(bex.Type,bex.Message);		
//			}
//			catch (SqlException sex)   //���ݿ��쳣
//			{
//				//����ع�					
//				//trans.Rollback();												
//				//LogAdapter.WriteDatabaseException(sex);				
//				throw new BusinessException("���ݿ��쳣",sex.Message);
//			}
//			catch (Exception ex)		 //�����쳣
//			{
//				//����ع�						
//				//trans.Rollback();						
//				//LogAdapter.WriteFeaturesException(ex);	
//				throw new BusinessException("�����쳣",ex.Message);
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
//					throw new BusinessException("��ѯ����","����Ϊ�գ����ʼ��������");
//				}
//				if (dtNameCode.Rows.Count == 0)
//				{
//					throw new BusinessException("��ѯ����","����Ϊ�գ����ʼ��������");
//				}				
//				
//			}
//			catch (BusinessException bex) //ҵ���쳣
//			{		
//				//LogAdapter.WriteBusinessException(bex);
//				throw new BusinessException(bex.Type,bex.Message);		
//			}
//			catch (SqlException sex)   //���ݿ��쳣
//			{
//				//����ع�					
//				//trans.Rollback();												
//				//LogAdapter.WriteDatabaseException(sex);				
//				throw new BusinessException("���ݿ��쳣",sex.Message);
//			}
//			catch (Exception ex)		 //�����쳣
//			{
//				//����ع�						
//				//trans.Rollback();						
//				//LogAdapter.WriteFeaturesException(ex);	
//				throw new BusinessException("�����쳣",ex.Message);
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
//					throw new BusinessException("��ѯ����","����Ϊ�գ����ʼ��������");
//				}
//				if (dtNameCode.Rows.Count == 0)
//				{
//					throw new BusinessException("��ѯ����","����Ϊ�գ����ʼ��������");
//				}				
//				
//			}
//			catch (BusinessException bex) //ҵ���쳣
//			{		
//				//LogAdapter.WriteBusinessException(bex);
//				throw new BusinessException(bex.Type,bex.Message);		
//			}
//			catch (SqlException sex)   //���ݿ��쳣
//			{
//				//����ع�					
//				//trans.Rollback();												
//				//LogAdapter.WriteDatabaseException(sex);				
//				throw new BusinessException("���ݿ��쳣",sex.Message);
//			}
//			catch (Exception ex)		 //�����쳣
//			{
//				//����ع�						
//				//trans.Rollback();						
//				//LogAdapter.WriteFeaturesException(ex);	
//				throw new BusinessException("�����쳣",ex.Message);
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
            NameCode memberCode = new NameCode();
            memberCode.cnvcCodeID = nameCode.cnvcCodeID;
            oldNameCode = EntityMapping.Get(memberCode) as NameCode;
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

		public void DeleteNameCode(NameCode nameCode)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();				
				trans = conn.BeginTransaction();
				EntityMapping.Delete(nameCode,trans);				
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

		public void ModifyNameCode(NameCode nameCode)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();					
				trans = conn.BeginTransaction();
				EntityMapping.Update(nameCode,trans);				
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

		public void AddMemberCode(MemberCode memberCode)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Create(memberCode,trans);				
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

		public void ModifyMemberCode(MemberCode memberCode)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Update(memberCode,trans);				
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
		public void DeleteMemberCode(MemberCode memberCode)
		{
			try
			{
				conn = ConnectionPool.BorrowConnection();
				trans = conn.BeginTransaction();
				EntityMapping.Delete(memberCode,trans);				
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

        public void getFree(MemberCode memberCode)
        {
            string strFree = "";
            DataTable dtMemberCode = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbMemberCode where cnvcMemberName='" + memberCode.cnvcMemberName + "' and cnvcMemberType = '" + memberCode.cnvcMemberType + "'");
            strFree = dtMemberCode.Rows[0]["cnvcMemberValue"].ToString();
        }
		/// <summary>
		/// �ͷ�չλ
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
					throw new BusinessException("�ͷ�չλ","δ�ҵ�ָ��չλ��");
				}
				ShowSeat ss = new ShowSeat(dtShowSeat);
				if (ss.cnvcState != ConstApp.Show_Seat_State_SignIn)
				{
					throw new BusinessException("�ͷ�չλ","չλδǩ�������ܽ����ͷ�չλ������");
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
					throw new BusinessException("�ͷ�չλ","δ�ҵ�ʹ�ô�չλ�Ļ�Ա��ǻ�Ա");
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
		/// ��λ
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
					throw new BusinessException("��λ","δ�ҵ�ָ��չλ");
				}
				if (dtShowSeat.Rows[0]["cnvcState"].ToString() != "")
				{
					if (dtShowSeat.Rows[0]["cnvcState"].ToString() != memberSeat.cnvcOperName)
					{
						throw new BusinessException("��λ","չλ�ѱ�ʹ��");
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
					throw new BusinessException("��λ","�����쳣");
				}
				if (dtMemberSeat.Rows.Count == 0)
				{
					throw new BusinessException("��λ","������ǩ��չλ");
				}
				DataRow[] drSignIns = dtMemberSeat.Select("cnvcState = '"+ConstApp.Show_Seat_State_SignIn+"'");
				DataRow[] drNoSignIns = dtMemberSeat.Select("cnvcState = '"+ConstApp.Show_Seat_State_Release+"'");
				if (drNoSignIns.Length == 0)
				{
					throw new BusinessException("��λ","�������ͷ�չλ");
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
					throw new Exception("û���޸ļ�¼");
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

        public void PointsAdd(SqlTransaction trans,string strFeeFlag,string strMemberRight,string strMemberCardNo,string strOperName,DateTime dOperDate, decimal dfee)
        {
            string strMemberType = "";
            switch (strFeeFlag)
            {
                case ConstApp.Fee_Flag_Card:
                    strMemberType = ConstApp.PointsBK;
                    break;
                case ConstApp.Fee_Flag_InMoney:
                    strMemberType = ConstApp.PointsCZ;
                    break;
                case ConstApp.Fee_Flag_SignIn:
                    strMemberType = ConstApp.PointsMF;
                    break;
                case ConstApp.Fee_Flag_Product:
                    strMemberType = ConstApp.PointsXF;
                    break;
            }
            if (strFeeFlag == ConstApp.Fee_Flag_Card)
            {
                strMemberType = ConstApp.PointsBK;
            }

            string strsql = "select * from tbMemberCode where cnvcMemberName='" + strMemberRight + "' and cnvcMemberType='" + strMemberType + "'";
            DataTable dt = SqlHelper.ExecuteDataTable(trans, CommandType.Text, strsql);
            if (dt.Rows.Count > 0)
            {
                string strpoints = dt.Rows[0]["cnvcMemberValue"].ToString();
                int ipoints = 0;// Convert.ToInt32(strpoints);
                switch (strFeeFlag)
                {
                    case ConstApp.Fee_Flag_Card:
                        ipoints = Convert.ToInt32(strpoints);
                        break;
                    case ConstApp.Fee_Flag_InMoney:
                        ipoints = Convert.ToInt32(strpoints)*Convert.ToInt32(Math.Round(dfee))/100;
                        break;
                    case ConstApp.Fee_Flag_SignIn:
                        ipoints = Convert.ToInt32(strpoints);
                        break;
                    case ConstApp.Fee_Flag_Product:
                        ipoints = Convert.ToInt32(strpoints) * Convert.ToInt32(Math.Round(dfee)) / 100;
                        break;
                }
                if (ipoints > 0)
                {
                    MemberPoints mp = new MemberPoints();
                    mp.cnvcMemberCardNo = strMemberCardNo;
                    mp = EntityMapping.Get(mp, trans) as MemberPoints;
                    if (mp == null)
                    {
                        mp = new MemberPoints();
                        mp.cnvcMemberCardNo = strMemberCardNo;
                        mp.cnnPoints = ipoints;
                        EntityMapping.Create(mp, trans);
                    }
                    else
                    {
                        mp.cnnPoints = mp.cnnPoints + ipoints;
                        EntityMapping.Update(mp, trans);
                    }

                    MemberPointsLog mpl = new MemberPointsLog();
                    mpl.cnnPoints = mp.cnnPoints;
                    mpl.cnvcMemberCardNo = strMemberCardNo;
                    mpl.cnvcOperName = strOperName;
                    mpl.cnvcOperDate = dOperDate;
                    mpl.cnvcOperFlag = strFeeFlag;
                    EntityMapping.Create(mpl, trans);
                }
            }
        }

        public void InMoneySetting(bool bIs)
        {
            DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbNameCode where cnvcType='"+ConstApp.InMoneySetting+"'");
            if (dt.Rows.Count > 0)
            {
                NameCode nc = new NameCode(dt);
                nc.cnvcValue = bIs ? "1" : "0";
                EntityMapping.Update(nc);
            }
            else
            {
                NameCode nc = new NameCode();
                nc.cnvcType = ConstApp.InMoneySetting;
                nc.cnvcValue = bIs ? "1" : "0";
                EntityMapping.Create(nc);
            }
        }
        public void AddInMoney(int icount,int ibegin,int ipercent,int iup)
        {
            try
            {
                conn = ConnectionPool.BorrowConnection();
                trans = conn.BeginTransaction();
                DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbNameCode where cnvcType like '��ֵ����%-��ʼ���' and cnvcValue='"+ibegin.ToString()+"'");
                if (dt.Rows.Count > 0) throw new BusinessException("��ֵ���͹���", "��ͬ��ʼ���Ĺ����Ѵ��ڣ���ɾ����������ӣ�");
                NameCode nc = new NameCode();
                nc.cnvcType = ConstApp.InMoneySetting + icount.ToString()+"-��ʼ���";
                nc.cnvcValue = ibegin.ToString();
                EntityMapping.Create(nc);

                nc = new NameCode();
                nc.cnvcType = ConstApp.InMoneySetting + icount.ToString() + "-���ͱ���";
                nc.cnvcValue = ipercent.ToString();
                EntityMapping.Create(nc);

                nc = new NameCode();
                nc.cnvcType = ConstApp.InMoneySetting + icount.ToString() + "-�����޶�";
                nc.cnvcValue = iup.ToString();
                EntityMapping.Create(nc);

                trans.Commit();
            }
            catch (BusinessException bex) //ҵ���쳣
            {
                //����ع�					
                trans.Rollback();
                //LogAdapter.WriteBusinessException(bex);
                throw new BusinessException(bex.Type, bex.Message);
            }
            catch (SqlException sex)   //���ݿ��쳣
            {
                //����ع�					
                trans.Rollback();
                //LogAdapter.WriteDatabaseException(sex);				
                throw new BusinessException("���ݿ��쳣", sex.Message);
            }
            catch (Exception ex)		 //�����쳣
            {
                //����ع�						
                trans.Rollback();
                //LogAdapter.WriteFeaturesException(ex);	
                throw new BusinessException("�����쳣", ex.Message);
            }
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
        }
        public void DelInMoney(string strid)
        {
            SqlHelper.ExecuteNonQuery(CommandType.Text,"delete from tbNameCode where cnvcType like '"+ConstApp.InMoneySetting+strid+"%'");
        }

        public decimal GetInMoneySetting(SqlTransaction trans,decimal invalue)
        {
            string strsql = "select * from tbNameCode where cnvcType = '��ֵ����' and cnvcValue='1'";
            DataTable dt = null;
            if(trans!=null)
                dt = SqlHelper.ExecuteDataTable(trans, CommandType.Text, strsql);
            else
                dt = SqlHelper.ExecuteDataTable( CommandType.Text, strsql);
            if (dt.Rows.Count == 0) return 0;
            strsql = @"select convert(int,a.id) as cnnID,convert(int,a.cnnBegin) as cnnBegin,convert(int,b.cnnPercent) cnnPercent,convert(int,c.cnnUp) cnnUp from 
(select SUBSTRING(cnvctype,5,len(cnvctype)-9) as id ,cnvcvalue as cnnBegin from tbNameCode where cnvcType like '��ֵ����%' and cnvcType<>'��ֵ����'
and SUBSTRING(cnvctype,len(cnvctype)-4+1,4)='��ʼ���') a left join 
(select SUBSTRING(cnvctype,5,len(cnvctype)-9) as id,cnvcvalue as cnnPercent from tbNameCode where cnvcType like '��ֵ����%' and cnvcType<>'��ֵ����'
and SUBSTRING(cnvctype,len(cnvctype)-4+1,4)='���ͱ���') b on a.id=b.id left join 
(select SUBSTRING(cnvctype,5,len(cnvctype)-9) as id,cnvcvalue as cnnUp from tbNameCode where cnvcType like '��ֵ����%' and cnvcType<>'��ֵ����'
and SUBSTRING(cnvctype,len(cnvctype)-4+1,4)='�����޶�') c on a.id=c.id";

            if (trans != null)
                dt = SqlHelper.ExecuteDataTable(trans, CommandType.Text, strsql);//.ToString();
            else
                dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);//.ToString();
            //dt.Select("cnnBegin<=" + invalue.ToString(),);
            string strBegin = dt.Compute("max(cnnBegin)","cnnBegin<=" + invalue.ToString()).ToString();
            if (string.IsNullOrEmpty(strBegin)) return 0;

            DataRow[] drMs = dt.Select("cnnBegin="+strBegin, "cnnBegin");
            decimal dPercent = Convert.ToDecimal(drMs[0]["cnnPercent"]);
            decimal dUp = Convert.ToDecimal(drMs[0]["cnnUp"]);

            if (dPercent == 0) return dUp;
            else
                return invalue * dPercent / 100;

            //strsql = "select cnvcvalue from tbNameCode where cnvcType like '��ֵ����%-��ʼ���'";// and cnvcValue<='"+invalue.ToString()+"'";
            ////string strvalue = "";
            //if(trans!=null)
            //    dt = SqlHelper.ExecuteDataTable(trans, CommandType.Text, strsql);//.ToString();
            //else
            //    dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);//.ToString();
            ////if(string.IsNullOrEmpty(strvalue)) return 0;
            //if (dt.Rows.Count == 0) return 0;
            //decimal dvalue = 0;
            //decimal dtemp = 0;
            //List<decimal> ltemp = new List<decimal>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ltemp.Add(Convert.ToDecimal(dr[0]));
            //}
            //ltemp.Sort();
            //foreach (decimal dtemp2 in ltemp)
            //{
            //    if (dtemp2 <= invalue)
            //    {
            //        if (dtemp <= dtemp2)
            //        {
            //            dtemp = dtemp2;
            //            dvalue = dtemp2;
            //        }
            //        //break;
            //    }
            //}
            //strsql = "select * from tbNameCode  where cnvcType like '��ֵ����%-��ʼ���' and cnvcValue='"+dvalue.ToString()+"'";
            //if(trans!=null)
            //dt = SqlHelper.ExecuteDataTable(trans,CommandType.Text, strsql);
            //else
            //dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);
            //if (dt.Rows.Count == 0) return 0;
            //NameCode nc = new NameCode(dt);
            ////strsql = "select * from tbNameCode where cnvcType like '" + nc.cnvcType.Split('-')[0] + "-���ͱ���" + "'";
            ////if (trans != null)
            ////    dt = SqlHelper.ExecuteDataTable(trans, CommandType.Text, strsql);
            ////else
            ////    dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);
            ////if (dt.Rows.Count == 0) return 0;
            ////nc = new NameCode(dt);
            ////string strpercent = nc.cnvcValue;
            //strsql = "select * from tbNameCode where cnvcType like '" + nc.cnvcType.Split('-')[0] + "-�����޶�" + "'";
            //if (trans != null)
            //    dt = SqlHelper.ExecuteDataTable(trans, CommandType.Text, strsql);
            //else
            //    dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);
            //if (dt.Rows.Count == 0) return 0;
            //nc = new NameCode(dt);
            //string strup = nc.cnvcValue;

            ////decimal dpercent = Convert.ToDecimal(strpercent);
            //decimal dup = Convert.ToDecimal(strup);

            ////decimal dDonate = dpercent * invalue / 100;
            ////if (dDonate > dup) return dup;
            //return dup;
        }

        public decimal GetInMoneySetting(decimal invalue)
        {
            return GetInMoneySetting(null, invalue);
        }
        public void SetCardType(string strType)
        {
            string strsql = "select * from tbNameCode where cnvcType='"+ConstApp.CardType+"'";
            DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);
            if (dt.Rows.Count == 0)
            {
                NameCode nc = new NameCode();
                nc.cnvcType = ConstApp.CardType;
                nc.cnvcValue = strType;
                EntityMapping.Create(nc);
            }
            else
            {
                NameCode nc = new NameCode(dt);
                nc.cnvcValue = strType;
                EntityMapping.Update(nc);
            }
        }
        public void SetCardTypeName(string strType,string strName)
        {
            string strsql = "select * from tbNameCode where cnvcType='" + strType + "'";
            DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);
            if (dt.Rows.Count == 0)
            {
                NameCode nc = new NameCode();
                nc.cnvcType = strType;
                nc.cnvcValue = strName;
                EntityMapping.Create(nc);
            }
            else
            {
                NameCode nc = new NameCode(dt);
                nc.cnvcValue = strName;
                EntityMapping.Update(nc);
            }
        }
        public string GetCardTypeName(string strType)
        {
            string strName = "";
            string strsql = "select * from tbNameCode where cnvcType='" + strType + "'";
            DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);
            if (dt.Rows.Count == 0)
            {
                switch (strType)
                {
                    case ConstApp.CardType_L6:
                        strName = "һͨ��";
                        break;
                    case ConstApp.CardType_L8:
                        strName = "�Ǵο�";
                        break;
                }
            }
            else
            {
                NameCode nc = new NameCode(dt);
                strName = nc.cnvcValue;
            }
            return strName;
        }
	}
}
