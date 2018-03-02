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
using MemberManage.Business;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Common;
namespace MemberManage.Reports
{
	/// <summary>
	/// Summary description for ProductReport.
	/// </summary>
    public class AllMoneyReport : frmBase
	{
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraButton btnExcel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEndDate;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbOperName;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.Misc.UltraButton btnQuery;
		private Infragistics.Win.Printing.UltraPrintPreviewDialog ultraPrintPreviewDialog1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.UltraWinGrid.UltraGridPrintDocument ultraGridPrintDocument1;
		private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
		private System.ComponentModel.IContainer components;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbMember;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbMemberRight;
		public static bool IsShowing ;
		public AllMoneyReport()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
			IsShowing = false;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbMemberRight = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbMember = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnExcel = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.chkEndDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkBeginDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cmbEndDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.cmbBeginDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.cmbOperName = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.btnQuery = new Infragistics.Win.Misc.UltraButton();
            this.ultraPrintPreviewDialog1 = new Infragistics.Win.Printing.UltraPrintPreviewDialog(this.components);
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGridPrintDocument1 = new Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(this.components);
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMemberRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOperName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox2.Controls.Add(this.cmbMemberRight);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox2.Controls.Add(this.cmbMember);
            this.ultraGroupBox2.Controls.Add(this.btnExcel);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox2.Controls.Add(this.chkEndDate);
            this.ultraGroupBox2.Controls.Add(this.chkBeginDate);
            this.ultraGroupBox2.Controls.Add(this.cmbEndDate);
            this.ultraGroupBox2.Controls.Add(this.cmbBeginDate);
            this.ultraGroupBox2.Controls.Add(this.cmbOperName);
            this.ultraGroupBox2.Controls.Add(this.ultraButton1);
            this.ultraGroupBox2.Controls.Add(this.btnQuery);
            this.ultraGroupBox2.Location = new System.Drawing.Point(128, 32);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(748, 152);
            this.ultraGroupBox2.TabIndex = 8;
            this.ultraGroupBox2.Text = "查找";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(56, 104);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(96, 23);
            this.ultraLabel1.TabIndex = 45;
            this.ultraLabel1.Text = "会员资格：";
            // 
            // cmbMemberRight
            // 
            this.cmbMemberRight.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbMemberRight.Location = new System.Drawing.Point(160, 104);
            this.cmbMemberRight.Name = "cmbMemberRight";
            this.cmbMemberRight.Size = new System.Drawing.Size(144, 21);
            this.cmbMemberRight.TabIndex = 44;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(56, 72);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(96, 23);
            this.ultraLabel4.TabIndex = 43;
            this.ultraLabel4.Text = "是否会员：";
            // 
            // cmbMember
            // 
            this.cmbMember.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbMember.Location = new System.Drawing.Point(160, 72);
            this.cmbMember.Name = "cmbMember";
            this.cmbMember.Size = new System.Drawing.Size(144, 21);
            this.cmbMember.TabIndex = 42;
            // 
            // btnExcel
            // 
            this.btnExcel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnExcel.Location = new System.Drawing.Point(624, 96);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 37;
            this.btnExcel.Text = "导出EXCEL";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(56, 32);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel5.TabIndex = 36;
            this.ultraLabel5.Text = "操作员：";
            // 
            // chkEndDate
            // 
            this.chkEndDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkEndDate.Location = new System.Drawing.Point(320, 88);
            this.chkEndDate.Name = "chkEndDate";
            this.chkEndDate.Size = new System.Drawing.Size(96, 20);
            this.chkEndDate.TabIndex = 31;
            this.chkEndDate.Text = "操作结束时间";
            // 
            // chkBeginDate
            // 
            this.chkBeginDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkBeginDate.Location = new System.Drawing.Point(320, 48);
            this.chkBeginDate.Name = "chkBeginDate";
            this.chkBeginDate.Size = new System.Drawing.Size(96, 20);
            this.chkBeginDate.TabIndex = 30;
            this.chkBeginDate.Text = "操作开始时间";
            // 
            // cmbEndDate
            // 
            this.cmbEndDate.DateTime = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
            this.cmbEndDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbEndDate.Location = new System.Drawing.Point(424, 88);
            this.cmbEndDate.MaskInput = "{date} {time}";
            this.cmbEndDate.Name = "cmbEndDate";
            this.cmbEndDate.Size = new System.Drawing.Size(144, 21);
            this.cmbEndDate.TabIndex = 29;
            this.cmbEndDate.Value = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
            // 
            // cmbBeginDate
            // 
            this.cmbBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbBeginDate.Location = new System.Drawing.Point(424, 48);
            this.cmbBeginDate.MaskInput = "{date} {time}";
            this.cmbBeginDate.Name = "cmbBeginDate";
            this.cmbBeginDate.Size = new System.Drawing.Size(144, 21);
            this.cmbBeginDate.TabIndex = 28;
            // 
            // cmbOperName
            // 
            this.cmbOperName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbOperName.Location = new System.Drawing.Point(160, 32);
            this.cmbOperName.Name = "cmbOperName";
            this.cmbOperName.Size = new System.Drawing.Size(144, 21);
            this.cmbOperName.TabIndex = 27;
            // 
            // ultraButton1
            // 
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton1.Location = new System.Drawing.Point(624, 64);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 19;
            this.ultraButton1.Text = "打印";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnQuery.Location = new System.Drawing.Point(624, 32);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 18;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // ultraPrintPreviewDialog1
            // 
            this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.ultraGrid1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(48, 205);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(840, 379);
            this.ultraGroupBox1.TabIndex = 9;
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ultraGrid1.Location = new System.Drawing.Point(152, 56);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(192, 80);
            this.ultraGrid1.TabIndex = 4;
            this.ultraGrid1.Text = "查询结果";
            this.ultraGrid1.InitializePrint += new Infragistics.Win.UltraWinGrid.InitializePrintEventHandler(this.ultraGrid1_InitializePrint);
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            // 
            // AllMoneyReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(944, 597);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "AllMoneyReport";
            this.Text = Login.constApp.strCardTypeL8Name + "收入报表";
            this.Load += new System.EventHandler(this.ProductReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMemberRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOperName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void ProductReport_Load(object sender, System.EventArgs e)
		{
			this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti; 
			cmbBeginDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEndDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbBeginDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 00:00";
			cmbEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 23:59";
			DataTable dtOper = Helper.Query("select * from tbOper where cnvcOperName <> 'admin'");			

			cmbOperName.DataSource = dtOper;
			cmbOperName.DisplayMember = "cnvcOperName";
			cmbOperName.ValueMember = "cnnOperID";

			//绑定会员状态
//			DataTable dtState = new DataTable();
//			//dtState.Columns.Add("cnvcState");
//			dtState.Columns.Add("会员状态");
//
//			DataRow drState0 = dtState.NewRow();
//			//drState0["cnvcState"] = "0";
//			drState0["会员状态"] = ConstApp.Card_State_InUse;
//
//			dtState.Rows.Add(drState0);
//
//			DataRow drState1 = dtState.NewRow();
//			//drState1["cnvcState"] = "1";
//			drState1["会员状态"] = ConstApp.Card_State_InLose;
//
//			dtState.Rows.Add(drState1);
//
//			DataRow drState2 = dtState.NewRow();
//			//drState2["cnvcState"] = "2";
//			drState2["会员状态"] = ConstApp.Card_State_InAdd;
//
//			dtState.Rows.Add(drState2);
//
//			DataRow drState3 = dtState.NewRow();
//			//drState2["cnvcState"] = "2";
//			drState3["会员状态"] = ConstApp.Card_State_InCallBack;
//
//			dtState.Rows.Add(drState3);

			
			//cmbState.DataSource = dtState;
			//cmbState.DisplayMember = "会员状态";
			//cmbState.ValueMember = "cnvcState";
			//cmbState.DataBind();	
			//cmbState.SelectedIndex = 0;

			//Helper.BindJob(cmbShow);

			Helper.BindMember(cmbMember);
            ClientHelper.BindMemberRight(cmbMemberRight);

			this.ultraGrid1.Dock       = DockStyle.Fill;
			this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
			this.ultraGroupBox1.BringToFront();

			//Helper.BindProduct(cmbProduct);
            //if (ClientHelper.idept.cnnDeptID != 0)
            //{
            //    if(!Login.constApp.alOperFunc.Contains("收入报表查询"))
            //    {
            //        this.btnQuery.Enabled = false;
            //    }
            //    if(!Login.constApp.alOperFunc.Contains("收入报表打印"))
            //    {
            //        this.ultraButton1.Enabled = false;
            //        btnExcel.Enabled = false;
            //    }
            //}
		}

		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			Helper.Print(this,ultraGrid1,ultraGridPrintDocument1,ultraPrintPreviewDialog1);
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
            ClientHelper.ExportExcel(saveFileDialog1, ultraGridExcelExporter1, ultraGrid1, "云南人才市场服务产品消费报表", this.oper.cnvcOperName);
		}

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e); 

			e.Layout.Bands[0].Columns["cnvcMoneyType"].Header.Caption = "收入项目";			
			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "会员卡号";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "实收";
			e.Layout.Bands[0].Columns["cnvcOperName"].Header.Caption = "操作员名称";
			e.Layout.Bands[0].Columns["cndOperDate"].Header.Caption = "操作时间";
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Header.Caption = "会员资格";

			e.Layout.Bands[0].Columns["cndOperDate"].CellActivation = Activation.NoEdit;
			e.Layout.Bands[0].Columns["cndOperDate"].Format = "yyyy-MM-dd hh:mm";

			e.Layout.Bands[0].SummaryFooterCaption = "合计："; 

			//e.Layout.Bands[0].Columns["cnnSerialNo"].Hidden = true;
		}

		private void ultraGrid1_InitializePrint(object sender, Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs e)
		{
			Helper.PrintDisplay(e,"云南人才市场收入报表");	
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			try
			{				
				//发卡
//				string strSql_Renew = "select '发卡' as cnvcMoneyType,cnvcMemberCardNo,cnvcMemberName,cnvcPaperNo,cnvcMemberRight,cnnPrepay,cnvcOperName,cndInNetDate as cndOperDate from tbMember ";
//				strSql_Renew += " where (cnvcState='"+ConstApp.Card_State_InUse+"' or cnvcState='"+ConstApp.Card_State_InLose+"')";
				//会员充值
				string strSql_InMoney = "select cnvcOperFlag as cnvcMoneyType,a.cnvcMemberCardNo,b.cnvcMemberName,b.cnvcPaperNo,b.cnvcMemberRight,a.cnnPrepay,a.cnvcOperName,a.cndOperDate from tbMemberPrepayLog a join tbMember b on a.cnvcMemberCardNo=b.cnvcMemberCardNo ";
				//strSql_InMoney += " where b.cnvcState<>'"+ConstApp.Card_State_InAdd+"' ";

				//工本费
				string strSql_Cost = "select '工本费' as cnvcMoneyType,a.cnvcMemberCardNo,b.cnvcMemberName,b.cnvcPaperNo,b.cnvcMemberRight,a.cnnCost as cnnPrepay,a.cnvcOperName,a.cndOperDate  from tbCostLog a join tbMember b on a.cnvcMemberCardNo=b.cnvcMemberCardNo";
				strSql_Cost += " where 1=1 ";

				string strSql_MemberProduct = "select a.cnvcProductName as cnvcMoneyType,a.cnvcMemberCardNo,b.cnvcMemberName,b.cnvcPaperNo,b.cnvcMemberRight,a.cnnPrepay,a.cnvcOperName,a.cndOperDate  from tbMemberProductLog a join tbMember b on a.cnvcMemberCardNo=b.cnvcMemberCardNo ";
				strSql_MemberProduct += " where 1=1 ";

				string strSql_FMemberProduct = "select a.cnvcProductName as cnvcMoneyType,'' as cnvcMemberCardNo,b.cnvcMemberName,b.cnvcPaperNo,'' as cnvcMemberRight,a.cnnPrepay,a.cnvcOperName,a.cndOperDate  from tbMemberProductLog a join tbFMember b on a.cnvcPaperNo=b.cnvcPaperNo ";
				strSql_FMemberProduct += " where 1=1 ";

				string strSql_Prepay = "select '缴费' as cnvcMoneyType,'' as cnvcMemberCardNo,c.cnvcMemberName,c.cnvcPaperNo,'' as cnvcMemberRight,"
//					                + " case "
//						            + " when a.cnvcMemberCardNo is not null then b.cnvcMemberCardNo"
//						            + " when a.cnvcMemberCardNo is null then '' "
//                                    + " end cnvcMemberCardNo "
//                                    + " , "
//									+ " case  "
//									+ " when a.cnvcMemberCardNo is not null then b.cnvcMemberName "
//									+ " when a.cnvcMemberCardNo is null then c.cnvcMemberName "
//									+ " end cnvcMemberName, "
//                                    + " case  "
//                                    + " when a.cnvcMemberCardNo is not null then b.cnvcPaperNo "
//                                    + " when a.cnvcMemberCardNo is null then c.cnvcPaperNo "
//                                    + " end cnvcPaperNo, "     
//					+ " case  "
//					+ " when a.cnvcMemberCardNo is not null then b.cnvcMemberRight "
//					+ " when a.cnvcMemberCardNo is null then '' "
//					+ " end cnvcMemberRight, "            
                                    + " a.cnnBalance as cnnPrepay,a.cnvcOperName,a.cndOperDate "
                                    + " from tbPrepay a "
                                    //+ " left join tbMember b on a.cnvcMemberCardNo=b.cnvcMemberCardNo and a.cnvcMemberCardNo is not null "
                                    + " left join tbFMember c on a.cnvcPaperNo=c.cnvcPaperNo and a.cnvcMemberCardNo is null ";
				strSql_Prepay += " where 1=1 ";
				if (cmbOperName.Text.Trim().Length > 0)
				{
					//strSql_Renew += " and cnvcOperName like '%"+cmbOperName.Text+"%'";
					strSql_InMoney += " and a.cnvcOperName like '%"+cmbOperName.Text+"%'";
					strSql_Cost += " and a.cnvcOperName like '%"+cmbOperName.Text+"%'";
					strSql_MemberProduct += " and a.cnvcOperName like '%"+cmbOperName.Text+"%'";
					strSql_FMemberProduct += " and a.cnvcOperName like '%"+cmbOperName.Text+"%'";
					strSql_Prepay += " and a.cnvcOperName like '%"+cmbOperName.Text+"%'";
				}
				if (chkBeginDate.Checked)
				{
					//strSql_Renew += " and cndInNetDate >='"+cmbBeginDate.Value.ToString()+"'";
					strSql_InMoney += " and a.cndOperDate >= '"+cmbBeginDate.Value.ToString()+"'";
					strSql_Cost += " and a.cndOperDate >= '"+cmbBeginDate.Value.ToString()+"'";
					strSql_MemberProduct += " and a.cndOperDate >= '"+cmbBeginDate.Value.ToString()+"'";
					strSql_FMemberProduct += " and a.cndOperDate >= '"+cmbBeginDate.Value.ToString()+"'";
					strSql_Prepay += " and a.cndOperDate >= '"+cmbBeginDate.Value.ToString()+"'";
				}
				if (chkEndDate.Checked)
				{
					//strSql_Renew += " and cndInNetDate <='"+cmbEndDate.Value.ToString()+"'";
					strSql_InMoney += " and a.cndOperDate <= '"+cmbEndDate.Value.ToString()+"'";
					strSql_Cost += " and a.cndOperDate <= '"+cmbEndDate.Value.ToString()+"'";
					strSql_MemberProduct += " and a.cndOperDate <= '"+cmbEndDate.Value.ToString()+"'";
					strSql_FMemberProduct += " and a.cndOperDate <= '"+cmbEndDate.Value.ToString()+"'";
					strSql_Prepay += " and a.cndOperDate <= '"+cmbEndDate.Value.ToString()+"'";
				}
				if (cmbMember.Text == "会员")
				{
					strSql_Prepay += " and a.cnvcMemberCardNo is not null  ";
				}
				if (cmbMember.Text == "非会员")
				{
					strSql_Prepay += " and a.cnvcMemberCardNo is null";
					//strSql_Renew += " and 1<>1";
				}
				if (cmbMemberRight.Text.Trim().Length > 0)
				{
					//strSql_Renew += " and cnvcMemberRight like '%"+cmbMemberRight.Text+"%'";
					strSql_InMoney += " and b.cnvcMemberRight like '%"+cmbMemberRight.Text+"%'";
					strSql_Cost += " and b.cnvcMemberRight like '%"+cmbMemberRight.Text+"%'";
					strSql_MemberProduct += " and b.cnvcMemberRight like '%"+cmbMemberRight.Text+"%'";
					//strSql_FMemberProduct += " and b.cnvcMemberRight like '%"+cmbMemberRight.Text+"%'";
					//strSql_Prepay += " and b.cnvcMemberRight like '%"+cmbMemberRight.Text+"%'";
				}

				DataTable dtPrepay = null;
				if (cmbMember.Text.Trim().Length == 0)
				{
					dtPrepay = Helper.Query(strSql_InMoney);
					DataTable dtCost= Helper.Query(strSql_Cost);
					DataTable dtMemberProduct = Helper.Query(strSql_MemberProduct);
					DataTable dtFMemberProduct = Helper.Query(strSql_FMemberProduct);
					DataTable dtPay = Helper.Query(strSql_Prepay);
					//DataTable dtRenew = Helper.Query(strSql_Renew);
					foreach (DataRow dr in dtCost.Rows)
					{
						dtPrepay.Rows.Add(dr.ItemArray);
					}
					foreach (DataRow dr in dtMemberProduct.Rows)
					{
						dtPrepay.Rows.Add(dr.ItemArray);
					}
					foreach (DataRow dr in dtFMemberProduct.Rows)
					{
						dtPrepay.Rows.Add(dr.ItemArray);
					}
					foreach (DataRow dr in dtPay.Rows)
					{
						dtPrepay.Rows.Add(dr.ItemArray);
					}
//					foreach (DataRow dr in dtRenew.Rows)
//					{
//						dtPrepay.Rows.Add(dr.ItemArray);
//					}
				}
				else if (cmbMember.Text == "会员")
				{
					dtPrepay = Helper.Query(strSql_InMoney);
					DataTable dtCost= Helper.Query(strSql_Cost);
					DataTable dtMemberProduct = Helper.Query(strSql_MemberProduct);
					//DataTable dtFMemberProduct = Helper.Query(strSql_FMemberProduct);
					DataTable dtPay = Helper.Query(strSql_Prepay);
					//DataTable dtRenew = Helper.Query(strSql_Renew);
					foreach (DataRow dr in dtCost.Rows)
					{
						dtPrepay.Rows.Add(dr.ItemArray);
					}
					foreach (DataRow dr in dtMemberProduct.Rows)
					{
						dtPrepay.Rows.Add(dr.ItemArray);
					}
					foreach (DataRow dr in dtPay.Rows)
					{
						dtPrepay.Rows.Add(dr.ItemArray);
					}
//					foreach (DataRow dr in dtRenew.Rows)
//					{
//						dtPrepay.Rows.Add(dr.ItemArray);
//					}

				}
				else if (cmbMember.Text == "非会员")
				{
					//dtPrepay = Helper.Query(strSql_InMoney);
					//DataTable dtCost= Helper.Query(strSql_Cost);
					//DataTable dtMemberProduct = Helper.Query(strSql_MemberProduct);
					dtPrepay = Helper.Query(strSql_FMemberProduct);
					DataTable dtPay = Helper.Query(strSql_Prepay);
//					foreach (DataRow dr in dtCost.Rows)
//					{
//						dtPrepay.Rows.Add(dr.ItemArray);
//					}
//					foreach (DataRow dr in dtMemberProduct.Rows)
//					{
//						dtPrepay.Rows.Add(dr.ItemArray);
//					}
//					foreach (DataRow dr in dtFMemberProduct.Rows)
//					{
//						dtPrepay.Rows.Add(dr.ItemArray);
//					}
					foreach (DataRow dr in dtPay.Rows)
					{
						dtPrepay.Rows.Add(dr.ItemArray);
					}
				}
				this.ultraGrid1.DataSource = null;
				this.ultraGrid1.DataSource = dtPrepay;
				this.ultraGrid1.DataBind();

                ClientHelper.AddGridColumn(this.ultraGrid1, this.oper.cnvcOperName);
				Helper.AddGridSummary(this.ultraGrid1,SummaryType.Count,"收入合计，共{0}条","cnvcMemberRight");		
				Helper.AddGridSummary(this.ultraGrid1,SummaryType.Sum,"{0}","cnnPrepay");		
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
	}
}
