using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Infragistics.Win.AppStyling;
using System.Reflection;
using System.IO;
//using MemberManage;
//using MemberManage.Business;
//using MemberManage.Print;
//using ynhrMemberManage.MemberManage.Common;
using ynhrMemberManage.ORM;
using ynhrMemberManage.CardCommon;
using ynhrMemberManage.CardCommon.CardDef;
using ynhrMemberManage.CardCommon.CardRef;
using System.Threading;
using ynhrMemberManage.Common;
using ynhrMemberManage.Domain;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Print;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace TouchHold
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : frmBase
    {
        #region 字段
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberPwd;
		private Infragistics.Win.Misc.UltraButton btnLogin;
		private Infragistics.Win.Misc.UltraButton btnIntro;
		public static ConstApp constApp = new ConstApp();
		public static Member pMember = null;
		private Infragistics.Win.Misc.UltraButton btnBooking;
		private Infragistics.Win.Misc.UltraButton btnSignIn;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
		private ShowBooking booking ;//new ShowBooking(ultraGroupBox2,ultraGroupBox3,txtMemberCardNo,txtMemberPwd);
		private ShowSignIn signIn ;//= new ShowSignIn(ultraGroupBox2,ultraGroupBox3,txtMemberCardNo,txtMemberPwd);
        private TouchOne.ShowBooking bookingOn;
        private TouchOne.ShowSignIn signInOn;
		private QueryInfo queryInfo;
        private TouchOne.QueryInfo queryInfo2;
		private ChangePwd changePwd;
		//private BusinessIntro bi = new BusinessIntro();
		private Infragistics.Win.Misc.UltraButton btnQuit;

		private Infragistics.Win.UltraWinEditors.UltraTextEditor textBox;
		private Thread oThread;
		private Thread dThread;
		private DocExplorer doc = new DocExplorer();
		private vodExplorer vod = new vodExplorer();
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
		private Infragistics.Win.Misc.UltraButton btnJobQuery;
		private Infragistics.Win.Misc.UltraButton btnVod;
		private Infragistics.Win.Misc.UltraButton btnChangePwd;
		private Infragistics.Win.Misc.UltraButton btnQueryInfo;
		private Infragistics.Win.Misc.UltraLabel lblError;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox5;
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
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private MemberSeat ms = null;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;
        private BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer2;
		//ApplicationIdleTimer idle = null;
//		private System.Timers.Timer _timer; 
//		private System.DateTime lastAppIdleTime;
        //		private bool isIdle;
        #endregion
        public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();	
            //idle = new ApplicationIdleTimer();
            //System.Windows.Forms.Application.AddMessageFilter(idle);
            
            //idle.ApplicationIdle += new ApplicationIdleTimer.ApplicationIdleEventHandler(this.App_Idle);

            //SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
		}

        //void Application_Idle(object sender, EventArgs e)
        //{
        //    //throw new Exception("The method or operation is not implemented.");
            
        //}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
            if (oThread != null)
            {
                if (oThread.IsAlive)
                {
                    oThread.Abort();
                }
                if (dThread.IsAlive)
                {
                    dThread.Abort();
                }
            }
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.btnIntro = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnVod = new Infragistics.Win.Misc.UltraButton();
            this.btnJobQuery = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
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
            this.btnLogin = new Infragistics.Win.Misc.UltraButton();
            this.txtMemberPwd = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.btnBooking = new Infragistics.Win.Misc.UltraButton();
            this.btnSignIn = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnQueryInfo = new Infragistics.Win.Misc.UltraButton();
            this.btnChangePwd = new Infragistics.Win.Misc.UltraButton();
            this.btnQuit = new Infragistics.Win.Misc.UltraButton();
            this.lblError = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox5 = new Infragistics.Win.Misc.UltraGroupBox();
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
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).BeginInit();
            this.ultraGroupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIntro
            // 
            this.btnIntro.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIntro.Location = new System.Drawing.Point(8, 16);
            this.btnIntro.Name = "btnIntro";
            this.btnIntro.Size = new System.Drawing.Size(104, 48);
            this.btnIntro.TabIndex = 0;
            this.btnIntro.Text = "业务介绍";
            this.btnIntro.Click += new System.EventHandler(this.btnIntro_Click);
            // 
            // ultraGroupBox1
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.Controls.Add(this.btnVod);
            this.ultraGroupBox1.Controls.Add(this.btnJobQuery);
            this.ultraGroupBox1.Controls.Add(this.btnIntro);
            this.ultraGroupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraGroupBox1.Location = new System.Drawing.Point(24, 16);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(376, 80);
            this.ultraGroupBox1.TabIndex = 1;
            // 
            // btnVod
            // 
            this.btnVod.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVod.Location = new System.Drawing.Point(128, 16);
            this.btnVod.Name = "btnVod";
            this.btnVod.Size = new System.Drawing.Size(104, 48);
            this.btnVod.TabIndex = 2;
            this.btnVod.Text = "业务视频";
            this.btnVod.Click += new System.EventHandler(this.btnVod_Click);
            // 
            // btnJobQuery
            // 
            this.btnJobQuery.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJobQuery.Location = new System.Drawing.Point(248, 16);
            this.btnJobQuery.Name = "btnJobQuery";
            this.btnJobQuery.Size = new System.Drawing.Size(120, 48);
            this.btnJobQuery.TabIndex = 1;
            this.btnJobQuery.Text = "招聘会查询";
            this.btnJobQuery.Click += new System.EventHandler(this.btnJobQuery_Click);
            // 
            // ultraGroupBox2
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox2.Appearance = appearance2;
            this.ultraGroupBox2.Controls.Add(this.btnBackSpace);
            this.ultraGroupBox2.Controls.Add(this.btnCancel);
            this.ultraGroupBox2.Controls.Add(this.btnNumber0);
            this.ultraGroupBox2.Controls.Add(this.btnNumber9);
            this.ultraGroupBox2.Controls.Add(this.btnNumber8);
            this.ultraGroupBox2.Controls.Add(this.btnNumber7);
            this.ultraGroupBox2.Controls.Add(this.btnNumber6);
            this.ultraGroupBox2.Controls.Add(this.btnNumber15);
            this.ultraGroupBox2.Controls.Add(this.btnNumber4);
            this.ultraGroupBox2.Controls.Add(this.btnNumber13);
            this.ultraGroupBox2.Controls.Add(this.btnNumber2);
            this.ultraGroupBox2.Controls.Add(this.btnNumber1);
            this.ultraGroupBox2.Controls.Add(this.btnLogin);
            this.ultraGroupBox2.Controls.Add(this.txtMemberPwd);
            this.ultraGroupBox2.Controls.Add(this.txtMemberCardNo);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            appearance5.ForeColor = System.Drawing.Color.White;
            this.ultraGroupBox2.HeaderAppearance = appearance5;
            this.ultraGroupBox2.Location = new System.Drawing.Point(24, 104);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(376, 400);
            this.ultraGroupBox2.TabIndex = 2;
            this.ultraGroupBox2.Text = "会员请刷卡登录";
            this.ultraGroupBox2.UseAppStyling = false;
            // 
            // btnBackSpace
            // 
            this.btnBackSpace.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBackSpace.Location = new System.Drawing.Point(240, 344);
            this.btnBackSpace.Name = "btnBackSpace";
            this.btnBackSpace.Size = new System.Drawing.Size(65, 48);
            this.btnBackSpace.TabIndex = 23;
            this.btnBackSpace.Text = "←";
            this.btnBackSpace.Click += new System.EventHandler(this.btnBackSpace_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(152, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 48);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNumber0
            // 
            this.btnNumber0.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber0.Location = new System.Drawing.Point(64, 344);
            this.btnNumber0.Name = "btnNumber0";
            this.btnNumber0.Size = new System.Drawing.Size(65, 48);
            this.btnNumber0.TabIndex = 21;
            this.btnNumber0.Text = "0";
            this.btnNumber0.Click += new System.EventHandler(this.btnNumber0_Click);
            // 
            // btnNumber9
            // 
            this.btnNumber9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber9.Location = new System.Drawing.Point(240, 280);
            this.btnNumber9.Name = "btnNumber9";
            this.btnNumber9.Size = new System.Drawing.Size(65, 48);
            this.btnNumber9.TabIndex = 20;
            this.btnNumber9.Text = "9";
            this.btnNumber9.Click += new System.EventHandler(this.btnNumber9_Click);
            // 
            // btnNumber8
            // 
            this.btnNumber8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber8.Location = new System.Drawing.Point(151, 280);
            this.btnNumber8.Name = "btnNumber8";
            this.btnNumber8.Size = new System.Drawing.Size(65, 48);
            this.btnNumber8.TabIndex = 19;
            this.btnNumber8.Text = "8";
            this.btnNumber8.Click += new System.EventHandler(this.btnNumber8_Click);
            // 
            // btnNumber7
            // 
            this.btnNumber7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber7.Location = new System.Drawing.Point(64, 280);
            this.btnNumber7.Name = "btnNumber7";
            this.btnNumber7.Size = new System.Drawing.Size(65, 48);
            this.btnNumber7.TabIndex = 18;
            this.btnNumber7.Text = "7";
            this.btnNumber7.Click += new System.EventHandler(this.btnNumber7_Click);
            // 
            // btnNumber6
            // 
            this.btnNumber6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber6.Location = new System.Drawing.Point(240, 216);
            this.btnNumber6.Name = "btnNumber6";
            this.btnNumber6.Size = new System.Drawing.Size(65, 48);
            this.btnNumber6.TabIndex = 17;
            this.btnNumber6.Text = "6";
            this.btnNumber6.Click += new System.EventHandler(this.btnNumber6_Click);
            // 
            // btnNumber15
            // 
            this.btnNumber15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber15.Location = new System.Drawing.Point(151, 216);
            this.btnNumber15.Name = "btnNumber15";
            this.btnNumber15.Size = new System.Drawing.Size(65, 48);
            this.btnNumber15.TabIndex = 16;
            this.btnNumber15.Text = "5";
            this.btnNumber15.Click += new System.EventHandler(this.btnNumber15_Click);
            // 
            // btnNumber4
            // 
            this.btnNumber4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber4.Location = new System.Drawing.Point(64, 216);
            this.btnNumber4.Name = "btnNumber4";
            this.btnNumber4.Size = new System.Drawing.Size(65, 48);
            this.btnNumber4.TabIndex = 15;
            this.btnNumber4.Text = "4";
            this.btnNumber4.Click += new System.EventHandler(this.btnNumber4_Click);
            // 
            // btnNumber13
            // 
            this.btnNumber13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber13.Location = new System.Drawing.Point(240, 152);
            this.btnNumber13.Name = "btnNumber13";
            this.btnNumber13.Size = new System.Drawing.Size(65, 48);
            this.btnNumber13.TabIndex = 14;
            this.btnNumber13.Text = "3";
            this.btnNumber13.Click += new System.EventHandler(this.btnNumber13_Click);
            // 
            // btnNumber2
            // 
            this.btnNumber2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber2.Location = new System.Drawing.Point(151, 152);
            this.btnNumber2.Name = "btnNumber2";
            this.btnNumber2.Size = new System.Drawing.Size(65, 48);
            this.btnNumber2.TabIndex = 13;
            this.btnNumber2.Text = "2";
            this.btnNumber2.Click += new System.EventHandler(this.btnNumber2_Click);
            // 
            // btnNumber1
            // 
            this.btnNumber1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNumber1.Location = new System.Drawing.Point(64, 152);
            this.btnNumber1.Name = "btnNumber1";
            this.btnNumber1.Size = new System.Drawing.Size(65, 48);
            this.btnNumber1.TabIndex = 12;
            this.btnNumber1.Text = "1";
            this.btnNumber1.Click += new System.EventHandler(this.btnNumber1_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(96, 96);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(176, 48);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtMemberPwd
            // 
            this.txtMemberPwd.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMemberPwd.Location = new System.Drawing.Point(136, 64);
            this.txtMemberPwd.Name = "txtMemberPwd";
            this.txtMemberPwd.PasswordChar = '*';
            this.txtMemberPwd.Size = new System.Drawing.Size(176, 30);
            this.txtMemberPwd.TabIndex = 3;
            this.txtMemberPwd.Enter += new System.EventHandler(this.txtMemberPwd_Enter);
            // 
            // txtMemberCardNo
            // 
            this.txtMemberCardNo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMemberCardNo.Location = new System.Drawing.Point(136, 24);
            this.txtMemberCardNo.MaxLength = 8;
            this.txtMemberCardNo.Name = "txtMemberCardNo";
            this.txtMemberCardNo.Size = new System.Drawing.Size(176, 30);
            this.txtMemberCardNo.TabIndex = 2;
            this.txtMemberCardNo.Enter += new System.EventHandler(this.txtMemberCardNo_Enter);
            // 
            // ultraLabel2
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.ForeColor = System.Drawing.Color.White;
            this.ultraLabel2.Appearance = appearance3;
            this.ultraLabel2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraLabel2.Location = new System.Drawing.Point(32, 64);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 1;
            this.ultraLabel2.Text = "会员密码：";
            this.ultraLabel2.UseAppStyling = false;
            // 
            // ultraLabel1
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.ForeColor = System.Drawing.Color.White;
            this.ultraLabel1.Appearance = appearance4;
            this.ultraLabel1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraLabel1.Location = new System.Drawing.Point(32, 32);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "会员卡号：";
            this.ultraLabel1.UseAppStyling = false;
            // 
            // btnBooking
            // 
            this.btnBooking.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBooking.Location = new System.Drawing.Point(104, 40);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Size = new System.Drawing.Size(176, 48);
            this.btnBooking.TabIndex = 5;
            this.btnBooking.Text = "预订";
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSignIn.Location = new System.Drawing.Point(104, 88);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(176, 48);
            this.btnSignIn.TabIndex = 6;
            this.btnSignIn.Text = "签到";
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // ultraGroupBox3
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox3.Appearance = appearance6;
            this.ultraGroupBox3.Controls.Add(this.btnQueryInfo);
            this.ultraGroupBox3.Controls.Add(this.btnChangePwd);
            this.ultraGroupBox3.Controls.Add(this.btnQuit);
            this.ultraGroupBox3.Controls.Add(this.btnBooking);
            this.ultraGroupBox3.Controls.Add(this.btnSignIn);
            this.ultraGroupBox3.Location = new System.Drawing.Point(424, 24);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(376, 312);
            this.ultraGroupBox3.TabIndex = 7;
            // 
            // btnQueryInfo
            // 
            this.btnQueryInfo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQueryInfo.Location = new System.Drawing.Point(104, 136);
            this.btnQueryInfo.Name = "btnQueryInfo";
            this.btnQueryInfo.Size = new System.Drawing.Size(176, 48);
            this.btnQueryInfo.TabIndex = 9;
            this.btnQueryInfo.Text = "会员信息查询";
            this.btnQueryInfo.Click += new System.EventHandler(this.btnQueryInfo_Click);
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChangePwd.Location = new System.Drawing.Point(104, 184);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(176, 48);
            this.btnChangePwd.TabIndex = 8;
            this.btnChangePwd.Text = "修改密码";
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Location = new System.Drawing.Point(104, 232);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(176, 48);
            this.btnQuit.TabIndex = 7;
            this.btnQuit.Text = "退出";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblError.Location = new System.Drawing.Point(424, 344);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(376, 72);
            this.lblError.TabIndex = 8;
            // 
            // ultraGroupBox5
            // 
            this.ultraGroupBox5.Controls.Add(this.lblPrintTip);
            this.ultraGroupBox5.Controls.Add(this.lblPaperNo);
            this.ultraGroupBox5.Controls.Add(this.ultraLabel9);
            this.ultraGroupBox5.Controls.Add(this.ultraButton3);
            this.ultraGroupBox5.Controls.Add(this.ultraButton1);
            this.ultraGroupBox5.Controls.Add(this.lblMemberName);
            this.ultraGroupBox5.Controls.Add(this.lblMemberCardNo);
            this.ultraGroupBox5.Controls.Add(this.lblSeat);
            this.ultraGroupBox5.Controls.Add(this.lblJobName);
            this.ultraGroupBox5.Controls.Add(this.ultraLabel6);
            this.ultraGroupBox5.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox5.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox5.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraGroupBox5.Location = new System.Drawing.Point(416, 424);
            this.ultraGroupBox5.Name = "ultraGroupBox5";
            this.ultraGroupBox5.Size = new System.Drawing.Size(552, 320);
            this.ultraGroupBox5.TabIndex = 19;
            this.ultraGroupBox5.Text = "展位签到信息确认";
            // 
            // lblPrintTip
            // 
            this.lblPrintTip.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrintTip.Location = new System.Drawing.Point(16, 200);
            this.lblPrintTip.Name = "lblPrintTip";
            this.lblPrintTip.Size = new System.Drawing.Size(528, 64);
            this.lblPrintTip.TabIndex = 12;
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
            this.ultraButton3.Location = new System.Drawing.Point(280, 280);
            this.ultraButton3.Name = "ultraButton3";
            this.ultraButton3.Size = new System.Drawing.Size(120, 40);
            this.ultraButton3.TabIndex = 9;
            this.ultraButton3.Text = "返回";
            this.ultraButton3.Click += new System.EventHandler(this.ultraButton3_Click);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(120, 280);
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
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(16, 32);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(144, 23);
            this.ultraLabel3.TabIndex = 0;
            this.ultraLabel3.Text = "招聘会：";
            // 
            // ultraLabel7
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.ForeColor = System.Drawing.Color.White;
            this.ultraLabel7.Appearance = appearance7;
            this.ultraLabel7.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraLabel7.Location = new System.Drawing.Point(8, 568);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(600, 40);
            this.ultraLabel7.TabIndex = 20;
            this.ultraLabel7.Text = "云南人才市场会员单位自助服务";
            this.ultraLabel7.UseAppStyling = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.ControlBox = false;
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.ultraGroupBox5);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.ultraGroupBox3);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Closed += new System.EventHandler(this.Form1_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).EndInit();
            this.ultraGroupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Assembly   asm   =   Assembly.GetExecutingAssembly();  
			Stream  styleStream = asm.GetManifestResourceStream("TouchHold.Template_Vista.isl");
			StyleManager.Load(styleStream,true);			  
			Application.Run(new Form1());
		}
        
		private void Form1_Load(object sender, System.EventArgs e)
		{
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

            CheckForIllegalCrossThreadCalls = false;
			pMember = null;
			//constApp.LoadPara();
            ynhrMemberManage.BusinessFacade.SysInit.LoadPara(constApp);
			//this.FormBorderStyle=FormBorderStyle.None;
			//this.WindowState= FormWindowState.Maximized;
			//this.TopMost = true;
			this.ultraLabel7.Left = (this.Width-this.ultraLabel7.Width)/2;
			this.ultraLabel7.Top = 50;
			this.ultraGroupBox1.Left = (this.Width-this.ultraGroupBox1.Width)/2;
			this.ultraGroupBox1.Top = 100;//this.Height-this.ultraGroupBox1.Height;
			this.ultraGroupBox2.Left = (this.Width-this.ultraGroupBox2.Width)/2;
			this.ultraGroupBox2.Top = 120+this.ultraGroupBox1.Height;

			this.ultraGroupBox3.Left = (this.Width-this.ultraGroupBox3.Width)/2;
			this.ultraGroupBox3.Top = 120+this.ultraGroupBox1.Height;

			this.lblError.Left = (this.Width-this.lblError.Width)/2;
			this.lblError.Top = 120+this.ultraGroupBox1.Height+this.ultraGroupBox2.Height;

			//			this.btnBooking.Left = (this.Width-this.btnBooking.Width)/2;
			//			this.btnBooking.Top = this.Height/2+10;
			//
			//			this.btnSignIn.Left = (this.Width-this.btnSignIn.Width)/2;
			//			this.btnSignIn.Top = this.Height/2+10;

			this.ultraGroupBox3.Visible = false;
			this.btnBooking.Visible = false;
			this.btnSignIn.Visible = false;
			this.lblError.Visible = false;

			this.ultraGroupBox5.Visible = false;
			this.ultraGroupBox5.Top = (this.Height-this.ultraGroupBox5.Height)/2;
			this.ultraGroupBox5.Left = (this.Width-this.ultraGroupBox5.Width)/2;

            //this.SetBackgroundImg();
			oThread = new Thread(new ThreadStart(BrushCard));
			oThread.Start();	
			
			dThread = new Thread(new ThreadStart(DispInto));
			dThread.Start();

            this.timer2.Interval = 1000;
            this.timer2.Start();	
		}
        //[System.Runtime.InteropServices.DllImport("user32")]  
        //private  static  extern  int  mouse_event(int  dwFlags,int  dx,int  dy,  int  cButtons,  int  dwExtraInfo);  
        //const  int  MOUSEEVENTF_MOVE  =  0x0001;  

        //private void App_Idle(ApplicationIdleTimer.ApplicationIdleEventArgs e)
        //{
			
        //    if (e.IdleDuration.TotalSeconds>10&& Form1.ActiveForm.Name == "Form1")
        //    {
				
        //        btnQuit_Click(null,null);
        //        //idle.LastAppIdleTime = DateTime.Now;
        //    }
			
        //}

		public void DispInto()
		{
			while (true)
			{
				try
				{
					//constApp.LoadPara();
                    SysInit.LoadPara(constApp);
					string strSql = "select cnnJobID from tbJob where cndBeginDate<getdate() and cndEndDate>getdate()";
					DataTable dtJob = Helper.Query(strSql);

					if (dtJob.Rows.Count > 0)
					{
						this.ultraGroupBox1.Visible = false;
					}
					else
					{
						this.ultraGroupBox1.Visible = true;
					}
				}
				catch (Exception)
				{
					
				}
				finally
				{
					GC.Collect();
					int iFlash = Form1.constApp.iTouchFlash;
					
					System.Threading.Thread.Sleep(1000*60*iFlash);//1000*60*60);
				}
			}
		}
		public void BrushCard()
		{
			while (true)
			{
				//刷卡
				try
				{
                    this.timer2.Stop();
					//读取会员卡号
					CardM1 m1=new CardM1();
					string strCardNo = "";
					string strRet = m1.ReadCard(out strCardNo);
					//idle.ApplicationIdle -= new ApplicationIdleTimer.ApplicationIdleEventHandler(this.App_Idle);
						
					if (strCardNo != "")
					{
						//idle.ApplicationIdle -= new ApplicationIdleTimer.ApplicationIdleEventHandler(this.App_Idle);
						
						txtMemberCardNo.Text = strCardNo;	
						txtMemberPwd.Text = "";
						//txtMemberPwd.Focus();
						textBox = txtMemberPwd;
						if (pMember != null)
						{
                            if (pMember.cnvcMemberCardNo != strCardNo)
                            {
                                //idle.LastAppIdleTime = DateTime.Now;
                                //switch (constApp.strCardType)
                                //{
                                //    case "l8":
                                if (booking != null)
                                {
                                    if (!booking.IsDisposed)
                                    {
                                        ultraGroupBox2.Visible = true;
                                        ultraGroupBox3.Visible = false;
                                        txtMemberPwd.Text = "";
                                        booking.Close();
                                    }
                                }
                                if (signIn != null)
                                {
                                    if (!signIn.IsDisposed)
                                    {
                                        ultraGroupBox2.Visible = true;
                                        ultraGroupBox3.Visible = false;
                                        txtMemberPwd.Text = "";
                                        signIn.Close();
                                    }
                                }
                                //    break;
                                //case "l6":
                                if (bookingOn != null)
                                {
                                    if (!this.bookingOn.IsDisposed)
                                    {
                                        ultraGroupBox2.Visible = true;
                                        ultraGroupBox3.Visible = false;
                                        txtMemberPwd.Text = "";
                                        bookingOn.Close();
                                    }
                                }
                                if (signInOn != null)
                                {
                                    if (!this.signInOn.IsDisposed)
                                    {
                                        ultraGroupBox2.Visible = true;
                                        ultraGroupBox3.Visible = false;
                                        txtMemberPwd.Text = "";
                                        signInOn.Close();
                                    }
                                }
                                //        break;
                                //}
                                if (doc != null)
                                {
                                    if (!doc.IsDisposed)
                                    {
                                        doc.Close();
                                    }
                                }
                                if (vod != null)
                                {
                                    if (!vod.IsDisposed)
                                    {
                                        vod.Close();
                                    }
                                }
                                pMember = null;
                                CardLogin(strCardNo);

                            }
						}
						else
						{
							//idle.LastAppIdleTime = DateTime.Now;
							CardLogin(strCardNo);
						}
						//idle.ApplicationIdle += new ApplicationIdleTimer.ApplicationIdleEventHandler(this.App_Idle);
						
					}
					//idle.ApplicationIdle += new ApplicationIdleTimer.ApplicationIdleEventHandler(this.App_Idle);
                    this.timer2.Start();	
				
				}
				catch (System.Exception ex)
				{
                    this.lblError.Visible = true;
                    this.lblError.Text = "信息提示：" + ex.Message;
                    //this.backgroundWorker1.RunWorkerAsync(ex);
				}
				finally
				{
					GC.Collect();
					System.Threading.Thread.Sleep(1000);//5*1000*60);
				}
			}
		}

		private void btnIntro_Click(object sender, System.EventArgs e)
		{
			if (doc.IsDisposed)
			{
				//bi = new BusinessIntro();
				//bi.Show();
				doc = new DocExplorer();
				doc.strPath = System.Configuration.ConfigurationManager.AppSettings["FilePath"];//selectedNode.Tag.ToString();
                doc.strName = System.Configuration.ConfigurationManager.AppSettings["FileName"];//selectedNode.Text.Substring(0,selectedNode.Text.IndexOf("."));
				doc.Show();
			}
			else
			{
				//bi.Show();
                doc.strPath = System.Configuration.ConfigurationManager.AppSettings["FilePath"];//selectedNode.Tag.ToString();
                doc.strName = System.Configuration.ConfigurationManager.AppSettings["FileName"];//selectedNode.Text.Substring(0,selectedNode.Text.IndexOf("."));
				doc.Show();
			}
			
		}

		private void CardLogin(string strCardNo)
		{
			//登录
			try
			{
				queryInfo = new QueryInfo();
                queryInfo2 = new TouchHold.TouchOne.QueryInfo();
				changePwd = new ChangePwd(ultraGroupBox1,ultraGroupBox2,ultraGroupBox3,txtMemberCardNo,txtMemberPwd,lblError);
				DataTable dtMember = Helper.Query("select * from tbMember where cnvcMemberCardNo = '"+strCardNo+"'");
				if (dtMember.Rows.Count == 0)
				{
					this.txtMemberCardNo.Text="";
					this.txtMemberPwd.Text="";
					this.txtMemberCardNo.Focus();
					throw new BusinessException("登录错误","会员不存在！");
				}

				Member member = new Member(dtMember);
				if (DateTime.Now > DateTime.Parse(member.cndEndDate))
				{
					throw new BusinessException("登录错误","会员过期！");
				}
				//idle.LastAppIdleTime = DateTime.Now;
				pMember = member;

                constApp.strCardType = strCardNo.Length == 6 ? "l6" : "l8";

				LoginJobJudge();
			}
			catch (BusinessException bex)
			{
				this.lblError.Visible = true;
				this.lblError.Text = bex.Type+"："+bex.Message;
				//MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				this.lblError.Visible = true;
				this.lblError.Text = "信息提示："+ex.Message;
				//MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		private void btnLogin_Click(object sender, System.EventArgs e)
		{
			//登录
			try
			{
				queryInfo = new QueryInfo();
                queryInfo2 = new TouchHold.TouchOne.QueryInfo();
				changePwd = new ChangePwd(ultraGroupBox1,ultraGroupBox2,ultraGroupBox3,txtMemberCardNo,txtMemberPwd,lblError);
				string strCardNo = txtMemberCardNo.Text;
				string strPwd = txtMemberPwd.Text;
				if (strCardNo.Length == 0 || strPwd.Length == 0)
				{
					this.txtMemberCardNo.Text="";
					this.txtMemberPwd.Text="";
					this.txtMemberCardNo.Focus();
					throw new BusinessException("登录错误","请重新输入卡号或密码！");
				}
				DataTable dtMember = Helper.Query("select * from tbMember where cnvcMemberCardNo = '"+strCardNo+"'");
				if (dtMember.Rows.Count == 0)
				{
					this.txtMemberCardNo.Text="";
					this.txtMemberPwd.Text="";
					this.txtMemberCardNo.Focus();
					throw new BusinessException("登录错误","会员不存在！");
				}
				Member member = new Member(dtMember);
				if (member.cnvcMemberPwd != strPwd)
				{
					this.txtMemberPwd.Text="";
					this.txtMemberPwd.Focus();
					throw new BusinessException("登录错误","密码错误！请核对后重新输入！");
				}
				//Member member = new Member(dtMember);
				if (DateTime.Now > DateTime.Parse(member.cndEndDate))
				{
					throw new BusinessException("登录错误","会员过期！");
				}
				//idle.LastAppIdleTime = DateTime.Now;
				pMember = member;

                constApp.strCardType = strCardNo.Length == 6 ? "l6" : "l8";
				LoginJobJudge();

				lblError.Visible = false;
				
			}
			catch (BusinessException bex)
			{
				this.lblError.Visible = true;
				this.lblError.Text = bex.Type+"："+bex.Message;
				//MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				this.lblError.Visible = true;
				this.lblError.Text = "信息提示："+ex.Message;
				//MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

		}
		private void LoginJobJudge()
		{
			bool bSignIn = false;
			bool bBooking = false;
            DataTable dtJob = Helper.Query("select * from tbJob where GETDATE() between cndBeginDate and cndEndDate");
			//有签到招聘会
			if (dtJob.Rows.Count > 0)
			{
				string strSignBeginDate = Form1.constApp.dTouchSignInBeginDate;				
				string strSignEndDate = Form1.constApp.dTouchSignInEndDate;
				if (strSignBeginDate != "")
				{
					string[] strSignBeginDates = strSignBeginDate.Split(':');
					int iSignInBeginHour = int.Parse(strSignBeginDates[0]);
					int iSignInBeginMinute = int.Parse(strSignBeginDates[1]);
					TimeSpan tsSignInBegin = new TimeSpan(iSignInBeginHour,iSignInBeginMinute,0);
					if (DateTime.Now.TimeOfDay > tsSignInBegin)
					{
						if (strSignEndDate != "")
						{
						
							string[] strSignEndDates = strSignEndDate.Split(':');
							int iSignInEndHour = int.Parse(strSignEndDates[0]);
							int iSignInEndMinute = int.Parse(strSignEndDates[1]);
							TimeSpan tsSignInEnd = new TimeSpan(iSignInEndHour,iSignInEndMinute,0);
							if (DateTime.Now.TimeOfDay < tsSignInEnd)
							{
								bSignIn = true;
							}							
						}
						else
						{
							bSignIn = true;
						}
					}					
				}	
				else
				{
					bSignIn = true;
				}
			}
            //else
            //{
				//有预订招聘会
            DataTable dtBookJob = Helper.Query("select * from tbJob where GETDATE() between cndBookBeginDate and cndBookEndDate");
				if (dtBookJob.Rows.Count > 0)
				{
					string strBookBeginDate = Form1.constApp.dTouchBookBeginDate;
					string strBookEndDate = Form1.constApp.dTouchBookEndDate;
					if (strBookBeginDate != "")
					{
						string[] strBookBeginDates = strBookBeginDate.Split(':');
						int iBookBeginHour = int.Parse(strBookBeginDates[0]);
						int iBookBeginMinute = int.Parse(strBookBeginDates[1]);
						TimeSpan tsBegin = new TimeSpan(iBookBeginHour,iBookBeginMinute,0);
						if (DateTime.Now.TimeOfDay > tsBegin)
						{
							if (strBookEndDate != "")
							{						
								string[] strBookEndDates = strBookEndDate.Split(':');
								int iBookEndHour = int.Parse(strBookEndDates[0]);
								int iBookEndMinute = int.Parse(strBookEndDates[1]);
								TimeSpan tsEnd = new TimeSpan(iBookEndHour,iBookEndMinute,0);
								if (DateTime.Now.TimeOfDay < tsEnd)
								{
									bBooking = true;
								}
							}
							else
							{
								bBooking = true;
							}
						}
					}
					else
					{
						bBooking = true;
					}
				}
			//}
                btnSignIn.Visible = false;
                btnBooking.Visible = false;
			if (bSignIn)
			{
				signIn = new ShowSignIn(ultraGroupBox1,ultraGroupBox2,ultraGroupBox3,txtMemberCardNo,txtMemberPwd);
                this.signInOn = new TouchHold.TouchOne.ShowSignIn(ultraGroupBox1, ultraGroupBox2, ultraGroupBox3, txtMemberCardNo, txtMemberPwd);
				//					signIn.Show();
				this.ultraGroupBox1.Visible = false;
				this.ultraGroupBox3.Visible = true;
				this.btnQueryInfo.Visible = false;
				btnSignIn.Visible = true;
				
				ultraGroupBox2.Visible = false;
			}
			if (bBooking)
			{
				booking = new ShowBooking(ultraGroupBox2,ultraGroupBox3,txtMemberCardNo,txtMemberPwd);
                this.bookingOn = new TouchHold.TouchOne.ShowBooking(ultraGroupBox2, ultraGroupBox3, txtMemberCardNo, txtMemberPwd);
				//						booking.Show();
				this.ultraGroupBox1.Visible = true;
				this.ultraGroupBox3.Visible = true;
				this.btnChangePwd.Visible = true;
				this.btnQueryInfo.Visible = true;
				btnBooking.Visible = true;
				
				ultraGroupBox2.Visible = false;
			}
			if(!bSignIn && !bBooking)
			{
				this.ultraGroupBox1.Visible = true;
				this.ultraGroupBox2.Visible = false;
				this.ultraGroupBox3.Visible = true;
				this.btnQueryInfo.Visible = true;
				this.btnSignIn.Visible = false;
				this.btnBooking.Visible = false;
				this.txtMemberCardNo.Text="";
				this.txtMemberPwd.Text="";
				//this.ultraGroupBox3.Visible = false;
				
				this.ultraGroupBox2.Focus();
				throw new BusinessException("系统提示","现在没有招聘会预订和签到！");
			}
			//控制鼠标移动
			//idle.LastAppIdleTime = DateTime.Now;
			
		}
		private void btnBooking_Click(object sender, System.EventArgs e)
		{
            switch (constApp.strCardType)
            {
                case "l8":
                    if (booking.IsDisposed)
                    {
                        booking = new ShowBooking(ultraGroupBox2, ultraGroupBox3, txtMemberCardNo, txtMemberPwd);
                        booking.Show();
                    }
                    else
                    {
                        booking.Show();
                    }
                    break;
                case "l6":
                    if (bookingOn.IsDisposed)
                    {
                        bookingOn = new TouchOne.ShowBooking(ultraGroupBox2, ultraGroupBox3, txtMemberCardNo, txtMemberPwd);
                        bookingOn.Show();
                    }
                    else
                    {
                        bookingOn.Show();
                    }
                    break;
            }
			
		}
		private void SignIn()
		{
			try
			{
				if (null == ms)
				{
					throw new BusinessException("展位签到","无正在进行招聘会");
				}

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

				ms.cndOperDate = DateTime.Now;
                switch (constApp.strCardType)
                {
                    case "l8":
                        JobManage jobManage = new JobManage();

                        TouchPrintedBill pBill = new TouchPrintedBill(ms.ToTable());
                        pBill.cnvcBillType = ConstApp.Bill_Type_SignIn;
                        pBill.cnvcShow = ms.cnvcShowName;
                        pBill.cndEndDate = pMember.cndEndDate;

                        PrintedBill bill = new PrintedBill(pBill.ToTable());
                        Member retMember = jobManage.MemberSeatSignIn(ms, bill);
                        pBill.cnvcFreeLast = retMember.cnvcFree;
                        pBill.cnvcSeat = retMember.cnvcSales;
                        Helper.PrintTouchTicket(pBill);	
                        break;
                    case "l6":
                        ynhrMemberManage.BusinessFacade.MemberBusiness.JobManage jm = new ynhrMemberManage.BusinessFacade.MemberBusiness.JobManage();
                        pBill = new TouchPrintedBill(ms.ToTable());
                        pBill.cnvcBillType = ConstApp.Bill_Type_SignIn;
                        pBill.cnvcShow = ms.cnvcShowName;
                        pBill.cndEndDate = "";
                        pBill.cnvcSynch = "触摸屏操作";
                        bill = new PrintedBill(pBill.ToTable());
                        Bill nbill = null;
                        retMember = jm.MemberSeatSignIn(ms, bill,out nbill);

                        
                        pBill.cnnBalance = nbill.cnnBalance;
                        pBill.cnnLastBalance = nbill.cnnLastBalance;
                        pBill.cnnPrepay = nbill.cnnPrepay;

                        pBill.cnvcFreeLast = retMember.cnvcFree;
                        pBill.cnvcSeat = retMember.cnvcSales;
                        Helper.PrintTouchTicket(pBill);	
                        break;
                }
				
				this.lblPrintTip.Visible = true;
				this.ultraButton1.Visible = false;
				this.ultraButton3.Visible = false;
//				DateTime dtBegin = DateTime.Now;
//				TimeSpan ts = DateTime.Now - dtBegin;
				this.lblPrintTip.Text = "签到成功，在刷卡器下面取签到小票，再到四号窗口领取参会资料！";
				this.timer1.Interval = 1000;
				this.timer1.Start();	
				
			}
			catch (BusinessException bex)
			{
				this.lblError.Visible = true;
				this.lblError.Text = bex.Type+"："+bex.Message;
				this.ultraGroupBox5.Visible = false;
				this.ultraGroupBox3.Visible = true;
				//MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				this.lblError.Visible = true;
				this.lblError.Text = "信息提示："+ex.Message;
				this.ultraGroupBox5.Visible = false;
				this.ultraGroupBox3.Visible = true;
				//MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void btnSignIn_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				string strSql = "select top 1 * from tbJob where cndBeginDate<getdate() and cndEndDate>getdate()";
				DataTable dtJob = Helper.Query(strSql);
				if (dtJob.Rows.Count == 0)
				{	
					throw new BusinessException("招聘会","无正在进行招聘会！");
				}
				if (Form1.pMember == null)
				{
					this.btnQuit_Click(null,null);
					return;
					//throw new BusinessException("登录错误","请登录！");
				}
				int kSeat = 0;
				int bSeat = 0;

				Job job = new Job(dtJob);
				
				DataTable dtShowSeat = Helper.Query("select * from tbMemberSeat where cnnID="+job.cnnJobID+" and cnvcMemberCardNo = '"+Form1.pMember.cnvcMemberCardNo+"' and cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
				bSeat = dtShowSeat.Rows.Count;
				DataTable dtKShowSeat = Helper.Query("select cnvcSeat from tbShowSeat where cnvcState is null and cnnJobID="+job.cnnJobID);
				kSeat = dtKShowSeat.Rows.Count;
									
				if (bSeat > 0)
				{
					ms = new MemberSeat();
					ms.cnvcMemberCardNo = Form1.pMember.cnvcMemberCardNo;
					ms.cnvcPaperNo = Form1.pMember.cnvcPaperNo;
					ms.cnvcMemberName = Form1.pMember.cnvcMemberName;
					ms.cnvcOperName = Form1.pMember.cnvcMemberCardNo;
					ms.cndOperDate = DateTime.Now;
					ms.cnnID = job.cnnJobID;//int.Parse(strJobID);
					ms.cnvcJobName = job.cnvcJobName;//strJobName;
					//ms.cnvcFloor = strShowID;
					foreach (DataRow drMemberSeat in dtShowSeat.Rows)
					{
						MemberSeat seat = new MemberSeat(drMemberSeat);
						ms.cnvcFloor = seat.cnvcFloor;
						ms.cnvcShowName = seat.cnvcShowName;
						ms.cnvcSeat += seat.cnvcSeat+"，";
					}

					this.ultraGroupBox5.Text = "展位签到信息确认";
					this.ultraGroupBox5.Visible = true;
					this.ultraGroupBox3.Visible = false;
					this.ultraButton1.Visible = true;
					this.ultraButton3.Visible = true;
					this.lblPrintTip.Visible = false;
					
					this.lblJobName.Text = ms.cnvcJobName;
					this.lblSeat.Text = ms.cnvcSeat;
					this.lblMemberCardNo.Text = ms.cnvcMemberCardNo;
					this.lblMemberName.Text = ms.cnvcMemberName;
					this.lblPaperNo.Text = ms.cnvcPaperNo;
				}
				else
				{
					if (kSeat > 0)
					{
                        switch (constApp.strCardType)
                        {
                            case "l8":
                                if (signIn.IsDisposed)
                                {
                                    signIn = new ShowSignIn(ultraGroupBox1, ultraGroupBox2, ultraGroupBox3, txtMemberCardNo, txtMemberPwd);
                                    signIn.Show();
                                }
                                else
                                {
                                    signIn.Show();
                                }
                                break;
                            case "l6":
                                if (signInOn.IsDisposed)
                                {
                                    signInOn = new TouchHold.TouchOne.ShowSignIn(ultraGroupBox1, ultraGroupBox2, ultraGroupBox3, txtMemberCardNo, txtMemberPwd);
                                    signInOn.Show();
                                }
                                else
                                {
                                    signInOn.Show();
                                }
                                break;
                        }
					}
					else
					{
						throw new BusinessException("招聘会签到","已经没有空展位了！");
						//MessageBox.Show(this, "已经没有空展位了！","招聘会签到",MessageBoxButtons.OK,MessageBoxIcon.Information);		
					}
					
				
				}
			}
			catch (BusinessException bex)
			{
				this.lblError.Visible = true;
				this.lblError.Text = bex.Type+"："+bex.Message;
				this.ultraGroupBox5.Visible = false;
				this.ultraGroupBox3.Visible = true;
				//MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				this.lblError.Visible = true;
				this.lblError.Text = "信息提示："+ex.Message;
				this.ultraGroupBox5.Visible = false;
				this.ultraGroupBox3.Visible = true;
				//MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			
			
			
		}

		private void Form1_Closed(object sender, System.EventArgs e)
		{
			GC.Collect();
		}

		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			//this.ultraGroupBox1.Visible = true;
			this.ultraGroupBox2.Visible = true;
			this.ultraGroupBox3.Visible = false;
			this.ultraGroupBox5.Visible = false;
			
			this.lblError.Visible = false;

			this.txtMemberCardNo.Text = "";
			this.txtMemberPwd.Text = "";

			ms = null;
			pMember = null;

            if (queryInfo != null)
            {
                if (!this.queryInfo.IsDisposed)
                {
                    this.queryInfo.Close();
                }
            }
            if (queryInfo2 != null)
            {
                if (!this.queryInfo2.IsDisposed)
                    this.queryInfo2.Close();
            }
            if (doc != null)
            {
                if (!this.doc.IsDisposed)
                    this.doc.Close();
            }
            if (vod != null)
            {
                if (!this.vod.IsDisposed)
                    this.vod.Close();
            }
            if (this.signIn != null)
            {
                if (!this.signIn.IsDisposed)
                    this.signIn.Close();
            }
            if (signInOn != null)
            {
                if (!this.signInOn.IsDisposed)
                    this.signInOn.Close();
            }
            if (booking != null)
            {
                if (!this.booking.IsDisposed)
                    this.booking.Close();
            }
            if (bookingOn != null)
            {
                if (!this.bookingOn.IsDisposed)
                    this.bookingOn.Close();
            }
        }

        #region 虚拟键盘
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
						if (textBox.Name == "txtMemberCardNo")
						{						
							if (textBox.Text.Length < 8)
							{
								textBox.Text += this.CurrentKey.Trim();
							}	
							else if (textBox.Text.Length == 8)
							{
								txtMemberPwd.Focus();
								//textBox.Text += this.keyBoard1.CurrentKey.Trim();
							}
						}
						if (textBox.Name == "txtMemberPwd")
						{
							textBox.Text += this.CurrentKey.Trim();
						}
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

				if (textBox.Name == "txtMemberCardNo")
				{
					txtMemberCardNo.Text = textBox.Text;
				}
				if (textBox.Name == "txtMemberPwd")
				{
					txtMemberPwd.Text = textBox.Text;
				}
			}
			
		}

		private void txtMemberCardNo_Enter(object sender, System.EventArgs e)
		{
			textBox = txtMemberCardNo;
		}

		private void txtMemberPwd_Enter(object sender, System.EventArgs e)
		{
			textBox = txtMemberPwd;
		}
		//public event EventHandler KeyOneClicked;
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
        #endregion

        private void btnJobQuery_Click(object sender, System.EventArgs e)
		{
			if (doc.IsDisposed)
			{
				//bi = new BusinessIntro();
				//bi.Show();
				doc = new DocExplorer();
                doc.strPath = System.Configuration.ConfigurationManager.AppSettings["JobIntro"];//selectedNode.Tag.ToString();
                doc.strName = System.Configuration.ConfigurationManager.AppSettings["JobIntro"];//selectedNode.Text.Substring(0,selectedNode.Text.IndexOf("."));
				doc.Show();
			}
			else
			{
				//bi.Show();
                doc.strPath = System.Configuration.ConfigurationManager.AppSettings["JobIntro"];//selectedNode.Tag.ToString();
                doc.strName = System.Configuration.ConfigurationManager.AppSettings["JobIntro"];//selectedNode.Text.Substring(0,selectedNode.Text.IndexOf("."));
				doc.Show();
			}
		
		}

		private void btnVod_Click(object sender, System.EventArgs e)
		{
//			vodExplorer vod = new vodExplorer();
//			vod.strVodPath = System.Configuration.ConfigurationSettings.AppSettings["VodPath"];//selectedNode.Text.Substring(0,selectedNode.Text.IndexOf("."));
//			vod.Show();
			if (vod.IsDisposed)
			{
				vod = new vodExplorer();
                vod.strVodPath = System.Configuration.ConfigurationManager.AppSettings["VodPath"];//selectedNode.Text.Substring(0,selectedNode.Text.IndexOf("."));
				vod.Show();
			}
			else
			{
                vod.strVodPath = System.Configuration.ConfigurationManager.AppSettings["VodPath"];//selectedNode.Text.Substring(0,selectedNode.Text.IndexOf("."));
				vod.Show();
			}
		}

		private void btnQueryInfo_Click(object sender, System.EventArgs e)
		{
			//会员信息查询
            switch (constApp.strCardType)
            {
                case "l8":
                    if (queryInfo.IsDisposed)
                    {
                        queryInfo = new QueryInfo();
                        queryInfo.Show();
                    }
                    else
                    {
                        queryInfo.Show();
                    }
                    break;
                case "l6":
                    if (queryInfo2.IsDisposed)
                    {
                        queryInfo2 = new TouchHold.TouchOne.QueryInfo();
                        queryInfo2.Show();
                    }
                    else
                    {
                        queryInfo2.Show();
                    }
                    break;
            }
		}

		private void btnChangePwd_Click(object sender, System.EventArgs e)
		{
			//修改密码
			if (changePwd.IsDisposed)
			{
				changePwd = new ChangePwd(ultraGroupBox1,ultraGroupBox2,ultraGroupBox3,txtMemberCardNo,txtMemberPwd,lblError);
				changePwd.Show();
			}
			else
			{
				changePwd.Show();
			}
		}

		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			//展位签到
			SignIn();
		}

		private void ultraButton3_Click(object sender, System.EventArgs e)
		{
			this.ultraGroupBox5.Visible = false;
			this.ultraGroupBox3.Visible = true;
		}

        //定义结构体 
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }
        //引入系统API 
        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);      

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
				btnQuit_Click(null,null);
			}

            
			
		}

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (e.Result is Exception)
            //{
            //    this.lblError.Visible = true;
            //    this.lblError.Text = "信息提示：" + ((Exception)e.Result).Message;
            //}
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //if (e.Argument is Exception)
            //{
            //    this.lblError.Visible = true;
            //    this.lblError.Text = "信息提示：" + ((Exception)e.Argument).Message;
            //}
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //获取系统的运行时间 
            int systemUpTime = Environment.TickCount;
            int LastInputTicks = 0;
            int IdleTicks = 0;
            LASTINPUTINFO LastInputInfo = new LASTINPUTINFO();
            LastInputInfo.cbSize = (uint)Marshal.SizeOf(LastInputInfo);
            LastInputInfo.dwTime = 0;
            //获取用户上次操作的时间 
            if (GetLastInputInfo(ref LastInputInfo))
            {
                LastInputTicks = (int)LastInputInfo.dwTime;
                //求差，就是系统空闲的时间 
                IdleTicks = systemUpTime - LastInputTicks;
            }
            //lblSystemUpTime.Text = Convert.ToString(systemUpTime / 1000) + " 秒";
            //lblIdleTime.Text = Convert.ToString(IdleTicks / 1000) + " 秒"; 
            if(IdleTicks/1000>constApp.iTouchFlash)
            {
                btnQuit_Click(null, null);
            }
        }
	}
}
