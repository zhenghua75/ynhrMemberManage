
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	SecurityManage.cs
* 作者:	     郑华
* 创建日期:    2008-01-04
* 功能描述:    报表查询

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
		/// 查询
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
				+" (select * from tbNameCode where cnvcType = '服务产品')a "
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
				MessageBox.Show("服务产品参数不全","服务产品参数");
			}
			return dtProductSort;
		}
		public static void BindProduct(UltraGrid gridProduct)
		{
			DataTable dtProduct = Query("select a.cnvcValue as cnvcProductName,b.cnvcMemberType,b.cnvcMemberValue from "
				                +" (select * from tbNameCode where cnvcType = '服务产品')a "
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
				MessageBox.Show("服务产品参数不全","服务产品参数");
			}

		}
		public static void BindMemberProduct(UltraGrid gridProduct,string strMemberRight)
		{
			DataTable dtProduct = Query("select 'true' as cnvcIsSelected,* from tbMemberCode  where "
				                + " cnvcMemberName in "
								+ " (select cnvcValue from tbNameCode where cnvcType = '会员资格') "
						        + " and cnvcMemberType in "
                                + " (select cnvcValue from tbNameCode where cnvcType = '服务产品') "
                                + " and cnvcMemberName = '"+strMemberRight+"' ");
			gridProduct.SetDataBinding(dtProduct,null,true,true);
		}
		public static void BindSynch(UltraComboEditor cmbSynch)
		{
			cmbSynch.Items.Add("0","会员系统");
			cmbSynch.Items.Add("1","网站操作");
			cmbSynch.Items.Add("2","触摸屏操作");
            cmbSynch.Items.Add("3", "客服预定");
		}
		
		/// <summary>
		/// 绑定会员参数类型
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
			alMember.Add("会员");
			alMember.Add("非会员");
			cmbMember.SetDataBinding(alMember,null);

		}
        public static void BindCost(UltraComboEditor cmbMember)
        {
            ArrayList alMember = new ArrayList();
            alMember.Add("工本费");
            //alMember.Add("非会员");
            cmbMember.SetDataBinding(alMember, null);

        }
		public static void AddDirection(UltraComboEditor cmbDirection)
		{
			cmbDirection.Items.Add("上","上");
			cmbDirection.Items.Add("下","下");
			cmbDirection.Items.Add("左","左");
			cmbDirection.Items.Add("右","右");
			cmbDirection.Items.Add("闭合","闭合");
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
			cmbInfoWay.Items.Add("自带","自带");
			cmbInfoWay.Items.Add("上一次","上一次");
			cmbInfoWay.Items.Add("待传","待传");
			cmbInfoWay.Items.Add("传真","传真");
			cmbInfoWay.Items.Add("申请表","申请表");
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
			//String drawString = "云南人才市场";
			Font drawFontTitle = new Font("Arial", 14);
			Font drawFontBody = new Font("Arial", 8);
			
			//Font aa = new Font()
			SolidBrush drawBrush = new SolidBrush(Color.Black);			

			StringFormat drawFormat = new StringFormat();
			drawFormat.FormatFlags = StringFormatFlags.DisplayFormatControl;

			Pen p = new Pen(drawBrush,1.0f);
			p.DashStyle = DashStyle.Dash;

			e.Graphics.DrawString("云南人才市场", drawFontTitle, drawBrush, 50.0f, 40.0f, drawFormat);
			e.Graphics.DrawLine(p,0.0f,68.0f,300.0f,68.0f);
			e.Graphics.DrawString("会员卡号：", drawFontBody, drawBrush, 35.0f, 70.0F, drawFormat);
			e.Graphics.DrawString(pMember.cnvcMemberCardNo, drawFontBody, drawBrush, 115.0f, 70.0F, drawFormat);
			e.Graphics.DrawString("单位名称：", drawFontBody, drawBrush, 35.0f, 85.0F, drawFormat);
			e.Graphics.DrawString(pMember.cnvcMemberName, drawFontBody, drawBrush, 115.0f, 85.0F, drawFormat);
			e.Graphics.DrawString("工商注册号：", drawFontBody, drawBrush, 35.0f, 100.0F, drawFormat);
			e.Graphics.DrawString(pMember.cnvcPaperNo, drawFontBody, drawBrush, 115.0f, 100.0F, drawFormat);
			e.Graphics.DrawString("展位：", drawFontBody, drawBrush, 35.0f, 115.0F, drawFormat);
			e.Graphics.DrawString(pMember.cnvcProduct, drawFontBody, drawBrush, 115.0f, 115.0F, drawFormat);
			e.Graphics.DrawString("免费场次剩余", drawFontBody, drawBrush, 35.0f, 130.0F, drawFormat);
			e.Graphics.DrawString(pMember.cnvcFree, drawFontBody, drawBrush, 115.0f, 130.0F, drawFormat);

			e.Graphics.DrawLine(p,0.0f,145.0f,300.0f,145.0f);
			
			e.Graphics.DrawString("操作员：", drawFontBody, drawBrush, 35.0f, 145.0F, drawFormat);			
			e.Graphics.DrawString(pMember.cnvcOperName, drawFontBody, drawBrush, 115.0f, 145.0F, drawFormat);
			
			
			e.Graphics.DrawString("签到时间："+DateTime.Now.ToShortDateString()+"  "+DateTime.Now.ToShortTimeString(), drawFontBody, drawBrush, 35.0f, 160.0F, drawFormat);
		}
		public static void SetlblDirection(zhhLabel lbl,string strDirection)
		{
			//switch (cmbDirection.Text)
			switch (strDirection)
			{
				case "上":
					lbl.BorderBottom = System.Drawing.Color.Black;
					lbl.BorderLeft = System.Drawing.Color.Black;
					lbl.BorderRight = System.Drawing.Color.Black;
					lbl.BorderTop = System.Drawing.Color.Transparent;
					break;
				case "下":
					lbl.BorderBottom = System.Drawing.Color.Transparent;
					lbl.BorderLeft = System.Drawing.Color.Black;
					lbl.BorderRight = System.Drawing.Color.Black;
					lbl.BorderTop = System.Drawing.Color.Black;
					break;
				case "左":
					lbl.BorderBottom = System.Drawing.Color.Black;
					lbl.BorderLeft = System.Drawing.Color.Transparent;
					lbl.BorderRight = System.Drawing.Color.Black;
					lbl.BorderTop = System.Drawing.Color.Black;
					break;
				case "右":
					lbl.BorderBottom = System.Drawing.Color.Black;
					lbl.BorderLeft = System.Drawing.Color.Black;
					lbl.BorderRight = System.Drawing.Color.Transparent;
					lbl.BorderTop = System.Drawing.Color.Black;
					break;
				case "闭合":
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
				strDirection = "上";
			}
			if (zhhlbl.BorderBottom == System.Drawing.Color.Transparent)
			{
				strDirection = "下";
			}
			if (zhhlbl.BorderLeft == System.Drawing.Color.Transparent)
			{
				strDirection = "左";
			}
			if (zhhlbl.BorderRight == System.Drawing.Color.Transparent)
			{
				strDirection = "右";
			}
			if (zhhlbl.BorderTop == System.Drawing.Color.Black
				&& zhhlbl.BorderBottom == System.Drawing.Color.Black
				&& zhhlbl.BorderLeft == System.Drawing.Color.Black
				&& zhhlbl.BorderRight == System.Drawing.Color.Black)
			{
				strDirection = "闭合";
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
			cmbFloor.Items.Add("A","招聘会一厅");
			cmbFloor.Items.Add("B","招聘会二厅");
		}
		public static void SetDefaultFloor(Panel pl,string strFloor)
		{
			if (strFloor == "A")
			{
				pl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				pl.Location = new System.Drawing.Point(48, 16);
				pl.Name = "panel招聘会一厅";
				pl.Size = new System.Drawing.Size(632, 568);
			}
			if (strFloor == "B")
			{
				pl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				pl.Location = new System.Drawing.Point(10, 13);
				pl.Name = "panel招聘会二厅";
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
		/// 操作流水
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
		/// 招聘会流水
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
		/// 展厅流水
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
			//e.Layout.Bands[0].Columns["操作时间"].CellActivation = Activation.NoEdit;

			e.Layout.Bands[0].Override.SummaryFooterCaptionAppearance.FontData.Bold = DefaultableBoolean.True; 
			e.Layout.Bands[0].Override.SummaryValueAppearance.BackColor = Color.White;
			e.Layout.Bands[0].Override.SummaryValueAppearance.TextHAlign = HAlign.Right;
			e.Layout.Bands[0].Override.SummaryFooterCaptionAppearance.BackColor = Color.White;
			//e.Layout.Bands[0].SummaryFooterCaption = "合计：会员数量"; 

		}
        

		
		public static void AddGridSummary(UltraGrid grid,SummaryType st,string strFormat,int icol)
		{
			//添加汇总
			grid.DisplayLayout.Bands[0].Summaries.Add(
				st, 
				grid.DisplayLayout.Bands[0].Columns[icol]);
			grid.DisplayLayout.Bands[0].Summaries[icol].DisplayFormat = strFormat;

		}
		public static void AddGridSummary(UltraGrid grid,SummaryType st,string strFormat,string strColName)
		{
			//添加汇总
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
			
			e.DefaultLogicalPageLayoutInfo.PageFooter = "第<#>页";
			e.DefaultLogicalPageLayoutInfo.PageFooterHeight= 40; 
			e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = HAlign.Center; 
			e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.FontData.Italic = DefaultableBoolean.True; 
			e.DefaultLogicalPageLayoutInfo.PageFooterBorderStyle = UIElementBorderStyle.None; 

		}
		
		public static void Print(System.Windows.Forms.IWin32Window owner,UltraGrid grid,UltraGridPrintDocument doc,UltraPrintPreviewDialog dlg)
		{
			//打印汉化
			Infragistics.Shared.ResourceCustomizer rc= Infragistics.Win.Printing.Resources.Customizer;//Resources.Customizer;
			rc.SetCustomizedString("PrintPreview_DialogCaption","打印预览");
			rc.SetCustomizedString("PrintPreview_Tool_Print","打印(&P)");
			rc.SetCustomizedString("PrintPreview_Tool_ClosePreview","关闭(&C)");
			rc.SetCustomizedString("PrintPreview_Tool_ContextMenuPreviewZoom","显示比例");
			rc.SetCustomizedString("PrintPreview_Tool_Current_Page","当前页");
			rc.SetCustomizedString("PrintPreview_Tool_Exit","退出(&X)");
			rc.SetCustomizedString("PrintPreview_Tool_First_Page","第一页");
			rc.SetCustomizedString("PrintPreview_Tool_Go_To","跳至");
			rc.SetCustomizedString("PrintPreview_Tool_Last_Page","最后一页");
			rc.SetCustomizedString("PrintPreview_Tool_Next_Page","下一页");
			rc.SetCustomizedString("PrintPreview_Tool_Previous_Page","前一页");
			rc.SetCustomizedString("PrintPreview_Tool_Next_View","下一视图(&N)");
			rc.SetCustomizedString("PrintPreview_Tool_Previous_View","前一视图(&P)");
			rc.SetCustomizedString("PrintPreview_Tool_Hand_Tool","手型工具(&H)");
			rc.SetCustomizedString("PrintPreview_Tool_Page_Setup","页面设置(&U)");
			rc.SetCustomizedString("PrintPreview_Tool_Snapshot_Tool","快照工具(&S)");
			rc.SetCustomizedString("PrintPreview_Tool_View","视图(&V)");
			rc.SetCustomizedString("PrintPreview_Tool_Whole_Page","合适页");
			rc.SetCustomizedString("PrintPreview_Tool_Zoom","缩放(&Z)");
			rc.SetCustomizedString("PrintPreview_Tool_Zoom_In","放大");
  
			rc.SetCustomizedString("PrintPreview_Tool_Zoom_Out","缩小");

			rc.SetCustomizedString("PrintPreview_ToolCategory_Context_Menus","上下文菜单");
			rc.SetCustomizedString("PrintPreview_ToolCategory_File","文件");
			rc.SetCustomizedString("PrintPreview_ToolCategory_Menus","菜单");
			rc.SetCustomizedString("PrintPreview_ToolCategory_Tools","工具栏");
			rc.SetCustomizedString("PrintPreview_ToolCategory_View","视图");
			rc.SetCustomizedString("PrintPreview_ToolCategory_Zoom_Mode","缩放模式");

			rc.SetCustomizedString("PrintPreview_ToolTip_ClosePreview","关闭");
			rc.SetCustomizedString("PrintPreview_ToolTip_Zoom","缩放");
			rc.SetCustomizedString("StatusBar_Page_X_OF_X","页:{0}/{1}");

			rc.SetCustomizedString("CustomizeImg_ToolBar_MenuBar","菜单");
			rc.SetCustomizedString("CustomizeImg_ToolBar_Standard","标准");
			rc.SetCustomizedString("CustomizeImg_ToolBar_View","视图");
			rc.SetCustomizedString("PrintPreview_Tool_File","文件(&F)");
			rc.SetCustomizedString("PrintPreview_Tool_Tools","工具(&T)");
			rc.SetCustomizedString("PrintPreview_Tool_Dynamic_Zoom_Tool","动态缩放工具(&D)");
			rc.SetCustomizedString("PrintPreview_Tool_Zoom_Out_Tool","缩小工具");
			rc.SetCustomizedString("PrintPreview_Tool_Zoom_In_Tool","放大工具");
			// rc.SetCustomizedString("PrintPreview_Tool_Page_Layout","菜单");
			rc.SetCustomizedString("PreviewRowColSelection_Cancel","取消");
			rc.SetCustomizedString("PreviewRowColSelection_SelectedPages","{0} x {1} 页");

			rc.SetCustomizedString("PreviewRowColSelection_Cancel","取消");
			rc.SetCustomizedString("PrintPreview_Tool_Page_Width","页宽");
			rc.SetCustomizedString("PrintPreview_ZoomListItem_MarginWidth","文字宽度");
			rc.SetCustomizedString("PrintPreview_ZoomListItem_PageWidth","页宽");
			rc.SetCustomizedString("PrintPreview_ZoomListItem_WholePage","合适页");
			rc.SetCustomizedString("PrintPreview_Tool_Page_Layout","页面布局");
			rc.SetCustomizedString("PrintPreview_Tool_Margin_Width","文字宽度");
			rc.SetCustomizedString("ContextMenuPreviewHand","缩放视图");


			rc.SetCustomizedString("PrintPreview_Tool_Reduce_Page_Thumbnails","缩小");
			rc.SetCustomizedString("PrintPreview_Tool_Show_Page_Numbers","显示页号");
			rc.SetCustomizedString("PrintPreview_Tool_ContextMenuThumbnail","缩略图");
			rc.SetCustomizedString("PrintPreview_Tool_Enlarge_Page_Thumbnails","放大");
			rc.SetCustomizedString("PrintPreview_Tool_Thumbnails","缩略图");
			rc.SetCustomizedString("PrintPreview_Tool_Continuous","连续排序");
			//说明
			rc.SetCustomizedString("StatusBar_DynamicZoom_Instructions","单击并拖动进行缩放操作");
			rc.SetCustomizedString("StatusBar_Page_X_OF_X","当前页: {0} / {1}");
			rc.SetCustomizedString("StatusBar_SnapShot_Instructions","单击并拖动,系统将选定矩型区域复制到剪帖板");
			rc.SetCustomizedString("StatusBar_ZoomIn_Instructions","单击并拖动,系统将放大选定矩型区域");
			rc.SetCustomizedString("StatusBar_ZoomOut_Instructions","单击并拖动,系统将缩小选定矩型区域");
			rc.SetCustomizedString("StatusBar_Hand_Instructions","单击并拖动以便显示更多内容");

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
			db.Caption = "今天";
			db.Type = DateButtonType.Today;
			calendar.DateButtons.Add(db);
		}

		public static void MemberCardNoValidated(UltraTextEditor txtMemberCardNo,ErrorProvider errorProvide,string strType)
		{
			if (txtMemberCardNo.Text.Trim().Length < 8 )
			{
				errorProvide.SetError(txtMemberCardNo,"会员卡号必须是8位！");
			}
			else
			{
				string strMemberCardNo = txtMemberCardNo.Text.Trim();
				if (strMemberCardNo.Equals("00000000"))
				{
					errorProvide.SetError(txtMemberCardNo,"会员卡号不能都为零");
				}
				else
				{
					//判断卡号是否存在
					if (strType == "new")
					{
					
						DataTable dtMember = Query("select * from tbMember where cnvcMemberCardNo = '"+strMemberCardNo+"'");

						Member member = new Member();
						member.cnvcMemberCardNo = strMemberCardNo;
                        MemberManageFacade memberManage = new MemberManageFacade();
						Member oldMember = memberManage.GetMemberbyCardNo(member);
						if (dtMember.Rows.Count > 0)
						{
							errorProvide.SetError(txtMemberCardNo,"会员卡号已存在");
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
