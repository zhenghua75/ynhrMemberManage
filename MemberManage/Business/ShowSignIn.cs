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
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Common;
namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for ShowSignIn.
	/// </summary>
    public class ShowSignIn : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraButton btnLoadSeat;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraButton btnSignIn;
		private System.ComponentModel.IContainer components;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Infragistics.Win.Misc.UltraLabel ultraLabel8;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl4;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.Misc.UltraLabel ultraLabel12;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPwd;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPMemberCardNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtFPaperNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtFMemberName;
		public static bool IsShowing ;
		private Infragistics.Win.Printing.UltraPrintDocument ultraPrintDocument1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel13;
		private Infragistics.Win.Misc.UltraLabel ultraLabel14;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid2;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox6;
		private Infragistics.Win.Misc.UltraLabel ultraLabel10;
		private Infragistics.Win.Misc.UltraLabel ultraLabel11;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQPaperNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQMemberCardNo;
		private Infragistics.Win.Misc.UltraButton btnMemberSignIn;
		private Infragistics.Win.Misc.UltraButton btnMemberQuery;
		private Infragistics.Win.Misc.UltraButton btnFMemberQuery;
		private Infragistics.Win.UltraWinTabControl.UltraTabControl tabSignIn;
		private Infragistics.Win.Misc.UltraButton btnBrushCard;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQFMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQFPaperNo;
		private Infragistics.Win.Misc.UltraButton btnFMemberSignIn;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox7;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSeat;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkSeat;
		private Infragistics.Win.Misc.UltraButton btnEnMemberSignIn;
		private Infragistics.Win.Misc.UltraButton btnEnFMemberSignIn;
		private System.Windows.Forms.ToolTip toolTip1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPwdConfirm;
		private Infragistics.Win.Misc.UltraLabel ultraLabel16;
		private Infragistics.Win.Misc.UltraButton btnMemberCancel;
		private Infragistics.Win.Misc.UltraButton btnFMemberCancel;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox8;
		private Infragistics.Win.Misc.UltraLabel lblFree;
		private Infragistics.Win.Misc.UltraLabel lblMemberName;
		private Infragistics.Win.Misc.UltraLabel lblPaperNo;
		private Infragistics.Win.Misc.UltraLabel lblMemberCardNo;
		private Infragistics.Win.Misc.UltraLabel ultraLabel17;
		private Infragistics.Win.Misc.UltraLabel ultraLabel18;
		private Infragistics.Win.Misc.UltraLabel ultraLabel19;
		private Infragistics.Win.Misc.UltraLabel ultraLabel20;
		private Infragistics.Win.Misc.UltraButton ultraButton2;
		private Infragistics.Win.Misc.UltraButton ultraButton3;
		//private Member pMember = null;
		private PrintedBill pBill = null;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbFloors;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbJob;
		private Infragistics.Win.Misc.UltraButton btnMemberChangeSeat;
		private Infragistics.Win.Misc.UltraButton btnFMemberChangeSeat;
		private Infragistics.Win.Misc.UltraButton btnChangeSeat;
		private Infragistics.Win.Misc.UltraButton btnBatchSignIn;//= new PrintedBill();\
		private MemberSeat ms = null;
		public ShowSignIn()
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
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnBatchSignIn = new Infragistics.Win.Misc.UltraButton();
            this.btnLoadSeat = new Infragistics.Win.Misc.UltraButton();
            this.cmbFloors = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbJob = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnBrushCard = new Infragistics.Win.Misc.UltraButton();
            this.btnSignIn = new Infragistics.Win.Misc.UltraButton();
            this.txtPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.btnChangeSeat = new Infragistics.Win.Misc.UltraButton();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGroupBox5 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnMemberCancel = new Infragistics.Win.Misc.UltraButton();
            this.btnMemberQuery = new Infragistics.Win.Misc.UltraButton();
            this.txtQPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.txtQMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.txtQMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox4 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnMemberChangeSeat = new Infragistics.Win.Misc.UltraButton();
            this.txtPwdConfirm = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.btnEnMemberSignIn = new Infragistics.Win.Misc.UltraButton();
            this.txtPwd = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.btnMemberSignIn = new Infragistics.Win.Misc.UltraButton();
            this.txtPMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGroupBox6 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnFMemberCancel = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.txtQFMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.txtQFPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnFMemberQuery = new Infragistics.Win.Misc.UltraButton();
            this.ultraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnFMemberChangeSeat = new Infragistics.Win.Misc.UltraButton();
            this.btnEnFMemberSignIn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.txtFMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.txtFPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnFMemberSignIn = new Infragistics.Win.Misc.UltraButton();
            this.tabSignIn = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraPrintDocument1 = new Infragistics.Win.Printing.UltraPrintDocument(this.components);
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox7 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraButton3 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.chkSeat = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.txtSeat = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ultraGroupBox8 = new Infragistics.Win.Misc.UltraGroupBox();
            this.lblFree = new Infragistics.Win.Misc.UltraLabel();
            this.lblMemberName = new Infragistics.Win.Misc.UltraLabel();
            this.lblPaperNo = new Infragistics.Win.Misc.UltraLabel();
            this.lblMemberCardNo = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFloors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbJob)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).BeginInit();
            this.ultraTabPageControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).BeginInit();
            this.ultraGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).BeginInit();
            this.ultraGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwdConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPMemberCardNo)).BeginInit();
            this.ultraTabPageControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox6)).BeginInit();
            this.ultraGroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQFMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQFPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSignIn)).BeginInit();
            this.tabSignIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox7)).BeginInit();
            this.ultraGroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox8)).BeginInit();
            this.ultraGroupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.ultraGroupBox1);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(268, 406);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.btnBatchSignIn);
            this.ultraGroupBox1.Controls.Add(this.btnLoadSeat);
            this.ultraGroupBox1.Controls.Add(this.cmbFloors);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox1.Controls.Add(this.cmbJob);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(24, 48);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(280, 232);
            this.ultraGroupBox1.TabIndex = 13;
            this.ultraGroupBox1.Text = "座位";
            // 
            // btnBatchSignIn
            // 
            this.btnBatchSignIn.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnBatchSignIn.Location = new System.Drawing.Point(96, 168);
            this.btnBatchSignIn.Name = "btnBatchSignIn";
            this.btnBatchSignIn.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSignIn.TabIndex = 7;
            this.btnBatchSignIn.Text = "批量签到";
            this.btnBatchSignIn.Click += new System.EventHandler(this.btnBatchSignIn_Click);
            // 
            // btnLoadSeat
            // 
            this.btnLoadSeat.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnLoadSeat.Location = new System.Drawing.Point(96, 128);
            this.btnLoadSeat.Name = "btnLoadSeat";
            this.btnLoadSeat.Size = new System.Drawing.Size(75, 23);
            this.btnLoadSeat.TabIndex = 6;
            this.btnLoadSeat.Text = "导入座位图";
            this.btnLoadSeat.Click += new System.EventHandler(this.btnLoadSeat_Click);
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
            this.cmbFloors.Location = new System.Drawing.Point(56, 80);
            this.cmbFloors.Name = "cmbFloors";
            this.cmbFloors.Size = new System.Drawing.Size(160, 21);
            this.cmbFloors.TabIndex = 4;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(16, 80);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(48, 23);
            this.ultraLabel2.TabIndex = 3;
            this.ultraLabel2.Text = "展厅：";
            // 
            // cmbJob
            // 
            this.cmbJob.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbJob.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbJob.Location = new System.Drawing.Point(56, 32);
            this.cmbJob.Name = "cmbJob";
            this.cmbJob.Size = new System.Drawing.Size(160, 21);
            this.cmbJob.TabIndex = 1;
            this.cmbJob.ValueChanged += new System.EventHandler(this.cmbShow_ValueChanged);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(8, 32);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(56, 23);
            this.ultraLabel1.TabIndex = 2;
            this.ultraLabel1.Text = "招聘会：";
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ultraGroupBox3);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(268, 406);
            // 
            // ultraGroupBox3
            // 
            this.ultraGroupBox3.Controls.Add(this.btnBrushCard);
            this.ultraGroupBox3.Controls.Add(this.btnSignIn);
            this.ultraGroupBox3.Controls.Add(this.txtPaperNo);
            this.ultraGroupBox3.Controls.Add(this.ultraLabel6);
            this.ultraGroupBox3.Controls.Add(this.txtMemberName);
            this.ultraGroupBox3.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox3.Controls.Add(this.txtMemberCardNo);
            this.ultraGroupBox3.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox3.Controls.Add(this.btnChangeSeat);
            this.ultraGroupBox3.Location = new System.Drawing.Point(16, 24);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(240, 192);
            this.ultraGroupBox3.TabIndex = 15;
            this.ultraGroupBox3.Text = "会员";
            // 
            // btnBrushCard
            // 
            this.btnBrushCard.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnBrushCard.Location = new System.Drawing.Point(16, 144);
            this.btnBrushCard.Name = "btnBrushCard";
            this.btnBrushCard.Size = new System.Drawing.Size(56, 23);
            this.btnBrushCard.TabIndex = 12;
            this.btnBrushCard.Text = "刷卡";
            this.btnBrushCard.Click += new System.EventHandler(this.BrushCard_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnSignIn.Location = new System.Drawing.Point(88, 144);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(64, 23);
            this.btnSignIn.TabIndex = 7;
            this.btnSignIn.Text = "签到";
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // txtPaperNo
            // 
            this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPaperNo.Enabled = false;
            this.txtPaperNo.Location = new System.Drawing.Point(128, 112);
            this.txtPaperNo.Name = "txtPaperNo";
            this.txtPaperNo.Size = new System.Drawing.Size(100, 21);
            this.txtPaperNo.TabIndex = 5;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(16, 112);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel6.TabIndex = 4;
            this.ultraLabel6.Text = "工商注册号：";
            // 
            // txtMemberName
            // 
            this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberName.Enabled = false;
            this.txtMemberName.Location = new System.Drawing.Point(128, 72);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtMemberName.TabIndex = 3;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(16, 72);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel5.TabIndex = 2;
            this.ultraLabel5.Text = "单位名称：";
            // 
            // txtMemberCardNo
            // 
            this.txtMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberCardNo.Enabled = false;
            this.txtMemberCardNo.Location = new System.Drawing.Point(128, 40);
            this.txtMemberCardNo.Name = "txtMemberCardNo";
            this.txtMemberCardNo.Size = new System.Drawing.Size(100, 21);
            this.txtMemberCardNo.TabIndex = 1;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(16, 40);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel4.TabIndex = 0;
            this.ultraLabel4.Text = "会员卡号：";
            // 
            // btnChangeSeat
            // 
            this.btnChangeSeat.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnChangeSeat.Location = new System.Drawing.Point(168, 144);
            this.btnChangeSeat.Name = "btnChangeSeat";
            this.btnChangeSeat.Size = new System.Drawing.Size(64, 23);
            this.btnChangeSeat.TabIndex = 17;
            this.btnChangeSeat.Text = "换位";
            this.btnChangeSeat.Click += new System.EventHandler(this.btnChangeSeat_Click);
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.ultraGrid1);
            this.ultraTabPageControl3.Controls.Add(this.ultraGroupBox5);
            this.ultraTabPageControl3.Controls.Add(this.ultraGroupBox4);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(268, 406);
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Location = new System.Drawing.Point(24, 112);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(232, 160);
            this.ultraGrid1.TabIndex = 18;
            this.ultraGrid1.Text = "会员信息";
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            this.ultraGrid1.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.ultraGrid1_AfterSelectChange);
            // 
            // ultraGroupBox5
            // 
            this.ultraGroupBox5.Controls.Add(this.btnMemberCancel);
            this.ultraGroupBox5.Controls.Add(this.btnMemberQuery);
            this.ultraGroupBox5.Controls.Add(this.txtQPaperNo);
            this.ultraGroupBox5.Controls.Add(this.ultraLabel13);
            this.ultraGroupBox5.Controls.Add(this.txtQMemberName);
            this.ultraGroupBox5.Controls.Add(this.ultraLabel14);
            this.ultraGroupBox5.Controls.Add(this.txtQMemberCardNo);
            this.ultraGroupBox5.Controls.Add(this.ultraLabel15);
            this.ultraGroupBox5.Location = new System.Drawing.Point(16, 8);
            this.ultraGroupBox5.Name = "ultraGroupBox5";
            this.ultraGroupBox5.Size = new System.Drawing.Size(240, 104);
            this.ultraGroupBox5.TabIndex = 17;
            // 
            // btnMemberCancel
            // 
            this.btnMemberCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnMemberCancel.Location = new System.Drawing.Point(120, 80);
            this.btnMemberCancel.Name = "btnMemberCancel";
            this.btnMemberCancel.Size = new System.Drawing.Size(64, 23);
            this.btnMemberCancel.TabIndex = 13;
            this.btnMemberCancel.Text = "清除";
            this.btnMemberCancel.Click += new System.EventHandler(this.btnMemberCancel_Click);
            // 
            // btnMemberQuery
            // 
            this.btnMemberQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnMemberQuery.Location = new System.Drawing.Point(40, 80);
            this.btnMemberQuery.Name = "btnMemberQuery";
            this.btnMemberQuery.Size = new System.Drawing.Size(64, 23);
            this.btnMemberQuery.TabIndex = 12;
            this.btnMemberQuery.Text = "查询";
            this.btnMemberQuery.Click += new System.EventHandler(this.btnMemberQuery_Click);
            // 
            // txtQPaperNo
            // 
            this.txtQPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQPaperNo.Location = new System.Drawing.Point(126, 56);
            this.txtQPaperNo.Name = "txtQPaperNo";
            this.txtQPaperNo.Size = new System.Drawing.Size(100, 21);
            this.txtQPaperNo.TabIndex = 11;
            // 
            // ultraLabel13
            // 
            this.ultraLabel13.Location = new System.Drawing.Point(14, 56);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel13.TabIndex = 10;
            this.ultraLabel13.Text = "工商注册号：";
            // 
            // txtQMemberName
            // 
            this.txtQMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQMemberName.Location = new System.Drawing.Point(128, 32);
            this.txtQMemberName.Name = "txtQMemberName";
            this.txtQMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtQMemberName.TabIndex = 9;
            // 
            // ultraLabel14
            // 
            this.ultraLabel14.Location = new System.Drawing.Point(14, 32);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel14.TabIndex = 8;
            this.ultraLabel14.Text = "单位名称：";
            // 
            // txtQMemberCardNo
            // 
            this.txtQMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQMemberCardNo.Location = new System.Drawing.Point(128, 8);
            this.txtQMemberCardNo.MaxLength = 8;
            this.txtQMemberCardNo.Name = "txtQMemberCardNo";
            this.txtQMemberCardNo.Size = new System.Drawing.Size(100, 21);
            this.txtQMemberCardNo.TabIndex = 7;
            // 
            // ultraLabel15
            // 
            this.ultraLabel15.Location = new System.Drawing.Point(16, 8);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel15.TabIndex = 6;
            this.ultraLabel15.Text = "会员卡号：";
            // 
            // ultraGroupBox4
            // 
            this.ultraGroupBox4.Controls.Add(this.btnMemberChangeSeat);
            this.ultraGroupBox4.Controls.Add(this.txtPwdConfirm);
            this.ultraGroupBox4.Controls.Add(this.ultraLabel16);
            this.ultraGroupBox4.Controls.Add(this.btnEnMemberSignIn);
            this.ultraGroupBox4.Controls.Add(this.txtPwd);
            this.ultraGroupBox4.Controls.Add(this.ultraLabel9);
            this.ultraGroupBox4.Controls.Add(this.btnMemberSignIn);
            this.ultraGroupBox4.Controls.Add(this.txtPMemberCardNo);
            this.ultraGroupBox4.Controls.Add(this.ultraLabel12);
            this.ultraGroupBox4.Location = new System.Drawing.Point(16, 272);
            this.ultraGroupBox4.Name = "ultraGroupBox4";
            this.ultraGroupBox4.Size = new System.Drawing.Size(248, 128);
            this.ultraGroupBox4.TabIndex = 16;
            this.ultraGroupBox4.Text = "会员";
            // 
            // btnMemberChangeSeat
            // 
            this.btnMemberChangeSeat.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnMemberChangeSeat.Location = new System.Drawing.Point(176, 96);
            this.btnMemberChangeSeat.Name = "btnMemberChangeSeat";
            this.btnMemberChangeSeat.Size = new System.Drawing.Size(64, 23);
            this.btnMemberChangeSeat.TabIndex = 15;
            this.btnMemberChangeSeat.Text = "换位";
            this.btnMemberChangeSeat.Click += new System.EventHandler(this.btnMemberChangeSeat_Click);
            // 
            // txtPwdConfirm
            // 
            this.txtPwdConfirm.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPwdConfirm.Location = new System.Drawing.Point(128, 72);
            this.txtPwdConfirm.Name = "txtPwdConfirm";
            this.txtPwdConfirm.PasswordChar = '*';
            this.txtPwdConfirm.Size = new System.Drawing.Size(100, 21);
            this.txtPwdConfirm.TabIndex = 14;
            // 
            // ultraLabel16
            // 
            this.ultraLabel16.Location = new System.Drawing.Point(16, 72);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel16.TabIndex = 13;
            this.ultraLabel16.Text = "会员密码确认：";
            // 
            // btnEnMemberSignIn
            // 
            this.btnEnMemberSignIn.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnEnMemberSignIn.Location = new System.Drawing.Point(96, 96);
            this.btnEnMemberSignIn.Name = "btnEnMemberSignIn";
            this.btnEnMemberSignIn.Size = new System.Drawing.Size(72, 23);
            this.btnEnMemberSignIn.TabIndex = 12;
            this.btnEnMemberSignIn.Text = "现场签到";
            this.btnEnMemberSignIn.Click += new System.EventHandler(this.btnEnMemberSignIn_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPwd.Location = new System.Drawing.Point(128, 48);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(100, 21);
            this.txtPwd.TabIndex = 11;
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.Location = new System.Drawing.Point(16, 48);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel9.TabIndex = 10;
            this.ultraLabel9.Text = "会员密码：";
            // 
            // btnMemberSignIn
            // 
            this.btnMemberSignIn.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnMemberSignIn.Location = new System.Drawing.Point(24, 96);
            this.btnMemberSignIn.Name = "btnMemberSignIn";
            this.btnMemberSignIn.Size = new System.Drawing.Size(64, 23);
            this.btnMemberSignIn.TabIndex = 8;
            this.btnMemberSignIn.Text = "签到";
            this.btnMemberSignIn.Click += new System.EventHandler(this.MemberSignIn_Click);
            // 
            // txtPMemberCardNo
            // 
            this.txtPMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPMemberCardNo.Location = new System.Drawing.Point(128, 24);
            this.txtPMemberCardNo.MaxLength = 8;
            this.txtPMemberCardNo.Name = "txtPMemberCardNo";
            this.txtPMemberCardNo.Size = new System.Drawing.Size(100, 21);
            this.txtPMemberCardNo.TabIndex = 1;
            // 
            // ultraLabel12
            // 
            this.ultraLabel12.Location = new System.Drawing.Point(16, 24);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel12.TabIndex = 0;
            this.ultraLabel12.Text = "会员卡号：";
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.ultraGroupBox6);
            this.ultraTabPageControl4.Controls.Add(this.ultraGrid2);
            this.ultraTabPageControl4.Controls.Add(this.ultraGroupBox2);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(268, 406);
            // 
            // ultraGroupBox6
            // 
            this.ultraGroupBox6.Controls.Add(this.btnFMemberCancel);
            this.ultraGroupBox6.Controls.Add(this.ultraLabel10);
            this.ultraGroupBox6.Controls.Add(this.txtQFMemberName);
            this.ultraGroupBox6.Controls.Add(this.ultraLabel11);
            this.ultraGroupBox6.Controls.Add(this.txtQFPaperNo);
            this.ultraGroupBox6.Controls.Add(this.btnFMemberQuery);
            this.ultraGroupBox6.Location = new System.Drawing.Point(10, 8);
            this.ultraGroupBox6.Name = "ultraGroupBox6";
            this.ultraGroupBox6.Size = new System.Drawing.Size(248, 104);
            this.ultraGroupBox6.TabIndex = 18;
            this.ultraGroupBox6.Text = "非会员";
            // 
            // btnFMemberCancel
            // 
            this.btnFMemberCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnFMemberCancel.Location = new System.Drawing.Point(136, 72);
            this.btnFMemberCancel.Name = "btnFMemberCancel";
            this.btnFMemberCancel.Size = new System.Drawing.Size(56, 23);
            this.btnFMemberCancel.TabIndex = 17;
            this.btnFMemberCancel.Text = "清除";
            this.btnFMemberCancel.Click += new System.EventHandler(this.btnFMemberCancel_Click);
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.Location = new System.Drawing.Point(32, 24);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel10.TabIndex = 13;
            this.ultraLabel10.Text = "单位名称：";
            // 
            // txtQFMemberName
            // 
            this.txtQFMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQFMemberName.Location = new System.Drawing.Point(136, 24);
            this.txtQFMemberName.Name = "txtQFMemberName";
            this.txtQFMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtQFMemberName.TabIndex = 14;
            // 
            // ultraLabel11
            // 
            this.ultraLabel11.Location = new System.Drawing.Point(24, 48);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel11.TabIndex = 15;
            this.ultraLabel11.Text = "工商注册号：";
            // 
            // txtQFPaperNo
            // 
            this.txtQFPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQFPaperNo.Location = new System.Drawing.Point(136, 48);
            this.txtQFPaperNo.Name = "txtQFPaperNo";
            this.txtQFPaperNo.Size = new System.Drawing.Size(100, 21);
            this.txtQFPaperNo.TabIndex = 16;
            // 
            // btnFMemberQuery
            // 
            this.btnFMemberQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnFMemberQuery.Location = new System.Drawing.Point(64, 72);
            this.btnFMemberQuery.Name = "btnFMemberQuery";
            this.btnFMemberQuery.Size = new System.Drawing.Size(56, 23);
            this.btnFMemberQuery.TabIndex = 9;
            this.btnFMemberQuery.Text = "查询";
            this.btnFMemberQuery.Click += new System.EventHandler(this.btnFMemberQuery_Click);
            // 
            // ultraGrid2
            // 
            this.ultraGrid2.Location = new System.Drawing.Point(18, 112);
            this.ultraGrid2.Name = "ultraGrid2";
            this.ultraGrid2.Size = new System.Drawing.Size(232, 168);
            this.ultraGrid2.TabIndex = 17;
            this.ultraGrid2.Text = "非会员信息";
            this.ultraGrid2.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid2_InitializeLayout);
            this.ultraGrid2.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.ultraGrid2_AfterSelectChange);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.btnFMemberChangeSeat);
            this.ultraGroupBox2.Controls.Add(this.btnEnFMemberSignIn);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel8);
            this.ultraGroupBox2.Controls.Add(this.txtFMemberName);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel7);
            this.ultraGroupBox2.Controls.Add(this.txtFPaperNo);
            this.ultraGroupBox2.Controls.Add(this.btnFMemberSignIn);
            this.ultraGroupBox2.Location = new System.Drawing.Point(16, 280);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(248, 120);
            this.ultraGroupBox2.TabIndex = 16;
            this.ultraGroupBox2.Text = "非会员";
            // 
            // btnFMemberChangeSeat
            // 
            this.btnFMemberChangeSeat.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnFMemberChangeSeat.Location = new System.Drawing.Point(184, 88);
            this.btnFMemberChangeSeat.Name = "btnFMemberChangeSeat";
            this.btnFMemberChangeSeat.Size = new System.Drawing.Size(56, 23);
            this.btnFMemberChangeSeat.TabIndex = 18;
            this.btnFMemberChangeSeat.Text = "换位";
            this.btnFMemberChangeSeat.Click += new System.EventHandler(this.btnFMemberChangeSeat_Click);
            // 
            // btnEnFMemberSignIn
            // 
            this.btnEnFMemberSignIn.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnEnFMemberSignIn.Location = new System.Drawing.Point(96, 88);
            this.btnEnFMemberSignIn.Name = "btnEnFMemberSignIn";
            this.btnEnFMemberSignIn.Size = new System.Drawing.Size(72, 23);
            this.btnEnFMemberSignIn.TabIndex = 17;
            this.btnEnFMemberSignIn.Text = "现场签到";
            this.btnEnFMemberSignIn.Click += new System.EventHandler(this.btnEnFMemberSignIn_Click);
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.Location = new System.Drawing.Point(32, 24);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel8.TabIndex = 13;
            this.ultraLabel8.Text = "单位名称：";
            // 
            // txtFMemberName
            // 
            this.txtFMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtFMemberName.Location = new System.Drawing.Point(136, 24);
            this.txtFMemberName.Name = "txtFMemberName";
            this.txtFMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtFMemberName.TabIndex = 14;
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Location = new System.Drawing.Point(24, 56);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel7.TabIndex = 15;
            this.ultraLabel7.Text = "工商注册号：";
            // 
            // txtFPaperNo
            // 
            this.txtFPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtFPaperNo.Location = new System.Drawing.Point(136, 56);
            this.txtFPaperNo.Name = "txtFPaperNo";
            this.txtFPaperNo.Size = new System.Drawing.Size(100, 21);
            this.txtFPaperNo.TabIndex = 16;
            // 
            // btnFMemberSignIn
            // 
            this.btnFMemberSignIn.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnFMemberSignIn.Location = new System.Drawing.Point(16, 88);
            this.btnFMemberSignIn.Name = "btnFMemberSignIn";
            this.btnFMemberSignIn.Size = new System.Drawing.Size(56, 23);
            this.btnFMemberSignIn.TabIndex = 9;
            this.btnFMemberSignIn.Text = "签到";
            this.btnFMemberSignIn.Click += new System.EventHandler(this.FMemberSignIn_Click);
            // 
            // tabSignIn
            // 
            this.tabSignIn.Controls.Add(this.ultraTabSharedControlsPage1);
            this.tabSignIn.Controls.Add(this.ultraTabPageControl1);
            this.tabSignIn.Controls.Add(this.ultraTabPageControl2);
            this.tabSignIn.Controls.Add(this.ultraTabPageControl3);
            this.tabSignIn.Controls.Add(this.ultraTabPageControl4);
            this.tabSignIn.Location = new System.Drawing.Point(728, 184);
            this.tabSignIn.Name = "tabSignIn";
            this.tabSignIn.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.tabSignIn.Size = new System.Drawing.Size(272, 432);
            this.tabSignIn.TabIndex = 0;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "导入座位";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "会员卡签到";
            ultraTab3.TabPage = this.ultraTabPageControl3;
            ultraTab3.Text = "卡号密码签到";
            ultraTab4.TabPage = this.ultraTabPageControl4;
            ultraTab4.Text = "非会员签到";
            this.tabSignIn.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2,
            ultraTab3,
            ultraTab4});
            this.tabSignIn.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.tabSignIn_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(268, 406);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraLabel3.Location = new System.Drawing.Point(736, 0);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(280, 16);
            this.ultraLabel3.TabIndex = 13;
            this.ultraLabel3.Text = "红色-预订,蓝色-签到,绿色-占位,紫色-充值";
            // 
            // ultraGroupBox7
            // 
            this.ultraGroupBox7.Controls.Add(this.ultraButton3);
            this.ultraGroupBox7.Controls.Add(this.ultraButton2);
            this.ultraGroupBox7.Controls.Add(this.chkSeat);
            this.ultraGroupBox7.Controls.Add(this.ultraButton1);
            this.ultraGroupBox7.Controls.Add(this.txtSeat);
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.ultraGroupBox7.HeaderAppearance = appearance1;
            this.ultraGroupBox7.Location = new System.Drawing.Point(728, 144);
            this.ultraGroupBox7.Name = "ultraGroupBox7";
            this.ultraGroupBox7.Size = new System.Drawing.Size(280, 40);
            this.ultraGroupBox7.TabIndex = 14;
            this.ultraGroupBox7.Text = "重新指定签到座位";
            // 
            // ultraButton3
            // 
            this.ultraButton3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton3.Location = new System.Drawing.Point(152, 16);
            this.ultraButton3.Name = "ultraButton3";
            this.ultraButton3.Size = new System.Drawing.Size(56, 23);
            this.ultraButton3.TabIndex = 16;
            this.ultraButton3.Text = "释放";
            this.ultraButton3.Click += new System.EventHandler(this.ultraButton3_Click);
            // 
            // ultraButton2
            // 
            this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton2.Location = new System.Drawing.Point(216, 16);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(56, 23);
            this.ultraButton2.TabIndex = 15;
            this.ultraButton2.Text = "刷新";
            this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
            // 
            // chkSeat
            // 
            this.chkSeat.Location = new System.Drawing.Point(8, 16);
            this.chkSeat.Name = "chkSeat";
            this.chkSeat.Size = new System.Drawing.Size(48, 24);
            this.chkSeat.TabIndex = 14;
            this.chkSeat.Text = "座位";
            // 
            // ultraButton1
            // 
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton1.Location = new System.Drawing.Point(88, 16);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(56, 23);
            this.ultraButton1.TabIndex = 13;
            this.ultraButton1.Text = "占位";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // txtSeat
            // 
            this.txtSeat.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtSeat.Location = new System.Drawing.Point(56, 16);
            this.txtSeat.Name = "txtSeat";
            this.txtSeat.Size = new System.Drawing.Size(32, 21);
            this.txtSeat.TabIndex = 8;
            // 
            // ultraGroupBox8
            // 
            this.ultraGroupBox8.Controls.Add(this.lblFree);
            this.ultraGroupBox8.Controls.Add(this.lblMemberName);
            this.ultraGroupBox8.Controls.Add(this.lblPaperNo);
            this.ultraGroupBox8.Controls.Add(this.lblMemberCardNo);
            this.ultraGroupBox8.Controls.Add(this.ultraLabel17);
            this.ultraGroupBox8.Controls.Add(this.ultraLabel18);
            this.ultraGroupBox8.Controls.Add(this.ultraLabel19);
            this.ultraGroupBox8.Controls.Add(this.ultraLabel20);
            appearance6.FontData.BoldAsString = "True";
            this.ultraGroupBox8.HeaderAppearance = appearance6;
            this.ultraGroupBox8.Location = new System.Drawing.Point(744, 16);
            this.ultraGroupBox8.Name = "ultraGroupBox8";
            this.ultraGroupBox8.Size = new System.Drawing.Size(264, 128);
            this.ultraGroupBox8.TabIndex = 15;
            // 
            // lblFree
            // 
            this.lblFree.Location = new System.Drawing.Point(96, 104);
            this.lblFree.Name = "lblFree";
            this.lblFree.Size = new System.Drawing.Size(160, 16);
            this.lblFree.TabIndex = 7;
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
            // ultraLabel17
            // 
            appearance2.TextHAlignAsString = "Right";
            this.ultraLabel17.Appearance = appearance2;
            this.ultraLabel17.Location = new System.Drawing.Point(8, 104);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(80, 16);
            this.ultraLabel17.TabIndex = 3;
            this.ultraLabel17.Text = "场次：";
            // 
            // ultraLabel18
            // 
            appearance3.TextHAlignAsString = "Right";
            this.ultraLabel18.Appearance = appearance3;
            this.ultraLabel18.Location = new System.Drawing.Point(8, 64);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(80, 16);
            this.ultraLabel18.TabIndex = 2;
            this.ultraLabel18.Text = "单位名称：";
            // 
            // ultraLabel19
            // 
            appearance4.TextHAlignAsString = "Right";
            this.ultraLabel19.Appearance = appearance4;
            this.ultraLabel19.Location = new System.Drawing.Point(8, 40);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(80, 16);
            this.ultraLabel19.TabIndex = 1;
            this.ultraLabel19.Text = "工商注册号：";
            // 
            // ultraLabel20
            // 
            appearance5.TextHAlignAsString = "Right";
            this.ultraLabel20.Appearance = appearance5;
            this.ultraLabel20.Location = new System.Drawing.Point(8, 16);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(80, 16);
            this.ultraLabel20.TabIndex = 0;
            this.ultraLabel20.Text = "会员卡号：";
            // 
            // ShowSignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1016, 619);
            this.Controls.Add(this.ultraGroupBox8);
            this.Controls.Add(this.ultraGroupBox7);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.tabSignIn);
            this.Name = "ShowSignIn";
            this.Text = Login.constApp.strCardTypeL8Name + "展位签到";
            this.Load += new System.EventHandler(this.ShowSignIn_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFloors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbJob)).EndInit();
            this.ultraTabPageControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            this.ultraGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).EndInit();
            this.ultraTabPageControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).EndInit();
            this.ultraGroupBox5.ResumeLayout(false);
            this.ultraGroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).EndInit();
            this.ultraGroupBox4.ResumeLayout(false);
            this.ultraGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwdConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPMemberCardNo)).EndInit();
            this.ultraTabPageControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox6)).EndInit();
            this.ultraGroupBox6.ResumeLayout(false);
            this.ultraGroupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQFMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQFPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSignIn)).EndInit();
            this.tabSignIn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox7)).EndInit();
            this.ultraGroupBox7.ResumeLayout(false);
            this.ultraGroupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox8)).EndInit();
            this.ultraGroupBox8.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void btnLoadSeat_Click(object sender, System.EventArgs e)
		{			
			LoadPanel();
			if (null != ms)
			{
				this.ultraGroupBox8.Text = ms.cnvcJobName+"●"+ms.cnvcShowName;
			}
			
		}

		#region 展位
		private void LoadSeat(Panel pl,string strFloor,string strJobID)
		{
			string strSql = "select a.*,c.cnvcMemberCardNo,c.cnvcFree from tbShowSeat a"
				+" left outer join tbMemberSeat b on a.cnnJobID=b.cnnID and a.cnvcSeat=b.cnvcSeat and a.cnvcFloor=b.cnvcFloor and (b.cnvcState='预订' or b.cnvcState='签到')"
				+" left outer join tbMember c on b.cnvcMemberCardNo=c.cnvcMemberCardNo"
				+" where a.cnvcFloor='"+strFloor+"' and a.cnnJobID="+strJobID;
			//string strSql = "select * from tbShowSeat where cnvcFloor='"+strFloor+"' and cnnJobID="+strJobID;
//			string strSql = "select a.*,c.cnvcMemberCardNo,c.cnvcPaperNo,c.cnvcMemberName,c.cnvcFree from tbShowSeat a "
//				+" left outer join tbMemberSeat b on a.cnnJobID=b.cnnID "
//				+" and a.cnvcSeat=b.cnvcSeat and a.cnvcFloor=b.cnvcFloor "
//				//+" and  b.cnvcState = '"+ConstApp.Show_Seat_State_Booking+"'"
//				+" left outer join tbMember c on b.cnvcMemberCardNo=c.cnvcMemberCardNo "
//				+" where a.cnvcFloor='"+strFloor+"' and a.cnnJobID="+strJobID;
			DataTable dtSeat = Helper.Query(strSql);
			//DataTable dtSeat = Helper.Query("select * from tbShowSeat where cnvcFloor='"+strFloor+"' and cnnJobID="+strJobID);
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
						//member = new Member(drSeat);
						if (member.cnvcMemberCardNo.Length > 0)
						{
                            if (!string.IsNullOrEmpty(member.cnvcFree))
                            {
                                if (member.cnvcFree != ConstApp.Free_Time_NoLimit)
                                {

                                    int iFree = int.Parse(member.cnvcFree);
                                    if (iFree <= Login.constApp.iTishi)
                                    {
                                        lbl.BackColor = Color.Purple;
                                        //this.toolTip1.SetToolTip(lbl,"【会员卡号】："+member.cnvcMemberCardNo+"\n【工商注册号】："+member.cnvcPaperNo+"\n【单位名称】："+member.cnvcMemberName+"\n【场次】："+member.cnvcFree);
                                    }
                                }
                            }
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
		private void lbl_Click(object sender, EventArgs e)
		{
			Control lCtrl =(sender as Control);
			txtSeat.Text = lCtrl.Text;
			txtSeat.Tag = lCtrl.Text;
			//显示单位信息
			DataTable dtMemberSeat = Helper.Query("select cnvcMemberCardNo,cnvcMemberName,cnvcPaperNo,cnvcState from tbMemberSeat where cnnID="+ms.cnnID.ToString()+" and cnvcSeat = '"+lCtrl.Text+"' and (cnvcState ='"+ConstApp.Show_Seat_State_SignIn+"' or cnvcState='"+ConstApp.Show_Seat_State_Booking+"')");
			Member member = new Member(dtMemberSeat);
			if (dtMemberSeat.Rows.Count > 0)
			{
			
				
				if (member.cnvcMemberCardNo != "")
				{
					DataTable dtMember = Helper.Query("select cnvcFree from tbMember where cnvcMemberCardNo = '"+member.cnvcMemberCardNo+"'");
					if (dtMember.Rows.Count > 0)
					{
						member.cnvcFree = dtMember.Rows[0][0].ToString();
					}
				
				}
			}
			this.lblMemberCardNo.Text = member.cnvcMemberCardNo;
			this.lblMemberName.Text = member.cnvcMemberName;
			this.lblPaperNo.Text = member.cnvcPaperNo;
			this.lblFree.Text = member.cnvcFree;
			ms.cnvcMemberCardNo = member.cnvcMemberCardNo;
			ms.cnvcMemberName = member.cnvcMemberName;
			ms.cnvcPaperNo = member.cnvcPaperNo;
			ms.cnvcState = member.cnvcState;
		
			ms.cnvcSeat = lCtrl.Text;
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
			try
			{
				if (null == cmbJob.SelectedItem)
				{
					throw new BusinessException("展位方案","请选择招聘会");
				}
				if (null == cmbFloors.SelectedItem)
				{
					throw new BusinessException("展位方案","请选择展厅");
				}
				if (null == ms)
				{
					ms = new MemberSeat();
				}	
								
				string strJobID = cmbJob.SelectedItem.DataValue.ToString();
				string strShowID = cmbFloors.SelectedItem.DataValue.ToString();

							
				ms.cnnID = int.Parse(strJobID);
				ms.cnvcJobName = this.cmbJob.Text;
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
		private void ShowSignIn_Load(object sender, System.EventArgs e)
		{
			string strSql = "select * from tbJob where cndEndDate>=getdate() and cndBeginDate <=getdate() ";
            if (Login.constApp.strJobBeginDate != "")
            {
                strSql = "select * from tbJob where convert(varchar(10),cndBeginDate,121)>='" + Login.constApp.strJobBeginDate + "'";
                if (Login.constApp.strJobEndDate != "")
                    strSql += " and convert(varchar(10),cndEndDate,121)<='" + Login.constApp.strJobEndDate + "'";
                strSql += " order by cndBeginDate";
            }
            else
            {
                if (Login.constApp.strJobEndDate != "")
                {
                    strSql = "select * from tbJob where convert(varchar(10),cndEndDate,121)<='" + Login.constApp.strJobEndDate + "'";
                    strSql += " order by cndBeginDate";
                }
            }
			//JobManage jobManage = new JobManage();
			DataTable dtJob = Helper.Query(strSql);//jobManage.GetAllJob();
			cmbJob.DataSource = dtJob;
			cmbJob.ValueMember = "cnnID";
			cmbJob.DisplayMember = "cnvcJobName";
			cmbJob.DataBind();

            //if (ClientHelper.oper.cnnDeptID != 0)
            //{
            //    if(!Login.constApp.alOperFunc.Contains("释放"))
            //    {
            //        this.ultraButton3.Visible = false;
            //    }				
            //}	
            //if (ClientHelper.idept.cnnDeptID != 0)
            //{
            //    if(!Login.constApp.alOperFunc.Contains("换位"))
            //    {
            //        this.btnChangeSeat.Visible = false;
            //        this.btnMemberChangeSeat.Visible = false;
            //        this.btnFMemberChangeSeat.Visible = false;
            //    }				
            //}	

            //if (ClientHelper.idept.cnnDeptID != 0)
            //{
            //    if(!Login.constApp.alOperFunc.Contains("批量签到"))
            //    {
            //        this.btnBatchSignIn.Visible = false;					
            //    }				
            //}	

			//Helper.BindJob(cmbShow);
			this.cmbFloors.Items.Clear();
			btnSignIn.Enabled = false;
			btnChangeSeat.Enabled = false;
			btnMemberSignIn.Enabled = false;
			btnFMemberSignIn.Enabled = false;
		}
		#region  会员卡签到
		private void btnSignIn_Click(object sender, System.EventArgs e)
		{
			//会员卡签到
			try
			{
				if (null == ms)
				{
					throw new BusinessException("展位签到","请选择招聘会及展厅");
				}
				DateTime dtOperDate = DateTime.Now;
				Member member = new Member();
				member.cnvcMemberCardNo = txtMemberCardNo.Text;
				member.cnvcPaperNo = txtPaperNo.Text;
				member.cnvcMemberName = txtMemberName.Text;
				member.cnvcOperName = this.oper.cnvcOperName;
				member.cndOperDate = dtOperDate;

				DataTable dtMember = Helper.Query("select * from tbMember where cnvcMemberCardNo = '"+txtMemberCardNo.Text+"'");
				Member oldMember = new Member(dtMember);
				Job job = new Job();
				job.cnnJobID = ms.cnnID;
				job.cnvcJobName = ms.cnvcJobName;

//				DataTable dtState1 = Helper.Query("select * from tbMember where  cndEndDate < getDate() and cnvcMemberCardNo=" +member.cnvcMemberCardNo);
//				if (dtState1.Rows.Count != 0)
//				{
//					txtPMemberCardNo.Text="";
//					txtPwd.Text="";
//					txtPwdConfirm.Text="";
//					throw new BusinessException("会员状态","会员已经过期，请重新发卡！");
//				}

				if (chkSeat.Checked)
				{
					
					if (ms.cnvcSeat == "")
					{
						throw new BusinessException("展位签到","请选择重新指定展位");
					}
					
					//先取消预订
					MemberCancelBook(member,job);
					//预订指定展位
					string strFloor = ms.cnvcFloor;
					string strSeat = ms.cnvcSeat;
					DataTable dtJob = Helper.Query("select * from tbJob where cnnJobID="+job.cnnJobID);
					if (dtJob.Rows.Count == 0)
					{
						throw new BusinessException("展位签到","未找到招聘会");
					}
					Job oldJob = new Job(dtJob);
					MemberBook(member,oldJob,strFloor,strSeat);
				}
				MemberSeat memberSeat = new MemberSeat(member.ToTable());
				memberSeat.cnnID = job.cnnJobID;
				memberSeat.cnvcJobName = job.cnvcJobName;
				JobManage jobManage = new JobManage();
				
				pBill = new PrintedBill(member.ToTable());				
				pBill.cnvcBillType = ConstApp.Bill_Type_SignIn;
				pBill.cnvcMemberRight = oldMember.cnvcMemberRight;
				
							
				Member retMember = jobManage.MemberSeatSignIn(memberSeat,pBill);	
				//pBill.cnvcFreeLast = retMember.cnvcFree;
				pBill.cnvcSeat = retMember.cnvcSales;
				

				btnSignIn.Enabled = false;
				txtMemberCardNo.Text = "";
				txtMemberName.Text = "";
				txtPaperNo.Text = "";
				chkSeat.Checked = false;

				DataTable dtMemberSeat = Helper.Query("select top 1 cnvcFloor from tbMemberSeat where cnnID="+memberSeat.cnnID+" and cnvcMemberCardNo='"+memberSeat.cnvcMemberCardNo+"'");
				if (dtMemberSeat.Rows.Count > 0)
				{
					string strFloor = dtMemberSeat.Rows[0][0].ToString();
					if (ms.cnvcFloor != strFloor)
					{
					
						DataTable dtShow = Helper.Query("select * from tbShow where cnnShowID="+strFloor);
						if (dtShow.Rows.Count > 0)
						{
							ms.cnvcShowName = dtShow.Rows[0]["cnvcShowName"].ToString();
							cmbFloors.SelectedIndex = cmbFloors.FindString(ms.cnvcShowName);							
						}
					}
				}
				pBill.cnvcShow = ms.cnvcShowName;
				Helper.PrintTicket(pBill);
				btnLoadSeat_Click(null,null);				
				//MessageBox.Show(this,"展位签到成功！","展位签到",MessageBoxButtons.OK,MessageBoxIcon.Information);

				

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

		#region 预订、取消预订
		private void MemberBook(Member member,Job job,string strFloor,string strSeat)
		{
			//会员预订
			string strMemberRight = member.cnvcMemberRight;
			MemberSeat seat = new MemberSeat();
			seat.cnnID = job.cnnJobID;
			seat.cnvcJobName = job.cnvcJobName;
			seat.cnvcMemberCardNo = member.cnvcMemberCardNo;
			seat.cnvcMemberName = member.cnvcMemberName;
			seat.cnvcPaperNo = member.cnvcPaperNo;
			seat.cnvcOperName = member.cnvcOperName;
			seat.cndOperDate = member.cndOperDate;
				
			seat.cnvcSeat = strSeat;
			seat.cnvcFloor = strFloor;
			seat.cnvcState = ConstApp.Show_Seat_State_Booking;
			JobManage jobManage = new JobManage();

			DateTime dtBookBeginDate = job.cndBookBeginDate;
			DateTime dtBookEndDate = job.cndBookEndDate;

			if(Login.constApp.htBookDate.ContainsKey(strMemberRight))
			{
				int iBookDate = int.Parse(Login.constApp.htBookDate[strMemberRight].ToString());
				DateTime dtMemberBookBeginDate = dtBookEndDate.AddDays(iBookDate);
				if (dtBookBeginDate > dtMemberBookBeginDate)
				{
					if (DateTime.Now < dtMemberBookBeginDate)
					{
						throw new BusinessException("展位预订","未到展位预订时间");
					}
				} 
				else
				{
					if (DateTime.Now < dtBookBeginDate)
					{
						throw new BusinessException("展位预订","未到展位预订时间");
					}
				}

			}
			if (DateTime.Now > dtBookEndDate)
			{
				throw new BusinessException("展位预订","已过展位预订时间");
			}
			jobManage.MemberSeatBooking(seat);
		}
		private void MemberCancelBook(Member member,Job job)
		{
			//会员取消预订			
			MemberSeat seat = new MemberSeat();
			seat.cnnID = job.cnnJobID;
			seat.cnvcJobName = job.cnvcJobName;
			seat.cnvcMemberCardNo = member.cnvcMemberCardNo;
			seat.cnvcMemberName = member.cnvcMemberName;
			seat.cnvcPaperNo = member.cnvcPaperNo;
			seat.cnvcOperName = member.cnvcOperName;
			seat.cndOperDate = member.cndOperDate;
			JobManage jobManage = new JobManage();
			jobManage.CancelMemberSeatBooking(seat,"");

		}
		private void FMemberBook(FMember fmember,Job job,string strFloor,string strSeat)
		{			
			//非会员预订
			MemberSeat seat = new MemberSeat();
			seat.cnnID = job.cnnJobID;
			seat.cnvcJobName = job.cnvcJobName;
			seat.cnvcMemberName = fmember.cnvcMemberName;
			seat.cnvcPaperNo = fmember.cnvcPaperNo;
			seat.cnvcOperName = fmember.cnvcOperName;
			seat.cndOperDate = fmember.cndOperDate;

			seat.cnvcSeat = strSeat;
			seat.cnvcFloor = strFloor;
			seat.cnvcState = ConstApp.Show_Seat_State_Booking;//"预订";
			JobManage jobManage = new JobManage();
            MemberManageFacade memberManage = new MemberManageFacade();
				
			DateTime dtBookBeginDate = job.cndBookBeginDate;
			DateTime dtBookEndDate = job.cndBookEndDate;
					
			if (DateTime.Now < dtBookBeginDate)
			{
				throw new BusinessException("展位预订","未到展位预订时间");
			}
			if (DateTime.Now > dtBookEndDate)
			{
				throw new BusinessException("展位预订","已过展位预订时间");
			}
			jobManage.NoMemberSeatBooking(seat,pBill);
		}
		private void FMemberCancelBook(FMember fmember,Job job)
		{	
			//非会员取消预订
			MemberSeat seat = new MemberSeat();
			seat.cnnID = job.cnnJobID;
			seat.cnvcJobName = job.cnvcJobName;
			seat.cnvcMemberName = fmember.cnvcMemberName;
			seat.cnvcPaperNo = fmember.cnvcPaperNo;
			seat.cnvcOperName = fmember.cnvcOperName;
			seat.cndOperDate = fmember.cndOperDate;
			JobManage jobManage = new JobManage();
				
			Job oldJob = new Job();
			jobManage.CancelNoMemberSeatBooking(seat,"");
		}
		#endregion

		#region 卡号密码签到
		private void MemberSignIn_Click(object sender, System.EventArgs e)
		{
			//卡号密码签到
			try
			{			
				if (null == ms)
				{
					throw new BusinessException("签到","请选择招聘会");
				}
				if (txtPMemberCardNo.Text == "")
				{
					throw new BusinessException("签到","卡号不能为空！");
				}
				if (txtPwd.Text == "")
				{
					throw new BusinessException("签到","密码不能为空！");
				}
				UltraGridRow row = this.ultraGrid1.ActiveRow;
				if (null == row)
				{
					throw new BusinessException("签到","请选择会员！");
				}

				if (txtPwd.Text != row.Cells["cnvcMemberPwd"].Value.ToString())
				{
					throw new BusinessException("展位签到","密码错误");
				}
				if (txtPwd.Text != txtPwdConfirm.Text)
				{
					throw new BusinessException("展位签到","密码错误");
				}

                if (row.Cells["cnvcMemberCardNo"].Value.ToString().Length == 6) throw new BusinessException("会员签到", "请选择会员卡（8位）");
				DateTime dtOperDate = DateTime.Now;
				Member member = new Member();
				member.cnvcMemberCardNo = row.Cells["cnvcMemberCardNo"].Value.ToString();
				member.cnvcMemberName = row.Cells["cnvcMemberName"].Value.ToString();
				member.cnvcPaperNo = row.Cells["cnvcPaperNo"].Value.ToString();
				member.cnvcMemberRight = row.Cells["cnvcMemberRight"].Value.ToString();
				string strTime="";
				string strTimeY="";
				string strTimeM="";
				string strTimeD="";
				strTimeY=DateTime.Now.Year.ToString();
				strTimeM=DateTime.Now.Month.ToString();
				strTimeD=DateTime.Now.Day.ToString();
				int aa=Convert.ToInt32(strTimeM);
				int bb=Convert.ToInt32(strTimeD);
				if (aa<10)
				{
					strTimeM="0" + strTimeM;
				}
				if (bb<10)
				{
					strTimeD="0" + strTimeD;
				}

				strTime =strTimeY + "-" +strTimeM + "-" + strTimeD;
                DataTable dtState1 = Helper.Query("select * from tbMember where CAST (case when cndEndDate ='(none)' then '9999-12-31' else cndEndDate end as DateTime) < CAST('" + strTime + "' as DateTime) and cnvcMemberCardNo='" + member.cnvcMemberCardNo + "'");
				if (dtState1.Rows.Count != 0)
				{
					throw new BusinessException("会员状态","会员已经过期，请重新办理会员！");
				}
				

				member.cnvcOperName = this.oper.cnvcOperName;
				member.cndOperDate = dtOperDate;
				Job job = new Job();
				job.cnnJobID = ms.cnnID;//int.Parse(cmbShow.SelectedItem.DataValue.ToString());
				job.cnvcJobName = ms.cnvcJobName;//cmbShow.SelectedItem.DisplayText;
				string strMsg = "招聘会："+ms.cnvcJobName+"\r会员卡号："+member.cnvcMemberCardNo+"\r单位名称："+member.cnvcMemberName+"\r工商注册号："+member.cnvcPaperNo;
				DialogResult ret = MessageBox.Show(this,strMsg,"会员签到信息确认",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if (ret == DialogResult.Yes)
				{
					if (chkSeat.Checked)
					{
						if (ms.cnvcSeat == "")
						{
							throw new BusinessException("展位签到","请选择重新指定展位");
						}
						//先取消预订
						MemberCancelBook(member,job);
						//预订指定展位
						string strFloor = ms.cnvcFloor;//cmbFloor.SelectedItem.DataValue.ToString();
						string strSeat = ms.cnvcSeat;//txtSeat.Text;
						DataTable dtJob = Helper.Query("select * from tbJob where cnnJobID="+job.cnnJobID);
						if (dtJob.Rows.Count == 0)
						{
							throw new BusinessException("展位签到","未找到招聘会");
						}
						Job oldJob = new Job(dtJob);
						MemberBook(member,oldJob,strFloor,strSeat);
					}
					MemberSeat memberSeat = new MemberSeat(member.ToTable());
					memberSeat.cnnID = job.cnnJobID;
					memberSeat.cnvcJobName = job.cnvcJobName;

					pBill = new PrintedBill(member.ToTable());
					pBill.cnvcBillType = ConstApp.Bill_Type_SignIn;
					pBill.cnvcMemberRight = member.cnvcMemberRight;
					JobManage jobManage = new JobManage();					
					Member retMember = jobManage.MemberSeatSignIn(memberSeat,pBill);
					
					pBill.cnvcSeat = retMember.cnvcSales;
					
					//pBill.cnvcFreeLast = retMember.cnvcFree;
					
					DataTable dtMemberSeat = Helper.Query("select top 1 cnvcFloor from tbMemberSeat where cnnID="+memberSeat.cnnID+" and cnvcMemberCardNo='"+memberSeat.cnvcMemberCardNo+"'");
					if (dtMemberSeat.Rows.Count > 0)
					{
						string strFloor = dtMemberSeat.Rows[0][0].ToString();
						if (ms.cnvcFloor != strFloor)
						{
						
							DataTable dtShow = Helper.Query("select * from tbShow where cnnShowID="+strFloor);
							if (dtShow.Rows.Count > 0)
							{
								ms.cnvcShowName = dtShow.Rows[0]["cnvcShowName"].ToString();
								cmbFloors.SelectedIndex = cmbFloors.FindString(ms.cnvcShowName);
								
							}
						}
					}
					pBill.cnvcShow = ms.cnvcShowName;
					Helper.PrintTicket(pBill);
					this.btnLoadSeat_Click(null,null);					
                    txtPwdConfirm.Text="";
					//MessageBox.Show(this,"展位签到成功！","展位签到",MessageBoxButtons.OK,MessageBoxIcon.Information);


					btnMemberQuery_Click(null,null);
					
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

		#endregion

		#region 非会员签到
		private void FMemberSignIn_Click(object sender, System.EventArgs e)
		{
			//非会员签到
			try
			{			
				if (null == ms)
				{
					throw new BusinessException("签到","请选择招聘会");
				}
				UltraGridRow row = this.ultraGrid2.ActiveRow;
				if (null == row)
				{
					throw new BusinessException("签到","请选择会员！");
				}
				if (txtFPaperNo.Text == "")
				{
					throw new BusinessException("签到","工商注册号不能为空！");
				}
				DateTime dtOperDate = DateTime.Now;
				FMember fmember = new FMember();
				fmember.cnvcMemberName = row.Cells["cnvcMemberName"].Value.ToString();
				fmember.cnvcPaperNo = row.Cells["cnvcPaperNo"].Value.ToString();
				fmember.cnvcOperName = this.oper.cnvcOperName;
				fmember.cndOperDate = dtOperDate;

				Job job = new Job();
				job.cnnJobID = ms.cnnID;
				job.cnvcJobName = ms.cnvcJobName;

				string strMsg = "招聘会："+job.cnvcJobName+"\r单位名称："+fmember.cnvcMemberName+"\r工商注册号："+fmember.cnvcPaperNo;
				DialogResult ret = MessageBox.Show(this,strMsg,"非会员签到信息确认",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if (ret == DialogResult.Yes)
				{
					if (chkSeat.Checked)
					{
						if (ms.cnvcSeat == "")
						{
							throw new BusinessException("展位签到","请选择重新指定展位");
						}
						//先取消预订
						FMemberCancelBook(fmember,job);
						//预订指定展位
						string strFloor = ms.cnvcFloor;//cmbFloor.SelectedItem.DataValue.ToString();
						string strSeat = ms.cnvcSeat;//txtSeat.Text;
						DataTable dtJob = Helper.Query("select * from tbJob where cnnJobID="+job.cnnJobID);
						if (dtJob.Rows.Count == 0)
						{
							throw new BusinessException("展位签到","未找到招聘会");
						}
						Job oldJob = new Job(dtJob);
						FMemberBook(fmember,oldJob,strFloor,strSeat);
					}
					MemberSeat memberSeat = new MemberSeat(fmember.ToTable());
					memberSeat.cnnID = job.cnnJobID;
					memberSeat.cnvcJobName = job.cnvcJobName;	
					memberSeat.cnvcMemberName=fmember.cnvcMemberName;
					JobManage jobManage = new JobManage();
					
					string strSeats = jobManage.FMemberSeatSignIn(memberSeat);
					
					pBill = new PrintedBill(fmember.ToTable());	
					pBill.cnvcSeat = strSeats;
					pBill.cnvcBillType = ConstApp.Bill_Type_SignIn;
					
					DataTable dtMemberSeat = Helper.Query("select top 1 cnvcFloor from tbMemberSeat where cnnID="+memberSeat.cnnID+" and cnvcPaperNo='"+memberSeat.cnvcPaperNo+"' and cnvcMemberCardNo is null");
					if (dtMemberSeat.Rows.Count > 0)
					{
						string strFloor = dtMemberSeat.Rows[0][0].ToString();
						if (ms.cnvcFloor != strFloor)
						{
						
							DataTable dtShow = Helper.Query("select * from tbShow where cnnShowID="+strFloor);
							if (dtShow.Rows.Count > 0)
							{
								ms.cnvcShowName = dtShow.Rows[0]["cnvcShowName"].ToString();
								cmbFloors.SelectedIndex = cmbFloors.FindString(ms.cnvcShowName);
							}
						}
					}

					pBill.cnvcShow = ms.cnvcShowName;
					Helper.PrintTicket(pBill);	
					this.btnLoadSeat_Click(null,null);									
					//MessageBox.Show(this,"展位签到成功！","展位签到",MessageBoxButtons.OK,MessageBoxIcon.Information);
					btnFMemberQuery_Click(null,null);
					
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
		#endregion

		#region  刷卡
		private void BrushCard_Click(object sender, System.EventArgs e)
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
                if (strCardNo.Length == 6) throw new BusinessException("会员刷卡签到", "请放入会员卡（8位）");
				DataTable dtMember = Helper.Query("select * from tbMember where cnvcMemberCardNo = '"+strCardNo+"'");
				if (dtMember.Rows.Count == 0)
				{
					throw new BusinessException("展位签到","未找到会员");
				}
                DataTable dtMemberIn = Helper.Query("select * from tbMember where cnvcMemberCardNo = '" + strCardNo + "' and cndInNetDate < '20110228'");
                if (dtMemberIn.Rows.Count != 0)
                {
                    throw new BusinessException("展位签到", "请核对该会员是否已经发6位“一通卡”，未发请用卡号和密码预定和签到！！");
                }
				string strTime="";
				string strTimeY="";
				string strTimeM="";
				string strTimeD="";
				strTimeY=DateTime.Now.Year.ToString();
				strTimeM=DateTime.Now.Month.ToString();
				strTimeD=DateTime.Now.Day.ToString();
				int aa=Convert.ToInt32(strTimeM);
				int bb=Convert.ToInt32(strTimeD);
				if (aa<10)
				{
					strTimeM="0" + strTimeM;
				}
				if (bb<10)
				{
					strTimeD="0" + strTimeD;
				}

				strTime =strTimeY + "-" +strTimeM + "-" + strTimeD;
                DataTable dtState1 = Helper.Query("select * from tbMember where CAST (case when cndEndDate ='(none)' then '9999-12-31' else cndEndDate end as DateTime) < CAST('" + strTime + "' as DateTime) and cnvcMemberCardNo='" + strCardNo + "'");
				if (dtState1.Rows.Count != 0)
				{
					throw new BusinessException("会员状态","会员已经过期，请重新办理会员！");
				}
				Member member = new Member(dtMember);				
			
				txtMemberName.Text = member.cnvcMemberName;
				txtMemberCardNo.Text = member.cnvcMemberCardNo;
				txtPaperNo.Text = member.cnvcPaperNo;
				btnSignIn.Enabled = true;
				btnChangeSeat.Enabled = true;
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

		private void cmbShow_ValueChanged(object sender, System.EventArgs e)
		{
			if (cmbJob.SelectedItem != null)
			{
				string strJobID = cmbJob.SelectedItem.DataValue.ToString();
				Helper.BindShow(cmbFloors,strJobID);
			}
		}
		#region 查找会员
		private void btnMemberQuery_Click(object sender, System.EventArgs e)
		{
			//查找会员
			try
			{
				if (null == ms)
				{
					throw new BusinessException("查找会员","请选择招聘会及展厅");
				}
				string strSql = "select top 10 cnvcMemberCardNo,cnvcMemberName,cnvcPaperNo,cnvcMemberRight,cnvcFree,'' as cnvcBookSeat,cnvcMemberPwd from tbMember where cnvcState = '"+ConstApp.Card_State_InUse+"'";
				if (txtQMemberCardNo.Text.Trim().Length > 0)
				{
					strSql += " and cnvcMemberCardNo like '%"+txtQMemberCardNo.Text+"%'";
				}
				if (txtQMemberName.Text.Trim().Length > 0)
				{
					strSql += " and cnvcMemberName like '%"+txtQMemberName.Text+"%'";
				}
				if (txtQPaperNo.Text.Trim().Length > 0)
				{
					strSql += " and cnvcPaperNo like '%"+txtQPaperNo.Text+"%'";
				}
				DataTable dtMember = Helper.Query(strSql);

				if (dtMember.Rows.Count > 0)
				{
					foreach (DataRow drMember in dtMember.Rows)
					{
						Member member = new Member(drMember);
						string strSql2 = "select cnvcSeat  from tbMemberSeat where cnvcMemberCardNo = '"+member.cnvcMemberCardNo+"' and cnvcState='"+ConstApp.Show_Seat_State_Booking+"' and cnnID="+ms.cnnID.ToString();
						DataTable dtMemberSeat = Helper.Query(strSql2);
						string strRet = "";
						if (dtMemberSeat.Rows.Count > 0)
						{
							foreach (DataRow drMemberSeat in dtMemberSeat.Rows)
							{
								strRet += drMemberSeat["cnvcSeat"].ToString()+",";
							}
							drMember["cnvcBookSeat"] = strRet;
						}
					}
				}
				this.ultraGrid1.DataSource = null;
				this.ultraGrid1.DataSource = dtMember;
				this.ultraGrid1.DataBind();	
			
				txtPMemberCardNo.Text = "";
				txtPwd.Text = "";

				txtQMemberCardNo.Text = "";
				txtQMemberName.Text = "";
				txtQPaperNo.Text = "";

				txtSeat.Text = "";
				txtSeat.Tag = null;

				chkSeat.Checked = false;

				btnMemberSignIn.Enabled = false;


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

		#region ultraGrid1
		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e);
			e.Layout.Bands[0].Columns["cnvcMemberPwd"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "会员卡号";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Header.Caption = "会员资格";
			e.Layout.Bands[0].Columns["cnvcFree"].Header.Caption = "场次";
			e.Layout.Bands[0].Columns["cnvcBookSeat"].Header.Caption = "已预订展位";

			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Width = 60;
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Width = 100;
			e.Layout.Bands[0].Columns["cnvcFree"].Width = 60;
		}

		private void ultraGrid1_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			UltraGridRow row = this.ultraGrid1.ActiveRow;
			if (row != null)
			{
				txtPMemberCardNo.Text = row.Cells["cnvcMemberCardNo"].Value.ToString();
				//txtPMemberName.Text = row.Cells["cnvcMemberName"].Value.ToString();
				txtPwd.Tag = row.Cells["cnvcMemberPwd"].Value.ToString();

				txtQMemberCardNo.Text = row.Cells["cnvcMemberCardNo"].Value.ToString();
				txtQMemberName.Text = row.Cells["cnvcMemberName"].Value.ToString();
				txtQPaperNo.Text = row.Cells["cnvcPaperNo"].Value.ToString();

				btnMemberSignIn.Enabled = true;
			}
		}
		#endregion

		#region 查找非会员
		private void btnFMemberQuery_Click(object sender, System.EventArgs e)
		{
			//查找非会员
			try
			{
				if (null == ms)
				{
					throw new BusinessException("查找会员","请选择招聘会及展厅");
				}
				string strSql = "select top 10 cnvcMemberName,cnvcPaperNo,'' as cnvcBookSeat from tbFMember where 1=1";				
				if (txtQFMemberName.Text.Trim().Length > 0)
				{
					strSql += " and cnvcMemberName like '%"+txtQFMemberName.Text+"%'";
				}
				if (txtQFPaperNo.Text.Trim().Length > 0)
				{
					strSql += " and cnvcPaperNo like '%"+txtQFPaperNo.Text+"%'";
				}
				DataTable dtMember = Helper.Query(strSql);

				if (dtMember.Rows.Count > 0)
				{
					foreach (DataRow drMember in dtMember.Rows)
					{
						FMember member = new FMember(drMember);
						string strSql2 = "select cnvcSeat  from tbMemberSeat where cnvcMemberCardNo is null and cnvcPaperNo = '"+member.cnvcPaperNo+"' and cnvcState='"+ConstApp.Show_Seat_State_Booking+"' and cnnID="+ms.cnnID.ToString();
						DataTable dtMemberSeat = Helper.Query(strSql2);
						string strRet = "";
						if (dtMemberSeat.Rows.Count > 0)
						{
							foreach (DataRow drMemberSeat in dtMemberSeat.Rows)
							{
								strRet += drMemberSeat["cnvcSeat"].ToString()+",";
							}
							drMember["cnvcBookSeat"] = strRet;
						}
					}
				}
				this.ultraGrid2.DataSource = null;
				this.ultraGrid2.DataSource = dtMember;
				this.ultraGrid2.DataBind();		
		
				txtFMemberName.Text = "";
				txtFPaperNo.Text = "";

				txtQFMemberName.Text = "";
				txtQFPaperNo.Text = "";

				txtSeat.Text = "";
				txtSeat.Tag = null;
				chkSeat.Checked = false;

				btnFMemberSignIn.Enabled = false;

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

		#region ultraGrid2
		private void ultraGrid2_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e);
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcBookSeat"].Header.Caption = "已预订展位";

		}

		private void ultraGrid2_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			UltraGridRow row = this.ultraGrid2.ActiveRow;
			if (row != null)
			{
				txtFMemberName.Text = row.Cells["cnvcMemberName"].Value.ToString();
				txtFPaperNo.Text = row.Cells["cnvcPaperNo"].Value.ToString();

				txtQFMemberName.Text = row.Cells["cnvcMemberName"].Value.ToString();
				txtQFPaperNo.Text = row.Cells["cnvcPaperNo"].Value.ToString();

				btnFMemberSignIn.Enabled = true;
			}
		}
		#endregion

		#region  占位
		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			//占位
			try
			{
				if (ms.cnvcSeat == "")
				{
					throw new BusinessException("展位签到","请选择要占展位");
				}
				if (null == ms)
				{
					throw new BusinessException("展位签到","请选择招聘会及展厅");
				}

				ShowSeat seat = new ShowSeat();
				seat.cnvcSeat = txtSeat.Text;
				seat.cnnJobID = ms.cnnID;//int.Parse(cmbShow.SelectedItem.DataValue.ToString());
				seat.cnvcFloor = ms.cnvcFloor;//cmbFloor.SelectedItem.DataValue.ToString();
				seat.cnvcOperName = this.oper.cnvcOperName;
				seat.cndOperDate = DateTime.Now;

				DataTable dtSeat = Helper.Query("select * from tbShowSeat where cnnJobID="+seat.cnnJobID+" and cnvcState='"+seat.cnvcOperName+"'");
				if (dtSeat.Rows.Count > 0)
				{
					ShowSeat oldSeat = new ShowSeat(dtSeat);
					throw new BusinessException("展位签到","你已经占了一个位置，不能再占了。你占的位置是："+oldSeat.cnvcSeat);
				}
				JobManage jm = new JobManage();
				jm.HoldSeat(seat);
				MessageBox.Show(this, "占位成功", "展位签到",MessageBoxButtons.OK,MessageBoxIcon.Information);				
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
		#endregion

		#region 强制非会员签到
		private void btnEnFMemberSignIn_Click(object sender, System.EventArgs e)
		{
			//强制非会员签到
			try
			{			
				if (null == ms)
				{
					throw new BusinessException("签到","请选择招聘会");
				}
				UltraGridRow row = this.ultraGrid2.ActiveRow;
				if (null == row)
				{
					throw new BusinessException("签到","请选择会员！");
				}
				if (txtFPaperNo.Text == "")
				{
					throw new BusinessException("签到","工商注册号不能为空！");
				}
				DateTime dtOperDate = DateTime.Now;
				FMember fmember = new FMember();
				fmember.cnvcMemberName = row.Cells["cnvcMemberName"].Value.ToString();
				fmember.cnvcPaperNo = row.Cells["cnvcPaperNo"].Value.ToString();
				fmember.cnvcOperName = this.oper.cnvcOperName;
				fmember.cndOperDate = dtOperDate;

				Job job = new Job();
				job.cnnJobID = ms.cnnID;
				job.cnvcJobName = ms.cnvcJobName;

				string strMsg = "招聘会："+job.cnvcJobName+"\r单位名称："+fmember.cnvcMemberName+"\r工商注册号："+fmember.cnvcPaperNo;
				DialogResult ret = MessageBox.Show(this,strMsg,"非会员签到信息确认",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if (ret == DialogResult.Yes)
				{
					MemberSeat memberSeat = new MemberSeat(fmember.ToTable());
					memberSeat.cnnID = job.cnnJobID;
					memberSeat.cnvcJobName = job.cnvcJobName;					
					JobManage jobManage = new JobManage();
					string strSeats = jobManage.EnFMemberSeatSignIn(memberSeat);

					pBill = new PrintedBill(fmember.ToTable());
					pBill.cnvcBillType = ConstApp.Bill_Type_SignIn;
					pBill.cnvcSeat = strSeats;
					//MessageBox.Show(this,"展位签到成功！","展位签到",MessageBoxButtons.OK,MessageBoxIcon.Information);
					DataTable dtMemberSeat = Helper.Query("select top 1 cnvcFloor from tbMemberSeat where cnnID="+memberSeat.cnnID+" and cnvcPaperNo='"+memberSeat.cnvcPaperNo+"' and cnvcMemberCardNo is null");
					if (dtMemberSeat.Rows.Count > 0)
					{
						string strFloor = dtMemberSeat.Rows[0][0].ToString();
						if (ms.cnvcFloor != strFloor)
						{
						
							DataTable dtShow = Helper.Query("select * from tbShow where cnnShowID="+strFloor);
							if (dtShow.Rows.Count > 0)
							{
								ms.cnvcShowName = dtShow.Rows[0]["cnvcShowName"].ToString();
								cmbFloors.SelectedIndex = cmbFloors.FindString(ms.cnvcShowName);
								//pBill.cnvcShow = strShowName;
							}
						}
					}
					pBill.cnvcShow = ms.cnvcShowName;
					Helper.PrintTicket(pBill);
					this.btnLoadSeat_Click(null,null);					
					btnFMemberQuery_Click(null,null);
					
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
		#endregion

		#region 强制卡号密码签到
		private void btnEnMemberSignIn_Click(object sender, System.EventArgs e)
		{
			//强制卡号密码签到
			try
			{			
				if (null == ms)
				{
					throw new BusinessException("签到","请选择招聘会");
				}
				if (txtPMemberCardNo.Text == "")
				{
					throw new BusinessException("签到","卡号不能为空！");
				}
				UltraGridRow row = this.ultraGrid1.ActiveRow;
				if (null == row)
				{
					throw new BusinessException("签到","请选择会员！");
				}
                if (row.Cells["cnvcMemberCardNo"].Value.ToString().Length == 6) throw new BusinessException("会员签到", "请选择会员卡（8位）");
				DateTime dtOperDate = DateTime.Now;
				Member member = new Member();
				member.cnvcMemberCardNo = row.Cells["cnvcMemberCardNo"].Value.ToString();
				member.cnvcMemberName = row.Cells["cnvcMemberName"].Value.ToString();
				member.cnvcPaperNo = row.Cells["cnvcPaperNo"].Value.ToString();
				member.cnvcMemberRight = row.Cells["cnvcMemberRight"].Value.ToString();
				member.cnvcOperName = this.oper.cnvcOperName;
				member.cndOperDate = dtOperDate;

				string strTime="";
				string strTimeY="";
				string strTimeM="";
				string strTimeD="";
				strTimeY=DateTime.Now.Year.ToString();
				strTimeM=DateTime.Now.Month.ToString();
				strTimeD=DateTime.Now.Day.ToString();
				int aa=Convert.ToInt32(strTimeM);
				int bb=Convert.ToInt32(strTimeD);
				if (aa<10)
				{
					strTimeM="0" + strTimeM;
				}
				if (bb<10)
				{
					strTimeD="0" + strTimeD;
				}

				strTime =strTimeY + "-" +strTimeM + "-" + strTimeD;
                DataTable dtState1 = Helper.Query("select * from tbMember where CAST (case when cndEndDate ='(none)' then '9999-12-31' else cndEndDate end as DateTime) < CAST('" + strTime + "' as DateTime) and cnvcMemberCardNo='" + member.cnvcMemberCardNo + "'");
				if (dtState1.Rows.Count != 0)
				{
					throw new BusinessException("会员状态","会员已经过期，请重新办理会员！");
				}

				Job job = new Job();
				job.cnnJobID = ms.cnnID;
				job.cnvcJobName = ms.cnvcJobName;
				string strMsg = "招聘会："+ms.cnvcJobName+"\r会员卡号："+member.cnvcMemberCardNo+"\r单位名称："+member.cnvcMemberName+"\r工商注册号："+member.cnvcPaperNo;
				DialogResult ret = MessageBox.Show(this,strMsg,"会员签到信息确认",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if (ret == DialogResult.Yes)
				{
					MemberSeat memberSeat = new MemberSeat(member.ToTable());
					memberSeat.cnnID = job.cnnJobID;
					memberSeat.cnvcJobName = job.cnvcJobName;

					JobManage jobManage = new JobManage();					
					//Member retMember = jobManage.MemberSeatSignIn(memberSeat,pBill);
					
					pBill = new PrintedBill(member.ToTable());
					pBill.cnvcBillType = ConstApp.Bill_Type_SignIn;
					Member retMember = jobManage.MemberSeatSignIn(memberSeat,pBill);
					pBill.cnvcSeat = retMember.cnvcSales;
					//pBill.cnvcFreeLast = retMember.cnvcFree;
					//MessageBox.Show(this,"展位签到成功！","展位签到",MessageBoxButtons.OK,MessageBoxIcon.Information);
					
					DataTable dtMemberSeat = Helper.Query("select top 1 cnvcFloor from tbMemberSeat where cnnID="+memberSeat.cnnID+" and cnvcMemberCardNo='"+memberSeat.cnvcMemberCardNo+"'");
					if (dtMemberSeat.Rows.Count > 0)
					{
						string strFloor = dtMemberSeat.Rows[0][0].ToString();
						if (ms.cnvcFloor != strFloor)
						{						
							DataTable dtShow = Helper.Query("select * from tbShow where cnnShowID="+strFloor);
							if (dtShow.Rows.Count > 0)
							{
								ms.cnvcShowName = dtShow.Rows[0]["cnvcShowName"].ToString();
								cmbFloors.SelectedIndex = cmbFloors.FindString(ms.cnvcShowName);
								//pBill.cnvcShow = strShowName;							
							}
						}
					}
					pBill.cnvcShow = ms.cnvcShowName;
					Helper.PrintTicket(pBill);
					this.btnLoadSeat_Click(null,null);
					btnMemberQuery_Click(null,null);
					
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
		#endregion

		private void btnMemberCancel_Click(object sender, System.EventArgs e)
		{
			this.txtQMemberCardNo.Text = "";
			this.txtQPaperNo.Text = "";
			this.txtQMemberName.Text = "";
		}

		private void btnFMemberCancel_Click(object sender, System.EventArgs e)
		{
			this.txtQFMemberName.Text = "";
			this.txtQFPaperNo.Text = "";
		}

		private void ultraButton2_Click(object sender, System.EventArgs e)
		{
			//刷新展位
			btnLoadSeat_Click(null,null);
		}

		private void ultraButton3_Click(object sender, System.EventArgs e)
		{
			//释放展位
			try
			{
				if (MessageBox.Show(this,"是否要进行释放展位操作？","释放",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.No)
				{
					return;
				}
				
				if (null == ms)
				{
					throw new BusinessException("释放","请选择招聘会及展厅");
				}
				if (ms.cnvcSeat == "")
				{
					throw new BusinessException("释放","请选择展位");
				}
				if (ms.cnvcState != ConstApp.Show_Seat_State_SignIn)
				{
					throw new BusinessException("释放","请选择已签到展位");
				}

                MemberManageFacade mm = new MemberManageFacade();
				ms.cnvcOperName = this.oper.cnvcOperName;
				ms.cndOperDate = DateTime.Now;
				mm.ReleaseSeat(ms);
				MessageBox.Show(this,"展位释放成功","释放展位",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

		private void btnChangeSeat_Click(object sender, System.EventArgs e)
		{
			//刷卡换位
			try
			{
				if (MessageBox.Show(this,"是否要进行换位操作？","换位",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.No)
				{
					return;
				}
				if (null == ms)
				{
					throw new BusinessException("换位","请选择招聘会及展厅");
				}
				if (ms.cnvcSeat == "")
				{
					throw new BusinessException("换位","请选择展位");
				}
				if (ms.cnvcState != "")
				{
					throw new BusinessException("换位","请选择空展位");
				}
				ms.cnvcMemberCardNo = this.txtMemberCardNo.Text;
				ms.cnvcPaperNo = this.txtPaperNo.Text;
				ms.cnvcMemberName = this.txtMemberName.Text;
				ms.cnvcOperName = this.oper.cnvcOperName;
				ms.cndOperDate = DateTime.Now;
                MemberManageFacade mm = new MemberManageFacade();
				mm.ChangeSeat(ms);
				MessageBox.Show(this,"换位成功","换位",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

		private void btnMemberChangeSeat_Click(object sender, System.EventArgs e)
		{
			//卡号密码换位
			try
			{
				if (MessageBox.Show(this,"是否要进行换位操作？","换位",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.No)
				{
					return;
				}
				if (null == ms)
				{
					throw new BusinessException("换位","请选择招聘会及展厅");
				}
				if (ms.cnvcSeat == "")
				{
					throw new BusinessException("换位","请选择展位");
				}
				if (ms.cnvcState != "")
				{
					throw new BusinessException("换位","请选择空展位");
				}
				ms.cnvcMemberCardNo = this.txtPMemberCardNo.Text;
//				ms.cnvcPaperNo = this.txtPaperNo.Text;
//				ms.cnvcMemberName = this.txtMemberName.Text;
				ms.cnvcOperName = this.oper.cnvcOperName;
				ms.cndOperDate = DateTime.Now;
                MemberManageFacade mm = new MemberManageFacade();
				mm.ChangeSeat(ms);
				MessageBox.Show(this,"换位成功","换位",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

		private void btnFMemberChangeSeat_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (MessageBox.Show(this,"是否要进行换位操作？","换位",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.No)
				{
					return;
				}
				if (null == ms)
				{
					throw new BusinessException("换位","请选择招聘会及展厅");
				}
				if (ms.cnvcSeat == "")
				{
					throw new BusinessException("换位","请选择展位");
				}
				if (ms.cnvcState != "")
				{
					throw new BusinessException("换位","请选择空展位");
				}
				//ms.cnvcMemberCardNo = this.txtMemberCardNo.Text;
				ms.cnvcPaperNo = this.txtFPaperNo.Text;
				ms.cnvcMemberName = this.txtFMemberName.Text;
				ms.cnvcOperName = this.oper.cnvcOperName;
				ms.cndOperDate = DateTime.Now;
                MemberManageFacade mm = new MemberManageFacade();
				mm.ChangeSeat(ms);
				MessageBox.Show(this,"换位成功","换位",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

		private void btnBatchSignIn_Click(object sender, System.EventArgs e)
		{
			//批量签到
			try
			{
				
				if (null == cmbJob.SelectedItem)
				{
					throw new BusinessException("批量签到","请选择招聘会");
				}
				
				
				if (MessageBox.Show(this,"是否要对【"+cmbJob.SelectedItem.DisplayText+"】招聘会进行批量签到操作？","批量签到",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.No)
				{
					return;
				}
				Job job = new Job();
				job.cnnJobID = int.Parse(cmbJob.SelectedItem.DataValue.ToString());
				job.cnvcOperName = this.oper.cnvcOperName;
				job.cndOperDate = DateTime.Now;
				
				JobManage jm = new JobManage();
				jm.BatchSignIn(job);
				MessageBox.Show(this,"批量签到成功","批量签到",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

		private void tabSignIn_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
		{
		
		}

	}
}
