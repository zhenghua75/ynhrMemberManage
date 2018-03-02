using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Infragistics;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using MemberManage.Business;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Common;
namespace MemberManage.MemberReport
{
	/// <summary>
	/// Summary description for OperLogReport.
	/// </summary>
    public class OperLogReport : frmBase
	{
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.Printing.UltraPrintPreviewDialog ultraPrintPreviewDialog1;
		private Infragistics.Win.UltraWinGrid.UltraGridPrintDocument ultraGridPrintDocument1;
		private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraButton btnExcel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbOperName;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.Misc.UltraButton btnQuery;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		private System.ComponentModel.IContainer components;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbSynch;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEndDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBeginDate;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbOperFlag;
		public static bool IsShowing ;

		public OperLogReport()
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
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraPrintPreviewDialog1 = new Infragistics.Win.Printing.UltraPrintPreviewDialog(this.components);
            this.ultraGridPrintDocument1 = new Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(this.components);
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbOperFlag = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbEndDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.chkEndDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cmbBeginDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.chkBeginDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbSynch = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnExcel = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbOperName = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.btnQuery = new Infragistics.Win.Misc.UltraButton();
            this.txtPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOperFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSynch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOperName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.ultraGrid1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(16, 205);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(932, 387);
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
            // ultraPrintPreviewDialog1
            // 
            this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox2.Controls.Add(this.cmbOperFlag);
            this.ultraGroupBox2.Controls.Add(this.cmbEndDate);
            this.ultraGroupBox2.Controls.Add(this.chkEndDate);
            this.ultraGroupBox2.Controls.Add(this.cmbBeginDate);
            this.ultraGroupBox2.Controls.Add(this.chkBeginDate);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel9);
            this.ultraGroupBox2.Controls.Add(this.cmbSynch);
            this.ultraGroupBox2.Controls.Add(this.btnExcel);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox2.Controls.Add(this.cmbOperName);
            this.ultraGroupBox2.Controls.Add(this.ultraButton1);
            this.ultraGroupBox2.Controls.Add(this.btnQuery);
            this.ultraGroupBox2.Controls.Add(this.txtPaperNo);
            this.ultraGroupBox2.Controls.Add(this.txtMemberName);
            this.ultraGroupBox2.Controls.Add(this.txtMemberCardNo);
            this.ultraGroupBox2.Location = new System.Drawing.Point(104, 32);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(720, 168);
            this.ultraGroupBox2.TabIndex = 8;
            this.ultraGroupBox2.Text = "查找";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(24, 136);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(96, 23);
            this.ultraLabel4.TabIndex = 45;
            this.ultraLabel4.Text = "操作类型：";
            // 
            // cmbOperFlag
            // 
            this.cmbOperFlag.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbOperFlag.Location = new System.Drawing.Point(128, 136);
            this.cmbOperFlag.Name = "cmbOperFlag";
            this.cmbOperFlag.Size = new System.Drawing.Size(144, 21);
            this.cmbOperFlag.TabIndex = 44;
            // 
            // cmbEndDate
            // 
            this.cmbEndDate.DateTime = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
            this.cmbEndDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbEndDate.Location = new System.Drawing.Point(392, 86);
            this.cmbEndDate.MaskInput = "{date} {time}";
            this.cmbEndDate.Name = "cmbEndDate";
            this.cmbEndDate.Size = new System.Drawing.Size(144, 21);
            this.cmbEndDate.TabIndex = 41;
            this.cmbEndDate.Value = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
            // 
            // chkEndDate
            // 
            this.chkEndDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.chkEndDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkEndDate.Location = new System.Drawing.Point(320, 86);
            this.chkEndDate.Name = "chkEndDate";
            this.chkEndDate.Size = new System.Drawing.Size(72, 20);
            this.chkEndDate.TabIndex = 43;
            this.chkEndDate.Text = "结束时间";
            // 
            // cmbBeginDate
            // 
            this.cmbBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbBeginDate.Location = new System.Drawing.Point(392, 62);
            this.cmbBeginDate.MaskInput = "{date} {time}";
            this.cmbBeginDate.Name = "cmbBeginDate";
            this.cmbBeginDate.Size = new System.Drawing.Size(144, 21);
            this.cmbBeginDate.TabIndex = 40;
            // 
            // chkBeginDate
            // 
            this.chkBeginDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.chkBeginDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkBeginDate.Location = new System.Drawing.Point(320, 62);
            this.chkBeginDate.Name = "chkBeginDate";
            this.chkBeginDate.Size = new System.Drawing.Size(80, 20);
            this.chkBeginDate.TabIndex = 42;
            this.chkBeginDate.Text = "开始时间";
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.Location = new System.Drawing.Point(288, 136);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(96, 23);
            this.ultraLabel9.TabIndex = 39;
            this.ultraLabel9.Text = "同步标志：";
            // 
            // cmbSynch
            // 
            this.cmbSynch.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbSynch.Location = new System.Drawing.Point(392, 136);
            this.cmbSynch.Name = "cmbSynch";
            this.cmbSynch.Size = new System.Drawing.Size(144, 21);
            this.cmbSynch.TabIndex = 38;
            // 
            // btnExcel
            // 
            this.btnExcel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnExcel.Location = new System.Drawing.Point(592, 104);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 37;
            this.btnExcel.Text = "导出EXCEL";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(288, 32);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(64, 23);
            this.ultraLabel5.TabIndex = 36;
            this.ultraLabel5.Text = "操作员：";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(24, 104);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 34;
            this.ultraLabel3.Text = "单位名称：";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(24, 64);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 33;
            this.ultraLabel2.Text = "工商注册号：";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(24, 32);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 32;
            this.ultraLabel1.Text = "会员卡号：";
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
            this.ultraButton1.Location = new System.Drawing.Point(592, 64);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 19;
            this.ultraButton1.Text = "打印";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnQuery.Location = new System.Drawing.Point(592, 24);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 18;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtPaperNo
            // 
            this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPaperNo.Location = new System.Drawing.Point(128, 64);
            this.txtPaperNo.Name = "txtPaperNo";
            this.txtPaperNo.Size = new System.Drawing.Size(136, 21);
            this.txtPaperNo.TabIndex = 17;
            // 
            // txtMemberName
            // 
            this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberName.Location = new System.Drawing.Point(128, 104);
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
            // OperLogReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1000, 605);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.ultraGroupBox2);
            this.Name = "OperLogReport";
            this.Text = Login.constApp.strCardTypeL6Name + "操作日志报表";
            this.Load += new System.EventHandler(this.OperLogReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOperFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSynch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOperName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void OperLogReport_Load(object sender, System.EventArgs e)
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
			cmbOperName.DataBind();
			Helper.BindSynch(cmbSynch);
			BindOperFlag();

			this.ultraGrid1.Dock       = DockStyle.Fill;
			this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
			this.ultraGroupBox1.BringToFront();

            //if (ClientHelper.idept.cnnDeptID != 0)
            //{
            //    if(!Login.constApp.alOperFunc.Contains("操作日志报表查询"))
            //    {
            //        this.btnQuery.Enabled = false;
            //    }
            //    if(!Login.constApp.alOperFunc.Contains("操作日志报表打印"))
            //    {
            //        this.ultraButton1.Enabled = false;
            //        btnExcel.Enabled = false;
            //    }
            //}
		}

		private void BindOperFlag()
		{
			DataTable dtOperFlag = Helper.Query("select distinct cnvcOperFlag from tbOperLog");
			cmbOperFlag.DataSource = dtOperFlag;
			cmbOperFlag.DataBind();
		}
		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e); 		
			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "会员卡号";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "金额";
			e.Layout.Bands[0].Columns["cnvcFree"].Header.Caption = "场次";
            e.Layout.Bands[0].Columns["cnvcFree"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcOperFlag"].Header.Caption = "操作";
			e.Layout.Bands[0].Columns["cnvcOperName"].Header.Caption = "操作员名称";
			e.Layout.Bands[0].Columns["cndOperDate"].Header.Caption = "操作时间";
			e.Layout.Bands[0].Columns["cnvcSynch"].Header.Caption = "同步标志";
			e.Layout.Bands[0].Columns["cndOperDate"].CellActivation = Activation.NoEdit;
			e.Layout.Bands[0].Columns["cndOperDate"].Format = "yyyy-MM-dd hh:mm";

			e.Layout.Bands[0].SummaryFooterCaption = "合计："; 
		}

		private void ultraGrid1_InitializePrint(object sender, Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs e)
		{
			Helper.PrintDisplay(e,"云南人才市场操作日志报表");	
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			try
			{
				//string strSql = "select cnnJobID,'' as cnvcJobName,cnvcMemberCardNo,cnvcPaperNo,'' as cnvcMemberName,cnnPrepay,cnnReturn,cnnBalance,cnvcState,cnvcOperName,cndOperDate from tbPrepay where 1=1 ";
				string strSql = "select a.cnvcOperName,a.cndOperDate,a.cnvcMemberCardNo,case when b.cnvcMemberCardNo is null then c.cnvcPaperNo "
+" else b.cnvcPaperNo end as cnvcPaperNo,"
					          +" case when b.cnvcMemberName is null then c.cnvcMemberName"
                              + " when c.cnvcMemberName is null then b.cnvcMemberName else b.cnvcMemberName "
							  +" end cnvcMemberName,a.cnvcFree,a.cnnPrepay,a.cnvcOperFlag"
					+ " ,case a.cniSynch "
					+ " when 0 then '会员系统' "
					+ " when 1 then '网站操作' "
					+ " when 2 then '触摸屏操作'  "
                    + " when 3 then '客服预定' "
					+ " end cnvcSynch "
							  +" from tbOperLog a"
                              + " left outer join tbMember b on a.cnvcMemberCardNo=b.cnvcMemberCardNo  "
						      +" left outer join tbFMember c on a.cnvcPaperNo=c.cnvcPaperNo";
				strSql += " where (a.cnvcMemberCardNo is null or Len(a.cnvcMemberCardNo)=6) ";
				if (txtMemberCardNo.Text.Trim().Length > 0)
				{
					strSql += " and a.cnvcMemberCardNo is not null and a.cnvcMemberCardNo like '%"+txtMemberCardNo.Text+"%'";
				}
				if (txtMemberName.Text!="")
				{
					strSql += " and (b.cnvcMemberName like '%"+txtMemberName.Text+"%' or c.cnvcMemberName like '"+txtMemberName.Text+"')";
				}
				if (txtPaperNo.Text.Trim().Length > 0)
				{
					strSql += " and (b.cnvcPaperNo like '"+txtPaperNo.Text+"' or c.cnvcPaperNo like '%"+txtPaperNo.Text+"%')";
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
				if (cmbSynch.Text.Trim().Length > 0)
				{
					strSql += " and a.cniSynch = "+cmbSynch.Value.ToString();
				}
				if (cmbOperFlag.Text.Trim().Length > 0)
				{
					strSql += " and cnvcOperFlag = '"+cmbOperFlag.Text+"'";
				}
				strSql += " order by  a.cndOperDate " ;
				DataTable dtPrepay = Helper.Query(strSql);
				this.ultraGrid1.DataSource = null;
				this.ultraGrid1.DataSource = dtPrepay;
				this.ultraGrid1.DataBind();

                ClientHelper.AddGridColumn(this.ultraGrid1, this.oper.cnvcOperName);
				Helper.AddGridSummary(this.ultraGrid1,SummaryType.Count,"操作条数：{0}","cnvcOperName");		
//				Helper.AddGridSummary(this.ultraGrid1,SummaryType.Sum,"充值总额：{0}","cnnPrepay");		
//				Helper.AddGridSummary(this.ultraGrid1,SummaryType.Sum,"免费场次余额总额：{0}","cnvcFreeBalance");		
//				Helper.AddGridSummary(this.ultraGrid1,SummaryType.Sum,"缴费总额：{0}","cnnBalance");		
//				Helper.AddGridSummary(this.ultraGrid1,SummaryType.Sum,"免费场次总额：{0}","cnvcFree");	
//				Helper.AddGridSummary(this.ultraGrid1,SummaryType.Sum,"会员费总额：{0}","cnnMemberFee");	
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

		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			Helper.Print(this,ultraGrid1,ultraGridPrintDocument1,ultraPrintPreviewDialog1);
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
            ClientHelper.ExportExcel(saveFileDialog1, ultraGridExcelExporter1, ultraGrid1, "云南人才市场操作日志报表", this.oper.cnvcOperName);
		}
	}
}
