using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MemberManage.Business;
using System.Data;
using System.Data.SqlClient;
using Infragistics;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Domain;
using ynhrMemberManage.Common;
namespace MemberManage.Reports
{
	/// <summary>
	/// Summary description for NoBookingReport.
	/// </summary>
    public class NoBookingReport : frmBase
	{
		private System.ComponentModel.IContainer components;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.Printing.UltraPrintPreviewDialog ultraPrintPreviewDialog1;
		private Infragistics.Win.UltraWinGrid.UltraGridPrintDocument ultraGridPrintDocument1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		private Infragistics.Win.Misc.UltraButton btnExcel;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEndDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate;
		private Infragistics.Win.Misc.UltraButton btnPrint;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmdBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbShow;
		private Infragistics.Win.Misc.UltraButton btnQuery;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBeginDate;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbMember;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbTrade;
		private Infragistics.Win.Misc.UltraLabel ultraLabel8;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCustomerService;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSales;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbSynch;
		private Infragistics.Win.Misc.UltraLabel ultraLabel10;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbMemberRight;
		private Infragistics.Win.Misc.UltraButton btnFilter;
		public static bool IsShowing;

		public NoBookingReport()
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
			this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.ultraPrintPreviewDialog1 = new Infragistics.Win.Printing.UltraPrintPreviewDialog(this.components);
			this.ultraGridPrintDocument1 = new Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(this.components);
			this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
			this.cmbMemberRight = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
			this.cmbSynch = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
			this.txtCustomerService = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
			this.txtSales = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
			this.cmbTrade = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
			this.cmbMember = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
			this.txtPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.txtMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.btnExcel = new Infragistics.Win.Misc.UltraButton();
			this.cmbEndDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.chkEndDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.btnPrint = new Infragistics.Win.Misc.UltraButton();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.cmdBeginDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.cmbShow = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.btnQuery = new Infragistics.Win.Misc.UltraButton();
			this.chkBeginDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
			this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
			this.btnFilter = new Infragistics.Win.Misc.UltraButton();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
			this.ultraGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbMemberRight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbSynch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCustomerService)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSales)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbTrade)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbMember)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmdBeginDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbShow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
			this.ultraGroupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// ultraGrid1
			// 
			this.ultraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			this.ultraGrid1.Location = new System.Drawing.Point(48, 64);
			this.ultraGrid1.Name = "ultraGrid1";
			this.ultraGrid1.Size = new System.Drawing.Size(216, 88);
			this.ultraGrid1.TabIndex = 16;
			this.ultraGrid1.Text = "取消预订列表";
			this.ultraGrid1.InitializePrint += new Infragistics.Win.UltraWinGrid.InitializePrintEventHandler(this.ultraGrid1_InitializePrint);
			this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
			// 
			// ultraPrintPreviewDialog1
			// 
			this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
			// 
			// ultraGroupBox1
			// 
			this.ultraGroupBox1.Controls.Add(this.btnFilter);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel10);
			this.ultraGroupBox1.Controls.Add(this.cmbMemberRight);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel9);
			this.ultraGroupBox1.Controls.Add(this.cmbSynch);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel8);
			this.ultraGroupBox1.Controls.Add(this.txtCustomerService);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel7);
			this.ultraGroupBox1.Controls.Add(this.txtSales);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel4);
			this.ultraGroupBox1.Controls.Add(this.cmbTrade);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
			this.ultraGroupBox1.Controls.Add(this.cmbMember);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel5);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel6);
			this.ultraGroupBox1.Controls.Add(this.txtPaperNo);
			this.ultraGroupBox1.Controls.Add(this.txtMemberName);
			this.ultraGroupBox1.Controls.Add(this.txtMemberCardNo);
			this.ultraGroupBox1.Controls.Add(this.btnExcel);
			this.ultraGroupBox1.Controls.Add(this.cmbEndDate);
			this.ultraGroupBox1.Controls.Add(this.chkEndDate);
			this.ultraGroupBox1.Controls.Add(this.btnPrint);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
			this.ultraGroupBox1.Controls.Add(this.cmdBeginDate);
			this.ultraGroupBox1.Controls.Add(this.cmbShow);
			this.ultraGroupBox1.Controls.Add(this.btnQuery);
			this.ultraGroupBox1.Controls.Add(this.chkBeginDate);
			this.ultraGroupBox1.Location = new System.Drawing.Point(120, 24);
			this.ultraGroupBox1.Name = "ultraGroupBox1";
			this.ultraGroupBox1.Size = new System.Drawing.Size(756, 200);
			this.ultraGroupBox1.TabIndex = 17;
			// 
			// ultraLabel10
			// 
			this.ultraLabel10.Location = new System.Drawing.Point(96, 160);
			this.ultraLabel10.Name = "ultraLabel10";
			this.ultraLabel10.Size = new System.Drawing.Size(96, 23);
			this.ultraLabel10.TabIndex = 47;
			this.ultraLabel10.Text = "会员资格：";
			// 
			// cmbMemberRight
			// 
			this.cmbMemberRight.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbMemberRight.Location = new System.Drawing.Point(200, 160);
			this.cmbMemberRight.Name = "cmbMemberRight";
			this.cmbMemberRight.TabIndex = 46;
			// 
			// ultraLabel9
			// 
			this.ultraLabel9.Location = new System.Drawing.Point(80, 128);
			this.ultraLabel9.Name = "ultraLabel9";
			this.ultraLabel9.Size = new System.Drawing.Size(112, 23);
			this.ultraLabel9.TabIndex = 42;
			this.ultraLabel9.Text = "同步标志：";
			// 
			// cmbSynch
			// 
			this.cmbSynch.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbSynch.Location = new System.Drawing.Point(200, 128);
			this.cmbSynch.Name = "cmbSynch";
			this.cmbSynch.TabIndex = 41;
			// 
			// ultraLabel8
			// 
			this.ultraLabel8.Location = new System.Drawing.Point(384, 168);
			this.ultraLabel8.Name = "ultraLabel8";
			this.ultraLabel8.TabIndex = 40;
			this.ultraLabel8.Text = "客服姓名：";
			// 
			// txtCustomerService
			// 
			this.txtCustomerService.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtCustomerService.Location = new System.Drawing.Point(488, 168);
			this.txtCustomerService.Name = "txtCustomerService";
			this.txtCustomerService.Size = new System.Drawing.Size(100, 21);
			this.txtCustomerService.TabIndex = 39;
			// 
			// ultraLabel7
			// 
			this.ultraLabel7.Location = new System.Drawing.Point(384, 144);
			this.ultraLabel7.Name = "ultraLabel7";
			this.ultraLabel7.TabIndex = 38;
			this.ultraLabel7.Text = "销售人员：";
			// 
			// txtSales
			// 
			this.txtSales.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtSales.Location = new System.Drawing.Point(488, 144);
			this.txtSales.Name = "txtSales";
			this.txtSales.Size = new System.Drawing.Size(100, 21);
			this.txtSales.TabIndex = 37;
			// 
			// ultraLabel4
			// 
			this.ultraLabel4.Location = new System.Drawing.Point(384, 120);
			this.ultraLabel4.Name = "ultraLabel4";
			this.ultraLabel4.TabIndex = 36;
			this.ultraLabel4.Text = "行业：";
			// 
			// cmbTrade
			// 
			this.cmbTrade.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbTrade.Location = new System.Drawing.Point(488, 120);
			this.cmbTrade.Name = "cmbTrade";
			this.cmbTrade.Size = new System.Drawing.Size(104, 21);
			this.cmbTrade.TabIndex = 35;
			// 
			// ultraLabel3
			// 
			this.ultraLabel3.Location = new System.Drawing.Point(384, 24);
			this.ultraLabel3.Name = "ultraLabel3";
			this.ultraLabel3.Size = new System.Drawing.Size(96, 23);
			this.ultraLabel3.TabIndex = 34;
			this.ultraLabel3.Text = "是否会员：";
			// 
			// cmbMember
			// 
			this.cmbMember.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbMember.Location = new System.Drawing.Point(488, 24);
			this.cmbMember.Name = "cmbMember";
			this.cmbMember.Size = new System.Drawing.Size(104, 21);
			this.cmbMember.TabIndex = 33;
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.Location = new System.Drawing.Point(384, 96);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.TabIndex = 26;
			this.ultraLabel1.Text = "工商注册号：";
			// 
			// ultraLabel5
			// 
			this.ultraLabel5.Location = new System.Drawing.Point(384, 72);
			this.ultraLabel5.Name = "ultraLabel5";
			this.ultraLabel5.TabIndex = 25;
			this.ultraLabel5.Text = "单位名称：";
			// 
			// ultraLabel6
			// 
			this.ultraLabel6.Location = new System.Drawing.Point(384, 48);
			this.ultraLabel6.Name = "ultraLabel6";
			this.ultraLabel6.TabIndex = 24;
			this.ultraLabel6.Text = "会员卡号：";
			// 
			// txtPaperNo
			// 
			this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtPaperNo.Location = new System.Drawing.Point(488, 96);
			this.txtPaperNo.Name = "txtPaperNo";
			this.txtPaperNo.Size = new System.Drawing.Size(100, 21);
			this.txtPaperNo.TabIndex = 22;
			// 
			// txtMemberName
			// 
			this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtMemberName.Location = new System.Drawing.Point(488, 72);
			this.txtMemberName.Name = "txtMemberName";
			this.txtMemberName.Size = new System.Drawing.Size(100, 21);
			this.txtMemberName.TabIndex = 21;
			// 
			// txtMemberCardNo
			// 
			this.txtMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtMemberCardNo.Location = new System.Drawing.Point(488, 48);
			this.txtMemberCardNo.Name = "txtMemberCardNo";
			this.txtMemberCardNo.Size = new System.Drawing.Size(100, 21);
			this.txtMemberCardNo.TabIndex = 20;
			// 
			// btnExcel
			// 
			this.btnExcel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnExcel.Location = new System.Drawing.Point(632, 128);
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.TabIndex = 12;
			this.btnExcel.Text = "导出EXCEL";
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			// 
			// cmbEndDate
			// 
			this.cmbEndDate.DateTime = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
			this.cmbEndDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbEndDate.Location = new System.Drawing.Point(200, 96);
			this.cmbEndDate.MaskInput = "{date} {time}";
			this.cmbEndDate.Name = "cmbEndDate";
			this.cmbEndDate.TabIndex = 7;
			this.cmbEndDate.Value = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
			// 
			// chkEndDate
			// 
			this.chkEndDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.chkEndDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.chkEndDate.Location = new System.Drawing.Point(80, 96);
			this.chkEndDate.Name = "chkEndDate";
			this.chkEndDate.TabIndex = 11;
			this.chkEndDate.Text = "结束时间";
			// 
			// btnPrint
			// 
			this.btnPrint.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnPrint.Location = new System.Drawing.Point(632, 96);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.TabIndex = 3;
			this.btnPrint.Text = "打印";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// ultraLabel2
			// 
			this.ultraLabel2.Location = new System.Drawing.Point(80, 32);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.Size = new System.Drawing.Size(112, 23);
			this.ultraLabel2.TabIndex = 6;
			this.ultraLabel2.Text = "招聘会：";
			// 
			// cmdBeginDate
			// 
			this.cmdBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmdBeginDate.Location = new System.Drawing.Point(200, 64);
			this.cmdBeginDate.MaskInput = "{date} {time}";
			this.cmdBeginDate.Name = "cmdBeginDate";
			this.cmdBeginDate.TabIndex = 5;
			// 
			// cmbShow
			// 
			this.cmbShow.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbShow.Location = new System.Drawing.Point(200, 32);
			this.cmbShow.Name = "cmbShow";
			this.cmbShow.TabIndex = 4;
			// 
			// btnQuery
			// 
			this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnQuery.Location = new System.Drawing.Point(632, 64);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.TabIndex = 0;
			this.btnQuery.Text = "查询";
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// chkBeginDate
			// 
			this.chkBeginDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.chkBeginDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.chkBeginDate.Location = new System.Drawing.Point(80, 64);
			this.chkBeginDate.Name = "chkBeginDate";
			this.chkBeginDate.TabIndex = 10;
			this.chkBeginDate.Text = "开始时间";
			// 
			// ultraGroupBox2
			// 
			this.ultraGroupBox2.Controls.Add(this.ultraGrid1);
			this.ultraGroupBox2.Location = new System.Drawing.Point(16, 232);
			this.ultraGroupBox2.Name = "ultraGroupBox2";
			this.ultraGroupBox2.Size = new System.Drawing.Size(992, 352);
			this.ultraGroupBox2.TabIndex = 18;
			// 
			// btnFilter
			// 
			this.btnFilter.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnFilter.Location = new System.Drawing.Point(344, 32);
			this.btnFilter.Name = "btnFilter";
			this.btnFilter.Size = new System.Drawing.Size(40, 23);
			this.btnFilter.TabIndex = 52;
			this.btnFilter.Text = "检索";
			this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
			// 
			// NoBookingReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(1024, 605);
			this.Controls.Add(this.ultraGroupBox2);
			this.Controls.Add(this.ultraGroupBox1);
			this.Name = "NoBookingReport";
			this.Text = "取消预订报表";
			this.Load += new System.EventHandler(this.NoBookingReport_Load);
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
			this.ultraGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbMemberRight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbSynch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCustomerService)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSales)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbTrade)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbMember)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmdBeginDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbShow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
			this.ultraGroupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Helper.Print(this,ultraGrid1,ultraGridPrintDocument1,ultraPrintPreviewDialog1);	
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			string strSql = "select a.cnvcMemberCardNo,a.cnvcMemberName,a.cnvcPaperNo,a.cnvcJobName,cast (a.cnvcSeat as int) as cnvcSeat,a.cnvcOperName,a.cndOperDate,"
				+ " case "
				+ " when a.cnvcMemberCardNo is null then '' "
				+ " when a.cnvcMemberCardNo is not null then b.cnvcMemberRight "
				+ " end cnvcMemberRight ,"
				+ " case "
				+ " when a.cnvcMemberCardNo is null then c.cnvcTrade "
				+ " when a.cnvcMemberCardNo is not null then b.cnvcTrade "
				+ " end cnvcTrade ,"
				+ " case "
				+ " when a.cnvcMemberCardNo is null then c.cnvcSales "
				+ " when a.cnvcMemberCardNo is not null then b.cnvcSales "
				+ " end cnvcSales ,"
				+ " case "
				+ " when a.cnvcMemberCardNo is null then c.cnvcCustomerService "
				+ " when a.cnvcMemberCardNo is not null then b.cnvcCustomerService "
				+ " end cnvcCustomerService "
				+ " ,case a.cniSynch "
				+ " when 0 then '会员系统' "
				+ " when 1 then '网站操作' "
				+ " when 2 then '触摸屏操作'  "
				+ " end cnvcSynch "
				+ " from tbMemberSeat a "
				+ " left outer join tbMember b on a.cnvcMemberCardNo = b.cnvcMemberCardNo  and a.cnvcMemberCardNo is not null "
				+ " left outer join tbFMember c on a.cnvcPaperNo=c.cnvcPaperNo and a.cnvcMemberCardNo is null ";
			strSql += " where a.cnvcState='"+ConstApp.Show_Seat_State_No_Booking+"'";
			
			if (cmbMember.Text == "会员")
			{
				strSql += " and a.cnvcMemberCardNo is not null";
			}
			if (cmbMember.Text == "非会员")
			{
				strSql += " and a.cnvcMemberCardNo is null";
			}			
			
			if (cmbShow.SelectedItem != null)
			{
				strSql += " and a.cnnID="+cmbShow.SelectedItem.DataValue.ToString();

			}
			if (chkBeginDate.Checked)
			{
				strSql += " and a.cndOperDate >='"+cmdBeginDate.Text+"'";
			}
			if (chkEndDate.Checked)
			{
				strSql += " and a.cndOperDate <='"+cmbEndDate.Text+"'";
			}
			if (txtMemberCardNo.Text.Trim().Length > 0)
			{
				strSql += " and a.cnvcMemberCardNo like '%"+txtMemberCardNo.Text+"%'";
			}
			if (txtMemberName.Text.Trim().Length > 0)
			{
				strSql += " and a.cnvcMemberName like '%"+txtMemberName.Text+"%'";
			}
			if (txtPaperNo.Text.Trim().Length > 0)
			{
				strSql += " and a.cnvcPaperNo like '%"+txtPaperNo.Text+"%'";
			}
			if (cmbTrade.Text.Trim().Length > 0)
			{
				strSql += " and (b.cnvcTrade like '%"+cmbTrade.Text+"%' or c.cnvcTrade like '%"+cmbTrade.Text+"%')";
			}
			if (txtSales.Text.Trim().Length > 0)
			{
				strSql += " and (b.cnvcSales like '%"+txtSales.Text+"%' or c.cnvcSales like '%"+txtSales.Text+"%')";
				//strSql += " and cnvcSales like '%"+txtSales.Text+"%'";
			}
			if (txtCustomerService.Text.Trim().Length > 0)
			{
				strSql += " and (b.cnvcCustomerService like '%"+txtCustomerService.Text+"%' or c.cnvcCustomerService like '%"+txtCustomerService.Text+"%')";
				//strSql += " and cnvcCustomerService like '%"+txtCustomerService.Text+"%'";
			}
			if (cmbSynch.Text.Trim().Length > 0)
			{
				strSql += " and a.cniSynch = "+cmbSynch.Value.ToString() ;
			}
			if (cmbMemberRight.Text.Trim().Length > 0)
			{
				strSql += " and b.cnvcMemberRight = '"+cmbMemberRight.Text +"'";
			}
			strSql +="  order by cast (cnvcSeat as int)";
			DataTable dt = Helper.Query(strSql);//query.Report(strSql);
			
			this.ultraGrid1.DataSource = null;
			this.ultraGrid1.DataSource = dt;
			this.ultraGrid1.SetDataBinding(dt,null);

            ClientHelper.AddGridColumn(this.ultraGrid1, this.oper.cnvcOperName);
			Helper.AddGridSummary(this.ultraGrid1,SummaryType.Count,"{0}",0);			
		}

		private void NoBookingReport_Load(object sender, System.EventArgs e)
		{
			this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            ClientHelper.BindTrade(cmbTrade);
            ClientHelper.BindMemberRight(cmbMemberRight);
			cmdBeginDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEndDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmdBeginDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 00:00";
			cmbEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 23:59";
			//Helper.BindJob_Query(cmbShow);
			Helper.BindJob_Query_Limit(cmbShow);

			Helper.BindMember(cmbMember);
			Helper.BindSynch(cmbSynch);

			this.ultraGrid1.Dock       = DockStyle.Fill;
			this.ultraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
			this.ultraGroupBox2.BringToFront();

            //if (ClientHelper.idept.cnnDeptID != 0)
            //{
            //    if(!Login.constApp.alOperFunc.Contains("取消预订报表查询"))
            //    {
            //        this.btnQuery.Enabled = false;
            //    }
            //    if(!Login.constApp.alOperFunc.Contains("取消报表打印"))
            //    {
            //        this.btnPrint.Enabled = false;
            //        this.btnExcel.Enabled = false;
            //    }
            //}
		}

		private void ultraGrid1_InitializePrint(object sender, Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs e)
		{
			Helper.PrintDisplay(e,"云南人才市场取消预订报表");			
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
            ClientHelper.ExportExcel(saveFileDialog1, ultraGridExcelExporter1, ultraGrid1, "云南人才市场取消预订报表", this.oper.cnvcOperName);
		}

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e); 
			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "会员卡号";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnvcJobName"].Header.Caption = "招聘会";
			e.Layout.Bands[0].Columns["cnvcSeat"].Header.Caption = "展位";
			e.Layout.Bands[0].Columns["cnvcOperName"].Header.Caption = "操作员";
			e.Layout.Bands[0].Columns["cndOperDate"].Header.Caption = "操作时间";
			e.Layout.Bands[0].Columns["cnvcTrade"].Header.Caption = "行业";
			e.Layout.Bands[0].Columns["cnvcSales"].Header.Caption = "销售人员";
			e.Layout.Bands[0].Columns["cnvcCustomerService"].Header.Caption = "客服姓名";
			e.Layout.Bands[0].Columns["cnvcSynch"].Header.Caption = "同步标志";
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Header.Caption = "会员资格";
			e.Layout.Bands[0].Columns["cndOperDate"].Format = "yyyy-MM-dd hh:mm";
			e.Layout.Bands[0].Columns["cndOperDate"].Width = 110;
			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Width = 60;
			e.Layout.Bands[0].Columns["cndOperDate"].CellActivation = Activation.NoEdit;
			e.Layout.Bands[0].SummaryFooterCaption = "合计：数量"; 
		}

		private void btnFilter_Click(object sender, System.EventArgs e)
		{
			string strBeginDate = DateTime.Parse(this.cmdBeginDate.Value.ToString()).ToString("yyyy-MM-dd");
			string strEndDate = DateTime.Parse(this.cmbEndDate.Value.ToString()).ToString("yyyy-MM-dd");
			//Helper.BindJob_Query_Filter(cmbShow,strBeginDate,strEndDate);
			Helper.BindJob_Query_Filter(cmbShow,chkBeginDate.Checked,strBeginDate,chkEndDate.Checked,strEndDate);
		}
	}
}
