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
namespace MemberManage.MemberReport
{
	/// <summary>
	/// Summary description for InMoneyReport.
	/// </summary>
    public class InMoneyReport : frmBase
	{
		private Infragistics.Win.Printing.UltraPrintPreviewDialog ultraPrintPreviewDialog1;
		private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraButton btnExcel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEndDate;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbOperName;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.Misc.UltraButton btnQuery;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.UltraWinGrid.UltraGridPrintDocument ultraGridPrintDocument1;
		private System.ComponentModel.IContainer components;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbState;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbMemberRight;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbSales;
        private Infragistics.Win.Misc.UltraLabel ultraLabel20;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDept;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbOperType;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
		public static bool IsShowing ;
		public InMoneyReport()
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
            this.ultraPrintPreviewDialog1 = new Infragistics.Win.Printing.UltraPrintPreviewDialog(this.components);
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmbDept = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbSales = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbMemberRight = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbState = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnExcel = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.chkEndDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkBeginDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cmbEndDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.cmbBeginDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.cmbOperName = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.btnQuery = new Infragistics.Win.Misc.UltraButton();
            this.txtPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGridPrintDocument1 = new Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(this.components);
            this.cmbOperType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMemberRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOperName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOperType)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraPrintPreviewDialog1
            // 
            this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.cmbOperType);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel8);
            this.ultraGroupBox2.Controls.Add(this.cmbDept);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel7);
            this.ultraGroupBox2.Controls.Add(this.cmbSales);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel20);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel6);
            this.ultraGroupBox2.Controls.Add(this.cmbMemberRight);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox2.Controls.Add(this.cmbState);
            this.ultraGroupBox2.Controls.Add(this.btnExcel);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox2.Controls.Add(this.chkEndDate);
            this.ultraGroupBox2.Controls.Add(this.chkBeginDate);
            this.ultraGroupBox2.Controls.Add(this.cmbEndDate);
            this.ultraGroupBox2.Controls.Add(this.cmbBeginDate);
            this.ultraGroupBox2.Controls.Add(this.cmbOperName);
            this.ultraGroupBox2.Controls.Add(this.ultraButton1);
            this.ultraGroupBox2.Controls.Add(this.btnQuery);
            this.ultraGroupBox2.Controls.Add(this.txtPaperNo);
            this.ultraGroupBox2.Controls.Add(this.txtMemberName);
            this.ultraGroupBox2.Controls.Add(this.txtMemberCardNo);
            this.ultraGroupBox2.Location = new System.Drawing.Point(16, 24);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(1102, 150);
            this.ultraGroupBox2.TabIndex = 6;
            this.ultraGroupBox2.Text = "查找";
            // 
            // cmbDept
            // 
            this.cmbDept.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbDept.Location = new System.Drawing.Point(928, 31);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(152, 21);
            this.cmbDept.TabIndex = 69;
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Location = new System.Drawing.Point(826, 31);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel7.TabIndex = 68;
            this.ultraLabel7.Text = "部门：";
            // 
            // cmbSales
            // 
            this.cmbSales.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbSales.Location = new System.Drawing.Point(656, 108);
            this.cmbSales.Name = "cmbSales";
            this.cmbSales.Size = new System.Drawing.Size(152, 21);
            this.cmbSales.TabIndex = 63;
            // 
            // ultraLabel20
            // 
            this.ultraLabel20.Location = new System.Drawing.Point(554, 108);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel20.TabIndex = 62;
            this.ultraLabel20.Text = "销售人员：";
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(290, 112);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel6.TabIndex = 47;
            this.ultraLabel6.Text = "会员资格：";
            // 
            // cmbMemberRight
            // 
            this.cmbMemberRight.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbMemberRight.Location = new System.Drawing.Point(392, 112);
            this.cmbMemberRight.Name = "cmbMemberRight";
            this.cmbMemberRight.Size = new System.Drawing.Size(144, 21);
            this.cmbMemberRight.TabIndex = 46;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(290, 72);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel4.TabIndex = 39;
            this.ultraLabel4.Text = "会员状态：";
            // 
            // cmbState
            // 
            this.cmbState.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbState.Location = new System.Drawing.Point(392, 72);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(144, 21);
            this.cmbState.TabIndex = 38;
            // 
            // btnExcel
            // 
            this.btnExcel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnExcel.Location = new System.Drawing.Point(1021, 106);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 37;
            this.btnExcel.Text = "导出EXCEL";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(290, 32);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel5.TabIndex = 36;
            this.ultraLabel5.Text = "操作员：";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(26, 112);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 34;
            this.ultraLabel3.Text = "单位名称：";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(26, 72);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 33;
            this.ultraLabel2.Text = "工商注册号：";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(26, 32);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 32;
            this.ultraLabel1.Text = "会员卡号：";
            // 
            // chkEndDate
            // 
            this.chkEndDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkEndDate.Location = new System.Drawing.Point(554, 72);
            this.chkEndDate.Name = "chkEndDate";
            this.chkEndDate.Size = new System.Drawing.Size(100, 23);
            this.chkEndDate.TabIndex = 31;
            this.chkEndDate.Text = "操作结束时间";
            // 
            // chkBeginDate
            // 
            this.chkBeginDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkBeginDate.Location = new System.Drawing.Point(554, 32);
            this.chkBeginDate.Name = "chkBeginDate";
            this.chkBeginDate.Size = new System.Drawing.Size(100, 23);
            this.chkBeginDate.TabIndex = 30;
            this.chkBeginDate.Text = "操作开始时间";
            // 
            // cmbEndDate
            // 
            this.cmbEndDate.DateTime = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
            this.cmbEndDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbEndDate.Location = new System.Drawing.Point(656, 72);
            this.cmbEndDate.MaskInput = "{date} {time}";
            this.cmbEndDate.Name = "cmbEndDate";
            this.cmbEndDate.Size = new System.Drawing.Size(144, 21);
            this.cmbEndDate.TabIndex = 29;
            this.cmbEndDate.Value = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
            // 
            // cmbBeginDate
            // 
            this.cmbBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbBeginDate.Location = new System.Drawing.Point(656, 32);
            this.cmbBeginDate.MaskInput = "{date} {time}";
            this.cmbBeginDate.Name = "cmbBeginDate";
            this.cmbBeginDate.Size = new System.Drawing.Size(144, 21);
            this.cmbBeginDate.TabIndex = 28;
            // 
            // cmbOperName
            // 
            this.cmbOperName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbOperName.Location = new System.Drawing.Point(392, 32);
            this.cmbOperName.Name = "cmbOperName";
            this.cmbOperName.Size = new System.Drawing.Size(144, 21);
            this.cmbOperName.TabIndex = 27;
            // 
            // ultraButton1
            // 
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton1.Location = new System.Drawing.Point(928, 106);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 19;
            this.ultraButton1.Text = "打印";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnQuery.Location = new System.Drawing.Point(838, 106);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 18;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtPaperNo
            // 
            this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPaperNo.Location = new System.Drawing.Point(128, 72);
            this.txtPaperNo.Name = "txtPaperNo";
            this.txtPaperNo.Size = new System.Drawing.Size(136, 21);
            this.txtPaperNo.TabIndex = 17;
            // 
            // txtMemberName
            // 
            this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberName.Location = new System.Drawing.Point(128, 112);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(136, 21);
            this.txtMemberName.TabIndex = 15;
            // 
            // txtMemberCardNo
            // 
            this.txtMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberCardNo.Location = new System.Drawing.Point(128, 32);
            this.txtMemberCardNo.Name = "txtMemberCardNo";
            this.txtMemberCardNo.Size = new System.Drawing.Size(136, 21);
            this.txtMemberCardNo.TabIndex = 13;
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.ultraGrid1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(16, 197);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(1102, 347);
            this.ultraGroupBox1.TabIndex = 7;
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
            // cmbOperType
            // 
            this.cmbOperType.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbOperType.Location = new System.Drawing.Point(928, 71);
            this.cmbOperType.Name = "cmbOperType";
            this.cmbOperType.Size = new System.Drawing.Size(152, 21);
            this.cmbOperType.TabIndex = 71;
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.Location = new System.Drawing.Point(826, 71);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel8.TabIndex = 70;
            this.ultraLabel8.Text = "类型：";
            // 
            // InMoneyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1186, 557);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "InMoneyReport";
            this.Text = "一通卡充值报表";
            this.Load += new System.EventHandler(this.InMoneyReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMemberRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOperName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOperType)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void InMoneyReport_Load(object sender, System.EventArgs e)
		{
			this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti; 
			ClientHelper.BindMemberRight(cmbMemberRight);
			cmbBeginDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEndDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbBeginDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 00:00";
			cmbEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 23:59";
            //DataTable dtOper = Helper.Query("select * from tbOper where cnvcOperName <> 'admin'");			

            //cmbOperName.DataSource = dtOper;
            //cmbOperName.DisplayMember = "cnvcOperName";
            //cmbOperName.ValueMember = "cnnOperID";
            
            ClientHelper.BindOper(cmbOperName, this.oper,this.dept);
			//绑定会员状态
			DataTable dtState = new DataTable();
			//dtState.Columns.Add("cnvcState");
			dtState.Columns.Add("会员状态");

			DataRow drState0 = dtState.NewRow();
			//drState0["cnvcState"] = "0";
			drState0["会员状态"] = ConstApp.Card_State_InUse;

			dtState.Rows.Add(drState0);

			DataRow drState1 = dtState.NewRow();
			//drState1["cnvcState"] = "1";
			drState1["会员状态"] = ConstApp.Card_State_InLose;

			dtState.Rows.Add(drState1);

			DataRow drState2 = dtState.NewRow();
			//drState2["cnvcState"] = "2";
			drState2["会员状态"] = ConstApp.Card_State_InAdd;

			dtState.Rows.Add(drState2);

			DataRow drState3 = dtState.NewRow();
			//drState2["cnvcState"] = "2";
			drState3["会员状态"] = ConstApp.Card_State_InCallBack;

			dtState.Rows.Add(drState3);

			
			cmbState.DataSource = dtState;
			//cmbState.DisplayMember = "会员状态";
			//cmbState.ValueMember = "cnvcState";
			cmbState.DataBind();	
			//cmbState.SelectedIndex = 0;

			//Helper.BindJob(cmbShow);
            DataTable dtOperType = new DataTable();
            dtOperType.Columns.Add("操作类型");
            DataRow drOperType0 = dtOperType.NewRow();
            drOperType0["操作类型"] = ConstApp.Fee_Flag_Card;
            dtOperType.Rows.Add(drOperType0);

            DataRow drOperType1 = dtOperType.NewRow();
            drOperType1["操作类型"] = ConstApp.Fee_Flag_InMoney;
            dtOperType.Rows.Add(drOperType1);

            cmbOperType.DataSource = dtOperType;
            cmbOperType.DataBind();

			this.ultraGrid1.Dock       = DockStyle.Fill;
			this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
			this.ultraGroupBox1.BringToFront();

            //if (ClientHelper.idept.cnnDeptID != 0)
            //{
            //    if(!Login.constApp.alOperFunc.Contains("充值报表查询"))
            //    {
            //        this.btnQuery.Enabled = false;
            //    }
            //    if(!Login.constApp.alOperFunc.Contains("充值报表打印"))
            //    {
            //        this.ultraButton1.Enabled = false;
            //        btnExcel.Enabled = false;
            //    }
            //}
            ClientHelper.BindSales(cmbSales, this.oper.cnnOperID.ToString());
            ClientHelper.BindDept(cmbDept, this.oper.cnnOperID.ToString());
		}

		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			Helper.Print(this,ultraGrid1,ultraGridPrintDocument1,ultraPrintPreviewDialog1);
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
            ClientHelper.ExportExcel(saveFileDialog1, ultraGridExcelExporter1, ultraGrid1, "云南人才市场充值报表", this.oper.cnvcOperName);
		}

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e); 

			e.Layout.Bands[0].Columns["cnvcState"].Header.Caption = "会员状态";	
			e.Layout.Bands[0].Columns["cndEndDate"].Header.Caption = "卡使用时限";
            e.Layout.Bands[0].Columns["cnvcOperFlag"].Header.Caption = "类型";
			e.Layout.Bands[0].Columns["cnnMemberFee"].Header.Caption = "会员费";
            //e.Layout.Bands[0].Columns["cnnMemberFee"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcFreeBalance"].Header.Caption = "场次余额";
            e.Layout.Bands[0].Columns["cnvcFreeBalance"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "会员卡号";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Header.Caption = "会员资格";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "充值金额";
			e.Layout.Bands[0].Columns["cnvcFree"].Header.Caption = "免费场次";
            //e.Layout.Bands[0].Columns["cnvcFree"].Hidden = true;
			e.Layout.Bands[0].Columns["cnnBalance"].Header.Caption = "缴费";
			e.Layout.Bands[0].Columns["cnvcDiscount"].Header.Caption = "折扣";
            e.Layout.Bands[0].Columns["cnvcDeptName"].Header.Caption = "部门";
            e.Layout.Bands[0].Columns["cnvcSales"].Header.Caption = "销售人员";
			e.Layout.Bands[0].Columns["cnvcOperName"].Header.Caption = "操作员名称";
			e.Layout.Bands[0].Columns["cndOperDate"].Header.Caption = "操作时间";

			e.Layout.Bands[0].Columns["cndOperDate"].CellActivation = Activation.NoEdit;
			e.Layout.Bands[0].Columns["cndOperDate"].Format = "yyyy-MM-dd hh:mm";

            //e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "充值金额";
            e.Layout.Bands[0].Columns["cnnLastBalance"].Header.Caption = "上次余额";
            e.Layout.Bands[0].Columns["cnnBalance"].Header.Caption = "当前余额";
            e.Layout.Bands[0].Columns["cnnDonate"].Header.Caption = "赠送金额";

			e.Layout.Bands[0].SummaryFooterCaption = "合计："; 
		}

		private void ultraGrid1_InitializePrint(object sender, Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs e)
		{
			Helper.PrintDisplay(e,"云南人才市场充值报表");	
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			try
			{
				//string strSql = "select cnnJobID,'' as cnvcJobName,cnvcMemberCardNo,cnvcPaperNo,'' as cnvcMemberName,cnnPrepay,cnnReturn,cnnBalance,cnvcState,cnvcOperName,cndOperDate from tbPrepay where 1=1 ";
                string strSql = "select a.cnvcMemberCardNo,a.cnvcMemberName,a.cnvcPaperNo,a.cnvcMemberRight,a.cnnMemberFee,a.cnvcDiscount,b.cnvcOperFlag,a.cnvcFree as cnvcFreeBalance,b.cnnLastBalance,b.cnnPrepay,b.cnnDonate,b.cnnBalance,b.cnvcFree,a.cnvcState,a.cndEndDate,case when e.cnvcDeptName is null then '云南人才市场' else e.cnvcDeptName end as cnvcDeptName,b.cnvcSales,b.cnvcOperName,b.cndOperDate from tbMemberPrepayLog b"
					          + " left outer join tbMember a on a.cnvcMemberCardNo = b.cnvcMemberCardNo";
				//strSql += " where a.cnvcState<>'"+ConstApp.Card_State_InAdd+"'  and b.cnvcOperFlag='"+ConstApp.Fee_Flag_InMoney+"'";
                //strSql += " left join tbOper c on b.cnvcOperName=c.cnvcOperName left join tbDept d on c.cnnDeptID=d.cnnDeptID ";
                strSql += " left join tbSales c on b.cnvcSales=c.cnvcSales left join tbOperDept d on c.cnnDeptID=d.cnnDeptID and c.cnnSales=d.cnnOperID left join tbDept e on c.cnnDeptID=e.cnnDeptID";
                //if (this.oper.cnnDeptID != 0)
                //{
                    
                //    //strSql += " where (d.cnnParentDeptID=" + this.oper.cnnDeptID.ToString() + " or d.cnnDeptID=" + this.oper.cnnDeptID.ToString() + ")  and ";
                //    strSql += string.Format(" where d.cnnOperID={0} and ", this.oper.cnnOperID.ToString());
                //}
                //else
                //{
                    strSql += " where ";
                //}
                    strSql += " LEN(b.cnvcMemberCardNo)=6 ";
				if (txtMemberCardNo.Text.Trim().Length > 0)
				{
					strSql += " and a.cnvcMemberCardNo like '%"+txtMemberCardNo.Text+"%'";
				}
				if (txtMemberName.Text!="")
				{
					strSql += " and a.cnvcMemberName like '%"+txtMemberName.Text+"%'";
				}
				if (txtPaperNo.Text.Trim().Length > 0)
				{
					strSql += " and a.cnvcPaperNo like '%"+txtPaperNo.Text+"%'";
				}
				if (cmbOperName.Text.Trim().Length > 0)
				{
					strSql += " and b.cnvcOperName like '%"+cmbOperName.Text+"%'";
				}
				if (chkBeginDate.Checked)
				{
					strSql += " and b.cndOperDate >= '"+cmbBeginDate.Value.ToString()+"'";
				}
				if (chkEndDate.Checked)
				{
					strSql += " and b.cndOperDate <= '"+cmbEndDate.Value.ToString()+"'";
				}
				if (cmbState.Text.Trim().Length > 0)
				{
					strSql += " and a.cnvcState = '"+cmbState.Text+"'";
				}
				if (cmbMemberRight.Text.Trim().Length > 0)
				{
					strSql += " and a.cnvcMemberRight = '"+cmbMemberRight.Text+"'";
				}
                if (cmbSales.Text.Trim().Length > 0)
                {
                    strSql += " and b.cnvcSales='"+cmbSales.Text+"'";
                }
                if (cmbDept.Text.Trim().Length > 0)
                {
                    strSql += " and e.cnvcDeptName='" + cmbDept.Text + "'";
                }
                if (cmbOperType.Text.Trim().Length > 0)
                {
                    strSql+=" and b.cnvcOperFlag='" + cmbOperType.Text + "'";

                }
				DataTable dtPrepay = Helper.Query(strSql);
				this.ultraGrid1.DataSource = null;
				this.ultraGrid1.DataSource = dtPrepay;
				this.ultraGrid1.DataBind();

                ClientHelper.AddGridColumn(this.ultraGrid1, this.oper.cnvcOperName);
				Helper.AddGridSummary(this.ultraGrid1,SummaryType.Count,"充值条数：{0}","cnvcPaperNo");		
				Helper.AddGridSummary(this.ultraGrid1,SummaryType.Sum,"充值总额：{0}","cnnPrepay");		
				//Helper.AddGridSummary(this.ultraGrid1,SummaryType.Sum,"免费场次余额总额：{0}","cnvcFreeBalance");		
				//Helper.AddGridSummary(this.ultraGrid1,SummaryType.Sum,"缴费总额：{0}","cnnBalance");		
				//Helper.AddGridSummary(this.ultraGrid1,SummaryType.Sum,"场次总额：{0}","cnvcFree");	
				//Helper.AddGridSummary(this.ultraGrid1,SummaryType.Sum,"会员费总额：{0}","cnnMemberFee");	
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
