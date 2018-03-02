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
using ynhrMemberManage.Common;
using ynhrMemberManage.BusinessFacade;

namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for MemberFileModify.
	/// </summary>
    public class MemberFileModify : frmBase
	{
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraButton btnQuery;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtHandleManPaperNo;
		private Infragistics.Win.Misc.UltraLabel ultraLabel22;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtHandleMan;
		private Infragistics.Win.Misc.UltraLabel ultraLabel21;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSales;
		private Infragistics.Win.Misc.UltraLabel ultraLabel20;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPostalcode;
		private Infragistics.Win.Misc.UltraLabel ultraLabel19;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMobileTelephone;
		private Infragistics.Win.Misc.UltraLabel ultraLabel18;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberPwd;
		private Infragistics.Win.Misc.UltraLabel ultraLabel16;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCorporation;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cmdEndDate;
		private Infragistics.Win.Misc.UltraLabel ultraLabel12;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbEnterpriseType;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCommnets;
		private Infragistics.Win.Misc.UltraLabel ultraLabel11;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtEmail;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtLinkPhone;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtLinkAddress;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel17;
		private Infragistics.Win.Misc.UltraLabel ultraLabel23;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtLinkman;
		private Infragistics.Win.Misc.UltraLabel ultraLabel24;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQPaperNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQMemberCardNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Infragistics.Win.Misc.UltraButton btnModify;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbTrade;
		private Infragistics.Win.Misc.UltraLabel ultraLabel8;
		private Infragistics.Win.Misc.UltraLabel ultraLabel10;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberPwdConfirm;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCustomerService;
		private Infragistics.Win.Misc.UltraLabel ultraLabel25;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEndDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmdBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtFax;
		private Infragistics.Win.Misc.UltraLabel ultraLabel26;
		public static bool IsShowing ;
		public MemberFileModify()
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
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmbEndDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.chkEndDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cmdBeginDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.chkBeginDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.btnQuery = new Infragistics.Win.Misc.UltraButton();
            this.txtQPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.txtQMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.txtQMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtFax = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.txtCustomerService = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMemberPwdConfirm = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbTrade = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.txtHandleManPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel22 = new Infragistics.Win.Misc.UltraLabel();
            this.txtHandleMan = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.txtSales = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.txtPostalcode = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMobileTelephone = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMemberPwd = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.txtCorporation = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.cmdEndDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbEnterpriseType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtCommnets = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.txtEmail = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.btnModify = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.txtLinkPhone = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtLinkAddress = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.txtPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel23 = new Infragistics.Win.Misc.UltraLabel();
            this.txtLinkman = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel24 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdBeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberPwdConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHandleManPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHandleMan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostalcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileTelephone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorporation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnterpriseType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommnets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Location = new System.Drawing.Point(8, 120);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(400, 464);
            this.ultraGrid1.TabIndex = 3;
            this.ultraGrid1.Text = "会员档案";
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            this.ultraGrid1.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.ultraGrid1_AfterSelectChange);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.cmbEndDate);
            this.ultraGroupBox1.Controls.Add(this.chkEndDate);
            this.ultraGroupBox1.Controls.Add(this.cmdBeginDate);
            this.ultraGroupBox1.Controls.Add(this.chkBeginDate);
            this.ultraGroupBox1.Controls.Add(this.btnQuery);
            this.ultraGroupBox1.Controls.Add(this.txtQPaperNo);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox1.Controls.Add(this.txtQMemberName);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox1.Controls.Add(this.txtQMemberCardNo);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(96, 16);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(840, 88);
            this.ultraGroupBox1.TabIndex = 2;
            this.ultraGroupBox1.Text = "会员档案查询";
            // 
            // cmbEndDate
            // 
            this.cmbEndDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbEndDate.Location = new System.Drawing.Point(384, 48);
            this.cmbEndDate.MaskInput = "{date} {time}";
            this.cmbEndDate.Name = "cmbEndDate";
            this.cmbEndDate.Size = new System.Drawing.Size(144, 21);
            this.cmbEndDate.TabIndex = 13;
            // 
            // chkEndDate
            // 
            this.chkEndDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.chkEndDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkEndDate.Location = new System.Drawing.Point(264, 48);
            this.chkEndDate.Name = "chkEndDate";
            this.chkEndDate.Size = new System.Drawing.Size(120, 20);
            this.chkEndDate.TabIndex = 15;
            this.chkEndDate.Text = "结束时间";
            // 
            // cmdBeginDate
            // 
            this.cmdBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmdBeginDate.Location = new System.Drawing.Point(384, 16);
            this.cmdBeginDate.MaskInput = "{date} {time}";
            this.cmdBeginDate.Name = "cmdBeginDate";
            this.cmdBeginDate.Size = new System.Drawing.Size(144, 21);
            this.cmdBeginDate.TabIndex = 12;
            // 
            // chkBeginDate
            // 
            this.chkBeginDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.chkBeginDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkBeginDate.Location = new System.Drawing.Point(264, 16);
            this.chkBeginDate.Name = "chkBeginDate";
            this.chkBeginDate.Size = new System.Drawing.Size(120, 20);
            this.chkBeginDate.TabIndex = 14;
            this.chkBeginDate.Text = "开始时间";
            // 
            // btnQuery
            // 
            this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnQuery.Location = new System.Drawing.Point(608, 48);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtQPaperNo
            // 
            this.txtQPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQPaperNo.Location = new System.Drawing.Point(152, 48);
            this.txtQPaperNo.Name = "txtQPaperNo";
            this.txtQPaperNo.Size = new System.Drawing.Size(100, 21);
            this.txtQPaperNo.TabIndex = 5;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(32, 48);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 4;
            this.ultraLabel3.Text = "工商注册号：";
            // 
            // txtQMemberName
            // 
            this.txtQMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQMemberName.Location = new System.Drawing.Point(672, 16);
            this.txtQMemberName.Name = "txtQMemberName";
            this.txtQMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtQMemberName.TabIndex = 3;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(552, 16);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 2;
            this.ultraLabel2.Text = "单位名称：";
            // 
            // txtQMemberCardNo
            // 
            this.txtQMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQMemberCardNo.Location = new System.Drawing.Point(152, 16);
            this.txtQMemberCardNo.Name = "txtQMemberCardNo";
            this.txtQMemberCardNo.Size = new System.Drawing.Size(100, 21);
            this.txtQMemberCardNo.TabIndex = 1;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(32, 16);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "会员卡号：";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.txtFax);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel26);
            this.ultraGroupBox2.Controls.Add(this.txtCustomerService);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel25);
            this.ultraGroupBox2.Controls.Add(this.txtMemberPwdConfirm);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel10);
            this.ultraGroupBox2.Controls.Add(this.cmbTrade);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel8);
            this.ultraGroupBox2.Controls.Add(this.txtHandleManPaperNo);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel22);
            this.ultraGroupBox2.Controls.Add(this.txtHandleMan);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel21);
            this.ultraGroupBox2.Controls.Add(this.txtSales);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel20);
            this.ultraGroupBox2.Controls.Add(this.txtPostalcode);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel19);
            this.ultraGroupBox2.Controls.Add(this.txtMobileTelephone);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel18);
            this.ultraGroupBox2.Controls.Add(this.txtMemberPwd);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel16);
            this.ultraGroupBox2.Controls.Add(this.txtCorporation);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel15);
            this.ultraGroupBox2.Controls.Add(this.cmdEndDate);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel12);
            this.ultraGroupBox2.Controls.Add(this.cmbEnterpriseType);
            this.ultraGroupBox2.Controls.Add(this.txtCommnets);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel11);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel9);
            this.ultraGroupBox2.Controls.Add(this.txtEmail);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel7);
            this.ultraGroupBox2.Controls.Add(this.btnCancel);
            this.ultraGroupBox2.Controls.Add(this.btnModify);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel6);
            this.ultraGroupBox2.Controls.Add(this.txtLinkPhone);
            this.ultraGroupBox2.Controls.Add(this.txtLinkAddress);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox2.Controls.Add(this.txtPaperNo);
            this.ultraGroupBox2.Controls.Add(this.txtMemberCardNo);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel17);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel23);
            this.ultraGroupBox2.Controls.Add(this.txtLinkman);
            this.ultraGroupBox2.Controls.Add(this.txtMemberName);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel24);
            this.ultraGroupBox2.Location = new System.Drawing.Point(416, 120);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(608, 464);
            this.ultraGroupBox2.TabIndex = 21;
            this.ultraGroupBox2.Text = "会员档案资料修改";
            // 
            // txtFax
            // 
            this.txtFax.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtFax.Location = new System.Drawing.Point(136, 224);
            this.txtFax.MaxLength = 20;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(152, 21);
            this.txtFax.TabIndex = 12;
            // 
            // ultraLabel26
            // 
            this.ultraLabel26.Location = new System.Drawing.Point(32, 224);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel26.TabIndex = 56;
            this.ultraLabel26.Text = "传真：";
            // 
            // txtCustomerService
            // 
            this.txtCustomerService.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtCustomerService.Location = new System.Drawing.Point(424, 320);
            this.txtCustomerService.MaxLength = 20;
            this.txtCustomerService.Name = "txtCustomerService";
            this.txtCustomerService.Size = new System.Drawing.Size(152, 21);
            this.txtCustomerService.TabIndex = 19;
            // 
            // ultraLabel25
            // 
            this.ultraLabel25.Location = new System.Drawing.Point(320, 320);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel25.TabIndex = 54;
            this.ultraLabel25.Text = "客服姓名：";
            // 
            // txtMemberPwdConfirm
            // 
            this.txtMemberPwdConfirm.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberPwdConfirm.Location = new System.Drawing.Point(424, 64);
            this.txtMemberPwdConfirm.MaxLength = 200;
            this.txtMemberPwdConfirm.Name = "txtMemberPwdConfirm";
            this.txtMemberPwdConfirm.Size = new System.Drawing.Size(152, 21);
            this.txtMemberPwdConfirm.TabIndex = 2;
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.Location = new System.Drawing.Point(320, 64);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel10.TabIndex = 51;
            this.ultraLabel10.Text = "会员密码确认：";
            // 
            // cmbTrade
            // 
            this.cmbTrade.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbTrade.Location = new System.Drawing.Point(136, 256);
            this.cmbTrade.Name = "cmbTrade";
            this.cmbTrade.Size = new System.Drawing.Size(152, 21);
            this.cmbTrade.TabIndex = 14;
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.Location = new System.Drawing.Point(32, 256);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel8.TabIndex = 49;
            this.ultraLabel8.Text = "行业：";
            // 
            // txtHandleManPaperNo
            // 
            this.txtHandleManPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtHandleManPaperNo.Location = new System.Drawing.Point(136, 320);
            this.txtHandleManPaperNo.MaxLength = 20;
            this.txtHandleManPaperNo.Name = "txtHandleManPaperNo";
            this.txtHandleManPaperNo.Size = new System.Drawing.Size(152, 21);
            this.txtHandleManPaperNo.TabIndex = 17;
            // 
            // ultraLabel22
            // 
            this.ultraLabel22.Location = new System.Drawing.Point(32, 320);
            this.ultraLabel22.Name = "ultraLabel22";
            this.ultraLabel22.Size = new System.Drawing.Size(104, 23);
            this.ultraLabel22.TabIndex = 45;
            this.ultraLabel22.Text = "经办人身份证号：";
            // 
            // txtHandleMan
            // 
            this.txtHandleMan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtHandleMan.Location = new System.Drawing.Point(136, 288);
            this.txtHandleMan.MaxLength = 20;
            this.txtHandleMan.Name = "txtHandleMan";
            this.txtHandleMan.Size = new System.Drawing.Size(152, 21);
            this.txtHandleMan.TabIndex = 16;
            // 
            // ultraLabel21
            // 
            this.ultraLabel21.Location = new System.Drawing.Point(32, 288);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel21.TabIndex = 43;
            this.ultraLabel21.Text = "经办人：";
            // 
            // txtSales
            // 
            this.txtSales.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtSales.Location = new System.Drawing.Point(424, 288);
            this.txtSales.MaxLength = 20;
            this.txtSales.Name = "txtSales";
            this.txtSales.Size = new System.Drawing.Size(152, 21);
            this.txtSales.TabIndex = 18;
            // 
            // ultraLabel20
            // 
            this.ultraLabel20.Location = new System.Drawing.Point(320, 288);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel20.TabIndex = 41;
            this.ultraLabel20.Text = "销售人员：";
            // 
            // txtPostalcode
            // 
            this.txtPostalcode.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPostalcode.Location = new System.Drawing.Point(424, 192);
            this.txtPostalcode.MaxLength = 20;
            this.txtPostalcode.Name = "txtPostalcode";
            this.txtPostalcode.Size = new System.Drawing.Size(152, 21);
            this.txtPostalcode.TabIndex = 11;
            // 
            // ultraLabel19
            // 
            this.ultraLabel19.Location = new System.Drawing.Point(320, 192);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel19.TabIndex = 39;
            this.ultraLabel19.Text = "邮政编码：";
            // 
            // txtMobileTelephone
            // 
            this.txtMobileTelephone.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMobileTelephone.Location = new System.Drawing.Point(136, 128);
            this.txtMobileTelephone.MaxLength = 20;
            this.txtMobileTelephone.Name = "txtMobileTelephone";
            this.txtMobileTelephone.Size = new System.Drawing.Size(152, 21);
            this.txtMobileTelephone.TabIndex = 6;
            // 
            // ultraLabel18
            // 
            this.ultraLabel18.Location = new System.Drawing.Point(32, 128);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel18.TabIndex = 37;
            this.ultraLabel18.Text = "手机号码：";
            // 
            // txtMemberPwd
            // 
            this.txtMemberPwd.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberPwd.Location = new System.Drawing.Point(424, 32);
            this.txtMemberPwd.MaxLength = 200;
            this.txtMemberPwd.Name = "txtMemberPwd";
            this.txtMemberPwd.Size = new System.Drawing.Size(152, 21);
            this.txtMemberPwd.TabIndex = 1;
            // 
            // ultraLabel16
            // 
            this.ultraLabel16.Location = new System.Drawing.Point(320, 32);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel16.TabIndex = 34;
            this.ultraLabel16.Text = "会员密码：";
            // 
            // txtCorporation
            // 
            this.txtCorporation.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtCorporation.Location = new System.Drawing.Point(136, 96);
            this.txtCorporation.MaxLength = 20;
            this.txtCorporation.Name = "txtCorporation";
            this.txtCorporation.Size = new System.Drawing.Size(152, 21);
            this.txtCorporation.TabIndex = 4;
            // 
            // ultraLabel15
            // 
            this.ultraLabel15.Location = new System.Drawing.Point(32, 96);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel15.TabIndex = 30;
            this.ultraLabel15.Text = "法人代表：";
            // 
            // cmdEndDate
            // 
            this.cmdEndDate.BackColor = System.Drawing.SystemColors.Window;
            this.cmdEndDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.cmdEndDate.Format = "yyyy-MM-dd";
            this.cmdEndDate.Location = new System.Drawing.Point(424, 256);
            this.cmdEndDate.Name = "cmdEndDate";
            this.cmdEndDate.NonAutoSizeHeight = 23;
            this.cmdEndDate.Size = new System.Drawing.Size(152, 21);
            this.cmdEndDate.TabIndex = 15;
            this.cmdEndDate.Value = new System.DateTime(2008, 1, 9, 0, 0, 0, 0);
            // 
            // ultraLabel12
            // 
            this.ultraLabel12.Location = new System.Drawing.Point(320, 256);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(104, 23);
            this.ultraLabel12.TabIndex = 26;
            this.ultraLabel12.Text = "卡使用时限：";
            // 
            // cmbEnterpriseType
            // 
            this.cmbEnterpriseType.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbEnterpriseType.Location = new System.Drawing.Point(424, 224);
            this.cmbEnterpriseType.Name = "cmbEnterpriseType";
            this.cmbEnterpriseType.Size = new System.Drawing.Size(152, 21);
            this.cmbEnterpriseType.TabIndex = 13;
            // 
            // txtCommnets
            // 
            this.txtCommnets.AutoSize = false;
            this.txtCommnets.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtCommnets.Location = new System.Drawing.Point(136, 352);
            this.txtCommnets.MaxLength = 200;
            this.txtCommnets.Multiline = true;
            this.txtCommnets.Name = "txtCommnets";
            this.txtCommnets.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtCommnets.Size = new System.Drawing.Size(440, 64);
            this.txtCommnets.TabIndex = 20;
            // 
            // ultraLabel11
            // 
            this.ultraLabel11.Location = new System.Drawing.Point(32, 360);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel11.TabIndex = 22;
            this.ultraLabel11.Text = "备注：";
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.Location = new System.Drawing.Point(320, 224);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel9.TabIndex = 16;
            this.ultraLabel9.Text = "企业性质：";
            // 
            // txtEmail
            // 
            this.txtEmail.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtEmail.Location = new System.Drawing.Point(136, 192);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(152, 21);
            this.txtEmail.TabIndex = 10;
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Location = new System.Drawing.Point(32, 192);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel7.TabIndex = 12;
            this.ultraLabel7.Text = "电子邮箱：";
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnCancel.Location = new System.Drawing.Point(336, 424);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancelModify_Click);
            // 
            // btnModify
            // 
            this.btnModify.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnModify.Location = new System.Drawing.Point(200, 424);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 31;
            this.btnModify.Text = "确定";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(32, 160);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel6.TabIndex = 10;
            this.ultraLabel6.Text = "单位地址：";
            // 
            // txtLinkPhone
            // 
            this.txtLinkPhone.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtLinkPhone.Location = new System.Drawing.Point(424, 160);
            this.txtLinkPhone.MaxLength = 20;
            this.txtLinkPhone.Name = "txtLinkPhone";
            this.txtLinkPhone.Size = new System.Drawing.Size(152, 21);
            this.txtLinkPhone.TabIndex = 9;
            // 
            // txtLinkAddress
            // 
            this.txtLinkAddress.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtLinkAddress.Location = new System.Drawing.Point(136, 160);
            this.txtLinkAddress.MaxLength = 200;
            this.txtLinkAddress.Name = "txtLinkAddress";
            this.txtLinkAddress.Size = new System.Drawing.Size(152, 21);
            this.txtLinkAddress.TabIndex = 8;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(320, 160);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel5.TabIndex = 8;
            this.ultraLabel5.Text = "办公电话：";
            // 
            // txtPaperNo
            // 
            this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPaperNo.Location = new System.Drawing.Point(136, 64);
            this.txtPaperNo.MaxLength = 30;
            this.txtPaperNo.Name = "txtPaperNo";
            this.txtPaperNo.Size = new System.Drawing.Size(152, 21);
            this.txtPaperNo.TabIndex = 3;
            // 
            // txtMemberCardNo
            // 
            this.txtMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberCardNo.Enabled = false;
            this.txtMemberCardNo.Location = new System.Drawing.Point(136, 32);
            this.txtMemberCardNo.MaxLength = 8;
            this.txtMemberCardNo.Name = "txtMemberCardNo";
            this.txtMemberCardNo.Size = new System.Drawing.Size(152, 21);
            this.txtMemberCardNo.TabIndex = 1;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(32, 64);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel4.TabIndex = 4;
            this.ultraLabel4.Text = "工商注册号：";
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.Location = new System.Drawing.Point(32, 32);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel17.TabIndex = 0;
            this.ultraLabel17.Text = "会员卡号：";
            // 
            // ultraLabel23
            // 
            this.ultraLabel23.Location = new System.Drawing.Point(320, 128);
            this.ultraLabel23.Name = "ultraLabel23";
            this.ultraLabel23.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel23.TabIndex = 6;
            this.ultraLabel23.Text = "联系人：";
            // 
            // txtLinkman
            // 
            this.txtLinkman.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtLinkman.Location = new System.Drawing.Point(424, 128);
            this.txtLinkman.MaxLength = 20;
            this.txtLinkman.Name = "txtLinkman";
            this.txtLinkman.Size = new System.Drawing.Size(152, 21);
            this.txtLinkman.TabIndex = 7;
            this.txtLinkman.ValueChanged += new System.EventHandler(this.txtLinkman_ValueChanged);
            // 
            // txtMemberName
            // 
            this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberName.Location = new System.Drawing.Point(424, 96);
            this.txtMemberName.MaxLength = 100;
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(152, 21);
            this.txtMemberName.TabIndex = 5;
            // 
            // ultraLabel24
            // 
            this.ultraLabel24.Location = new System.Drawing.Point(320, 96);
            this.ultraLabel24.Name = "ultraLabel24";
            this.ultraLabel24.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel24.TabIndex = 2;
            this.ultraLabel24.Text = "单位名称：";
            // 
            // MemberFileModify
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1028, 589);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGrid1);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "MemberFileModify";
            this.Text = Login.constApp.strCardTypeL8Name + "会员档案修改";
            this.Load += new System.EventHandler(this.MemberFileModify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdBeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberPwdConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHandleManPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHandleMan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostalcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileTelephone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorporation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnterpriseType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommnets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//查询
			try
			{
                string strSql = "select top 100 cnvcMemberCardNo,cnvcMemberName,cnvcPaperNo,cnvcMemberRight,cnvcDiscount,cnvcFree,cnnMemberFee,cnnPrepay,cndInNetDate from tbMember where Len(cnvcMemberCardNo)=8 and  cnvcState='" + ConstApp.Card_State_InUse + "'";
				if (txtQMemberCardNo.Text.Length > 0)
				{
					strSql += " and cnvcMemberCardNo like '%"+txtQMemberCardNo.Text+"%'";
				}
				if (txtQPaperNo.Text.Length > 0)
				{
					strSql += " and cnvcPaperNo like '%"+txtQPaperNo.Text+"%'";
				}
				if (txtQMemberName.Text.Length > 0)
				{
					strSql += " and cnvcMemberName like '%"+txtQMemberName.Text+"%'";
				}
				if (chkBeginDate.Checked)
				{
					strSql += " and cndInNetDate >='"+cmdBeginDate.Text+"'";
				}
				if (chkEndDate.Checked)
				{
					strSql += " and cndInNetDate <='"+cmbEndDate.Text+"'";
				}
//				if (cmbState.Text.Length > 0)
//				{
//					strSql += " and cnvcState='"+cmbState.Text+"'";
//				}
				DataTable dtMember = Helper.Query(strSql);
				this.ultraGrid1.DataSource = null;
				this.ultraGrid1.DataSource = dtMember;
				this.ultraGrid1.SetDataBinding(dtMember,null);
				ClearText();
				btnModify.Enabled = false;
				
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

		private void MemberFileModify_Load(object sender, System.EventArgs e)
		{
			ClientHelper.BindEnterpriseType(cmbEnterpriseType);
			ClientHelper.BindTrade(cmbTrade);
			cmdBeginDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEndDate.MaskInput = "yyyy-mm-dd hh:mm";
			
			cmdBeginDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 00:00";
			cmbEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 23:59";

			cmdEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

			btnModify.Enabled = false;
			
		}

		private void btnModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				#region 数据验证
				if (txtMemberCardNo.Text.Trim().Length == 0)
				{
					throw new BusinessException("发卡","请选择进行修改的会员");
				}
				if (txtMemberName.Text.Trim().Length == 0)
				{
					throw new BusinessException("发卡","单位名称不能为空");
				}
				if (txtPaperNo.Text.Trim().Length == 0)
				{
					throw new BusinessException("发卡","工商注册号不能为空");
				}
				if (txtMemberPwd.Text.Trim().Length == 0)
				{
					throw new BusinessException("发卡","密码不能为空");
				}

				if (txtMemberPwd.Text != txtMemberPwdConfirm.Text)
				{
					throw new BusinessException("发卡","会员密码确认和会员密码不同");
				}
				#endregion
				Member member = new Member();
				member.cnvcMemberPwd = txtMemberPwd.Text;
				member.cnvcComments = txtCommnets.Text;
				member.cnvcEmail = txtEmail.Text;
				member.cnvcEnterpriseType = cmbEnterpriseType.Text;
				member.cnvcCompanyAddress = txtLinkAddress.Text;
				member.cnvcCorporation = txtCorporation.Text;
				member.cnvcLinkman = txtLinkman.Text;
				member.cnvcLinkPhone = txtLinkPhone.Text;
				member.cnvcMemberCardNo = txtMemberCardNo.Text;
				member.cnvcMemberPwd = txtMemberPwd.Text;
				member.cnvcMemberName = txtMemberName.Text;
				member.cnvcPaperNo = txtPaperNo.Text;
				member.cndEndDate = cmdEndDate.Text;
				member.cnvcOperName = this.oper.cnvcOperName;
				member.cndOperDate = DateTime.Now;
				member.cnvcMobileTelePhone = txtMobileTelephone.Text;
				member.cnvcPostalCode = txtPostalcode.Text;
				member.cnvcSales = txtSales.Text;
				member.cnvcHandleman = txtHandleMan.Text;
				member.cnvcHandlemanPaperNo = txtHandleManPaperNo.Text;
				member.cnvcTrade = cmbTrade.Text;
				member.cnvcCustomerService = txtCustomerService.Text;
				member.cnvcFax = txtFax.Text;
                MemberManageFacade mm = new MemberManageFacade();
				mm.ModifyMember(member);
				MessageBox.Show(this,"会员档案修改成功！","会员档案修改",MessageBoxButtons.OK,MessageBoxIcon.Information);
				btnQuery_Click(null,null);

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

		private void ClearText()
		{
			txtCommnets.Text                   = ""  ;
			txtEmail.Text                      = "" 	;
			cmbEnterpriseType.Text             = "" 	;
			txtLinkAddress.Text                = "" 	;
			txtCorporation.Text                = "" 	;
			txtLinkman.Text                    = "" 	;
			txtLinkPhone.Text                  = "" 	;
			txtMemberCardNo.Text               = "" 	;
			txtMemberPwd.Text                  = "" 	;
			txtMemberName.Text                 = "" 	;
			txtPaperNo.Text                    = "" 	;
			//cmdEndDate.Text                    = "" 	;
			cmdEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			txtMobileTelephone.Text            = "" 	;
			txtPostalcode.Text                 = "" 	;
			txtSales.Text                      = "" 	;
			txtHandleMan.Text                  = "" 	;
			txtHandleManPaperNo.Text           = "" 	;
			cmbTrade.Text = "";
			txtMemberPwd.Text = "";
			txtMemberPwdConfirm.Text = "";
			txtFax.Text = "";

		}

		private void btnCancelModify_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e);
			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "会员卡号";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Header.Caption = "会员资格";
			e.Layout.Bands[0].Columns["cnvcDiscount"].Header.Caption = "折扣";
			e.Layout.Bands[0].Columns["cnvcFree"].Header.Caption = "场次";
			e.Layout.Bands[0].Columns["cnnMemberFee"].Header.Caption = "会员费";
			e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "实收";
			e.Layout.Bands[0].Columns["cndInNetDate"].Header.Caption = "入会时间";

			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Width = 60;
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Width = 100;
			e.Layout.Bands[0].Columns["cnvcDiscount"].Width = 30;
			e.Layout.Bands[0].Columns["cnvcFree"].Width = 60;
		}

		private void ultraGrid1_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{			
			try
			{
				UltraGridRow row = this.ultraGrid1.ActiveRow;
				if (null != row)
				{

					string strMemberCardNo = row.Cells["cnvcMemberCardNo"].Value.ToString();
					DataTable dtMember = Helper.Query("select * from tbMember where cnvcMemberCardNo = '"+strMemberCardNo+"'");
					if (dtMember.Rows.Count == 0)
					{
						throw new BusinessException("会员档案修改","查询会员出错！");
					}

					Member member = new Member(dtMember);

					txtCommnets.Text                  =  member.cnvcComments        ;
					txtEmail.Text                      =  member.cnvcEmail           ;
					cmbEnterpriseType.Text             =  member.cnvcEnterpriseType  ;
					txtLinkAddress.Text                =  member.cnvcCompanyAddress  ;
					txtCorporation.Text                =  member.cnvcCorporation     ;
					txtLinkman.Text                    =  member.cnvcLinkman         ;
					txtLinkPhone.Text                 =  member.cnvcLinkPhone       ;
					txtMemberCardNo.Text              =  member.cnvcMemberCardNo    ;
					txtMemberPwd.Text                  =  member.cnvcMemberPwd       ;
					txtMemberName.Text                 =  member.cnvcMemberName      ;
					txtPaperNo.Text                    =  member.cnvcPaperNo         ;
					cmdEndDate.Text                    =  member.cndEndDate          ;
					txtMobileTelephone.Text            =  member.cnvcMobileTelePhone ;
					txtPostalcode.Text                 =  member.cnvcPostalCode      ;
					txtSales.Text                      =  member.cnvcSales           ;
					txtHandleMan.Text                  =  member.cnvcHandleman       ;
					txtHandleManPaperNo.Text           =  member.cnvcHandlemanPaperNo;
					cmbTrade.Text = member.cnvcTrade;
					txtMemberPwd.Text = member.cnvcMemberPwd;
					txtMemberPwdConfirm.Text = member.cnvcMemberPwd;
					txtFax.Text = member.cnvcFax;
					

					btnModify.Enabled = true;

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

		private void txtLinkman_ValueChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
