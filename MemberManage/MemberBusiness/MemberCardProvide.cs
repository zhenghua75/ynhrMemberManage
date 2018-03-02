using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.Domain;
using ynhrMemberManage.ORM;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using Infragistics.Win.UltraWinGrid;
using ynhrMemberManage.Print;
using ynhrMemberManage.Common;
using ynhrMemberManage.BusinessFacade.MemberBusiness;
using MemberManage.Business;
namespace MemberManage.MemberBusiness
{
	/// <summary>
	/// Summary description for MemberCardProvide.
	/// </summary>
    public class MemberCardProvide : frmBase
	{
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private System.ComponentModel.IContainer components = null;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Infragistics.Win.Misc.UltraLabel ultraLabel8;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.Misc.UltraButton ultraButton2;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.Misc.UltraLabel ultraLabel11;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtLinkman;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtLinkPhone;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtLinkAddress;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtEmail;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCommnets;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbMemberRight;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbEnterpriseType;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCorporation;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberPwd;
		private Infragistics.Win.Misc.UltraLabel ultraLabel16;
		private Infragistics.Win.Printing.UltraPrintDocument ultraPrintDocument1;
		private Infragistics.Win.Printing.UltraPrintPreviewDialog ultraPrintPreviewDialog1;
		public static bool IsShowing ;
		private Infragistics.Win.Misc.UltraLabel ultraLabel18;
		private Infragistics.Win.Misc.UltraLabel ultraLabel19;
		private Infragistics.Win.Misc.UltraLabel ultraLabel20;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMobileTelephone;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPostalcode;
		private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private Infragistics.Win.Misc.UltraLabel ultraLabel22;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor cmbHandleManPaperNo;
		private Infragistics.Win.Misc.UltraLabel ultraLabel23;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbTrade;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberPwdConfirm;
		private Infragistics.Win.Misc.UltraLabel ultraLabel24;
        //private Member pMember = null;
		private Infragistics.Win.Misc.UltraLabel ultraLabel25;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtFax;
        private Infragistics.Win.Misc.UltraLabel ultraLabel26;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbCustomerService;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbHandleMan;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbSales;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPrepay;
        private Infragistics.Win.Misc.UltraLabel lblPrepay;
        private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox2;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel2;
        private UltraGrid ultraGrid2;
		private PrintedBill pBill = null;
		//public int iDiscount = 100;

		public MemberCardProvide()
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
            this.txtMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.txtPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtLinkman = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.txtLinkPhone = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.txtLinkAddress = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.txtEmail = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraExpandableGroupBox2 = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel2 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.ultraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.txtPrepay = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblPrepay = new Infragistics.Win.Misc.UltraLabel();
            this.cmbCustomerService = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbHandleMan = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbSales = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtFax = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMemberPwdConfirm = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel24 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbTrade = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel23 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbHandleManPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel22 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.txtPostalcode = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMobileTelephone = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMemberPwd = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.txtCorporation = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbEnterpriseType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbMemberRight = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtCommnets = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ultraPrintDocument1 = new Infragistics.Win.Printing.UltraPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new Infragistics.Win.Printing.UltraPrintPreviewDialog(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox2)).BeginInit();
            this.ultraExpandableGroupBox2.SuspendLayout();
            this.ultraExpandableGroupBoxPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrepay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCustomerService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHandleMan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberPwdConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHandleManPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostalcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileTelephone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorporation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnterpriseType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMemberRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommnets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMemberCardNo
            // 
            this.txtMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberCardNo.Location = new System.Drawing.Point(136, 16);
            this.txtMemberCardNo.MaxLength = 8;
            this.txtMemberCardNo.Name = "txtMemberCardNo";
            this.txtMemberCardNo.Size = new System.Drawing.Size(152, 21);
            this.txtMemberCardNo.TabIndex = 1;
            this.txtMemberCardNo.Visible = false;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(32, 16);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "会员卡号：";
            this.ultraLabel1.Visible = false;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(320, 56);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 2;
            this.ultraLabel2.Text = "单位名称：";
            // 
            // txtMemberName
            // 
            this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberName.Location = new System.Drawing.Point(424, 56);
            this.txtMemberName.MaxLength = 100;
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(152, 21);
            this.txtMemberName.TabIndex = 5;
            this.txtMemberName.Validated += new System.EventHandler(this.txtMemberName_Validated);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(32, 56);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 4;
            this.ultraLabel3.Text = "工商注册号：";
            // 
            // txtPaperNo
            // 
            this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPaperNo.Location = new System.Drawing.Point(136, 56);
            this.txtPaperNo.MaxLength = 30;
            this.txtPaperNo.Name = "txtPaperNo";
            this.txtPaperNo.Size = new System.Drawing.Size(152, 21);
            this.txtPaperNo.TabIndex = 4;
            this.txtPaperNo.Validated += new System.EventHandler(this.txtPaperNo_Validated);
            // 
            // txtLinkman
            // 
            this.txtLinkman.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtLinkman.Location = new System.Drawing.Point(424, 88);
            this.txtLinkman.MaxLength = 20;
            this.txtLinkman.Name = "txtLinkman";
            this.txtLinkman.Size = new System.Drawing.Size(152, 21);
            this.txtLinkman.TabIndex = 7;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(320, 88);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel4.TabIndex = 6;
            this.ultraLabel4.Text = "联系人：";
            // 
            // txtLinkPhone
            // 
            this.txtLinkPhone.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtLinkPhone.Location = new System.Drawing.Point(424, 120);
            this.txtLinkPhone.MaxLength = 20;
            this.txtLinkPhone.Name = "txtLinkPhone";
            this.txtLinkPhone.Size = new System.Drawing.Size(152, 21);
            this.txtLinkPhone.TabIndex = 9;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(320, 120);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel5.TabIndex = 8;
            this.ultraLabel5.Text = "办公电话：";
            // 
            // txtLinkAddress
            // 
            this.txtLinkAddress.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtLinkAddress.Location = new System.Drawing.Point(136, 152);
            this.txtLinkAddress.MaxLength = 200;
            this.txtLinkAddress.Name = "txtLinkAddress";
            this.txtLinkAddress.Size = new System.Drawing.Size(152, 21);
            this.txtLinkAddress.TabIndex = 10;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(32, 152);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel6.TabIndex = 10;
            this.ultraLabel6.Text = "单位地址：";
            // 
            // txtEmail
            // 
            this.txtEmail.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtEmail.Location = new System.Drawing.Point(136, 184);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(152, 21);
            this.txtEmail.TabIndex = 12;
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Location = new System.Drawing.Point(32, 184);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel7.TabIndex = 12;
            this.ultraLabel7.Text = "电子邮箱：";
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.Location = new System.Drawing.Point(320, 216);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel8.TabIndex = 14;
            this.ultraLabel8.Text = "会员资格：";
            // 
            // ultraButton1
            // 
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton1.Location = new System.Drawing.Point(192, 458);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 31;
            this.ultraButton1.Text = "确定";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // ultraButton2
            // 
            this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton2.Location = new System.Drawing.Point(320, 458);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(75, 23);
            this.ultraButton2.TabIndex = 33;
            this.ultraButton2.Text = "取消";
            this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.ultraExpandableGroupBox2);
            this.ultraGroupBox2.Controls.Add(this.txtPrepay);
            this.ultraGroupBox2.Controls.Add(this.lblPrepay);
            this.ultraGroupBox2.Controls.Add(this.cmbCustomerService);
            this.ultraGroupBox2.Controls.Add(this.cmbHandleMan);
            this.ultraGroupBox2.Controls.Add(this.cmbSales);
            this.ultraGroupBox2.Controls.Add(this.txtFax);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel26);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel25);
            this.ultraGroupBox2.Controls.Add(this.txtMemberPwdConfirm);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel24);
            this.ultraGroupBox2.Controls.Add(this.cmbTrade);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel23);
            this.ultraGroupBox2.Controls.Add(this.cmbHandleManPaperNo);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel22);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel21);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel20);
            this.ultraGroupBox2.Controls.Add(this.txtPostalcode);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel19);
            this.ultraGroupBox2.Controls.Add(this.txtMobileTelephone);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel18);
            this.ultraGroupBox2.Controls.Add(this.txtMemberPwd);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel16);
            this.ultraGroupBox2.Controls.Add(this.txtCorporation);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel15);
            this.ultraGroupBox2.Controls.Add(this.cmbEnterpriseType);
            this.ultraGroupBox2.Controls.Add(this.cmbMemberRight);
            this.ultraGroupBox2.Controls.Add(this.txtCommnets);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel11);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel9);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel8);
            this.ultraGroupBox2.Controls.Add(this.txtEmail);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel7);
            this.ultraGroupBox2.Controls.Add(this.ultraButton2);
            this.ultraGroupBox2.Controls.Add(this.ultraButton1);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel6);
            this.ultraGroupBox2.Controls.Add(this.txtLinkPhone);
            this.ultraGroupBox2.Controls.Add(this.txtLinkAddress);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox2.Controls.Add(this.txtPaperNo);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox2.Controls.Add(this.txtLinkman);
            this.ultraGroupBox2.Controls.Add(this.txtMemberName);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox2.Location = new System.Drawing.Point(224, 24);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(608, 600);
            this.ultraGroupBox2.TabIndex = 20;
            // 
            // ultraExpandableGroupBox2
            // 
            this.ultraExpandableGroupBox2.Controls.Add(this.ultraExpandableGroupBoxPanel2);
            this.ultraExpandableGroupBox2.ExpandedSize = new System.Drawing.Size(560, 105);
            this.ultraExpandableGroupBox2.Location = new System.Drawing.Point(24, 487);
            this.ultraExpandableGroupBox2.Name = "ultraExpandableGroupBox2";
            this.ultraExpandableGroupBox2.Size = new System.Drawing.Size(560, 105);
            this.ultraExpandableGroupBox2.TabIndex = 61;
            this.ultraExpandableGroupBox2.Text = "服务产品";
            this.ultraExpandableGroupBox2.Visible = false;
            // 
            // ultraExpandableGroupBoxPanel2
            // 
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraGrid2);
            this.ultraExpandableGroupBoxPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel2.Location = new System.Drawing.Point(3, 19);
            this.ultraExpandableGroupBoxPanel2.Name = "ultraExpandableGroupBoxPanel2";
            this.ultraExpandableGroupBoxPanel2.Size = new System.Drawing.Size(554, 83);
            this.ultraExpandableGroupBoxPanel2.TabIndex = 0;
            // 
            // ultraGrid2
            // 
            this.ultraGrid2.Location = new System.Drawing.Point(16, 3);
            this.ultraGrid2.Name = "ultraGrid2";
            this.ultraGrid2.Size = new System.Drawing.Size(531, 77);
            this.ultraGrid2.TabIndex = 0;
            this.ultraGrid2.Text = "可用服务产品";
            this.ultraGrid2.Visible = false;
            this.ultraGrid2.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid2_InitializeLayout);
            // 
            // txtPrepay
            // 
            this.txtPrepay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPrepay.Enabled = false;
            this.txtPrepay.Location = new System.Drawing.Point(422, 312);
            this.txtPrepay.Name = "txtPrepay";
            this.txtPrepay.Size = new System.Drawing.Size(152, 21);
            this.txtPrepay.TabIndex = 59;
            this.txtPrepay.Visible = false;
            // 
            // lblPrepay
            // 
            this.lblPrepay.Location = new System.Drawing.Point(318, 312);
            this.lblPrepay.Name = "lblPrepay";
            this.lblPrepay.Size = new System.Drawing.Size(100, 23);
            this.lblPrepay.TabIndex = 60;
            this.lblPrepay.Text = "会员费：";
            this.lblPrepay.Visible = false;
            // 
            // cmbCustomerService
            // 
            this.cmbCustomerService.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbCustomerService.Location = new System.Drawing.Point(424, 277);
            this.cmbCustomerService.Name = "cmbCustomerService";
            this.cmbCustomerService.Size = new System.Drawing.Size(152, 21);
            this.cmbCustomerService.TabIndex = 58;
            // 
            // cmbHandleMan
            // 
            this.cmbHandleMan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbHandleMan.Location = new System.Drawing.Point(136, 280);
            this.cmbHandleMan.Name = "cmbHandleMan";
            this.cmbHandleMan.Size = new System.Drawing.Size(152, 21);
            this.cmbHandleMan.TabIndex = 57;
            this.cmbHandleMan.ValueChanged += new System.EventHandler(this.cmbHandleMan_ValueChanged);
            // 
            // cmbSales
            // 
            this.cmbSales.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbSales.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbSales.Location = new System.Drawing.Point(424, 248);
            this.cmbSales.Name = "cmbSales";
            this.cmbSales.Size = new System.Drawing.Size(152, 21);
            this.cmbSales.TabIndex = 56;
            // 
            // txtFax
            // 
            this.txtFax.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtFax.Location = new System.Drawing.Point(136, 216);
            this.txtFax.MaxLength = 20;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(152, 21);
            this.txtFax.TabIndex = 14;
            // 
            // ultraLabel26
            // 
            this.ultraLabel26.Location = new System.Drawing.Point(32, 216);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel26.TabIndex = 53;
            this.ultraLabel26.Text = "传真：";
            // 
            // ultraLabel25
            // 
            this.ultraLabel25.Location = new System.Drawing.Point(320, 280);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel25.TabIndex = 52;
            this.ultraLabel25.Text = "客服姓名：";
            // 
            // txtMemberPwdConfirm
            // 
            this.txtMemberPwdConfirm.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberPwdConfirm.Location = new System.Drawing.Point(424, 24);
            this.txtMemberPwdConfirm.MaxLength = 200;
            this.txtMemberPwdConfirm.Name = "txtMemberPwdConfirm";
            this.txtMemberPwdConfirm.Size = new System.Drawing.Size(152, 21);
            this.txtMemberPwdConfirm.TabIndex = 3;
            // 
            // ultraLabel24
            // 
            this.ultraLabel24.Location = new System.Drawing.Point(320, 24);
            this.ultraLabel24.Name = "ultraLabel24";
            this.ultraLabel24.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel24.TabIndex = 50;
            this.ultraLabel24.Text = "会员密码确认：";
            // 
            // cmbTrade
            // 
            this.cmbTrade.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbTrade.Location = new System.Drawing.Point(136, 248);
            this.cmbTrade.Name = "cmbTrade";
            this.cmbTrade.Size = new System.Drawing.Size(152, 21);
            this.cmbTrade.TabIndex = 16;
            this.cmbTrade.Validated += new System.EventHandler(this.cmbTrade_Validated);
            // 
            // ultraLabel23
            // 
            this.ultraLabel23.Location = new System.Drawing.Point(32, 248);
            this.ultraLabel23.Name = "ultraLabel23";
            this.ultraLabel23.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel23.TabIndex = 47;
            this.ultraLabel23.Text = "行业：";
            // 
            // cmbHandleManPaperNo
            // 
            this.cmbHandleManPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbHandleManPaperNo.Location = new System.Drawing.Point(136, 316);
            this.cmbHandleManPaperNo.MaxLength = 20;
            this.cmbHandleManPaperNo.Name = "cmbHandleManPaperNo";
            this.cmbHandleManPaperNo.Size = new System.Drawing.Size(152, 21);
            this.cmbHandleManPaperNo.TabIndex = 23;
            // 
            // ultraLabel22
            // 
            this.ultraLabel22.Location = new System.Drawing.Point(32, 314);
            this.ultraLabel22.Name = "ultraLabel22";
            this.ultraLabel22.Size = new System.Drawing.Size(104, 23);
            this.ultraLabel22.TabIndex = 45;
            this.ultraLabel22.Text = "经办人身份证号：";
            // 
            // ultraLabel21
            // 
            this.ultraLabel21.Location = new System.Drawing.Point(32, 281);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel21.TabIndex = 43;
            this.ultraLabel21.Text = "经办人：";
            // 
            // ultraLabel20
            // 
            this.ultraLabel20.Location = new System.Drawing.Point(320, 248);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel20.TabIndex = 41;
            this.ultraLabel20.Text = "销售人员：";
            // 
            // txtPostalcode
            // 
            this.txtPostalcode.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPostalcode.Location = new System.Drawing.Point(424, 152);
            this.txtPostalcode.MaxLength = 20;
            this.txtPostalcode.Name = "txtPostalcode";
            this.txtPostalcode.Size = new System.Drawing.Size(152, 21);
            this.txtPostalcode.TabIndex = 11;
            // 
            // ultraLabel19
            // 
            this.ultraLabel19.Location = new System.Drawing.Point(320, 152);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel19.TabIndex = 39;
            this.ultraLabel19.Text = "邮政编码：";
            // 
            // txtMobileTelephone
            // 
            this.txtMobileTelephone.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMobileTelephone.Location = new System.Drawing.Point(136, 120);
            this.txtMobileTelephone.MaxLength = 20;
            this.txtMobileTelephone.Name = "txtMobileTelephone";
            this.txtMobileTelephone.Size = new System.Drawing.Size(152, 21);
            this.txtMobileTelephone.TabIndex = 8;
            // 
            // ultraLabel18
            // 
            this.ultraLabel18.Location = new System.Drawing.Point(32, 120);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel18.TabIndex = 37;
            this.ultraLabel18.Text = "手机号码：";
            // 
            // txtMemberPwd
            // 
            this.txtMemberPwd.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberPwd.Location = new System.Drawing.Point(136, 24);
            this.txtMemberPwd.MaxLength = 200;
            this.txtMemberPwd.Name = "txtMemberPwd";
            this.txtMemberPwd.Size = new System.Drawing.Size(152, 21);
            this.txtMemberPwd.TabIndex = 2;
            this.txtMemberPwd.Validated += new System.EventHandler(this.txtMemberPwd_Validated);
            // 
            // ultraLabel16
            // 
            this.ultraLabel16.Location = new System.Drawing.Point(32, 24);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel16.TabIndex = 34;
            this.ultraLabel16.Text = "会员密码：";
            // 
            // txtCorporation
            // 
            this.txtCorporation.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtCorporation.Location = new System.Drawing.Point(136, 88);
            this.txtCorporation.MaxLength = 20;
            this.txtCorporation.Name = "txtCorporation";
            this.txtCorporation.Size = new System.Drawing.Size(152, 21);
            this.txtCorporation.TabIndex = 6;
            // 
            // ultraLabel15
            // 
            this.ultraLabel15.Location = new System.Drawing.Point(32, 88);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel15.TabIndex = 30;
            this.ultraLabel15.Text = "法人代表：";
            // 
            // cmbEnterpriseType
            // 
            this.cmbEnterpriseType.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbEnterpriseType.Location = new System.Drawing.Point(424, 184);
            this.cmbEnterpriseType.Name = "cmbEnterpriseType";
            this.cmbEnterpriseType.Size = new System.Drawing.Size(152, 21);
            this.cmbEnterpriseType.TabIndex = 13;
            this.cmbEnterpriseType.Validated += new System.EventHandler(this.cmbEnterpriseType_Validated);
            // 
            // cmbMemberRight
            // 
            this.cmbMemberRight.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbMemberRight.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbMemberRight.Location = new System.Drawing.Point(424, 216);
            this.cmbMemberRight.Name = "cmbMemberRight";
            this.cmbMemberRight.Size = new System.Drawing.Size(152, 21);
            this.cmbMemberRight.TabIndex = 15;
            this.cmbMemberRight.ValueChanged += new System.EventHandler(this.cmbMemberRight_ValueChanged);
            // 
            // txtCommnets
            // 
            this.txtCommnets.AutoSize = false;
            this.txtCommnets.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtCommnets.Location = new System.Drawing.Point(136, 354);
            this.txtCommnets.MaxLength = 200;
            this.txtCommnets.Multiline = true;
            this.txtCommnets.Name = "txtCommnets";
            this.txtCommnets.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtCommnets.Size = new System.Drawing.Size(440, 88);
            this.txtCommnets.TabIndex = 26;
            // 
            // ultraLabel11
            // 
            this.ultraLabel11.Location = new System.Drawing.Point(32, 362);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel11.TabIndex = 22;
            this.ultraLabel11.Text = "备注：";
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.Location = new System.Drawing.Point(320, 184);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel9.TabIndex = 16;
            this.ultraLabel9.Text = "企业性质：";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ultraPrintDocument1
            // 
            this.ultraPrintDocument1.DocumentName = "会员卡小票";
            // 
            // ultraPrintPreviewDialog1
            // 
            this.ultraPrintPreviewDialog1.Document = this.ultraPrintDocument1;
            this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
            // 
            // MemberCardProvide
            // 
            this.AcceptButton = this.ultraButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(920, 627);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.txtMemberCardNo);
            this.Controls.Add(this.ultraLabel1);
            this.Name = "MemberCardProvide";
            this.Text = Login.constApp.strCardTypeL6Name + "录入";
            this.Load += new System.EventHandler(this.MemberCardProvide_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox2)).EndInit();
            this.ultraExpandableGroupBox2.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrepay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCustomerService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHandleMan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberPwdConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHandleManPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostalcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileTelephone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorporation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnterpriseType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMemberRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommnets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void ultraButton1_Click(object sender, System.EventArgs e)
        {
            //try
            //{
            #region 数据验证
            //this.txtMemberCardNo_Validated(null,null);
            this.txtMemberName_Validated(null, null);
            this.txtPaperNo_Validated(null, null);
            this.cmbTrade_Validated(null, null);
            this.cmbEnterpriseType_Validated(null, null);
            //this.txtDiscount_Validated(null,null);
            //string strMemberCardNoError = this.errorProvider1.GetError(txtMemberCardNo);
            string strMemberNameError = this.errorProvider1.GetError(txtMemberName);
            string strPaperNoError = this.errorProvider1.GetError(txtPaperNo);
            //string strDiscountError = this.errorProvider1.GetError(txtDiscount);
            string strTrade = this.errorProvider1.GetError(cmbTrade);
            string strEnterpriseType = this.errorProvider1.GetError(cmbEnterpriseType);
            //				if (strMemberCardNoError.Length >0)
            //				{
            //					throw new BusinessException("发卡",strMemberCardNoError);
            //				}
            if (strMemberNameError.Length > 0)
            {
                throw new BusinessException("发卡", strMemberNameError);
            }
            if (strPaperNoError.Length > 0)
            {
                throw new BusinessException("发卡", strPaperNoError);
            }
            //if (strDiscountError.Length >0)
            //{
            //    throw new BusinessException("发卡",strDiscountError);
            //}
            if (strTrade.Length > 0)
            {
                throw new BusinessException("发卡", strTrade);
            }
            if (strEnterpriseType.Length > 0)
            {
                throw new BusinessException("发卡", strEnterpriseType);
            }
            if (cmbEnterpriseType.Text == "")
            {
                throw new BusinessException("发卡", "企业性质不能为空！");
            }
            if (cmbTrade.Text == "")
            {
                throw new BusinessException("发卡", "行业不能为空！");
            }
            if (cmbMemberRight.Text == "")
            {
                throw new BusinessException("发卡", "会员资格不能为空！");
            }
            //if (txtFact.Text.Trim().Length == 0)
            //{
            //    throw new BusinessException("发卡","请输入实收");
            //}
            //if (txtDiscount.Text.Trim().Length == 0)
            //{
            //    throw new BusinessException("发卡","请输入折扣");
            //}
            if (txtMemberPwd.Text.Trim().Length == 0)
            {
                throw new BusinessException("发卡", "请输入会员密码");
            }
            //cmbMemberRight_ValueChanged(null,null);
            string strMemberRight = this.errorProvider1.GetError(cmbMemberRight);
            if (strMemberRight.Length > 0)
            {
                throw new BusinessException("发卡", strMemberRight);
            }
            if (txtMemberPwd.Text != txtMemberPwdConfirm.Text)
            {
                throw new BusinessException("发卡", "会员密码确认和会员密码不同！");
            }
            #endregion
            string strCardNo = Helper.CreateCardNo6();
            if (strCardNo == "")
            {
                throw new BusinessException("发卡", "卡号生成错误！");
            }
            if (strCardNo == "C00000")
            {
                throw new BusinessException("发卡", "卡号超出限制！");
            }

            Member member = new Member();
            member.cnvcComments = txtCommnets.Text;
            //member.cnvcDiscount = txtDiscount.Text;
            member.cnvcEmail = txtEmail.Text;
            member.cnvcEnterpriseType = cmbEnterpriseType.Text;
            if (this.GetIsFeeType(cmbMemberRight.Text))
            {
                member.cnvcFree = this.GetFeeType(cmbMemberRight.Text);
            }
            member.cnvcCompanyAddress = txtLinkAddress.Text;
            member.cnvcCorporation = txtCorporation.Text;
            member.cnvcLinkman = txtLinkman.Text;
            member.cnvcLinkPhone = txtLinkPhone.Text;
            //member.cnvcMemberCardNo = txtMemberCardNo.Text;
            member.cnvcMemberCardNo = strCardNo;
            member.cnvcMemberPwd = txtMemberPwd.Text;
            member.cnvcMemberName = txtMemberName.Text;
            member.cnvcMemberRight = cmbMemberRight.Text;
            member.cnvcPaperNo = txtPaperNo.Text;
            //member.cnvcProduct = cmbProduct.Text;
            if (this.GetIsMemberFee(cmbMemberRight.Text))
            {
                member.cnnMemberFee = this.GetMemberFee(cmbMemberRight.Text);//Decimal.Parse(txtPrepay.Text);
            }
            //member.cnnPrepay = Decimal.Parse(txtFact.Text);

            member.cndEndDate = this.GetEndDate(cmbMemberRight.Text);//DateTime.Now.ToString("yyyy-MM-dd");//cmdEndDate.Text;//"9999-12-31";//
            member.cnvcOperName = this.oper.cnvcOperName;
            member.cndOperDate = DateTime.Now;
            member.cndInNetDate = member.cndOperDate;
            member.cnvcMobileTelePhone = txtMobileTelephone.Text;
            member.cnvcPostalCode = txtPostalcode.Text;
            member.cnvcSales = cmbSales.Text;
            member.cnvcHandleman = cmbHandleMan.Text;
            member.cnvcHandlemanPaperNo = cmbHandleManPaperNo.Text;
            member.cnvcTrade = cmbTrade.Text;
            member.cnvcCustomerService = cmbCustomerService.Text;
            member.cnvcFax = txtFax.Text;
            MemberManageFacade mm = new MemberManageFacade();

            ArrayList alProduct = new ArrayList();
            string strProduct = "";
            if (this.GetIsProduct(cmbMemberRight.Text) && this.GetIsProductSelect(cmbMemberRight.Text))
            {
                foreach (UltraGridRow selRow in this.ultraGrid2.Rows)
                {
                    string strSelected = selRow.Cells["cnvcIsSelected"].Value.ToString();
                    bool bSelected = bool.Parse(strSelected);
                    if (bSelected)
                    {
                        MemberProduct product = new MemberProduct();
                        product.cndOperDate = DateTime.Now;
                        product.cnvcOperName = this.oper.cnvcOperName;
                        product.cnvcMemberCardNo = strCardNo;//txtMemberCardNo.Text;
                        product.cnvcPaperNo = txtPaperNo.Text;
                        product.cnvcMemberName = txtMemberName.Text;
                        product.cnvcProductName = selRow.Cells["cnvcMemberType"].Value.ToString();
                        //productLog.cnnProductPrice = Decimal.Parse(selRow.Cells["cnnProductPrice"].Value.ToString());
                        //productLog.cnvcProductDiscount = selRow.Cells["cnnProductDiscount"].Value.ToString();
                        //productLog.cnnPrepay = Decimal.Parse(selRow.Cells["cnnPrepay"].Value.ToString());
                        product.cnvcFree = selRow.Cells["cnvcMemberValue"].Value.ToString();
                        alProduct.Add(product);
                        strProduct += product.cnvcProductName + ",,,," + product.cnvcFree + ",|";
                    }
                }
            }
            //if (alProduct.Count < 1)
            //{
            //    throw new BusinessException("服务产品消费", "请选择充值产品");
            //}
            //MemberManage mm = new MemberManage();
            //mm.ConsumeProduct(alProduct, true, "");

            pBill = new PrintedBill(member.ToTable());
            pBill.cnvcProduct = strProduct;
            pBill.cnvcBillType = "会员信息录入";//ConstApp.Bill_Type_Provide;



            //pMember = member;
            //				DialogResult dr = MessageBox.Show(this,"【是】发卡并打印小票\n【否】不发卡，资料入库，不打印小票\n【取消】关闭发卡界面，不做操作","发卡成功！",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information);
            //				if (dr == DialogResult.Yes)
            //				{
            //					member.cnvcState = ConstApp.Card_State_InUse;//"正常在用";
            //					mm.AddMember(member,alProduct,pBill,true);
            //					MessageBox.Show(this,"发卡成功！","发卡");
            //					pBill.cnvcProduct = "";
            //					Helper.PrintTicket(pBill);	
            //					//清空继续发卡
            //					ClearText();
            //				}
            //				else if (dr == DialogResult.No)
            //				{
            member.cnvcState = ConstApp.Card_State_NoCard;//"未发卡";
            mm.AddMember(member,alProduct, pBill, false);
            MessageBox.Show(this, "入库成功，未发卡", "发卡");
            ClearText();
            //				}
            //				else
            //				{
            //					this.Close();
            //				}
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

		private void ultraButton2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void ClearText()
		{
			this.txtCommnets.Text = "";
			this.txtEmail.Text = "";
			this.txtLinkAddress.Text = "";
			this.txtLinkman.Text = "";
			this.txtLinkPhone.Text = "";
			this.txtMemberCardNo.Text = "";
			this.txtMemberName.Text = "";
			this.txtPaperNo.Text = "";
			//txtPrepay.Text = "";
			//this.txtPrepay.Text = "0";
			txtCorporation.Text = "";
			//txtDiscount.Text = "100";
			//txtFact.Text = "";
			txtMemberPwd.Text = "";
			txtMemberPwdConfirm.Text = "";
			txtMobileTelephone.Text = "";
			txtPostalcode.Text = "";
			cmbSales.Text = "";
			cmbHandleMan.Text = "";
			cmbHandleManPaperNo.Text = "";
			cmbCustomerService.Text = "";
			txtFax.Text = "";
			cmbMemberRight_ValueChanged(null,null);
			txtMemberCardNo.Focus();
		}

		private void MemberCardProvide_Load(object sender, System.EventArgs e)
		{
			//Helper.AddTodayButton(cmdEndDate);
			//cmdEndDate.Text = DateTime.Now.AddYears(1).AddDays(1).ToString("yyyy-MM-dd");
			Helper.SetTextBox(txtMemberCardNo,"MemberCardNo");
			//Helper.SetTextBox(txtDiscount,"Discount");
			//Helper.SetTextBox(txtFact,"Prepay");
			Helper.SetTextBox(txtMemberPwd,"Prepay");
			Helper.SetTextBox(txtMemberPwdConfirm,"Prepay");
			ClientHelper.BindTrade(cmbTrade);
            ClientHelper.BindMemberRight(cmbMemberRight);
            cmbMemberRight.SelectedIndex = 10;// Login.constApp.strCardTypeL6Name + "会员";
            ClientHelper.BindEnterpriseType(cmbEnterpriseType);
//			cmbMemberRight.SelectedIndex = 0;

			//this.ultraGrid2.Dock = DockStyle.Fill;
            ClientHelper.BindSales(cmbSales);//, this.oper.cnnOperID.ToString());
            //ClientHelper.BindSales(cmbHandleMan);//, this.oper.cnnOperID.ToString());
            ClientHelper.BindSales(cmbCustomerService);//, this.oper.cnnOperID.ToString());
		}

		private void txtMemberCardNo_Validated(object sender, System.EventArgs e)
		{			
			Helper.MemberCardNoValidated(this.txtMemberCardNo,errorProvider1,"new");
		}

        //private void txtDiscount_Validated(object sender, System.EventArgs e)
        //{
			
        //    //this.errorProvider1.SetError(txtMemberCardNo,"");	
        //    try
        //    {
        //        string strDiscount = txtDiscount.Text.Trim();
        //        if (strDiscount == "")
        //        {
        //            strDiscount = "100";
        //            txtDiscount.Text = "100";
        //        }
				
        //        string strMemberDiscount = "";//Login.constApp.htMemberDiscount[cmbMemberRight.Text].ToString();
        //        if (Login.constApp.htMemberDiscount.ContainsKey(cmbMemberRight.Text))
        //        {
        //            strMemberDiscount = Login.constApp.htMemberDiscount[cmbMemberRight.Text].ToString();
        //        }
        //        else
        //        {
        //            throw new BusinessException("参数",cmbMemberRight.Text+"的“折扣”参数未设置");
        //        }

        //        string strCuMemberDiscount = "";
        //        if (int.Parse(strMemberDiscount) > this.iDiscount)
        //        {
        //            strCuMemberDiscount = this.iDiscount.ToString();
        //        }
        //        else
        //        {
        //            strCuMemberDiscount = strMemberDiscount;
        //        }
        //        if (int.Parse(strDiscount) <0 || int.Parse(strDiscount) < int.Parse(strCuMemberDiscount) || int.Parse(strDiscount) > 100)
        //        {
        //            this.errorProvider1.SetError(txtDiscount,"折扣必须大于零小于等于100,并在权限范围内！");
        //        }
        //        else
        //        {
        //            this.errorProvider1.SetError(txtDiscount,"");
        //            //int iMemberFee = int.Parse(txtPrepay.Text);
        //            int iDiscount = int.Parse(txtDiscount.Text);
        //            //string strFact = ((iMemberFee*iDiscount)/100).ToString();
        //            //txtFact.Text = strFact;
        //        }
			
        //    }
        //    catch (BusinessException bex)
        //    {
        //        MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
        //    }
			
			
        //}

		private void txtMemberName_Validated(object sender, System.EventArgs e)
		{
			if (txtMemberName.Text.Trim().Length == 0)
			{
				this.errorProvider1.SetError(txtMemberName,"单位名称不能为空！");
			}
			else
			{
				this.errorProvider1.SetError(txtMemberName,"");
			}
		
		}

		private void txtPaperNo_Validated(object sender, System.EventArgs e)
		{
			if (txtPaperNo.Text.Trim().Length == 0)
			{
				this.errorProvider1.SetError(txtPaperNo,"工商注册号不能为空！");
			}
			else
			{
				this.errorProvider1.SetError(txtPaperNo,"");
			}
		}
		

		
		private void txtMemberPwd_Validated(object sender, System.EventArgs e)
		{
			if (txtMemberPwd.Text == "")
			{
				Random rr = new Random(DateTime.Now.Millisecond);
				rr.Next();
				txtMemberPwd.Text = rr.Next(100000,999999).ToString();
				txtMemberPwdConfirm.Text = txtMemberPwd.Text;
			}
			
		}

		private void ultraGrid2_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			e.Layout.Bands[0].Columns["cnvcIsSelected"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
			e.Layout.Bands[0].Columns["cnvcIsSelected"].Header.Caption = "选择";
			e.Layout.Bands[0].Columns["cnnMemberCodeID"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "会员资格";
			e.Layout.Bands[0].Columns["cnvcMemberType"].Header.Caption = "服务产品";
			e.Layout.Bands[0].Columns["cnvcMemberValue"].Header.Caption = "场次";
            e.Layout.Bands[0].Columns["cnvcMemberValue"].Hidden = true;

			e.Layout.Bands[0].Columns["cnvcIsSelected"].Width = 30;
			e.Layout.Bands[0].Columns["cnvcMemberValue"].Width = 60;

			e.Layout.Bands[0].Columns["cnvcMemberName"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			e.Layout.Bands[0].Columns["cnvcMemberType"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

		}

		private void cmbTrade_Validated(object sender, System.EventArgs e)
		{
			if (cmbTrade.Text.Trim().Length == 0)
			{
				this.errorProvider1.SetError(cmbTrade,"行业不能为空！");
			}
			else
			{
				this.errorProvider1.SetError(cmbTrade,"");
			}
		}

		private void cmbEnterpriseType_Validated(object sender, System.EventArgs e)
		{
			if (cmbEnterpriseType.Text.Trim().Length == 0)
			{
				this.errorProvider1.SetError(cmbEnterpriseType,"企业性质不能为空！");
			}
			else
			{
				this.errorProvider1.SetError(cmbEnterpriseType,"");
			}
		}

        private void cmbMemberRight_ValueChanged(object sender, System.EventArgs e)
        {
            //if (Login.constApp.htDisabledDate.ContainsKey(cmbMemberRight.Text))
            //{
            //    string strDisabledDate = Login.constApp.htDisabledDate[cmbMemberRight.Text].ToString();
            //    string strCurDate = DateTime.Now.AddMonths(int.Parse(strDisabledDate)).ToString();
            //    cmdEndDate.Text = strCurDate;
            //    this.errorProvider1.SetError(cmbMemberRight, "");
            //}
            //else
            //{
            //    MessageBox.Show(this, cmbMemberRight.Text + " 的“卡有效月份”参数未设置", "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.errorProvider1.SetError(cmbMemberRight, cmbMemberRight.Text + " 的“卡有效月份”参数未设置");
            //}
            if (this.GetIsProduct(cmbMemberRight.Text) && this.GetIsProductSelect(cmbMemberRight.Text))
            {
                this.ultraExpandableGroupBox2.Visible = true;
                this.ultraGrid2.Visible = true;
                Helper.BindMemberProduct(this.ultraGrid2, cmbMemberRight.Text);
            }
            else
            {
                this.ultraExpandableGroupBox2.Visible = false;
                this.ultraGrid2.Visible = false;
            }
            if (this.GetIsMemberFee(cmbMemberRight.Text))
            {
                this.lblPrepay.Visible = true;
                this.txtPrepay.Visible = true;

                if (Login.constApp.htMemberFee.ContainsKey(cmbMemberRight.Text))
                {
                    string strMemberFee = Login.constApp.htMemberFee[cmbMemberRight.Text].ToString();
                    txtPrepay.Text = strMemberFee;
                    this.errorProvider1.SetError(cmbMemberRight, "");
                }
                else
                {
                    MessageBox.Show(this, cmbMemberRight.Text + " 的“会员费”参数未设置", "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.errorProvider1.SetError(cmbMemberRight, cmbMemberRight.Text + " 的“会员费”参数未设置");
                }
            }
            else
            {
                this.lblPrepay.Visible = false;
                this.txtPrepay.Visible = false;
            }
            if (this.GetIsDisabledDate(cmbMemberRight.Text))
            {
                if (!Login.constApp.htDisabledDate.ContainsKey(cmbMemberRight.Text))
                {
                    MessageBox.Show(this, cmbMemberRight.Text + " 的“卡有效月份”参数未设置", "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.errorProvider1.SetError(cmbMemberRight, cmbMemberRight.Text + " 的“卡有效月份”参数未设置");
                }
            }
            if (this.GetIsFeeType(cmbMemberRight.Text))
            {
                if (Login.constApp.htFree.ContainsKey(cmbMemberRight.Text))
                {
                    this.errorProvider1.SetError(cmbMemberRight, "");
                }
                else
                {
                    MessageBox.Show(this, cmbMemberRight.Text + " 的“场次”参数未设置", "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.errorProvider1.SetError(cmbMemberRight, cmbMemberRight.Text + " 的“场次”参数未设置");
                }
            }
        }

        private void cmbHandleMan_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbHandleMan.Text))
            {
                cmbHandleManPaperNo.Text = ClientHelper.GetCredentials(cmbHandleMan.Text);
            }
        }
	}
}