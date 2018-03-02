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
    public class ProductConsumeReport : frmBase
	{
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
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
		private Infragistics.Win.Printing.UltraPrintPreviewDialog ultraPrintPreviewDialog1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.UltraWinGrid.UltraGridPrintDocument ultraGridPrintDocument1;
		private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbProduct;
		private System.ComponentModel.IContainer components;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbMember;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbSales;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDept;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		public static bool IsShowing ;
		public ProductConsumeReport()
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
            this.cmbDept = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbSales = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbMember = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbProduct = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
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
            this.ultraPrintPreviewDialog1 = new Infragistics.Win.Printing.UltraPrintPreviewDialog(this.components);
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGridPrintDocument1 = new Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(this.components);
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOperName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.cmbDept);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel7);
            this.ultraGroupBox2.Controls.Add(this.cmbSales);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel21);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox2.Controls.Add(this.cmbMember);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel6);
            this.ultraGroupBox2.Controls.Add(this.cmbProduct);
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
            this.ultraGroupBox2.Location = new System.Drawing.Point(28, 32);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(1101, 150);
            this.ultraGroupBox2.TabIndex = 8;
            this.ultraGroupBox2.Text = "����";
            // 
            // cmbDept
            // 
            this.cmbDept.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbDept.Location = new System.Drawing.Point(931, 33);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(152, 21);
            this.cmbDept.TabIndex = 71;
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Location = new System.Drawing.Point(829, 33);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel7.TabIndex = 70;
            this.ultraLabel7.Text = "���ţ�";
            // 
            // cmbSales
            // 
            this.cmbSales.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbSales.Location = new System.Drawing.Point(656, 108);
            this.cmbSales.Name = "cmbSales";
            this.cmbSales.Size = new System.Drawing.Size(144, 21);
            this.cmbSales.TabIndex = 59;
            // 
            // ultraLabel21
            // 
            this.ultraLabel21.Location = new System.Drawing.Point(552, 109);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel21.TabIndex = 58;
            this.ultraLabel21.Text = "������Ա��";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(288, 112);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(96, 23);
            this.ultraLabel4.TabIndex = 43;
            this.ultraLabel4.Text = "�Ƿ��Ա��";
            // 
            // cmbMember
            // 
            this.cmbMember.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbMember.Location = new System.Drawing.Point(392, 112);
            this.cmbMember.Name = "cmbMember";
            this.cmbMember.Size = new System.Drawing.Size(144, 21);
            this.cmbMember.TabIndex = 42;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(288, 72);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel6.TabIndex = 41;
            this.ultraLabel6.Text = "�����Ʒ��";
            // 
            // cmbProduct
            // 
            this.cmbProduct.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbProduct.Location = new System.Drawing.Point(392, 72);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(144, 21);
            this.cmbProduct.TabIndex = 40;
            // 
            // btnExcel
            // 
            this.btnExcel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnExcel.Location = new System.Drawing.Point(1020, 106);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 37;
            this.btnExcel.Text = "����EXCEL";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(288, 32);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel5.TabIndex = 36;
            this.ultraLabel5.Text = "����Ա��";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(24, 112);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 34;
            this.ultraLabel3.Text = "��λ���ƣ�";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(24, 72);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 33;
            this.ultraLabel2.Text = "����ע��ţ�";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(24, 32);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 32;
            this.ultraLabel1.Text = "��Ա���ţ�";
            // 
            // chkEndDate
            // 
            this.chkEndDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkEndDate.Location = new System.Drawing.Point(552, 72);
            this.chkEndDate.Name = "chkEndDate";
            this.chkEndDate.Size = new System.Drawing.Size(96, 20);
            this.chkEndDate.TabIndex = 31;
            this.chkEndDate.Text = "��������ʱ��";
            // 
            // chkBeginDate
            // 
            this.chkBeginDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkBeginDate.Location = new System.Drawing.Point(552, 32);
            this.chkBeginDate.Name = "chkBeginDate";
            this.chkBeginDate.Size = new System.Drawing.Size(96, 20);
            this.chkBeginDate.TabIndex = 30;
            this.chkBeginDate.Text = "������ʼʱ��";
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
            this.ultraButton1.Location = new System.Drawing.Point(931, 106);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 19;
            this.ultraButton1.Text = "��ӡ";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnQuery.Location = new System.Drawing.Point(829, 107);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 18;
            this.btnQuery.Text = "��ѯ";
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
            // ultraPrintPreviewDialog1
            // 
            this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.ultraGrid1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(28, 205);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(1101, 379);
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
            this.ultraGrid1.Text = "��ѯ���";
            this.ultraGrid1.InitializePrint += new Infragistics.Win.UltraWinGrid.InitializePrintEventHandler(this.ultraGrid1_InitializePrint);
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            // 
            // ProductConsumeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1167, 597);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "ProductConsumeReport";
            this.Text = Login.constApp.strCardTypeL6Name + "�����Ʒ���ѱ���";
            this.Load += new System.EventHandler(this.ProductReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOperName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
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
			//�󶨻�Ա״̬
//			DataTable dtState = new DataTable();
//			//dtState.Columns.Add("cnvcState");
//			dtState.Columns.Add("��Ա״̬");
//
//			DataRow drState0 = dtState.NewRow();
//			//drState0["cnvcState"] = "0";
//			drState0["��Ա״̬"] = ConstApp.Card_State_InUse;
//
//			dtState.Rows.Add(drState0);
//
//			DataRow drState1 = dtState.NewRow();
//			//drState1["cnvcState"] = "1";
//			drState1["��Ա״̬"] = ConstApp.Card_State_InLose;
//
//			dtState.Rows.Add(drState1);
//
//			DataRow drState2 = dtState.NewRow();
//			//drState2["cnvcState"] = "2";
//			drState2["��Ա״̬"] = ConstApp.Card_State_InAdd;
//
//			dtState.Rows.Add(drState2);
//
//			DataRow drState3 = dtState.NewRow();
//			//drState2["cnvcState"] = "2";
//			drState3["��Ա״̬"] = ConstApp.Card_State_InCallBack;
//
//			dtState.Rows.Add(drState3);

			
			//cmbState.DataSource = dtState;
			//cmbState.DisplayMember = "��Ա״̬";
			//cmbState.ValueMember = "cnvcState";
			//cmbState.DataBind();	
			//cmbState.SelectedIndex = 0;

			//Helper.BindJob(cmbShow);

			Helper.BindMember(cmbMember);

			this.ultraGrid1.Dock       = DockStyle.Fill;
			this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
			this.ultraGroupBox1.BringToFront();

            ClientHelper.BindProduct(cmbProduct);
            //if (ClientHelper.idept.cnnDeptID != 0)
            //{
            //    if(!Login.constApp.alOperFunc.Contains("�����Ʒ��ֵ�ɷѱ����ѯ"))
            //    {
            //        this.btnQuery.Enabled = false;
            //    }
            //    if(!Login.constApp.alOperFunc.Contains("�����Ʒ��ֵ�ɷѱ����ӡ"))
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
            ClientHelper.ExportExcel(saveFileDialog1, ultraGridExcelExporter1, ultraGrid1, "�����˲��г������Ʒ���ѱ���", this.oper.cnvcOperName);
		}

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e); 

			//e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "��Ա״̬";	
			e.Layout.Bands[0].Columns["cnvcProductDiscount"].Header.Caption = "��Ʒ�ۿ�";	
			e.Layout.Bands[0].Columns["cnvcProductName"].Header.Caption = "�����Ʒ";	
			e.Layout.Bands[0].Columns["cnnProductPrice"].Header.Caption = "��Ʒ����";			
			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "��Ա����";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "����ע���";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "��λ����";
			e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "���ѽ��";

            e.Layout.Bands[0].Columns["cnnCount"].Header.Caption = "����";
            e.Layout.Bands[0].Columns["cnnLastBalance"].Header.Caption = "�ϴ����";
            e.Layout.Bands[0].Columns["cnnBalance"].Header.Caption = "��ǰ���";

			e.Layout.Bands[0].Columns["cnvcFree"].Header.Caption = "����";
            e.Layout.Bands[0].Columns["cnvcFree"].Hidden = true;
			//e.Layout.Bands[0].Columns["cnnBalance"].Header.Caption = "�ɷ�";
			//e.Layout.Bands[0].Columns["cnvcDiscount"].Header.Caption = "�ۿ�";
            e.Layout.Bands[0].Columns["cnvcDeptName"].Header.Caption = "����";
            e.Layout.Bands[0].Columns["cnvcSales"].Header.Caption = "������Ա";
			e.Layout.Bands[0].Columns["cnvcOperName"].Header.Caption = "����Ա����";
			e.Layout.Bands[0].Columns["cndOperDate"].Header.Caption = "����ʱ��";

			e.Layout.Bands[0].Columns["cndOperDate"].CellActivation = Activation.NoEdit;
			e.Layout.Bands[0].Columns["cndOperDate"].Format = "yyyy-MM-dd hh:mm";

			e.Layout.Bands[0].SummaryFooterCaption = "�ϼƣ�"; 

			e.Layout.Bands[0].Columns["cnnSerialNo"].Hidden = true;
		}

		private void ultraGrid1_InitializePrint(object sender, Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs e)
		{
			Helper.PrintDisplay(e,"�����˲��г������Ʒ���ѱ���");	
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			try
			{
                string strSql = "select a.cnnSerialNo,a.cnvcMemberCardNo,a.cnvcPaperNo,a.cnvcMemberName,a.cnvcProductName,a.cnnProductPrice,a.cnvcProductDiscount,a.cnnCount,a.cnnLastBalance,a.cnnPrepay,a.cnnBalance,a.cnvcFree,case when e.cnvcDeptName is null then '�����˲��г�' else e.cnvcDeptName end as cnvcDeptName,a.cnvcSales,a.cnvcOperName,a.cndOperDate from tbMemberProductLog a ";
                //strSql += " left join tbOper c on a.cnvcOperName=c.cnvcOperName left join tbDept d on c.cnnDeptID=d.cnnDeptID ";
                strSql += " left join tbSales c on a.cnvcSales=c.cnvcSales left join tbOperDept d on c.cnnDeptID=d.cnnDeptID and c.cnnSales=d.cnnOperID left join tbDept e on c.cnnDeptID=e.cnnDeptID";
                //if (this.oper.cnnDeptID != 0)
                //{

                //    //strSql += " where (d.cnnParentDeptID=" + this.oper.cnnDeptID.ToString() + " or d.cnnDeptID=" + this.oper.cnnDeptID.ToString() + ")  ";
                //    strSql += string.Format(" where d.cnnOperID={0} ", this.oper.cnnOperID.ToString());
                //}
                //else
                //{
                    strSql += " where 1=1 ";
                //}
                //strSql += " where 1=1";
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
					strSql += " and a.cnvcOperName like '%"+cmbOperName.Text+"%'";
				}
				if (chkBeginDate.Checked)
				{
					strSql += " and a.cndOperDate >= '"+cmbBeginDate.Value.ToString()+"'";
				}
				if (chkEndDate.Checked)
				{
					strSql += " and a.cndOperDate <= '"+cmbEndDate.Value.ToString()+"'";
				}
				if (cmbProduct.Text.Trim().Length > 0)
				{
                    strSql += " and a.cnvcProductName like '%" + cmbProduct.Text + "%'";
				}
                if (cmbSales.Text.Trim().Length > 0)
                {
                    strSql += " and a.cnvcSales like '%"+cmbSales.Text+"%'";
                }
                if (cmbDept.Text.Trim().Length > 0)
                {
                    strSql += " and e.cnvcDeptName like '%" + cmbDept.Text + "%'";
                }
                string strSql2 = "select a.cnnSerialNo,'' as cnvcMemberCardNo,a.cnvcPaperNo,a.cnvcMemberName,a.cnvcProductName,a.cnnProductPrice,a.cnvcProductDiscount,a.cnnCount,a.cnnLastBalance,a.cnnPrepay,a.cnnBalance,a.cnvcFree,case when e.cnvcDeptName is null then '�����˲��г�' else e.cnvcDeptName end as cnvcDeptName,a.cnvcSales,a.cnvcOperName,a.cndOperDate from tbFMemberProductLog a ";
                //strSql2 += " left join tbOper c on a.cnvcOperName=c.cnvcOperName left join tbDept d on c.cnnDeptID=d.cnnDeptID ";
                strSql2 += " left join tbSales c on a.cnvcSales=c.cnvcSales left join tbOperDept d on c.cnnDeptID=d.cnnDeptID and c.cnnSales=d.cnnOperID left join tbDept e on c.cnnDeptID=e.cnnDeptID";
                //if (this.oper.cnnDeptID != 0)
                //{

                //    //strSql2 += " where (d.cnnParentDeptID=" + this.oper.cnnDeptID.ToString() + " or d.cnnDeptID=" + this.oper.cnnDeptID.ToString() + ")  ";
                //    strSql2 += string.Format(" where d.cnnOperID={0} ", this.oper.cnnOperID.ToString());
                //}
                //else
                //{
                    strSql2 += " where 1=1 ";
                //}
                //strSql2 += " where 1=1";
//				if (txtMemberCardNo.Text.Trim().Length > 0)
//				{
//					strSql2 += " and cnvcMemberCardNo like '%"+txtMemberCardNo.Text+"%'";
//				}
				if (txtMemberName.Text!="")
				{
                    strSql2 += " and a.cnvcMemberName like '%" + txtMemberName.Text + "%'";
				}
				if (txtPaperNo.Text.Trim().Length > 0)
				{
                    strSql2 += " and a.cnvcPaperNo like '%" + txtPaperNo.Text + "%'";
				}
				if (cmbOperName.Text.Trim().Length > 0)
				{
                    strSql2 += " and a.cnvcOperName like '%" + cmbOperName.Text + "%'";
				}
				if (chkBeginDate.Checked)
				{
                    strSql2 += " and a.cndOperDate >= '" + cmbBeginDate.Value.ToString() + "'";
				}
				if (chkEndDate.Checked)
				{
                    strSql2 += " and a.cndOperDate <= '" + cmbEndDate.Value.ToString() + "'";
				}
				if (cmbProduct.Text.Trim().Length > 0)
				{
                    strSql2 += " and a.cnvcProductName like '%" + cmbProduct.Text + "%'";
				}
                if (cmbSales.Text.Trim().Length > 0)
                {
                    strSql2 += " and a.cnvcSales like '%" + cmbSales.Text + "%'";
                }
                if (cmbDept.Text.Trim().Length > 0)
                {
                    strSql2 += " and e.cnvcDeptName like '%" + cmbDept.Text + "%'";
                }
				DataTable dtPrepay = new DataTable();
				if (cmbMember.Text.Trim().Length == 0)
				{
					dtPrepay = Helper.Query(strSql);
					DataTable dtPrepay2 = Helper.Query(strSql2);
					foreach (DataRow dr in dtPrepay2.Rows)
					{
						dtPrepay.Rows.Add(dr.ItemArray);
					}
				}
				else if (cmbMember.Text == "��Ա")
				{
					dtPrepay = Helper.Query(strSql);
				}
				else if (cmbMember.Text == "�ǻ�Ա")
				{
					dtPrepay = Helper.Query(strSql2);
				}
				
				this.ultraGrid1.DataSource = null;
				this.ultraGrid1.DataSource = dtPrepay;
				this.ultraGrid1.DataBind();

                ClientHelper.AddGridColumn(this.ultraGrid1, this.oper.cnvcOperName);
				Helper.AddGridSummary(this.ultraGrid1,SummaryType.Count,"�����Ʒ���Ѵ�����{0}","cnvcMemberCardNo");		
			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"ϵͳ����",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
	}
}
