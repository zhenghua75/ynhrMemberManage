using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.Domain;
using ynhrMemberManage.ORM;
using System.Data;
using System.Data.SqlClient;
using Infragistics;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ynhrMemberManage.Common;
using ynhrMemberManage.BusinessFacade.MemberBusiness;

namespace MemberManage.MemberBusiness
{
	/// <summary>
	/// Summary description for JobQuery.
	/// </summary>
    public class JobQuery : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtJobName;
		private Infragistics.Win.Misc.UltraButton btnOK;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		public static bool IsShowing ;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkIs;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEndDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBeginDate;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBeginDate2;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBeginDate2;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEndDate2;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate2;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBeginDate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public JobQuery()
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
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmbBeginDate2 = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.chkBeginDate2 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cmbEndDate2 = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.chkEndDate2 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmbBeginDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.chkBeginDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cmbEndDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.chkEndDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkIs = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.btnOK = new Infragistics.Win.Misc.UltraButton();
            this.txtJobName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.ultraGroupBox3);
            this.ultraGroupBox1.Controls.Add(this.ultraGroupBox2);
            this.ultraGroupBox1.Controls.Add(this.chkIs);
            this.ultraGroupBox1.Controls.Add(this.ultraButton1);
            this.ultraGroupBox1.Controls.Add(this.btnOK);
            this.ultraGroupBox1.Controls.Add(this.txtJobName);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(128, 40);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(744, 176);
            this.ultraGroupBox1.TabIndex = 0;
            // 
            // ultraGroupBox3
            // 
            this.ultraGroupBox3.Controls.Add(this.cmbBeginDate2);
            this.ultraGroupBox3.Controls.Add(this.chkBeginDate2);
            this.ultraGroupBox3.Controls.Add(this.cmbEndDate2);
            this.ultraGroupBox3.Controls.Add(this.chkEndDate2);
            this.ultraGroupBox3.Location = new System.Drawing.Point(328, 64);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(296, 96);
            this.ultraGroupBox3.TabIndex = 17;
            this.ultraGroupBox3.Text = "招聘会结束时间";
            // 
            // cmbBeginDate2
            // 
            this.cmbBeginDate2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbBeginDate2.Location = new System.Drawing.Point(136, 24);
            this.cmbBeginDate2.MaskInput = "{date} {time}";
            this.cmbBeginDate2.Name = "cmbBeginDate2";
            this.cmbBeginDate2.Size = new System.Drawing.Size(144, 21);
            this.cmbBeginDate2.TabIndex = 12;
            // 
            // chkBeginDate2
            // 
            this.chkBeginDate2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.chkBeginDate2.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkBeginDate2.Location = new System.Drawing.Point(16, 24);
            this.chkBeginDate2.Name = "chkBeginDate2";
            this.chkBeginDate2.Size = new System.Drawing.Size(120, 20);
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
            this.cmbEndDate2.Size = new System.Drawing.Size(144, 21);
            this.cmbEndDate2.TabIndex = 13;
            this.cmbEndDate2.Value = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
            // 
            // chkEndDate2
            // 
            this.chkEndDate2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.chkEndDate2.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkEndDate2.Location = new System.Drawing.Point(16, 56);
            this.chkEndDate2.Name = "chkEndDate2";
            this.chkEndDate2.Size = new System.Drawing.Size(120, 20);
            this.chkEndDate2.TabIndex = 15;
            this.chkEndDate2.Text = "结束时间";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.cmbBeginDate);
            this.ultraGroupBox2.Controls.Add(this.chkBeginDate);
            this.ultraGroupBox2.Controls.Add(this.cmbEndDate);
            this.ultraGroupBox2.Controls.Add(this.chkEndDate);
            this.ultraGroupBox2.Location = new System.Drawing.Point(24, 64);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(296, 96);
            this.ultraGroupBox2.TabIndex = 16;
            this.ultraGroupBox2.Text = "招聘会开始时间";
            // 
            // cmbBeginDate
            // 
            this.cmbBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbBeginDate.Location = new System.Drawing.Point(136, 24);
            this.cmbBeginDate.MaskInput = "{date} {time}";
            this.cmbBeginDate.Name = "cmbBeginDate";
            this.cmbBeginDate.Size = new System.Drawing.Size(144, 21);
            this.cmbBeginDate.TabIndex = 12;
            // 
            // chkBeginDate
            // 
            this.chkBeginDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.chkBeginDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkBeginDate.Location = new System.Drawing.Point(16, 24);
            this.chkBeginDate.Name = "chkBeginDate";
            this.chkBeginDate.Size = new System.Drawing.Size(120, 20);
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
            this.cmbEndDate.Size = new System.Drawing.Size(144, 21);
            this.cmbEndDate.TabIndex = 13;
            this.cmbEndDate.Value = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
            // 
            // chkEndDate
            // 
            this.chkEndDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.chkEndDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkEndDate.Location = new System.Drawing.Point(16, 56);
            this.chkEndDate.Name = "chkEndDate";
            this.chkEndDate.Size = new System.Drawing.Size(120, 20);
            this.chkEndDate.TabIndex = 15;
            this.chkEndDate.Text = "结束时间";
            // 
            // chkIs
            // 
            this.chkIs.Location = new System.Drawing.Point(392, 32);
            this.chkIs.Name = "chkIs";
            this.chkIs.Size = new System.Drawing.Size(120, 20);
            this.chkIs.TabIndex = 4;
            this.chkIs.Text = "是否失效";
            // 
            // ultraButton1
            // 
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton1.Location = new System.Drawing.Point(648, 104);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 3;
            this.ultraButton1.Text = "取消";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // btnOK
            // 
            this.btnOK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnOK.Location = new System.Drawing.Point(648, 64);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "查询";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtJobName
            // 
            this.txtJobName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtJobName.Location = new System.Drawing.Point(240, 32);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(136, 21);
            this.txtJobName.TabIndex = 1;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(136, 32);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 16);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "招聘会名称：";
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Location = new System.Drawing.Point(128, 231);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(744, 328);
            this.ultraGrid1.TabIndex = 1;
            this.ultraGrid1.Text = "招聘会信息";
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            // 
            // JobQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1183, 571);
            this.Controls.Add(this.ultraGrid1);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "JobQuery";
            this.Text = "招聘会信息查询";
            this.Load += new System.EventHandler(this.JobQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            this.ultraGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				//string strSql = "";

				//string strSql = "select * from tbJob where 1=1";
                string strSql = @"select job.*,product.cnnPrice,product.cnnDiscount from tbJob job left join
(
select a.cnvcMemberName,a.cnnPrice,b.cnnDiscount from 
(select cnvcMemberName,cnvcMemberValue as cnnPrice
 from tbMemberCode where cnvcMemberName in (
select cnvcValue from tbNameCode where cnvcType='服务产品'
) and cnvcMemberType='产品单价') a
left join 
(select cnvcMemberName,cnvcMemberValue as cnnDiscount
 from tbMemberCode where cnvcMemberName in (
select cnvcValue from tbNameCode where cnvcType='服务产品'
) and cnvcMemberType='产品折扣') b on a.cnvcMemberName=b.cnvcMemberName
) product on convert(varchar(100),job.cnvcJobTheme)=product.cnvcMemberName where 1=1";
				if (!chkIs.Checked)
				{
                    strSql += " and job.cndEndDate >= getdate()";
				}
				if (txtJobName.Text.Trim().Length > 0)
				{
                    strSql += " and job.cnvcJobName like '%" + txtJobName.Text + "%'";
				}
				if (chkBeginDate.Checked)
				{
                    strSql += " and job.cndBeginDate >='" + cmbBeginDate.Value.ToString() + "'";
				}
				if (chkEndDate.Checked)
				{
                    strSql += " and job.cndBeginDate <='" + cmbEndDate.Value.ToString() + "'";
				}
				if (chkBeginDate2.Checked)
				{
                    strSql += " and job.cndEndDate >='" + cmbBeginDate2.Value.ToString() + "'";
				}
				if (chkEndDate2.Checked)
				{
                    strSql += " and job.cndEndDate <='" + cmbEndDate2.Value.ToString() + "'";
				}
                strSql += " order by job.cndBeginDate";
				DataTable dtJob = Helper.Query(strSql);
				this.ultraGrid1.DataSource = null;
				this.ultraGrid1.DataSource = dtJob;
				this.ultraGrid1.DataBind();

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

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e);
			e.Layout.Bands[0].Columns["cnnJobID"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcOperName"].Hidden = true;
			e.Layout.Bands[0].Columns["cndOperDate"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcJobName"].Header.Caption = "招聘会名称";
			e.Layout.Bands[0].Columns["cnvcJobTheme"].Header.Caption = "所属服务产品";
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

			e.Layout.Bands[0].Columns["cndBeginDate"].Width = 100;
			e.Layout.Bands[0].Columns["cndEndDate"].Width = 100;
			e.Layout.Bands[0].Columns["cndBookBeginDate"].Width = 100;
			e.Layout.Bands[0].Columns["cndBookEndDate"].Width = 100;
            e.Layout.Bands[0].Columns["cnnPrice"].Width = 50;
            e.Layout.Bands[0].Columns["cnnDiscount"].Width = 50;
            e.Layout.Bands[0].Columns["cnnPrice"].Header.Caption = "单价";
            e.Layout.Bands[0].Columns["cnnDiscount"].Header.Caption = "折扣";
				//e.Layout.Bands(1).Columns("Amount").Format = """$""#,##0.00"
		}

		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void JobQuery_Load(object sender, System.EventArgs e)
		{
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
