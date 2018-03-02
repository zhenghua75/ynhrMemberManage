#region Import
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Infragistics.Shared; 
using Infragistics.Win; 
using Infragistics.Win.UltraWinGrid; 
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.Misc;
using ynhrMemberManage.ORM;
//using ynhrMemberManage.MemberManage.Common;
using ynhrMemberManage.CardCommon.CardRef;
using ynhrMemberManage.CardCommon.CardDef;
//using MemberManage.Print;
//using MemberManage.Business;
using Infragistics.Win.UltraWinTree;
using ynhrMemberManage.Domain;
using ynhrMemberManage.Print;
using ynhrMemberManage.BusinessFacade.MemberBusiness;
using ynhrMemberManage.Common;
#endregion
namespace TouchHold.TouchOne
{
	/// <summary>
	/// Summary description for ShowSignIn.
	/// </summary>
	public class ShowSignIn : frmBase
	{
		#region 变量
		private Infragistics.Win.Misc.UltraButton btnSignIn;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolTip toolTip1;
		private Infragistics.Win.Misc.UltraButton btnExit;

		private Infragistics.Win.Misc.UltraGroupBox boxLogin;
		private Infragistics.Win.Misc.UltraGroupBox boxOper;
		private Infragistics.Win.Misc.UltraGroupBox boxInfo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberPwd;

		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel lblPrintTip;
		private Infragistics.Win.Misc.UltraLabel lblPaperNo;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.Misc.UltraButton ultraButton3;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.Misc.UltraLabel lblMemberName;
		private Infragistics.Win.Misc.UltraLabel lblMemberCardNo;
		private Infragistics.Win.Misc.UltraLabel lblSeat;
		private Infragistics.Win.Misc.UltraLabel lblJobName;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraButton btnReturn;
		private Infragistics.Win.Misc.UltraLabel lblBookError;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Infragistics.Win.Misc.UltraGroupBox ugbInfoConfirm;
		private Infragistics.Win.Misc.UltraGroupBox ugbInfoDisp;
		private Infragistics.Win.Misc.UltraGroupBox ugbInfoTip;
		private Infragistics.Win.Misc.UltraGroupBox ugbJob;
		private Infragistics.Win.Misc.UltraGroupBox ugbShow;
		private Infragistics.Win.Misc.UltraGroupBox ugbSignIn;
		private Infragistics.Win.Misc.UltraLabel lblSelectedSeat;
		private Infragistics.Win.Misc.UltraLabel lblSelectedShow;
		private Infragistics.Win.Misc.UltraLabel lblSelectedJob;
		private Infragistics.Win.Misc.UltraLabel ultraLabel8;
		private Infragistics.Win.Misc.UltraButton btnSelectLogin;
		private Infragistics.Win.Misc.UltraButton btnSelectShow;
		private System.Windows.Forms.Timer timer1;
		private MemberSeat ms = null;
		#endregion

		public ShowSignIn(UltraGroupBox ultraGroupBox1,UltraGroupBox ultraGroupBox2,UltraGroupBox ultraGroupBox3,UltraTextEditor txtMemberCardNo,UltraTextEditor txtMemberPwd)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.boxLogin = ultraGroupBox2;
			this.boxOper = ultraGroupBox3;
			this.boxInfo = ultraGroupBox1;
			this.txtMemberCardNo = txtMemberCardNo;
			this.txtMemberPwd = txtMemberPwd;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			//ApplicationIdleTimer idle = new ApplicationIdleTimer();
            //System.Windows.Forms.Application.AddMessageFilter(idle);
			//idle.ApplicationIdle += new ApplicationIdleTimer.ApplicationIdleEventHandler(this.App_Idle);
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
			//IsShowing = false;
		}
		protected   override   void   WndProc(ref   System.Windows.Forms.Message   m)     
		{     
			if(m.Msg   !=   0x0003   &&   m.WParam   !=   (IntPtr)0xF012)   
			{   
				base.WndProc(ref   m);   
			}
    
		}  

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.btnSignIn = new Infragistics.Win.Misc.UltraButton();
            this.ugbInfoDisp = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.lblSelectedSeat = new Infragistics.Win.Misc.UltraLabel();
            this.lblSelectedShow = new Infragistics.Win.Misc.UltraLabel();
            this.lblSelectedJob = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ugbSignIn = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnSelectShow = new Infragistics.Win.Misc.UltraButton();
            this.btnSelectLogin = new Infragistics.Win.Misc.UltraButton();
            this.btnExit = new Infragistics.Win.Misc.UltraButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ugbInfoConfirm = new Infragistics.Win.Misc.UltraGroupBox();
            this.lblPrintTip = new Infragistics.Win.Misc.UltraLabel();
            this.lblPaperNo = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraButton3 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.lblMemberName = new Infragistics.Win.Misc.UltraLabel();
            this.lblMemberCardNo = new Infragistics.Win.Misc.UltraLabel();
            this.lblSeat = new Infragistics.Win.Misc.UltraLabel();
            this.lblJobName = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ugbInfoTip = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnReturn = new Infragistics.Win.Misc.UltraButton();
            this.lblBookError = new Infragistics.Win.Misc.UltraLabel();
            this.ugbJob = new Infragistics.Win.Misc.UltraGroupBox();
            this.ugbShow = new Infragistics.Win.Misc.UltraGroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ugbInfoDisp)).BeginInit();
            this.ugbInfoDisp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbSignIn)).BeginInit();
            this.ugbSignIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbInfoConfirm)).BeginInit();
            this.ugbInfoConfirm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbInfoTip)).BeginInit();
            this.ugbInfoTip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbShow)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSignIn
            // 
            this.btnSignIn.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnSignIn.Location = new System.Drawing.Point(24, 24);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(240, 64);
            this.btnSignIn.TabIndex = 7;
            this.btnSignIn.Text = "签到";
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // ugbInfoDisp
            // 
            this.ugbInfoDisp.Controls.Add(this.ultraLabel8);
            this.ugbInfoDisp.Controls.Add(this.lblSelectedSeat);
            this.ugbInfoDisp.Controls.Add(this.lblSelectedShow);
            this.ugbInfoDisp.Controls.Add(this.lblSelectedJob);
            this.ugbInfoDisp.Controls.Add(this.ultraLabel7);
            this.ugbInfoDisp.Controls.Add(this.ultraLabel3);
            this.ugbInfoDisp.Controls.Add(this.ultraLabel1);
            this.ugbInfoDisp.Location = new System.Drawing.Point(576, 16);
            this.ugbInfoDisp.Name = "ugbInfoDisp";
            this.ugbInfoDisp.Size = new System.Drawing.Size(288, 368);
            this.ugbInfoDisp.TabIndex = 14;
            // 
            // ultraLabel8
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance1;
            this.ultraLabel8.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraLabel8.Location = new System.Drawing.Point(24, 288);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(240, 64);
            this.ultraLabel8.TabIndex = 18;
            this.ultraLabel8.Text = "请选择展位";
            // 
            // lblSelectedSeat
            // 
            this.lblSelectedSeat.Font = new System.Drawing.Font("宋体", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSelectedSeat.Location = new System.Drawing.Point(88, 192);
            this.lblSelectedSeat.Name = "lblSelectedSeat";
            this.lblSelectedSeat.Size = new System.Drawing.Size(176, 80);
            this.lblSelectedSeat.TabIndex = 17;
            // 
            // lblSelectedShow
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.lblSelectedShow.Appearance = appearance2;
            this.lblSelectedShow.Location = new System.Drawing.Point(96, 112);
            this.lblSelectedShow.Name = "lblSelectedShow";
            this.lblSelectedShow.Size = new System.Drawing.Size(176, 64);
            this.lblSelectedShow.TabIndex = 16;
            this.lblSelectedShow.Text = "展厅：";
            // 
            // lblSelectedJob
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.lblSelectedJob.Appearance = appearance3;
            this.lblSelectedJob.Location = new System.Drawing.Point(96, 16);
            this.lblSelectedJob.Name = "lblSelectedJob";
            this.lblSelectedJob.Size = new System.Drawing.Size(184, 64);
            this.lblSelectedJob.TabIndex = 15;
            this.lblSelectedJob.Text = "招聘会：";
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Location = new System.Drawing.Point(16, 40);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(96, 23);
            this.ultraLabel7.TabIndex = 14;
            this.ultraLabel7.Text = "招聘会：";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(16, 128);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(72, 23);
            this.ultraLabel3.TabIndex = 11;
            this.ultraLabel3.Text = "展厅：";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(16, 208);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(72, 23);
            this.ultraLabel1.TabIndex = 9;
            this.ultraLabel1.Text = "展位：";
            // 
            // ugbSignIn
            // 
            this.ugbSignIn.Controls.Add(this.btnSelectShow);
            this.ugbSignIn.Controls.Add(this.btnSelectLogin);
            this.ugbSignIn.Controls.Add(this.btnExit);
            this.ugbSignIn.Controls.Add(this.btnSignIn);
            this.ugbSignIn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ugbSignIn.Location = new System.Drawing.Point(656, 392);
            this.ugbSignIn.Name = "ugbSignIn";
            this.ugbSignIn.Size = new System.Drawing.Size(280, 264);
            this.ugbSignIn.TabIndex = 15;
            // 
            // btnSelectShow
            // 
            this.btnSelectShow.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnSelectShow.Location = new System.Drawing.Point(24, 88);
            this.btnSelectShow.Name = "btnSelectShow";
            this.btnSelectShow.Size = new System.Drawing.Size(240, 56);
            this.btnSelectShow.TabIndex = 11;
            this.btnSelectShow.Text = "选择展厅";
            this.btnSelectShow.Click += new System.EventHandler(this.btnSelectShow_Click);
            // 
            // btnSelectLogin
            // 
            this.btnSelectLogin.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnSelectLogin.Location = new System.Drawing.Point(24, 144);
            this.btnSelectLogin.Name = "btnSelectLogin";
            this.btnSelectLogin.Size = new System.Drawing.Size(240, 56);
            this.btnSelectLogin.TabIndex = 10;
            this.btnSelectLogin.Text = "返回主菜单";
            this.btnSelectLogin.Click += new System.EventHandler(this.btnSelectLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnExit.Location = new System.Drawing.Point(24, 200);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(240, 56);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "退出系统";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ugbInfoConfirm
            // 
            this.ugbInfoConfirm.Controls.Add(this.lblPrintTip);
            this.ugbInfoConfirm.Controls.Add(this.lblPaperNo);
            this.ugbInfoConfirm.Controls.Add(this.ultraLabel9);
            this.ugbInfoConfirm.Controls.Add(this.ultraButton3);
            this.ugbInfoConfirm.Controls.Add(this.ultraButton1);
            this.ugbInfoConfirm.Controls.Add(this.lblMemberName);
            this.ugbInfoConfirm.Controls.Add(this.lblMemberCardNo);
            this.ugbInfoConfirm.Controls.Add(this.lblSeat);
            this.ugbInfoConfirm.Controls.Add(this.lblJobName);
            this.ugbInfoConfirm.Controls.Add(this.ultraLabel6);
            this.ugbInfoConfirm.Controls.Add(this.ultraLabel5);
            this.ugbInfoConfirm.Controls.Add(this.ultraLabel4);
            this.ugbInfoConfirm.Controls.Add(this.ultraLabel2);
            this.ugbInfoConfirm.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ugbInfoConfirm.Location = new System.Drawing.Point(8, 8);
            this.ugbInfoConfirm.Name = "ugbInfoConfirm";
            this.ugbInfoConfirm.Size = new System.Drawing.Size(552, 312);
            this.ugbInfoConfirm.TabIndex = 18;
            this.ugbInfoConfirm.Text = "展位签到信息确认";
            // 
            // lblPrintTip
            // 
            this.lblPrintTip.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrintTip.Location = new System.Drawing.Point(24, 200);
            this.lblPrintTip.Name = "lblPrintTip";
            this.lblPrintTip.Size = new System.Drawing.Size(512, 64);
            this.lblPrintTip.TabIndex = 12;
            this.lblPrintTip.Text = "签到成功，请在刷卡器下面取签到小票，再到四号窗口领取参会资料！";
            this.lblPrintTip.Visible = false;
            // 
            // lblPaperNo
            // 
            this.lblPaperNo.Location = new System.Drawing.Point(168, 160);
            this.lblPaperNo.Name = "lblPaperNo";
            this.lblPaperNo.Size = new System.Drawing.Size(376, 23);
            this.lblPaperNo.TabIndex = 11;
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.Location = new System.Drawing.Point(16, 160);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(136, 23);
            this.ultraLabel9.TabIndex = 10;
            this.ultraLabel9.Text = "工商注册号：：";
            // 
            // ultraButton3
            // 
            this.ultraButton3.Location = new System.Drawing.Point(280, 272);
            this.ultraButton3.Name = "ultraButton3";
            this.ultraButton3.Size = new System.Drawing.Size(120, 40);
            this.ultraButton3.TabIndex = 9;
            this.ultraButton3.Text = "返回";
            this.ultraButton3.Click += new System.EventHandler(this.ultraButton3_Click);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(120, 272);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(120, 40);
            this.ultraButton1.TabIndex = 8;
            this.ultraButton1.Text = "确定";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // lblMemberName
            // 
            this.lblMemberName.Location = new System.Drawing.Point(168, 128);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(376, 23);
            this.lblMemberName.TabIndex = 7;
            // 
            // lblMemberCardNo
            // 
            this.lblMemberCardNo.Location = new System.Drawing.Point(168, 96);
            this.lblMemberCardNo.Name = "lblMemberCardNo";
            this.lblMemberCardNo.Size = new System.Drawing.Size(376, 23);
            this.lblMemberCardNo.TabIndex = 6;
            // 
            // lblSeat
            // 
            this.lblSeat.Location = new System.Drawing.Point(168, 64);
            this.lblSeat.Name = "lblSeat";
            this.lblSeat.Size = new System.Drawing.Size(376, 23);
            this.lblSeat.TabIndex = 5;
            // 
            // lblJobName
            // 
            this.lblJobName.Location = new System.Drawing.Point(168, 32);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(376, 23);
            this.lblJobName.TabIndex = 4;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(16, 128);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(136, 23);
            this.ultraLabel6.TabIndex = 3;
            this.ultraLabel6.Text = "单位名称：";
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(16, 96);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(136, 23);
            this.ultraLabel5.TabIndex = 2;
            this.ultraLabel5.Text = "会员卡号：";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(16, 64);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(136, 23);
            this.ultraLabel4.TabIndex = 1;
            this.ultraLabel4.Text = "展位：";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(16, 32);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(144, 23);
            this.ultraLabel2.TabIndex = 0;
            this.ultraLabel2.Text = "招聘会：";
            // 
            // ugbInfoTip
            // 
            this.ugbInfoTip.Controls.Add(this.btnReturn);
            this.ugbInfoTip.Controls.Add(this.lblBookError);
            this.ugbInfoTip.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ugbInfoTip.Location = new System.Drawing.Point(8, 328);
            this.ugbInfoTip.Name = "ugbInfoTip";
            this.ugbInfoTip.Size = new System.Drawing.Size(552, 216);
            this.ugbInfoTip.TabIndex = 19;
            this.ugbInfoTip.Text = "信息提示";
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(160, 144);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(200, 64);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "返回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblBookError
            // 
            this.lblBookError.Location = new System.Drawing.Point(16, 32);
            this.lblBookError.Name = "lblBookError";
            this.lblBookError.Size = new System.Drawing.Size(528, 104);
            this.lblBookError.TabIndex = 0;
            // 
            // ugbJob
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.ugbJob.Appearance = appearance4;
            this.ugbJob.Location = new System.Drawing.Point(216, 568);
            this.ugbJob.Name = "ugbJob";
            this.ugbJob.Size = new System.Drawing.Size(176, 56);
            this.ugbJob.TabIndex = 20;
            this.ugbJob.Text = "招聘会";
            // 
            // ugbShow
            // 
            this.ugbShow.Location = new System.Drawing.Point(216, 632);
            this.ugbShow.Name = "ugbShow";
            this.ugbShow.Size = new System.Drawing.Size(248, 56);
            this.ugbShow.TabIndex = 21;
            this.ugbShow.Text = "请选择招聘会展厅";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ShowSignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.ClientSize = new System.Drawing.Size(1024, 746);
            this.ControlBox = false;
            this.Controls.Add(this.ugbShow);
            this.Controls.Add(this.ugbJob);
            this.Controls.Add(this.ugbInfoTip);
            this.Controls.Add(this.ugbInfoConfirm);
            this.Controls.Add(this.ugbSignIn);
            this.Controls.Add(this.ugbInfoDisp);
            this.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowSignIn";
            this.Text = "展位签到";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ShowSignIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ugbInfoDisp)).EndInit();
            this.ugbInfoDisp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbSignIn)).EndInit();
            this.ugbSignIn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbInfoConfirm)).EndInit();
            this.ugbInfoConfirm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbInfoTip)).EndInit();
            this.ugbInfoTip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbShow)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		#region 展位
		private void LoadSeat(Panel pl,string strFloor,string strJobID)
		{
			string strSql = "select a.*,c.cnvcMemberCardNo,c.cnvcPaperNo,c.cnvcMemberName,c.cnvcFree from tbShowSeat a "
				+" left outer join tbMemberSeat b on a.cnnJobID=b.cnnID "
				+" and a.cnvcSeat=b.cnvcSeat and a.cnvcFloor=b.cnvcFloor "
				//+" and  b.cnvcState = '"+ConstApp.Show_Seat_State_Booking+"'"
				+" left outer join tbMember c on b.cnvcMemberCardNo=c.cnvcMemberCardNo "
				+" where a.cnvcFloor='"+strFloor+"' and a.cnnJobID="+strJobID;
			DataTable dtSeat = Helper.Query(strSql);
			//DataTable dtSeat = Helper.Query("select * from tbShowSeat where cnvcFloor='"+strFloor+"' and cnnJobID="+strJobID);
			foreach (DataRow drSeat in dtSeat.Rows)
			{
				ShowSeat seat = new ShowSeat(drSeat);
				zhhLabel lbl = new zhhLabel();
				lbl.Name = "lbl"+seat.cnvcControlName;
				lbl.Text = seat.cnvcControlName;//seat.cnvcSeat;
				if (seat.cnvcControlName.StartsWith("黑"))
				{
					lbl.BackColor = Color.Black;
				}
				if (seat.cnvcControlName.StartsWith("空"))
				{
					lbl.Text = "";
				}
				else if (seat.cnvcState.Length > 1)
				{
					lbl.BackColor = Color.Red;
				}
				Point p1 = new Point(seat.cnnX,seat.cnnY);
				lbl.Location = p1;
				lbl.Height = seat.cnnHeight;
				lbl.Width = seat.cnnWidth;
				lbl.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
				lbl.TextAlign = ContentAlignment.MiddleCenter;
				lbl.BorderStyle = BorderStyle.None;
				Helper.SetlblDirection(lbl,seat.cnvcDirection);
				if (Helper.IsNumber(seat.cnvcControlName))
				{
					if (seat.cnvcState == "")
					{
						lbl.Click +=new EventHandler(lbl_Click);
					}
					else
					{
						lbl.Click +=new EventHandler(lblUse_Click);
					}
					
				}				
				pl.Controls.Add(lbl);
					
			}

		}
		private void lbl_Click(object sender, EventArgs e)
		{
			Control lCtrl =(sender as Control);
			lblSelectedSeat.Text = lCtrl.Text;
//			ugbSignIn.Visible = true;
//			ugbSignIn.Left = ugbInfoDisp.Left;
//			ugbSignIn.Top = ugbInfoDisp.Top+ugbInfoDisp.Height+30;
			ms.cnvcSeat = lCtrl.Text;
			ultraLabel8.Visible = false;
			this.btnSignIn.Visible = true;
		}
		private void lblUse_Click(object sender, EventArgs e)
		{
			Control lCtrl =(sender as Control);
			lblSelectedSeat.Text = "";
			//			ugbSignIn.Visible = true;
			//			ugbSignIn.Left = ugbInfoDisp.Left;
			//			ugbSignIn.Top = ugbInfoDisp.Top+ugbInfoDisp.Height+30;
			ms.cnvcSeat = "";
			ultraLabel8.Visible = true;
			this.btnSignIn.Visible = false;
		}
		private void JudgePanel()
		{
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl.Name.StartsWith("panel"))
				{
					this.Controls.Remove(ctrl);
					break;
				}
					
			}
		}
		private void LoadPanel(Show show)
		{
			//导入展位方案
			try
			{		
				ms.cnvcFloor = show.cnnShowID.ToString();
				ms.cnvcShowName = show.cnvcShowName;
				JudgePanel();
				Panel pl = new Panel();
				pl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				//pl.Location = new System.Drawing.Point(show.cnnX, show.cnnY);
				pl.Name = "panel"+show.cnvcShowName;
				pl.Size = new System.Drawing.Size(show.cnnWeight, show.cnnHeight);

				pl.Top = (this.Height - show.cnnHeight)/2;
				pl.Left = (this.Width-ugbInfoDisp.Width)/2-show.cnnWeight/2;
				
				this.Controls.Add(pl);
				LoadSeat(pl,show.cnnShowID.ToString(),show.cnnJobID.ToString());
				this.lblSelectedJob.Text = ms.cnvcJobName;
				this.lblSelectedShow.Text = ms.cnvcShowName;	
				this.lblSelectedSeat.Text = "";
				this.ultraLabel8.Visible = true;
				this.ugbInfoDisp.Top = 100;
				this.ugbInfoDisp.Left = pl.Left + pl.Width + 10;

				ugbSignIn.Visible = true;
				ugbSignIn.Left = ugbInfoDisp.Left;
				ugbSignIn.Top = ugbInfoDisp.Top+ugbInfoDisp.Height+30;

				this.btnSignIn.Visible = false;


			}
			catch (BusinessException bex)
			{
				DispError(bex.Type+"："+bex.Message);
				//MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				DispError("信息提示："+ex.Message);
				//MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}		

		}

		#endregion
		private void ShowSignIn_Load(object sender, System.EventArgs e)
		{
			//this.FormBorderStyle=FormBorderStyle.None;
			this.DispJob();
		}
		#region 招聘会
		private void DispJob()
		{
			//显示招聘会
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl is UltraGroupBox)
				{
					ctrl.Visible = false;
				}
			}
			int iHeight = 0;
			this.ugbJob.Visible = true;
			this.ugbJob.Text = "请选择招聘会";
			this.ugbJob.Font = new Font("宋体",40);
			this.ugbJob.Width = 800;
			this.ugbJob.Appearance.BackColor = Color.Transparent;
			this.ugbJob.Controls.Clear();
			UltraButton btnReturn = new UltraButton();
			btnReturn.Name = "jobReturn";
			btnReturn.Text = "返回";
			btnReturn.Height = 100;
			btnReturn.Font = ugbJob.Font;
			btnReturn.Dock = DockStyle.Top;
			btnReturn.Click +=new EventHandler(btnJobReturn_Click);
			ugbJob.Controls.Add(btnReturn);

			iHeight += 100;
			
			string strSql = "select * from tbJob where cndBeginDate<getdate() and cndEndDate>getdate() order by cndBeginDate desc";
			DataTable dtJob = Helper.Query(strSql);
			int iCount = 0;
			foreach (DataRow drJob in dtJob.Rows)
			{
				Job job = new Job(drJob);
                //if (Form1.constApp.htMemberSeats.Contains(Form1.pMember.cnvcMemberRight))
                //{
                //    DataTable dtSeats = Helper.Query("select count(*) from tbMemberSeat where cnvcMemberCardNo='"+Form1.pMember.cnvcMemberCardNo+"' and cnvcState='"+ConstApp.Show_Seat_State_SignIn+"' and cnnID="+job.cnnJobID.ToString());
                //    string strBookSeats = Form1.constApp.htMemberSeats[Form1.pMember.cnvcMemberRight].ToString();
                //    string strBookedSeats = dtSeats.Rows[0][0].ToString();
                //    if (strBookedSeats != ConstApp.Free_Time_NoLimit)
                //    {
                //        int iBookSeats = int.Parse(strBookSeats);
                //        int iBookedSeats = int.Parse(strBookedSeats);
                //        if (iBookedSeats >= iBookSeats)
                //        {
                //            //btnReturn.Text = "展位签到,已到限制展位数！";
                //            //DispError("展位签到,已到限制展位数！");
                //            continue;
                //            //throw new BusinessException("展位签到","已到限制展位数！");
                //        }
                //    }
                //}
				iCount++;


				UltraButton btn = new UltraButton();
				btn.Name = "job"+job.cnnJobID;
				btn.Text = job.cnvcJobName;
				btn.Tag = job;
				btn.Height = 100;
				btn.Font = ugbJob.Font;
				btn.Dock = DockStyle.Top;
				btn.Click += new EventHandler(btnJob_Click);
				ugbJob.Controls.Add(btn);

				iHeight += 100;
			}
			if(iCount==0)
			{
				UltraButton btn = new UltraButton();
				btn.Name = "joberror";
				btn.Text = "展位签到, 展位已经签到！";
				//btn.Tag = job;
				btn.Height = 100;
				btn.Font = ugbJob.Font;
				btn.Dock = DockStyle.Top;
				//btn.Click += new EventHandler(btnJob_Click);
				ugbJob.Controls.Add(btn);

				iHeight += 100;
			}
			this.ugbJob.Height = iHeight+100;
			this.ugbJob.Top = (this.Height-this.ugbJob.Height)/2;
			this.ugbJob.Left = (this.Width-this.ugbJob.Width)/2;
			
		}

		private void btnJobReturn_Click(object sender, System.EventArgs e)
		{
			//招聘会返回
			this.Close();
		}
		private void btnJob_Click(object sender, System.EventArgs e)
		{
			//招聘会按钮
			UltraButton btn = (UltraButton)sender;
			Job job = (Job)btn.Tag;
			DispShow(job);
		}
		#endregion
		#region 展厅
		private void DispShow(Job job)
		{
			//显示展厅
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl is UltraGroupBox)
				{
					ctrl.Visible = false;
				}
			}
			ms = new MemberSeat(Form1.pMember.ToTable());
			ms.cnnID = job.cnnJobID;
			ms.cnvcJobName = job.cnvcJobName;

			int iHeight = 0;
			this.ugbShow.Visible = true;
			this.ugbShow.Text = "请选择招聘会展厅";
			this.ugbShow.Font = new Font("宋体",40);
			this.ugbShow.Width = 800;
			this.ugbShow.Appearance.BackColor = Color.Transparent;
			this.ugbShow.Controls.Clear();
			UltraButton btnReturn = new UltraButton();
			btnReturn.Name = "jobReturn";
			btnReturn.Text = "返回";
			btnReturn.Height = 100;
			btnReturn.Font = ugbShow.Font;
			btnReturn.Dock = DockStyle.Top;
			btnReturn.Click +=new EventHandler(btnShowReturn_Click);
			ugbShow.Controls.Add(btnReturn);

			iHeight += 100;

			string strSql = "select * from tbShow where cnnJobID="+job.cnnJobID.ToString()+" order by cnnShowID desc";
			DataTable dtShow = Helper.Query(strSql);
			foreach (DataRow drShow in dtShow.Rows)
			{
				Show show = new Show(drShow);
				string strSeatSql = "select cnvcSeat from tbShowSeat where cnnJobID="+job.cnnJobID.ToString()+" and cnvcFloor="+show.cnnShowID.ToString()+" and cnvcState is null and cnvcSeat is not null";
				DataTable dtSeat = Helper.Query(strSeatSql);
				if (dtSeat.Rows.Count > 0)
				{
				
					UltraButton btn = new UltraButton();
					btn.Name = "show"+show.cnnShowID;
					btn.Text = show.cnvcShowName;
					btn.Tag = show;
					btn.Height = 100;
					btn.Font = ugbJob.Font;
					btn.Dock = DockStyle.Top;
					btn.Click +=new EventHandler(btnShow_Click);
					ugbShow.Controls.Add(btn);

					iHeight += 100;
				}
			}
			this.ugbShow.Height = iHeight+100;
			this.ugbShow.Top = (this.Height-this.ugbShow.Height)/2;
			this.ugbShow.Left = (this.Width-this.ugbShow.Width)/2;

		}
		private void btnShowReturn_Click(object sender, System.EventArgs e)
		{
			//展厅返回
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl is UltraGroupBox)
				{
					ctrl.Visible = false;
				}
			}
			ugbJob.Visible = true;
		}
		private void btnShow_Click(object sender, System.EventArgs e)
		{
			//展厅座位显示
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl is UltraGroupBox)
				{
					ctrl.Visible = false;
				}
			}
			ugbInfoDisp.Visible = true;
			//ugbSignIn.Visible = true;
			UltraButton btn = (UltraButton)sender;
			Show show = (Show)btn.Tag;
			LoadPanel(show);
		}
		#endregion
		#region  会员卡签到
		private void btnSignIn_Click(object sender, System.EventArgs e)
		{
			//会员卡签到
			try
			{				
                //if (Form1.constApp.htMemberSeats.Contains(Form1.pMember.cnvcMemberRight))
                //{
                //    DataTable dtSeats = Helper.Query("select count(*) from tbMemberSeat where cnvcMemberCardNo='"+Form1.pMember.cnvcMemberCardNo+"' and cnvcState='"+ConstApp.Show_Seat_State_SignIn+"' and cnnID="+ms.cnnID.ToString());
                //    string strBookSeats = Form1.constApp.htMemberSeats[Form1.pMember.cnvcMemberRight].ToString();
                //    string strBookedSeats = dtSeats.Rows[0][0].ToString();
                //    if (strBookedSeats != ConstApp.Free_Time_NoLimit)
                //    {
                //        int iBookSeats = int.Parse(strBookSeats);
                //        int iBookedSeats = int.Parse(strBookedSeats);
                //        if (iBookedSeats >= iBookSeats)
                //        {
                //            throw new BusinessException("展位签到","已到限制展位数！");
                //        }
                //    }
                //}

				if (ms.cnvcSeat == "")
				{
					throw new BusinessException("展位签到","请选择展位");
				}

				ms.cnvcOperName = Form1.pMember.cnvcMemberCardNo;
				ms.cndOperDate = DateTime.Now;
				ms.cniSynch = 2;

				foreach (Control ctrl in this.Controls)
				{
					if (ctrl is Panel)
					{
						ctrl.Visible = false;
					}
				}	
				foreach (Control ctrl in this.Controls)
				{
					if (ctrl is UltraGroupBox)
					{
						ctrl.Visible = false;
					}
				}
				ugbInfoConfirm.Visible = true;
				this.ugbInfoConfirm.Top = (this.Height-this.ugbInfoConfirm.Height)/2;
				this.ugbInfoConfirm.Left = (this.Width-this.ugbInfoConfirm.Width)/2;
				this.lblJobName.Text = ms.cnvcJobName;
				this.lblSeat.Text = ms.cnvcSeat;
				this.lblMemberCardNo.Text = ms.cnvcMemberCardNo;
				this.lblMemberName.Text = ms.cnvcMemberName;
				this.lblPaperNo.Text = ms.cnvcPaperNo;

			}
			catch (BusinessException bex)
			{
				DispError(bex.Type+"："+bex.Message);
				//MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				DispError("信息提示："+ex.Message);
				//MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			
		}

		#endregion


		
        //private void App_Idle(ApplicationIdleTimer.ApplicationIdleEventArgs e)
        //{
        //    if (e.IdleDuration.TotalSeconds>30)
        //    {
        //        btnExit_Click(null,null);
        //    }
			
        //}
		private void DispError(string strError)
		{
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl is Panel)
				{
					ctrl.Visible = false;
				}
			}
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl is UltraGroupBox)
				{
					ctrl.Visible = false;
				}
			}
			this.ugbInfoTip.Top = (this.Height-this.ugbInfoTip.Height)/2;
			this.ugbInfoTip.Left = (this.Width-this.ugbInfoTip.Width)/2;
			this.ugbInfoTip.Visible = true;
			this.lblBookError.Text = strError;
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
						

			Form1.pMember = null;
			this.boxInfo.Visible = false;
			this.boxLogin.Visible = true;
			this.boxOper.Visible = false;
			this.txtMemberCardNo.Text = "";
			this.txtMemberPwd.Text = "";
			this.Close();
		}

		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			//签到
			try
			{			

				Member member = new Member(ms.ToTable());

				JobManage jobManage = new JobManage();
				//预订指定展位
				ms.cnvcState = ConstApp.Show_Seat_State_Booking;				
				jobManage.MemberSeatBooking(ms);
		
				TouchPrintedBill pBill = new TouchPrintedBill(ms.ToTable());				
				pBill.cnvcBillType = ConstApp.Bill_Type_SignIn;
				pBill.cnvcShow = ms.cnvcShowName;
				//pBill.cndEndDate = Form1.pMember.cndEndDate;
		
					
				PrintedBill bill = new PrintedBill(pBill.ToTable());
                Bill nbill = null;
				Member retMember = jobManage.MemberSeatSignIn(ms,bill,out nbill);
                pBill.cnnBalance = nbill.cnnBalance;
                pBill.cnnLastBalance = nbill.cnnLastBalance;
                pBill.cnnPrepay = nbill.cnnPrepay;
				//pBill.cnvcFreeLast = retMember.cnvcFree;
				pBill.cnvcSeat = retMember.cnvcSales;

				Helper.PrintTouchTicket(pBill);
				this.lblPrintTip.Visible = true;
				this.ultraButton1.Visible = false;
				this.ultraButton3.Visible = false;
				this.lblPrintTip.Text = "签到成功，请在刷卡器下面取签到小票，再到四号窗口领取参会资料！";
				this.timer1.Interval = 1000;
				this.timer1.Start();
			}
			catch (BusinessException bex)
			{
				DispError(bex.Type+"："+bex.Message);
				//MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				DispError("信息提示："+ex.Message);
				//MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}		
		}

		private void ultraButton3_Click(object sender, System.EventArgs e)
		{
			//签到返回
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl is Panel)
				{
					ctrl.Visible = true;
				}
			}	
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl is UltraGroupBox)
				{
					ctrl.Visible = false;
				}
			}
			this.ugbInfoDisp.Visible = true;
			this.ultraLabel8.Visible = true;
			this.lblSelectedSeat.Text = "";
			ms.cnvcSeat = "";
			this.ugbSignIn.Visible = true;
			btnSignIn.Visible = false;
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			//错误信息返回
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl is Panel)
				{
					ctrl.Visible = false;
				}
			}	
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl is UltraGroupBox)
				{
					ctrl.Visible = false;
				}
			}			
			this.lblSelectedSeat.Text = "";
			ms.cnvcSeat = "";
			ms.cnvcFloor = "";
			ms.cnvcShowName = "";
			this.ugbShow.Visible = true;
		}

		private void btnSelectLogin_Click(object sender, System.EventArgs e)
		{
			//返回主菜单
			this.Close();
		}

		private void btnSelectShow_Click(object sender, System.EventArgs e)
		{
			//选择展厅
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl is Panel)
				{
					ctrl.Visible = false;
				}
			}	
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl is UltraGroupBox)
				{
					ctrl.Visible = false;
				}
			}
			this.ugbShow.Visible = true;
		}

		private int iCount = 0;
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if (iCount < 5)
			{			
				this.lblPrintTip.Text = "签到成功，请在刷卡器下面取签到小票，再到四号窗口领取参会资料！"+(5-iCount)+"秒后自动退出";
				iCount ++;
			}
			else
			{
				this.timer1.Stop();
				btnExit_Click(null,null);
			}
		}

		
	}
}
