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
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ultraComboEditor1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbSales;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDept;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
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
            this.cmbSales = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.txtPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraComboEditor1 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
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
            this.cmbDept = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMemberRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOperName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDept)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.cmbDept);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel8);
            this.ultraGroupBox2.Controls.Add(this.cmbSales);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel21);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel6);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel7);
            this.ultraGroupBox2.Controls.Add(this.txtPaperNo);
            this.ultraGroupBox2.Controls.Add(this.txtMemberName);
            this.ultraGroupBox2.Controls.Add(this.txtMemberCardNo);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox2.Controls.Add(this.ultraComboEditor1);
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
            this.ultraGroupBox2.Location = new System.Drawing.Point(48, 32);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(1144, 152);
            this.ultraGroupBox2.TabIndex = 8;
            this.ultraGroupBox2.Text = "查找";
            // 
            // cmbSales
            // 
            this.cmbSales.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbSales.Location = new System.Drawing.Point(961, 45);
            this.cmbSales.Name = "cmbSales";
            this.cmbSales.Size = new System.Drawing.Size(144, 21);
            this.cmbSales.TabIndex = 61;
            // 
            // ultraLabel21
            // 
            this.ultraLabel21.Location = new System.Drawing.Point(857, 46);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel21.TabIndex = 60;
            this.ultraLabel21.Text = "销售人员：";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(42, 112);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 53;
            this.ultraLabel3.Text = "单位名称：";
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(42, 77);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel6.TabIndex = 52;
            this.ultraLabel6.Text = "工商注册号：";
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Location = new System.Drawing.Point(42, 40);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel7.TabIndex = 51;
            this.ultraLabel7.Text = "会员卡号：";
            // 
            // txtPaperNo
            // 
            this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPaperNo.Location = new System.Drawing.Point(146, 77);
            this.txtPaperNo.Name = "txtPaperNo";
            this.txtPaperNo.Size = new System.Drawing.Size(136, 21);
            this.txtPaperNo.TabIndex = 50;
            // 
            // txtMemberName
            // 
            this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberName.Location = new System.Drawing.Point(146, 111);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(136, 21);
            this.txtMemberName.TabIndex = 49;
            // 
            // txtMemberCardNo
            // 
            this.txtMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberCardNo.Location = new System.Drawing.Point(146, 40);
            this.txtMemberCardNo.Name = "txtMemberCardNo";
            this.txtMemberCardNo.Size = new System.Drawing.Size(136, 21);
            this.txtMemberCardNo.TabIndex = 48;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(566, 43);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(96, 23);
            this.ultraLabel2.TabIndex = 47;
            this.ultraLabel2.Text = "是否工本费：";
            // 
            // ultraComboEditor1
            // 
            this.ultraComboEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.ultraComboEditor1.Location = new System.Drawing.Point(670, 43);
            this.ultraComboEditor1.Name = "ultraComboEditor1";
            this.ultraComboEditor1.Size = new System.Drawing.Size(144, 21);
            this.ultraComboEditor1.TabIndex = 46;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(301, 113);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(96, 23);
            this.ultraLabel1.TabIndex = 45;
            this.ultraLabel1.Text = "会员资格：";
            // 
            // cmbMemberRight
            // 
            this.cmbMemberRight.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbMemberRight.Location = new System.Drawing.Point(405, 113);
            this.cmbMemberRight.Name = "cmbMemberRight";
            this.cmbMemberRight.Size = new System.Drawing.Size(144, 21);
            this.cmbMemberRight.TabIndex = 44;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(301, 81);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(96, 23);
            this.ultraLabel4.TabIndex = 43;
            this.ultraLabel4.Text = "是否会员：";
            // 
            // cmbMember
            // 
            this.cmbMember.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbMember.Location = new System.Drawing.Point(405, 81);
            this.cmbMember.Name = "cmbMember";
            this.cmbMember.Size = new System.Drawing.Size(144, 21);
            this.cmbMember.TabIndex = 42;
            // 
            // btnExcel
            // 
            this.btnExcel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnExcel.Location = new System.Drawing.Point(1039, 111);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 37;
            this.btnExcel.Text = "导出EXCEL";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(301, 41);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel5.TabIndex = 36;
            this.ultraLabel5.Text = "操作员：";
            // 
            // chkEndDate
            // 
            this.chkEndDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkEndDate.Location = new System.Drawing.Point(566, 119);
            this.chkEndDate.Name = "chkEndDate";
            this.chkEndDate.Size = new System.Drawing.Size(96, 20);
            this.chkEndDate.TabIndex = 31;
            this.chkEndDate.Text = "操作结束时间";
            // 
            // chkBeginDate
            // 
            this.chkBeginDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkBeginDate.Location = new System.Drawing.Point(566, 79);
            this.chkBeginDate.Name = "chkBeginDate";
            this.chkBeginDate.Size = new System.Drawing.Size(96, 20);
            this.chkBeginDate.TabIndex = 30;
            this.chkBeginDate.Text = "操作开始时间";
            // 
            // cmbEndDate
            // 
            this.cmbEndDate.DateTime = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
            this.cmbEndDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbEndDate.Location = new System.Drawing.Point(670, 119);
            this.cmbEndDate.MaskInput = "{date} {time}";
            this.cmbEndDate.Name = "cmbEndDate";
            this.cmbEndDate.Size = new System.Drawing.Size(144, 21);
            this.cmbEndDate.TabIndex = 29;
            this.cmbEndDate.Value = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
            // 
            // cmbBeginDate
            // 
            this.cmbBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbBeginDate.Location = new System.Drawing.Point(670, 79);
            this.cmbBeginDate.MaskInput = "{date} {time}";
            this.cmbBeginDate.Name = "cmbBeginDate";
            this.cmbBeginDate.Size = new System.Drawing.Size(144, 21);
            this.cmbBeginDate.TabIndex = 28;
            // 
            // cmbOperName
            // 
            this.cmbOperName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbOperName.Location = new System.Drawing.Point(405, 41);
            this.cmbOperName.Name = "cmbOperName";
            this.cmbOperName.Size = new System.Drawing.Size(144, 21);
            this.cmbOperName.TabIndex = 27;
            // 
            // ultraButton1
            // 
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton1.Location = new System.Drawing.Point(947, 111);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 19;
            this.ultraButton1.Text = "打印";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnQuery.Location = new System.Drawing.Point(856, 113);
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
            this.ultraGroupBox1.Size = new System.Drawing.Size(1144, 379);
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
            // cmbDept
            // 
            this.cmbDept.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbDept.Location = new System.Drawing.Point(961, 81);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(152, 21);
            this.cmbDept.TabIndex = 73;
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.Location = new System.Drawing.Point(859, 81);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel8.TabIndex = 72;
            this.ultraLabel8.Text = "部门：";
            // 
            // AllMoneyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1272, 597);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "AllMoneyReport";
            this.Text = Login.constApp.strCardTypeL6Name + "消费明细报表";
            this.Load += new System.EventHandler(this.ProductReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMemberRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOperName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDept)).EndInit();
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
            //DataTable dtOper = Helper.Query("select * from tbOper where cnvcOperName <> 'admin'");			

            //cmbOperName.DataSource = dtOper;
            //cmbOperName.DisplayMember = "cnvcOperName";
            //cmbOperName.ValueMember = "cnnOperID";
            ClientHelper.BindOper(cmbOperName, this.oper, this.dept);

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
            Helper.BindCost(this.ultraComboEditor1);
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
            ClientHelper.BindSales(cmbSales, this.oper.cnnOperID.ToString());
            ClientHelper.BindDept(cmbDept, this.oper.cnnOperID.ToString());
		}

		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			Helper.Print(this,ultraGrid1,ultraGridPrintDocument1,ultraPrintPreviewDialog1);
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
            ClientHelper.ExportExcel(saveFileDialog1, ultraGridExcelExporter1, ultraGrid1, "云南人才市场消费明细报表", this.oper.cnvcOperName);
		}

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e); 

			e.Layout.Bands[0].Columns["cnvcMoneyType"].Header.Caption = "收入项目";			
			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "会员卡号";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "实收";

            e.Layout.Bands[0].Columns["cnnBalance"].Header.Caption = "当前余额";
            e.Layout.Bands[0].Columns["cnnLastBalance"].Header.Caption = "上次余额";
            e.Layout.Bands[0].Columns["cnnDonate"].Header.Caption = "赠送金额";
            e.Layout.Bands[0].Columns["cnvcDeptName"].Header.Caption = "部门";
            e.Layout.Bands[0].Columns["cnvcSales"].Header.Caption = "销售人员";
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
			Helper.PrintDisplay(e,"云南人才市场消费明细报表");	
		}

        private void btnQuery_Click(object sender, System.EventArgs e)
        {
            //工本费
            //string strSql_Cost = "select '工本费' as cnvcMoneyType,a.cnvcMemberCardNo,b.cnvcMemberName,b.cnvcPaperNo,b.cnvcMemberRight,0 as cnnLastBalance,a.cnnCost as cnnPrepay,0 as cnnDonate,0 as cnnBalance,a.cnvcOperName,a.cndOperDate  from tbCostLog a join tbMember b on a.cnvcMemberCardNo=b.cnvcMemberCardNo";
            //strSql_Cost += " where 1=1 ";

            string strSql_MemberProduct = "select a.cnvcProductName as cnvcMoneyType,a.cnvcMemberCardNo,b.cnvcMemberName,b.cnvcPaperNo,b.cnvcMemberRight,a.cnnLastBalance,a.cnnPrepay,0 as cnnDonate,a.cnnBalance,case when e.cnvcDeptName is null then '云南人才市场' else e.cnvcDeptName end as cnvcDeptName,a.cnvcSales,a.cnvcOperName,a.cndOperDate  from tbMemberProductLog a join tbMember b on a.cnvcMemberCardNo=b.cnvcMemberCardNo ";
            //strSql_MemberProduct += " where 1=1 ";
            //strSql_MemberProduct += " left join tbOper c on a.cnvcOperName=c.cnvcOperName left join tbDept d on c.cnnDeptID=d.cnnDeptID ";
            strSql_MemberProduct += " left join tbSales c on a.cnvcSales=c.cnvcSales left join tbOperDept d on c.cnnDeptID=d.cnnDeptID and c.cnnSales=d.cnnOperID left join tbDept e on c.cnnDeptID=e.cnnDeptID ";
            //if (this.oper.cnnDeptID != 0)
            //{

            //    //strSql_MemberProduct += " where (d.cnnParentDeptID=" + this.oper.cnnDeptID.ToString() + " or d.cnnDeptID=" + this.oper.cnnDeptID.ToString() + ")  ";
            //    strSql_MemberProduct += string.Format(" where d.cnnOperID={0} ", this.oper.cnnOperID.ToString());
            //}
            //else
            //{
                strSql_MemberProduct += " where 1=1 ";
            //}
                string strSql_FMemberProduct = "select a.cnvcProductName as cnvcMoneyType,'' as cnvcMemberCardNo,b.cnvcMemberName,b.cnvcPaperNo,'' as cnvcMemberRight,a.cnnLastBalance,a.cnnPrepay,0 as cnnDonate,a.cnnBalance,case when e.cnvcDeptName is null then '云南人才市场' else e.cnvcDeptName end as cnvcDeptName,a.cnvcSales,a.cnvcOperName,a.cndOperDate  from tbFMemberProductLog a join tbFMember b on a.cnvcPaperNo=b.cnvcPaperNo ";
            //strSql_FMemberProduct += " where 1=1 ";
            //strSql_FMemberProduct += " left join tbOper c on a.cnvcOperName=c.cnvcOperName left join tbDept d on c.cnnDeptID=d.cnnDeptID ";
                strSql_FMemberProduct += " left join tbSales c on a.cnvcSales=c.cnvcSales left join tbOperDept d on c.cnnDeptID=d.cnnDeptID and c.cnnSales=d.cnnOperID left join tbDept e on c.cnnDeptID=e.cnnDeptID ";
            //if (this.oper.cnnDeptID != 0)
            //{

            //    //strSql_FMemberProduct += " where (d.cnnParentDeptID=" + this.oper.cnnDeptID.ToString() + " or d.cnnDeptID=" + this.oper.cnnDeptID.ToString() + ")  ";
            //    strSql_FMemberProduct += string.Format(" where d.cnnOperID={0} ", this.oper.cnnOperID.ToString());
            //}
            //else
            //{
                strSql_FMemberProduct += " where 1=1 ";
            //}
            if(!string.IsNullOrEmpty(txtMemberCardNo.Text))
            {
                strSql_MemberProduct += " and a.cnvcMemberCardNo like '%"+txtMemberCardNo.Text+"%' ";
            }
            if (!string.IsNullOrEmpty(txtMemberName.Text))
            {
                strSql_MemberProduct += " and a.cnvcMemberName like '%" + txtMemberName.Text + "%'";
                strSql_FMemberProduct += " and a.cnvcMemberName like '%" + txtMemberName.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtPaperNo.Text))
            {
                strSql_MemberProduct += " and a.cnvcPaperNo like '%" + txtPaperNo.Text + "%'";
                strSql_FMemberProduct += " and a.cnvcPaperNo like '%" + txtPaperNo.Text + "%'";
            }
            if (cmbOperName.Text.Trim().Length > 0)
            {
                //strSql_Cost += " and a.cnvcOperName like '%" + cmbOperName.Text + "%'";
                strSql_MemberProduct += " and a.cnvcOperName like '%" + cmbOperName.Text + "%'";
                strSql_FMemberProduct += " and a.cnvcOperName like '%" + cmbOperName.Text + "%'";
            }
            if (chkBeginDate.Checked)
            {
                //strSql_Cost += " and a.cndOperDate >= '" + cmbBeginDate.Value.ToString() + "'";
                strSql_MemberProduct += " and a.cndOperDate >= '" + cmbBeginDate.Value.ToString() + "'";
                strSql_FMemberProduct += " and a.cndOperDate >= '" + cmbBeginDate.Value.ToString() + "'";
            }
            if (chkEndDate.Checked)
            {
                //strSql_Cost += " and a.cndOperDate <= '" + cmbEndDate.Value.ToString() + "'";
                strSql_MemberProduct += " and a.cndOperDate <= '" + cmbEndDate.Value.ToString() + "'";
                strSql_FMemberProduct += " and a.cndOperDate <= '" + cmbEndDate.Value.ToString() + "'";
            }
            if (cmbMemberRight.Text.Trim().Length > 0)
            {
                //strSql_Cost += " and b.cnvcMemberRight like '%" + cmbMemberRight.Text + "%'";
                strSql_MemberProduct += " and b.cnvcMemberRight like '%" + cmbMemberRight.Text + "%'";
            }
            if (cmbSales.Text.Trim().Length > 0)
            {
                strSql_MemberProduct += " and a.cnvcSales like '%" + cmbSales.Text + "%'";
                strSql_FMemberProduct += " and a.cnvcSales like '%" + cmbSales.Text + "%'";
            }
            if (cmbDept.Text.Trim().Length > 0)
            {
                strSql_MemberProduct += " and e.cnvcDeptName like '%" + cmbDept.Text + "%'";
                strSql_FMemberProduct += " and e.cnvcDeptName like '%" + cmbDept.Text + "%'";
            }
            DataTable dtCost = null;
            //if (this.ultraComboEditor1.Text == "工本费")
            //{
            //    dtCost = Helper.Query(strSql_Cost);
            //}
            //else
            //{
            if (cmbMember.Text.Trim().Length == 0)
            {
                //dtCost = Helper.Query(strSql_Cost);
                dtCost = Helper.Query(strSql_MemberProduct);
                DataTable dtFMemberProduct = Helper.Query(strSql_FMemberProduct);
                //foreach (DataRow dr in dtMemberProduct.Rows)
                //{
                //    dtCost.Rows.Add(dr.ItemArray);
                //}
                foreach (DataRow dr in dtFMemberProduct.Rows)
                {
                    dtCost.Rows.Add(dr.ItemArray);
                }
            }
            else if (cmbMember.Text == "会员")
            {
                //dtCost = Helper.Query(strSql_Cost);
                dtCost = Helper.Query(strSql_MemberProduct);
                //foreach (DataRow dr in dtMemberProduct.Rows)
                //{
                //    dtCost.Rows.Add(dr.ItemArray);
                //}


            }
            else if (cmbMember.Text == "非会员")
            {
                dtCost = Helper.Query(strSql_FMemberProduct);
            }
            //}
            this.ultraGrid1.DataSource = null;
            this.ultraGrid1.DataSource = dtCost;
            this.ultraGrid1.DataBind();

            ClientHelper.AddGridColumn(this.ultraGrid1, this.oper.cnvcOperName);
            Helper.AddGridSummary(this.ultraGrid1, SummaryType.Count, "收入合计，共{0}条", "cnvcMemberRight");
            Helper.AddGridSummary(this.ultraGrid1, SummaryType.Sum, "{0}", "cnnPrepay");
        }
	}
}
