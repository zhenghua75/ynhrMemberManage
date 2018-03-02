using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.Domain;
using ynhrMemberManage.ORM;
using System.Data;
using System.Data.SqlClient;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Common;

namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for ShowEnd.
	/// </summary>
    public class JobEnd : frmBase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbShow;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraButton btnOK;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo txtEndDate;
		public static bool IsShowing ;

		public JobEnd()
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
			Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
			this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.cmbShow = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.txtEndDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
			this.btnOK = new Infragistics.Win.Misc.UltraButton();
			this.btnCancel = new Infragistics.Win.Misc.UltraButton();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
			this.ultraGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbShow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEndDate)).BeginInit();
			this.SuspendLayout();
			// 
			// ultraGroupBox1
			// 
			this.ultraGroupBox1.Controls.Add(this.btnCancel);
			this.ultraGroupBox1.Controls.Add(this.btnOK);
			this.ultraGroupBox1.Controls.Add(this.txtEndDate);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
			this.ultraGroupBox1.Controls.Add(this.cmbShow);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
			this.ultraGroupBox1.Location = new System.Drawing.Point(24, 40);
			this.ultraGroupBox1.Name = "ultraGroupBox1";
			this.ultraGroupBox1.Size = new System.Drawing.Size(448, 344);
			this.ultraGroupBox1.TabIndex = 0;
			this.ultraGroupBox1.Text = "ultraGroupBox1";
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.Location = new System.Drawing.Point(48, 48);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.TabIndex = 0;
			this.ultraLabel1.Text = "招聘会：";
			// 
			// cmbShow
			// 
			this.cmbShow.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbShow.Location = new System.Drawing.Point(168, 48);
			this.cmbShow.Name = "cmbShow";
			this.cmbShow.TabIndex = 1;
			// 
			// ultraLabel2
			// 
			this.ultraLabel2.Location = new System.Drawing.Point(48, 104);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.TabIndex = 2;
			this.ultraLabel2.Text = "结束时间：";
			// 
			// txtEndDate
			// 
			this.txtEndDate.BackColor = System.Drawing.SystemColors.Window;
			this.txtEndDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.txtEndDate.DateButtons.Add(dateButton1);
			this.txtEndDate.Location = new System.Drawing.Point(168, 104);
			this.txtEndDate.Name = "txtEndDate";
			this.txtEndDate.NonAutoSizeHeight = 23;
			this.txtEndDate.Size = new System.Drawing.Size(144, 21);
			this.txtEndDate.TabIndex = 3;
			// 
			// btnOK
			// 
			this.btnOK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnOK.Location = new System.Drawing.Point(104, 216);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "确定";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnCancel.Location = new System.Drawing.Point(216, 216);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// JobEnd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(560, 453);
			this.Controls.Add(this.ultraGroupBox1);
			this.Name = "JobEnd";
			this.Text = "招聘会结束";
			this.Load += new System.EventHandler(this.JobEnd_Load);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
			this.ultraGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbShow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEndDate)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				Job job = new Job();
				job.cnnJobID = int.Parse(cmbShow.SelectedItem.DataValue.ToString());
				//job.cnvcJobCycleEnd = txtEndDate.Text;
				JobManage jobManage = new JobManage();
				jobManage.EndJob(job);
				MessageBox.Show(this,"招聘会结束成功！","招聘会结束",MessageBoxButtons.OK,MessageBoxIcon.Information);

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

		private void JobEnd_Load(object sender, System.EventArgs e)
		{
		
			try
			{
				JobManage jobManage = new JobManage();
				DataTable dtJob = jobManage.GetAllJob();
				cmbShow.DataSource = dtJob;
				cmbShow.ValueMember = "cnnID";
				cmbShow.DisplayMember = "cnvcJobName";
				cmbShow.DataBind();
				cmbShow.SelectedIndex = 0;
				

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
