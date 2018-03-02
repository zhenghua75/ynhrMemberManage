using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using System.Text.RegularExpressions;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Common;
namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for MemberCardAddCardNewCard.
	/// </summary>
    public class MemberCardAddCardNewCard : frmBase
	{
		private Infragistics.Win.Misc.UltraButton btnAddCard;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtNewMemberCardNo;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		public Member member;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MemberCardAddCardNewCard()
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
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnAddCard = new Infragistics.Win.Misc.UltraButton();
			this.txtNewMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
			this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			((System.ComponentModel.ISupportInitialize)(this.txtNewMemberCardNo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
			this.ultraGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnAddCard
			// 
			this.btnAddCard.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnAddCard.Location = new System.Drawing.Point(56, 88);
			this.btnAddCard.Name = "btnAddCard";
			this.btnAddCard.Size = new System.Drawing.Size(72, 23);
			this.btnAddCard.TabIndex = 11;
			this.btnAddCard.Text = "确定";
			this.btnAddCard.Click += new System.EventHandler(this.btnAddCard_Click);
			// 
			// txtNewMemberCardNo
			// 
			this.txtNewMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtNewMemberCardNo.Location = new System.Drawing.Point(152, 40);
			this.txtNewMemberCardNo.MaxLength = 8;
			this.txtNewMemberCardNo.Name = "txtNewMemberCardNo";
			this.txtNewMemberCardNo.Size = new System.Drawing.Size(100, 21);
			this.txtNewMemberCardNo.TabIndex = 10;
			this.txtNewMemberCardNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewMemberCardNo_KeyPress);
			this.txtNewMemberCardNo.Validated += new System.EventHandler(this.txtNewMemberCardNo_Validated);
			// 
			// ultraLabel4
			// 
			this.ultraLabel4.Location = new System.Drawing.Point(40, 40);
			this.ultraLabel4.Name = "ultraLabel4";
			this.ultraLabel4.TabIndex = 9;
			this.ultraLabel4.Text = "新会员卡号：";
			// 
			// ultraButton1
			// 
			this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.ultraButton1.Location = new System.Drawing.Point(152, 88);
			this.ultraButton1.Name = "ultraButton1";
			this.ultraButton1.Size = new System.Drawing.Size(72, 23);
			this.ultraButton1.TabIndex = 12;
			this.ultraButton1.Text = "取消";
			this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
			// 
			// ultraGroupBox1
			// 
			this.ultraGroupBox1.Controls.Add(this.ultraLabel4);
			this.ultraGroupBox1.Controls.Add(this.btnAddCard);
			this.ultraGroupBox1.Controls.Add(this.txtNewMemberCardNo);
			this.ultraGroupBox1.Controls.Add(this.ultraButton1);
			this.ultraGroupBox1.Location = new System.Drawing.Point(48, 48);
			this.ultraGroupBox1.Name = "ultraGroupBox1";
			this.ultraGroupBox1.Size = new System.Drawing.Size(320, 160);
			this.ultraGroupBox1.TabIndex = 13;
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// MemberCardAddCardNewCard
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(416, 237);
			this.Controls.Add(this.ultraGroupBox1);
			this.Name = "MemberCardAddCardNewCard";
			this.Text = "补卡操作";
			((System.ComponentModel.ISupportInitialize)(this.txtNewMemberCardNo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
			this.ultraGroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void txtNewMemberCardNo_Validated(object sender, System.EventArgs e)
		{
			if (txtNewMemberCardNo.Text.Trim().Length != 8 )
			{
				this.errorProvider1.SetError(txtNewMemberCardNo,"卡号必须是8位！");
			}
			else
			{
				//this.errorProvider1.SetError(txtMemberCardNo,"");	
				string strMemberCardNo = txtNewMemberCardNo.Text.Trim();
				Regex re = new Regex(@"[0-9]");
				if (!re.IsMatch(strMemberCardNo))
				{
					this.errorProvider1.SetError(txtNewMemberCardNo,"卡号必须是数字！");
				}
				else
				{
					if (strMemberCardNo.Equals("00000"))
					{
						this.errorProvider1.SetError(txtNewMemberCardNo,"卡号不能都为零");
					}
					else
					{
						//判断卡号是否存在
						Member member = new Member();
						member.cnvcMemberCardNo = strMemberCardNo;
						MemberManageFacade memberManage = new MemberManageFacade();
						Member oldMember = memberManage.GetMemberbyCardNo(member);
						if (oldMember.cnvcMemberCardNo.Length > 0)
						{
							this.errorProvider1.SetError(txtNewMemberCardNo,"卡号已存在");
						}
						else
						{
							this.errorProvider1.SetError(txtNewMemberCardNo,"");
						}
						
					}
					
				}			
			}
		}

		private void btnAddCard_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.txtNewMemberCardNo_Validated(null,null);
				string strCardNoError = this.errorProvider1.GetError(txtNewMemberCardNo);
				if (strCardNoError.Length > 0)
				{
					throw new BusinessException("补卡",strCardNoError);
				}
				MemberManageFacade memberManage = new MemberManageFacade();
				member.cnvcMemberCardNo = txtNewMemberCardNo.Text;
								
				//memberManage.AddCard(member);
				MessageBox.Show(this,"补卡成功！","补卡操作",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.Close();
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
			this.Dispose();
		}

		private void txtNewMemberCardNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==8)
			{
				return;
			}
			if(e.KeyChar<48||e.KeyChar>57)
			{
				e.Handled=true;
			}
		}
	}
}
