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
	/// Summary description for DeptManage.
	/// </summary>
    public class DeptManage : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDeptName;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbParentDept;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraButton btnAddDept;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraButton ultraButton2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Infragistics.Win.Misc.UltraLabel ultraLabel8;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.Misc.UltraLabel ultraLabel10;
		private Infragistics.Win.Misc.UltraButton ultraButton3;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDiscount;
		private Infragistics.Win.Misc.UltraLabel lblParentDept;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbParentDept2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDeptName2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDiscount3;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbParentDept3;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDeptName3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbManager;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbManager3;
		public static bool IsShowing ;

		public DeptManage()
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
			this.cmbManager = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
			this.btnAddDept = new Infragistics.Win.Misc.UltraButton();
			this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
			this.lblParentDept = new Infragistics.Win.Misc.UltraLabel();
			this.txtDiscount = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.cmbParentDept = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.txtDeptName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
			this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
			this.cmbParentDept2 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.txtDeptName2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
			this.cmbManager3 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.ultraButton3 = new Infragistics.Win.Misc.UltraButton();
			this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
			this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
			this.txtDiscount3 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.cmbParentDept3 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.txtDeptName3 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
			this.ultraGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbManager)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbParentDept)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDeptName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
			this.ultraGroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbParentDept2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDeptName2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
			this.ultraGroupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbManager3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDiscount3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbParentDept3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDeptName3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// ultraGroupBox1
			// 
			this.ultraGroupBox1.Controls.Add(this.cmbManager);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel9);
			this.ultraGroupBox1.Controls.Add(this.btnAddDept);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
			this.ultraGroupBox1.Controls.Add(this.lblParentDept);
			this.ultraGroupBox1.Controls.Add(this.txtDiscount);
			this.ultraGroupBox1.Controls.Add(this.cmbParentDept);
			this.ultraGroupBox1.Controls.Add(this.txtDeptName);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
			this.ultraGroupBox1.Location = new System.Drawing.Point(24, 8);
			this.ultraGroupBox1.Name = "ultraGroupBox1";
			this.ultraGroupBox1.Size = new System.Drawing.Size(280, 216);
			this.ultraGroupBox1.TabIndex = 0;
			this.ultraGroupBox1.Text = "添加部门";
			// 
			// cmbManager
			// 
			this.cmbManager.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbManager.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.cmbManager.Location = new System.Drawing.Point(144, 136);
			this.cmbManager.Name = "cmbManager";
			this.cmbManager.Size = new System.Drawing.Size(112, 21);
			this.cmbManager.TabIndex = 9;
			// 
			// ultraLabel9
			// 
			this.ultraLabel9.Location = new System.Drawing.Point(38, 136);
			this.ultraLabel9.Name = "ultraLabel9";
			this.ultraLabel9.TabIndex = 8;
			this.ultraLabel9.Text = "部门管理员：";
			// 
			// btnAddDept
			// 
			this.btnAddDept.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnAddDept.Location = new System.Drawing.Point(96, 176);
			this.btnAddDept.Name = "btnAddDept";
			this.btnAddDept.TabIndex = 6;
			this.btnAddDept.Text = "添加部门";
			this.btnAddDept.Click += new System.EventHandler(this.btnAddDept_Click);
			// 
			// ultraLabel3
			// 
			this.ultraLabel3.Location = new System.Drawing.Point(40, 104);
			this.ultraLabel3.Name = "ultraLabel3";
			this.ultraLabel3.TabIndex = 5;
			this.ultraLabel3.Text = "折扣：";
			// 
			// lblParentDept
			// 
			this.lblParentDept.Location = new System.Drawing.Point(40, 72);
			this.lblParentDept.Name = "lblParentDept";
			this.lblParentDept.TabIndex = 4;
			this.lblParentDept.Text = "上级部门名称：";
			// 
			// txtDiscount
			// 
			this.txtDiscount.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtDiscount.Location = new System.Drawing.Point(144, 104);
			this.txtDiscount.Name = "txtDiscount";
			this.txtDiscount.Size = new System.Drawing.Size(100, 21);
			this.txtDiscount.TabIndex = 3;
			// 
			// cmbParentDept
			// 
			this.cmbParentDept.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbParentDept.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.cmbParentDept.Location = new System.Drawing.Point(144, 72);
			this.cmbParentDept.Name = "cmbParentDept";
			this.cmbParentDept.Size = new System.Drawing.Size(112, 21);
			this.cmbParentDept.TabIndex = 2;
			// 
			// txtDeptName
			// 
			this.txtDeptName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtDeptName.Location = new System.Drawing.Point(144, 32);
			this.txtDeptName.Name = "txtDeptName";
			this.txtDeptName.Size = new System.Drawing.Size(100, 21);
			this.txtDeptName.TabIndex = 1;
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.Location = new System.Drawing.Point(40, 32);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.TabIndex = 0;
			this.ultraLabel1.Text = "部门名称：";
			// 
			// ultraGroupBox2
			// 
			this.ultraGroupBox2.Controls.Add(this.ultraButton1);
			this.ultraGroupBox2.Controls.Add(this.ultraLabel4);
			this.ultraGroupBox2.Controls.Add(this.cmbParentDept2);
			this.ultraGroupBox2.Controls.Add(this.txtDeptName2);
			this.ultraGroupBox2.Controls.Add(this.ultraLabel5);
			this.ultraGroupBox2.Location = new System.Drawing.Point(24, 232);
			this.ultraGroupBox2.Name = "ultraGroupBox2";
			this.ultraGroupBox2.Size = new System.Drawing.Size(280, 120);
			this.ultraGroupBox2.TabIndex = 1;
			this.ultraGroupBox2.Text = "查询部门";
			// 
			// ultraButton1
			// 
			this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.ultraButton1.Location = new System.Drawing.Point(88, 80);
			this.ultraButton1.Name = "ultraButton1";
			this.ultraButton1.TabIndex = 11;
			this.ultraButton1.Text = "查询部门";
			this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
			// 
			// ultraLabel4
			// 
			this.ultraLabel4.Location = new System.Drawing.Point(24, 56);
			this.ultraLabel4.Name = "ultraLabel4";
			this.ultraLabel4.TabIndex = 10;
			this.ultraLabel4.Text = "上级部门名称：";
			// 
			// cmbParentDept2
			// 
			this.cmbParentDept2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbParentDept2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.cmbParentDept2.Location = new System.Drawing.Point(136, 48);
			this.cmbParentDept2.Name = "cmbParentDept2";
			this.cmbParentDept2.Size = new System.Drawing.Size(112, 21);
			this.cmbParentDept2.TabIndex = 9;
			// 
			// txtDeptName2
			// 
			this.txtDeptName2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtDeptName2.Location = new System.Drawing.Point(136, 24);
			this.txtDeptName2.Name = "txtDeptName2";
			this.txtDeptName2.Size = new System.Drawing.Size(100, 21);
			this.txtDeptName2.TabIndex = 8;
			// 
			// ultraLabel5
			// 
			this.ultraLabel5.Location = new System.Drawing.Point(32, 24);
			this.ultraLabel5.Name = "ultraLabel5";
			this.ultraLabel5.TabIndex = 7;
			this.ultraLabel5.Text = "部门名称：";
			// 
			// ultraGroupBox3
			// 
			this.ultraGroupBox3.Controls.Add(this.cmbManager3);
			this.ultraGroupBox3.Controls.Add(this.ultraButton3);
			this.ultraGroupBox3.Controls.Add(this.ultraLabel10);
			this.ultraGroupBox3.Controls.Add(this.ultraButton2);
			this.ultraGroupBox3.Controls.Add(this.ultraLabel6);
			this.ultraGroupBox3.Controls.Add(this.ultraLabel7);
			this.ultraGroupBox3.Controls.Add(this.txtDiscount3);
			this.ultraGroupBox3.Controls.Add(this.cmbParentDept3);
			this.ultraGroupBox3.Controls.Add(this.txtDeptName3);
			this.ultraGroupBox3.Controls.Add(this.ultraLabel8);
			this.ultraGroupBox3.Location = new System.Drawing.Point(24, 360);
			this.ultraGroupBox3.Name = "ultraGroupBox3";
			this.ultraGroupBox3.Size = new System.Drawing.Size(280, 216);
			this.ultraGroupBox3.TabIndex = 2;
			this.ultraGroupBox3.Text = "修改部门";
			// 
			// cmbManager3
			// 
			this.cmbManager3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbManager3.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.cmbManager3.Location = new System.Drawing.Point(136, 144);
			this.cmbManager3.Name = "cmbManager3";
			this.cmbManager3.Size = new System.Drawing.Size(112, 21);
			this.cmbManager3.TabIndex = 17;
			// 
			// ultraButton3
			// 
			this.ultraButton3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.ultraButton3.Location = new System.Drawing.Point(136, 176);
			this.ultraButton3.Name = "ultraButton3";
			this.ultraButton3.TabIndex = 16;
			this.ultraButton3.Text = "删除部门";
			this.ultraButton3.Click += new System.EventHandler(this.ultraButton3_Click);
			// 
			// ultraLabel10
			// 
			this.ultraLabel10.Location = new System.Drawing.Point(32, 144);
			this.ultraLabel10.Name = "ultraLabel10";
			this.ultraLabel10.TabIndex = 15;
			this.ultraLabel10.Text = "部门管理员：";
			// 
			// ultraButton2
			// 
			this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.ultraButton2.Location = new System.Drawing.Point(32, 176);
			this.ultraButton2.Name = "ultraButton2";
			this.ultraButton2.TabIndex = 13;
			this.ultraButton2.Text = "修改部门";
			this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
			// 
			// ultraLabel6
			// 
			this.ultraLabel6.Location = new System.Drawing.Point(32, 113);
			this.ultraLabel6.Name = "ultraLabel6";
			this.ultraLabel6.TabIndex = 12;
			this.ultraLabel6.Text = "折扣：";
			// 
			// ultraLabel7
			// 
			this.ultraLabel7.Location = new System.Drawing.Point(32, 81);
			this.ultraLabel7.Name = "ultraLabel7";
			this.ultraLabel7.TabIndex = 11;
			this.ultraLabel7.Text = "上级部门名称：";
			// 
			// txtDiscount3
			// 
			this.txtDiscount3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtDiscount3.Location = new System.Drawing.Point(136, 113);
			this.txtDiscount3.Name = "txtDiscount3";
			this.txtDiscount3.Size = new System.Drawing.Size(100, 21);
			this.txtDiscount3.TabIndex = 10;
			// 
			// cmbParentDept3
			// 
			this.cmbParentDept3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbParentDept3.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.cmbParentDept3.Location = new System.Drawing.Point(136, 81);
			this.cmbParentDept3.Name = "cmbParentDept3";
			this.cmbParentDept3.Size = new System.Drawing.Size(112, 21);
			this.cmbParentDept3.TabIndex = 9;
			// 
			// txtDeptName3
			// 
			this.txtDeptName3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtDeptName3.Location = new System.Drawing.Point(136, 41);
			this.txtDeptName3.Name = "txtDeptName3";
			this.txtDeptName3.Size = new System.Drawing.Size(100, 21);
			this.txtDeptName3.TabIndex = 8;
			// 
			// ultraLabel8
			// 
			this.ultraLabel8.Location = new System.Drawing.Point(32, 41);
			this.ultraLabel8.Name = "ultraLabel8";
			this.ultraLabel8.TabIndex = 7;
			this.ultraLabel8.Text = "部门名称：";
			// 
			// ultraGrid1
			// 
			this.ultraGrid1.Location = new System.Drawing.Point(344, 24);
			this.ultraGrid1.Name = "ultraGrid1";
			this.ultraGrid1.Size = new System.Drawing.Size(520, 544);
			this.ultraGrid1.TabIndex = 3;
			this.ultraGrid1.Text = "部门列表";
			this.ultraGrid1.AfterRowActivate += new System.EventHandler(this.ultraGrid1_AfterRowActivate);
			// 
			// DeptManage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(888, 581);
			this.Controls.Add(this.ultraGrid1);
			this.Controls.Add(this.ultraGroupBox3);
			this.Controls.Add(this.ultraGroupBox2);
			this.Controls.Add(this.ultraGroupBox1);
			this.Name = "DeptManage";
			this.Text = "部门管理";
			this.Load += new System.EventHandler(this.DeptManage_Load);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
			this.ultraGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbManager)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbParentDept)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDeptName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
			this.ultraGroupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbParentDept2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDeptName2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
			this.ultraGroupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbManager3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDiscount3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbParentDept3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDeptName3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnAddDept_Click(object sender, System.EventArgs e)
		{
			try
			{
				Dept dept = new Dept();
				dept.cnvcDeptName = txtDeptName.Text;
				dept.cnvcManager = cmbManager.Text;
				dept.cnnDiscount = int.Parse(txtDiscount.Text);
				if (cmbParentDept.Items.Count > 0)
				{
					if (cmbParentDept.SelectedIndex >= 0)
					{
						dept.cnnParentDeptID = int.Parse(cmbParentDept.SelectedItem.DataValue.ToString());
					}
				}
					
				
				SecurityManage security = new SecurityManage();
				security.AddDept(dept);
				MessageBox.Show(this,"部门添加成功！","部门管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindParentDept();
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

		private void BindParentDept()
		{
			SecurityManage secruty = new SecurityManage();
			DataTable dtDept = secruty.getAllDept();

			cmbParentDept.DataSource = dtDept;
			cmbParentDept.ValueMember = "部门ID";
			cmbParentDept.DisplayMember = "部门名称";
			cmbParentDept.DataBind();

			cmbParentDept.SelectedIndex = 0;//cmbParentDept.FindString("云南人才市场");

			cmbParentDept2.DataSource = dtDept;
			cmbParentDept2.ValueMember = "部门ID";
			cmbParentDept2.DisplayMember = "部门名称";
			cmbParentDept2.DataBind();

			cmbParentDept2.SelectedIndex = 0;//cmbParentDept2.FindString("云南人才市场");

			cmbParentDept3.DataSource = dtDept;
			cmbParentDept3.ValueMember = "部门ID";
			cmbParentDept3.DisplayMember = "部门名称";
			cmbParentDept3.DataBind();

			cmbParentDept3.SelectedIndex = 0;//cmbParentDept3.FindString("云南人才市场");

			this.ultraGrid1.DataSource = dtDept;
			this.ultraGrid1.DataBind();

			BindOper();
		}
		private void BindOper()
		{
			try
			{
				SecurityManage secruty = new SecurityManage();
				DataTable dtOper = secruty.getAllOper();
				cmbManager.DataSource = dtOper;
				cmbManager.ValueMember = "操作员ID";
				cmbManager.DisplayMember = "操作员名称";
				cmbManager.DataBind();

				cmbManager3.DataSource = dtOper;
				cmbManager3.ValueMember = "操作员ID";
				cmbManager3.DisplayMember = "操作员名称";
				cmbManager3.DataBind();
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

		private void DeptManage_Load(object sender, System.EventArgs e)
		{
			BindParentDept();
		}

		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			try
			{
				Dept dept = new Dept();
				dept.cnvcDeptName = txtDeptName2.Text;
				if (cmbParentDept2.Items.Count > 0)
				{
					if (cmbParentDept2.SelectedIndex >= 0)
					{
						dept.cnnParentDeptID = int.Parse(cmbParentDept2.SelectedItem.DataValue.ToString());
					}
				}
				SecurityManage secruty = new SecurityManage();
				DataTable dtDept = secruty.getDept(dept);
				this.ultraGrid1.DataSource = dtDept;
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

		private void ultraButton2_Click(object sender, System.EventArgs e)
		{
			//修改
			try
			{
				Dept dept = new Dept();
				dept.cnnDeptID = int.Parse(txtDeptName3.Tag.ToString());
				dept.cnvcDeptName = txtDeptName3.Text;
				if (cmbParentDept3.Items.Count > 0)
				{
					if (cmbParentDept3.SelectedIndex >= 0)
					{
						dept.cnnParentDeptID = int.Parse(cmbParentDept3.SelectedItem.DataValue.ToString());
					}
				}
				dept.cnnDiscount = int.Parse(txtDiscount3.Text);
				dept.cnvcManager = cmbManager3.Text;
				SecurityManage secruty = new SecurityManage();
				secruty.ModifyDept(dept);
				MessageBox.Show(this,"部门修改成功！","部门管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindParentDept();
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
			string strDeptID = this.ultraGrid1.ActiveRow.Cells["部门ID"].Value.ToString();
			string strDeptName = this.ultraGrid1.ActiveRow.Cells["部门名称"].Value.ToString();
			string strParentDeptID = this.ultraGrid1.ActiveRow.Cells["上级部门ID"].Value.ToString();
			string strDiscount = this.ultraGrid1.ActiveRow.Cells["部门折扣上限"].Value.ToString();
			string strManager = this.ultraGrid1.ActiveRow.Cells["部门管理员"].Value.ToString();

			txtDeptName3.Tag = strDeptID;
			txtDeptName3.Text = strDeptName;
			cmbParentDept3.SelectedIndex = cmbParentDept3.FindString(strDeptName);
			txtDiscount3.Text = strDiscount;
			cmbManager3.SelectedIndex = cmbManager3.FindString(strManager);
															
		}

		private void ultraButton3_Click(object sender, System.EventArgs e)
		{
			//删除部门
			try
			{
				Dept dept = new Dept();
				dept.cnnDeptID = int.Parse(txtDeptName3.Tag.ToString());
				dept.cnvcDeptName = txtDeptName3.Text;
				if (cmbParentDept3.Items.Count > 0)
				{
					if (cmbParentDept3.SelectedIndex >= 0)
					{
						dept.cnnParentDeptID = int.Parse(cmbParentDept3.SelectedItem.DataValue.ToString());
					}
				}
				dept.cnnDiscount = int.Parse(txtDiscount3.Text);
				dept.cnvcManager = cmbManager3.Text;
				SecurityManage secruty = new SecurityManage();
				secruty.DeleteDept(dept);
				MessageBox.Show(this,"部门删除成功！","部门管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindParentDept();
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
