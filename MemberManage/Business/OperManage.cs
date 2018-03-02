using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.Domain;
using System.Data;
using System.Data.SqlClient;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Common;
using ynhrMemberManage.Business;
namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for OperManage.
	/// </summary>
    public class OperManage : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtOperName;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDept;
		private Infragistics.Win.Misc.UltraButton btnAddOper;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraButton ultraButton2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.Misc.UltraButton ultraButton3;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPwd;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtOperName2;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDept2;
		private Infragistics.Win.Misc.UltraButton btnQueryOper;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDept3;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtOperName3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public static bool IsShowing ;

		public OperManage()
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
			this.btnAddOper = new Infragistics.Win.Misc.UltraButton();
			this.cmbDept = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
			this.txtPwd = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.txtOperName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
			this.btnQueryOper = new Infragistics.Win.Misc.UltraButton();
			this.cmbDept2 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
			this.txtOperName2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraButton3 = new Infragistics.Win.Misc.UltraButton();
			this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
			this.cmbDept3 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
			this.txtOperName3 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
			this.ultraGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbDept)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPwd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOperName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
			this.ultraGroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbDept2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOperName2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
			this.ultraGroupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbDept3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOperName3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// ultraGroupBox1
			// 
			this.ultraGroupBox1.Controls.Add(this.btnAddOper);
			this.ultraGroupBox1.Controls.Add(this.cmbDept);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
			this.ultraGroupBox1.Controls.Add(this.txtPwd);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
			this.ultraGroupBox1.Controls.Add(this.txtOperName);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
			this.ultraGroupBox1.Location = new System.Drawing.Point(16, 0);
			this.ultraGroupBox1.Name = "ultraGroupBox1";
			this.ultraGroupBox1.Size = new System.Drawing.Size(256, 208);
			this.ultraGroupBox1.TabIndex = 0;
			this.ultraGroupBox1.Text = "添加操作员";
			// 
			// btnAddOper
			// 
			this.btnAddOper.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnAddOper.Location = new System.Drawing.Point(80, 176);
			this.btnAddOper.Name = "btnAddOper";
			this.btnAddOper.Size = new System.Drawing.Size(80, 23);
			this.btnAddOper.TabIndex = 6;
			this.btnAddOper.Text = "添加操作员";
			this.btnAddOper.Click += new System.EventHandler(this.btnAddOper_Click);
			// 
			// cmbDept
			// 
			this.cmbDept.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbDept.Location = new System.Drawing.Point(144, 136);
			this.cmbDept.Name = "cmbDept";
			this.cmbDept.Size = new System.Drawing.Size(104, 21);
			this.cmbDept.TabIndex = 5;
			// 
			// ultraLabel3
			// 
			this.ultraLabel3.Location = new System.Drawing.Point(24, 136);
			this.ultraLabel3.Name = "ultraLabel3";
			this.ultraLabel3.TabIndex = 4;
			this.ultraLabel3.Text = "部门：";
			// 
			// txtPwd
			// 
			this.txtPwd.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtPwd.Location = new System.Drawing.Point(144, 80);
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.PasswordChar = '*';
			this.txtPwd.Size = new System.Drawing.Size(100, 21);
			this.txtPwd.TabIndex = 3;
			// 
			// ultraLabel2
			// 
			this.ultraLabel2.Location = new System.Drawing.Point(24, 80);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.TabIndex = 2;
			this.ultraLabel2.Text = "操作员密码：";
			// 
			// txtOperName
			// 
			this.txtOperName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtOperName.Location = new System.Drawing.Point(144, 40);
			this.txtOperName.Name = "txtOperName";
			this.txtOperName.Size = new System.Drawing.Size(100, 21);
			this.txtOperName.TabIndex = 1;
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.Location = new System.Drawing.Point(24, 40);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.TabIndex = 0;
			this.ultraLabel1.Text = "操作员名称：";
			// 
			// ultraGroupBox2
			// 
			this.ultraGroupBox2.Controls.Add(this.btnQueryOper);
			this.ultraGroupBox2.Controls.Add(this.cmbDept2);
			this.ultraGroupBox2.Controls.Add(this.ultraLabel5);
			this.ultraGroupBox2.Controls.Add(this.txtOperName2);
			this.ultraGroupBox2.Controls.Add(this.ultraLabel4);
			this.ultraGroupBox2.Location = new System.Drawing.Point(16, 208);
			this.ultraGroupBox2.Name = "ultraGroupBox2";
			this.ultraGroupBox2.Size = new System.Drawing.Size(264, 160);
			this.ultraGroupBox2.TabIndex = 1;
			this.ultraGroupBox2.Text = "查询操作员";
			// 
			// btnQueryOper
			// 
			this.btnQueryOper.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnQueryOper.Location = new System.Drawing.Point(88, 120);
			this.btnQueryOper.Name = "btnQueryOper";
			this.btnQueryOper.Size = new System.Drawing.Size(80, 23);
			this.btnQueryOper.TabIndex = 8;
			this.btnQueryOper.Text = "查询操作员";
			this.btnQueryOper.Click += new System.EventHandler(this.btnQueryOper_Click);
			// 
			// cmbDept2
			// 
			this.cmbDept2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbDept2.Location = new System.Drawing.Point(140, 80);
			this.cmbDept2.Name = "cmbDept2";
			this.cmbDept2.Size = new System.Drawing.Size(104, 21);
			this.cmbDept2.TabIndex = 7;
			// 
			// ultraLabel5
			// 
			this.ultraLabel5.Location = new System.Drawing.Point(20, 80);
			this.ultraLabel5.Name = "ultraLabel5";
			this.ultraLabel5.TabIndex = 6;
			this.ultraLabel5.Text = "部门：";
			// 
			// txtOperName2
			// 
			this.txtOperName2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtOperName2.Location = new System.Drawing.Point(142, 37);
			this.txtOperName2.Name = "txtOperName2";
			this.txtOperName2.Size = new System.Drawing.Size(100, 21);
			this.txtOperName2.TabIndex = 3;
			// 
			// ultraLabel4
			// 
			this.ultraLabel4.Location = new System.Drawing.Point(22, 37);
			this.ultraLabel4.Name = "ultraLabel4";
			this.ultraLabel4.TabIndex = 2;
			this.ultraLabel4.Text = "操作员名称：";
			// 
			// ultraGroupBox3
			// 
			this.ultraGroupBox3.Controls.Add(this.ultraButton3);
			this.ultraGroupBox3.Controls.Add(this.ultraButton2);
			this.ultraGroupBox3.Controls.Add(this.cmbDept3);
			this.ultraGroupBox3.Controls.Add(this.ultraLabel6);
			this.ultraGroupBox3.Controls.Add(this.txtOperName3);
			this.ultraGroupBox3.Controls.Add(this.ultraLabel7);
			this.ultraGroupBox3.Location = new System.Drawing.Point(16, 376);
			this.ultraGroupBox3.Name = "ultraGroupBox3";
			this.ultraGroupBox3.Size = new System.Drawing.Size(264, 160);
			this.ultraGroupBox3.TabIndex = 2;
			this.ultraGroupBox3.Text = "修改操作员";
			// 
			// ultraButton3
			// 
			this.ultraButton3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.ultraButton3.Location = new System.Drawing.Point(136, 120);
			this.ultraButton3.Name = "ultraButton3";
			this.ultraButton3.Size = new System.Drawing.Size(80, 23);
			this.ultraButton3.TabIndex = 14;
			this.ultraButton3.Text = "删除操作员";
			this.ultraButton3.Click += new System.EventHandler(this.ultraButton3_Click);
			// 
			// ultraButton2
			// 
			this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.ultraButton2.Location = new System.Drawing.Point(32, 120);
			this.ultraButton2.Name = "ultraButton2";
			this.ultraButton2.Size = new System.Drawing.Size(80, 23);
			this.ultraButton2.TabIndex = 13;
			this.ultraButton2.Text = "修改操作员";
			this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
			// 
			// cmbDept3
			// 
			this.cmbDept3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbDept3.Location = new System.Drawing.Point(136, 78);
			this.cmbDept3.Name = "cmbDept3";
			this.cmbDept3.Size = new System.Drawing.Size(104, 21);
			this.cmbDept3.TabIndex = 12;
			// 
			// ultraLabel6
			// 
			this.ultraLabel6.Location = new System.Drawing.Point(24, 78);
			this.ultraLabel6.Name = "ultraLabel6";
			this.ultraLabel6.TabIndex = 11;
			this.ultraLabel6.Text = "部门：";
			// 
			// txtOperName3
			// 
			this.txtOperName3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtOperName3.Location = new System.Drawing.Point(144, 35);
			this.txtOperName3.Name = "txtOperName3";
			this.txtOperName3.Size = new System.Drawing.Size(100, 21);
			this.txtOperName3.TabIndex = 10;
			// 
			// ultraLabel7
			// 
			this.ultraLabel7.Location = new System.Drawing.Point(24, 35);
			this.ultraLabel7.Name = "ultraLabel7";
			this.ultraLabel7.TabIndex = 9;
			this.ultraLabel7.Text = "操作员名称：";
			// 
			// ultraGrid1
			// 
			this.ultraGrid1.Location = new System.Drawing.Point(320, 16);
			this.ultraGrid1.Name = "ultraGrid1";
			this.ultraGrid1.Size = new System.Drawing.Size(360, 520);
			this.ultraGrid1.TabIndex = 3;
			this.ultraGrid1.Text = "操作员列表";
			this.ultraGrid1.AfterRowActivate += new System.EventHandler(this.ultraGrid1_AfterRowActivate);
			// 
			// OperManage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(904, 549);
			this.Controls.Add(this.ultraGrid1);
			this.Controls.Add(this.ultraGroupBox3);
			this.Controls.Add(this.ultraGroupBox2);
			this.Controls.Add(this.ultraGroupBox1);
			this.Name = "OperManage";
			this.Text = "操作员管理";
			this.Load += new System.EventHandler(this.OperManage_Load);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
			this.ultraGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbDept)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPwd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOperName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
			this.ultraGroupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbDept2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOperName2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
			this.ultraGroupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbDept3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOperName3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnAddOper_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (txtOperName.Text == "admin")
				{
					throw new BusinessException("操作员管理","操作员添加错误！");
				}
				Oper opers = new Oper();
				opers.cnvcOperName = txtOperName.Text;
				opers.cnvcPwd = DataSecurity.Encrypt(txtPwd.Text);
				opers.cnnDeptID = int.Parse(cmbDept.SelectedItem.DataValue.ToString());
				SecurityManage security = new SecurityManage();
				security.AddOper(opers);
				MessageBox.Show(this,"操作员添加成功！","操作员管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindDept();
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

		private void BindOper()
		{
			try
			{
				SecurityManage secruty = new SecurityManage();
				DataTable dtOpers = secruty.getAllOper();
				this.ultraGrid1.DataSource = dtOpers;
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

		private void BindDept()
		{
			SecurityManage secruty = new SecurityManage();
			DataTable dtDept = secruty.getAllDept();
			

			cmbDept.DataSource = dtDept;
			cmbDept.ValueMember = "部门ID";
			cmbDept.DisplayMember = "部门名称";
			cmbDept.DataBind();
			cmbDept.SelectedIndex = 0;

			cmbDept2.DataSource = dtDept;
			cmbDept2.ValueMember = "部门ID";
			cmbDept2.DisplayMember = "部门名称";
			cmbDept2.DataBind();
			cmbDept2.SelectedIndex = 0;

			cmbDept3.DataSource = dtDept;
			cmbDept3.ValueMember = "部门ID";
			cmbDept3.DisplayMember = "部门名称";
			cmbDept3.DataBind();
			cmbDept3.SelectedIndex = 0;

			BindOper();
			
		}

		private void ultraButton2_Click(object sender, System.EventArgs e)
		{
			//修改

			try
			{
				Oper opers = new Oper();
				opers.cnnOperID = int.Parse(txtOperName3.Tag.ToString());
				opers.cnvcOperName = txtOperName.Text;
				if (cmbDept3.Items.Count > 0)
				{
					if (cmbDept3.SelectedIndex >= 0)
					{
						opers.cnnDeptID = int.Parse(cmbDept3.SelectedItem.DataValue.ToString());
					}
				}
				SecurityManage secruty = new SecurityManage();
				secruty.ModifyOper(opers);
				MessageBox.Show(this,"操作员修改成功！","操作员管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindDept();
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

		private void ultraButton3_Click(object sender, System.EventArgs e)
		{
			//删除
			try
			{
				Oper opers = new Oper();
				opers.cnnOperID = int.Parse(txtOperName3.Tag.ToString());
				opers.cnvcOperName = txtOperName.Text;
				if (cmbDept3.Items.Count > 0)
				{
					if (cmbDept3.SelectedIndex >= 0)
					{
						opers.cnnDeptID = int.Parse(cmbDept3.SelectedItem.DataValue.ToString());
					}
				}
				SecurityManage secruty = new SecurityManage();
				secruty.DeleteOper(opers);
				MessageBox.Show(this,"操作员修改成功！","操作员管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindDept();
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

		private void OperManage_Load(object sender, System.EventArgs e)
		{
			BindDept();
		}

		private void btnQueryOper_Click(object sender, System.EventArgs e)
		{
			//查询
			try
			{
				Oper opers = new Oper();
				opers.cnvcOperName = txtOperName2.Text;
				opers.cnvcPwd = cmbDept2.Text;
				SecurityManage secruty = new SecurityManage();
				DataTable dtOpers = secruty.getOper(opers);
				this.ultraGrid1.DataSource = dtOpers;
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

		private void ultraGrid1_AfterRowActivate(object sender, System.EventArgs e)
		{
			string strOperID = this.ultraGrid1.ActiveRow.Cells["操作员ID"].Value.ToString();
			string strOperName = this.ultraGrid1.ActiveRow.Cells["操作员名称"].Value.ToString();
			string strDeptName = this.ultraGrid1.ActiveRow.Cells["部门名称"].Value.ToString();

			txtOperName3.Tag = strOperID;
			txtOperName3.Text = strOperName;
			cmbDept3.SelectedIndex = cmbDept3.FindString(strDeptName);

		}
	}
}
