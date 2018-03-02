using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using System.Data;
using System.Data.SqlClient;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Common;

namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for ShowBookSetting.
	/// </summary>
    public class ShowBookSetting : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbShow;
		private Infragistics.Win.Misc.UltraButton btnLeave;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public static bool IsShowing ;

		public ShowBookSetting()
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
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.cmbShow = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.btnLeave = new Infragistics.Win.Misc.UltraButton();
			this.btnCancel = new Infragistics.Win.Misc.UltraButton();
			this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
			this.ultraGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbShow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// ultraGroupBox1
			// 
			this.ultraGroupBox1.Controls.Add(this.ultraGrid1);
			this.ultraGroupBox1.Controls.Add(this.btnCancel);
			this.ultraGroupBox1.Controls.Add(this.btnLeave);
			this.ultraGroupBox1.Controls.Add(this.cmbShow);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
			this.ultraGroupBox1.Location = new System.Drawing.Point(48, 32);
			this.ultraGroupBox1.Name = "ultraGroupBox1";
			this.ultraGroupBox1.Size = new System.Drawing.Size(552, 432);
			this.ultraGroupBox1.TabIndex = 0;
			this.ultraGroupBox1.Text = "展位预订设置";
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.Location = new System.Drawing.Point(72, 48);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.TabIndex = 0;
			this.ultraLabel1.Text = "招聘会：";
			// 
			// cmbShow
			// 
			this.cmbShow.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbShow.Location = new System.Drawing.Point(192, 48);
			this.cmbShow.Name = "cmbShow";
			this.cmbShow.TabIndex = 1;
			this.cmbShow.ValueChanged += new System.EventHandler(this.cmbShow_ValueChanged);
			// 
			// btnLeave
			// 
			this.btnLeave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnLeave.Location = new System.Drawing.Point(376, 224);
			this.btnLeave.Name = "btnLeave";
			this.btnLeave.Size = new System.Drawing.Size(75, 24);
			this.btnLeave.TabIndex = 3;
			this.btnLeave.Text = "预留展位";
			this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnCancel.Location = new System.Drawing.Point(376, 272);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 24);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "取消预留";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// ultraGrid1
			// 
			this.ultraGrid1.Location = new System.Drawing.Point(16, 104);
			this.ultraGrid1.Name = "ultraGrid1";
			this.ultraGrid1.Size = new System.Drawing.Size(328, 304);
			this.ultraGrid1.TabIndex = 5;
			this.ultraGrid1.Text = "展位列表";
			// 
			// ShowBookSetting
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(656, 493);
			this.Controls.Add(this.ultraGroupBox1);
			this.Name = "ShowBookSetting";
			this.Text = "展位预订设置";
			this.Load += new System.EventHandler(this.ShowBookSetting_Load);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
			this.ultraGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbShow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void ShowBookSetting_Load(object sender, System.EventArgs e)
		{
			JobManage jobManage = new JobManage();
			DataTable dtJob = jobManage.GetAllJob();
			cmbShow.DataSource = dtJob;
			cmbShow.ValueMember = "cnnID";
			cmbShow.DisplayMember = "cnvcJobName";
			cmbShow.DataBind();
			cmbShow.SelectedIndex = 0;

			BindSeat();
			
		}

		private void cmbShow_ValueChanged(object sender, System.EventArgs e)
		{
			BindSeat();
		
		}

		private void BindSeat()
		{
			Job job = new Job();
			job.cnnJobID = int.Parse(cmbShow.SelectedItem.DataValue.ToString());
			JobManage jobManage = new JobManage();
			DataTable dtSeat = jobManage.GetAllSeat(job);
			this.ultraGrid1.DataSource = dtSeat;
			this.ultraGrid1.DataBind();

		}

		private void btnLeave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.ultraGrid1.ActiveRow.Cells["状态"].Value.ToString().Length > 0)
				{
					throw new BusinessException("展位预订设置","此展位已在使用，无法预留！");
				}
				ShowSeat seat = new ShowSeat();
				seat.cnnJobID = int.Parse(cmbShow.SelectedItem.DataValue.ToString());
				seat.cnvcSeat = this.ultraGrid1.ActiveRow.Cells["展位"].Value.ToString();
				seat.cnvcState = "预留";
				JobManage jobManage = new JobManage();
				jobManage.AddLeaveSeat(seat);
				BindSeat();
				MessageBox.Show(this,"展位预留成功！","展位预订设置",MessageBoxButtons.OK,MessageBoxIcon.Information);

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
			try
			{
				if (this.ultraGrid1.ActiveRow.Cells["状态"].Value.ToString() != "预留")
				{
					throw new BusinessException("展位预订设置","此展位不在预留状态，无法取消预留！");
				}
				ShowSeat seat = new ShowSeat();
				seat.cnnJobID = int.Parse(cmbShow.SelectedItem.DataValue.ToString());
				seat.cnvcSeat = this.ultraGrid1.ActiveRow.Cells["展位"].Value.ToString();				
				JobManage jobManage = new JobManage();
				jobManage.CancelLeaveSeat(seat);
				BindSeat();
				MessageBox.Show(this,"展位预留成功！","展位预订设置",MessageBoxButtons.OK,MessageBoxIcon.Information);

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
