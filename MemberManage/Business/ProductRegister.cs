using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Microsoft.Win32;
using System.Windows.Forms;
using cc;
using Sunmast.Hardware;

namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for ProductRegister.
	/// </summary>
	public class ProductRegister : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txts5;
		private System.Windows.Forms.TextBox txts4;
		private System.Windows.Forms.TextBox txts3;
		private System.Windows.Forms.TextBox txts2;
		private System.Windows.Forms.TextBox txts1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		public static bool IsShowing ;
		private Infragistics.Win.Misc.UltraButton ultraButton2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ProductRegister()
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
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txts5 = new System.Windows.Forms.TextBox();
			this.txts4 = new System.Windows.Forms.TextBox();
			this.txts3 = new System.Windows.Forms.TextBox();
			this.txts2 = new System.Windows.Forms.TextBox();
			this.txts1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
			this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
			this.SuspendLayout();
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(256, 128);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(16, 23);
			this.label6.TabIndex = 23;
			this.label6.Text = "—";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(192, 128);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(16, 23);
			this.label5.TabIndex = 22;
			this.label5.Text = "—";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(128, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(16, 23);
			this.label4.TabIndex = 21;
			this.label4.Text = "—";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(64, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 23);
			this.label3.TabIndex = 20;
			this.label3.Text = "—";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txts5
			// 
			this.txts5.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txts5.Location = new System.Drawing.Point(272, 128);
			this.txts5.MaxLength = 5;
			this.txts5.Name = "txts5";
			this.txts5.Size = new System.Drawing.Size(48, 22);
			this.txts5.TabIndex = 19;
			this.txts5.Text = "";
			// 
			// txts4
			// 
			this.txts4.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txts4.Location = new System.Drawing.Point(208, 128);
			this.txts4.MaxLength = 5;
			this.txts4.Name = "txts4";
			this.txts4.Size = new System.Drawing.Size(48, 22);
			this.txts4.TabIndex = 18;
			this.txts4.Text = "";
			// 
			// txts3
			// 
			this.txts3.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txts3.Location = new System.Drawing.Point(144, 128);
			this.txts3.MaxLength = 5;
			this.txts3.Name = "txts3";
			this.txts3.Size = new System.Drawing.Size(48, 22);
			this.txts3.TabIndex = 17;
			this.txts3.Text = "";
			// 
			// txts2
			// 
			this.txts2.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txts2.Location = new System.Drawing.Point(80, 128);
			this.txts2.MaxLength = 5;
			this.txts2.Name = "txts2";
			this.txts2.Size = new System.Drawing.Size(48, 22);
			this.txts2.TabIndex = 15;
			this.txts2.Text = "";
			// 
			// txts1
			// 
			this.txts1.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txts1.Location = new System.Drawing.Point(16, 128);
			this.txts1.MaxLength = 5;
			this.txts1.Name = "txts1";
			this.txts1.Size = new System.Drawing.Size(48, 22);
			this.txts1.TabIndex = 13;
			this.txts1.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(184, 23);
			this.label2.TabIndex = 16;
			this.label2.Text = "请输入注册序列号：";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(360, 80);
			this.label1.TabIndex = 14;
			// 
			// ultraButton1
			// 
			this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.ultraButton1.Location = new System.Drawing.Point(88, 168);
			this.ultraButton1.Name = "ultraButton1";
			this.ultraButton1.TabIndex = 24;
			this.ultraButton1.Text = "注册";
			this.ultraButton1.Click += new System.EventHandler(this.btnReg_Click);
			// 
			// ultraButton2
			// 
			this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.ultraButton2.Location = new System.Drawing.Point(184, 168);
			this.ultraButton2.Name = "ultraButton2";
			this.ultraButton2.TabIndex = 25;
			this.ultraButton2.Text = "取消";
			this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
			// 
			// ProductRegister
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(376, 221);
			this.ControlBox = false;
			this.Controls.Add(this.ultraButton2);
			this.Controls.Add(this.ultraButton1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txts5);
			this.Controls.Add(this.txts4);
			this.Controls.Add(this.txts3);
			this.Controls.Add(this.txts2);
			this.Controls.Add(this.txts1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "ProductRegister";
			this.Text = "产品注册";
			this.Load += new System.EventHandler(this.ProductRegister_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void ProductRegister_Load(object sender, System.EventArgs e)
		{
			label1.Text="注册\n" + "本软件为受权软件，未经注册，您将受限使用部份功能。\n" + "通过注册，您将可以使用全部功能。";
		}

		private void btnReg_Click(object sender, System.EventArgs e)
		{
			string str_ss1,str_ss2,str_ss3,str_ss4,str_ss5;
			string str_sn1,str_sn2,str_sn3,str_sn4,str_sn5;
			if(txts5.Text.Trim().Length!=5)
			{
				MessageBox.Show("注册序列号不正确，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				str_sn5=txts5.Text.Trim();
				str_ss1=txts5.Text.Trim().Substring(4,1);
			}
			if(txts4.Text.Trim().Length!=5)
			{
				MessageBox.Show("注册序列号不正确，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				str_sn4=txts4.Text.Trim();
				str_ss2=txts4.Text.Trim().Substring(3,1);
			}
			if(txts3.Text.Trim().Length!=5)
			{
				MessageBox.Show("注册序列号不正确，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				str_sn3=txts3.Text.Trim();
				str_ss3=txts3.Text.Trim().Substring(2,1);
			}
			if(txts2.Text.Trim().Length!=5)
			{
				MessageBox.Show("注册序列号不正确，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				str_sn2=txts2.Text.Trim();
				str_ss4=txts2.Text.Trim().Substring(1,1);
			}
			if(txts1.Text.Trim().Length!=5)
			{
				MessageBox.Show("注册序列号不正确，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				str_sn1=txts1.Text.Trim();
				str_ss5=txts1.Text.Trim().Substring(0,1);
			}

			//读硬盘的序列号
			string str_SerialNumber;
			string str_nb1,str_nb2,str_nb3,str_nb4,str_nb5;
			HardDiskInfo hdd = AtapiDevice.GetHddInfo(0); // 第一个硬盘
			str_SerialNumber=hdd.SerialNumber.ToString();//AtapiDevice.getHDDID().Trim();//
			str_nb1=str_SerialNumber.Substring(0,1);
			str_nb2=str_SerialNumber.Substring(1,1);
			str_nb3=str_SerialNumber.Substring(2,1);
			str_nb4=str_SerialNumber.Substring(3,1);
			str_nb5=str_SerialNumber.Substring(4,1);

			if(str_nb1==str_ss1&&str_nb2==str_ss2&&str_nb3==str_ss3&&str_nb4==str_ss4&&str_nb5==str_ss5)
			{
				//加密
				DESEncryptor dese1=new DESEncryptor();
				dese1.InputString=str_sn1 + "-" + str_sn2 + "-" + str_sn3 + "-" + str_sn4 + "-" + str_sn5;
				dese1.EncryptKey="zhenghua0lhgynkm0";
				dese1.DesEncrypt();
				string mingWen=dese1.OutString;
				dese1=null;
				
				//写注册表
				string name="ProductKey";
				string tovalue=mingWen;
				string[] subkeyNames;
				bool _exist=false;
				if (tovalue!="")
				{
					RegistryKey hklm = Registry.LocalMachine; 
					RegistryKey software = hklm.OpenSubKey("SOFTWARE",true);
					subkeyNames = software.GetSubKeyNames();
					foreach(string keyName in subkeyNames)
					{
						if(keyName == "KMMWAMS")
						{
							RegistryKey aimdir = software.OpenSubKey("KMMWAMS",true);
							aimdir.SetValue(name,tovalue);
							_exist=true;
						}
					}
					if(!_exist)
					{
						RegistryKey aimdir = software.CreateSubKey("KMMWAMS");
						aimdir.SetValue(name,tovalue);
					}

					MessageBox.Show("恭喜，您已成功注册，系统将自动退出，稍后请重新启动会员管理系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					Application.Exit();
				}
				else
				{
					MessageBox.Show("注册失败，请稍后重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
			}
			else
			{
				MessageBox.Show("注册序列号不正确，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
		}


		private void ultraButton2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
	}
}
