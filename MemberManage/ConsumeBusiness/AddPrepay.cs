using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Infragistics;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ynhrMemberManage.Print;
using ynhrMemberManage.Common;
using ynhrMemberManage.BusinessFacade.MemberBusiness;
namespace MemberManage.Business.ConsumeBusiness
{
	/// <summary>
	/// Summary description for AddPrepay.
	/// </summary>
    public partial class AddPrepay : frmBase
	{
		

		public string strJobID = "";
		public string strMemberCardNo = "";
		public string strMemberName = "";
		public string strPaperNo = "";
		
		public static bool IsShowing ;
		
		//private Member pMember = null;
		public AddPrepay()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		
		

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			//缴费
			try
			{
                //if (null == cmbShow.SelectedItem)
                //{
                //    throw new BusinessException("缴费","请选择招聘会");
                //}
				if (txtPrepay.Text.Trim().Length == 0)
				{
					throw new BusinessException("充值","请输入金额");
				}	
				UltraGridRow row = this.ultraGrid1.ActiveRow;
				if (null == row)
				{
					throw new BusinessException("充值","请选择充值的非会员");
				}
				string strMemberName = row.Cells["cnvcMemberName"].Value.ToString();
                //Prepay prepay = new Prepay();
                ////prepay.cnnJobID = int.Parse(cmbShow.SelectedItem.DataValue.ToString());
                //prepay.cnvcPaperNo = row.Cells["cnvcPaperNo"].Value.ToString();//txtPaperNo.Text;
                //prepay.cnnPrepay = int.Parse(txtPrepay.Text);
                //prepay.cnnBalance = prepay.cnnPrepay;
                //prepay.cnvcOperName = this.oper.cnvcOperName;
                //prepay.cndOperDate = DateTime.Now;
				
				FMember member = new FMember();
				//member.cnvcMemberCardNo = row.Cells["cnvcMemberCardNo"].Value.ToString();
                member.cnvcPaperNo = row.Cells["cnvcPaperNo"].Value.ToString();
                member.cnnPrepay = Convert.ToDecimal(txtPrepay.Text);
				member.cnvcMemberName = txtMemberName.Text;
				member.cnvcOperName = this.oper.cnvcOperName;
				member.cndOperDate = DateTime.Now;
                member.cnvcSales = cmbSales.Text;
				//pMember = member;
				JobManage job = new JobManage();
				job.AddPrepay(member);

				PrintedBill pBill = new PrintedBill(member.ToTable());
				pBill.cnvcBillType = ConstApp.Bill_Type_AddPrepay;
				Helper.PrintTicket(pBill);
				//this.ultraPrintDocument1.Print();
				MessageBox.Show(this,"充值成功！","充值",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtPrepay.Text = "";
				txtMemberName.Text = "";
				txtPaperNo.Text = "";
				btnOK.Enabled = false;
				//cmbShow.Text = "";

			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void AddPrepay_Load(object sender, System.EventArgs e)
		{
			//Helper.BindJob(cmbShow);
			Helper.SetTextBox(txtPrepay,"Prepay");
			btnOK.Enabled = false;
            ClientHelper.BindSales(cmbSales);//, this.oper.cnnOperID.ToString());
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//
			try
			{
				string strSql = "select top 10  cnvcMemberName,cnvcPaperNo,cnvcCompanyAddress,cnvcEnterpriseType from tbFMember where 1=1 ";
				if (txtQMemberName.Text.Trim().Length > 0)
				{
					strSql += " and cnvcMemberName like '%"+txtQMemberName.Text+"%'";
				}
				if (txtQPaperNo.Text.Trim().Length > 0)
				{
					strSql += " and cnvcPaperNo like '%"+txtQPaperNo.Text+"%'";
				}

//				string strSql2 = "select top 10 cnvcMemberCardNo,cnvcMemberName,cnvcPaperNo,cnvcCompanyAddress,cnvcEnterpriseType from tbMember where cndEndDate<getdate() and cnvcState='"+ConstApp.Card_State_InUse+"' ";
//				if (txtQMemberCardNo.Text.Trim().Length > 0)
//				{
//					strSql2 += " and cnvcMemberCardNo like '%"+txtQMemberCardNo.Text+"%'";
//				}
//				if (txtQMemberName.Text.Trim().Length > 0)
//				{
//					strSql2 += " and cnvcMemberName like '%"+txtQMemberName.Text+"%'";
//				}
//				if (txtQPaperNo.Text.Trim().Length > 0)
//				{
//					strSql2 += " and cnvcPaperNo like '%"+txtQPaperNo.Text+"%'";
//				}

				DataTable dtFMember = Helper.Query(strSql);
				//DataTable dtMember = Helper.Query(strSql2);
//				foreach (DataRow drFMember in dtFMember.Rows)
//				{
//					dtMember.Rows.Add(drFMember.ItemArray);
//				}
				this.ultraGrid1.DataSource = null;
				this.ultraGrid1.DataSource = dtFMember;
				this.ultraGrid1.DataBind();
				txtPrepay.Text = "";
				txtMemberName.Text = "";
				txtPaperNo.Text = "";
				btnOK.Enabled = false;
				//cmbShow.Text = "";

			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

		}		

//		private void ultraPrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
//		{
//			//
//			//String drawString = "云南人才市场";
//			Font drawFontTitle = new Font("Arial", 14);
//			Font drawFontBody = new Font("Arial", 8);
//			SolidBrush drawBrush = new SolidBrush(Color.Black);			
//
//			StringFormat drawFormat = new StringFormat();
//			drawFormat.FormatFlags = StringFormatFlags.DisplayFormatControl;
//			e.Graphics.DrawString("云南人才市场", drawFontTitle, drawBrush, 50.0f, 40.0f, drawFormat);
//			e.Graphics.DrawLine(new Pen(drawBrush,1.0f),0.0f,68.0f,300.0f,68.0f);
//			e.Graphics.DrawString("会员卡号：", drawFontBody, drawBrush, 35.0f, 70.0F, drawFormat);
//			e.Graphics.DrawString(pMember.cnvcMemberCardNo, drawFontBody, drawBrush, 115.0f, 70.0F, drawFormat);
//			e.Graphics.DrawString("单位名称：", drawFontBody, drawBrush, 35.0f, 85.0F, drawFormat);
//			e.Graphics.DrawString(pMember.cnvcMemberName, drawFontBody, drawBrush, 115.0f, 85.0F, drawFormat);
//			e.Graphics.DrawString("工商注册号：", drawFontBody, drawBrush, 35.0f, 100.0F, drawFormat);
//			e.Graphics.DrawString(pMember.cnvcPaperNo, drawFontBody, drawBrush, 115.0f, 100.0F, drawFormat);
//			e.Graphics.DrawString("展位费：", drawFontBody, drawBrush, 35.0f, 115.0F, drawFormat);
//			e.Graphics.DrawString(pMember.cnnPrepay.ToString(), drawFontBody, drawBrush, 115.0f, 115.0F, drawFormat);
//			e.Graphics.DrawLine(new Pen(drawBrush,1.0f),0.0f,130.0f,300.0f,130.0f);
//			e.Graphics.DrawString("操作员：", drawFontBody, drawBrush, 35.0f, 130.0F, drawFormat);
//			e.Graphics.DrawString(pMember.cnvcOperName, drawFontBody, drawBrush, 115.0f, 130.0F, drawFormat);
//			e.Graphics.DrawString("操作时间："+DateTime.Now.ToShortDateString(), drawFontBody, drawBrush, 35.0f, 145.0F, drawFormat);
//
//		}

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e);
			//e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "会员卡号";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcCompanyAddress"].Header.Caption = "单位地址";
			e.Layout.Bands[0].Columns["cnvcEnterpriseType"].Header.Caption = "企业性质";

		}

		private void ultraGrid1_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			UltraGridRow row = this.ultraGrid1.ActiveRow;
			if (null != row)
			{
				//txtMemberCardNo.Text = row.Cells["cnvcMemberCardNo"].Value.ToString();
				txtMemberName.Text = row.Cells["cnvcMemberName"].Value.ToString();
				txtPaperNo.Text = row.Cells["cnvcPaperNo"].Value.ToString();
				btnOK.Enabled = true;
			}
		}
	}
}
