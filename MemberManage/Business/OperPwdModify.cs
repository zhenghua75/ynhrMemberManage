using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using ynhrMemberManage.Common;
using ynhrMemberManage.Business;
using System.Web.Security;
namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for OperPwdModify.
	/// </summary>
	public class OperPwdModify : frmBase
	{
		private Infragistics.Win.Misc.UltraButton btnOK;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtOperName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPwd;
		public static bool IsShowing ;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPwdConfirm;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OperPwdModify()
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
			this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
			this.txtPwdConfirm = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.txtPwd = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.txtOperName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
			this.ultraGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtPwdConfirm)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPwd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOperName)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnOK.Location = new System.Drawing.Point(48, 168);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "确定";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnCancel.Location = new System.Drawing.Point(168, 168);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// ultraGroupBox1
			// 
			this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
			this.ultraGroupBox1.Controls.Add(this.txtPwdConfirm);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
			this.ultraGroupBox1.Controls.Add(this.txtPwd);
			this.ultraGroupBox1.Controls.Add(this.txtOperName);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
			this.ultraGroupBox1.Controls.Add(this.btnOK);
			this.ultraGroupBox1.Controls.Add(this.btnCancel);
			this.ultraGroupBox1.Location = new System.Drawing.Point(256, 104);
			this.ultraGroupBox1.Name = "ultraGroupBox1";
			this.ultraGroupBox1.Size = new System.Drawing.Size(296, 224);
			this.ultraGroupBox1.TabIndex = 2;
			this.ultraGroupBox1.Text = "操作员密码重置";
			// 
			// ultraLabel3
			// 
			this.ultraLabel3.Location = new System.Drawing.Point(24, 128);
			this.ultraLabel3.Name = "ultraLabel3";
			this.ultraLabel3.Size = new System.Drawing.Size(112, 23);
			this.ultraLabel3.TabIndex = 6;
			this.ultraLabel3.Text = "操作员密码确认：";
			// 
			// txtPwdConfirm
			// 
			this.txtPwdConfirm.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtPwdConfirm.Location = new System.Drawing.Point(152, 128);
			this.txtPwdConfirm.Name = "txtPwdConfirm";
			this.txtPwdConfirm.PasswordChar = '*';
			this.txtPwdConfirm.Size = new System.Drawing.Size(100, 21);
			this.txtPwdConfirm.TabIndex = 3;
			// 
			// ultraLabel2
			// 
			this.ultraLabel2.Location = new System.Drawing.Point(24, 88);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.TabIndex = 3;
			this.ultraLabel2.Text = "操作员密码：";
			// 
			// txtPwd
			// 
			this.txtPwd.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtPwd.Location = new System.Drawing.Point(152, 88);
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.PasswordChar = '*';
			this.txtPwd.Size = new System.Drawing.Size(100, 21);
			this.txtPwd.TabIndex = 2;
			// 
			// txtOperName
			// 
			this.txtOperName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtOperName.Location = new System.Drawing.Point(152, 40);
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
			// OperPwdModify
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(880, 549);
			this.Controls.Add(this.ultraGroupBox1);
			this.Name = "OperPwdModify";
			this.Text = "操作员密码修改";
			this.Load += new System.EventHandler(this.OperPwdModify_Load);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
			this.ultraGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtPwdConfirm)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPwd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOperName)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void OperPwdModify_Load(object sender, System.EventArgs e)
		{
			txtOperName.Text = this.oper.cnvcOperName;
			if (this.dept.cnnDeptID != 0)
			{				
				txtOperName.Enabled = false;
			}
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (txtOperName.Text.Trim().Length == 0)
				{
					throw new BusinessException("操作员密码重置","操作员名称不能为空");
				}
				if (txtPwd.Text.Trim().Length == 0)
				{
					throw new BusinessException("操作员密码重置","操作员密码不能为空");
				}
				if (txtPwdConfirm.Text.Trim().Length == 0)
				{
					throw new BusinessException("操作员密码重置","密码确认不能为空");
				}
				if (txtPwd.Text != txtPwdConfirm.Text)
				{
					throw new BusinessException("操作员密码重置","密码和密码确认不同");
				}
                //Oper oper = new Oper();
                //oper.cnvcOperName = txtOperName.Text;
                //oper.cnvcPwd = DataSecurity.Encrypt(txtPwd.Text);
                //SecurityManage securityManage = new SecurityManage();
				//securityManage.ModifyPwd(oper);

                Membership.Provider.ChangePassword(txtOperName.Text, "123456", txtPwd.Text);
				MessageBox.Show(this,"操作员密码修改成功！","操作员密码修改",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtPwd.Text = "";
                txtPwdConfirm.Text = "";
				txtPwd.Focus();

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
	}
}
