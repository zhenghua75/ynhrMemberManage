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
using ynhrMemberManage.BusinessFacade.MemberBusiness;
using MemberManage.Business;

namespace MemberManage.MemberBusiness
{
	/// <summary>
	/// Summary description for FMemberFileModify.
	/// </summary>
    public class FMemberFileModify : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraButton btnQuery;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQPaperNo;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQMemberName;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtHandleManPaperNo;
        private Infragistics.Win.Misc.UltraLabel ultraLabel22;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
		private Infragistics.Win.Misc.UltraLabel ultraLabel20;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPostalcode;
		private Infragistics.Win.Misc.UltraLabel ultraLabel19;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMobileTelephone;
		private Infragistics.Win.Misc.UltraLabel ultraLabel18;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCorporation;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbEnterpriseType;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCommnets;
		private Infragistics.Win.Misc.UltraLabel ultraLabel11;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtEmail;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Infragistics.Win.Misc.UltraButton btnModify;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtLinkPhone;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtLinkAddress;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel23;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtLinkman;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.Misc.UltraLabel ultraLabel24;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		public static bool IsShowing ;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbTrade;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
		private Infragistics.Win.Misc.UltraLabel ultraLabel25;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEndDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmdBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtFax;
		private Infragistics.Win.Misc.UltraLabel ultraLabel26;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbSales;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbHandleMan;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbCustomerService;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FMemberFileModify()
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
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtFax = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbTrade = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.txtHandleManPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel22 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.txtPostalcode = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMobileTelephone = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.txtCorporation = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
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
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel23 = new Infragistics.Win.Misc.UltraLabel();
            this.txtLinkman = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel24 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.cmbSales = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbHandleMan = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbCustomerService = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdBeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHandleManPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostalcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileTelephone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorporation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnterpriseType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommnets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHandleMan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCustomerService)).BeginInit();
            this.SuspendLayout();
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
            this.ultraGroupBox1.Location = new System.Drawing.Point(80, 14);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(824, 88);
            this.ultraGroupBox1.TabIndex = 22;
            this.ultraGroupBox1.Text = "非会员档案查询";
            // 
            // cmbEndDate
            // 
            this.cmbEndDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbEndDate.Location = new System.Drawing.Point(400, 56);
            this.cmbEndDate.MaskInput = "{date} {time}";
            this.cmbEndDate.Name = "cmbEndDate";
            this.cmbEndDate.Size = new System.Drawing.Size(144, 21);
            this.cmbEndDate.TabIndex = 17;
            // 
            // chkEndDate
            // 
            this.chkEndDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.chkEndDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkEndDate.Location = new System.Drawing.Point(280, 56);
            this.chkEndDate.Name = "chkEndDate";
            this.chkEndDate.Size = new System.Drawing.Size(120, 20);
            this.chkEndDate.TabIndex = 19;
            this.chkEndDate.Text = "结束时间";
            // 
            // cmdBeginDate
            // 
            this.cmdBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmdBeginDate.Location = new System.Drawing.Point(400, 24);
            this.cmdBeginDate.MaskInput = "{date} {time}";
            this.cmdBeginDate.Name = "cmdBeginDate";
            this.cmdBeginDate.Size = new System.Drawing.Size(144, 21);
            this.cmdBeginDate.TabIndex = 16;
            // 
            // chkBeginDate
            // 
            this.chkBeginDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.chkBeginDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkBeginDate.Location = new System.Drawing.Point(280, 24);
            this.chkBeginDate.Name = "chkBeginDate";
            this.chkBeginDate.Size = new System.Drawing.Size(120, 20);
            this.chkBeginDate.TabIndex = 18;
            this.chkBeginDate.Text = "开始时间";
            // 
            // btnQuery
            // 
            this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnQuery.Location = new System.Drawing.Point(616, 32);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtQPaperNo
            // 
            this.txtQPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQPaperNo.Location = new System.Drawing.Point(144, 24);
            this.txtQPaperNo.Name = "txtQPaperNo";
            this.txtQPaperNo.Size = new System.Drawing.Size(100, 21);
            this.txtQPaperNo.TabIndex = 5;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(40, 24);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 4;
            this.ultraLabel3.Text = "工商注册号：";
            // 
            // txtQMemberName
            // 
            this.txtQMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQMemberName.Location = new System.Drawing.Point(144, 56);
            this.txtQMemberName.Name = "txtQMemberName";
            this.txtQMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtQMemberName.TabIndex = 3;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(40, 56);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 2;
            this.ultraLabel2.Text = "单位名称：";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.cmbCustomerService);
            this.ultraGroupBox2.Controls.Add(this.cmbHandleMan);
            this.ultraGroupBox2.Controls.Add(this.cmbSales);
            this.ultraGroupBox2.Controls.Add(this.txtFax);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel26);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel25);
            this.ultraGroupBox2.Controls.Add(this.cmbTrade);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel8);
            this.ultraGroupBox2.Controls.Add(this.txtHandleManPaperNo);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel22);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel21);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel20);
            this.ultraGroupBox2.Controls.Add(this.txtPostalcode);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel19);
            this.ultraGroupBox2.Controls.Add(this.txtMobileTelephone);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel18);
            this.ultraGroupBox2.Controls.Add(this.txtCorporation);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel15);
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
            this.ultraGroupBox2.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel23);
            this.ultraGroupBox2.Controls.Add(this.txtLinkman);
            this.ultraGroupBox2.Controls.Add(this.txtMemberName);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel24);
            this.ultraGroupBox2.Location = new System.Drawing.Point(416, 118);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(608, 426);
            this.ultraGroupBox2.TabIndex = 24;
            this.ultraGroupBox2.Text = "非会员档案资料修改";
            // 
            // txtFax
            // 
            this.txtFax.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtFax.Location = new System.Drawing.Point(424, 208);
            this.txtFax.MaxLength = 20;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(152, 21);
            this.txtFax.TabIndex = 14;
            // 
            // ultraLabel26
            // 
            this.ultraLabel26.Location = new System.Drawing.Point(320, 208);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel26.TabIndex = 60;
            this.ultraLabel26.Text = "传真：";
            // 
            // ultraLabel25
            // 
            this.ultraLabel25.Location = new System.Drawing.Point(32, 272);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel25.TabIndex = 55;
            this.ultraLabel25.Text = "客服姓名：";
            // 
            // cmbTrade
            // 
            this.cmbTrade.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbTrade.Location = new System.Drawing.Point(136, 208);
            this.cmbTrade.Name = "cmbTrade";
            this.cmbTrade.Size = new System.Drawing.Size(152, 21);
            this.cmbTrade.TabIndex = 13;
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.Location = new System.Drawing.Point(32, 208);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel8.TabIndex = 53;
            this.ultraLabel8.Text = "行业：";
            // 
            // txtHandleManPaperNo
            // 
            this.txtHandleManPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtHandleManPaperNo.Location = new System.Drawing.Point(424, 272);
            this.txtHandleManPaperNo.MaxLength = 20;
            this.txtHandleManPaperNo.Name = "txtHandleManPaperNo";
            this.txtHandleManPaperNo.Size = new System.Drawing.Size(152, 21);
            this.txtHandleManPaperNo.TabIndex = 17;
            // 
            // ultraLabel22
            // 
            this.ultraLabel22.Location = new System.Drawing.Point(320, 272);
            this.ultraLabel22.Name = "ultraLabel22";
            this.ultraLabel22.Size = new System.Drawing.Size(104, 23);
            this.ultraLabel22.TabIndex = 45;
            this.ultraLabel22.Text = "经办人身份证号：";
            // 
            // ultraLabel21
            // 
            this.ultraLabel21.Location = new System.Drawing.Point(320, 240);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel21.TabIndex = 43;
            this.ultraLabel21.Text = "经办人：";
            // 
            // ultraLabel20
            // 
            this.ultraLabel20.Location = new System.Drawing.Point(32, 240);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel20.TabIndex = 41;
            this.ultraLabel20.Text = "销售人员：";
            // 
            // txtPostalcode
            // 
            this.txtPostalcode.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPostalcode.Location = new System.Drawing.Point(424, 144);
            this.txtPostalcode.MaxLength = 20;
            this.txtPostalcode.Name = "txtPostalcode";
            this.txtPostalcode.Size = new System.Drawing.Size(152, 21);
            this.txtPostalcode.TabIndex = 10;
            // 
            // ultraLabel19
            // 
            this.ultraLabel19.Location = new System.Drawing.Point(320, 144);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel19.TabIndex = 39;
            this.ultraLabel19.Text = "邮政编码：";
            // 
            // txtMobileTelephone
            // 
            this.txtMobileTelephone.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMobileTelephone.Location = new System.Drawing.Point(136, 112);
            this.txtMobileTelephone.MaxLength = 20;
            this.txtMobileTelephone.Name = "txtMobileTelephone";
            this.txtMobileTelephone.Size = new System.Drawing.Size(152, 21);
            this.txtMobileTelephone.TabIndex = 7;
            // 
            // ultraLabel18
            // 
            this.ultraLabel18.Location = new System.Drawing.Point(32, 112);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel18.TabIndex = 37;
            this.ultraLabel18.Text = "手机号码：";
            // 
            // txtCorporation
            // 
            this.txtCorporation.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtCorporation.Location = new System.Drawing.Point(136, 80);
            this.txtCorporation.MaxLength = 20;
            this.txtCorporation.Name = "txtCorporation";
            this.txtCorporation.Size = new System.Drawing.Size(152, 21);
            this.txtCorporation.TabIndex = 5;
            // 
            // ultraLabel15
            // 
            this.ultraLabel15.Location = new System.Drawing.Point(32, 80);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel15.TabIndex = 30;
            this.ultraLabel15.Text = "法人代表：";
            // 
            // cmbEnterpriseType
            // 
            this.cmbEnterpriseType.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbEnterpriseType.Location = new System.Drawing.Point(424, 176);
            this.cmbEnterpriseType.Name = "cmbEnterpriseType";
            this.cmbEnterpriseType.Size = new System.Drawing.Size(152, 21);
            this.cmbEnterpriseType.TabIndex = 12;
            // 
            // txtCommnets
            // 
            this.txtCommnets.AutoSize = false;
            this.txtCommnets.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtCommnets.Location = new System.Drawing.Point(136, 304);
            this.txtCommnets.MaxLength = 200;
            this.txtCommnets.Multiline = true;
            this.txtCommnets.Name = "txtCommnets";
            this.txtCommnets.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtCommnets.Size = new System.Drawing.Size(440, 72);
            this.txtCommnets.TabIndex = 19;
            // 
            // ultraLabel11
            // 
            this.ultraLabel11.Location = new System.Drawing.Point(32, 304);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel11.TabIndex = 22;
            this.ultraLabel11.Text = "备注：";
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.Location = new System.Drawing.Point(320, 176);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel9.TabIndex = 16;
            this.ultraLabel9.Text = "企业性质：";
            // 
            // txtEmail
            // 
            this.txtEmail.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtEmail.Location = new System.Drawing.Point(136, 176);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(152, 21);
            this.txtEmail.TabIndex = 11;
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Location = new System.Drawing.Point(32, 176);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel7.TabIndex = 12;
            this.ultraLabel7.Text = "电子邮箱：";
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnCancel.Location = new System.Drawing.Point(336, 392);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnModify
            // 
            this.btnModify.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnModify.Location = new System.Drawing.Point(200, 392);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 31;
            this.btnModify.Text = "确定";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(32, 144);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel6.TabIndex = 10;
            this.ultraLabel6.Text = "单位地址：";
            // 
            // txtLinkPhone
            // 
            this.txtLinkPhone.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtLinkPhone.Location = new System.Drawing.Point(424, 112);
            this.txtLinkPhone.MaxLength = 20;
            this.txtLinkPhone.Name = "txtLinkPhone";
            this.txtLinkPhone.Size = new System.Drawing.Size(152, 21);
            this.txtLinkPhone.TabIndex = 8;
            // 
            // txtLinkAddress
            // 
            this.txtLinkAddress.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtLinkAddress.Location = new System.Drawing.Point(136, 144);
            this.txtLinkAddress.MaxLength = 200;
            this.txtLinkAddress.Name = "txtLinkAddress";
            this.txtLinkAddress.Size = new System.Drawing.Size(152, 21);
            this.txtLinkAddress.TabIndex = 9;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(320, 112);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel5.TabIndex = 8;
            this.ultraLabel5.Text = "办公电话：";
            // 
            // txtPaperNo
            // 
            this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPaperNo.Enabled = false;
            this.txtPaperNo.Location = new System.Drawing.Point(136, 48);
            this.txtPaperNo.MaxLength = 30;
            this.txtPaperNo.Name = "txtPaperNo";
            this.txtPaperNo.Size = new System.Drawing.Size(152, 21);
            this.txtPaperNo.TabIndex = 3;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(32, 48);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel4.TabIndex = 4;
            this.ultraLabel4.Text = "工商注册号：";
            // 
            // ultraLabel23
            // 
            this.ultraLabel23.Location = new System.Drawing.Point(320, 80);
            this.ultraLabel23.Name = "ultraLabel23";
            this.ultraLabel23.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel23.TabIndex = 6;
            this.ultraLabel23.Text = "联系人：";
            // 
            // txtLinkman
            // 
            this.txtLinkman.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtLinkman.Location = new System.Drawing.Point(424, 80);
            this.txtLinkman.MaxLength = 20;
            this.txtLinkman.Name = "txtLinkman";
            this.txtLinkman.Size = new System.Drawing.Size(152, 21);
            this.txtLinkman.TabIndex = 6;
            // 
            // txtMemberName
            // 
            this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberName.Location = new System.Drawing.Point(424, 48);
            this.txtMemberName.MaxLength = 100;
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(152, 21);
            this.txtMemberName.TabIndex = 4;
            // 
            // ultraLabel24
            // 
            this.ultraLabel24.Location = new System.Drawing.Point(320, 48);
            this.ultraLabel24.Name = "ultraLabel24";
            this.ultraLabel24.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel24.TabIndex = 2;
            this.ultraLabel24.Text = "单位名称：";
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Location = new System.Drawing.Point(8, 118);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(400, 426);
            this.ultraGrid1.TabIndex = 23;
            this.ultraGrid1.Text = "非会员档案";
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            this.ultraGrid1.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.ultraGrid1_AfterSelectChange);
            // 
            // cmbSales
            // 
            this.cmbSales.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbSales.Location = new System.Drawing.Point(136, 240);
            this.cmbSales.Name = "cmbSales";
            this.cmbSales.Size = new System.Drawing.Size(152, 21);
            this.cmbSales.TabIndex = 64;
            // 
            // cmbHandleMan
            // 
            this.cmbHandleMan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbHandleMan.Location = new System.Drawing.Point(424, 237);
            this.cmbHandleMan.Name = "cmbHandleMan";
            this.cmbHandleMan.Size = new System.Drawing.Size(152, 21);
            this.cmbHandleMan.TabIndex = 65;
            // 
            // cmbCustomerService
            // 
            this.cmbCustomerService.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbCustomerService.Location = new System.Drawing.Point(136, 267);
            this.cmbCustomerService.Name = "cmbCustomerService";
            this.cmbCustomerService.Size = new System.Drawing.Size(152, 21);
            this.cmbCustomerService.TabIndex = 66;
            // 
            // FMemberFileModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1028, 557);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGrid1);
            this.Name = "FMemberFileModify";
            this.Text = "非会员修改";
            this.Load += new System.EventHandler(this.FMemberFileModify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdBeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHandleManPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostalcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileTelephone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorporation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnterpriseType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommnets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHandleMan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCustomerService)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void FMemberFileModify_Load(object sender, System.EventArgs e)
		{
			ClientHelper.BindEnterpriseType(cmbEnterpriseType);
			ClientHelper.BindTrade(cmbTrade);
			chkBeginDate.Checked=true;
			chkEndDate.Checked=true;
			cmdBeginDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEndDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmdBeginDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 00:00";
			cmbEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 23:59";

			btnModify.Enabled = false;
            ClientHelper.BindSales(cmbSales);//, this.oper.cnnOperID.ToString());
            ClientHelper.BindSales(cmbHandleMan);//, this.oper.cnnOperID.ToString());
            ClientHelper.BindSales(cmbCustomerService);//, this.oper.cnnOperID.ToString());
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//查询
			try
			{
				string strSql = "select top 100 cnvcMemberName,cnvcPaperNo,cnvcCorporation,cnvcCompanyAddress,cnvcEnterpriseType,cndInNetDate from tbFMember where 1=1 ";
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
		private void ClearText()
		{
			txtCommnets.Text                   = ""  ;
			txtEmail.Text                      = "" 	;
			cmbEnterpriseType.Text             = "" 	;
			txtLinkAddress.Text                = "" 	;
			txtCorporation.Text                = "" 	;
			txtLinkman.Text                    = "" 	;
			txtLinkPhone.Text                  = "" 	;
			txtMemberName.Text                 = "" 	;
			txtPaperNo.Text                    = "" 	;
			txtMobileTelephone.Text            = "" 	;
			txtPostalcode.Text                 = "" 	;
			cmbSales.Text                      = "" 	;
			cmbHandleMan.Text                  = "" 	;
			txtHandleManPaperNo.Text           = "" 	;
			cmbTrade.Text = "";
			cmbCustomerService.Text = "";
			txtFax.Text = "";

		}

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e);
			e.Layout.Bands[0].Columns["cnvcCorporation"].Header.Caption = "法人代表";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcEnterpriseType"].Header.Caption = "企业性质";
			e.Layout.Bands[0].Columns["cnvcCompanyAddress"].Header.Caption = "单位地址";
			e.Layout.Bands[0].Columns["cndInNetDate"].Header.Caption = "入会时间";
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				#region 数据验证				
				if (txtMemberName.Text.Trim().Length == 0)
				{
					throw new BusinessException("发卡","单位名称不能为空");
				}
				if (txtPaperNo.Text.Trim().Length == 0)
				{
					throw new BusinessException("发卡","工商注册号不能为空");
				}

				#endregion
				FMember member = new FMember();
				member.cnvcComments = txtCommnets.Text;
				member.cnvcEmail = txtEmail.Text;
				member.cnvcEnterpriseType = cmbEnterpriseType.Text;
				member.cnvcCompanyAddress = txtLinkAddress.Text;
				member.cnvcCorporation = txtCorporation.Text;
				member.cnvcLinkman = txtLinkman.Text;
				member.cnvcLinkPhone = txtLinkPhone.Text;
				//member.cnvcMemberCardNo = txtMemberCardNo.Text;
				//member.cnvcMemberPwd = txtMemberPwd.Text;
				member.cnvcMemberName = txtMemberName.Text;
				member.cnvcPaperNo = txtPaperNo.Text;
				//member.cndEndDate = cmdEndDate.Text;
				member.cnvcOperName = this.oper.cnvcOperName;
				member.cndOperDate = DateTime.Now;
				member.cnvcMobileTelePhone = txtMobileTelephone.Text;
				member.cnvcPostalCode = txtPostalcode.Text;
				member.cnvcSales = cmbSales.Text;
				member.cnvcHandleman = cmbHandleMan.Text;
				member.cnvcHandlemanPaperNo = txtHandleManPaperNo.Text;
				member.cnvcTrade = cmbTrade.Text;
				member.cnvcCustomerService = cmbCustomerService.Text;
				member.cnvcFax = txtFax.Text;
                MemberManageFacade mm = new MemberManageFacade();
				mm.ModifyFMember(member);
				MessageBox.Show(this,"非会员档案修改成功！","非会员档案修改",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

		private void ultraGrid1_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			try
			{
				UltraGridRow row = this.ultraGrid1.ActiveRow;
				if (null != row)
				{

					string strPaperNo = row.Cells["cnvcPaperNo"].Value.ToString();
					DataTable dtMember = Helper.Query("select * from tbFMember where cnvcPaperNo = '"+strPaperNo+"'");
					if (dtMember.Rows.Count == 0)
					{
						throw new BusinessException("非会员档案修改","查询非会员出错！");
					}

					Member member = new Member(dtMember);

					txtCommnets.Text                  =  member.cnvcComments        ;
					txtEmail.Text                      =  member.cnvcEmail           ;
					cmbEnterpriseType.Text             =  member.cnvcEnterpriseType  ;
					txtLinkAddress.Text                =  member.cnvcCompanyAddress  ;
					txtCorporation.Text                =  member.cnvcCorporation     ;
					txtLinkman.Text                    =  member.cnvcLinkman         ;
					txtLinkPhone.Text                 =  member.cnvcLinkPhone       ;
					//txtMemberCardNo.Text              =  member.cnvcMemberCardNo    ;
					//txtMemberPwd.Text                  =  member.cnvcMemberPwd       ;
					txtMemberName.Text                 =  member.cnvcMemberName      ;
					txtPaperNo.Text                    =  member.cnvcPaperNo         ;
					//cmdEndDate.Text                    =  member.cndEndDate          ;
					txtMobileTelephone.Text            =  member.cnvcMobileTelePhone ;
					txtPostalcode.Text                 =  member.cnvcPostalCode      ;
					cmbSales.Text                      =  member.cnvcSales           ;
					cmbHandleMan.Text                  =  member.cnvcHandleman       ;
					txtHandleManPaperNo.Text           =  member.cnvcHandlemanPaperNo;
					cmbTrade.Text = member.cnvcTrade;
					txtFax.Text = member.cnvcFax;
					cmbCustomerService.Text = member.cnvcCustomerService;

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
	}
}
