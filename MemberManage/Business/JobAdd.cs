using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.Domain;
using ynhrMemberManage.ORM;
using System.Data;
using System.Data.SqlClient;
using ynhrMemberManage.Common;
using ynhrMemberManage.BusinessFacade;

namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for JobAdd.
	/// </summary>
    public class JobAdd : frmBase
	{
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;

		public static bool IsShowing ;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtJobName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtJobTheme;
		private Infragistics.Win.Misc.UltraButton btnOK;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBegin;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEnd;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBookEndDate;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBookBeginDate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public JobAdd()
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
			this.btnOK = new Infragistics.Win.Misc.UltraButton();
			this.btnCancel = new Infragistics.Win.Misc.UltraButton();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.txtJobName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.txtJobTheme = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
			this.cmbBookEndDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.cmbBookBeginDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
			this.cmbEnd = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.cmbBegin = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			((System.ComponentModel.ISupportInitialize)(this.txtJobName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtJobTheme)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
			this.ultraGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbBookEndDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBookBeginDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBegin)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnOK.Location = new System.Drawing.Point(96, 392);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "ȷ��";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnCancel.Location = new System.Drawing.Point(224, 392);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "ȡ��";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.Location = new System.Drawing.Point(64, 48);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.TabIndex = 2;
			this.ultraLabel1.Text = "��Ƹ�����ƣ�";
			// 
			// txtJobName
			// 
			this.txtJobName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtJobName.Location = new System.Drawing.Point(168, 48);
			this.txtJobName.Name = "txtJobName";
			this.txtJobName.Size = new System.Drawing.Size(200, 21);
			this.txtJobName.TabIndex = 3;
			// 
			// ultraLabel2
			// 
			this.ultraLabel2.Location = new System.Drawing.Point(64, 96);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.TabIndex = 4;
			this.ultraLabel2.Text = "��Ƹ�����⣺";
			// 
			// txtJobTheme
			// 
			this.txtJobTheme.AutoSize = false;
			this.txtJobTheme.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtJobTheme.Location = new System.Drawing.Point(168, 88);
			this.txtJobTheme.Multiline = true;
			this.txtJobTheme.Name = "txtJobTheme";
			this.txtJobTheme.Scrollbars = System.Windows.Forms.ScrollBars.Both;
			this.txtJobTheme.Size = new System.Drawing.Size(200, 72);
			this.txtJobTheme.TabIndex = 5;
			// 
			// ultraLabel3
			// 
			this.ultraLabel3.Location = new System.Drawing.Point(48, 184);
			this.ultraLabel3.Name = "ultraLabel3";
			this.ultraLabel3.Size = new System.Drawing.Size(112, 23);
			this.ultraLabel3.TabIndex = 6;
			this.ultraLabel3.Text = "��Ƹ�Ὺʼʱ�䣺";
			// 
			// ultraLabel4
			// 
			this.ultraLabel4.Location = new System.Drawing.Point(48, 224);
			this.ultraLabel4.Name = "ultraLabel4";
			this.ultraLabel4.Size = new System.Drawing.Size(112, 23);
			this.ultraLabel4.TabIndex = 7;
			this.ultraLabel4.Text = "��Ƹ�����ʱ�䣺";
			// 
			// ultraGroupBox1
			// 
			this.ultraGroupBox1.Controls.Add(this.cmbBookEndDate);
			this.ultraGroupBox1.Controls.Add(this.cmbBookBeginDate);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel5);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel6);
			this.ultraGroupBox1.Controls.Add(this.cmbEnd);
			this.ultraGroupBox1.Controls.Add(this.cmbBegin);
			this.ultraGroupBox1.Controls.Add(this.txtJobName);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
			this.ultraGroupBox1.Controls.Add(this.txtJobTheme);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel4);
			this.ultraGroupBox1.Controls.Add(this.btnOK);
			this.ultraGroupBox1.Controls.Add(this.btnCancel);
			this.ultraGroupBox1.Location = new System.Drawing.Point(248, 16);
			this.ultraGroupBox1.Name = "ultraGroupBox1";
			this.ultraGroupBox1.Size = new System.Drawing.Size(384, 472);
			this.ultraGroupBox1.TabIndex = 8;
			// 
			// cmbBookEndDate
			// 
			this.cmbBookEndDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbBookEndDate.Location = new System.Drawing.Point(168, 304);
			this.cmbBookEndDate.MaskInput = "{date} {time}";
			this.cmbBookEndDate.Name = "cmbBookEndDate";
			this.cmbBookEndDate.Size = new System.Drawing.Size(200, 21);
			this.cmbBookEndDate.TabIndex = 16;
			// 
			// cmbBookBeginDate
			// 
			this.cmbBookBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbBookBeginDate.Location = new System.Drawing.Point(168, 264);
			this.cmbBookBeginDate.MaskInput = "{date} {time}";
			this.cmbBookBeginDate.Name = "cmbBookBeginDate";
			this.cmbBookBeginDate.Size = new System.Drawing.Size(200, 21);
			this.cmbBookBeginDate.TabIndex = 15;
			// 
			// ultraLabel5
			// 
			this.ultraLabel5.Location = new System.Drawing.Point(56, 264);
			this.ultraLabel5.Name = "ultraLabel5";
			this.ultraLabel5.Size = new System.Drawing.Size(96, 23);
			this.ultraLabel5.TabIndex = 13;
			this.ultraLabel5.Text = "Ԥ����ʼʱ�䣺";
			// 
			// ultraLabel6
			// 
			this.ultraLabel6.Location = new System.Drawing.Point(56, 304);
			this.ultraLabel6.Name = "ultraLabel6";
			this.ultraLabel6.Size = new System.Drawing.Size(104, 23);
			this.ultraLabel6.TabIndex = 14;
			this.ultraLabel6.Text = "Ԥ������ʱ�䣺";
			// 
			// cmbEnd
			// 
			this.cmbEnd.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbEnd.Location = new System.Drawing.Point(168, 224);
			this.cmbEnd.MaskInput = "{date} {time}";
			this.cmbEnd.Name = "cmbEnd";
			this.cmbEnd.Size = new System.Drawing.Size(200, 21);
			this.cmbEnd.TabIndex = 12;
			this.cmbEnd.ValueChanged += new System.EventHandler(this.cmbEnd_ValueChanged);
			// 
			// cmbBegin
			// 
			this.cmbBegin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbBegin.Location = new System.Drawing.Point(168, 184);
			this.cmbBegin.MaskInput = "{date} {time}";
			this.cmbBegin.Name = "cmbBegin";
			this.cmbBegin.Size = new System.Drawing.Size(200, 21);
			this.cmbBegin.TabIndex = 11;
			this.cmbBegin.ValueChanged += new System.EventHandler(this.cmbBegin_ValueChanged);
			// 
			// JobAdd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(880, 517);
			this.Controls.Add(this.ultraGroupBox1);
			this.Name = "JobAdd";
			this.Text = "��Ƹ������";
			this.Load += new System.EventHandler(this.JobAdd_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtJobName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtJobTheme)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
			this.ultraGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbBookEndDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBookBeginDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBegin)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (txtJobName.Text.Trim().Length == 0)
				{
					throw new BusinessException("��Ƹ������","��������Ƹ�����ƣ�");
				}
				DataTable dtJob = Helper.Query("select * from tbJob where cnvcJobName ='"+txtJobName.Text+"'");
				if (dtJob.Rows.Count > 0)
				{
					throw new BusinessException("��Ƹ������","ͬ����Ƹ���Ѵ��ڣ�");
				}
				Job job = new Job();
				job.cnvcJobName = txtJobName.Text;
				job.cnvcJobTheme = txtJobTheme.Text;
				job.cndBeginDate = DateTime.Parse(cmbBegin.Text);
				job.cndEndDate = DateTime.Parse(cmbEnd.Text);
				job.cndBookBeginDate = DateTime.Parse(cmbBookBeginDate.Text);
				job.cndBookEndDate = DateTime.Parse(cmbBookEndDate.Text);
				job.cnvcOperName = this.oper.cnvcOperName;
				job.cndOperDate = DateTime.Now;
				if (job.cndEndDate < job.cndBeginDate)
				{
					throw new BusinessException("��Ƹ������","��Ƹ�Ὺʼʱ�䲻�ܴ��ڽ���ʱ�䣡");
				}
				if (job.cndBookEndDate < job.cndBookBeginDate)
				{
					throw new BusinessException("��Ƹ������","��Ƹ��Ԥ����ʼʱ�䲻�ܴ���Ԥ������ʱ�䣡");
				}
				if (job.cndEndDate < job.cndBookEndDate)
				{
					throw new BusinessException("��Ƹ������","��Ƹ��Ԥ����ʼʱ�䲻�ܴ�����Ƹ�����ʱ�䣡");
				}
				JobManage jobManage = new JobManage();
				jobManage.AddJob(job);
				MessageBox.Show(this,"�����Ƹ��ɹ���","��Ƹ������",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtJobName.Text = "";
				txtJobTheme.Text = "";

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

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void JobAdd_Load(object sender, System.EventArgs e)
		{
			cmbBegin.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEnd.MaskInput = "yyyy-mm-dd hh:mm";
			cmbBookBeginDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbBookEndDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEnd.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 23:59";
			cmbBookEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 23:59";

			DateTime dtBegin = DateTime.Parse(cmbBegin.Value.ToString());
			cmbBookBeginDate.Value = dtBegin.AddDays(-(Login.constApp.iBookDate)).ToString("yyyy-MM-dd");			

		}

		private void cmbBegin_ValueChanged(object sender, System.EventArgs e)
		{
			DateTime dtBegin = DateTime.Parse(cmbBegin.Value.ToString());
			cmbBookBeginDate.Value = dtBegin.AddDays(-(Login.constApp.iBookDate)).ToString("yyyy-MM-dd");			
		}

		private void cmbEnd_ValueChanged(object sender, System.EventArgs e)
		{
			cmbBookEndDate.Value = cmbEnd.Value;
		}
	}
}
