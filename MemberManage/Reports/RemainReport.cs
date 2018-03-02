using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MemberManage.Business;
using System.Data;
using System.Data.SqlClient;
using Infragistics;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ynhrMemberManage.Domain;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Common;
namespace MemberManage.Reports
{
	/// <summary>
	/// Summary description for BookingReport.
	/// </summary>
    public class RemainReport : frmBase
	{
		private System.ComponentModel.IContainer components;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.Printing.UltraPrintPreviewDialog ultraPrintPreviewDialog1;
		private Infragistics.Win.UltraWinGrid.UltraGridPrintDocument ultraGridPrintDocument1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraButton btnExcel;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEndDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate;
		private Infragistics.Win.Misc.UltraButton btnPrint;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmdBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbShow;
		private Infragistics.Win.Misc.UltraButton btnQuery;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBeginDate;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraButton btnFilter;
		public static bool IsShowing;

		public RemainReport()
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
			this.ultraPrintPreviewDialog1 = new Infragistics.Win.Printing.UltraPrintPreviewDialog(this.components);
			this.ultraGridPrintDocument1 = new Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(this.components);
			this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
			this.btnExcel = new Infragistics.Win.Misc.UltraButton();
			this.cmbEndDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.chkEndDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.btnPrint = new Infragistics.Win.Misc.UltraButton();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.cmdBeginDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.cmbShow = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.btnQuery = new Infragistics.Win.Misc.UltraButton();
			this.chkBeginDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
			this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
			this.btnFilter = new Infragistics.Win.Misc.UltraButton();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
			this.ultraGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmdBeginDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbShow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
			this.ultraGroupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// ultraGrid1
			// 
			this.ultraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			this.ultraGrid1.Location = new System.Drawing.Point(48, 48);
			this.ultraGrid1.Name = "ultraGrid1";
			this.ultraGrid1.Size = new System.Drawing.Size(176, 88);
			this.ultraGrid1.TabIndex = 16;
			this.ultraGrid1.Text = "预留列表";
			this.ultraGrid1.InitializePrint += new Infragistics.Win.UltraWinGrid.InitializePrintEventHandler(this.ultraGrid1_InitializePrint);
			this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
			// 
			// ultraPrintPreviewDialog1
			// 
			this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
			// 
			// ultraGroupBox1
			// 
			this.ultraGroupBox1.Controls.Add(this.btnFilter);
			this.ultraGroupBox1.Controls.Add(this.btnExcel);
			this.ultraGroupBox1.Controls.Add(this.cmbEndDate);
			this.ultraGroupBox1.Controls.Add(this.chkEndDate);
			this.ultraGroupBox1.Controls.Add(this.btnPrint);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
			this.ultraGroupBox1.Controls.Add(this.cmdBeginDate);
			this.ultraGroupBox1.Controls.Add(this.cmbShow);
			this.ultraGroupBox1.Controls.Add(this.btnQuery);
			this.ultraGroupBox1.Controls.Add(this.chkBeginDate);
			this.ultraGroupBox1.Location = new System.Drawing.Point(120, 24);
			this.ultraGroupBox1.Name = "ultraGroupBox1";
			this.ultraGroupBox1.Size = new System.Drawing.Size(796, 128);
			this.ultraGroupBox1.TabIndex = 17;
			// 
			// btnExcel
			// 
			this.btnExcel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnExcel.Location = new System.Drawing.Point(488, 88);
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.TabIndex = 12;
			this.btnExcel.Text = "导出EXCEL";
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			// 
			// cmbEndDate
			// 
			this.cmbEndDate.DateTime = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
			this.cmbEndDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbEndDate.Location = new System.Drawing.Point(280, 80);
			this.cmbEndDate.MaskInput = "{date} {time}";
			this.cmbEndDate.Name = "cmbEndDate";
			this.cmbEndDate.TabIndex = 7;
			this.cmbEndDate.Value = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
			// 
			// chkEndDate
			// 
			this.chkEndDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.chkEndDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.chkEndDate.Location = new System.Drawing.Point(160, 80);
			this.chkEndDate.Name = "chkEndDate";
			this.chkEndDate.TabIndex = 11;
			this.chkEndDate.Text = "结束时间";
			// 
			// btnPrint
			// 
			this.btnPrint.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnPrint.Location = new System.Drawing.Point(488, 56);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.TabIndex = 3;
			this.btnPrint.Text = "打印";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// ultraLabel2
			// 
			this.ultraLabel2.Location = new System.Drawing.Point(160, 32);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.Size = new System.Drawing.Size(112, 23);
			this.ultraLabel2.TabIndex = 6;
			this.ultraLabel2.Text = "招聘会：";
			// 
			// cmdBeginDate
			// 
			this.cmdBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmdBeginDate.Location = new System.Drawing.Point(280, 56);
			this.cmdBeginDate.MaskInput = "{date} {time}";
			this.cmdBeginDate.Name = "cmdBeginDate";
			this.cmdBeginDate.TabIndex = 5;
			// 
			// cmbShow
			// 
			this.cmbShow.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbShow.Location = new System.Drawing.Point(280, 32);
			this.cmbShow.Name = "cmbShow";
			this.cmbShow.TabIndex = 4;
			// 
			// btnQuery
			// 
			this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnQuery.Location = new System.Drawing.Point(488, 24);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.TabIndex = 0;
			this.btnQuery.Text = "查询";
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// chkBeginDate
			// 
			this.chkBeginDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.chkBeginDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.chkBeginDate.Location = new System.Drawing.Point(160, 56);
			this.chkBeginDate.Name = "chkBeginDate";
			this.chkBeginDate.TabIndex = 10;
			this.chkBeginDate.Text = "开始时间";
			// 
			// ultraGroupBox2
			// 
			this.ultraGroupBox2.Controls.Add(this.ultraGrid1);
			this.ultraGroupBox2.Location = new System.Drawing.Point(24, 168);
			this.ultraGroupBox2.Name = "ultraGroupBox2";
			this.ultraGroupBox2.Size = new System.Drawing.Size(960, 416);
			this.ultraGroupBox2.TabIndex = 18;
			// 
			// btnFilter
			// 
			this.btnFilter.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnFilter.Location = new System.Drawing.Point(424, 32);
			this.btnFilter.Name = "btnFilter";
			this.btnFilter.Size = new System.Drawing.Size(48, 23);
			this.btnFilter.TabIndex = 51;
			this.btnFilter.Text = "检索";
			this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
			// 
			// RemainReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(992, 597);
			this.Controls.Add(this.ultraGroupBox2);
			this.Controls.Add(this.ultraGroupBox1);
			this.Name = "RemainReport";
			this.Text = "预留报表";
			this.Load += new System.EventHandler(this.BookingReport_Load);
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
			this.ultraGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmdBeginDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbShow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
			this.ultraGroupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			string strSql = "select cnvcJobName,cast (cnvcSeat as int) as cnvcSeat,cnvcOperName,cndOperDate from tbShowSeat where cnvcState = '"+ConstApp.Show_Seat_State_Remain+"' and cnvcSeat is not null";						
			
			if (cmbShow.SelectedItem != null)
			{
				strSql += " and cnnJobID="+cmbShow.SelectedItem.DataValue.ToString();

			}
			if (chkBeginDate.Checked)
			{
				strSql += " and cndOperDate >='"+cmdBeginDate.Text+"'";
			}
			if (chkEndDate.Checked)
			{
				strSql += " and cndOperDate <='"+cmbEndDate.Text+"'";
			}
			
			strSql +="  order by cast (cnvcSeat as int)";

			DataTable dt = Helper.Query(strSql);//query.Report(strSql);
			
			this.ultraGrid1.DataSource = null;
			this.ultraGrid1.DataSource = dt;
			this.ultraGrid1.SetDataBinding(dt,null);

            ClientHelper.AddGridColumn(this.ultraGrid1, this.oper.cnvcOperName);
			Helper.AddGridSummary(this.ultraGrid1,SummaryType.Count,"{0}",0);			

		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Helper.Print(this,ultraGrid1,ultraGridPrintDocument1,ultraPrintPreviewDialog1);
		}

		private void BookingReport_Load(object sender, System.EventArgs e)
		{
			this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti; 
			//Helper.BindTrade(cmbTrade);
			//Helper.BindInfoWay(cmbInfoWay);
			//Helper.BindMemberRight(cmbMemberRight);
			cmdBeginDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEndDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmdBeginDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 00:00";
			cmbEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 23:59";
			//Helper.BindJob_Query(cmbShow);
			Helper.BindJob_Query_Limit(cmbShow);
			//Helper.BindMember(cmbMember);
			//Helper.BindSynch(cmbSynch);
			//PopulateValueList();
			this.ultraGrid1.Dock       = DockStyle.Fill;
			this.ultraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
			this.ultraGroupBox2.BringToFront();

            //if (ClientHelper.idept.cnnDeptID != 0)
            //{
            //    if(!Login.constApp.alOperFunc.Contains("预留报表查询"))
            //    {
            //        this.btnQuery.Enabled = false;
            //    }
            //    if(!Login.constApp.alOperFunc.Contains("预留报表打印"))
            //    {
            //        this.btnPrint.Enabled = false;
            //        btnExcel.Enabled = false;
            //    }
            //}
		}

		private void ultraGrid1_InitializePrint(object sender, Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs e)
		{
			Helper.PrintDisplay(e,"云南人才市场预留报表");	


		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
            ClientHelper.ExportExcel(saveFileDialog1, ultraGridExcelExporter1, ultraGrid1, "云南人才市场预留报表", this.oper.cnvcOperName);
		}

		
		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e); 
			
			//e.Layout.Bands[0].Columns["cnnJobID"].Hidden = true;								
			e.Layout.Bands[0].Columns["cnvcJobName"].Header.Caption = "招聘会";
			e.Layout.Bands[0].Columns["cnvcSeat"].Header.Caption = "展位";
			e.Layout.Bands[0].Columns["cnvcOperName"].Header.Caption = "操作员";
			e.Layout.Bands[0].Columns["cndOperDate"].Header.Caption = "操作时间";
			e.Layout.Bands[0].Columns["cndOperDate"].CellActivation = Activation.NoEdit;
			e.Layout.Bands[0].SummaryFooterCaption = "合计：数量"; 
		}

		private void btnFilter_Click(object sender, System.EventArgs e)
		{
			string strBeginDate = DateTime.Parse(this.cmdBeginDate.Value.ToString()).ToString("yyyy-MM-dd");
			string strEndDate = DateTime.Parse(this.cmbEndDate.Value.ToString()).ToString("yyyy-MM-dd");
			//Helper.BindJob_Query_Filter(cmbShow,strBeginDate,strEndDate);
			Helper.BindJob_Query_Filter(cmbShow,chkBeginDate.Checked,strBeginDate,chkEndDate.Checked,strEndDate);
		}
		
	}
}
