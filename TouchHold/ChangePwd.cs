using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
//using MemberManage;
//using MemberManage.Business;
//using ynhrMemberManage.MemberManage.Common;
using ynhrMemberManage.ORM;
using Infragistics;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using ynhrMemberManage.Common;
using ynhrMemberManage.Domain;

namespace TouchHold
{
	/// <summary>
	/// ChangePwd 的摘要说明。
	/// </summary>
	public class ChangePwd : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraButton btnBackSpace;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Infragistics.Win.Misc.UltraButton btnNumber0;
		private Infragistics.Win.Misc.UltraButton btnNumber9;
		private Infragistics.Win.Misc.UltraButton btnNumber8;
		private Infragistics.Win.Misc.UltraButton btnNumber7;
		private Infragistics.Win.Misc.UltraButton btnNumber6;
		private Infragistics.Win.Misc.UltraButton btnNumber15;
		private Infragistics.Win.Misc.UltraButton btnNumber4;
		private Infragistics.Win.Misc.UltraButton btnNumber13;
		private Infragistics.Win.Misc.UltraButton btnNumber2;
		private Infragistics.Win.Misc.UltraButton btnNumber1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor textBox;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtConfirmPwd;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPwd;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtOldPwd;
		private Infragistics.Win.Misc.UltraButton btnOK;
		private Infragistics.Win.Misc.UltraButton btnReturn;

		private Infragistics.Win.Misc.UltraGroupBox boxLogin;
		private Infragistics.Win.Misc.UltraGroupBox boxOper;
		private Infragistics.Win.Misc.UltraGroupBox boxInfo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberPwd;
		private Infragistics.Win.Misc.UltraLabel lblError;
		private Infragistics.Win.Misc.UltraLabel lblChangePwdError;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ChangePwd(UltraGroupBox ultraGroupBox1,UltraGroupBox ultraGroupBox2,UltraGroupBox ultraGroupBox3,UltraTextEditor txtMemberCardNo,UltraTextEditor txtMemberPwd,UltraLabel lblError)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			this.boxLogin = ultraGroupBox2;
			this.boxOper = ultraGroupBox3;
			this.boxInfo = ultraGroupBox1;
			this.txtMemberCardNo = txtMemberCardNo;
			this.txtMemberPwd = txtMemberPwd;
			this.lblError = lblError;
            //ApplicationIdleTimer idle = new ApplicationIdleTimer();
            //System.Windows.Forms.Application.AddMessageFilter(idle);
            //idle.ApplicationIdle += new ApplicationIdleTimer.ApplicationIdleEventHandler(this.App_Idle);
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.btnOK = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnBackSpace = new Infragistics.Win.Misc.UltraButton();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.btnNumber0 = new Infragistics.Win.Misc.UltraButton();
            this.btnNumber9 = new Infragistics.Win.Misc.UltraButton();
            this.btnNumber8 = new Infragistics.Win.Misc.UltraButton();
            this.btnNumber7 = new Infragistics.Win.Misc.UltraButton();
            this.btnNumber6 = new Infragistics.Win.Misc.UltraButton();
            this.btnNumber15 = new Infragistics.Win.Misc.UltraButton();
            this.btnNumber4 = new Infragistics.Win.Misc.UltraButton();
            this.btnNumber13 = new Infragistics.Win.Misc.UltraButton();
            this.btnNumber2 = new Infragistics.Win.Misc.UltraButton();
            this.btnNumber1 = new Infragistics.Win.Misc.UltraButton();
            this.txtConfirmPwd = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.txtPwd = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.txtOldPwd = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.btnReturn = new Infragistics.Win.Misc.UltraButton();
            this.lblChangePwdError = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPwd)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(56, 232);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(176, 48);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ultraGroupBox1
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.Controls.Add(this.btnBackSpace);
            this.ultraGroupBox1.Controls.Add(this.btnCancel);
            this.ultraGroupBox1.Controls.Add(this.btnNumber0);
            this.ultraGroupBox1.Controls.Add(this.btnNumber9);
            this.ultraGroupBox1.Controls.Add(this.btnNumber8);
            this.ultraGroupBox1.Controls.Add(this.btnNumber7);
            this.ultraGroupBox1.Controls.Add(this.btnNumber6);
            this.ultraGroupBox1.Controls.Add(this.btnNumber15);
            this.ultraGroupBox1.Controls.Add(this.btnNumber4);
            this.ultraGroupBox1.Controls.Add(this.btnNumber13);
            this.ultraGroupBox1.Controls.Add(this.btnNumber2);
            this.ultraGroupBox1.Controls.Add(this.btnNumber1);
            this.ultraGroupBox1.Controls.Add(this.txtConfirmPwd);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox1.Controls.Add(this.txtPwd);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox1.Controls.Add(this.txtOldPwd);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox1.Controls.Add(this.btnReturn);
            this.ultraGroupBox1.Controls.Add(this.btnOK);
            this.ultraGroupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            appearance5.ForeColor = System.Drawing.Color.White;
            this.ultraGroupBox1.HeaderAppearance = appearance5;
            this.ultraGroupBox1.Location = new System.Drawing.Point(184, 48);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(488, 560);
            this.ultraGroupBox1.TabIndex = 11;
            this.ultraGroupBox1.Text = "修改密码";
            this.ultraGroupBox1.UseAppStyling = false;
            // 
            // btnBackSpace
            // 
            this.btnBackSpace.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBackSpace.Location = new System.Drawing.Point(288, 488);
            this.btnBackSpace.Name = "btnBackSpace";
            this.btnBackSpace.Size = new System.Drawing.Size(75, 48);
            this.btnBackSpace.TabIndex = 35;
            this.btnBackSpace.Text = "←";
            this.btnBackSpace.Click += new System.EventHandler(this.btnBackSpace_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(200, 488);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 48);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNumber0
            // 
            this.btnNumber0.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber0.Location = new System.Drawing.Point(112, 488);
            this.btnNumber0.Name = "btnNumber0";
            this.btnNumber0.Size = new System.Drawing.Size(75, 48);
            this.btnNumber0.TabIndex = 33;
            this.btnNumber0.Text = "0";
            this.btnNumber0.Click += new System.EventHandler(this.btnNumber0_Click);
            // 
            // btnNumber9
            // 
            this.btnNumber9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber9.Location = new System.Drawing.Point(288, 424);
            this.btnNumber9.Name = "btnNumber9";
            this.btnNumber9.Size = new System.Drawing.Size(75, 48);
            this.btnNumber9.TabIndex = 32;
            this.btnNumber9.Text = "9";
            this.btnNumber9.Click += new System.EventHandler(this.btnNumber9_Click);
            // 
            // btnNumber8
            // 
            this.btnNumber8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber8.Location = new System.Drawing.Point(200, 424);
            this.btnNumber8.Name = "btnNumber8";
            this.btnNumber8.Size = new System.Drawing.Size(75, 48);
            this.btnNumber8.TabIndex = 31;
            this.btnNumber8.Text = "8";
            this.btnNumber8.Click += new System.EventHandler(this.btnNumber8_Click);
            // 
            // btnNumber7
            // 
            this.btnNumber7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber7.Location = new System.Drawing.Point(112, 424);
            this.btnNumber7.Name = "btnNumber7";
            this.btnNumber7.Size = new System.Drawing.Size(75, 48);
            this.btnNumber7.TabIndex = 30;
            this.btnNumber7.Text = "7";
            this.btnNumber7.Click += new System.EventHandler(this.btnNumber7_Click);
            // 
            // btnNumber6
            // 
            this.btnNumber6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber6.Location = new System.Drawing.Point(288, 360);
            this.btnNumber6.Name = "btnNumber6";
            this.btnNumber6.Size = new System.Drawing.Size(75, 48);
            this.btnNumber6.TabIndex = 29;
            this.btnNumber6.Text = "6";
            this.btnNumber6.Click += new System.EventHandler(this.btnNumber6_Click);
            // 
            // btnNumber15
            // 
            this.btnNumber15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber15.Location = new System.Drawing.Point(200, 360);
            this.btnNumber15.Name = "btnNumber15";
            this.btnNumber15.Size = new System.Drawing.Size(75, 48);
            this.btnNumber15.TabIndex = 28;
            this.btnNumber15.Text = "5";
            this.btnNumber15.Click += new System.EventHandler(this.btnNumber15_Click);
            // 
            // btnNumber4
            // 
            this.btnNumber4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber4.Location = new System.Drawing.Point(112, 360);
            this.btnNumber4.Name = "btnNumber4";
            this.btnNumber4.Size = new System.Drawing.Size(75, 48);
            this.btnNumber4.TabIndex = 27;
            this.btnNumber4.Text = "4";
            this.btnNumber4.Click += new System.EventHandler(this.btnNumber4_Click);
            // 
            // btnNumber13
            // 
            this.btnNumber13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber13.Location = new System.Drawing.Point(288, 296);
            this.btnNumber13.Name = "btnNumber13";
            this.btnNumber13.Size = new System.Drawing.Size(75, 48);
            this.btnNumber13.TabIndex = 26;
            this.btnNumber13.Text = "3";
            this.btnNumber13.Click += new System.EventHandler(this.btnNumber13_Click);
            // 
            // btnNumber2
            // 
            this.btnNumber2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber2.Location = new System.Drawing.Point(200, 296);
            this.btnNumber2.Name = "btnNumber2";
            this.btnNumber2.Size = new System.Drawing.Size(75, 48);
            this.btnNumber2.TabIndex = 25;
            this.btnNumber2.Text = "2";
            this.btnNumber2.Click += new System.EventHandler(this.btnNumber2_Click);
            // 
            // btnNumber1
            // 
            this.btnNumber1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber1.Location = new System.Drawing.Point(112, 296);
            this.btnNumber1.Name = "btnNumber1";
            this.btnNumber1.Size = new System.Drawing.Size(75, 48);
            this.btnNumber1.TabIndex = 24;
            this.btnNumber1.Text = "1";
            this.btnNumber1.Click += new System.EventHandler(this.btnNumber1_Click);
            // 
            // txtConfirmPwd
            // 
            this.txtConfirmPwd.Location = new System.Drawing.Point(192, 176);
            this.txtConfirmPwd.Name = "txtConfirmPwd";
            this.txtConfirmPwd.PasswordChar = '*';
            this.txtConfirmPwd.Size = new System.Drawing.Size(224, 30);
            this.txtConfirmPwd.TabIndex = 17;
            this.txtConfirmPwd.Enter += new System.EventHandler(this.txtConfirmPwd_Enter);
            // 
            // ultraLabel3
            // 
            appearance2.ForeColor = System.Drawing.Color.White;
            this.ultraLabel3.Appearance = appearance2;
            this.ultraLabel3.Location = new System.Drawing.Point(32, 176);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(144, 23);
            this.ultraLabel3.TabIndex = 16;
            this.ultraLabel3.Text = "确认新密码：";
            this.ultraLabel3.UseAppStyling = false;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(192, 120);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(224, 30);
            this.txtPwd.TabIndex = 15;
            this.txtPwd.Enter += new System.EventHandler(this.txtPwd_Enter);
            // 
            // ultraLabel2
            // 
            appearance3.ForeColor = System.Drawing.Color.White;
            this.ultraLabel2.Appearance = appearance3;
            this.ultraLabel2.Location = new System.Drawing.Point(32, 120);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(144, 23);
            this.ultraLabel2.TabIndex = 14;
            this.ultraLabel2.Text = "输入新密码：";
            this.ultraLabel2.UseAppStyling = false;
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(192, 64);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.Size = new System.Drawing.Size(224, 30);
            this.txtOldPwd.TabIndex = 13;
            this.txtOldPwd.Enter += new System.EventHandler(this.txtOldPwd_Enter);
            // 
            // ultraLabel1
            // 
            appearance4.ForeColor = System.Drawing.Color.White;
            this.ultraLabel1.Appearance = appearance4;
            this.ultraLabel1.Location = new System.Drawing.Point(32, 64);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(144, 23);
            this.ultraLabel1.TabIndex = 12;
            this.ultraLabel1.Text = "输入旧密码：";
            this.ultraLabel1.UseAppStyling = false;
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.Location = new System.Drawing.Point(248, 232);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(176, 48);
            this.btnReturn.TabIndex = 11;
            this.btnReturn.Text = "返回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblChangePwdError
            // 
            this.lblChangePwdError.Location = new System.Drawing.Point(184, 624);
            this.lblChangePwdError.Name = "lblChangePwdError";
            this.lblChangePwdError.Size = new System.Drawing.Size(488, 72);
            this.lblChangePwdError.TabIndex = 12;
            // 
            // ChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.ClientSize = new System.Drawing.Size(896, 723);
            this.ControlBox = false;
            this.Controls.Add(this.lblChangePwdError);
            this.Controls.Add(this.ultraGroupBox1);
            this.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePwd";
            this.Text = "ChangePwd";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ChangePwd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPwd)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		private string currentKey;
		public string CurrentKey
		{
			set { currentKey = value; }
			get { return currentKey; }           
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
			currentKey = btn.Text;
			KeyOneClicked(this, e);
		}

		private void btnBackSpace_Click(object sender, System.EventArgs e)
		{
			Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
			currentKey = btn.Text;
			KeyOneClicked(this, e);
		}

		private void btnNumber1_Click(object sender, System.EventArgs e)
		{
			Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
			currentKey = btn.Text;
			KeyOneClicked(this, e);
		}

		private void btnNumber2_Click(object sender, System.EventArgs e)
		{
			Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
			currentKey = btn.Text;
			KeyOneClicked(this, e);
		}

		private void btnNumber13_Click(object sender, System.EventArgs e)
		{
			Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
			currentKey = btn.Text;
			KeyOneClicked(this, e);
		}

		private void btnNumber4_Click(object sender, System.EventArgs e)
		{
			Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
			currentKey = btn.Text;
			KeyOneClicked(this, e);
		}

		private void btnNumber15_Click(object sender, System.EventArgs e)
		{
			Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
			currentKey = btn.Text;
			KeyOneClicked(this, e);
		}

		private void btnNumber6_Click(object sender, System.EventArgs e)
		{
			Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
			currentKey = btn.Text;
			KeyOneClicked(this, e);
		}

		private void btnNumber7_Click(object sender, System.EventArgs e)
		{
			Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
			currentKey = btn.Text;
			KeyOneClicked(this, e);
		}

		private void btnNumber8_Click(object sender, System.EventArgs e)
		{
			Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
			currentKey = btn.Text;
			KeyOneClicked(this, e);
		}

		private void btnNumber9_Click(object sender, System.EventArgs e)
		{
			Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
			currentKey = btn.Text;
			KeyOneClicked(this, e);
		}

		private void btnNumber0_Click(object sender, System.EventArgs e)
		{
			Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
			currentKey = btn.Text;
			KeyOneClicked(this, e);
		}
		
		private void KeyOneClicked(object sender, System.EventArgs e)
		{
			if (null != textBox)
			{
			
				switch (this.CurrentKey.Trim())
				{
					case "1":
					case "2":
					case "3":
					case "4":
					case "5":
					case "6":
					case "7":
					case "8":
					case "9":
					case "0":						
						textBox.Text += this.CurrentKey.Trim();
						break;
					case "←":
						if (textBox.Text.Length -1 >= 0)
						{
							textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
						}
						break;
					case "取消":
						textBox.Text = string.Empty;
						break;

					default:
						break;
				}

				if (textBox.Name == "txtOldPwd")
				{
					txtOldPwd.Text = textBox.Text;
				}
				if (textBox.Name == "txtPwd")
				{
					txtPwd.Text = textBox.Text;
				}
				if (textBox.Name == "txtConfirmPwd")
				{
					txtConfirmPwd.Text = textBox.Text;
				}
			}
			
		}

		private void txtOldPwd_Enter(object sender, System.EventArgs e)
		{
			this.textBox = this.txtOldPwd;
		}

		private void txtPwd_Enter(object sender, System.EventArgs e)
		{
			this.textBox = this.txtPwd;
		}

		private void txtConfirmPwd_Enter(object sender, System.EventArgs e)
		{
			this.textBox = this.txtConfirmPwd;
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
        //private void App_Idle(ApplicationIdleTimer.ApplicationIdleEventArgs e)
        //{
        //    if (e.IdleDuration.TotalSeconds>10)
        //    {
        //        btnReturn_Click(null,null);
        //    }
			
        //}
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.txtOldPwd.Text.Trim().Length == 0)
				{
					throw new BusinessException("密码错误","请输入旧密码！");
				}
				if (this.txtPwd.Text.Trim().Length == 0)
				{
					throw new BusinessException("密码错误","请输入新密码！");
				}
				if (this.txtConfirmPwd.Text.Trim().Length == 0)
				{
					throw new BusinessException("密码错误","请确认新密码！");
				}
				if (!this.txtOldPwd.Text.Equals(Form1.pMember.cnvcMemberPwd))
				{
					throw new BusinessException("密码错误","输入的旧密码错误！");
				}
				if (!this.txtPwd.Text.Equals(this.txtConfirmPwd.Text))
				{
					throw new BusinessException("密码错误","确认新密码和输入的新密码不一致！请重新输入！");
				}
                if (txtPwd.Text.Length < 6) throw new BusinessException("发卡", "会员密码最少6位");
				Member member = Form1.pMember;
				member.cnvcMemberPwd = txtPwd.Text;
				member.cnvcOperName = member.cnvcMemberCardNo;
				member.cndOperDate = DateTime.Now;
				member.cniSynch = 2;
				//MemberManage.Business.MemberManage mm = new MemberManage.Business.MemberManage();
                ynhrMemberManage.BusinessFacade.MemberManageFacade mm = new ynhrMemberManage.BusinessFacade.MemberManageFacade();
				mm.ModifyMember(member);
				Form1.pMember = member;
				
				this.lblError.Text = "密码修改：密码修改成功！请重新登录！";
				//MessageBox.Show(this, "", "密码修改",MessageBoxButtons.OK,MessageBoxIcon.Information);

				Form1.pMember = null;
				this.boxInfo.Visible = true;
				this.boxLogin.Visible = true;
				this.boxOper.Visible = false;
				this.txtMemberCardNo.Text = "";
				this.txtMemberPwd.Text = "";
				this.Close();

				
				
			}
			catch (BusinessException bex)
			{
				this.lblChangePwdError.Visible = true;
				this.lblChangePwdError.Text = bex.Type+"："+bex.Message;
				//MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				this.lblChangePwdError.Visible = true;
				this.lblChangePwdError.Text = "信息提示："+ex.Message;
				//MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void ChangePwd_Load(object sender, System.EventArgs e)
		{
			//this.FormBorderStyle=FormBorderStyle.None;
			this.ultraGroupBox1.Left = (this.Width-this.ultraGroupBox1.Width)/2;
			this.lblChangePwdError.Left = this.ultraGroupBox1.Left;
			this.lblChangePwdError.Top = this.ultraGroupBox1.Top + this.ultraGroupBox1.Height + 10;
			this.lblChangePwdError.Visible = false;
			//this.ultraGroupBox1.Top = (this.ultraGroupBox1.Height-this.ultraGroupBox1.Height)/2;

		}
	}
}
