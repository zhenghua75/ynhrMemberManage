using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using ynhrMemberManage.Domain;
using ynhrMemberManage.ORM;
using Infragistics;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

using Infragistics.Win.UltraWinEditors;

using MemberManage.Reports;
using ynhrMemberManage.Common;
using ynhrMemberManage.BusinessFacade.MemberBusiness;
using MemberManage.Business;
namespace MemberManage.MemberBusiness
{
	/// <summary>
	/// Summary description for MemberFileQuery.
	/// </summary>
    public class MemberFreeModify : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
		private Infragistics.Win.Misc.UltraButton btnQuery;
		private System.ComponentModel.IContainer components;
		private Infragistics.Win.UltraWinGrid.UltraGridPrintDocument ultraGridPrintDocument1;
		private Infragistics.Win.Printing.UltraPrintPreviewDialog ultraPrintPreviewDialog1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbEnterpriseType;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbTrade;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSales;
		private Infragistics.Win.Misc.UltraLabel ultraLabel8;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCustomerService;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate;
		private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cmbEndDate;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmdBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEndDate2;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbMemberRight;
		private Infragistics.Win.Misc.UltraButton btnModify;
		public static bool IsShowing ;
		public MemberFreeModify()
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
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnModify = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbMemberRight = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbEndDate2 = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.chkEndDate2 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cmdBeginDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.chkBeginDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cmbEndDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.chkEndDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.txtCustomerService = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.txtSales = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbTrade = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbEnterpriseType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.btnQuery = new Infragistics.Win.Misc.UltraButton();
            this.txtPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGridPrintDocument1 = new Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new Infragistics.Win.Printing.UltraPrintPreviewDialog(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMemberRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdBeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnterpriseType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.btnModify);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel9);
            this.ultraGroupBox1.Controls.Add(this.cmbMemberRight);
            this.ultraGroupBox1.Controls.Add(this.cmbEndDate2);
            this.ultraGroupBox1.Controls.Add(this.chkEndDate2);
            this.ultraGroupBox1.Controls.Add(this.cmdBeginDate);
            this.ultraGroupBox1.Controls.Add(this.chkBeginDate);
            this.ultraGroupBox1.Controls.Add(this.cmbEndDate);
            this.ultraGroupBox1.Controls.Add(this.chkEndDate);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel8);
            this.ultraGroupBox1.Controls.Add(this.txtCustomerService);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel7);
            this.ultraGroupBox1.Controls.Add(this.txtSales);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel6);
            this.ultraGroupBox1.Controls.Add(this.cmbTrade);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox1.Controls.Add(this.cmbEnterpriseType);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox1.Controls.Add(this.btnQuery);
            this.ultraGroupBox1.Controls.Add(this.txtPaperNo);
            this.ultraGroupBox1.Controls.Add(this.txtMemberName);
            this.ultraGroupBox1.Controls.Add(this.txtMemberCardNo);
            this.ultraGroupBox1.Location = new System.Drawing.Point(16, 24);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(952, 160);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.Click += new System.EventHandler(this.ultraGroupBox1_Click);
            // 
            // btnModify
            // 
            this.btnModify.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnModify.Location = new System.Drawing.Point(728, 112);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 37;
            this.btnModify.Text = "修改";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.Location = new System.Drawing.Point(80, 112);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel9.TabIndex = 36;
            this.ultraLabel9.Text = "会员资格：";
            // 
            // cmbMemberRight
            // 
            this.cmbMemberRight.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbMemberRight.Location = new System.Drawing.Point(184, 112);
            this.cmbMemberRight.Name = "cmbMemberRight";
            this.cmbMemberRight.Size = new System.Drawing.Size(104, 21);
            this.cmbMemberRight.TabIndex = 35;
            // 
            // cmbEndDate2
            // 
            this.cmbEndDate2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbEndDate2.Location = new System.Drawing.Point(712, 80);
            this.cmbEndDate2.MaskInput = "{date} {time}";
            this.cmbEndDate2.Name = "cmbEndDate2";
            this.cmbEndDate2.Size = new System.Drawing.Size(144, 21);
            this.cmbEndDate2.TabIndex = 32;
            // 
            // chkEndDate2
            // 
            this.chkEndDate2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.chkEndDate2.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkEndDate2.Location = new System.Drawing.Point(592, 80);
            this.chkEndDate2.Name = "chkEndDate2";
            this.chkEndDate2.Size = new System.Drawing.Size(120, 20);
            this.chkEndDate2.TabIndex = 34;
            this.chkEndDate2.Text = "结束时间";
            // 
            // cmdBeginDate
            // 
            this.cmdBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmdBeginDate.Location = new System.Drawing.Point(712, 48);
            this.cmdBeginDate.MaskInput = "{date} {time}";
            this.cmdBeginDate.Name = "cmdBeginDate";
            this.cmdBeginDate.Size = new System.Drawing.Size(144, 21);
            this.cmdBeginDate.TabIndex = 31;
            // 
            // chkBeginDate
            // 
            this.chkBeginDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.chkBeginDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkBeginDate.Location = new System.Drawing.Point(592, 48);
            this.chkBeginDate.Name = "chkBeginDate";
            this.chkBeginDate.Size = new System.Drawing.Size(120, 20);
            this.chkBeginDate.TabIndex = 33;
            this.chkBeginDate.Text = "开始时间";
            // 
            // cmbEndDate
            // 
            this.cmbEndDate.BackColor = System.Drawing.SystemColors.Window;
            this.cmbEndDate.DateButtons.Add(dateButton1);
            this.cmbEndDate.Location = new System.Drawing.Point(712, 16);
            this.cmbEndDate.Name = "cmbEndDate";
            this.cmbEndDate.NonAutoSizeHeight = 23;
            this.cmbEndDate.Size = new System.Drawing.Size(144, 21);
            this.cmbEndDate.TabIndex = 30;
            // 
            // chkEndDate
            // 
            this.chkEndDate.Location = new System.Drawing.Point(592, 16);
            this.chkEndDate.Name = "chkEndDate";
            this.chkEndDate.Size = new System.Drawing.Size(72, 20);
            this.chkEndDate.TabIndex = 29;
            this.chkEndDate.Text = "到期时间";
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.Location = new System.Drawing.Point(352, 112);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel8.TabIndex = 28;
            this.ultraLabel8.Text = "客服姓名：";
            // 
            // txtCustomerService
            // 
            this.txtCustomerService.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtCustomerService.Location = new System.Drawing.Point(464, 112);
            this.txtCustomerService.Name = "txtCustomerService";
            this.txtCustomerService.Size = new System.Drawing.Size(100, 21);
            this.txtCustomerService.TabIndex = 27;
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Location = new System.Drawing.Point(352, 80);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel7.TabIndex = 26;
            this.ultraLabel7.Text = "销售人员：";
            // 
            // txtSales
            // 
            this.txtSales.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtSales.Location = new System.Drawing.Point(464, 80);
            this.txtSales.Name = "txtSales";
            this.txtSales.Size = new System.Drawing.Size(100, 21);
            this.txtSales.TabIndex = 25;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(360, 48);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel6.TabIndex = 24;
            this.ultraLabel6.Text = "行业：";
            // 
            // cmbTrade
            // 
            this.cmbTrade.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbTrade.Location = new System.Drawing.Point(464, 48);
            this.cmbTrade.Name = "cmbTrade";
            this.cmbTrade.Size = new System.Drawing.Size(104, 21);
            this.cmbTrade.TabIndex = 23;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(80, 80);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel5.TabIndex = 22;
            this.ultraLabel5.Text = "企业性质：";
            // 
            // cmbEnterpriseType
            // 
            this.cmbEnterpriseType.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbEnterpriseType.Location = new System.Drawing.Point(184, 80);
            this.cmbEnterpriseType.Name = "cmbEnterpriseType";
            this.cmbEnterpriseType.Size = new System.Drawing.Size(104, 21);
            this.cmbEnterpriseType.TabIndex = 21;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(80, 48);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 18;
            this.ultraLabel3.Text = "工商注册号：";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(360, 16);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 17;
            this.ultraLabel2.Text = "单位名称：";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(80, 16);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 16;
            this.ultraLabel1.Text = "会员卡号：";
            // 
            // btnQuery
            // 
            this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnQuery.Location = new System.Drawing.Point(608, 112);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtPaperNo
            // 
            this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPaperNo.Location = new System.Drawing.Point(184, 48);
            this.txtPaperNo.Name = "txtPaperNo";
            this.txtPaperNo.Size = new System.Drawing.Size(100, 21);
            this.txtPaperNo.TabIndex = 5;
            // 
            // txtMemberName
            // 
            this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberName.Location = new System.Drawing.Point(464, 16);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtMemberName.TabIndex = 3;
            // 
            // txtMemberCardNo
            // 
            this.txtMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberCardNo.Location = new System.Drawing.Point(184, 16);
            this.txtMemberCardNo.Name = "txtMemberCardNo";
            this.txtMemberCardNo.Size = new System.Drawing.Size(100, 21);
            this.txtMemberCardNo.TabIndex = 1;
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraGrid1.Location = new System.Drawing.Point(72, 64);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(200, 80);
            this.ultraGrid1.TabIndex = 1;
            this.ultraGrid1.Text = "会员档案";
            this.ultraGrid1.InitializePrint += new Infragistics.Win.UltraWinGrid.InitializePrintEventHandler(this.ultraGrid1_InitializePrint);
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            this.ultraGrid1.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ultraGrid1_InitializeRow);
            // 
            // ultraPrintPreviewDialog1
            // 
            this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.ultraGrid1);
            this.ultraGroupBox2.Location = new System.Drawing.Point(24, 200);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(976, 368);
            this.ultraGroupBox2.TabIndex = 2;
            // 
            // MemberFreeModify
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1016, 573);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "MemberFreeModify";
            this.Text = "场次修改";
            this.Load += new System.EventHandler(this.MemberFileQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMemberRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdBeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnterpriseType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void MemberFileQuery_Load(object sender, System.EventArgs e)
		{
//			//绑定会员状态
//			DataTable dtState = new DataTable();
//			//dtState.Columns.Add("cnvcState");
//			dtState.Columns.Add("会员状态");
//
//			DataRow drState0 = dtState.NewRow();
//			drState0["会员状态"] = ConstApp.Card_State_InUse;
//			dtState.Rows.Add(drState0);
//
//			DataRow drState1 = dtState.NewRow();
//			drState1["会员状态"] = ConstApp.Card_State_InLose;
//			dtState.Rows.Add(drState1);
//
//			DataRow drState2 = dtState.NewRow();
//			drState2["会员状态"] = ConstApp.Card_State_InAdd;
//			dtState.Rows.Add(drState2);
//
//			DataRow drState3 = dtState.NewRow();
//			drState3["会员状态"] = ConstApp.Card_State_InCallBack;
//			dtState.Rows.Add(drState3);		
//			DataRow drState4 = dtState.NewRow();
//			drState4["会员状态"] = ConstApp.Card_State_NoCard;
//			dtState.Rows.Add(drState4);			
//			
//
//			
//			cmbState.DataSource = dtState;
//			cmbState.DataBind();	
			//cmbState.SelectedIndex = 0;

            ClientHelper.BindEnterpriseType(cmbEnterpriseType);
            ClientHelper.BindTrade(cmbTrade);

			cmdBeginDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEndDate2.MaskInput = "yyyy-mm-dd hh:mm";
			cmdBeginDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 00:00";
			cmbEndDate2.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 23:59";

			//cmbEndDate.MaskInput = "yyyy-mm-dd";

			this.ultraGrid1.Dock       = DockStyle.Fill;
			this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti; 
			this.ultraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
			this.ultraGroupBox2.BringToFront();

            ClientHelper.BindMemberRight(cmbMemberRight);
			PopulateValueList();

//			if (ClientHelper.idept.cnnDeptID != 0)
//			{
//				if(!Login.constApp.alOperFunc.Contains("会员档案报表查询"))
//				{
//					this.btnQuery.Enabled = false;
//				}
//				if(!Login.constApp.alOperFunc.Contains("会员档案报表打印"))
//				{
//					this.btnPrint.Enabled = false;
//					this.btnExcel.Enabled = false;
//				}
//				if(!Login.constApp.alOperFunc.Contains("会员档案报表修改"))
//				{
//					//this.btnPrint.Enabled = false;
//					this.btnModify.Enabled = false;
//				}
//			}
			
		}

		private void PopulateValueList()
		{
			if ( this.ultraGrid1.DisplayLayout.ValueLists.Exists("cnvcCustomerService") ) { return; }

			ValueList objValueList = this.ultraGrid1.DisplayLayout.ValueLists.Add("cnvcCustomerService");
			DataTable dtCustomerService = Helper.Query("select distinct cnvcCustomerService from tbMember where cnvcCustomerService is not null");
			//DataTable ds = new SpaceFlightsData().SpacePorts;
			for ( int i = 0 ; i < dtCustomerService.Rows.Count; i ++ )
				objValueList.ValueListItems.Add(dtCustomerService.Rows[i].ItemArray[0], dtCustomerService.Rows[i].ItemArray[0].ToString());
		}
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//查询
			try
			{
				//this.btnInlose.Enabled = true;
				string strSql = "select "
					          + " cnvcMemberCardNo,cnvcMemberPwd,cnvcMemberName,cnvcPaperNo,cnvcCorporation, "
                              + " cnvcCompanyAddress,cnvcLinkman,cnvcLinkPhone,cnvcEmail,cnvcFax,cnvcComments,cnvcMemberRight,cnvcEnterpriseType,cnvcDiscount,cnvcFree,cnvcFree as cnvcOldFree,cnvcProduct,cnvcState,cnnMemberFee, "
                              + " cnnPrepay,cndEndDate,cnvcOperName,cndOperDate,cnvcMobileTelePhone,cnvcPostalCode,cnvcSales,cnvcHandleman,cnvcHandlemanPaperNo, "
                              + " cnvcTrade,cnvcCustomerService,cnvcCustomerService as cnvcOldCustomerService "
					          + " ,case cniSynch "
					          + " when 0 then '会员系统' "
							  + " when 1 then '网站操作' "
							  + " when 2 then '触摸屏操作'  "
                              + " end cnvcSynch,cndInNetDate from tbMember where cnvcState='"+ConstApp.Card_State_InUse+"' ";
				if (txtMemberCardNo.Text.Trim().Length > 0)
				{
					strSql += " and cnvcMemberCardNo like '%"+txtMemberCardNo.Text+"%'";
				}
				if (txtMemberName.Text.Trim().Length > 0)
				{
					strSql += " and cnvcMemberName like '%"+txtMemberName.Text+"%'";
				}
				if (txtPaperNo.Text.Trim().Length > 0)
				{
					strSql += " and cnvcPaperNo like '%"+txtPaperNo.Text+"%'";
				}
//				if (cmbState.Text.Trim().Length > 0)
//				{
//					strSql += " and cnvcState = '"+cmbState.Text+"'";
//				}
				if (cmbEnterpriseType.Text.Trim().Length > 0)
				{
					strSql += " and cnvcEnterpriseType like '%"+cmbEnterpriseType.Text+"%'";					
				}
				if (cmbTrade.Text.Trim().Length > 0)
				{
					strSql += " and cnvcTrade like '%"+cmbTrade.Text+"%'";
				}
				if (txtSales.Text.Trim().Length > 0)
				{
					strSql += " and cnvcSales like '%"+txtSales.Text+"%'";
				}
				if (txtCustomerService.Text.Trim().Length > 0)
				{
					strSql += " and cnvcCustomerService like '%"+txtCustomerService.Text+"%'";
				}
				if (chkEndDate.Checked)
				{
					string strEndDate="";
					string aa=cmbEndDate.Text.Trim();
					if (DateTime.Parse(aa).Month<10)
					{
						strEndDate =DateTime.Parse(aa).Year.ToString()+ "-" + "0" + DateTime.Parse(aa).Month.ToString();
					}
					else 
					{
						strEndDate =DateTime.Parse(aa).Year.ToString()+ "-"  + DateTime.Parse(aa).Month.ToString();
					}
					if (DateTime.Parse(aa).Day<10)
					{
						strEndDate +="-" + "0" + DateTime.Parse(aa).Day.ToString();
					}
					else
					{
						strEndDate +="-" +  DateTime.Parse(aa).Day.ToString();
					}

					strSql += " and cndEndDate < = '"+ strEndDate +"' ";
				}
				if (chkBeginDate.Checked)
				{
					strSql += " and cndInNetDate >='"+cmdBeginDate.Text+"'";
				}
				if (chkEndDate2.Checked)
				{
					strSql += " and cndInNetDate <='"+cmbEndDate2.Text+"'";
				}
				if (cmbMemberRight.Text.Trim().Length > 0)
				{
					strSql += " and cnvcMemberRight = '"+cmbMemberRight.Text+"'";
				}
				Query query = new Query();
				DataTable dtMember = query.Report(strSql);
				
				this.ultraGrid1.DataSource = null;
				this.ultraGrid1.DataSource = dtMember;
				this.ultraGrid1.DataBind();
                ClientHelper.AddGridColumn(this.ultraGrid1, this.oper.cnvcOperName);
				Helper.AddGridSummary(this.ultraGrid1,SummaryType.Count,"{0}",0);	
				
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

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Helper.Print(this,ultraGrid1,ultraGridPrintDocument1,ultraPrintPreviewDialog1);
		}

		private void ultraGrid1_InitializePrint(object sender, Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs e)
		{
			Helper.PrintDisplay(e,"云南人才市场会员档案报表");
		}

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			//Helper.SetGridDisplay(e);
			e.Layout.ScrollBounds = ScrollBounds.ScrollToFill; 
			//e.Layout.Override.CellClickAction = CellClickAction.;
			e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;//UltraWinGrid.SelectType.Single;

			e.Layout.Bands[0].Override.SummaryFooterCaptionAppearance.FontData.Bold = DefaultableBoolean.True; 
			e.Layout.Bands[0].Override.SummaryValueAppearance.BackColor = Color.White;
			e.Layout.Bands[0].Override.SummaryValueAppearance.TextHAlign = HAlign.Right;
			e.Layout.Bands[0].Override.SummaryFooterCaptionAppearance.BackColor = Color.White;

			foreach (UltraGridColumn  col in e.Layout.Bands[0].Columns)
			{
				col.CellActivation = Activation.NoEdit;
			}

			e.Layout.Bands[0].Columns["cnvcCustomerService"].ValueList = this.ultraGrid1.DisplayLayout.ValueLists["cnvcCustomerService"];
			//
			e.Layout.Bands[0].Columns["cnvcFax"].Header.Caption = "传真";			
			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "会员卡号";			
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "实收";
			e.Layout.Bands[0].Columns["cnnMemberFee"].Header.Caption = "会员费";
			e.Layout.Bands[0].Columns["cnvcFree"].Header.Caption = "剩余场次";
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Header.Caption = "会员资格";
			e.Layout.Bands[0].Columns["cnvcState"].Header.Caption = "操作状态";
			e.Layout.Bands[0].Columns["cnvcOperName"].Header.Caption = "操作员名称";
			e.Layout.Bands[0].Columns["cndOperDate"].Header.Caption = "操作时间";
			e.Layout.Bands[0].Columns["cnvcDiscount"].Header.Caption = "折扣";
			e.Layout.Bands[0].Columns["cndEndDate"].Header.Caption = "到期时间";


			e.Layout.Bands[0].Columns["cnvcMemberPwd"].Hidden = true;//cnvcOldCustomerService
			e.Layout.Bands[0].Columns["cnvcOldCustomerService"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcOldFree"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcCorporation"].Header.Caption = "法人代表";
			e.Layout.Bands[0].Columns["cnvcCompanyAddress"].Header.Caption = "单位地址";
			e.Layout.Bands[0].Columns["cnvcLinkMan"].Header.Caption = "联系人";
			e.Layout.Bands[0].Columns["cnvcLinkPhone"].Header.Caption = "办公电话";
			e.Layout.Bands[0].Columns["cnvcEmail"].Header.Caption = "电子邮箱";
			e.Layout.Bands[0].Columns["cnvcComments"].Header.Caption = "备注";
			e.Layout.Bands[0].Columns["cnvcProduct"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcEnterpriseType"].Header.Caption = "企业性质";
			e.Layout.Bands[0].Columns["cnvcMobileTelephone"].Header.Caption = "手机号码";
			e.Layout.Bands[0].Columns["cnvcPostalCode"].Header.Caption = "邮政编码";
			e.Layout.Bands[0].Columns["cnvcSales"].Header.Caption = "销售人员";
			e.Layout.Bands[0].Columns["cnvcHandleman"].Header.Caption = "经办人";
			e.Layout.Bands[0].Columns["cnvcHandlemanPaperNo"].Header.Caption = "经办人身份证号";
			e.Layout.Bands[0].Columns["cnvcTrade"].Header.Caption = "行业";
			e.Layout.Bands[0].Columns["cnvcCustomerService"].Header.Caption = "客服姓名";
			e.Layout.Bands[0].Columns["cnvcFree"].CellActivation = Activation.AllowEdit;
			e.Layout.Bands[0].Columns["cnvcSynch"].Header.Caption = "同步标志";
			e.Layout.Bands[0].Columns["cndInNetDate"].Header.Caption = "入会时间";
			//e.Layout.Bands[0].Columns["cniRecid"].Hidden = true;
			//e.Layout.Bands[0].Columns["cniSynch"].Hidden = true;

			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Width = 60;
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Width = 100;
			e.Layout.Bands[0].Columns["cnvcDiscount"].Width = 30;
			e.Layout.Bands[0].Columns["cnvcFree"].Width = 60;

			e.Layout.Bands[0].Columns["cndOperDate"].CellActivation = Activation.NoEdit;


			e.Layout.Bands[0].SummaryFooterCaption = "合计：会员数量"; 

		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{

            ClientHelper.ExportExcel(saveFileDialog1, ultraGridExcelExporter1, this.ultraGrid1, "云南人才市场会员档案报表", this.oper.cnvcOperName);
		}

		private void btnModify_Click(object sender, System.EventArgs e)
		{
			//修改免费场次
			try
			{
				string strMemberCardNo = "";
				string strTipinfo = "";
				foreach (UltraGridRow row in this.ultraGrid1.Rows)
				{
					string strOldFree = row.Cells["cnvcOldFree"].Value.ToString();
					string strFree = row.Cells["cnvcFree"].Value.ToString();

					//string strSelected = row.Cells["cnvcAudit"].Value.ToString();
					//bool   bSelected = bool.Parse(strSelected);
					if (!strOldFree.Equals(strFree))
					{
						//if (row.Cells["cnvcOldAudit"].Value.ToString().Equals(ConstApp.IsNotAudit)||row.Cells["cnvcOldAudit"].Value.ToString()=="")
						//{
						strMemberCardNo += row.Cells["cnvcMemberCardNo"].Value.ToString()+"|"+row.Cells["cnvcFree"].Value.ToString()+",";
						strTipinfo += "\r会员卡号："+row.Cells["cnvcMemberCardNo"].Value.ToString()+"\r单位名称："+row.Cells["cnvcMemberName"].Value.ToString()+"\r原有免费场次："+row.Cells["cnvcOldFree"].Value.ToString()+"\r新免费场次："+row.Cells["cnvcFree"].Value.ToString();
						//}
					}
				}
				if (strMemberCardNo != "")
				{		
					
					if(DialogResult.Yes == MessageBox.Show(this,strTipinfo,"修改信息确认",MessageBoxButtons.YesNo,MessageBoxIcon.Information))
					{
                        MemberManageFacade mm = new MemberManageFacade();
						mm.FreeModify(strMemberCardNo);
						MessageBox.Show(this,"修改成功","修改",MessageBoxButtons.OK,MessageBoxIcon.Information);

					}
					
				}
				else
				{
					MessageBox.Show(this,"没有修改记录","修改",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
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

		private void ultraGroupBox1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void ultraGrid1_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
		{
			EmbeddableEditorBase editor = null;
			DefaultEditorOwnerSettings editorSettings = null;
			
			editorSettings = new DefaultEditorOwnerSettings( );
			editorSettings.DataType = typeof( int );
			editor = new EditorWithMask( new DefaultEditorOwner( editorSettings ) );
			editorSettings.MaskInput = "nnnn";
			e.Row.Cells[ "cnvcFree" ].Editor = editor;
		}
}
}
