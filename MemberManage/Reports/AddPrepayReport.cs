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
namespace MemberManage.Reports
{
	/// <summary>
	/// Summary description for AddPrepayReport.
	/// </summary>
	public class AddPrepayReport : frmBase
	{
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.Misc.UltraButton btnQuery;
		public static bool IsShowing ;
		private Infragistics.Win.Printing.UltraPrintPreviewDialog ultraPrintPreviewDialog1;
		private Infragistics.Win.UltraWinGrid.UltraGridPrintDocument ultraGridPrintDocument1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbShow;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbOperName;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEndDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraButton btnExcel;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbFeeDirection;
		private Infragistics.Win.Misc.UltraButton btnFilter;
		private System.ComponentModel.IContainer components;

		public AddPrepayReport()
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
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnFilter = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbFeeDirection = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnExcel = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.chkEndDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkBeginDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cmbEndDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.cmbBeginDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.cmbOperName = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbShow = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.btnQuery = new Infragistics.Win.Misc.UltraButton();
            this.txtPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraPrintPreviewDialog1 = new Infragistics.Win.Printing.UltraPrintPreviewDialog(this.components);
            this.ultraGridPrintDocument1 = new Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(this.components);
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFeeDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOperName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.btnFilter);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox2.Controls.Add(this.cmbFeeDirection);
            this.ultraGroupBox2.Controls.Add(this.btnExcel);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox2.Controls.Add(this.chkEndDate);
            this.ultraGroupBox2.Controls.Add(this.chkBeginDate);
            this.ultraGroupBox2.Controls.Add(this.cmbEndDate);
            this.ultraGroupBox2.Controls.Add(this.cmbBeginDate);
            this.ultraGroupBox2.Controls.Add(this.cmbOperName);
            this.ultraGroupBox2.Controls.Add(this.cmbShow);
            this.ultraGroupBox2.Controls.Add(this.ultraButton1);
            this.ultraGroupBox2.Controls.Add(this.btnQuery);
            this.ultraGroupBox2.Controls.Add(this.txtPaperNo);
            this.ultraGroupBox2.Controls.Add(this.txtMemberName);
            this.ultraGroupBox2.Location = new System.Drawing.Point(32, 18);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(872, 150);
            this.ultraGroupBox2.TabIndex = 3;
            this.ultraGroupBox2.Text = "����";
            // 
            // btnFilter
            // 
            this.btnFilter.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnFilter.Location = new System.Drawing.Point(560, 32);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(40, 23);
            this.btnFilter.TabIndex = 53;
            this.btnFilter.Text = "����";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(32, 104);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 39;
            this.ultraLabel1.Text = "�շѷ���";
            // 
            // cmbFeeDirection
            // 
            this.cmbFeeDirection.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbFeeDirection.Location = new System.Drawing.Point(136, 104);
            this.cmbFeeDirection.Name = "cmbFeeDirection";
            this.cmbFeeDirection.Size = new System.Drawing.Size(144, 21);
            this.cmbFeeDirection.TabIndex = 38;
            // 
            // btnExcel
            // 
            this.btnExcel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnExcel.Location = new System.Drawing.Point(728, 112);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 37;
            this.btnExcel.Text = "����EXCEL";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(312, 72);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel5.TabIndex = 36;
            this.ultraLabel5.Text = "����Ա��";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(312, 32);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel4.TabIndex = 35;
            this.ultraLabel4.Text = "��Ƹ�᣺";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(32, 72);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 34;
            this.ultraLabel3.Text = "��λ���ƣ�";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(32, 32);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 33;
            this.ultraLabel2.Text = "����ע��ţ�";
            // 
            // chkEndDate
            // 
            this.chkEndDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkEndDate.Location = new System.Drawing.Point(624, 72);
            this.chkEndDate.Name = "chkEndDate";
            this.chkEndDate.Size = new System.Drawing.Size(88, 20);
            this.chkEndDate.TabIndex = 31;
            this.chkEndDate.Text = "����ʱ��";
            // 
            // chkBeginDate
            // 
            this.chkBeginDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkBeginDate.Location = new System.Drawing.Point(624, 32);
            this.chkBeginDate.Name = "chkBeginDate";
            this.chkBeginDate.Size = new System.Drawing.Size(88, 20);
            this.chkBeginDate.TabIndex = 30;
            this.chkBeginDate.Text = "��ʼʱ��";
            // 
            // cmbEndDate
            // 
            this.cmbEndDate.DateTime = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
            this.cmbEndDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbEndDate.Location = new System.Drawing.Point(720, 72);
            this.cmbEndDate.MaskInput = "{date} {time}";
            this.cmbEndDate.Name = "cmbEndDate";
            this.cmbEndDate.Size = new System.Drawing.Size(144, 21);
            this.cmbEndDate.TabIndex = 29;
            this.cmbEndDate.Value = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
            // 
            // cmbBeginDate
            // 
            this.cmbBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbBeginDate.Location = new System.Drawing.Point(720, 32);
            this.cmbBeginDate.MaskInput = "{date} {time}";
            this.cmbBeginDate.Name = "cmbBeginDate";
            this.cmbBeginDate.Size = new System.Drawing.Size(144, 21);
            this.cmbBeginDate.TabIndex = 28;
            // 
            // cmbOperName
            // 
            this.cmbOperName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbOperName.Location = new System.Drawing.Point(416, 72);
            this.cmbOperName.Name = "cmbOperName";
            this.cmbOperName.Size = new System.Drawing.Size(144, 21);
            this.cmbOperName.TabIndex = 27;
            // 
            // cmbShow
            // 
            this.cmbShow.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbShow.Location = new System.Drawing.Point(416, 32);
            this.cmbShow.Name = "cmbShow";
            this.cmbShow.Size = new System.Drawing.Size(144, 21);
            this.cmbShow.TabIndex = 22;
            // 
            // ultraButton1
            // 
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton1.Location = new System.Drawing.Point(624, 112);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 19;
            this.ultraButton1.Text = "��ӡ";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnQuery.Location = new System.Drawing.Point(520, 112);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 18;
            this.btnQuery.Text = "��ѯ";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtPaperNo
            // 
            this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPaperNo.Location = new System.Drawing.Point(136, 32);
            this.txtPaperNo.Name = "txtPaperNo";
            this.txtPaperNo.Size = new System.Drawing.Size(136, 21);
            this.txtPaperNo.TabIndex = 17;
            // 
            // txtMemberName
            // 
            this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberName.Location = new System.Drawing.Point(136, 72);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(136, 21);
            this.txtMemberName.TabIndex = 15;
            // 
            // ultraPrintPreviewDialog1
            // 
            this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.ultraGrid1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(32, 184);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(976, 392);
            this.ultraGroupBox1.TabIndex = 5;
            this.ultraGroupBox1.Click += new System.EventHandler(this.ultraGroupBox1_Click);
            // 
            // AddPrepayReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1024, 589);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.ultraGroupBox2);
            this.Name = "AddPrepayReport";
            this.Text = Login.constApp.strCardTypeL8Name + "�ɷѱ���";
            this.Load += new System.EventHandler(this.AddPrepayReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFeeDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOperName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//
			try
			{
				//string strSql = "select cnnJobID,'' as cnvcJobName,cnvcMemberCardNo,cnvcPaperNo,'' as cnvcMemberName,cnnPrepay,cnnReturn,cnnBalance,cnvcState,cnvcOperName,cndOperDate from tbPrepay where 1=1 ";
				string strSql = "select a.cnnPrepayID,a.cnnJobID,b.cnvcJobName,a.cnvcPaperNo,"
					          + " d.cnvcMemberName,a.cnnPrepay,a.cnnReturn,a.cnnBalance,a.cnvcState,a.cnvcOperName,a.cndOperDate "
							  + " from tbPrepay a"
							  + " left outer join tbJob b on a.cnnJobID=b.cnnJobID";				
				//strSql += " left outer join tbMember c on a.cnvcMemberCardNo = c.cnvcMemberCardNo";				
				strSql += " left outer join tbFMember d on a.cnvcPaperNo=d.cnvcPaperNo and a.cnvcMemberCardNo is null";
				strSql += " where 1=1";
				if (cmbShow.Text.Trim().Length > 0)
				{
					strSql += " and b.cnvcJobName like '%"+cmbShow.Text+"%'";
				}
//				if (txtMemberCardNo.Text.Trim().Length > 0)
//				{
//					strSql += " and c.cnvcMemberCardNo like '%"+txtMemberCardNo.Text+"%'";
//				}
				if (txtMemberName.Text!="")
				{
					strSql += " and d.cnvcMemberName like '%"+txtMemberName.Text+"%'";
				}
				if (txtPaperNo.Text.Trim().Length > 0)
				{
					strSql += " and d.cnvcPaperNo like '%"+txtPaperNo.Text+"%'";
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
				if (cmbFeeDirection.Text.Trim()=="�ɷ�")
				{
					strSql += "and a.cnnReturn =0 ";
				}
				else if (cmbFeeDirection.Text.Trim()=="�˷�")
				{
					strSql += "and a.cnnReturn >0 ";
				}

				DataTable dtPrepay = Helper.Query(strSql);
				this.ultraGrid1.DataSource = null;
				this.ultraGrid1.DataSource = dtPrepay;
				this.ultraGrid1.DataBind();

                ClientHelper.AddGridColumn(this.ultraGrid1, this.oper.cnvcOperName);
				Helper.AddGridSummary(this.ultraGrid1,SummaryType.Count,"��Ա������{0}","cnvcPaperNo");		
				Helper.AddGridSummary(this.ultraGrid1,SummaryType.Sum,"չλ���ܶ{0}","cnnPrepay");		
				Helper.AddGridSummary(this.ultraGrid1,SummaryType.Sum,"�˷��ܶ{0}","cnnReturn");		
				Helper.AddGridSummary(this.ultraGrid1,SummaryType.Sum,"����ܶ{0}","cnnBalance");		
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

		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			Helper.Print(this,ultraGrid1,ultraGridPrintDocument1,ultraPrintPreviewDialog1);
		}

		private void ultraGrid1_InitializePrint(object sender, Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs e)
		{
			Helper.PrintDisplay(e,"�����˲��г��ɷѱ���");	
		}

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e); 

			e.Layout.Bands[0].Columns["cnnJobID"].Hidden = true;
			e.Layout.Bands[0].Columns["cnnPrepayID"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcJobName"].Header.Caption = "��Ƹ��";			
			//e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "��Ա����";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "����ע���";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "��λ����";
			e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "չλ��";
			e.Layout.Bands[0].Columns["cnnReturn"].Header.Caption = "�˷�";
			e.Layout.Bands[0].Columns["cnnBalance"].Header.Caption = "���";
			e.Layout.Bands[0].Columns["cnvcState"].Header.Caption = "����״̬";
			e.Layout.Bands[0].Columns["cnvcOperName"].Header.Caption = "����Ա����";
			e.Layout.Bands[0].Columns["cndOperDate"].Header.Caption = "����ʱ��";

			e.Layout.Bands[0].SummaryFooterCaption = "�ϼƣ�"; 
		}

		private void AddPrepayReport_Load(object sender, System.EventArgs e)
		{
			this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti; 
			cmbBeginDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEndDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbBeginDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 00:00";
			cmbEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 23:59";
			DataTable dtOper = Helper.Query("select * from tbOper where cnvcOperName <> 'admin'");			

			cmbOperName.DataSource = dtOper;
			cmbOperName.DisplayMember = "cnvcOperName";
			cmbOperName.ValueMember = "cnnOperID";

			//Helper.BindJob_Query(cmbShow);
			Helper.BindJob_Query_Limit(cmbShow);
			cmbFeeDirection.Items.Add("�ɷ�","�ɷ�");
			cmbFeeDirection.Items.Add("�˷�","�˷�");

			this.ultraGrid1.Dock       = DockStyle.Fill;
			this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
			this.ultraGroupBox1.BringToFront();

			//cmbFeeDirection.

            //if (ClientHelper.idept.cnnDeptID != 0)
            //{
            //    if(!Login.constApp.alOperFunc.Contains("�ɷѱ����ѯ"))
            //    {
            //        this.btnQuery.Enabled = false;
            //    }
            //    if(!Login.constApp.alOperFunc.Contains("�ɷѱ����ӡ"))
            //    {
            //        this.ultraButton1.Enabled = false;
            //        btnExcel.Enabled = false;
            //    }
            //}
			
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
            ClientHelper.ExportExcel(saveFileDialog1, ultraGridExcelExporter1, ultraGrid1, "�����˲��г��ɷѱ���", this.oper.cnvcOperName);
		}

		private void ultraGroupBox1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnFilter_Click(object sender, System.EventArgs e)
		{
			string strBeginDate = DateTime.Parse(this.cmbBeginDate.Value.ToString()).ToString("yyyy-MM-dd");
			string strEndDate = DateTime.Parse(this.cmbEndDate.Value.ToString()).ToString("yyyy-MM-dd");
			Helper.BindJob_Query_Filter(cmbShow,chkBeginDate.Checked,strBeginDate,chkEndDate.Checked,strEndDate);
		}
	}
}
