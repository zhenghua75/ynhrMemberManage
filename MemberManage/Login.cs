using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using MemberManage.Business;
using System.Data;
using System.Data.SqlClient;
using Infragistics.Win.AppStyling;
using System.Reflection;
using System.IO;
using ynhrMemberManage.CardCommon.CardRef;
using ynhrMemberManage.CardCommon.CardDef;
using ynhrMemberManage.Common;
using ynhrMemberManage.Business;
using ynhrMemberManage.BusinessFacade;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Web.Security;
using System.Security.Principal;
using Microsoft.Practices.EnterpriseLibrary.Security;
using System.Threading;
using System.Collections.Generic;
using ynhrMemeberManage.Security;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using System.Text;
namespace MemberManage
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login : System.Windows.Forms.Form
	{
		private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraButton btnLogin;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		public Infragistics.Win.UltraWinEditors.UltraTextEditor txtPWD;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;

        public static ConstApp constApp = new ConstApp();
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDept;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor txtOperName;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraButton btnBrushCard;
		int iLoginTime = 0;
		//public bool isLogin = false;

//		public ArrayList alOperFunc;
//		public Oper oper ;
//		public int iDiscount = 100;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Login()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		[STAThread]
		static void Main(string[] args)
		{
            Assembly asm = Assembly.GetExecutingAssembly();
            Stream styleStream = asm.GetManifestResourceStream("MemberManage.Resources.Template_Vista.isl");
            //Stream styleStream = asm.GetManifestResourceStream("MemberManage.Resources.Template_Office2007.isl");
            StyleManager.Load(styleStream, true);

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


			Application.Run(new  Login()); 
		}

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is System.Exception)
            {
                if (e.ExceptionObject is BusinessException)
                {
                    MessageBox.Show(((BusinessException)e.ExceptionObject).Message, ((BusinessException)e.ExceptionObject).Type, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(((System.Exception)e.ExceptionObject).Message,"������Ϣ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                HandleException((System.Exception)e.ExceptionObject);
                //ExceptionPolicy.HandleException((System.Exception)e.ExceptionObject, "Exception Policy");
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception is BusinessException)
            {
                MessageBox.Show(((BusinessException)e.Exception).Message, ((BusinessException)e.Exception).Type, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(((System.Exception)e.Exception).Message, "������Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //DialogResult dr = MessageBox.Show(e.Exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            HandleException(e.Exception);
            //ExceptionPolicy.HandleException(e.Exception, "Exception Policy");
        }
        static void HandleException(Exception e)
        {
            try
            {
                ExceptionPolicy.HandleException(e, "Exception Policy");
            }
            catch
            {                
                MessageBox.Show("Ӧ�ó����쳣", "Ӧ�ó������", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Login));
			this.ultraPictureBox1 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
			this.btnLogin = new Infragistics.Win.Misc.UltraButton();
			this.btnCancel = new Infragistics.Win.Misc.UltraButton();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.txtPWD = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
			this.btnBrushCard = new Infragistics.Win.Misc.UltraButton();
			this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
			this.txtOperName = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.cmbDept = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			((System.ComponentModel.ISupportInitialize)(this.txtPWD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
			this.ultraGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtOperName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbDept)).BeginInit();
			this.SuspendLayout();
			// 
			// ultraPictureBox1
			// 
			this.ultraPictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.ultraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty;
			this.ultraPictureBox1.Image = ((object)(resources.GetObject("ultraPictureBox1.Image")));
			this.ultraPictureBox1.Location = new System.Drawing.Point(8, 0);
			this.ultraPictureBox1.Name = "ultraPictureBox1";
			this.ultraPictureBox1.Size = new System.Drawing.Size(232, 120);
			this.ultraPictureBox1.TabIndex = 0;
			// 
			// btnLogin
			// 
			this.btnLogin.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnLogin.Location = new System.Drawing.Point(16, 144);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(56, 23);
			this.btnLogin.TabIndex = 5;
			this.btnLogin.Text = "��¼";
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(88, 144);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(56, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "ȡ��";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.Location = new System.Drawing.Point(24, 64);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(64, 23);
			this.ultraLabel1.TabIndex = 3;
			this.ultraLabel1.Text = "�û�����";
			// 
			// ultraLabel2
			// 
			this.ultraLabel2.Location = new System.Drawing.Point(24, 104);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.Size = new System.Drawing.Size(56, 23);
			this.ultraLabel2.TabIndex = 4;
			this.ultraLabel2.Text = "��  �룺";
			// 
			// txtPWD
			// 
			this.txtPWD.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtPWD.Location = new System.Drawing.Point(96, 104);
			this.txtPWD.Name = "txtPWD";
			this.txtPWD.NullText = "����������";
			this.txtPWD.PasswordChar = '*';
			this.txtPWD.Size = new System.Drawing.Size(120, 21);
			this.txtPWD.TabIndex = 2;
			// 
			// ultraGroupBox1
			// 
			this.ultraGroupBox1.Controls.Add(this.btnBrushCard);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
			this.ultraGroupBox1.Controls.Add(this.txtOperName);
			this.ultraGroupBox1.Controls.Add(this.cmbDept);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
			this.ultraGroupBox1.Controls.Add(this.txtPWD);
			this.ultraGroupBox1.Controls.Add(this.btnLogin);
			this.ultraGroupBox1.Controls.Add(this.btnCancel);
			this.ultraGroupBox1.Location = new System.Drawing.Point(8, 120);
			this.ultraGroupBox1.Name = "ultraGroupBox1";
			this.ultraGroupBox1.Size = new System.Drawing.Size(232, 184);
			this.ultraGroupBox1.TabIndex = 7;
			this.ultraGroupBox1.Text = "����Ա��¼";
			// 
			// btnBrushCard
			// 
			this.btnBrushCard.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnBrushCard.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnBrushCard.Location = new System.Drawing.Point(160, 144);
			this.btnBrushCard.Name = "btnBrushCard";
			this.btnBrushCard.Size = new System.Drawing.Size(56, 23);
			this.btnBrushCard.TabIndex = 10;
			this.btnBrushCard.Text = "ˢ��";
			this.btnBrushCard.Click += new System.EventHandler(this.btnBrushCard_Click);
			// 
			// ultraLabel3
			// 
			this.ultraLabel3.Location = new System.Drawing.Point(24, 32);
			this.ultraLabel3.Name = "ultraLabel3";
			this.ultraLabel3.Size = new System.Drawing.Size(56, 23);
			this.ultraLabel3.TabIndex = 9;
			this.ultraLabel3.Text = "��  �ţ�";
			// 
			// txtOperName
			// 
			this.txtOperName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtOperName.Location = new System.Drawing.Point(96, 64);
			this.txtOperName.Name = "txtOperName";
			this.txtOperName.Size = new System.Drawing.Size(120, 21);
			this.txtOperName.TabIndex = 1;
			// 
			// cmbDept
			// 
			this.cmbDept.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbDept.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.cmbDept.Location = new System.Drawing.Point(96, 24);
			this.cmbDept.Name = "cmbDept";
			this.cmbDept.Size = new System.Drawing.Size(120, 21);
			this.cmbDept.TabIndex = 7;
			this.cmbDept.ValueChanged += new System.EventHandler(this.cmbDept_ValueChanged);
			// 
			// Login
			// 
			this.AcceptButton = this.btnLogin;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(242)), ((System.Byte)(242)), ((System.Byte)(242)));
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(248, 309);
			this.ControlBox = false;
			this.Controls.Add(this.ultraGroupBox1);
			this.Controls.Add(this.ultraPictureBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Login";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "�����˲��г���Ա����ϵͳ";
			this.Load += new System.EventHandler(this.Login_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtPWD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
			this.ultraGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtOperName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbDept)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void btnLogin_Click(object sender, System.EventArgs e)
		{            
			//��¼
			try
			{
				
				if (iLoginTime > 3)
				{
					Application.Exit();
				}
				else
				{
					string strOperName = txtOperName.Text.Trim();
					string strPWD = txtPWD.Text.Trim();
					if (strOperName.Length == 0)
					{
						throw new BusinessException("��¼����","�������û�����");
					}
					if (strPWD.Length == 0)
					{
						throw new BusinessException("��¼����","���������룡");
					}
                    SysInit.LoadPara(Login.constApp);
                    LogIn(strOperName, strPWD,Login.constApp.strCardTypeL6Name,Login.constApp.strCardTypeL8Name);
                    SecurityManage security = new SecurityManage();

                    //security.OperLogin(strOperName);//,DataSecurity.Encrypt(strPWD);
                    //constApp.alOperFunc = security.alOperFunc;
                    //constApp.oper = security.oper;
                    //constApp.iDiscount = security.iDiscount;
					//isLogin = true;
					//constApp = new ConstApp();
					//LogAdapter.WriteFeaturesException(new Exception("�����������ǰ"));
                    

					//LogAdapter.WriteFeaturesException(new Exception("����������ݺ�"));

					OperLogin login = new OperLogin();
					if (cmbDept.SelectedItem != null)
					{
						login.cnnDeptID = int.Parse(cmbDept.SelectedItem.DataValue.ToString());
					}
					
					login.cnvcOperName = txtOperName.Text;
					login.cndLoginDate = DateTime.Now;
					login.cnvcLoginMethod = "¼��";
					login.cnnAgainTime = iLoginTime;
					security.LoginLog(login);

					//LogAdapter.WriteFeaturesException(new Exception("д��¼��־"));
					MainForm mForm = new MainForm();
                    mForm.Owner = this;
					//mForm.ll = this;
					//LogAdapter.WriteFeaturesException(new Exception("������new���"));
					mForm.Show();
					//LogAdapter.WriteFeaturesException(new Exception("������show���"));
                    this.Hide();
					//LogAdapter.WriteFeaturesException(new Exception("����������"));
				}
			}
			catch (BusinessException bex)
			{
				iLoginTime += 1;
				//MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
				this.txtOperName.Focus();
                throw bex;
				//isLogin = false;
			}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(this, ex.Message, "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    Application.Exit();
            //    //this.btnLogin.DialogResult = DialogResult.Cancel;
            //}
		}

        private static void LogIn(string strOperName, string strPWD,string strL6Name,string strL8Name)
        {
            if (!Membership.ValidateUser(strOperName, strPWD))
            {
                throw new BusinessException("��¼����", "����Ա�������������");
            }


            SecurityManage security = new SecurityManage();
            Oper oper = security.GetOperByName(strOperName);
            Dept dept = new Dept();
            dept.cnnDeptID = 0;
            dept.cnnDiscount = 0;
            dept.cnvcDeptName = "�����˲�����";
            if(oper.cnnDeptID != 0)
              dept = security.GetDeptById(oper.cnnDeptID);

            List<string> lFunc = security.GetFuncById(oper.cnnOperID, oper.cnnDeptID,constApp.strCardType,strL6Name,strL8Name);
            List<string> lAllFunc = security.GetAllFunc(constApp.strCardType, strL6Name, strL8Name);
            MyIdentity myidentity = new MyIdentity(oper, dept, Membership.Provider.Name);
            MyPrincipal myprincipal = new MyPrincipal(myidentity, lFunc,lAllFunc);
            Thread.CurrentPrincipal = myprincipal;
            //AppDomain.CurrentDomain.SetThreadPrincipal(myprincipal);
            //return security;
        }

		private void cmbDept_ValueChanged(object sender, System.EventArgs e)
		{
			//��ʼ������Ա
			try
			{
				SecurityManage security = new SecurityManage();
				DataTable dtOper = security.getAllOperByDept(cmbDept.SelectedItem.DataValue.ToString());
				txtOperName.DataSource = dtOper;
				txtOperName.DisplayMember = "cnvcOperName";
				txtOperName.ValueMember = "cnnOperID";
				txtOperName.DataBind();
				txtOperName.SelectedIndex = 0;
			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
				this.txtOperName.Focus();
				//isLogin = false;
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"ϵͳ����",MessageBoxButtons.OK,MessageBoxIcon.Error);
				Application.Exit();
				//this.btnLogin.DialogResult = DialogResult.Cancel;
			}

		}

		private void Login_Load(object sender, System.EventArgs e)
		{
			//��ʼ������
			//getAllDept
            if (CheckForUpdate.IsUpdate())
            {
                //this.Close();
                Application.Exit();
                Process.Start("AutoUpdate.exe");
                return;
            }
            //this.Visible = false;

            if (File.Exists(Application.StartupPath + @"\BatchScript.bat") && File.Exists(Application.StartupPath + @"\Script.sql"))
            {
                Process.Start("BatchScript.bat");
            }
            if (File.Exists(Application.StartupPath + @"\AutoUpdate.exe.delete"))
            {
                //Process.Start("BatchScript.bat");
                File.Delete(Application.StartupPath + @"\AutoUpdate.exe.delete");
            }			

			try
			{
				SecurityManage security = new SecurityManage();
				DataTable dtDept = security.getAllDept();
				cmbDept.DataSource = dtDept;
				cmbDept.DisplayMember = "��������";
				cmbDept.ValueMember = "����ID";
				cmbDept.DataBind();
				cmbDept.SelectedIndex = 0;

                
			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
				this.txtOperName.Focus();
				//isLogin = false;
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"ϵͳ����",MessageBoxButtons.OK,MessageBoxIcon.Error);
				Application.Exit();
				//this.btnLogin.DialogResult = DialogResult.Cancel;
			}

		}

		private void btnBrushCard_Click(object sender, System.EventArgs e)
		{
			//ˢ����¼
			try
			{
				//��ȡ��Ա����
				iLoginTime += 1;
				if (iLoginTime > 3)
				{
					Application.Exit();
				}
				else
				{
				
					CardM1 m1=new CardM1();
					string strCardNo = "";
					string strRet = m1.ReadCard(out strCardNo);//,out dtemp,out itemp);

					if (strRet != ConstMsg.RFOK)
					{
						throw new BusinessException("������ʧ��","��ȡ����Ա��ʧ�ܣ�");
					}		
					DataTable dtOper = Helper.Query("select * from tbOper where cnvcCardNo is not null and cnvcCardNo = '"+strCardNo+"'");
					if (dtOper.Rows.Count == 0)
					{
						throw new BusinessException("��¼","δ�ҵ�����Ա");
					}
					if (dtOper.Rows.Count > 1)
					{
						throw new BusinessException("��¼","δ�ҵ�����Ա");
					}
                    
                    Oper oper = new Oper(dtOper);
                    byte[] bIn = Convert.FromBase64String(oper.cnvcPwd);
                    byte[] bRet = Cryptographer.DecryptSymmetric("Custom Symmetric Cryptography Provider", bIn);
                    if (bRet == null)
                        throw new BusinessException("��¼", "�������");
                    string strpwd = Encoding.UTF8.GetString(bRet);
                    SysInit.LoadPara(Login.constApp);
                    LogIn(oper.cnvcOperName, strpwd,Login.constApp.strCardTypeL6Name,Login.constApp.strCardTypeL8Name);
                    SecurityManage security = new SecurityManage();
                    //security.OperLogin(oper.cnvcOperName);//,oper.cnvcPwd);
					//constApp.alOperFunc = security.alOperFunc;
					//constApp.oper = security.oper;
					//constApp.iDiscount = security.iDiscount;
                    //SysInit.LoadPara(Login.constApp);

					OperLogin login = new OperLogin(oper.ToTable());
					login.cndLoginDate = DateTime.Now;
					login.cnvcLoginMethod = "ˢ��";
					login.cnnAgainTime = iLoginTime;
					security.LoginLog(login);
					MainForm mForm = new MainForm();
					//mForm.ll = this;
                    mForm.Owner = this;
					mForm.Show();
					this.Hide();// = false;
				}
			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(this,ex.Message,"ϵͳ����",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}
		}


        
	
	}
}
