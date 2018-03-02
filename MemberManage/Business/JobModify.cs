using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.Domain;
using ynhrMemberManage.ORM;
using System.Data;
using System.Data.SqlClient;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ynhrMemberManage.Common;
using ynhrMemberManage.BusinessFacade;
namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for JobModify.
	/// </summary>
    public class JobModify : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraButton btnQuery;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtJobName;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		public static bool IsShowing ;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBookEndDate;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBookBeginDate;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEnd;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBegin;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtJobTheme;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Infragistics.Win.Misc.UltraButton btnOK;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtJobName2;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEndDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox4;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBeginDate2;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBeginDate2;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEndDate2;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public JobModify()
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
			this.txtJobName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.btnQuery = new Infragistics.Win.Misc.UltraButton();
			this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
			this.cmbBookEndDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.cmbBookBeginDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
			this.cmbEnd = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.cmbBegin = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.txtJobName2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.txtJobTheme = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
			this.btnOK = new Infragistics.Win.Misc.UltraButton();
			this.btnCancel = new Infragistics.Win.Misc.UltraButton();
			this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
			this.cmbBeginDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.chkBeginDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.cmbEndDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.chkEndDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraGroupBox4 = new Infragistics.Win.Misc.UltraGroupBox();
			this.cmbBeginDate2 = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.chkBeginDate2 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.cmbEndDate2 = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.chkEndDate2 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
			this.ultraGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtJobName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
			this.ultraGroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbBookEndDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBookBeginDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBegin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtJobName2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtJobTheme)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
			this.ultraGroupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).BeginInit();
			this.ultraGroupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbEndDate2)).BeginInit();
			this.SuspendLayout();
			// 
			// ultraGroupBox1
			// 
			this.ultraGroupBox1.Controls.Add(this.ultraGroupBox4);
			this.ultraGroupBox1.Controls.Add(this.ultraGroupBox3);
			this.ultraGroupBox1.Controls.Add(this.txtJobName);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
			this.ultraGroupBox1.Controls.Add(this.btnQuery);
			this.ultraGroupBox1.Location = new System.Drawing.Point(208, 40);
			this.ultraGroupBox1.Name = "ultraGroupBox1";
			this.ultraGroupBox1.Size = new System.Drawing.Size(736, 200);
			this.ultraGroupBox1.TabIndex = 0;
			this.ultraGroupBox1.Text = "招聘会信息修改";
			// 
			// txtJobName
			// 
			this.txtJobName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtJobName.Location = new System.Drawing.Point(320, 40);
			this.txtJobName.Name = "txtJobName";
			this.txtJobName.Size = new System.Drawing.Size(224, 21);
			this.txtJobName.TabIndex = 2;
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.Location = new System.Drawing.Point(216, 40);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.TabIndex = 1;
			this.ultraLabel1.Text = "招聘会名称：";
			// 
			// btnQuery
			// 
			this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnQuery.Location = new System.Drawing.Point(640, 80);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.TabIndex = 0;
			this.btnQuery.Text = "查询";
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// ultraGrid1
			// 
			this.ultraGrid1.Location = new System.Drawing.Point(40, 264);
			this.ultraGrid1.Name = "ultraGrid1";
			this.ultraGrid1.Size = new System.Drawing.Size(544, 360);
			this.ultraGrid1.TabIndex = 1;
			this.ultraGrid1.Text = "招聘会信息";
			this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
			this.ultraGrid1.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.ultraGrid1_AfterSelectChange);
			// 
			// ultraGroupBox2
			// 
			this.ultraGroupBox2.Controls.Add(this.cmbBookEndDate);
			this.ultraGroupBox2.Controls.Add(this.cmbBookBeginDate);
			this.ultraGroupBox2.Controls.Add(this.ultraLabel5);
			this.ultraGroupBox2.Controls.Add(this.ultraLabel6);
			this.ultraGroupBox2.Controls.Add(this.cmbEnd);
			this.ultraGroupBox2.Controls.Add(this.cmbBegin);
			this.ultraGroupBox2.Controls.Add(this.txtJobName2);
			this.ultraGroupBox2.Controls.Add(this.ultraLabel2);
			this.ultraGroupBox2.Controls.Add(this.txtJobTheme);
			this.ultraGroupBox2.Controls.Add(this.ultraLabel3);
			this.ultraGroupBox2.Controls.Add(this.ultraLabel4);
			this.ultraGroupBox2.Controls.Add(this.ultraLabel7);
			this.ultraGroupBox2.Controls.Add(this.btnOK);
			this.ultraGroupBox2.Controls.Add(this.btnCancel);
			this.ultraGroupBox2.Location = new System.Drawing.Point(592, 248);
			this.ultraGroupBox2.Name = "ultraGroupBox2";
			this.ultraGroupBox2.Size = new System.Drawing.Size(384, 384);
			this.ultraGroupBox2.TabIndex = 9;
			this.ultraGroupBox2.Text = "招聘会信息修改";
			// 
			// cmbBookEndDate
			// 
			this.cmbBookEndDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbBookEndDate.Location = new System.Drawing.Point(152, 297);
			this.cmbBookEndDate.MaskInput = "{date} {time}";
			this.cmbBookEndDate.Name = "cmbBookEndDate";
			this.cmbBookEndDate.Size = new System.Drawing.Size(200, 21);
			this.cmbBookEndDate.TabIndex = 30;
			// 
			// cmbBookBeginDate
			// 
			this.cmbBookBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbBookBeginDate.Location = new System.Drawing.Point(152, 257);
			this.cmbBookBeginDate.MaskInput = "{date} {time}";
			this.cmbBookBeginDate.Name = "cmbBookBeginDate";
			this.cmbBookBeginDate.Size = new System.Drawing.Size(200, 21);
			this.cmbBookBeginDate.TabIndex = 29;
			// 
			// ultraLabel5
			// 
			this.ultraLabel5.Location = new System.Drawing.Point(40, 257);
			this.ultraLabel5.Name = "ultraLabel5";
			this.ultraLabel5.Size = new System.Drawing.Size(96, 23);
			this.ultraLabel5.TabIndex = 27;
			this.ultraLabel5.Text = "预订开始时间：";
			// 
			// ultraLabel6
			// 
			this.ultraLabel6.Location = new System.Drawing.Point(40, 297);
			this.ultraLabel6.Name = "ultraLabel6";
			this.ultraLabel6.Size = new System.Drawing.Size(104, 23);
			this.ultraLabel6.TabIndex = 28;
			this.ultraLabel6.Text = "预订结束时间：";
			// 
			// cmbEnd
			// 
			this.cmbEnd.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbEnd.Location = new System.Drawing.Point(152, 217);
			this.cmbEnd.MaskInput = "{date} {time}";
			this.cmbEnd.Name = "cmbEnd";
			this.cmbEnd.Size = new System.Drawing.Size(200, 21);
			this.cmbEnd.TabIndex = 26;
			// 
			// cmbBegin
			// 
			this.cmbBegin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbBegin.Location = new System.Drawing.Point(152, 177);
			this.cmbBegin.MaskInput = "{date} {time}";
			this.cmbBegin.Name = "cmbBegin";
			this.cmbBegin.Size = new System.Drawing.Size(200, 21);
			this.cmbBegin.TabIndex = 25;
			// 
			// txtJobName2
			// 
			this.txtJobName2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtJobName2.Location = new System.Drawing.Point(152, 41);
			this.txtJobName2.Name = "txtJobName2";
			this.txtJobName2.Size = new System.Drawing.Size(200, 21);
			this.txtJobName2.TabIndex = 20;
			// 
			// ultraLabel2
			// 
			this.ultraLabel2.Location = new System.Drawing.Point(48, 41);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.TabIndex = 19;
			this.ultraLabel2.Text = "招聘会名称：";
			// 
			// txtJobTheme
			// 
			this.txtJobTheme.AutoSize = false;
			this.txtJobTheme.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtJobTheme.Location = new System.Drawing.Point(152, 81);
			this.txtJobTheme.Multiline = true;
			this.txtJobTheme.Name = "txtJobTheme";
			this.txtJobTheme.Scrollbars = System.Windows.Forms.ScrollBars.Both;
			this.txtJobTheme.Size = new System.Drawing.Size(200, 72);
			this.txtJobTheme.TabIndex = 22;
			// 
			// ultraLabel3
			// 
			this.ultraLabel3.Location = new System.Drawing.Point(48, 89);
			this.ultraLabel3.Name = "ultraLabel3";
			this.ultraLabel3.TabIndex = 21;
			this.ultraLabel3.Text = "招聘会主题：";
			// 
			// ultraLabel4
			// 
			this.ultraLabel4.Location = new System.Drawing.Point(32, 177);
			this.ultraLabel4.Name = "ultraLabel4";
			this.ultraLabel4.Size = new System.Drawing.Size(112, 23);
			this.ultraLabel4.TabIndex = 23;
			this.ultraLabel4.Text = "招聘会开始时间：";
			// 
			// ultraLabel7
			// 
			this.ultraLabel7.Location = new System.Drawing.Point(32, 217);
			this.ultraLabel7.Name = "ultraLabel7";
			this.ultraLabel7.Size = new System.Drawing.Size(112, 23);
			this.ultraLabel7.TabIndex = 24;
			this.ultraLabel7.Text = "招聘会结束时间：";
			// 
			// btnOK
			// 
			this.btnOK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnOK.Location = new System.Drawing.Point(104, 344);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 17;
			this.btnOK.Text = "确定";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnCancel.Location = new System.Drawing.Point(232, 344);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 18;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// ultraGroupBox3
			// 
			this.ultraGroupBox3.Controls.Add(this.cmbBeginDate);
			this.ultraGroupBox3.Controls.Add(this.chkBeginDate);
			this.ultraGroupBox3.Controls.Add(this.cmbEndDate);
			this.ultraGroupBox3.Controls.Add(this.chkEndDate);
			this.ultraGroupBox3.Location = new System.Drawing.Point(16, 80);
			this.ultraGroupBox3.Name = "ultraGroupBox3";
			this.ultraGroupBox3.Size = new System.Drawing.Size(296, 96);
			this.ultraGroupBox3.TabIndex = 17;
			this.ultraGroupBox3.Text = "招聘会开始时间";
			// 
			// cmbBeginDate
			// 
			this.cmbBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbBeginDate.Location = new System.Drawing.Point(136, 24);
			this.cmbBeginDate.MaskInput = "{date} {time}";
			this.cmbBeginDate.Name = "cmbBeginDate";
			this.cmbBeginDate.TabIndex = 12;
			// 
			// chkBeginDate
			// 
			this.chkBeginDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.chkBeginDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.chkBeginDate.Location = new System.Drawing.Point(16, 24);
			this.chkBeginDate.Name = "chkBeginDate";
			this.chkBeginDate.TabIndex = 14;
			this.chkBeginDate.Text = "开始时间";
			// 
			// cmbEndDate
			// 
			this.cmbEndDate.DateTime = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
			this.cmbEndDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbEndDate.Location = new System.Drawing.Point(136, 56);
			this.cmbEndDate.MaskInput = "{date} {time}";
			this.cmbEndDate.Name = "cmbEndDate";
			this.cmbEndDate.TabIndex = 13;
			this.cmbEndDate.Value = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
			// 
			// chkEndDate
			// 
			this.chkEndDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.chkEndDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.chkEndDate.Location = new System.Drawing.Point(16, 56);
			this.chkEndDate.Name = "chkEndDate";
			this.chkEndDate.TabIndex = 15;
			this.chkEndDate.Text = "结束时间";
			// 
			// ultraGroupBox4
			// 
			this.ultraGroupBox4.Controls.Add(this.cmbBeginDate2);
			this.ultraGroupBox4.Controls.Add(this.chkBeginDate2);
			this.ultraGroupBox4.Controls.Add(this.cmbEndDate2);
			this.ultraGroupBox4.Controls.Add(this.chkEndDate2);
			this.ultraGroupBox4.Location = new System.Drawing.Point(328, 80);
			this.ultraGroupBox4.Name = "ultraGroupBox4";
			this.ultraGroupBox4.Size = new System.Drawing.Size(296, 96);
			this.ultraGroupBox4.TabIndex = 18;
			this.ultraGroupBox4.Text = "招聘会结束时间";
			// 
			// cmbBeginDate2
			// 
			this.cmbBeginDate2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbBeginDate2.Location = new System.Drawing.Point(136, 24);
			this.cmbBeginDate2.MaskInput = "{date} {time}";
			this.cmbBeginDate2.Name = "cmbBeginDate2";
			this.cmbBeginDate2.TabIndex = 12;
			// 
			// chkBeginDate2
			// 
			this.chkBeginDate2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.chkBeginDate2.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.chkBeginDate2.Location = new System.Drawing.Point(16, 24);
			this.chkBeginDate2.Name = "chkBeginDate2";
			this.chkBeginDate2.TabIndex = 14;
			this.chkBeginDate2.Text = "开始时间";
			// 
			// cmbEndDate2
			// 
			this.cmbEndDate2.DateTime = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
			this.cmbEndDate2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbEndDate2.Location = new System.Drawing.Point(136, 56);
			this.cmbEndDate2.MaskInput = "{date} {time}";
			this.cmbEndDate2.Name = "cmbEndDate2";
			this.cmbEndDate2.TabIndex = 13;
			this.cmbEndDate2.Value = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
			// 
			// chkEndDate2
			// 
			this.chkEndDate2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.chkEndDate2.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.chkEndDate2.Location = new System.Drawing.Point(16, 56);
			this.chkEndDate2.Name = "chkEndDate2";
			this.chkEndDate2.TabIndex = 15;
			this.chkEndDate2.Text = "结束时间";
			// 
			// JobModify
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(992, 659);
			this.Controls.Add(this.ultraGroupBox2);
			this.Controls.Add(this.ultraGrid1);
			this.Controls.Add(this.ultraGroupBox1);
			this.Name = "JobModify";
			this.Text = "招聘会信息修改";
			this.Load += new System.EventHandler(this.JobModify_Load);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
			this.ultraGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtJobName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
			this.ultraGroupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbBookEndDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBookBeginDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBegin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtJobName2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtJobTheme)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
			this.ultraGroupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).EndInit();
			this.ultraGroupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbEndDate2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (txtJobName2.Text.Trim().Length == 0)
				{
					throw new BusinessException("招聘会信息修改","招聘会名称不能为空");
				}
				Job job = new Job();
				job.cnnJobID = int.Parse(txtJobName2.Tag.ToString());
				job.cnvcJobName = txtJobName2.Text;				
				job.cnvcJobTheme = txtJobTheme.Text;				
				job.cndBeginDate = DateTime.Parse(cmbBegin.Text);
				job.cndEndDate = DateTime.Parse(cmbEnd.Text);
				job.cndBookBeginDate = DateTime.Parse(cmbBookBeginDate.Text);
				job.cndBookEndDate = DateTime.Parse(cmbBookEndDate.Text);
				job.cnvcOperName = this.oper.cnvcOperName;
				job.cndOperDate = DateTime.Now;
				JobManage jobManage = new JobManage();
				jobManage.ModifyJob(job);
				MessageBox.Show(this,"招聘会信息修改成功！","招聘会信息修改",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

		private void ClearText()
		{
			txtJobName2.Text = "";
			txtJobTheme.Text = "";
			cmbBegin.Text = "";
			cmbEnd.Text = "";
			cmbBookBeginDate.Text = "";
			cmbBookEndDate.Text = "";
			btnOK.Enabled = false;

		}
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			try
			{
				string strSql = "select * from tbJob where 1=1";
				if (txtJobName.Text.Trim().Length > 0)
				{
					strSql += " and cnvcJobName like '%"+txtJobName.Text+"%'";
				}
				if (chkBeginDate.Checked)
				{
					strSql += " and cndBeginDate >='"+cmbBeginDate.Value.ToString()+"'";
				}
				if (chkEndDate.Checked)
				{
					strSql += " and cndBeginDate <='"+cmbEndDate.Value.ToString()+"'";
				}
				if (chkBeginDate2.Checked)
				{
					strSql += " and cndEndDate >='"+cmbBeginDate2.Value.ToString()+"'";
				}
				if (chkEndDate2.Checked)
				{
					strSql += " and cndEndDate <='"+cmbEndDate2.Value.ToString()+"'";
				}
				strSql += "order by cndBeginDate";
				DataTable dtJob = Helper.Query(strSql);
				this.ultraGrid1.DataSource = null;
				this.ultraGrid1.DataSource = dtJob;
				this.ultraGrid1.DataBind();
				ClearText();

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


		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e);
			e.Layout.Bands[0].Columns["cnnJobID"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcOperName"].Hidden = true;
			e.Layout.Bands[0].Columns["cndOperDate"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcJobName"].Header.Caption = "招聘会名称";
			e.Layout.Bands[0].Columns["cnvcJobTheme"].Header.Caption = "招聘会主题";
			e.Layout.Bands[0].Columns["cndBeginDate"].Header.Caption = "招聘会开始时间";
			e.Layout.Bands[0].Columns["cndEndDate"].Header.Caption = "招聘会结束时间";
			e.Layout.Bands[0].Columns["cndBookBeginDate"].Header.Caption = "预订开始时间";
			e.Layout.Bands[0].Columns["cndBookEndDate"].Header.Caption = "预订结束时间";
			e.Layout.Bands[0].Columns["cndBeginDate"].Format = "yyyy-MM-dd hh:mm";	
			e.Layout.Bands[0].Columns["cndEndDate"].Format = "yyyy-MM-dd hh:mm";	
			e.Layout.Bands[0].Columns["cndBookBeginDate"].Format = "yyyy-MM-dd hh:mm";	
			e.Layout.Bands[0].Columns["cndBookEndDate"].Format = "yyyy-MM-dd hh:mm";	

			e.Layout.Bands[0].Columns["cndBeginDate"].CellActivation = Activation.NoEdit;
			e.Layout.Bands[0].Columns["cndEndDate"].CellActivation = Activation.NoEdit;
			e.Layout.Bands[0].Columns["cndBookBeginDate"].CellActivation = Activation.NoEdit;
			e.Layout.Bands[0].Columns["cndBookEndDate"].CellActivation = Activation.NoEdit;
		}

		private void ultraGrid1_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			UltraGridRow activeRow = this.ultraGrid1.ActiveRow; 
			if (null != activeRow)
			{
				this.txtJobName2.Text = activeRow.Cells["cnvcJobName"].Value.ToString();
				this.txtJobName2.Tag = activeRow.Cells["cnnJobID"].Value; 
				this.txtJobTheme.Text = activeRow.Cells["cnvcJobTheme"].Value.ToString();
				cmbBegin.Text = activeRow.Cells["cndBeginDate"].Value.ToString();
				cmbEnd.Text = activeRow.Cells["cndEndDate"].Value.ToString();
				cmbBookBeginDate.Text = activeRow.Cells["cndBookBeginDate"].Value.ToString();
				cmbBookEndDate.Text = activeRow.Cells["cndBookEndDate"].Value.ToString();
				btnOK.Enabled = true;
			}			
		
		}

		private void JobModify_Load(object sender, System.EventArgs e)
		{
			cmbBegin.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEnd.MaskInput = "yyyy-mm-dd hh:mm";
			cmbBookBeginDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbBookEndDate.MaskInput = "yyyy-mm-dd hh:mm";


			cmbBeginDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEndDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbBeginDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 00:00";
			cmbEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 23:59";

			cmbBeginDate2.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEndDate2.MaskInput = "yyyy-mm-dd hh:mm";
			cmbBeginDate2.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 00:00";
			cmbEndDate2.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 23:59";
		}
	}
}
