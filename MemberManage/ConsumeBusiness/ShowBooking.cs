using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Infragistics.Shared; 
using Infragistics.Win; 
using Infragistics.Win.UltraWinGrid; 
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using ynhrMemberManage.CardCommon.CardRef;
using ynhrMemberManage.CardCommon.CardDef;
using ynhrMemberManage.Print;
using ynhrMemberManage.Common;
using ynhrMemberManage.BusinessFacade.MemberBusiness;
using MemberManage.Business;
namespace MemberManage.MemberBusiness
{
	/// <summary>
	/// Summary description for ShowBooking.
	/// </summary>
    public class ShowBooking : frmBase
	{
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;

		public static bool IsShowing ;
		private System.ComponentModel.IContainer components;
		private Infragistics.Win.Misc.UltraButton btnLoadSeat;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
		private Infragistics.Win.Misc.UltraButton btnBooking;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSeat;
		private Infragistics.Win.Misc.UltraButton btnQuery;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Infragistics.Win.Misc.UltraButton btnQueryFMember;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl4;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.Misc.UltraLabel ultraLabel12;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid2;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
		private Infragistics.Win.Misc.UltraButton btnNoMemberBooking;
		private Infragistics.Win.Misc.UltraButton btnCancelBooking;
		private Infragistics.Win.Misc.UltraButton btnCancelNoMemberBooking;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtFMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtFPaperNo;
		private Infragistics.Win.Printing.UltraPrintDocument ultraPrintDocument1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox4;
		private Infragistics.Win.Misc.UltraButton btnBrushCard;
		private Infragistics.Win.Misc.UltraButton btnCardBook;
		private Infragistics.Win.Misc.UltraLabel ultraLabel8;
		private Infragistics.Win.Misc.UltraLabel ultraLabel10;
		private Infragistics.Win.Misc.UltraLabel ultraLabel11;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCPaperNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCMemberCardNo;
		private Infragistics.Win.Misc.UltraButton btnCancelCardBook;
        private Infragistics.Win.Misc.UltraButton ultraButton2;
		private System.Windows.Forms.ToolTip toolTip1;
		private Infragistics.Win.Misc.UltraButton btnBatchCancelBook;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEndDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmdBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBeginDate;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel14;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
		private Infragistics.Win.Misc.UltraLabel lblMemberCardNo;
		private Infragistics.Win.Misc.UltraLabel lblPaperNo;
        private Infragistics.Win.Misc.UltraLabel lblMemberName;
		private Infragistics.Win.Misc.UltraButton btnFlash;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Infragistics.Win.Misc.UltraButton btnFCancel;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbJob;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbFloors;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbInfoWay;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox6;
        private Infragistics.Win.Misc.UltraLabel lblFree;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
		//private Member pMember = null;
		private MemberSeat ms = null;
		//private bool IsFMember = false;

		public ShowBooking()
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.btnBatchCancelBook = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbJob = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbFloors = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnLoadSeat = new Infragistics.Win.Misc.UltraButton();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGroupBox4 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnCancelCardBook = new Infragistics.Win.Misc.UltraButton();
            this.btnBrushCard = new Infragistics.Win.Misc.UltraButton();
            this.btnCardBook = new Infragistics.Win.Misc.UltraButton();
            this.txtCPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.txtCMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.txtCMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.btnCancelBooking = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.btnQuery = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.txtPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnBooking = new Infragistics.Win.Misc.UltraButton();
            this.ultraTabPageControl5 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.btnCancelNoMemberBooking = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnFCancel = new Infragistics.Win.Misc.UltraButton();
            this.cmbEndDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.chkEndDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cmdBeginDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.chkBeginDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.btnQueryFMember = new Infragistics.Win.Misc.UltraButton();
            this.txtFMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.txtFPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnNoMemberBooking = new Infragistics.Win.Misc.UltraButton();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.txtSeat = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnFlash = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraPrintDocument1 = new Infragistics.Win.Printing.UltraPrintDocument(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ultraGroupBox5 = new Infragistics.Win.Misc.UltraGroupBox();
            this.lblMemberName = new Infragistics.Win.Misc.UltraLabel();
            this.lblPaperNo = new Infragistics.Win.Misc.UltraLabel();
            this.lblMemberCardNo = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbInfoWay = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraGroupBox6 = new Infragistics.Win.Misc.UltraGroupBox();
            this.lblFree = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFloors)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).BeginInit();
            this.ultraGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCMemberCardNo)).BeginInit();
            this.ultraTabPageControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.ultraTabPageControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdBeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).BeginInit();
            this.ultraGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInfoWay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox6)).BeginInit();
            this.ultraGroupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.btnBatchCancelBook);
            this.ultraTabPageControl3.Controls.Add(this.ultraLabel1);
            this.ultraTabPageControl3.Controls.Add(this.ultraLabel2);
            this.ultraTabPageControl3.Controls.Add(this.cmbJob);
            this.ultraTabPageControl3.Controls.Add(this.cmbFloors);
            this.ultraTabPageControl3.Controls.Add(this.btnLoadSeat);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(260, 350);
            // 
            // btnBatchCancelBook
            // 
            this.btnBatchCancelBook.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnBatchCancelBook.Location = new System.Drawing.Point(80, 136);
            this.btnBatchCancelBook.Name = "btnBatchCancelBook";
            this.btnBatchCancelBook.Size = new System.Drawing.Size(96, 23);
            this.btnBatchCancelBook.TabIndex = 15;
            this.btnBatchCancelBook.Text = "批量取消预订";
            this.btnBatchCancelBook.Click += new System.EventHandler(this.btnBatchCancelBook_Click);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(8, 32);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(72, 23);
            this.ultraLabel1.TabIndex = 2;
            this.ultraLabel1.Text = "招聘会：";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(8, 64);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(80, 23);
            this.ultraLabel2.TabIndex = 3;
            this.ultraLabel2.Text = "展厅：";
            // 
            // cmbJob
            // 
            this.cmbJob.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbJob.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbJob.Location = new System.Drawing.Point(104, 32);
            this.cmbJob.Name = "cmbJob";
            this.cmbJob.Size = new System.Drawing.Size(144, 21);
            this.cmbJob.TabIndex = 1;
            this.cmbJob.ValueChanged += new System.EventHandler(this.cmbShow_ValueChanged);
            // 
            // cmbFloors
            // 
            this.cmbFloors.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbFloors.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = "ValueListItem0";
            valueListItem1.DisplayText = "2";
            valueListItem2.DataValue = "ValueListItem1";
            valueListItem2.DisplayText = "3";
            this.cmbFloors.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.cmbFloors.Location = new System.Drawing.Point(104, 64);
            this.cmbFloors.Name = "cmbFloors";
            this.cmbFloors.Size = new System.Drawing.Size(144, 21);
            this.cmbFloors.TabIndex = 4;
            this.cmbFloors.ValueChanged += new System.EventHandler(this.cmbFloor_ValueChanged);
            // 
            // btnLoadSeat
            // 
            this.btnLoadSeat.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnLoadSeat.Location = new System.Drawing.Point(80, 96);
            this.btnLoadSeat.Name = "btnLoadSeat";
            this.btnLoadSeat.Size = new System.Drawing.Size(80, 23);
            this.btnLoadSeat.TabIndex = 6;
            this.btnLoadSeat.Text = "导入座位图";
            this.btnLoadSeat.Click += new System.EventHandler(this.btnLoadSeat_Click);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ultraGroupBox4);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(260, 350);
            // 
            // ultraGroupBox4
            // 
            this.ultraGroupBox4.Controls.Add(this.btnCancelCardBook);
            this.ultraGroupBox4.Controls.Add(this.btnBrushCard);
            this.ultraGroupBox4.Controls.Add(this.btnCardBook);
            this.ultraGroupBox4.Controls.Add(this.txtCPaperNo);
            this.ultraGroupBox4.Controls.Add(this.ultraLabel8);
            this.ultraGroupBox4.Controls.Add(this.txtCMemberName);
            this.ultraGroupBox4.Controls.Add(this.ultraLabel10);
            this.ultraGroupBox4.Controls.Add(this.txtCMemberCardNo);
            this.ultraGroupBox4.Controls.Add(this.ultraLabel11);
            this.ultraGroupBox4.Location = new System.Drawing.Point(10, 24);
            this.ultraGroupBox4.Name = "ultraGroupBox4";
            this.ultraGroupBox4.Size = new System.Drawing.Size(240, 272);
            this.ultraGroupBox4.TabIndex = 16;
            this.ultraGroupBox4.Text = "会员";
            // 
            // btnCancelCardBook
            // 
            this.btnCancelCardBook.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnCancelCardBook.Enabled = false;
            this.btnCancelCardBook.Location = new System.Drawing.Point(173, 144);
            this.btnCancelCardBook.Name = "btnCancelCardBook";
            this.btnCancelCardBook.Size = new System.Drawing.Size(64, 23);
            this.btnCancelCardBook.TabIndex = 13;
            this.btnCancelCardBook.Text = "取消预订";
            this.btnCancelCardBook.Click += new System.EventHandler(this.btnCancelCardBook_Click);
            // 
            // btnBrushCard
            // 
            this.btnBrushCard.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnBrushCard.Location = new System.Drawing.Point(13, 144);
            this.btnBrushCard.Name = "btnBrushCard";
            this.btnBrushCard.Size = new System.Drawing.Size(64, 23);
            this.btnBrushCard.TabIndex = 12;
            this.btnBrushCard.Text = "刷卡";
            this.btnBrushCard.Click += new System.EventHandler(this.btnBrushCard_Click);
            // 
            // btnCardBook
            // 
            this.btnCardBook.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnCardBook.Enabled = false;
            this.btnCardBook.Location = new System.Drawing.Point(93, 144);
            this.btnCardBook.Name = "btnCardBook";
            this.btnCardBook.Size = new System.Drawing.Size(72, 23);
            this.btnCardBook.TabIndex = 7;
            this.btnCardBook.Text = "预订";
            this.btnCardBook.Click += new System.EventHandler(this.btnCardBook_Click);
            // 
            // txtCPaperNo
            // 
            this.txtCPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtCPaperNo.Enabled = false;
            this.txtCPaperNo.Location = new System.Drawing.Point(128, 104);
            this.txtCPaperNo.Name = "txtCPaperNo";
            this.txtCPaperNo.Size = new System.Drawing.Size(100, 21);
            this.txtCPaperNo.TabIndex = 5;
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.Location = new System.Drawing.Point(16, 104);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel8.TabIndex = 4;
            this.ultraLabel8.Text = "工商注册号：";
            // 
            // txtCMemberName
            // 
            this.txtCMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtCMemberName.Enabled = false;
            this.txtCMemberName.Location = new System.Drawing.Point(128, 72);
            this.txtCMemberName.Name = "txtCMemberName";
            this.txtCMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtCMemberName.TabIndex = 3;
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.Location = new System.Drawing.Point(16, 72);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel10.TabIndex = 2;
            this.ultraLabel10.Text = "单位名称：";
            // 
            // txtCMemberCardNo
            // 
            this.txtCMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtCMemberCardNo.Enabled = false;
            this.txtCMemberCardNo.Location = new System.Drawing.Point(128, 40);
            this.txtCMemberCardNo.Name = "txtCMemberCardNo";
            this.txtCMemberCardNo.Size = new System.Drawing.Size(100, 21);
            this.txtCMemberCardNo.TabIndex = 1;
            // 
            // ultraLabel11
            // 
            this.ultraLabel11.Location = new System.Drawing.Point(16, 40);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel11.TabIndex = 0;
            this.ultraLabel11.Text = "会员卡号：";
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.btnCancelBooking);
            this.ultraTabPageControl4.Controls.Add(this.ultraGroupBox1);
            this.ultraTabPageControl4.Controls.Add(this.ultraGrid1);
            this.ultraTabPageControl4.Controls.Add(this.btnBooking);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(260, 350);
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnCancelBooking.Location = new System.Drawing.Point(144, 320);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(72, 23);
            this.btnCancelBooking.TabIndex = 17;
            this.btnCancelBooking.Text = "取消预订";
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.btnCancel);
            this.ultraGroupBox1.Controls.Add(this.btnQuery);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel6);
            this.ultraGroupBox1.Controls.Add(this.txtPaperNo);
            this.ultraGroupBox1.Controls.Add(this.txtMemberName);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox1.Controls.Add(this.txtMemberCardNo);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox1.Location = new System.Drawing.Point(16, 16);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(232, 112);
            this.ultraGroupBox1.TabIndex = 16;
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnCancel.Location = new System.Drawing.Point(128, 80);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "清除";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnQuery.Location = new System.Drawing.Point(24, 80);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(80, 23);
            this.btnQuery.TabIndex = 11;
            this.btnQuery.Text = "查找";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(8, 56);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(80, 23);
            this.ultraLabel6.TabIndex = 4;
            this.ultraLabel6.Text = "工商注册号：";
            // 
            // txtPaperNo
            // 
            this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPaperNo.Location = new System.Drawing.Point(120, 56);
            this.txtPaperNo.Name = "txtPaperNo";
            this.txtPaperNo.Size = new System.Drawing.Size(104, 21);
            this.txtPaperNo.TabIndex = 5;
            // 
            // txtMemberName
            // 
            this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberName.Location = new System.Drawing.Point(120, 32);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtMemberName.TabIndex = 3;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(16, 32);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel5.TabIndex = 2;
            this.ultraLabel5.Text = "单位名称：";
            // 
            // txtMemberCardNo
            // 
            this.txtMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberCardNo.Location = new System.Drawing.Point(120, 8);
            this.txtMemberCardNo.MaxLength = 8;
            this.txtMemberCardNo.Name = "txtMemberCardNo";
            this.txtMemberCardNo.Size = new System.Drawing.Size(100, 21);
            this.txtMemberCardNo.TabIndex = 1;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(16, 8);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel4.TabIndex = 0;
            this.ultraLabel4.Text = "会员卡号：";
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Location = new System.Drawing.Point(16, 128);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(232, 184);
            this.ultraGrid1.TabIndex = 15;
            this.ultraGrid1.Text = "会员信息";
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            this.ultraGrid1.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.ultraGrid1_AfterSelectChange);
            // 
            // btnBooking
            // 
            this.btnBooking.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnBooking.Location = new System.Drawing.Point(56, 320);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Size = new System.Drawing.Size(72, 23);
            this.btnBooking.TabIndex = 7;
            this.btnBooking.Text = "预订";
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
            // 
            // ultraTabPageControl5
            // 
            this.ultraTabPageControl5.Controls.Add(this.btnCancelNoMemberBooking);
            this.ultraTabPageControl5.Controls.Add(this.ultraGroupBox3);
            this.ultraTabPageControl5.Controls.Add(this.ultraGrid2);
            this.ultraTabPageControl5.Controls.Add(this.btnNoMemberBooking);
            this.ultraTabPageControl5.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl5.Name = "ultraTabPageControl5";
            this.ultraTabPageControl5.Size = new System.Drawing.Size(260, 350);
            // 
            // btnCancelNoMemberBooking
            // 
            this.btnCancelNoMemberBooking.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnCancelNoMemberBooking.Location = new System.Drawing.Point(144, 320);
            this.btnCancelNoMemberBooking.Name = "btnCancelNoMemberBooking";
            this.btnCancelNoMemberBooking.Size = new System.Drawing.Size(72, 23);
            this.btnCancelNoMemberBooking.TabIndex = 22;
            this.btnCancelNoMemberBooking.Text = "取消预订";
            this.btnCancelNoMemberBooking.Click += new System.EventHandler(this.btnCancelNoMemberBooking_Click);
            // 
            // ultraGroupBox3
            // 
            this.ultraGroupBox3.Controls.Add(this.btnFCancel);
            this.ultraGroupBox3.Controls.Add(this.cmbEndDate);
            this.ultraGroupBox3.Controls.Add(this.chkEndDate);
            this.ultraGroupBox3.Controls.Add(this.cmdBeginDate);
            this.ultraGroupBox3.Controls.Add(this.chkBeginDate);
            this.ultraGroupBox3.Controls.Add(this.btnQueryFMember);
            this.ultraGroupBox3.Controls.Add(this.txtFMemberName);
            this.ultraGroupBox3.Controls.Add(this.ultraLabel12);
            this.ultraGroupBox3.Controls.Add(this.txtFPaperNo);
            this.ultraGroupBox3.Controls.Add(this.ultraLabel9);
            this.ultraGroupBox3.Location = new System.Drawing.Point(16, 8);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(240, 136);
            this.ultraGroupBox3.TabIndex = 21;
            // 
            // btnFCancel
            // 
            this.btnFCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnFCancel.Location = new System.Drawing.Point(128, 104);
            this.btnFCancel.Name = "btnFCancel";
            this.btnFCancel.Size = new System.Drawing.Size(72, 23);
            this.btnFCancel.TabIndex = 24;
            this.btnFCancel.Text = "清除";
            this.btnFCancel.Click += new System.EventHandler(this.btnFCancel_Click);
            // 
            // cmbEndDate
            // 
            this.cmbEndDate.DateTime = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
            this.cmbEndDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbEndDate.Location = new System.Drawing.Point(80, 80);
            this.cmbEndDate.MaskInput = "{date} {time}";
            this.cmbEndDate.Name = "cmbEndDate";
            this.cmbEndDate.Size = new System.Drawing.Size(144, 21);
            this.cmbEndDate.TabIndex = 21;
            this.cmbEndDate.Value = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
            // 
            // chkEndDate
            // 
            this.chkEndDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.chkEndDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkEndDate.Location = new System.Drawing.Point(8, 80);
            this.chkEndDate.Name = "chkEndDate";
            this.chkEndDate.Size = new System.Drawing.Size(72, 20);
            this.chkEndDate.TabIndex = 23;
            this.chkEndDate.Text = "结束时间";
            // 
            // cmdBeginDate
            // 
            this.cmdBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmdBeginDate.Location = new System.Drawing.Point(80, 56);
            this.cmdBeginDate.MaskInput = "{date} {time}";
            this.cmdBeginDate.Name = "cmdBeginDate";
            this.cmdBeginDate.Size = new System.Drawing.Size(144, 21);
            this.cmdBeginDate.TabIndex = 20;
            // 
            // chkBeginDate
            // 
            this.chkBeginDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.chkBeginDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkBeginDate.Location = new System.Drawing.Point(8, 56);
            this.chkBeginDate.Name = "chkBeginDate";
            this.chkBeginDate.Size = new System.Drawing.Size(80, 20);
            this.chkBeginDate.TabIndex = 22;
            this.chkBeginDate.Text = "开始时间";
            // 
            // btnQueryFMember
            // 
            this.btnQueryFMember.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnQueryFMember.Location = new System.Drawing.Point(32, 104);
            this.btnQueryFMember.Name = "btnQueryFMember";
            this.btnQueryFMember.Size = new System.Drawing.Size(72, 23);
            this.btnQueryFMember.TabIndex = 12;
            this.btnQueryFMember.Text = "查找";
            this.btnQueryFMember.Click += new System.EventHandler(this.btnQueryFMember_Click);
            // 
            // txtFMemberName
            // 
            this.txtFMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtFMemberName.Location = new System.Drawing.Point(88, 8);
            this.txtFMemberName.Name = "txtFMemberName";
            this.txtFMemberName.Size = new System.Drawing.Size(136, 21);
            this.txtFMemberName.TabIndex = 16;
            // 
            // ultraLabel12
            // 
            this.ultraLabel12.Location = new System.Drawing.Point(16, 8);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel12.TabIndex = 15;
            this.ultraLabel12.Text = "单位名称：";
            // 
            // txtFPaperNo
            // 
            this.txtFPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtFPaperNo.Location = new System.Drawing.Point(88, 32);
            this.txtFPaperNo.Name = "txtFPaperNo";
            this.txtFPaperNo.Size = new System.Drawing.Size(136, 21);
            this.txtFPaperNo.TabIndex = 18;
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.Location = new System.Drawing.Point(8, 32);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(80, 23);
            this.ultraLabel9.TabIndex = 17;
            this.ultraLabel9.Text = "工商注册号：";
            // 
            // ultraGrid2
            // 
            this.ultraGrid2.Location = new System.Drawing.Point(16, 144);
            this.ultraGrid2.Name = "ultraGrid2";
            this.ultraGrid2.Size = new System.Drawing.Size(240, 168);
            this.ultraGrid2.TabIndex = 20;
            this.ultraGrid2.Text = "非会员信息";
            this.ultraGrid2.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid2_InitializeLayout);
            this.ultraGrid2.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.ultraGrid2_AfterSelectChange);
            // 
            // btnNoMemberBooking
            // 
            this.btnNoMemberBooking.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnNoMemberBooking.Location = new System.Drawing.Point(56, 320);
            this.btnNoMemberBooking.Name = "btnNoMemberBooking";
            this.btnNoMemberBooking.Size = new System.Drawing.Size(72, 23);
            this.btnNoMemberBooking.TabIndex = 19;
            this.btnNoMemberBooking.Text = "预订";
            this.btnNoMemberBooking.Click += new System.EventHandler(this.btnNoMemberBooking_Click);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(280, 498);
            // 
            // txtSeat
            // 
            this.txtSeat.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtSeat.Enabled = false;
            this.txtSeat.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSeat.Location = new System.Drawing.Point(8, 16);
            this.txtSeat.Name = "txtSeat";
            this.txtSeat.Size = new System.Drawing.Size(64, 30);
            this.txtSeat.TabIndex = 8;
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraLabel7.Location = new System.Drawing.Point(736, 0);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(280, 16);
            this.ultraLabel7.TabIndex = 12;
            this.ultraLabel7.Text = "红色-预订,蓝色-签到, 绿色-占位,紫色-充值";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.btnFlash);
            this.ultraGroupBox2.Controls.Add(this.ultraButton2);
            this.ultraGroupBox2.Controls.Add(this.ultraButton1);
            this.ultraGroupBox2.Controls.Add(this.txtSeat);
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.ultraGroupBox2.HeaderAppearance = appearance1;
            this.ultraGroupBox2.Location = new System.Drawing.Point(744, 144);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(264, 56);
            this.ultraGroupBox2.TabIndex = 10;
            this.ultraGroupBox2.Text = "选定的座位";
            // 
            // btnFlash
            // 
            this.btnFlash.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnFlash.Location = new System.Drawing.Point(200, 24);
            this.btnFlash.Name = "btnFlash";
            this.btnFlash.Size = new System.Drawing.Size(56, 23);
            this.btnFlash.TabIndex = 15;
            this.btnFlash.Text = "刷新";
            this.btnFlash.Click += new System.EventHandler(this.btnFlash_Click);
            // 
            // ultraButton2
            // 
            this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton2.Location = new System.Drawing.Point(136, 24);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(64, 23);
            this.ultraButton2.TabIndex = 14;
            this.ultraButton2.Text = "取消预订";
            this.ultraButton2.Click += new System.EventHandler(this.btnSeatCancelBook_Click);
            // 
            // ultraButton1
            // 
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton1.Location = new System.Drawing.Point(80, 24);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(56, 23);
            this.ultraButton1.TabIndex = 13;
            this.ultraButton1.Text = "占位";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl3);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl4);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl5);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControl1.Location = new System.Drawing.Point(736, 240);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(264, 376);
            this.ultraTabControl1.TabIndex = 13;
            ultraTab1.Key = "seat";
            ultraTab1.TabPage = this.ultraTabPageControl3;
            ultraTab1.Text = "导入座位";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "会员刷卡预订";
            ultraTab3.Key = "MemberBooking";
            ultraTab3.TabPage = this.ultraTabPageControl4;
            ultraTab3.Text = "会员预订";
            ultraTab4.Key = "NoMemberBooking";
            ultraTab4.TabPage = this.ultraTabPageControl5;
            ultraTab4.Text = "非会员预订";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2,
            ultraTab3,
            ultraTab4});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(260, 350);
            // 
            // ultraGroupBox5
            // 
            this.ultraGroupBox5.Controls.Add(this.lblFree);
            this.ultraGroupBox5.Controls.Add(this.ultraLabel17);
            this.ultraGroupBox5.Controls.Add(this.lblMemberName);
            this.ultraGroupBox5.Controls.Add(this.lblPaperNo);
            this.ultraGroupBox5.Controls.Add(this.lblMemberCardNo);
            this.ultraGroupBox5.Controls.Add(this.ultraLabel16);
            this.ultraGroupBox5.Controls.Add(this.ultraLabel15);
            this.ultraGroupBox5.Controls.Add(this.ultraLabel14);
            appearance6.FontData.BoldAsString = "True";
            this.ultraGroupBox5.HeaderAppearance = appearance6;
            this.ultraGroupBox5.Location = new System.Drawing.Point(744, 16);
            this.ultraGroupBox5.Name = "ultraGroupBox5";
            this.ultraGroupBox5.Size = new System.Drawing.Size(264, 128);
            this.ultraGroupBox5.TabIndex = 14;
            // 
            // lblMemberName
            // 
            this.lblMemberName.Location = new System.Drawing.Point(96, 64);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(160, 32);
            this.lblMemberName.TabIndex = 6;
            // 
            // lblPaperNo
            // 
            this.lblPaperNo.Location = new System.Drawing.Point(96, 40);
            this.lblPaperNo.Name = "lblPaperNo";
            this.lblPaperNo.Size = new System.Drawing.Size(160, 16);
            this.lblPaperNo.TabIndex = 5;
            // 
            // lblMemberCardNo
            // 
            this.lblMemberCardNo.Location = new System.Drawing.Point(96, 16);
            this.lblMemberCardNo.Name = "lblMemberCardNo";
            this.lblMemberCardNo.Size = new System.Drawing.Size(160, 16);
            this.lblMemberCardNo.TabIndex = 4;
            // 
            // ultraLabel16
            // 
            appearance3.TextHAlignAsString = "Right";
            this.ultraLabel16.Appearance = appearance3;
            this.ultraLabel16.Location = new System.Drawing.Point(8, 64);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(80, 16);
            this.ultraLabel16.TabIndex = 2;
            this.ultraLabel16.Text = "单位名称：";
            // 
            // ultraLabel15
            // 
            appearance4.TextHAlignAsString = "Right";
            this.ultraLabel15.Appearance = appearance4;
            this.ultraLabel15.Location = new System.Drawing.Point(8, 40);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(80, 16);
            this.ultraLabel15.TabIndex = 1;
            this.ultraLabel15.Text = "工商注册号：";
            // 
            // ultraLabel14
            // 
            appearance5.TextHAlignAsString = "Right";
            this.ultraLabel14.Appearance = appearance5;
            this.ultraLabel14.Location = new System.Drawing.Point(8, 16);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(80, 16);
            this.ultraLabel14.TabIndex = 0;
            this.ultraLabel14.Text = "会员卡号：";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(16, 8);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 16;
            this.ultraLabel3.Text = "信息提交方式：";
            // 
            // cmbInfoWay
            // 
            this.cmbInfoWay.Location = new System.Drawing.Point(128, 8);
            this.cmbInfoWay.Name = "cmbInfoWay";
            this.cmbInfoWay.Size = new System.Drawing.Size(104, 21);
            this.cmbInfoWay.TabIndex = 17;
            // 
            // ultraGroupBox6
            // 
            this.ultraGroupBox6.Controls.Add(this.cmbInfoWay);
            this.ultraGroupBox6.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox6.Location = new System.Drawing.Point(744, 200);
            this.ultraGroupBox6.Name = "ultraGroupBox6";
            this.ultraGroupBox6.Size = new System.Drawing.Size(256, 40);
            this.ultraGroupBox6.TabIndex = 15;
            // 
            // lblFree
            // 
            this.lblFree.Location = new System.Drawing.Point(96, 106);
            this.lblFree.Name = "lblFree";
            this.lblFree.Size = new System.Drawing.Size(160, 16);
            this.lblFree.TabIndex = 9;
            // 
            // ultraLabel17
            // 
            appearance2.TextHAlignAsString = "Right";
            this.ultraLabel17.Appearance = appearance2;
            this.ultraLabel17.Location = new System.Drawing.Point(8, 106);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(80, 16);
            this.ultraLabel17.TabIndex = 8;
            this.ultraLabel17.Text = "余额：";
            // 
            // ShowBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1028, 637);
            this.Controls.Add(this.ultraGroupBox6);
            this.Controls.Add(this.ultraGroupBox5);
            this.Controls.Add(this.ultraTabControl1);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.ultraGroupBox2);
            this.Name = "ShowBooking";
            this.Text = Login.constApp.strCardTypeL6Name + "展位预订";
            this.Load += new System.EventHandler(this.ShowBooking_Load);
            this.ultraTabPageControl3.ResumeLayout(false);
            this.ultraTabPageControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFloors)).EndInit();
            this.ultraTabPageControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).EndInit();
            this.ultraGroupBox4.ResumeLayout(false);
            this.ultraGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCMemberCardNo)).EndInit();
            this.ultraTabPageControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.ultraTabPageControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            this.ultraGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdBeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).EndInit();
            this.ultraGroupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbInfoWay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox6)).EndInit();
            this.ultraGroupBox6.ResumeLayout(false);
            this.ultraGroupBox6.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void ShowBooking_Load(object sender, System.EventArgs e)
		{
			//Helper.BindJob(cmbJob);	
			string strSql = "select * from tbJob where cndBookBeginDate <=getdate() and cndBookEndDate>=getdate() order by cndBeginDate";
			//			string strSql = "select * from tbJob  order by cndBeginDate";
            if (Login.constApp.strJobBookingBeginDate != "")
            {
                strSql = "select * from tbJob where convert(varchar(10),cndBookBeginDate,121)>='" + Login.constApp.strJobBookingBeginDate + "'";
                if (Login.constApp.strJobBookingEndDate != "")
                    strSql += " and convert(varchar(10),cndBookEndDate,121)<='" + Login.constApp.strJobBookingEndDate + "'";
                strSql += " order by cndBeginDate";
            }
            else
            {
                if (Login.constApp.strJobBookingEndDate != "")
                {
                    strSql = "select * from tbJob where convert(varchar(10),cndBookEndDate,121)<='" + Login.constApp.strJobBookingEndDate + "'";
                    strSql += " order by cndBeginDate";
                }
            }
			//JobManage jobManage = new JobManage();
			DataTable dtJob = Helper.Query(strSql);//jobManage.GetAllJob();
			cmbJob.DataSource = dtJob;
			cmbJob.ValueMember = "cnnID";
			cmbJob.DisplayMember = "cnvcJobName";
			cmbJob.DataBind();

			Helper.BindInfoWay(cmbInfoWay);
			this.cmbFloors.Items.Clear();
			//cmbInfoWay.SelectedIndex = 0;
            //if (ClientHelper.idept.cnnDeptID != 0)
            //{
            //    if(!Login.constApp.alOperFunc.Contains("批量取消预订"))
            //    {
            //        this.btnBatchCancelBook.Visible = false;
            //    }				
            //}	
			chkBeginDate.Checked=true;
			chkEndDate.Checked=true;
			cmdBeginDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEndDate.MaskInput = "yyyy-mm-dd hh:mm";

			cmbEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 23:59";

		}
		#region 展位
		private void LoadSeat(Panel pl,string strFloor,string strJobID)
		{
			string strSql = "select a.*,c.cnvcMemberCardNo,c.cnnPrepay from tbShowSeat a"
				+" left outer join tbMemberSeat b on a.cnnJobID=b.cnnID and a.cnvcSeat=b.cnvcSeat and a.cnvcFloor=b.cnvcFloor and (b.cnvcState='预订' or b.cnvcState='签到')"
				+" left outer join tbMember c on b.cnvcMemberCardNo=c.cnvcMemberCardNo"
				+" where a.cnvcFloor='"+strFloor+"' and a.cnnJobID="+strJobID;
			//string strSql = "select * from tbShowSeat where cnvcFloor='"+strFloor+"' and cnnJobID="+strJobID;
//			string strSql = "select a.*, "
//				           +" case when b.cnvcMemberCardNo is not null then c.cnvcMemberCardNo when b.cnvcMemberCardNo is null then '' end cnvcMemberCardNo, "
//				           +" case when b.cnvcMemberCardNo is not null then c.cnvcPaperNo when b.cnvcMemberCardNo is null then d.cnvcPaperNo end cnvcPaperNo, "
//						   +" case when b.cnvcMemberCardNo is not null then c.cnvcFree when b.cnvcMemberCardNo is null then '' end cnvcFree,"
//						   +" case when b.cnvcMemberCardNo is not null then c.cnvcMemberName when b.cnvcMemberCardNo is null then d.cnvcMemberName end cnvcMemberName "
//				           +" from tbShowSeat a "
//						   +" left outer join tbMemberSeat b on a.cnnJobID=b.cnnID "
//						   +" and a.cnvcSeat=b.cnvcSeat and a.cnvcFloor=b.cnvcFloor "
//						   +" left outer join tbMember c on b.cnvcMemberCardNo=c.cnvcMemberCardNo "
//						   +" left outer join tbFMember d on b.cnvcPaperNo=d.cnvcPaperNo "
//						   +" where a.cnvcFloor='"+strFloor+"' and a.cnnJobID="+strJobID;
			DataTable dtSeat = Helper.Query(strSql);
			foreach (DataRow drSeat in dtSeat.Rows)
			{
				

				Member member = null;
				ShowSeat seat = new ShowSeat(drSeat);
				zhhLabel lbl = new zhhLabel();
				lbl.Name = "lbl"+seat.cnvcControlName;
				lbl.Text = seat.cnvcControlName;//seat.cnvcSeat;

				if (seat.cnvcControlName.StartsWith("黑"))
				{
					lbl.BackColor = Color.Black;
				}
				if (seat.cnvcControlName.StartsWith("空"))
				{
					lbl.Text = "";
				}
//				if (seat.cnvcState.Length > 0)
//				{
//				
//					member = new Member(drSeat);
//					if (member.cnvcPaperNo.Length > 0)
//					{
//						this.toolTip1.SetToolTip(lbl,"【会员卡号】："+member.cnvcMemberCardNo+"\n【工商注册号】："+member.cnvcPaperNo+"\n【单位名称】："+member.cnvcMemberName+"\n【场次】："+member.cnvcFree);
//					}
//				}
				
				if (seat.cnvcState == ConstApp.Show_Seat_State_Booking)
				{
					lbl.BackColor = Color.Red;
					member = new Member(drSeat);
//					if (null != member)
//					{
//					if (member.cnvcMemberCardNo == "00400944")
//					{
//						string str = "";
//					}
					if (member.cnvcMemberCardNo.Length > 0)
					{
                        //if (member.cnvcFree != ConstApp.Free_Time_NoLimit)
                        //{
							
							//int iFree = int.Parse(member.cnvcFree);
							if (member.cnnPrepay <= Login.constApp.iTishi)
							{
								lbl.BackColor = Color.Purple;
								
							}
						//}
					}
					//}
				}
				else if (seat.cnvcState == ConstApp.Show_Seat_State_Remain)
				{
					lbl.BackColor = Color.Yellow;
				}
				else if (seat.cnvcState == ConstApp.Show_Seat_State_SignIn)
				{
					lbl.BackColor = Color.Blue;
				}
				else if (seat.cnvcState.Length > 0)//== this.oper.cnvcOperName)
				{
					lbl.BackColor = Color.Green;
				}
				
				
				Point p1 = new Point(seat.cnnX,seat.cnnY);
				lbl.Location = p1;
				lbl.Height = seat.cnnHeight;
				lbl.Width = seat.cnnWidth;
				lbl.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
				lbl.TextAlign = ContentAlignment.MiddleCenter;
				lbl.BorderStyle = BorderStyle.None;
				Helper.SetlblDirection(lbl,seat.cnvcDirection);
				if (Helper.IsNumber(seat.cnvcControlName))
				{
					lbl.Click +=new EventHandler(lbl_Click);
				}				
				pl.Controls.Add(lbl);
					
			}

		}
		private void JudgePanel()
		{
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl.Name.StartsWith("panel"))
				{
					this.Controls.Remove(ctrl);
					break;
					//throw new BusinessException("展厅","当前已有展厅");
				}
					
			}
		}
		private void LoadPanel()
		{
			//导入展位方案
            //try
            //{
				if (null == cmbJob.SelectedItem)
				{
					throw new BusinessException("展位方案","请选择招聘会");
				}
				if (null == cmbFloors.SelectedItem)
				{
					throw new BusinessException("展位方案","请选择展厅");
				}
				string strJobID = cmbJob.SelectedItem.DataValue.ToString();
				string strShowID = cmbFloors.SelectedItem.DataValue.ToString();
				if (null == ms)
				{
					ms = new MemberSeat();
				}
				ms.cnnID = int.Parse(strJobID);
				ms.cnvcJobName = cmbJob.Text;
				ms.cnvcFloor = strShowID;	
				ms.cnvcShowName = cmbFloors.Text;

				

				DataTable dtShow = Helper.Query("select * from tbShow where cnnShowID="+strShowID);
				if (dtShow.Rows.Count == 0)
				{
					throw new BusinessException("展位方案","未找到展厅展厅");
				}
				Show show = new Show(dtShow);
				JudgePanel();
				Panel pl = new Panel();
				pl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				pl.Location = new System.Drawing.Point(show.cnnX, show.cnnY);
				pl.Name = "panel"+show.cnvcShowName;
				pl.Size = new System.Drawing.Size(show.cnnWeight, show.cnnHeight);
				this.Controls.Add(pl);
				LoadSeat(pl,strShowID,strJobID);


            //}
            //catch (BusinessException bex)
            //{
            //    MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}

		}

		#endregion
		private void cmbShow_ValueChanged(object sender, System.EventArgs e)
		{
			//LoadLabel();
			if (cmbJob.SelectedItem != null)
			{
				string strJobID = cmbJob.SelectedItem.DataValue.ToString();
				Helper.BindShow(cmbFloors,strJobID);
			}
			
		}

		private void cmbFloor_ValueChanged(object sender, System.EventArgs e)
		{
			//LoadLabel();
		}

		private void btnLoadSeat_Click(object sender, System.EventArgs e)
		{
			LoadPanel();
			if (null != ms)
			{
				this.ultraGroupBox5.Text = ms.cnvcJobName+"●"+ms.cnvcShowName;
			}
			
		}

		private void lbl_Click(object sender, EventArgs e)
		{
			Control lCtrl =(sender as Control);
			txtSeat.Text = lCtrl.Text;
			txtSeat.Tag = lCtrl.Text;
			//显示单位信息
			DataTable dtMemberSeat = Helper.Query("select cnvcMemberCardNo,cnvcMemberName,cnvcPaperNo,cnvcState from tbMemberSeat where cnnID="+ms.cnnID.ToString()+" and cnvcSeat = '"+lCtrl.Text+"' and (cnvcState ='"+ConstApp.Show_Seat_State_SignIn+"' or cnvcState='"+ConstApp.Show_Seat_State_Booking+"')");
			Member member = new Member(dtMemberSeat);
            if (member.cnvcMemberCardNo != "")
            {
                DataTable dtMember = Helper.Query("select isnull(cnnPrepay,0) from tbMember where cnvcMemberCardNo = '" + member.cnvcMemberCardNo + "'");
                if (dtMember.Rows.Count > 0)
                {
                    member.cnnPrepay = Convert.ToDecimal(dtMember.Rows[0][0]);
                }

            }
            else
            {
                DataTable dtMember = Helper.Query("select isnull(cnnPrepay,0) from tbFMember where cnvcPaperNo = '" + member.cnvcPaperNo + "'");
                if (dtMember.Rows.Count > 0)
                {
                    member.cnnPrepay = Convert.ToDecimal(dtMember.Rows[0][0]);
                }
            }
			this.lblMemberCardNo.Text = member.cnvcMemberCardNo;
			this.lblMemberName.Text = member.cnvcMemberName;
			this.lblPaperNo.Text = member.cnvcPaperNo;
			this.lblFree.Text = member.cnnPrepay.ToString();

			ms.cnvcMemberCardNo = member.cnvcMemberCardNo;
			ms.cnvcMemberName = member.cnvcMemberName;
			ms.cnvcPaperNo = member.cnvcPaperNo;
			ms.cnvcState = member.cnvcState;
		
			ms.cnvcSeat = lCtrl.Text;
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//查找会员
			try
			{
				if (null == ms)
				{
					throw new BusinessException("查找会员","请选择招聘会及展厅");
				}
                string strSql = "select top 20 cnvcMemberCardNo,cnvcMemberName,cnvcPaperNo,cnvcMemberRight,cnvcFree,'' as cnvcBookSeat ,'' as cnvcJobName from tbMember where LEN(cnvcMemberCardNo)=6 and cnvcState = '" + ConstApp.Card_State_InUse + "'";
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
				DataTable dtMember = Helper.Query(strSql);

				if (dtMember.Rows.Count > 0)
				{
					foreach (DataRow drMember in dtMember.Rows)
					{
						Member member = new Member(drMember);
						string strSql2 = "select cnvcSeat,cnvcJobName  from tbMemberSeat where cnvcMemberCardNo = '"+member.cnvcMemberCardNo+"' and cnvcState='"+ConstApp.Show_Seat_State_Booking+"' and cnnID="+ms.cnnID.ToString();
						DataTable dtMemberSeat = Helper.Query(strSql2);
						string strRet = "";
						//string strRet1 = "";
						if (dtMemberSeat.Rows.Count > 0)
						{
							//strRet1 += drMemberSeat["cnvcJobname"].ToString();
							foreach (DataRow drMemberSeat in dtMemberSeat.Rows)
							{
								strRet += drMemberSeat["cnvcSeat"].ToString()+",";
								
							}
							drMember["cnvcBookSeat"] = strRet;
							drMember["cnvcJobName"] = ms.cnvcJobName;
						}
					}
				}
				this.ultraGrid1.DataSource = null;
				this.ultraGrid1.DataSource = dtMember;
				this.ultraGrid1.DataBind();				

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

		private void btnBooking_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (null == ms)
				{
					throw new BusinessException("展位预订","请选择招聘会及展厅");
				}
				if (ms.cnvcSeat == "")
				{
					throw new BusinessException("展位预订","请选择展位");
				}
				if(null == cmbInfoWay.SelectedItem)
				{
					throw new BusinessException("展位预订","请选择信息提交方式");
				}

				UltraGridRow selectedRow = this.ultraGrid1.ActiveRow;
				if (null == selectedRow)
				{
					throw new BusinessException("展位预订","请选择进行预订的会员");
				}
				string strMemberRight = selectedRow.Cells["cnvcMemberRight"].Value.ToString();
				MemberSeat seat = new MemberSeat();
				seat.cnnID = ms.cnnID;
				seat.cnvcJobName = ms.cnvcJobName;
				seat.cnvcMemberCardNo = selectedRow.Cells["cnvcMemberCardNo"].Value.ToString();//txtMemberCardNo.Text;
				seat.cnvcMemberName = selectedRow.Cells["cnvcMemberName"].Value.ToString();//txtMemberName.Text;
				seat.cnvcPaperNo = selectedRow.Cells["cnvcPaperNo"].Value.ToString();//txtPaperNo.Text;
				seat.cnvcOperName = this.oper.cnvcOperName;
				seat.cndOperDate = DateTime.Now;
				seat.cnvcAudit = ConstApp.IsNotAudit;
				seat.cnvcInfoWay = cmbInfoWay.Text;
				seat.cnvcShowName = ms.cnvcShowName;

				DataTable dtState1 = Helper.Query("select * from tbMember where cnvcMemberCardNo='" +seat.cnvcMemberCardNo+"'");
				DateTime dtMemberEndDate = DateTime.MinValue;
                bool bFeeType = false;
                Member tMember = null;
                JobManage jobManage = new JobManage();
                if (dtState1.Rows.Count > 0)
                {
                    tMember = new Member(dtState1);

                    if (!this.GetIsJob(tMember.cnvcMemberRight))
                    {
                        MessageBox.Show("此会员不能参加招聘会");
                        return;
                    }
                    bFeeType = this.GetIsFeeType(tMember.cnvcMemberRight);
                    if (this.GetIsDisabledDate(tMember.cnvcMemberRight))
                    {
                        dtMemberEndDate = DateTime.Parse(tMember.cndEndDate);
                        if (dtMemberEndDate < DateTime.Now)
                        {
                            throw new BusinessException("会员状态", "会员已经过期，请重新办理会员！");
                        }
                    }

                    DataTable dtJob = Helper.Query("select * from tbJob where cnnJobID=" + ms.cnnID.ToString());
                    if (dtJob.Rows.Count == 0) throw new BusinessException("会员预定", "未找到招聘会信息");
                    Job job = new Job(dtJob);
                    DataTable dtMC = Helper.Query("select * from tbMemberCode where cnvcMemberName='" + job.cnvcJobTheme + "' and cnvcMemberType='" + ConstApp.ProductPrice + "'");
                    if (dtMC.Rows.Count > 0)
                    {
                        MemberCode mc = new MemberCode(dtMC);
                        if (!bFeeType)
                        {
                            decimal dDiscount = jobManage.GetDiscount(job.cnvcJobTheme, tMember.cnvcMemberRight, tMember.cnvcDiscount);
                            int iCount = jobManage.GetBookCount(job.cnnJobID, tMember.cnvcMemberCardNo)+1;
                            if (tMember.cnnPrepay < Convert.ToDecimal(mc.cnvcMemberValue)*iCount*dDiscount/100)
                            {
                                DialogResult drBook = MessageBox.Show(this, "预存金额不足，是否继续预定？", "展位预订", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (drBook == DialogResult.No)
                                {
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (tMember.cnvcFree != ConstApp.Free_Time_NoLimit)
                            {
                                if (int.Parse(tMember.cnvcFree) < 1)
                                {
                                    if (this.GetIsInMoney(tMember.cnvcMemberRight))
                                    {
                                        DialogResult drBook = MessageBox.Show(this, "免费场次为0，是否继续预定？", "展位预订", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (drBook == DialogResult.No)
                                        {
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "场次已用完", "展位预定", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }

				DataTable dtSeats = Helper.Query("select cnvcState,cnvcSeat from tbMemberSeat where cnnID="+ms.cnnID.ToString()+" and cnvcMemberCardNo = '"+seat.cnvcMemberCardNo+"' and (cnvcState='"+ConstApp.Show_Seat_State_Booking+"' or cnvcState ='"+ConstApp.Show_Seat_State_SignIn+"')");
				if (dtSeats.Rows.Count > 0)
				{
					string strSeats = "";
					DataRow[] drBookSeat = dtSeats.Select("cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
					DataRow[] drSignInSeat = dtSeats.Select("cnvcState='"+ConstApp.Show_Seat_State_SignIn+"'");
					if (drBookSeat.Length > 0)
					{
						strSeats += "已预订展位：";
						foreach (DataRow drSeat in drBookSeat)
						{
							strSeats += drSeat["cnvcSeat"].ToString()+"，";
						}
					}
					if (drSignInSeat.Length > 0)
					{
						strSeats += "已签到展位：";
						foreach (DataRow drSeat in drSignInSeat)
						{
							strSeats += drSeat["cnvcSeat"].ToString()+"，";
						}
					}
					DialogResult drSeats = MessageBox.Show(this,strSeats+"是否要继续预订？","展位预订",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
					if (drSeats == DialogResult.No)
					{
						return;
					}
				}
				bool IsSignIn = false;
				string strMsg = "招聘会："+ms.cnvcJobName+"\r展位："+ms.cnvcSeat+"\r会员卡号："+seat.cnvcMemberCardNo+"\r单位名称："+seat.cnvcMemberName+"\r工商注册号："+seat.cnvcPaperNo;
				DialogResult ret = MessageBox.Show(this,strMsg,"展位预订信息确认",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if (ret == DialogResult.Yes)
				{
				
					seat.cnvcSeat = txtSeat.Text;
					seat.cnvcFloor = ms.cnvcFloor;
					seat.cnvcState = ConstApp.Show_Seat_State_Booking;//"预订";
                    seat.cniSynch = 3;
					
                    MemberManageFacade memberManage = new MemberManageFacade();				
					Job oldJob = new Job();
					oldJob.cnnJobID = seat.cnnID;
					Job job = jobManage.GetJobByID(oldJob);

                    //if (DateTime.MinValue != dtMemberEndDate)
                    //{
                    //    if (dtMemberEndDate < job.cndBeginDate)
                    //    {
                    //        DialogResult drBook = MessageBox.Show(this,"招聘会开始时会员已过期，是否继续预定？","展位预订",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                    //        if (drBook == DialogResult.No)
                    //        {
                    //            return;
                    //        }
                    //    }
                    //}
					
					//
					DateTime dtBookBeginDate = job.cndBookBeginDate;
					DateTime dtBookEndDate = job.cndBookEndDate;
					if (DateTime.Now > job.cndBeginDate)
					{
						IsSignIn = true;
					}

					if(Login.constApp.htBookDate.ContainsKey(strMemberRight))
					{
						int iBookDate = int.Parse(Login.constApp.htBookDate[strMemberRight].ToString());
						DateTime dtMemberBookBeginDate = job.cndBeginDate.AddDays(-iBookDate);
						if (DateTime.Now < dtMemberBookBeginDate)
						{
							DialogResult drBook = MessageBox.Show(this,"此会员未到展位预订时间，是否要继续预订？","展位预订",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
							if (drBook == DialogResult.No)
							{
								return;
							}
							//throw new BusinessException("展位预订","此会员未到展位预订时间");
						}

					}
					if (DateTime.Now > dtBookEndDate)
					{
						DialogResult drBook = MessageBox.Show(this,"已过展位预订时间，是否要继续预订？","展位预订",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
						if (drBook == DialogResult.No)
						{
							return;
						}
						//throw new BusinessException("展位预订","已过展位预订时间");
					}
                    
					PrintedBill pBookBill = new PrintedBill(seat.ToTable());
					pBookBill.cnvcBillType = "预订";
					pBookBill.cnvcPaperNo = seat.cnvcPaperNo;
					pBookBill.cnvcMemberName = seat.cnvcMemberName;
					pBookBill.cnvcMemberRight = strMemberRight;
					//Member retMember = jobManage.MemberSeatSignIn(memberSeat,pBill);
                    pBookBill.cnvcSynch = "客服预定";
					//pBill.cnvcSeat = "";//retMember.cnvcSales;
                    pBookBill.cnvcFreeLast = tMember.cnvcFree;
					pBookBill.cnvcShow = ms.cnvcShowName;//cmbFloor.Text;
					pBookBill.cnvcJobInfo = "请于"+job.cndBeginDate.ToString("yyyy-MM-dd")+" 上午 9:30以前到";
                    pBookBill.cnbFeeType = bFeeType;
					jobManage.MemberSeatBooking(seat,pBookBill);
					//Helper.PrintTicket(pBill);
					MessageBox.Show(this,"展位预订成功！","展位预订",MessageBoxButtons.OK,MessageBoxIcon.Information);
					
					if (IsSignIn)
					{
					

						DialogResult dr2= MessageBox.Show(this,"是否立即签到？","签到",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
						if (dr2 == DialogResult.Yes)
						{
							//签到
							MemberSeat memberSeat = new MemberSeat();
							memberSeat.cnnID = ms.cnnID;//int.Parse(cmbShow.SelectedItem.DataValue.ToString());
							memberSeat.cnvcJobName = ms.cnvcJobName;//cmbShow.SelectedItem.DisplayText;
							memberSeat.cnvcMemberCardNo = seat.cnvcMemberCardNo;//strMemberCardNo;
							memberSeat.cnvcOperName = this.oper.cnvcOperName;
							memberSeat.cndOperDate = DateTime.Now;
							memberSeat.cnvcPaperNo = seat.cnvcPaperNo;//strPaperNo;

							//JobManage jobManage = new JobManage();	
							PrintedBill pBill = new PrintedBill(memberSeat.ToTable());
							pBill.cnvcBillType = ConstApp.Bill_Type_SignIn;
							pBill.cnvcPaperNo = seat.cnvcPaperNo;
							pBill.cnvcMemberName = seat.cnvcMemberName;
							pBill.cnvcMemberRight = strMemberRight;
                            pBill.cnvcSynch = "客服预定";
                            pBill.cnbFeeType = bFeeType;
                            Bill bill = null;
							Member retMember = jobManage.MemberSeatSignIn(memberSeat,pBill,out bill);

                            pBill.cnnBalance = bill.cnnBalance;
                            pBill.cnnLastBalance = bill.cnnLastBalance;
                            pBill.cnnPrepay = bill.cnnPrepay;

							pBill.cnvcSeat = retMember.cnvcSales;
							pBill.cnvcFreeLast = retMember.cnvcFree;
							pBill.cnvcShow = ms.cnvcShowName;//cmbFloor.Text;
							Helper.PrintTicket(pBill);
							//pMember = new Member();
							//pMember.cnvcMemberCardNo = memberSeat.cnvcMemberCardNo;
							//pMember.cnvcPaperNo = seat.cnvcPaperNo;//strPaperNo;
							//pMember.cnvcMemberName = seat.cnvcMemberName;//strMemberName;					
							//						pMember.cnvcProduct = retMember.cnvcSales;
							//						pMember.cnvcFree = retMember.cnvcFree;
							//pMember.cnvcOperName = this.oper.cnvcOperName;					
							//this.ultraPrintDocument1.Print();
							//MessageBox.Show(this,"展位签到成功！","展位签到",MessageBoxButtons.OK,MessageBoxIcon.Information);
						}
						else
						{
							//预订打小票
							
							Helper.PrintTicket(pBookBill);
						}
					}
					else
					{
						//预订打小票						
						Helper.PrintTicket(pBookBill);
					}
					
					this.btnLoadSeat_Click(null,null);
					btnQuery_Click(null,null);
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
			this.cmbInfoWay.Text="";
			this.cmbInfoWay.SelectedIndex = -1;
			LoadPanel();
		}

		#region 查找非会员
		private void btnQueryFMember_Click(object sender, System.EventArgs e)
		{
			//查找非会员
			try
			{
				if (null == ms)
				{
					throw new BusinessException("查找会员","请选择招聘会及展厅");
				}
				string strSql = "select top 20 cnvcMemberName,cnvcPaperNo,'' as cnvcBookSeat,'' as cnvcJobName from tbFMember where 1=1 ";				
				if (txtFMemberName.Text.Trim().Length > 0)
				{
					strSql += " and cnvcMemberName like '%"+txtFMemberName.Text+"%'";
				}
				if (txtFPaperNo.Text.Trim().Length > 0)
				{
					strSql += " and cnvcPaperNo like '%"+txtFPaperNo.Text+"%'";
				}
				if (chkBeginDate.Checked)
				{
					strSql += " and cndInNetDate >='"+cmdBeginDate.Text+"'";
				}
				if (chkEndDate.Checked)
				{
					strSql += " and cndInNetDate <='"+cmbEndDate.Text+"'";
				}
                strSql += " order by cnnPrepay desc";
				DataTable dtMember = Helper.Query(strSql);

				if (dtMember.Rows.Count > 0)
				{
					foreach (DataRow drMember in dtMember.Rows)
					{
						FMember member = new FMember(drMember);
						string strSql2 = "select cnvcSeat,cnvcJobname  from tbMemberSeat where cnvcMemberName='"+member.cnvcMemberName+"' and cnvcMemberCardNo is null and cnvcPaperNo = '"+member.cnvcPaperNo+"' and cnvcState='"+ConstApp.Show_Seat_State_Booking+"' and cnnID="+ms.cnnID.ToString();
						DataTable dtMemberSeat = Helper.Query(strSql2);
						string strRet = "";
						//string strRet1 = "";
						if (dtMemberSeat.Rows.Count > 0)
						{
							//strRet1 += drMemberSeat["cnvcJobname"].ToString();
							foreach (DataRow drMemberSeat in dtMemberSeat.Rows)
							{
								strRet += drMemberSeat["cnvcSeat"].ToString()+",";
								
							}
							drMember["cnvcBookSeat"] = strRet;
							drMember["cnvcJobName"] = ms.cnvcJobName;
						}
					}
				}
				this.ultraGrid2.DataSource = null;
				this.ultraGrid2.DataSource = dtMember;
				this.ultraGrid2.DataBind();				

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
		#endregion

		private void btnNoMemberBooking_Click(object sender, System.EventArgs e)
		{
			//非会员展位预订
			try
			{
				if (null == ms)
				{
					throw new BusinessException("展位预订","请选择招聘会及展厅");
				}
				if (ms.cnvcSeat == "")
				{
					throw new BusinessException("展位预订","请选择展位");
				}			
				if(null == cmbInfoWay.SelectedItem)
				{
					throw new BusinessException("展位预订","请选择信息提交方式");
				}
				UltraGridRow selectedRow = this.ultraGrid2.ActiveRow;
				if (null == selectedRow)
				{
					throw new BusinessException("展位预订","请选择进行预订的非会员");
				}

				MemberSeat seat = new MemberSeat();
				seat.cnnID = ms.cnnID;//int.Parse(cmbShow.SelectedItem.DataValue.ToString());
				seat.cnvcJobName = ms.cnvcJobName;//cmbShow.SelectedItem.DisplayText;
				//seat.cnvcMemberCardNo = selectedRow.Cells["会员卡号"].Value.ToString();//txtMemberCardNo.Text;
				seat.cnvcMemberName = selectedRow.Cells["cnvcMemberName"].Value.ToString();//txtMemberName.Text;
				seat.cnvcPaperNo = selectedRow.Cells["cnvcPaperNo"].Value.ToString();//txtPaperNo.Text;
				seat.cnvcOperName = this.oper.cnvcOperName;
				seat.cndOperDate = DateTime.Now;
				seat.cnvcInfoWay = cmbInfoWay.Text;
				seat.cnvcAudit = ConstApp.IsNotAudit;
				seat.cnvcShowName = ms.cnvcShowName;
				//非会员已预订展位提示
				DataTable dtSeats = Helper.Query("select cnvcState,cnvcSeat from tbMemberSeat where cnnID="+ms.cnnID.ToString()+" and cnvcMemberCardNo is null and cnvcMemberName = '"+seat.cnvcMemberName+"' and (cnvcState='"+ConstApp.Show_Seat_State_Booking+"' or cnvcState ='"+ConstApp.Show_Seat_State_SignIn+"')");
				if (dtSeats.Rows.Count > 0)
				{
					string strSeats = "";
					DataRow[] drBookSeat = dtSeats.Select("cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
					DataRow[] drSignInSeat = dtSeats.Select("cnvcState='"+ConstApp.Show_Seat_State_SignIn+"'");
					if (drBookSeat.Length > 0)
					{
						strSeats += "已预订展位：";
						foreach (DataRow drSeat in drBookSeat)
						{
							strSeats += drSeat["cnvcSeat"].ToString()+"，";
						}
					}
					if (drSignInSeat.Length > 0)
					{
						strSeats += "已签到展位：";
						foreach (DataRow drSeat in drSignInSeat)
						{
							strSeats += drSeat["cnvcSeat"].ToString()+"，";
						}
					}
					DialogResult drSeats = MessageBox.Show(this,strSeats+"是否要继续预订？","展位预订",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
					if (drSeats == DialogResult.No)
					{
						return;
					}
				}
				bool IsSignIn = false;
				string strMsg = "招聘会："+seat.cnvcJobName+"\r展位："+ms.cnvcSeat+"\r单位名称："+seat.cnvcMemberName+"\r工商注册号："+seat.cnvcPaperNo;
				DialogResult ret = MessageBox.Show(this,strMsg,"展位预订信息确认",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if (ret == DialogResult.Yes)
				{
				
					seat.cnvcSeat = txtSeat.Text;
					seat.cnvcFloor = ms.cnvcFloor;//cmbFloor.SelectedItem.DataValue.ToString();
					seat.cnvcState = ConstApp.Show_Seat_State_Booking;//"预订";
					JobManage jobManage = new JobManage();
                    MemberManageFacade memberManage = new MemberManageFacade();

				
					Job oldJob = new Job();
					oldJob.cnnJobID = seat.cnnID;
					Job job = jobManage.GetJobByID(oldJob);
					//
					DateTime dtBookBeginDate = job.cndBookBeginDate;
					DateTime dtBookEndDate = job.cndBookEndDate;
					if (DateTime.Now > job.cndBeginDate)
					{
						IsSignIn = true;
					}
					
					if (DateTime.Now < dtBookBeginDate)
					{
						throw new BusinessException("展位预订","未到展位预订时间");
					}
					if (DateTime.Now > dtBookEndDate)
					{
						throw new BusinessException("展位预订","已过展位预订时间");
					}
					PrintedBill pBookBill = new PrintedBill(seat.ToTable());
					pBookBill.cnvcShow = ms.cnvcShowName;
					pBookBill.cnvcBillType = "预订";
					pBookBill.cnvcJobInfo = "请于"+job.cndBeginDate.ToString("yyyy-MM-dd")+" 上午 9:30以前到";
					jobManage.NoMemberSeatBooking(seat,pBookBill);
					MessageBox.Show(this,"展位预订成功！","展位预订",MessageBoxButtons.OK,MessageBoxIcon.Information);
				
					if (IsSignIn)
					{
					
						DialogResult dr2= MessageBox.Show(this,"是否立即签到？","签到",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
						if (dr2 == DialogResult.Yes)
						{
							//签到
							MemberSeat memberSeat = new MemberSeat();
							memberSeat.cnnID = ms.cnnID;//int.Parse(cmbShow.SelectedItem.DataValue.ToString());
							memberSeat.cnvcJobName = ms.cnvcJobName;//cmbShow.SelectedItem.DisplayText;
							memberSeat.cnvcPaperNo = seat.cnvcPaperNo;
							memberSeat.cnvcOperName = this.oper.cnvcOperName;
							memberSeat.cnvcMemberName=seat.cnvcMemberName;
							memberSeat.cndOperDate = DateTime.Now;
							//JobManage jobManage = new JobManage();
							PrintedBill pBill = new PrintedBill(memberSeat.ToTable());
							pBill.cnvcPaperNo = seat.cnvcPaperNo;
							pBill.cnvcMemberName = seat.cnvcMemberName;
							pBill.cnvcBillType = ConstApp.Bill_Type_SignIn;

                            Bill bill = null;
							string strSeat = jobManage.FMemberSeatSignIn(memberSeat,out bill);

                            pBill.cnnBalance = bill.cnnBalance;
                            pBill.cnnLastBalance = bill.cnnLastBalance;
                            pBill.cnnPrepay = bill.cnnPrepay;

							pBill.cnvcSeat = strSeat;
							pBill.cnvcShow = ms.cnvcShowName;//cmbFloor.Text;
							Helper.PrintTicket(pBill);
							//pMember = new Member();
							//pMember.cnvcMemberCardNo = "";//memberSeat.cnvcMemberCardNo;
							//pMember.cnvcPaperNo = seat.cnvcPaperNo;//strPaperNo;					
							//pMember.cnvcOperName = this.oper.cnvcOperName;
							//pMember.cnvcProduct = strSeat;
							//pMember.cnvcMemberName = seat.cnvcMemberName;//strMemberName;
							//pMember.cnvcOperName = memberSeat.cnvcOperName;
							//this.ultraPrintDocument1.Print();
							//MessageBox.Show(this,"展位签到成功！","展位签到",MessageBoxButtons.OK,MessageBoxIcon.Information);
						}
						else
						{
							Helper.PrintTicket(pBookBill);
						}
					}
					else
					{
						Helper.PrintTicket(pBookBill);
					}
                    this.cmbInfoWay.Text="";
					this.cmbInfoWay.SelectedIndex = -1;
					this.btnLoadSeat_Click(null,null);
					btnQueryFMember_Click(null,null);
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
			LoadPanel();
		}

		private void btnCancelBooking_Click(object sender, System.EventArgs e)
		{
			//会员取消预订
			try
			{
				if (null ==ms)
				{
					throw new BusinessException("展位预订","请选择招聘会及展厅");
				}
				if (ms.cnvcSeat == "")
				{
					throw new BusinessException("展位预订","请选择展位");
				}
				
				UltraGridRow selectedRow = this.ultraGrid1.ActiveRow;
				if (null == selectedRow)
				{
					throw new BusinessException("展位预订","请选择进行取消预订的会员");
				}

				MemberSeat seat = new MemberSeat();
				seat.cnnID = ms.cnnID;//int.Parse(cmbShow.SelectedItem.DataValue.ToString());
				seat.cnvcFloor = ms.cnvcFloor;//cmbFloor.SelectedItem.DataValue.ToString();
				seat.cnvcJobName = ms.cnvcJobName;//cmbShow.SelectedItem.DisplayText;
				seat.cnvcMemberCardNo = selectedRow.Cells["cnvcMemberCardNo"].Value.ToString();//txtMemberCardNo.Text;
				seat.cnvcMemberName = selectedRow.Cells["cnvcMemberName"].Value.ToString();//txtMemberName.Text;
				seat.cnvcPaperNo = selectedRow.Cells["cnvcPaperNo"].Value.ToString();//txtPaperNo.Text;
				seat.cnvcOperName = this.oper.cnvcOperName;
				seat.cndOperDate = DateTime.Now;
				//string strBookSeat = txtSeat.Text;//selectedRow.Cells["cnvcBookSeat"].Value.ToString();
				DataTable dtMemberSeat = Helper.Query("select * from tbMemberSeat where cnvcMemberCardNo='"+seat.cnvcMemberCardNo+"' and cnnID="+seat.cnnID+" and cnvcSeat='"+ms.cnvcSeat+"' and cnvcFloor='"+seat.cnvcFloor+"' and cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
				if (dtMemberSeat.Rows.Count == 0)
				{
					throw new BusinessException("会员取消预订","此会员未预订此展位！");
				}
				string strMsg = "招聘会："+seat.cnvcJobName+"\r展位："+ms.cnvcSeat+"\r会员卡号："+seat.cnvcMemberCardNo+"\r单位名称："+seat.cnvcMemberName+"\r工商注册号："+seat.cnvcPaperNo;
				DialogResult ret = MessageBox.Show(this,strMsg,"取消展位预订信息确认",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if (ret == DialogResult.Yes)
				{
				
					seat.cnvcSeat = ms.cnvcSeat;//strBookSeat;
					JobManage jobManage = new JobManage();
                    MemberManageFacade memberManage = new MemberManageFacade();
					jobManage.CancelMemberSeatBooking(seat);
					MessageBox.Show(this,"取消展位预订成功！","展位预订",MessageBoxButtons.OK,MessageBoxIcon.Information);
					this.cmbInfoWay.Text ="";
					this.btnLoadSeat_Click(null,null);
					this.btnQuery_Click(null,null);
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

		private void btnCancelNoMemberBooking_Click(object sender, System.EventArgs e)
		{
			//非会员取消预订
			try
			{
				if (null == ms)
				{
					throw new BusinessException("展位预订","请选择招聘会及展厅");
				}
				if (ms.cnvcSeat == "")
				{
					throw new BusinessException("展位预订","请选择展位");
				}				
				UltraGridRow selectedRow = this.ultraGrid2.ActiveRow;
				if (null == selectedRow)
				{
					throw new BusinessException("展位预订","请选择进行取消预订的非会员");
				}

				MemberSeat seat = new MemberSeat();
				seat.cnnID = ms.cnnID;//int.Parse(cmbShow.SelectedItem.DataValue.ToString());
				seat.cnvcJobName = ms.cnvcJobName;//cmbShow.SelectedItem.DisplayText;				
				seat.cnvcFloor = ms.cnvcFloor;//cmbFloor.SelectedItem.DataValue.ToString();
				seat.cnvcMemberName = selectedRow.Cells["cnvcMemberName"].Value.ToString();//txtMemberName.Text;
				seat.cnvcPaperNo = selectedRow.Cells["cnvcPaperNo"].Value.ToString();//txtPaperNo.Text;
				seat.cnvcOperName = this.oper.cnvcOperName;
				seat.cndOperDate = DateTime.Now;
				//string strBookSeat = txtSeat.Text;//selectedRow.Cells["已预订展位"].Value.ToString();
				DataTable dtMemberSeat = Helper.Query("select * from tbMemberSeat where cnvcPaperNo='"+seat.cnvcPaperNo+"' and cnnID="+seat.cnnID+" and cnvcSeat='"+ms.cnvcSeat+"' and cnvcFloor='"+seat.cnvcFloor+"' and cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
				if (dtMemberSeat.Rows.Count == 0)
				{
					throw new BusinessException("非会员取消预订","此非会员未预订此展位！");
				}
				string strMsg = "招聘会："+seat.cnvcJobName+"\r展位："+txtSeat.Text+"\r单位名称："+seat.cnvcMemberName+"\r工商注册号："+seat.cnvcPaperNo;
				DialogResult ret = MessageBox.Show(this,strMsg,"取消展位预订信息确认",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if (ret == DialogResult.Yes)
				{				
					seat.cnvcSeat = ms.cnvcSeat;//strBookSeat;
					JobManage jobManage = new JobManage();
                    MemberManageFacade memberManage = new MemberManageFacade();

				
					Job oldJob = new Job();
					jobManage.CancelNoMemberSeatBooking(seat);
					MessageBox.Show(this,"取消展位预订成功！","取消展位预订",MessageBoxButtons.OK,MessageBoxIcon.Information);
				    
					this.cmbInfoWay.Text="";
					this.btnLoadSeat_Click(null,null);						
					btnQueryFMember_Click(null,null);
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

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e);
			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "会员卡号";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Header.Caption = "会员资格";
			e.Layout.Bands[0].Columns["cnvcFree"].Header.Caption = "场次";
            e.Layout.Bands[0].Columns["cnvcFree"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcBookSeat"].Header.Caption = "已预订展位";
			e.Layout.Bands[0].Columns["cnvcJobName"].Header.Caption = "招聘会";

			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Width = 60;
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Width = 100;
			e.Layout.Bands[0].Columns["cnvcFree"].Width = 60;
		}

		private void ultraGrid1_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			UltraGridRow row = this.ultraGrid1.ActiveRow;
			if (row != null)
			{
				txtMemberCardNo.Text = row.Cells["cnvcMemberCardNo"].Value.ToString();
				txtMemberName.Text = row.Cells["cnvcMemberName"].Value.ToString();
				txtPaperNo.Text = row.Cells["cnvcPaperNo"].Value.ToString();
			}
		}

		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			//占位
			try
			{
				if (null == ms)
				{
					throw new BusinessException("展位预订","请选择招聘会及展厅");
				}
				if (ms.cnvcSeat == "")
				{
					throw new BusinessException("展位预订","请选择要占展位");
				}				

				ShowSeat seat = new ShowSeat();
				seat.cnvcSeat = ms.cnvcSeat;//txtSeat.Text;
				seat.cnnJobID = ms.cnnID;//int.Parse(cmbShow.SelectedItem.DataValue.ToString());
				seat.cnvcFloor = ms.cnvcFloor;//cmbFloor.SelectedItem.DataValue.ToString();
				seat.cnvcOperName = this.oper.cnvcOperName;
				seat.cndOperDate = DateTime.Now;

				DataTable dtSeat = Helper.Query("select * from tbShowSeat where cnnJobID="+seat.cnnJobID+" and cnvcState='"+seat.cnvcOperName+"'");
				if (dtSeat.Rows.Count > 0)
				{
					ShowSeat oldSeat = new ShowSeat(dtSeat);
					throw new BusinessException("展位预订","你已经占了一个位置，不能再占了。你占的位置是："+oldSeat.cnvcSeat);
				}
				JobManage jm = new JobManage();
				jm.HoldSeat(seat);
				MessageBox.Show(this, "占位成功", "展位预订",MessageBoxButtons.OK,MessageBoxIcon.Information);				
				//LoadPanel();
				this.btnLoadSeat_Click(null,null);

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

		private void ultraGrid2_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e);
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcBookSeat"].Header.Caption = "已预订展位";
			e.Layout.Bands[0].Columns["cnvcJobName"].Header.Caption = "招聘会";
		}

		private void ultraGrid2_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			UltraGridRow row = this.ultraGrid2.ActiveRow;
			if (row != null)
			{
				//txtMemberCardNo.Text = row.Cells["cnvcMemberCardNo"].Value.ToString();
				txtFMemberName.Text = row.Cells["cnvcMemberName"].Value.ToString();
				txtFPaperNo.Text = row.Cells["cnvcPaperNo"].Value.ToString();
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
//			e.Graphics.DrawString("展位：", drawFontBody, drawBrush, 35.0f, 115.0F, drawFormat);
//			e.Graphics.DrawString(pMember.cnvcProduct, drawFontBody, drawBrush, 115.0f, 115.0F, drawFormat);
//			e.Graphics.DrawString("免费场次剩余", drawFontBody, drawBrush, 35.0f, 130.0F, drawFormat);
//			e.Graphics.DrawString(pMember.cnvcFree, drawFontBody, drawBrush, 115.0f, 130.0F, drawFormat);
//			e.Graphics.DrawLine(new Pen(drawBrush,1.0f),0.0f,145.0f,300.0f,145.0f);
//			e.Graphics.DrawString("操作员：", drawFontBody, drawBrush, 35.0f, 145.0F, drawFormat);			
//			e.Graphics.DrawString(pMember.cnvcOperName, drawFontBody, drawBrush, 115.0f, 145.0F, drawFormat);
//			
//			
//			e.Graphics.DrawString("签到时间："+DateTime.Now.ToShortDateString()+"  "+DateTime.Now.ToShortTimeString(), drawFontBody, drawBrush, 35.0f, 160.0F, drawFormat);
//		}

		private void btnBrushCard_Click(object sender, System.EventArgs e)
		{
			//刷卡
			try
			{
				//读取会员卡号
				CardM1 m1=new CardM1();
				string strCardNo = "";
				string strRet = m1.ReadCard(out strCardNo);//,out dtemp,out itemp);

				if (strRet != ConstMsg.RFOK)
				{
					throw new BusinessException("卡操作失败","读取会员卡失败！");
				}
                if (strCardNo.Length > 6) throw new BusinessException("会员刷卡签到", "请放入一卡通");
				DataTable dtMember = Helper.Query("select * from tbMember where cnvcMemberCardNo = '"+strCardNo+"' and cnvcState = '"+ConstApp.Card_State_InUse+"'");
				if (dtMember.Rows.Count == 0)
				{
					throw new BusinessException("展位签到","未找到会员");
				}
                
                
				Member member = new Member(dtMember);
                if (!this.GetIsJob(member.cnvcMemberRight))
                {
                    MessageBox.Show("此会员不能参加招聘会");
                    return;
                }
                if (this.GetIsDisabledDate(member.cnvcMemberRight))
                {
                    DataTable dtState1 = Helper.Query("select * from tbMember where  cndEndDate < getDate() and cnvcMemberCardNo='" + strCardNo + "'");
                    if (dtState1.Rows.Count != 0)
                    {
                        throw new BusinessException("会员状态", "会员已经过期，请重新办理会员！");
                    }
                }
				txtCMemberName.Text = member.cnvcMemberName;
				txtCMemberName.Tag = member.cnvcMemberRight;
				txtCMemberCardNo.Text = member.cnvcMemberCardNo;
				txtCPaperNo.Text = member.cnvcPaperNo;
				//txtCFree.Text = member.cnvcFree;
				btnCardBook.Enabled = true;
				btnCancelCardBook.Enabled = true;
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

		private void btnCardBook_Click(object sender, System.EventArgs e)
		{
			//刷卡预订
			try
			{
				if (null == ms)
				{
					throw new BusinessException("展位预订","请选择招聘会及展厅");
				}
				if (ms.cnvcSeat == "")
				{
					throw new BusinessException("展位预订","请选择展位");
				}				
				if (txtCPaperNo.Text.Length == 0||txtCMemberCardNo.Text.Length == 0 || txtCMemberName.Text.Length == 0)
				{
					throw new BusinessException("展位预订","请刷卡");
				}
				if(null == cmbInfoWay.SelectedItem)
				{
					throw new BusinessException("展位预订","请选择信息提交方式");
				}
				string strMemberRight = txtCMemberName.Tag.ToString();//selectedRow.Cells["cnvcMemberRight"].Value.ToString();
				MemberSeat seat = new MemberSeat();
				seat.cnnID = ms.cnnID;//int.Parse(cmbShow.SelectedItem.DataValue.ToString());
				seat.cnvcJobName = ms.cnvcJobName;//cmbShow.SelectedItem.DisplayText;
				seat.cnvcFloor = ms.cnvcFloor;
				seat.cnvcShowName = ms.cnvcShowName;
				seat.cnvcMemberCardNo = txtCMemberCardNo.Text;//selectedRow.Cells["cnvcMemberCardNo"].Value.ToString();//txtMemberCardNo.Text;
				seat.cnvcMemberName = txtCMemberName.Text;//selectedRow.Cells["cnvcMemberName"].Value.ToString();//txtMemberName.Text;
				seat.cnvcPaperNo = txtCPaperNo.Text;//selectedRow.Cells["cnvcPaperNo"].Value.ToString();//txtPaperNo.Text;
				seat.cnvcOperName = this.oper.cnvcOperName;
				seat.cndOperDate = DateTime.Now;
				seat.cnvcInfoWay = cmbInfoWay.Text;
				seat.cnvcAudit = ConstApp.IsNotAudit;
				seat.cnvcShowName = ms.cnvcShowName;
				
				bool IsSignIn = false;
				string strMsg = "招聘会："+seat.cnvcJobName+"\r展位："+ms.cnvcSeat+"\r会员卡号："+seat.cnvcMemberCardNo+"\r单位名称："+seat.cnvcMemberName+"\r工商注册号："+seat.cnvcPaperNo;
				DialogResult ret = MessageBox.Show(this,strMsg,"展位预订信息确认",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if (ret == DialogResult.Yes)
				{
				
					seat.cnvcSeat = txtSeat.Text;
					seat.cnvcFloor = ms.cnvcFloor;//cmbFloor.SelectedItem.DataValue.ToString();
					seat.cnvcState = ConstApp.Show_Seat_State_Booking;//"预订";
					JobManage jobManage = new JobManage();
                    MemberManageFacade memberManage = new MemberManageFacade();				
					Job oldJob = new Job();
					oldJob.cnnJobID = seat.cnnID;
					Job job = jobManage.GetJobByID(oldJob);

					DateTime dtBookBeginDate = job.cndBookBeginDate;
					DateTime dtBookEndDate = job.cndBookEndDate;
                    bool bFeeType = false;
                    Member tMember = null;
					DataTable dtState1 = Helper.Query("select * from tbMember where cnvcMemberCardNo='" +seat.cnvcMemberCardNo+"'");
                    if (dtState1.Rows.Count > 0)
                    {
                        tMember = new Member(dtState1);
                        DateTime dtMemberEndDate = DateTime.MaxValue;
                        if (tMember.cndEndDate != "(none)" && !string.IsNullOrEmpty(tMember.cndEndDate))
                            dtMemberEndDate = DateTime.Parse(tMember.cndEndDate);
                        
                        if (dtMemberEndDate < job.cndBeginDate)
                        {
                            DialogResult drBook = MessageBox.Show(this, "招聘会开始时会员已过期，是否继续预定？", "展位预订", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (drBook == DialogResult.No)
                            {
                                return;
                            }
                        }
                        if (!this.GetIsJob(tMember.cnvcMemberRight))
                        {
                            MessageBox.Show("此会员不能参加招聘会");
                            return;
                        }
                        bFeeType = this.GetIsFeeType(tMember.cnvcMemberRight);
                        //DataTable dtJob = Helper.Query("select * from tbJob where cnnJobID=" + ms.cnnID.ToString());
                        //if (dtJob.Rows.Count == 0) throw new BusinessException("会员预定", "未找到招聘会信息");
                        //Job job2 = new Job(dtJob);
                        
                            DataTable dtMC = Helper.Query("select * from tbMemberCode where cnvcMemberName='" + job.cnvcJobTheme + "' and cnvcMemberType='" + ConstApp.ProductPrice + "'");
                            if (dtMC.Rows.Count > 0)
                            {
                                MemberCode mc = new MemberCode(dtMC);
                                if (!bFeeType)
                                {
                                    decimal dDiscount = jobManage.GetDiscount(job.cnvcJobTheme, tMember.cnvcMemberRight, tMember.cnvcDiscount);
                                    int iCount = jobManage.GetBookCount(job.cnnJobID, tMember.cnvcMemberCardNo)+1;
                                    if (tMember.cnnPrepay < Convert.ToDecimal(mc.cnvcMemberValue) *iCount* dDiscount / 100)
                                    {
                                        DialogResult drBook = MessageBox.Show(this, "预存金额不足，是否继续预定？", "展位预订", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (drBook == DialogResult.No)
                                        {
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    if (tMember.cnvcFree != ConstApp.Free_Time_NoLimit)
                                    {
                                        if (int.Parse(tMember.cnvcFree) < 1)
                                        {
                                            if (this.GetIsInMoney(tMember.cnvcMemberRight))
                                            {
                                                DialogResult drBook = MessageBox.Show(this, "免费场次为0，是否继续预定？", "展位预订", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                                if (drBook == DialogResult.No)
                                                {
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show(this,"场次已用完","展位预定",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                                return;
                                            }
                                        }
                                    }
                                }
                            }


                    }

					if (DateTime.Now > job.cndBeginDate)
					{
						IsSignIn = true;
					}

					if(Login.constApp.htBookDate.ContainsKey(strMemberRight))
					{
						int iBookDate = int.Parse(Login.constApp.htBookDate[strMemberRight].ToString());
						DateTime dtMemberBookBeginDate = job.cndBeginDate.AddDays(-iBookDate);
						if (DateTime.Now < dtMemberBookBeginDate)
						{
							DialogResult drBook = MessageBox.Show(this,"此会员未到展位预订时间，是否要继续预订？","展位预订",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
							if (drBook == DialogResult.No)
							{
								return;
							}
							//throw new BusinessException("展位预订","未到展位预订时间");
						}

					}
					if (DateTime.Now > dtBookEndDate)
					{
						DialogResult drBook = MessageBox.Show(this,"已过展位预订时间，是否要继续预订？","展位预订",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
						if (drBook == DialogResult.No)
						{
							return;
						}
						//throw new BusinessException("展位预订","已过展位预订时间");
					}
					PrintedBill pBookBill = new PrintedBill(seat.ToTable());
					pBookBill.cnvcShow = ms.cnvcShowName;
					pBookBill.cnvcJobInfo = "请于"+job.cndBeginDate.ToString("yyyy-MM-dd")+" 上午 9:30以前到";
					pBookBill.cnvcBillType = "预订";
                    pBookBill.cnvcSynch = "会员系统";
                    pBookBill.cnbFeeType = bFeeType;
                    pBookBill.cnvcFreeLast = tMember.cnvcFree;
					jobManage.MemberSeatBooking(seat,pBookBill);
					MessageBox.Show(this,"展位预订成功！","展位预订",MessageBoxButtons.OK,MessageBoxIcon.Information);
					

					if (IsSignIn)
					{
					
						DialogResult dr2= MessageBox.Show(this,"是否立即签到？","签到",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
						if (dr2 == DialogResult.Yes)
						{
							//签到
							MemberSeat memberSeat = new MemberSeat();
							memberSeat.cnnID = ms.cnnID;//int.Parse(cmbShow.SelectedItem.DataValue.ToString());
							memberSeat.cnvcJobName = ms.cnvcJobName;//cmbShow.SelectedItem.DisplayText;
							memberSeat.cnvcMemberCardNo = seat.cnvcMemberCardNo;//strMemberCardNo;
							memberSeat.cnvcOperName = this.oper.cnvcOperName;
							memberSeat.cndOperDate = DateTime.Now;
							memberSeat.cnvcPaperNo = seat.cnvcPaperNo;//strPaperNo;

							//JobManage jobManage = new JobManage();	
							PrintedBill pBill = new PrintedBill(memberSeat.ToTable());
							pBill.cnvcMemberName = seat.cnvcMemberName;
							pBill.cnvcBillType = ConstApp.Bill_Type_SignIn;
							pBill.cnvcMemberRight = strMemberRight;
                            pBill.cnvcSynch = "会员系统";
                            pBill.cnbFeeType = bFeeType;
							//pBill.cnvcFree = "";

                            Bill bill = null;
							Member retMember = jobManage.MemberSeatSignIn(memberSeat,pBill,out bill);
							pBill.cnvcFreeLast = retMember.cnvcFree;

                            pBill.cnnBalance = bill.cnnBalance;
                            pBill.cnnLastBalance = bill.cnnLastBalance;
                            pBill.cnnPrepay = bill.cnnPrepay;

							pBill.cnvcSeat = retMember.cnvcSales;
							pBill.cnvcShow = ms.cnvcShowName;//cmbFloor.Text;

							Helper.PrintTicket(pBill);
						
							//MessageBox.Show(this,"展位签到成功！","展位签到",MessageBoxButtons.OK,MessageBoxIcon.Information);
						}
						else
						{
							Helper.PrintTicket(pBookBill);
						}
					}
					else
					{
						Helper.PrintTicket(pBookBill);
					}
					this.cmbInfoWay.SelectedIndex = -1;
					cmbInfoWay.Text ="";
					txtCMemberCardNo.Text = "";
					txtCMemberName.Text = "";
					txtCPaperNo.Text = "";
					//txtCFree.Text = "";
					btnCardBook.Enabled = false;
					btnCancelCardBook.Enabled = false;
					btnBrushCard.Enabled = true;
					
					//btnQuery_Click(null,null);
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
			LoadPanel();
		}

		private void btnCancelCardBook_Click(object sender, System.EventArgs e)
		{
			//会员刷卡取消预订
			try
			{
				if (null == ms)
				{
					throw new BusinessException("展位预订","请选择招聘会及展厅");
				}
				if (ms.cnvcSeat == "")
				{
					throw new BusinessException("展位预订","请选择展位");
				}				
				if (txtCPaperNo.Text.Length == 0||txtCMemberCardNo.Text.Length == 0 || txtCMemberName.Text.Length == 0)
				{
					throw new BusinessException("展位预订","请刷卡");
				}
				//string strMemberRight = txtCMemberName.Tag.ToString();//selectedRow.Cells["cnvcMemberRight"].Value.ToString();


				MemberSeat seat = new MemberSeat();
				seat.cnnID = ms.cnnID;//int.Parse(cmbShow.SelectedItem.DataValue.ToString());
				seat.cnvcFloor = ms.cnvcFloor;//cmbFloor.SelectedItem.DataValue.ToString();
				seat.cnvcJobName = ms.cnvcJobName;//cmbShow.SelectedItem.DisplayText;
				seat.cnvcMemberCardNo = txtCMemberCardNo.Text;//selectedRow.Cells["cnvcMemberCardNo"].Value.ToString();//txtMemberCardNo.Text;
				seat.cnvcMemberName = txtCMemberName.Text;//selectedRow.Cells["cnvcMemberName"].Value.ToString();//txtMemberName.Text;
				seat.cnvcPaperNo = txtCPaperNo.Text;//selectedRow.Cells["cnvcPaperNo"].Value.ToString();//txtPaperNo.Text;
				seat.cnvcOperName = this.oper.cnvcOperName;
				seat.cndOperDate = DateTime.Now;
				//string strBookSeat = txtSeat.Text;//selectedRow.Cells["cnvcBookSeat"].Value.ToString();
				DataTable dtMemberSeat = Helper.Query("select * from tbMemberSeat where cnvcMemberCardNo='"+seat.cnvcMemberCardNo+"' and cnnID="+seat.cnnID+" and cnvcSeat='"+ms.cnvcSeat+"' and cnvcFloor='"+seat.cnvcFloor+"' and cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
				if (dtMemberSeat.Rows.Count == 0)
				{
					throw new BusinessException("会员取消预订","此会员未预订此展位！");
				}
				string strMsg = "招聘会："+seat.cnvcJobName+"\r展位："+ms.cnvcSeat+"\r会员卡号："+seat.cnvcMemberCardNo+"\r单位名称："+seat.cnvcMemberName+"\r工商注册号："+seat.cnvcPaperNo;
				DialogResult ret = MessageBox.Show(this,strMsg,"取消展位预订信息确认",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if (ret == DialogResult.Yes)
				{
				
					seat.cnvcSeat = ms.cnvcSeat;//strBookSeat;
					JobManage jobManage = new JobManage();
                    MemberManageFacade memberManage = new MemberManageFacade();
					jobManage.CancelMemberSeatBooking(seat);
					MessageBox.Show(this,"取消展位预订成功！","展位预订",MessageBoxButtons.OK,MessageBoxIcon.Information);
					this.cmbInfoWay.Text="";
					txtCMemberCardNo.Text = "";
					txtCMemberName.Text = "";
					txtCPaperNo.Text = "";
					//txtCFree.Text = "";
					btnCardBook.Enabled = false;
					btnCancelCardBook.Enabled = false;
					btnBrushCard.Enabled = true;
					LoadPanel();
					//this.btnQuery_Click(null,null);
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

		private void btnSeatCancelBook_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (null == ms)
				{
					throw new BusinessException("展位预订","请选择招聘会及展厅");
				}
				if (ms.cnvcSeat == "")
				{
					throw new BusinessException("展位预订","请选择展位");
				}
			
				MemberSeat seat = new MemberSeat();
				seat.cnnID = ms.cnnID;//int.Parse(cmbShow.SelectedItem.DataValue.ToString());
				seat.cnvcFloor = ms.cnvcFloor;//cmbFloor.SelectedItem.DataValue.ToString();
				seat.cnvcJobName = ms.cnvcJobName;//cmbShow.SelectedItem.DisplayText;
				//seat.cnvcMemberCardNo = txtCMemberCardNo.Text;//selectedRow.Cells["cnvcMemberCardNo"].Value.ToString();//txtMemberCardNo.Text;
				//seat.cnvcMemberName = txtCMemberName.Text;//selectedRow.Cells["cnvcMemberName"].Value.ToString();//txtMemberName.Text;
				//seat.cnvcPaperNo = txtCPaperNo.Text;//selectedRow.Cells["cnvcPaperNo"].Value.ToString();//txtPaperNo.Text;
				seat.cnvcOperName = this.oper.cnvcOperName;
				seat.cndOperDate = DateTime.Now;
				//string strBookSeat = txtSeat.Text;//selectedRow.Cells["cnvcBookSeat"].Value.ToString();
				DataTable dtMemberSeat = Helper.Query("select * from tbMemberSeat where cnnID="+seat.cnnID+" and cnvcSeat='"+ms.cnvcSeat+"' and cnvcFloor='"+seat.cnvcFloor+"' and cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
				if (dtMemberSeat.Rows.Count == 0)
				{
					throw new BusinessException("按座位取消预订","此展位未预订！");
				}
				string strMsg = "招聘会："+seat.cnvcJobName+"\r展位："+ms.cnvcSeat;
				DialogResult ret = MessageBox.Show(this,strMsg,"取消展位预订信息确认",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if (ret == DialogResult.Yes)
				{
				
					seat.cnvcSeat = ms.cnvcSeat;
					JobManage jobManage = new JobManage();
                    MemberManageFacade memberManage = new MemberManageFacade();
					jobManage.CancelSeatBooking(seat);
					MessageBox.Show(this,"取消展位预订成功！","展位预订",MessageBoxButtons.OK,MessageBoxIcon.Information);
					LoadPanel();
					//this.btnQuery_Click(null,null);
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

		private void btnBatchCancelBook_Click(object sender, System.EventArgs e)
		{
			try
			{
				
				
				if (null == ms)
				{
					throw new BusinessException("展位预订","请选择招聘会及展厅");
				}
				

				MemberSeat seat = new MemberSeat();
				seat.cnnID = ms.cnnID;//int.Parse(cmbShow.SelectedItem.DataValue.ToString());
				//seat.cnvcFloor = cmbFloor.SelectedItem.DataValue.ToString();
				//seat.cnvcJobName = cmbShow.SelectedItem.DisplayText;
				seat.cnvcOperName = this.oper.cnvcOperName;
				seat.cndOperDate = DateTime.Now;
				//string strBookSeat = txtSeat.Text;//selectedRow.Cells["cnvcBookSeat"].Value.ToString();
				
				DialogResult ret = MessageBox.Show(this,"是否批量取消展位预订？","取消展位预订信息确认",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if (ret == DialogResult.Yes)
				{
				
					//seat.cnvcSeat = strBookSeat;
					JobManage jobManage = new JobManage();
                    MemberManageFacade memberManage = new MemberManageFacade();
					jobManage.CancelSeatBooking(seat,"");
					MessageBox.Show(this,"批量取消展位预订成功！","展位预订",MessageBoxButtons.OK,MessageBoxIcon.Information);
					//LoadPanel();
					this.btnLoadSeat_Click(null,null);
					//this.btnQuery_Click(null,null);
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

		private void btnFlash_Click(object sender, System.EventArgs e)
		{
			btnLoadSeat_Click(null,null);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.txtMemberCardNo.Text = "";
			this.txtPaperNo.Text = "";
			this.txtMemberName.Text = "";
		}

		private void btnFCancel_Click(object sender, System.EventArgs e)
		{
			this.txtFMemberName.Text = "";
			this.txtFPaperNo.Text = "";
		}
	}
}
