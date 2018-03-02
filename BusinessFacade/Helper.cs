
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	SecurityManage.cs
* ����:	     ֣��
* ��������:    2008-01-04
* ��������:    �����ѯ

*                                                           Copyright(C) 2007 zhenghua
*************************************************************************************/
using System;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using ynhrMemberManage.Print;
using Infragistics;
using Infragistics.Win;
using Infragistics.Win.Printing;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using Infragistics.Win.UltraWinSchedule;
using Infragistics.Win.UltraWinSchedule.CalendarCombo;
using Infragistics.Win.UltraWinEditors;
using System.Windows;
using System.Windows.Forms;
using ynhrMemberManage.Common;
namespace ynhrMemberManage.BusinessFacade
{
	public class ProductCode
	{
		public string cnvcProductName = "";
		public string cnvcProductPrice = "";
		public string cnvcProductDiscount = "";
	};
	/// <summary>
	/// Summary description for Query.
	/// </summary>
	public class Helper
	{
		public Helper()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// ��ѯ
		/// </summary>
		/// <param name="strSql"></param>
		/// <returns></returns>
		/// 
		#region
        public static DataTable Query(string strSql)
        {
            return SqlHelper.ExecuteDataTable(CommandType.Text, strSql);
        }
		
		#endregion

        public static string CreateCardNo()
        {
            string strRet = "";
            string strCount = SqlHelper.ExecuteScalar(CommandType.Text, "select count(*) from tbMember where Len(cnvcMemberCardNo)=8 ").ToString();

            int iCount = int.Parse(strCount) + 1;
            string strCardNo = iCount.ToString();
            if (strCardNo.Length == 1)
            {
                strRet = "A000000" + strCardNo;
            }
            else if (strCardNo.Length == 2)
            {
                strRet = "A00000" + strCardNo;
            }
            else if (strCardNo.Length == 3)
            {
                strRet = "A0000" + strCardNo;
            }
            else if (strCardNo.Length == 4)
            {
                strRet = "A000" + strCardNo;
            }
            else if (strCardNo.Length == 5)
            {
                strRet = "A00" + strCardNo;
            }
            else if (strCardNo.Length == 6)
            {
                strRet = "A0" + strCardNo;
            }
            else if (strCardNo.Length == 7)
            {
                strRet = "A" + strCardNo;
            }
            else if (strCardNo.Length == 8)
            {

                strRet = "B000000" + (iCount - 9999999).ToString();
            }
            else
            {
                strRet = "C0000000";
            }
            return strRet;
        }
        
		public static DataTable BindProduct()
		{
			DataTable dtProduct = Query("select a.cnvcValue as cnvcProductName,b.cnvcMemberType,b.cnvcMemberValue from "
				+" (select * from tbNameCode where cnvcType = '�����Ʒ')a "
				+" left outer join "
				+" tbMemberCode b on a.cnvcValue = b.cnvcMemberName");
			int oldCount = dtProduct.Rows.Count;
			Hashtable htProduct = new Hashtable();
			foreach (DataRow drProduct in dtProduct.Rows)
			{
				if (htProduct.ContainsKey(drProduct["cnvcProductName"].ToString()))
				{
					ProductCode p = (ProductCode)htProduct[drProduct["cnvcProductName"].ToString()];
					if (drProduct["cnvcMemberType"].ToString().Equals(ConstApp.ProductPrice))
					{
						p.cnvcProductPrice = drProduct["cnvcMemberValue"].ToString();
					}
					if (drProduct["cnvcMemberType"].ToString().Equals(ConstApp.ProductDiscount))
					{
						p.cnvcProductDiscount = drProduct["cnvcMemberValue"].ToString();
					}
				}
				else
				{
					ProductCode p = new ProductCode();
					p.cnvcProductName = drProduct["cnvcProductName"].ToString();
					if (drProduct["cnvcMemberType"].ToString().Equals(ConstApp.ProductPrice))
					{
						p.cnvcProductPrice = drProduct["cnvcMemberValue"].ToString();
					}
					if (drProduct["cnvcMemberType"].ToString().Equals(ConstApp.ProductDiscount))
					{
						p.cnvcProductDiscount = drProduct["cnvcMemberValue"].ToString();
					}
					htProduct.Add(p.cnvcProductName,p);
				}
				
			}
			DataTable dtProductNew = new DataTable();
			dtProductNew.Columns.Add("cnvcIsSelected");
			dtProductNew.Columns.Add("cnvcProductName");
			dtProductNew.Columns.Add("cnnProductPrice");
			dtProductNew.Columns.Add("cnnProductDiscount");
			dtProductNew.Columns.Add("cnnPrepay");
			dtProductNew.Columns.Add("cnvcFree");
			IDictionaryEnumerator myEnumerator = htProduct.GetEnumerator();
			while ( myEnumerator.MoveNext() )
			{
				DataRow drProduct = dtProductNew.NewRow();
				ProductCode p = (ProductCode)myEnumerator.Value;
				drProduct["cnvcIsSelected"] = "false";
				drProduct["cnvcFree"] = "1";
				drProduct["cnvcProductName"] = p.cnvcProductName;
				drProduct["cnnProductPrice"] = p.cnvcProductPrice;
				drProduct["cnnProductDiscount"] = p.cnvcProductDiscount;
				if (p.cnvcProductPrice == "" ||p.cnvcProductDiscount == "")
				{
					drProduct["cnnPrepay"] = p.cnvcProductPrice;
				}
				if (p.cnvcProductPrice != "" && p.cnvcProductDiscount != "")
				{
					drProduct["cnnPrepay"] = (int.Parse(p.cnvcProductPrice)*int.Parse(p.cnvcProductDiscount))/100;
				}

				dtProductNew.Rows.Add(drProduct);
			}
			//			DataView dvProduct = dtProductNew.Copy().DefaultView;
			//			dvProduct.Sort = "cnvcProductName";
			//			DataTable dtProductSort = dvProduct.Table.Copy();
			DataRow[] drProducts = dtProductNew.Select("cnnProductPrice <>'' and cnnProductDiscount <>''","cnvcProductName asc");
			DataTable dtProductSort = dtProductNew.Clone();
			//dtProductSort.Clear();
			foreach (DataRow drProduct in drProducts)
			{
				dtProductSort.ImportRow(drProduct);
			}
			int newCount = dtProductSort.Rows.Count;
			//gridProduct.SetDataBinding(dtProductSort,null,true,true);
			if (oldCount != newCount *2)
			{
				MessageBox.Show("�����Ʒ������ȫ","�����Ʒ����");
			}
			return dtProductSort;
		}
		public static void BindProduct(UltraGrid gridProduct)
		{
			DataTable dtProduct = Query("select a.cnvcValue as cnvcProductName,b.cnvcMemberType,b.cnvcMemberValue from "
				                +" (select * from tbNameCode where cnvcType = '�����Ʒ')a "
							    +" left outer join "
				                +" tbMemberCode b on a.cnvcValue = b.cnvcMemberName");
			int oldCount = dtProduct.Rows.Count;
			Hashtable htProduct = new Hashtable();
			foreach (DataRow drProduct in dtProduct.Rows)
			{
				if (htProduct.ContainsKey(drProduct["cnvcProductName"].ToString()))
				{
					ProductCode p = (ProductCode)htProduct[drProduct["cnvcProductName"].ToString()];
					if (drProduct["cnvcMemberType"].ToString().Equals(ConstApp.ProductPrice))
					{
						p.cnvcProductPrice = drProduct["cnvcMemberValue"].ToString();
					}
					if (drProduct["cnvcMemberType"].ToString().Equals(ConstApp.ProductDiscount))
					{
						p.cnvcProductDiscount = drProduct["cnvcMemberValue"].ToString();
					}
				}
				else
				{
					ProductCode p = new ProductCode();
					p.cnvcProductName = drProduct["cnvcProductName"].ToString();
					if (drProduct["cnvcMemberType"].ToString().Equals(ConstApp.ProductPrice))
					{
						p.cnvcProductPrice = drProduct["cnvcMemberValue"].ToString();
					}
					if (drProduct["cnvcMemberType"].ToString().Equals(ConstApp.ProductDiscount))
					{
						p.cnvcProductDiscount = drProduct["cnvcMemberValue"].ToString();
					}
					htProduct.Add(p.cnvcProductName,p);
				}
				
			}
			DataTable dtProductNew = new DataTable();
			dtProductNew.Columns.Add("cnvcIsSelected");
			dtProductNew.Columns.Add("cnvcProductName");
			dtProductNew.Columns.Add("cnnProductPrice");
			dtProductNew.Columns.Add("cnnProductDiscount");
			dtProductNew.Columns.Add("cnnPrepay");
			dtProductNew.Columns.Add("cnvcFree");
			IDictionaryEnumerator myEnumerator = htProduct.GetEnumerator();
			while ( myEnumerator.MoveNext() )
			{
				DataRow drProduct = dtProductNew.NewRow();
				ProductCode p = (ProductCode)myEnumerator.Value;
				drProduct["cnvcIsSelected"] = "false";
				drProduct["cnvcFree"] = "1";
				drProduct["cnvcProductName"] = p.cnvcProductName;
				drProduct["cnnProductPrice"] = p.cnvcProductPrice;
				drProduct["cnnProductDiscount"] = p.cnvcProductDiscount;
				if (p.cnvcProductPrice == "" ||p.cnvcProductDiscount == "")
				{
					drProduct["cnnPrepay"] = p.cnvcProductPrice;
				}
				if (p.cnvcProductPrice != "" && p.cnvcProductDiscount != "")
				{
					drProduct["cnnPrepay"] = (int.Parse(p.cnvcProductPrice)*int.Parse(p.cnvcProductDiscount))/100;
				}

				dtProductNew.Rows.Add(drProduct);
			}
//			DataView dvProduct = dtProductNew.Copy().DefaultView;
//			dvProduct.Sort = "cnvcProductName";
//			DataTable dtProductSort = dvProduct.Table.Copy();
			DataRow[] drProducts = dtProductNew.Select("cnnProductPrice <>'' and cnnProductDiscount <>''","cnvcProductName asc");
			DataTable dtProductSort = dtProductNew.Clone();
			//dtProductSort.Clear();
			foreach (DataRow drProduct in drProducts)
			{
				dtProductSort.ImportRow(drProduct);
			}
			int newCount = dtProductSort.Rows.Count;
			gridProduct.SetDataBinding(dtProductSort,null,true,true);
			if (oldCount != newCount *2)
			{
				MessageBox.Show("�����Ʒ������ȫ","�����Ʒ����");
			}

		}
		public static void BindMemberProduct(UltraGrid gridProduct,string strMemberRight)
		{
			DataTable dtProduct = Query("select 'true' as cnvcIsSelected,* from tbMemberCode  where "
				                + " cnvcMemberName in "
								+ " (select cnvcValue from tbNameCode where cnvcType = '��Ա�ʸ�') "
						        + " and cnvcMemberType in "
                                + " (select cnvcValue from tbNameCode where cnvcType = '�����Ʒ') "
                                + " and cnvcMemberName = '"+strMemberRight+"' ");
			gridProduct.SetDataBinding(dtProduct,null,true,true);
		}
		public static void BindSynch(UltraComboEditor cmbSynch)
		{
			cmbSynch.Items.Add("0","��Աϵͳ");
			cmbSynch.Items.Add("1","��վ����");
			cmbSynch.Items.Add("2","����������");
            cmbSynch.Items.Add("3", "�ͷ�Ԥ��");
		}
		
		/// <summary>
		/// �󶨻�Ա��������
		/// </summary>
		/// <param name="cmbMemberCode"></param>
		public static void BindMemberCode(UltraComboEditor cmbMemberCode,string strMember)
		{
			ArrayList alMemberCode = new ArrayList();
			if (strMember == ConstApp.MemberType)
			{				
				alMemberCode.Add(ConstApp.FreeType);
				alMemberCode.Add(ConstApp.BookDate);
				alMemberCode.Add(ConstApp.DisabledDate);
				alMemberCode.Add(ConstApp.MemberDiscount);
				alMemberCode.Add(ConstApp.MemberSeats);
				alMemberCode.Add(ConstApp.MemberFee);
				alMemberCode.Add(ConstApp.BookTimes);

                alMemberCode.Add(ConstApp.PointsBK);
                alMemberCode.Add(ConstApp.PointsCZ);
                alMemberCode.Add(ConstApp.PointsXF);
                alMemberCode.Add(ConstApp.PointsJF);

				DataTable dtProduct = Query("select * from tbNameCode where cnvcType = '"+ConstApp.Product+"' order by cnvcValue");
				foreach (DataRow drProduct in dtProduct.Rows)
				{
					NameCode namceCode = new NameCode(drProduct);
					if (!alMemberCode.Contains(namceCode.cnvcValue))
					{
						alMemberCode.Add(namceCode.cnvcValue);
					}
				}
			}
			if (strMember == ConstApp.Product)
			{
				alMemberCode.Add(ConstApp.ProductPrice);
				alMemberCode.Add(ConstApp.ProductDiscount);
                alMemberCode.Add(ConstApp.ProductPoints);
			}
			
			cmbMemberCode.SetDataBinding(alMemberCode,null);
		}

		public static void BindNameCodeType(UltraComboEditor cmbType)
		{
			ArrayList alMemberCode = new ArrayList();
			alMemberCode.Add(ConstApp.MemberType);
			alMemberCode.Add(ConstApp.EnterpriseType);
			alMemberCode.Add(ConstApp.BookDate);
			alMemberCode.Add(ConstApp.Trade);
			//alMemberCode.Add(ConstApp.Product);
			alMemberCode.Add(ConstApp.tishi);
			alMemberCode.Add(ConstApp.TouchFlash);
			alMemberCode.Add(ConstApp.TouchBookBeginDate);
			alMemberCode.Add(ConstApp.TouchBookEndDate);
			alMemberCode.Add(ConstApp.TouchSignInBeginDate);
			alMemberCode.Add(ConstApp.TouchSignInEndDate);
            alMemberCode.Add(ConstApp.JobListBeginDate);
            alMemberCode.Add(ConstApp.JobListEndDate);

            alMemberCode.Add(ConstApp.JobBookingListBeginDate);
            alMemberCode.Add(ConstApp.JobBookingListEndDate);

            alMemberCode.Add(ConstApp.JobRemainListBeginDate);
            alMemberCode.Add(ConstApp.JobRemainListEndDate);
            alMemberCode.Add(ConstApp.NetBookBeforeDate);
            alMemberCode.Add(ConstApp.InMoneyDiscount);
			cmbType.SetDataBinding(alMemberCode,null);
		}
        public static void BindNameCodeProductType(UltraComboEditor cmbType)
        {
            ArrayList alMemberCode = new ArrayList();
            //alMemberCode.Add(ConstApp.MemberType);
            //alMemberCode.Add(ConstApp.EnterpriseType);
            //alMemberCode.Add(ConstApp.BookDate);
            //alMemberCode.Add(ConstApp.Trade);
            alMemberCode.Add(ConstApp.Product);
            //alMemberCode.Add(ConstApp.tishi);
            //alMemberCode.Add(ConstApp.TouchFlash);
            //alMemberCode.Add(ConstApp.TouchBookBeginDate);
            //alMemberCode.Add(ConstApp.TouchBookEndDate);
            //alMemberCode.Add(ConstApp.TouchSignInBeginDate);
            //alMemberCode.Add(ConstApp.TouchSignInEndDate);

            cmbType.SetDataBinding(alMemberCode, null);
        }
		public static void BindMember(UltraComboEditor cmbMember)
		{
			ArrayList alMember = new ArrayList();
			alMember.Add("��Ա");
			alMember.Add("�ǻ�Ա");
			cmbMember.SetDataBinding(alMember,null);

		}
        public static void BindCost(UltraComboEditor cmbMember)
        {
            ArrayList alMember = new ArrayList();
            alMember.Add("������");
            //alMember.Add("�ǻ�Ա");
            cmbMember.SetDataBinding(alMember, null);

        }
		public static void AddDirection(UltraComboEditor cmbDirection)
		{
			cmbDirection.Items.Add("��","��");
			cmbDirection.Items.Add("��","��");
			cmbDirection.Items.Add("��","��");
			cmbDirection.Items.Add("��","��");
			cmbDirection.Items.Add("�պ�","�պ�");
		}
        public static void BindJob(UltraComboEditor cmbShow)
        {
            string strSql = "select * from tbJob where cndEndDate>=getdate() order by cndBeginDate";
            //			string strSql = "select * from tbJob  order by cndBeginDate";
            //if (ca.strJobBeginDate != "")
            //{
            //    strSql = "select * from tbJob where convert(varchar(10),cndBeginDate,121)>='" + ca.strJobBeginDate + "'";
            //    if (ca.strJobEndDate != "")
            //        strSql += " and convert(varchar(10),cndEndDate,121)<='" + ca.strJobEndDate + "'";
            //}
            //else
            //{
            //    if (ca.strJobEndDate != "")
            //        strSql = "select * from tbJob where convert(varchar(10),cndEndDate,121)<='" + ca.strJobEndDate + "'";
            //}
            //JobManage jobManage = new JobManage();
            DataTable dtJob = Query(strSql);//jobManage.GetAllJob();
            cmbShow.DataSource = dtJob;
            cmbShow.ValueMember = "cnnID";
            cmbShow.DisplayMember = "cnvcJobName";
            cmbShow.DataBind();
        }
		public static void BindJob_Query(UltraComboEditor cmbShow)
		{
			//			string strSql = "select * from tbJob where cndEndDate>=getdate() order by cndBeginDate";
			string strSql = "select * from tbJob  order by cndBeginDate";

			//JobManage jobManage = new JobManage();
			DataTable dtJob = Query(strSql);//jobManage.GetAllJob();
			cmbShow.DataSource = dtJob;
			cmbShow.ValueMember = "cnnID";
			cmbShow.DisplayMember = "cnvcJobName";
			cmbShow.DataBind();
		}
		public static void BindJob_Query_Filter(UltraComboEditor cmbShow,bool bBeginDate,string strBeginDate,bool bEndDate,string strEndDate)
		{
			//			string strSql = "select * from tbJob where cndEndDate>=getdate() order by cndBeginDate";
			string strSql = "select * from tbJob where 1=1 ";
			if(bBeginDate)
				strSql += " and Convert(char(10),cndBeginDate,121)>='"+strBeginDate+"' ";
			if(bEndDate)
				strSql += " and Convert(char(10),cndEndDate,121)<='"+strEndDate+"' ";
			strSql += " order by cndBeginDate ";
//			strSql = "select * from tbJob "
//							+" where Convert(char(10),cndBeginDate,121)>='"+strBeginDate+"' "
//							+"and Convert(char(10),cndEndDate,121)<='"+strEndDate+"' "
//							+"order by cndBeginDate";
			//JobManage jobManage = new JobManage();
			DataTable dtJob = Query(strSql);//jobManage.GetAllJob();
			cmbShow.DataSource = dtJob;
			cmbShow.ValueMember = "cnnID";
			cmbShow.DisplayMember = "cnvcJobName";
			cmbShow.DataBind();
		}
		public static void BindJob_Query_Limit(UltraComboEditor cmbShow)
		{
			//			string strSql = "select * from tbJob where cndEndDate>=getdate() order by cndBeginDate";
			string strSql = "select * from tbJob where DATEDIFF (day,cndBeginDate,getdate())<=20 "
						  + " or DATEDIFF (day,getdate(),cndBeginDate)>=-20 "
						  + " or DATEDIFF (day,cndEndDate,getdate())<=20 "
						  + " or DATEDIFF (day,getdate(),cndEndDate)>=-20  order by cndBeginDate";

			//JobManage jobManage = new JobManage();
			DataTable dtJob = Query(strSql);//jobManage.GetAllJob();
			cmbShow.DataSource = dtJob;
			cmbShow.ValueMember = "cnnID";
			cmbShow.DisplayMember = "cnvcJobName";
			cmbShow.DataBind();
		}
		public static void BindInfoWay(UltraComboEditor cmbInfoWay)
		{			
			cmbInfoWay.Items.Add("�Դ�","�Դ�");
			cmbInfoWay.Items.Add("��һ��","��һ��");
			cmbInfoWay.Items.Add("����","����");
			cmbInfoWay.Items.Add("����","����");
			cmbInfoWay.Items.Add("�����","�����");
		}
		public static void PrintTicket(PrintedBill pBill)
		{
			//pBill.Print()
			PrintEngine printEngine = new PrintEngine();
			printEngine.AddPrintObject(pBill);
			printEngine.Print();
		}
		public static void PrintTouchTicket(TouchPrintedBill pBill)
		{
			//pBill.Print()
			TouchPrintEngine printEngine = new TouchPrintEngine();
			printEngine.AddPrintObject(pBill);
			printEngine.Print();
		}
		public static void PrintTicket(PrintPageEventArgs e,Member pMember)
		{
			//String drawString = "�����˲��г�";
			Font drawFontTitle = new Font("Arial", 14);
			Font drawFontBody = new Font("Arial", 8);
			
			//Font aa = new Font()
			SolidBrush drawBrush = new SolidBrush(Color.Black);			

			StringFormat drawFormat = new StringFormat();
			drawFormat.FormatFlags = StringFormatFlags.DisplayFormatControl;

			Pen p = new Pen(drawBrush,1.0f);
			p.DashStyle = DashStyle.Dash;

			e.Graphics.DrawString("�����˲��г�", drawFontTitle, drawBrush, 50.0f, 40.0f, drawFormat);
			e.Graphics.DrawLine(p,0.0f,68.0f,300.0f,68.0f);
			e.Graphics.DrawString("��Ա���ţ�", drawFontBody, drawBrush, 35.0f, 70.0F, drawFormat);
			e.Graphics.DrawString(pMember.cnvcMemberCardNo, drawFontBody, drawBrush, 115.0f, 70.0F, drawFormat);
			e.Graphics.DrawString("��λ���ƣ�", drawFontBody, drawBrush, 35.0f, 85.0F, drawFormat);
			e.Graphics.DrawString(pMember.cnvcMemberName, drawFontBody, drawBrush, 115.0f, 85.0F, drawFormat);
			e.Graphics.DrawString("����ע��ţ�", drawFontBody, drawBrush, 35.0f, 100.0F, drawFormat);
			e.Graphics.DrawString(pMember.cnvcPaperNo, drawFontBody, drawBrush, 115.0f, 100.0F, drawFormat);
			e.Graphics.DrawString("չλ��", drawFontBody, drawBrush, 35.0f, 115.0F, drawFormat);
			e.Graphics.DrawString(pMember.cnvcProduct, drawFontBody, drawBrush, 115.0f, 115.0F, drawFormat);
			e.Graphics.DrawString("��ѳ���ʣ��", drawFontBody, drawBrush, 35.0f, 130.0F, drawFormat);
			e.Graphics.DrawString(pMember.cnvcFree, drawFontBody, drawBrush, 115.0f, 130.0F, drawFormat);

			e.Graphics.DrawLine(p,0.0f,145.0f,300.0f,145.0f);
			
			e.Graphics.DrawString("����Ա��", drawFontBody, drawBrush, 35.0f, 145.0F, drawFormat);			
			e.Graphics.DrawString(pMember.cnvcOperName, drawFontBody, drawBrush, 115.0f, 145.0F, drawFormat);
			
			
			e.Graphics.DrawString("ǩ��ʱ�䣺"+DateTime.Now.ToShortDateString()+"  "+DateTime.Now.ToShortTimeString(), drawFontBody, drawBrush, 35.0f, 160.0F, drawFormat);
		}
		public static void SetlblDirection(zhhLabel lbl,string strDirection)
		{
			//switch (cmbDirection.Text)
			switch (strDirection)
			{
				case "��":
					lbl.BorderBottom = System.Drawing.Color.Black;
					lbl.BorderLeft = System.Drawing.Color.Black;
					lbl.BorderRight = System.Drawing.Color.Black;
					lbl.BorderTop = System.Drawing.Color.Transparent;
					break;
				case "��":
					lbl.BorderBottom = System.Drawing.Color.Transparent;
					lbl.BorderLeft = System.Drawing.Color.Black;
					lbl.BorderRight = System.Drawing.Color.Black;
					lbl.BorderTop = System.Drawing.Color.Black;
					break;
				case "��":
					lbl.BorderBottom = System.Drawing.Color.Black;
					lbl.BorderLeft = System.Drawing.Color.Transparent;
					lbl.BorderRight = System.Drawing.Color.Black;
					lbl.BorderTop = System.Drawing.Color.Black;
					break;
				case "��":
					lbl.BorderBottom = System.Drawing.Color.Black;
					lbl.BorderLeft = System.Drawing.Color.Black;
					lbl.BorderRight = System.Drawing.Color.Transparent;
					lbl.BorderTop = System.Drawing.Color.Black;
					break;
				case "�պ�":
					lbl.BorderBottom = System.Drawing.Color.Black;
					lbl.BorderLeft = System.Drawing.Color.Black;
					lbl.BorderRight = System.Drawing.Color.Black;
					lbl.BorderTop = System.Drawing.Color.Black;
					break;
				default:
					lbl.BorderBottom = System.Drawing.Color.Black;
					lbl.BorderLeft = System.Drawing.Color.Black;
					lbl.BorderRight = System.Drawing.Color.Black;
					lbl.BorderTop = System.Drawing.Color.Transparent;
					break;
			}
		}
		public static string getlblDirection(zhhLabel zhhlbl)
		{
			string strDirection = "";
			if (zhhlbl.BorderTop == System.Drawing.Color.Transparent)
			{
				strDirection = "��";
			}
			if (zhhlbl.BorderBottom == System.Drawing.Color.Transparent)
			{
				strDirection = "��";
			}
			if (zhhlbl.BorderLeft == System.Drawing.Color.Transparent)
			{
				strDirection = "��";
			}
			if (zhhlbl.BorderRight == System.Drawing.Color.Transparent)
			{
				strDirection = "��";
			}
			if (zhhlbl.BorderTop == System.Drawing.Color.Black
				&& zhhlbl.BorderBottom == System.Drawing.Color.Black
				&& zhhlbl.BorderLeft == System.Drawing.Color.Black
				&& zhhlbl.BorderRight == System.Drawing.Color.Black)
			{
				strDirection = "�պ�";
			}
			return strDirection;
		}
		public static bool IsNumber(string str)
		{
			foreach (char c in str.ToCharArray())
			{
				if (!char.IsNumber(c))
				{
					return false;
				}
			}
			return true;
		}
		public static void SetDefaultFloor(UltraComboEditor cmbFloor)
		{
			cmbFloor.Items.Add("A","��Ƹ��һ��");
			cmbFloor.Items.Add("B","��Ƹ�����");
		}
		public static void SetDefaultFloor(Panel pl,string strFloor)
		{
			if (strFloor == "A")
			{
				pl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				pl.Location = new System.Drawing.Point(48, 16);
				pl.Name = "panel��Ƹ��һ��";
				pl.Size = new System.Drawing.Size(632, 568);
			}
			if (strFloor == "B")
			{
				pl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				pl.Location = new System.Drawing.Point(10, 13);
				pl.Name = "panel��Ƹ�����";
				pl.Size = new System.Drawing.Size(709, 423);
			}			
		}

		public static void BindShow(UltraComboEditor cmbFloor,string strJobID)
		{
			cmbFloor.Text = "";
			cmbFloor.Items.Clear();
			DataTable dtShow = Helper.Query("select * from tbShow where cnnJobID="+strJobID);
			cmbFloor.DataSource = dtShow;
			cmbFloor.DisplayMember = "cnvcShowName";
			cmbFloor.ValueMember = "cnnShowID";
			cmbFloor.DataBind();
		}
		/// <summary>
		/// ������ˮ
		/// </summary>
		/// <returns></returns>
		/// 
		#region
        public static decimal getSerialNo()
        {

            decimal dSerialNo = 0;

            SeqSerialNo serial = new SeqSerialNo();
            serial.cnvcFill = "0";
            dSerialNo = EntityMapping.Create(serial);
            return dSerialNo;

        }
		#endregion
		/// <summary>
		/// ��Ƹ����ˮ
		/// </summary>
		/// <returns></returns>
		/// 
		#region
        public static int getJobSerialNo()
        {
            int iSerialNo = 0;

            JobSerialNo serial = new JobSerialNo();
            serial.cnvcFill = "0";
            iSerialNo = (int)EntityMapping.Create(serial);

            return iSerialNo;

        }
		#endregion

		/// <summary>
		/// չ����ˮ
		/// </summary>
		/// <returns></returns>
		/// 
		#region
        public static int getShowSerialNo()
        {

            int iSerialNo = 0;

            ShowSerialNo serial = new ShowSerialNo();
            serial.cnvcFill = "0";
            iSerialNo = (int)EntityMapping.Create(serial);
            return iSerialNo;
        }
		#endregion
		public static void SetGridDisplay(InitializeLayoutEventArgs e)
		{
			e.Layout.ScrollBounds = ScrollBounds.ScrollToFill; 
			e.Layout.Override.CellClickAction = CellClickAction.RowSelect;
			e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;//UltraWinGrid.SelectType.Single;
			//e.Layout.Bands[0].Columns["����ʱ��"].CellActivation = Activation.NoEdit;

			e.Layout.Bands[0].Override.SummaryFooterCaptionAppearance.FontData.Bold = DefaultableBoolean.True; 
			e.Layout.Bands[0].Override.SummaryValueAppearance.BackColor = Color.White;
			e.Layout.Bands[0].Override.SummaryValueAppearance.TextHAlign = HAlign.Right;
			e.Layout.Bands[0].Override.SummaryFooterCaptionAppearance.BackColor = Color.White;
			//e.Layout.Bands[0].SummaryFooterCaption = "�ϼƣ���Ա����"; 

		}
        

		
		public static void AddGridSummary(UltraGrid grid,SummaryType st,string strFormat,int icol)
		{
			//��ӻ���
			grid.DisplayLayout.Bands[0].Summaries.Add(
				st, 
				grid.DisplayLayout.Bands[0].Columns[icol]);
			grid.DisplayLayout.Bands[0].Summaries[icol].DisplayFormat = strFormat;

		}
		public static void AddGridSummary(UltraGrid grid,SummaryType st,string strFormat,string strColName)
		{
			//��ӻ���
			SummarySettings summary = grid.DisplayLayout.Bands[0].Summaries.Add(
				st, 
				grid.DisplayLayout.Bands[0].Columns[strColName]);
			summary.DisplayFormat = strFormat;

		}

		public static void PrintDisplay(CancelablePrintEventArgs e,string strTitle)
		{
			e.DefaultLogicalPageLayoutInfo.PageHeader = strTitle;
			e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40;
			
			e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			
			e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = 
				Infragistics.Win.HAlign.Center;
			e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 20;
			
			e.DefaultLogicalPageLayoutInfo.PageFooter = "��<#>ҳ";
			e.DefaultLogicalPageLayoutInfo.PageFooterHeight= 40; 
			e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = HAlign.Center; 
			e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.FontData.Italic = DefaultableBoolean.True; 
			e.DefaultLogicalPageLayoutInfo.PageFooterBorderStyle = UIElementBorderStyle.None; 

		}
		
		public static void Print(System.Windows.Forms.IWin32Window owner,UltraGrid grid,UltraGridPrintDocument doc,UltraPrintPreviewDialog dlg)
		{
			//��ӡ����
			Infragistics.Shared.ResourceCustomizer rc= Infragistics.Win.Printing.Resources.Customizer;//Resources.Customizer;
			rc.SetCustomizedString("PrintPreview_DialogCaption","��ӡԤ��");
			rc.SetCustomizedString("PrintPreview_Tool_Print","��ӡ(&P)");
			rc.SetCustomizedString("PrintPreview_Tool_ClosePreview","�ر�(&C)");
			rc.SetCustomizedString("PrintPreview_Tool_ContextMenuPreviewZoom","��ʾ����");
			rc.SetCustomizedString("PrintPreview_Tool_Current_Page","��ǰҳ");
			rc.SetCustomizedString("PrintPreview_Tool_Exit","�˳�(&X)");
			rc.SetCustomizedString("PrintPreview_Tool_First_Page","��һҳ");
			rc.SetCustomizedString("PrintPreview_Tool_Go_To","����");
			rc.SetCustomizedString("PrintPreview_Tool_Last_Page","���һҳ");
			rc.SetCustomizedString("PrintPreview_Tool_Next_Page","��һҳ");
			rc.SetCustomizedString("PrintPreview_Tool_Previous_Page","ǰһҳ");
			rc.SetCustomizedString("PrintPreview_Tool_Next_View","��һ��ͼ(&N)");
			rc.SetCustomizedString("PrintPreview_Tool_Previous_View","ǰһ��ͼ(&P)");
			rc.SetCustomizedString("PrintPreview_Tool_Hand_Tool","���͹���(&H)");
			rc.SetCustomizedString("PrintPreview_Tool_Page_Setup","ҳ������(&U)");
			rc.SetCustomizedString("PrintPreview_Tool_Snapshot_Tool","���չ���(&S)");
			rc.SetCustomizedString("PrintPreview_Tool_View","��ͼ(&V)");
			rc.SetCustomizedString("PrintPreview_Tool_Whole_Page","����ҳ");
			rc.SetCustomizedString("PrintPreview_Tool_Zoom","����(&Z)");
			rc.SetCustomizedString("PrintPreview_Tool_Zoom_In","�Ŵ�");
  
			rc.SetCustomizedString("PrintPreview_Tool_Zoom_Out","��С");

			rc.SetCustomizedString("PrintPreview_ToolCategory_Context_Menus","�����Ĳ˵�");
			rc.SetCustomizedString("PrintPreview_ToolCategory_File","�ļ�");
			rc.SetCustomizedString("PrintPreview_ToolCategory_Menus","�˵�");
			rc.SetCustomizedString("PrintPreview_ToolCategory_Tools","������");
			rc.SetCustomizedString("PrintPreview_ToolCategory_View","��ͼ");
			rc.SetCustomizedString("PrintPreview_ToolCategory_Zoom_Mode","����ģʽ");

			rc.SetCustomizedString("PrintPreview_ToolTip_ClosePreview","�ر�");
			rc.SetCustomizedString("PrintPreview_ToolTip_Zoom","����");
			rc.SetCustomizedString("StatusBar_Page_X_OF_X","ҳ:{0}/{1}");

			rc.SetCustomizedString("CustomizeImg_ToolBar_MenuBar","�˵�");
			rc.SetCustomizedString("CustomizeImg_ToolBar_Standard","��׼");
			rc.SetCustomizedString("CustomizeImg_ToolBar_View","��ͼ");
			rc.SetCustomizedString("PrintPreview_Tool_File","�ļ�(&F)");
			rc.SetCustomizedString("PrintPreview_Tool_Tools","����(&T)");
			rc.SetCustomizedString("PrintPreview_Tool_Dynamic_Zoom_Tool","��̬���Ź���(&D)");
			rc.SetCustomizedString("PrintPreview_Tool_Zoom_Out_Tool","��С����");
			rc.SetCustomizedString("PrintPreview_Tool_Zoom_In_Tool","�Ŵ󹤾�");
			// rc.SetCustomizedString("PrintPreview_Tool_Page_Layout","�˵�");
			rc.SetCustomizedString("PreviewRowColSelection_Cancel","ȡ��");
			rc.SetCustomizedString("PreviewRowColSelection_SelectedPages","{0} x {1} ҳ");

			rc.SetCustomizedString("PreviewRowColSelection_Cancel","ȡ��");
			rc.SetCustomizedString("PrintPreview_Tool_Page_Width","ҳ��");
			rc.SetCustomizedString("PrintPreview_ZoomListItem_MarginWidth","���ֿ��");
			rc.SetCustomizedString("PrintPreview_ZoomListItem_PageWidth","ҳ��");
			rc.SetCustomizedString("PrintPreview_ZoomListItem_WholePage","����ҳ");
			rc.SetCustomizedString("PrintPreview_Tool_Page_Layout","ҳ�沼��");
			rc.SetCustomizedString("PrintPreview_Tool_Margin_Width","���ֿ��");
			rc.SetCustomizedString("ContextMenuPreviewHand","������ͼ");


			rc.SetCustomizedString("PrintPreview_Tool_Reduce_Page_Thumbnails","��С");
			rc.SetCustomizedString("PrintPreview_Tool_Show_Page_Numbers","��ʾҳ��");
			rc.SetCustomizedString("PrintPreview_Tool_ContextMenuThumbnail","����ͼ");
			rc.SetCustomizedString("PrintPreview_Tool_Enlarge_Page_Thumbnails","�Ŵ�");
			rc.SetCustomizedString("PrintPreview_Tool_Thumbnails","����ͼ");
			rc.SetCustomizedString("PrintPreview_Tool_Continuous","��������");
			//˵��
			rc.SetCustomizedString("StatusBar_DynamicZoom_Instructions","�������϶��������Ų���");
			rc.SetCustomizedString("StatusBar_Page_X_OF_X","��ǰҳ: {0} / {1}");
			rc.SetCustomizedString("StatusBar_SnapShot_Instructions","�������϶�,ϵͳ��ѡ�����������Ƶ�������");
			rc.SetCustomizedString("StatusBar_ZoomIn_Instructions","�������϶�,ϵͳ���Ŵ�ѡ����������");
			rc.SetCustomizedString("StatusBar_ZoomOut_Instructions","�������϶�,ϵͳ����Сѡ����������");
			rc.SetCustomizedString("StatusBar_Hand_Instructions","�������϶��Ա���ʾ��������");

			grid.BeginUpdate();			
			grid.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
			grid.UseAppStyling = false;			
			grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;;
			grid.EndUpdate();


			doc.Grid = grid;
			dlg.Document = doc;
			dlg.ShowDialog(owner);


			grid.BeginUpdate();
			//this.ultraGrid1.DisplayLayout.Bands[0].Columns[0].Hidden = false;
			grid.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;
			grid.UseAppStyling = true;
			grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
			grid.EndUpdate();
		}

		public static void AddTodayButton(UltraCalendarCombo calendar)
		{
			DateButton db = new DateButton();
			db.Action = DateButtonAction.SelectDay;
			db.Caption = "����";
			db.Type = DateButtonType.Today;
			calendar.DateButtons.Add(db);
		}

		public static void MemberCardNoValidated(UltraTextEditor txtMemberCardNo,ErrorProvider errorProvide,string strType)
		{
			if (txtMemberCardNo.Text.Trim().Length < 8 )
			{
				errorProvide.SetError(txtMemberCardNo,"��Ա���ű�����8λ��");
			}
			else
			{
				string strMemberCardNo = txtMemberCardNo.Text.Trim();
				if (strMemberCardNo.Equals("00000000"))
				{
					errorProvide.SetError(txtMemberCardNo,"��Ա���Ų��ܶ�Ϊ��");
				}
				else
				{
					//�жϿ����Ƿ����
					if (strType == "new")
					{
					
						DataTable dtMember = Query("select * from tbMember where cnvcMemberCardNo = '"+strMemberCardNo+"'");

						Member member = new Member();
						member.cnvcMemberCardNo = strMemberCardNo;
                        MemberManageFacade memberManage = new MemberManageFacade();
						Member oldMember = memberManage.GetMemberbyCardNo(member);
						if (dtMember.Rows.Count > 0)
						{
							errorProvide.SetError(txtMemberCardNo,"��Ա�����Ѵ���");
						}
						else
						{
							errorProvide.SetError(txtMemberCardNo,"");
						}
					}
					else
					{
						errorProvide.SetError(txtMemberCardNo,"");
					}
					
				}		
			}
		}
		public static void SetTextBox(UltraTextEditor textBox,string strType)
		{
			switch (strType)
			{
				case "MemberCardNo":
					textBox.MaxLength = 8;
					textBox.KeyPress +=new System.Windows.Forms.KeyPressEventHandler(textBox_KeyPress);
					break;
				case "Discount":
					textBox.MaxLength = 2;					
					textBox.KeyPress +=new System.Windows.Forms.KeyPressEventHandler(textBox_KeyPress);
					break;
				case "Prepay":
					textBox.KeyPress +=new System.Windows.Forms.KeyPressEventHandler(textBox_KeyPress);
					break;
//				case "":
//					break;
//				case "":
//					break;
//				case "":
//					break;
//				case "":
//					break;
//				case "":
//					break;
				default:
					break;
			}
		}

		private static void textBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==8)
			{
				return;
			}
			if(e.KeyChar<48||e.KeyChar>57)
			{
				e.Handled=true;
			}
		}
        
	}
}
