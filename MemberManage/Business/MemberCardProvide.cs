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
using ynhrMemberManage.BusinessFacade;
namespace MemberManage.Business
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
		private Infragistics.Win.Misc.UltraLabel ultraLabel10;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtEmail;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCommnets;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPrepay;
		private Infragistics.Win.Misc.UltraLabel ultraLabel14;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDiscount;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbMemberRight;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbEnterpriseType;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel12;
		private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cmdEndDate;
		private Infragistics.Win.Misc.UltraLabel ultraLabel13;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtFact;
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
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSales;
		private Infragistics.Win.Misc.UltraLabel ultraLabel17;
		private Infragistics.Win.Misc.UltraLabel ultraLabel21;
		private Infragistics.Win.Misc.UltraLabel ultraLabel22;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtHandleMan;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtHandleManPaperNo;
		private Infragistics.Win.Misc.UltraLabel ultraLabel23;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbTrade;
		private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox2;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel2;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberPwdConfirm;
		private Infragistics.Win.Misc.UltraLabel ultraLabel24;
		//private Member pMember = null;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCustomerService;
		private Infragistics.Win.Misc.UltraLabel ultraLabel25;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtFax;
		private Infragistics.Win.Misc.UltraLabel ultraLabel26;
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
            this.txtFax = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.txtCustomerService = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMemberPwdConfirm = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel24 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExpandableGroupBox2 = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel2 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.ultraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.txtCommnets = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.cmbTrade = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel23 = new Infragistics.Win.Misc.UltraLabel();
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
            this.txtFact = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.cmdEndDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.txtDiscount = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.cmbEnterpriseType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbMemberRight = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtPrepay = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberPwdConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox2)).BeginInit();
            this.ultraExpandableGroupBox2.SuspendLayout();
            this.ultraExpandableGroupBoxPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommnets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHandleManPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHandleMan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostalcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileTelephone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorporation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnterpriseType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMemberRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrepay)).BeginInit();
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
            this.ultraButton1.Location = new System.Drawing.Point(136, 545);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 31;
            this.ultraButton1.Text = "确定";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // ultraButton2
            // 
            this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton2.Location = new System.Drawing.Point(398, 540);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(75, 23);
            this.ultraButton2.TabIndex = 33;
            this.ultraButton2.Text = "取消";
            this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.txtFax);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel26);
            this.ultraGroupBox2.Controls.Add(this.txtCustomerService);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel25);
            this.ultraGroupBox2.Controls.Add(this.txtMemberPwdConfirm);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel24);
            this.ultraGroupBox2.Controls.Add(this.ultraExpandableGroupBox2);
            this.ultraGroupBox2.Controls.Add(this.cmbTrade);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel23);
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
            this.ultraGroupBox2.Controls.Add(this.txtFact);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel13);
            this.ultraGroupBox2.Controls.Add(this.cmdEndDate);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel12);
            this.ultraGroupBox2.Controls.Add(this.txtDiscount);
            this.ultraGroupBox2.Controls.Add(this.cmbEnterpriseType);
            this.ultraGroupBox2.Controls.Add(this.cmbMemberRight);
            this.ultraGroupBox2.Controls.Add(this.txtPrepay);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel14);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel10);
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
            this.ultraGroupBox2.Controls.Add(this.ultraLabel17);
            this.ultraGroupBox2.Location = new System.Drawing.Point(224, 24);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(608, 568);
            this.ultraGroupBox2.TabIndex = 20;
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
            // txtCustomerService
            // 
            this.txtCustomerService.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtCustomerService.Location = new System.Drawing.Point(424, 344);
            this.txtCustomerService.MaxLength = 20;
            this.txtCustomerService.Name = "txtCustomerService";
            this.txtCustomerService.Size = new System.Drawing.Size(152, 21);
            this.txtCustomerService.TabIndex = 24;
            // 
            // ultraLabel25
            // 
            this.ultraLabel25.Location = new System.Drawing.Point(320, 344);
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
            // ultraExpandableGroupBox2
            // 
            this.ultraExpandableGroupBox2.Controls.Add(this.ultraExpandableGroupBoxPanel2);
            this.ultraExpandableGroupBox2.ExpandedSize = new System.Drawing.Size(560, 144);
            this.ultraExpandableGroupBox2.Location = new System.Drawing.Point(24, 392);
            this.ultraExpandableGroupBox2.Name = "ultraExpandableGroupBox2";
            this.ultraExpandableGroupBox2.Size = new System.Drawing.Size(560, 144);
            this.ultraExpandableGroupBox2.TabIndex = 25;
            this.ultraExpandableGroupBox2.Text = "服务产品";
            // 
            // ultraExpandableGroupBoxPanel2
            // 
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraGrid2);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.txtCommnets);
            this.ultraExpandableGroupBoxPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel2.Location = new System.Drawing.Point(3, 19);
            this.ultraExpandableGroupBoxPanel2.Name = "ultraExpandableGroupBoxPanel2";
            this.ultraExpandableGroupBoxPanel2.Size = new System.Drawing.Size(554, 122);
            this.ultraExpandableGroupBoxPanel2.TabIndex = 0;
            // 
            // ultraGrid2
            // 
            this.ultraGrid2.Location = new System.Drawing.Point(16, 16);
            this.ultraGrid2.Name = "ultraGrid2";
            this.ultraGrid2.Size = new System.Drawing.Size(264, 88);
            this.ultraGrid2.TabIndex = 0;
            this.ultraGrid2.Text = "可用服务产品";
            this.ultraGrid2.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid2_InitializeLayout);
            // 
            // txtCommnets
            // 
            this.txtCommnets.AutoSize = false;
            this.txtCommnets.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtCommnets.Location = new System.Drawing.Point(111, 16);
            this.txtCommnets.MaxLength = 200;
            this.txtCommnets.Multiline = true;
            this.txtCommnets.Name = "txtCommnets";
            this.txtCommnets.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtCommnets.Size = new System.Drawing.Size(440, 88);
            this.txtCommnets.TabIndex = 26;
            this.txtCommnets.Visible = false;
            this.txtCommnets.WordWrap = false;
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
            // txtHandleManPaperNo
            // 
            this.txtHandleManPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtHandleManPaperNo.Location = new System.Drawing.Point(136, 376);
            this.txtHandleManPaperNo.MaxLength = 20;
            this.txtHandleManPaperNo.Name = "txtHandleManPaperNo";
            this.txtHandleManPaperNo.Size = new System.Drawing.Size(152, 21);
            this.txtHandleManPaperNo.TabIndex = 23;
            // 
            // ultraLabel22
            // 
            this.ultraLabel22.Location = new System.Drawing.Point(32, 376);
            this.ultraLabel22.Name = "ultraLabel22";
            this.ultraLabel22.Size = new System.Drawing.Size(104, 23);
            this.ultraLabel22.TabIndex = 45;
            this.ultraLabel22.Text = "经办人身份证号：";
            // 
            // txtHandleMan
            // 
            this.txtHandleMan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtHandleMan.Location = new System.Drawing.Point(136, 344);
            this.txtHandleMan.MaxLength = 20;
            this.txtHandleMan.Name = "txtHandleMan";
            this.txtHandleMan.Size = new System.Drawing.Size(152, 21);
            this.txtHandleMan.TabIndex = 22;
            // 
            // ultraLabel21
            // 
            this.ultraLabel21.Location = new System.Drawing.Point(32, 344);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel21.TabIndex = 43;
            this.ultraLabel21.Text = "经办人：";
            // 
            // txtSales
            // 
            this.txtSales.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtSales.Location = new System.Drawing.Point(424, 312);
            this.txtSales.MaxLength = 20;
            this.txtSales.Name = "txtSales";
            this.txtSales.Size = new System.Drawing.Size(152, 21);
            this.txtSales.TabIndex = 21;
            // 
            // ultraLabel20
            // 
            this.ultraLabel20.Location = new System.Drawing.Point(320, 312);
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
            // txtFact
            // 
            this.txtFact.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtFact.Location = new System.Drawing.Point(136, 312);
            this.txtFact.MaxLength = 8;
            this.txtFact.Name = "txtFact";
            this.txtFact.Size = new System.Drawing.Size(152, 21);
            this.txtFact.TabIndex = 20;
            // 
            // ultraLabel13
            // 
            this.ultraLabel13.Location = new System.Drawing.Point(32, 312);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel13.TabIndex = 28;
            this.ultraLabel13.Text = "实收：";
            // 
            // cmdEndDate
            // 
            this.cmdEndDate.BackColor = System.Drawing.SystemColors.Window;
            this.cmdEndDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.cmdEndDate.Format = "yyyy-MM-dd";
            this.cmdEndDate.Location = new System.Drawing.Point(424, 248);
            this.cmdEndDate.Name = "cmdEndDate";
            this.cmdEndDate.NonAutoSizeHeight = 23;
            this.cmdEndDate.Size = new System.Drawing.Size(152, 21);
            this.cmdEndDate.TabIndex = 17;
            // 
            // ultraLabel12
            // 
            this.ultraLabel12.Location = new System.Drawing.Point(320, 248);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(104, 23);
            this.ultraLabel12.TabIndex = 26;
            this.ultraLabel12.Text = "卡使用时限：";
            // 
            // txtDiscount
            // 
            this.txtDiscount.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtDiscount.Location = new System.Drawing.Point(424, 280);
            this.txtDiscount.MaxLength = 2;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(152, 21);
            this.txtDiscount.TabIndex = 19;
            this.txtDiscount.Validated += new System.EventHandler(this.txtDiscount_Validated);
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
            // txtPrepay
            // 
            this.txtPrepay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPrepay.Enabled = false;
            this.txtPrepay.Location = new System.Drawing.Point(136, 280);
            this.txtPrepay.Name = "txtPrepay";
            this.txtPrepay.Size = new System.Drawing.Size(152, 21);
            this.txtPrepay.TabIndex = 18;
            // 
            // ultraLabel14
            // 
            this.ultraLabel14.Location = new System.Drawing.Point(32, 280);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel14.TabIndex = 20;
            this.ultraLabel14.Text = "会员费：";
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.Location = new System.Drawing.Point(320, 280);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel10.TabIndex = 18;
            this.ultraLabel10.Text = "折扣：";
            // 
            // ultraLabel11
            // 
            this.ultraLabel11.Location = new System.Drawing.Point(32, 473);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel11.TabIndex = 22;
            this.ultraLabel11.Text = "备注：";
            this.ultraLabel11.Visible = false;
            this.ultraLabel11.WrapText = false;
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.Location = new System.Drawing.Point(320, 184);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel9.TabIndex = 16;
            this.ultraLabel9.Text = "企业性质：";
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.Location = new System.Drawing.Point(576, 288);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(16, 16);
            this.ultraLabel17.TabIndex = 21;
            this.ultraLabel17.Text = "折";
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
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(920, 627);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.txtMemberCardNo);
            this.Controls.Add(this.ultraLabel1);
            this.Name = "MemberCardProvide";
            this.Text = Login.constApp.strCardTypeL8Name + "会员信息录入";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberPwdConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox2)).EndInit();
            this.ultraExpandableGroupBox2.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommnets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHandleManPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHandleMan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostalcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileTelephone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorporation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnterpriseType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMemberRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrepay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			try
			{
				#region 数据验证
				//this.txtMemberCardNo_Validated(null,null);
				this.txtMemberName_Validated(null,null);
				this.txtPaperNo_Validated(null,null);	
				this.cmbTrade_Validated(null,null);
				this.cmbEnterpriseType_Validated(null,null);
				//this.txtDiscount_Validated(null,null);
				//string strMemberCardNoError = this.errorProvider1.GetError(txtMemberCardNo);
				string strMemberNameError = this.errorProvider1.GetError(txtMemberName);
				string strPaperNoError = this.errorProvider1.GetError(txtPaperNo);
				string strDiscountError = this.errorProvider1.GetError(txtDiscount);
				string strTrade = this.errorProvider1.GetError(cmbTrade);
				string strEnterpriseType = this.errorProvider1.GetError(cmbEnterpriseType);
//				if (strMemberCardNoError.Length >0)
//				{
//					throw new BusinessException("发卡",strMemberCardNoError);
//				}
				if (strMemberNameError.Length >0)
				{
					throw new BusinessException("发卡",strMemberNameError);
				}
				if (strPaperNoError.Length >0)
				{
					throw new BusinessException("发卡",strPaperNoError);
				}
				if (strDiscountError.Length >0)
				{
					throw new BusinessException("发卡",strDiscountError);
				}
				if (strTrade.Length > 0)
				{
					throw new BusinessException("发卡",strTrade);
				}
				if (strEnterpriseType.Length > 0)
				{
					throw new BusinessException("发卡",strEnterpriseType);
				}
				if (cmbEnterpriseType.Text=="")
				{
					throw new BusinessException("发卡","企业性质不能为空！");
				}
				if (cmbTrade.Text=="")
				{
					throw new BusinessException("发卡","行业不能为空！");
				}
				if (cmbMemberRight.Text=="")
				{
					throw new BusinessException("发卡","会员资格不能为空！");
				}
				if (txtFact.Text.Trim().Length == 0)
				{
					throw new BusinessException("发卡","请输入实收");
				}
				if (txtDiscount.Text.Trim().Length == 0)
				{
					throw new BusinessException("发卡","请输入折扣");
				}
				if (txtMemberPwd.Text.Trim().Length == 0)
				{
					throw new BusinessException("发卡","请输入会员密码");
				}
				//cmbMemberRight_ValueChanged(null,null);
				string strMemberRight = this.errorProvider1.GetError(cmbMemberRight);
				if (strMemberRight.Length >0)
				{
					throw new BusinessException("发卡",strMemberRight);
				}
				if (txtMemberPwd.Text != txtMemberPwdConfirm.Text)
				{
					throw new BusinessException("发卡","会员密码确认和会员密码不同！");
				}
				#endregion
				string strCardNo = Helper.CreateCardNo();
				if (strCardNo == "")
				{
					throw new BusinessException("发卡","卡号生成错误！");
				}
				if (strCardNo == "C0000000")
				{
					throw new BusinessException("发卡","卡号超出限制！");
				}
				
				Member member = new Member();
				member.cnvcComments = txtCommnets.Text;
				member.cnvcDiscount = txtDiscount.Text;
				member.cnvcEmail = txtEmail.Text;
				member.cnvcEnterpriseType = cmbEnterpriseType.Text;
				member.cnvcFree = Login.constApp.htFree[cmbMemberRight.Text].ToString();
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
				member.cnnMemberFee = Decimal.Parse(txtPrepay.Text);
				member.cnnPrepay = Decimal.Parse(txtFact.Text);
				
				member.cndEndDate = cmdEndDate.Text;
				member.cnvcOperName = this.oper.cnvcOperName;
				member.cndOperDate = DateTime.Now;
				member.cndInNetDate = member.cndOperDate;
				member.cnvcMobileTelePhone = txtMobileTelephone.Text;
				member.cnvcPostalCode = txtPostalcode.Text;
				member.cnvcSales = txtSales.Text;
				member.cnvcHandleman = txtHandleMan.Text;
				member.cnvcHandlemanPaperNo = txtHandleManPaperNo.Text;
				member.cnvcTrade = cmbTrade.Text;
				member.cnvcCustomerService = txtCustomerService.Text;
				member.cnvcFax = txtFax.Text;
                MemberManageFacade mm = new MemberManageFacade();

				ArrayList alProduct = new ArrayList();
				string strProduct = "";
				//会员
				foreach (UltraGridRow selRow in this.ultraGrid2.Rows)
				{
					string strSelected = selRow.Cells["cnvcIsSelected"].Value.ToString();
					bool   bSelected = bool.Parse(strSelected);
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
						strProduct += product.cnvcProductName +",,,,"+ product.cnvcFree+",|";
					}
				}
//				if (alProduct.Count < 1)
//				{
//					throw new BusinessException("服务产品消费","请选择充值产品");
//				}
				//MemberManage mm = new MemberManage();
				//mm.ConsumeProduct(alProduct,true,"");

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
					mm.AddMember(member,alProduct,pBill,false);
					MessageBox.Show(this,"入库成功，未发卡","发卡");
					ClearText();
//				}
//				else
//				{
//					this.Close();
//				}
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
			txtDiscount.Text = "100";
			txtFact.Text = "";
			txtMemberPwd.Text = "";
			txtMemberPwdConfirm.Text = "";
			txtMobileTelephone.Text = "";
			txtPostalcode.Text = "";
			txtSales.Text = "";
			txtHandleMan.Text = "";
			txtHandleManPaperNo.Text = "";
			txtCustomerService.Text = "";
			txtFax.Text = "";
			cmbMemberRight_ValueChanged(null,null);
			txtMemberCardNo.Focus();
		}

		private void MemberCardProvide_Load(object sender, System.EventArgs e)
		{
			Helper.AddTodayButton(cmdEndDate);
			//cmdEndDate.MaskInput = "yyyy-mm-dd";
			cmdEndDate.Text = DateTime.Now.AddYears(1).AddDays(1).ToString("yyyy-MM-dd");
			Helper.SetTextBox(txtMemberCardNo,"MemberCardNo");
			Helper.SetTextBox(txtDiscount,"Discount");
			Helper.SetTextBox(txtFact,"Prepay");
			Helper.SetTextBox(txtMemberPwd,"Prepay");
			Helper.SetTextBox(txtMemberPwdConfirm,"Prepay");
			ClientHelper.BindTrade(cmbTrade);
            ClientHelper.BindMemberRight(cmbMemberRight);
            ClientHelper.BindEnterpriseType(cmbEnterpriseType);
//			cmbMemberRight.SelectedIndex = 0;

			this.ultraGrid2.Dock = DockStyle.Fill;

		}

		private void txtMemberCardNo_Validated(object sender, System.EventArgs e)
		{			
			Helper.MemberCardNoValidated(this.txtMemberCardNo,errorProvider1,"new");
		}

		private void txtDiscount_Validated(object sender, System.EventArgs e)
		{
			
			//this.errorProvider1.SetError(txtMemberCardNo,"");	
			try
			{
				string strDiscount = txtDiscount.Text.Trim();
				if (strDiscount == "")
				{
					strDiscount = "100";
					txtDiscount.Text = "100";
				}
				
				string strMemberDiscount = "";//Login.constApp.htMemberDiscount[cmbMemberRight.Text].ToString();
				if (Login.constApp.htMemberDiscount.ContainsKey(cmbMemberRight.Text))
				{
					strMemberDiscount = Login.constApp.htMemberDiscount[cmbMemberRight.Text].ToString();
				}
				else
				{
					throw new BusinessException("参数",cmbMemberRight.Text+"的“折扣”参数未设置");
				}

				string strCuMemberDiscount = "";
				if (int.Parse(strMemberDiscount) > this.iDiscount)
				{
					strCuMemberDiscount = this.iDiscount.ToString();
				}
				else
				{
					strCuMemberDiscount = strMemberDiscount;
				}
				if (int.Parse(strDiscount) <0 || int.Parse(strDiscount) < int.Parse(strCuMemberDiscount) || int.Parse(strDiscount) > 100)
				{
					this.errorProvider1.SetError(txtDiscount,"折扣必须大于零小于等于100,并在权限范围内！");
				}
				else
				{
					this.errorProvider1.SetError(txtDiscount,"");
					int iMemberFee = int.Parse(txtPrepay.Text);
					int iDiscount = int.Parse(txtDiscount.Text);
					string strFact = ((iMemberFee*iDiscount)/100).ToString();
					txtFact.Text = strFact;
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
		


		private void cmbMemberRight_ValueChanged(object sender, System.EventArgs e)
		{
			if (Login.constApp.htDisabledDate.ContainsKey(cmbMemberRight.Text))
			{
				string strDisabledDate = Login.constApp.htDisabledDate[cmbMemberRight.Text].ToString();
				string strCurDate = DateTime.Now.AddMonths(int.Parse(strDisabledDate)).ToString();
				cmdEndDate.Text = strCurDate;
				this.errorProvider1.SetError(cmbMemberRight,"");
			}
			else
			{
				MessageBox.Show(this, cmbMemberRight.Text+" 的“卡有效月份”参数未设置", "参数错误",MessageBoxButtons.OK,MessageBoxIcon.Error);				
				this.errorProvider1.SetError(cmbMemberRight,cmbMemberRight.Text+" 的“卡有效月份”参数未设置");
			}
			if (Login.constApp.htMemberFee.ContainsKey(cmbMemberRight.Text))
			{
				string strMemberFee = Login.constApp.htMemberFee[cmbMemberRight.Text].ToString();
				txtPrepay.Text = strMemberFee;
				this.errorProvider1.SetError(cmbMemberRight,"");
			}
			else
			{
				MessageBox.Show(this, cmbMemberRight.Text+" 的“会员费”参数未设置", "参数错误",MessageBoxButtons.OK,MessageBoxIcon.Error);				
				this.errorProvider1.SetError(cmbMemberRight,cmbMemberRight.Text+" 的“会员费”参数未设置");
			}
			if (Login.constApp.htMemberDiscount.ContainsKey(cmbMemberRight.Text))
			{
				txtDiscount.Text = Login.constApp.htMemberDiscount[cmbMemberRight.Text].ToString();
				this.errorProvider1.SetError(cmbMemberRight,"");
			}
			else
			{
				MessageBox.Show(this, cmbMemberRight.Text+" 的“折扣”参数未设置", "参数错误",MessageBoxButtons.OK,MessageBoxIcon.Error);				
				this.errorProvider1.SetError(cmbMemberRight,cmbMemberRight.Text+" 的“折扣”参数未设置");
			}
			if (Login.constApp.htFree.ContainsKey(cmbMemberRight.Text))
			{
				//txtDiscount.Text = Login.constApp.htMemberDiscount[cmbMemberRight.Text].ToString();
				this.errorProvider1.SetError(cmbMemberRight,"");
			}
			else
			{
				MessageBox.Show(this, cmbMemberRight.Text+" 的“场次”参数未设置", "参数错误",MessageBoxButtons.OK,MessageBoxIcon.Error);				
				this.errorProvider1.SetError(cmbMemberRight,cmbMemberRight.Text+" 的“场次”参数未设置");
			}

			Helper.BindMemberProduct(this.ultraGrid2,cmbMemberRight.Text);

		}

		private void txtMemberPwd_Validated(object sender, System.EventArgs e)
		{
			if (txtMemberPwd.Text == "")
			{
				Random rr = new Random(DateTime.Now.Millisecond);
				rr.Next();
				txtMemberPwd.Text = rr.Next(1000000).ToString();
				txtMemberPwdConfirm.Text = txtMemberPwd.Text;
			}
			
		}

//		private void ultraPrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
//		{
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
//			e.Graphics.DrawString("会员密码：", drawFontBody, drawBrush, 35.0f, 85.0F, drawFormat);
//			e.Graphics.DrawString(pMember.cnvcMemberPwd, drawFontBody, drawBrush, 115.0f, 85.0F, drawFormat);
//			e.Graphics.DrawString("会员费：", drawFontBody, drawBrush, 35.0f, 100.0F, drawFormat);
//			e.Graphics.DrawString(pMember.cnnMemberFee.ToString(), drawFontBody, drawBrush, 115.0f, 100.0F, drawFormat);
//			e.Graphics.DrawString("折扣：", drawFontBody, drawBrush, 35.0f, 115.0F, drawFormat);
//			e.Graphics.DrawString(pMember.cnvcDiscount, drawFontBody, drawBrush, 115.0f, 115.0F, drawFormat);
//			e.Graphics.DrawString("实收：", drawFontBody, drawBrush, 35.0f, 130.0F, drawFormat);
//			e.Graphics.DrawString(pMember.cnnPrepay.ToString(), drawFontBody, drawBrush, 115.0f, 130.0F, drawFormat);
//			e.Graphics.DrawString("免费场次：", drawFontBody, drawBrush, 35.0f, 145.0F, drawFormat);
//			e.Graphics.DrawString(pMember.cnvcFree, drawFontBody, drawBrush, 115.0f, 145.0F, drawFormat);
//			e.Graphics.DrawString("卡使用时限：", drawFontBody, drawBrush, 35.0f, 160.0F, drawFormat);
//			e.Graphics.DrawString(cmdEndDate.Text, drawFontBody, drawBrush, 115.0f, 160.0F, drawFormat);
//			e.Graphics.DrawLine(new Pen(drawBrush,1.0f),0.0f,180.0f,300.0f,180.0f);
//			e.Graphics.DrawString("操作员：", drawFontBody, drawBrush, 35.0f, 180.0F, drawFormat);
//			e.Graphics.DrawString(pMember.cnvcOperName, drawFontBody, drawBrush, 115.0f, 180.0F, drawFormat);
//			e.Graphics.DrawString("操作时间："+DateTime.Now.ToShortDateString(), drawFontBody, drawBrush, 35.0f, 195.0F, drawFormat);
//
//			
//			//e.Graphics
//		}

		private void ultraGrid2_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			e.Layout.Bands[0].Columns["cnvcIsSelected"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
			e.Layout.Bands[0].Columns["cnvcIsSelected"].Header.Caption = "选择";
			e.Layout.Bands[0].Columns["cnnMemberCodeID"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "会员资格";
			e.Layout.Bands[0].Columns["cnvcMemberType"].Header.Caption = "服务产品";
			e.Layout.Bands[0].Columns["cnvcMemberValue"].Header.Caption = "场次";

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


	}
}