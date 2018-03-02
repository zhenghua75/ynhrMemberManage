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
//using MemberManage;
//using MemberManage.Business;
using ynhrMemberManage.ORM;
//using ynhrMemberManage.MemberManage.Common;
using ynhrMemberManage.CardCommon.CardRef;
using ynhrMemberManage.CardCommon.CardDef;
//using MemberManage.Print;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinTree;
using System.Threading;
using ynhrMemberManage.Print;
using ynhrMemberManage.Domain;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Common;
#endregion
namespace TouchHold
{
	/// <summary>
	/// Summary description for ShowBooking.
	/// </summary>
	public class ShowBooking : frmBase
	{

		//public static bool IsShowing ;
		#region 变量
		private System.ComponentModel.IContainer components;
		private Infragistics.Win.Misc.UltraButton btnCardBook;
		private Infragistics.Win.Misc.UltraButton ultraButton2;
		private System.Windows.Forms.ToolTip toolTip1;
		private Infragistics.Win.Misc.UltraButton btnExit;

		private Infragistics.Win.Misc.UltraGroupBox boxLogin;
		private Infragistics.Win.Misc.UltraGroupBox boxOper;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberPwd;

		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox6;
		private Infragistics.Win.Misc.UltraLabel lblBookError;
		private Infragistics.Win.Misc.UltraButton btnReturn;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.Misc.UltraButton ultraButton3;
		private Infragistics.Win.Misc.UltraLabel lblJobName;
		private Infragistics.Win.Misc.UltraLabel lblSeat;
		private Infragistics.Win.Misc.UltraLabel lblMemberCardNo;
		private Infragistics.Win.Misc.UltraLabel lblMemberName;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.Misc.UltraLabel lblPaperNo;
		private MemberSeat ms = null;
		private Infragistics.Win.Misc.UltraLabel lblPrintTip;
		private Infragistics.Win.Misc.UltraGroupBox ugbBook;
		private Infragistics.Win.Misc.UltraGroupBox ugbShow;
		private Infragistics.Win.Misc.UltraGroupBox ugbJob;
		private Infragistics.Win.Misc.UltraGroupBox ugbInfoDisp;
		private Infragistics.Win.Misc.UltraLabel ultraLabel8;
		private Infragistics.Win.Misc.UltraLabel lblSelectedSeat;
		private Infragistics.Win.Misc.UltraLabel lblSelectedShow;
		private Infragistics.Win.Misc.UltraLabel lblSelectedJob;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraButton btnSelectLogin;
		private Infragistics.Win.Misc.UltraButton btnSelectShow;
		private Infragistics.Win.Misc.UltraLabel ultraLabel10;
		private Infragistics.Win.Misc.UltraLabel ultraLabel11;
		private Infragistics.Win.Misc.UltraLabel ultraLabel12;
		private Infragistics.Win.Misc.UltraGroupBox ugbInfoConfirm;
		private Infragistics.Win.Misc.UltraGroupBox ugbInfoWay;
		private Infragistics.Win.Misc.UltraButton ultraButton4;
		private Infragistics.Win.Misc.UltraButton ultraButton5;
		private Infragistics.Win.Misc.UltraButton ultraButton6;
		private Infragistics.Win.Misc.UltraButton ultraButton7;
		private Infragistics.Win.Misc.UltraButton ultraButton8;
		private System.Windows.Forms.Timer timer1;
		private DateTime dtJobBeginDate;
		#endregion

		public ShowBooking(UltraGroupBox ultraGroupBox2,UltraGroupBox ultraGroupBox3,UltraTextEditor txtMemberCardNo,UltraTextEditor txtMemberPwd)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.boxLogin = ultraGroupBox2;
			this.boxOper = ultraGroupBox3;
			this.txtMemberCardNo = txtMemberCardNo;
			this.txtMemberPwd = txtMemberPwd;
            //ApplicationIdleTimer idle = new ApplicationIdleTimer();
            //System.Windows.Forms.Application.AddMessageFilter(idle);
            //idle.ApplicationIdle += new ApplicationIdleTimer.ApplicationIdleEventHandler(this.App_Idle);
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
            this.btnCardBook = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ugbBook = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnSelectShow = new Infragistics.Win.Misc.UltraButton();
            this.btnSelectLogin = new Infragistics.Win.Misc.UltraButton();
            this.btnExit = new Infragistics.Win.Misc.UltraButton();
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
            this.ultraGroupBox6 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnReturn = new Infragistics.Win.Misc.UltraButton();
            this.lblBookError = new Infragistics.Win.Misc.UltraLabel();
            this.ugbShow = new Infragistics.Win.Misc.UltraGroupBox();
            this.ugbJob = new Infragistics.Win.Misc.UltraGroupBox();
            this.ugbInfoDisp = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.lblSelectedSeat = new Infragistics.Win.Misc.UltraLabel();
            this.lblSelectedShow = new Infragistics.Win.Misc.UltraLabel();
            this.lblSelectedJob = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ugbInfoWay = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraButton8 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton7 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton6 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton5 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton4 = new Infragistics.Win.Misc.UltraButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ugbBook)).BeginInit();
            this.ugbBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbInfoConfirm)).BeginInit();
            this.ugbInfoConfirm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox6)).BeginInit();
            this.ultraGroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbInfoDisp)).BeginInit();
            this.ugbInfoDisp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugbInfoWay)).BeginInit();
            this.ugbInfoWay.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCardBook
            // 
            this.btnCardBook.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnCardBook.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCardBook.Location = new System.Drawing.Point(64, 8);
            this.btnCardBook.Name = "btnCardBook";
            this.btnCardBook.Size = new System.Drawing.Size(136, 40);
            this.btnCardBook.TabIndex = 7;
            this.btnCardBook.Text = "预订";
            this.btnCardBook.Click += new System.EventHandler(this.btnCardBook_Click);
            // 
            // ultraButton2
            // 
            this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraButton2.Location = new System.Drawing.Point(64, 48);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(136, 40);
            this.ultraButton2.TabIndex = 14;
            this.ultraButton2.Text = "取消预订";
            this.ultraButton2.Click += new System.EventHandler(this.btnCancelCardBook_Click);
            // 
            // ugbBook
            // 
            this.ugbBook.Controls.Add(this.btnSelectShow);
            this.ugbBook.Controls.Add(this.btnSelectLogin);
            this.ugbBook.Controls.Add(this.btnExit);
            this.ugbBook.Controls.Add(this.btnCardBook);
            this.ugbBook.Controls.Add(this.ultraButton2);
            this.ugbBook.Location = new System.Drawing.Point(288, 552);
            this.ugbBook.Name = "ugbBook";
            this.ugbBook.Size = new System.Drawing.Size(272, 216);
            this.ugbBook.TabIndex = 14;
            // 
            // btnSelectShow
            // 
            this.btnSelectShow.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnSelectShow.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectShow.Location = new System.Drawing.Point(64, 88);
            this.btnSelectShow.Name = "btnSelectShow";
            this.btnSelectShow.Size = new System.Drawing.Size(136, 40);
            this.btnSelectShow.TabIndex = 17;
            this.btnSelectShow.Text = "选择展厅";
            this.btnSelectShow.Click += new System.EventHandler(this.btnSelectShow_Click);
            // 
            // btnSelectLogin
            // 
            this.btnSelectLogin.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnSelectLogin.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectLogin.Location = new System.Drawing.Point(64, 128);
            this.btnSelectLogin.Name = "btnSelectLogin";
            this.btnSelectLogin.Size = new System.Drawing.Size(136, 40);
            this.btnSelectLogin.TabIndex = 16;
            this.btnSelectLogin.Text = "返回主菜单";
            this.btnSelectLogin.Click += new System.EventHandler(this.btnSelectLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnExit.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(64, 168);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(136, 40);
            this.btnExit.TabIndex = 15;
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
            this.ugbInfoConfirm.Location = new System.Drawing.Point(16, 0);
            this.ugbInfoConfirm.Name = "ugbInfoConfirm";
            this.ugbInfoConfirm.Size = new System.Drawing.Size(552, 328);
            this.ugbInfoConfirm.TabIndex = 16;
            this.ugbInfoConfirm.Text = "展位预订信息确认";
            // 
            // lblPrintTip
            // 
            this.lblPrintTip.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrintTip.Location = new System.Drawing.Point(32, 200);
            this.lblPrintTip.Name = "lblPrintTip";
            this.lblPrintTip.Size = new System.Drawing.Size(496, 64);
            this.lblPrintTip.TabIndex = 12;
            this.lblPrintTip.Text = "预订成功，请在刷卡器下面取预订小票。";
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
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(16, 32);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(144, 23);
            this.ultraLabel2.TabIndex = 0;
            this.ultraLabel2.Text = "招聘会：";
            // 
            // ultraGroupBox6
            // 
            this.ultraGroupBox6.Controls.Add(this.btnReturn);
            this.ultraGroupBox6.Controls.Add(this.lblBookError);
            this.ultraGroupBox6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraGroupBox6.Location = new System.Drawing.Point(8, 328);
            this.ultraGroupBox6.Name = "ultraGroupBox6";
            this.ultraGroupBox6.Size = new System.Drawing.Size(544, 224);
            this.ultraGroupBox6.TabIndex = 17;
            this.ultraGroupBox6.Text = "信息提示";
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(200, 168);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(136, 48);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "返回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblBookError
            // 
            this.lblBookError.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBookError.Location = new System.Drawing.Point(24, 48);
            this.lblBookError.Name = "lblBookError";
            this.lblBookError.Size = new System.Drawing.Size(504, 104);
            this.lblBookError.TabIndex = 0;
            // 
            // ugbShow
            // 
            this.ugbShow.Location = new System.Drawing.Point(128, 576);
            this.ugbShow.Name = "ugbShow";
            this.ugbShow.Size = new System.Drawing.Size(176, 56);
            this.ugbShow.TabIndex = 24;
            this.ugbShow.Text = "请选择招聘会展厅";
            // 
            // ugbJob
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ugbJob.Appearance = appearance1;
            this.ugbJob.Location = new System.Drawing.Point(16, 560);
            this.ugbJob.Name = "ugbJob";
            this.ugbJob.Size = new System.Drawing.Size(104, 80);
            this.ugbJob.TabIndex = 23;
            this.ugbJob.Text = "招聘会";
            // 
            // ugbInfoDisp
            // 
            this.ugbInfoDisp.Controls.Add(this.ultraLabel12);
            this.ugbInfoDisp.Controls.Add(this.ultraLabel11);
            this.ugbInfoDisp.Controls.Add(this.ultraLabel10);
            this.ugbInfoDisp.Controls.Add(this.ultraLabel8);
            this.ugbInfoDisp.Controls.Add(this.lblSelectedSeat);
            this.ugbInfoDisp.Controls.Add(this.lblSelectedShow);
            this.ugbInfoDisp.Controls.Add(this.lblSelectedJob);
            this.ugbInfoDisp.Controls.Add(this.ultraLabel7);
            this.ugbInfoDisp.Controls.Add(this.ultraLabel3);
            this.ugbInfoDisp.Controls.Add(this.ultraLabel1);
            this.ugbInfoDisp.Location = new System.Drawing.Point(576, 8);
            this.ugbInfoDisp.Name = "ugbInfoDisp";
            this.ugbInfoDisp.Size = new System.Drawing.Size(288, 368);
            this.ugbInfoDisp.TabIndex = 22;
            // 
            // ultraLabel12
            // 
            this.ultraLabel12.Location = new System.Drawing.Point(32, 320);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(240, 23);
            this.ultraLabel12.TabIndex = 21;
            this.ultraLabel12.Text = "无背景色为可用展位";
            // 
            // ultraLabel11
            // 
            this.ultraLabel11.Location = new System.Drawing.Point(32, 296);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(240, 23);
            this.ultraLabel11.TabIndex = 20;
            this.ultraLabel11.Text = "红色为已被使用展位";
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.Location = new System.Drawing.Point(32, 272);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(200, 23);
            this.ultraLabel10.TabIndex = 19;
            this.ultraLabel10.Text = "蓝色为自己预订展位";
            // 
            // ultraLabel8
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance2;
            this.ultraLabel8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraLabel8.Location = new System.Drawing.Point(32, 248);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(240, 24);
            this.ultraLabel8.TabIndex = 18;
            this.ultraLabel8.Text = "请选择展位";
            // 
            // lblSelectedSeat
            // 
            this.lblSelectedSeat.Font = new System.Drawing.Font("宋体", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSelectedSeat.Location = new System.Drawing.Point(88, 168);
            this.lblSelectedSeat.Name = "lblSelectedSeat";
            this.lblSelectedSeat.Size = new System.Drawing.Size(176, 80);
            this.lblSelectedSeat.TabIndex = 17;
            // 
            // lblSelectedShow
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.lblSelectedShow.Appearance = appearance3;
            this.lblSelectedShow.Location = new System.Drawing.Point(96, 88);
            this.lblSelectedShow.Name = "lblSelectedShow";
            this.lblSelectedShow.Size = new System.Drawing.Size(176, 64);
            this.lblSelectedShow.TabIndex = 16;
            this.lblSelectedShow.Text = "展厅：";
            // 
            // lblSelectedJob
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.lblSelectedJob.Appearance = appearance4;
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
            this.ultraLabel3.Location = new System.Drawing.Point(16, 104);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(72, 23);
            this.ultraLabel3.TabIndex = 11;
            this.ultraLabel3.Text = "展厅：";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(16, 184);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(72, 23);
            this.ultraLabel1.TabIndex = 9;
            this.ultraLabel1.Text = "展位：";
            // 
            // ugbInfoWay
            // 
            this.ugbInfoWay.Controls.Add(this.ultraButton8);
            this.ugbInfoWay.Controls.Add(this.ultraButton7);
            this.ugbInfoWay.Controls.Add(this.ultraButton6);
            this.ugbInfoWay.Controls.Add(this.ultraButton5);
            this.ugbInfoWay.Controls.Add(this.ultraButton4);
            this.ugbInfoWay.Location = new System.Drawing.Point(576, 392);
            this.ugbInfoWay.Name = "ugbInfoWay";
            this.ugbInfoWay.Size = new System.Drawing.Size(296, 144);
            this.ugbInfoWay.TabIndex = 25;
            this.ugbInfoWay.Text = "信息提交方式";
            // 
            // ultraButton8
            // 
            this.ultraButton8.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button3D;
            this.ultraButton8.Location = new System.Drawing.Point(112, 88);
            this.ultraButton8.Name = "ultraButton8";
            this.ultraButton8.Size = new System.Drawing.Size(88, 48);
            this.ultraButton8.TabIndex = 4;
            this.ultraButton8.Text = "申请表";
            this.ultraButton8.Click += new System.EventHandler(this.btn_Click);
            // 
            // ultraButton7
            // 
            this.ultraButton7.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button3D;
            this.ultraButton7.Location = new System.Drawing.Point(8, 88);
            this.ultraButton7.Name = "ultraButton7";
            this.ultraButton7.Size = new System.Drawing.Size(96, 48);
            this.ultraButton7.TabIndex = 3;
            this.ultraButton7.Text = "传真";
            this.ultraButton7.Click += new System.EventHandler(this.btn_Click);
            // 
            // ultraButton6
            // 
            this.ultraButton6.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button3D;
            this.ultraButton6.Location = new System.Drawing.Point(208, 32);
            this.ultraButton6.Name = "ultraButton6";
            this.ultraButton6.Size = new System.Drawing.Size(80, 48);
            this.ultraButton6.TabIndex = 2;
            this.ultraButton6.Text = "待传";
            this.ultraButton6.Click += new System.EventHandler(this.btn_Click);
            // 
            // ultraButton5
            // 
            this.ultraButton5.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button3D;
            this.ultraButton5.Location = new System.Drawing.Point(112, 32);
            this.ultraButton5.Name = "ultraButton5";
            this.ultraButton5.Size = new System.Drawing.Size(88, 48);
            this.ultraButton5.TabIndex = 1;
            this.ultraButton5.Text = "上一次";
            this.ultraButton5.Click += new System.EventHandler(this.btn_Click);
            // 
            // ultraButton4
            // 
            this.ultraButton4.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button3D;
            this.ultraButton4.Location = new System.Drawing.Point(8, 32);
            this.ultraButton4.Name = "ultraButton4";
            this.ultraButton4.Size = new System.Drawing.Size(96, 48);
            this.ultraButton4.TabIndex = 0;
            this.ultraButton4.Text = "自带";
            this.ultraButton4.Click += new System.EventHandler(this.btn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ShowBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.ClientSize = new System.Drawing.Size(977, 746);
            this.ControlBox = false;
            this.Controls.Add(this.ugbInfoWay);
            this.Controls.Add(this.ugbShow);
            this.Controls.Add(this.ugbJob);
            this.Controls.Add(this.ugbInfoDisp);
            this.Controls.Add(this.ultraGroupBox6);
            this.Controls.Add(this.ugbInfoConfirm);
            this.Controls.Add(this.ugbBook);
            this.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowBooking";
            this.Text = "展位预订";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ShowBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ugbBook)).EndInit();
            this.ugbBook.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbInfoConfirm)).EndInit();
            this.ugbInfoConfirm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox6)).EndInit();
            this.ultraGroupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugbInfoDisp)).EndInit();
            this.ugbInfoDisp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugbInfoWay)).EndInit();
            this.ugbInfoWay.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void ShowBooking_Load(object sender, System.EventArgs e)
		{
			//this.FormBorderStyle=FormBorderStyle.None;
			this.DispJob();
            //this.SetBackgroundImg();
		}
        //private void App_Idle(ApplicationIdleTimer.ApplicationIdleEventArgs e)
        //{
        //    if (e.IdleDuration.TotalSeconds>30)
        //    {
        //        btnExit_Click(null,null);
        //    }
			
        //}
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
				Member member = new Member(drSeat);
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
				if (seat.cnvcState.Length > 1)
				{
					lbl.BackColor = Color.Red;
					if (member.cnvcMemberCardNo == Form1.pMember.cnvcMemberCardNo)
					{
						if (seat.cnvcState == ConstApp.Show_Seat_State_Booking)
						{
							lbl.BackColor = Color.Blue;
						}
						
					}
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
						if (member.cnvcMemberCardNo == Form1.pMember.cnvcMemberCardNo)
						{
							lbl.Click +=new EventHandler(lblCancel_Click);
						}
						else
						{
							lbl.Click +=new EventHandler(lblUse_Click);
						}
						
					}
					
				}				
				pl.Controls.Add(lbl);
					
			}

		}
		private void lbl_Click(object sender, EventArgs e)
		{
			//空展位
			Control lCtrl =(sender as Control);
			lblSelectedSeat.Text = lCtrl.Text;
//			ugbBook.Visible = true;
//			ugbBook.Left = ugbInfoDisp.Left;
//			ugbBook.Top = ugbInfoDisp.Top+ugbInfoDisp.Height+30;
			ms.cnvcSeat = lCtrl.Text;
			ultraLabel8.Visible = false;
			this.btnCardBook.Visible = true;
			this.ultraButton2.Visible = false;
			this.ugbInfoWay.Visible = true;
		}
		private void lblUse_Click(object sender, EventArgs e)
		{
			//他人使用展位
			Control lCtrl =(sender as Control);
			lblSelectedSeat.Text = "";//lCtrl.Text;
//			ugbBook.Visible = true;
//			ugbBook.Left = ugbInfoDisp.Left;
//			ugbBook.Top = ugbInfoDisp.Top+ugbInfoDisp.Height+30;
			ms.cnvcSeat = "";//lCtrl.Text;
			ultraLabel8.Visible = true;
			this.btnCardBook.Visible = false;
			this.ultraButton2.Visible = false;
			this.ugbInfoWay.Visible = false;
		}
		private void lblCancel_Click(object sender, EventArgs e)
		{
			//自己预订展位
			Control lCtrl =(sender as Control);
			lblSelectedSeat.Text = lCtrl.Text;
//			ugbBook.Visible = true;
//			ugbBook.Left = ugbInfoDisp.Left;
//			ugbBook.Top = ugbInfoDisp.Top+ugbInfoDisp.Height+30;
			ms.cnvcSeat = lCtrl.Text;
			ultraLabel8.Visible = false;
			this.btnCardBook.Visible = false;
			this.ultraButton2.Visible = true;
			this.ugbInfoWay.Visible = false;
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
				this.ugbInfoDisp.Top = 10;
				this.ugbInfoDisp.Left = pl.Left + pl.Width + 10;

				
				this.ugbInfoWay.Left = this.ugbInfoDisp.Left;
				ugbInfoWay.Top = ugbInfoDisp.Top+ugbInfoDisp.Height+5;

				ugbBook.Visible = true;
				ugbBook.Left = ugbInfoDisp.Left;
				ugbBook.Top = ugbInfoWay.Top+ugbInfoWay.Height+5;

				this.btnCardBook.Visible = false;
				this.ultraButton2.Visible = false;


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

		#endregion

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

			//Form1.constApp.iBookDate
			//string strSql = "select * from tbJob where cndBeginDate>getdate() order by cndBeginDate desc";
			//string strSql = "select * from tbJob where cndBeginDate >=getdate() and cndBookBeginDate<=getdate() order by cndBeginDate desc";
            string strSql = "select * from tbJob where GETDATE() between cndBookBeginDate and cndBookEndDate order by cndBeginDate desc";
			DataTable dtJob = Helper.Query(strSql);
			foreach (DataRow drJob in dtJob.Rows)
			{
				Job job = new Job(drJob);
				int beforeDay = 0;
				if (Form1.constApp.htBookDate.Contains(Form1.pMember.cnvcMemberRight))
				{
					beforeDay = int.Parse(Form1.constApp.htBookDate[Form1.pMember.cnvcMemberRight].ToString());
				}
				
				if(job.cndBeginDate.AddDays(-beforeDay)<=DateTime.Now)
				{
				
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

			if(job.cndBeginDate >Convert.ToDateTime(Form1.pMember.cndEndDate))
			{
				DispError("所选择的招聘会开始前会员已到期，请到服务台办理","Job");
			}
			else
			{
                if (Form1.pMember.cnvcFree != ConstApp.Free_Time_NoLimit)
                {
                    if (string.IsNullOrEmpty(Form1.pMember.cnvcFree))
                    {
                        DispError("场次为0，请到服务台续费后再办理预定", "Job");
                    }
                    else
                    {
                        if (Convert.ToInt32(Form1.pMember.cnvcFree) == 0)
                        {
                            DispError("场次为0，请到服务台续费后再办理预定", "Job");
                        }
                        else
                        {
                            DispShow(job);
                        }
                    }
                }
                else
                {
                    DispShow(job);
                }
			}
			
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
			
			DateTime dtMemberEndDate = DateTime.Parse(Form1.pMember.cndEndDate);
			if (dtMemberEndDate < job.cndBeginDate)
			{
				DispError("界时会员已到期，不能预订！请到服务柜台咨询。","Job");
				return;
			}

			ms = new MemberSeat(Form1.pMember.ToTable());
			ms.cnnID = job.cnnJobID;
			ms.cnvcJobName = job.cnvcJobName;
			ms.cniSynch = 2;
			//ms.cnvcInfoWay = "自带";
			dtJobBeginDate = job.cndBeginDate;
			
			

			int iHeight = 0;
			this.ugbShow.Visible = true;
			this.ugbShow.Text = "请选择招聘会展厅";
			this.ugbShow.Font = new Font("宋体",40);
			this.ugbShow.Width = 800;
			this.ugbShow.Appearance.BackColor = Color.Transparent;
			this.ugbShow.Controls.Clear();
			UltraButton btnReturn = new UltraButton();
			btnReturn.Name = "jobReturn";
			btnReturn.Text = "重新选择招聘会";
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
				//				string strSeatSql = "select cnvcSeat from tbShowSeat where cnnJobID="+job.cnnJobID.ToString()+" and cnvcFloor="+show.cnnShowID.ToString()+" and cnvcState is null and cnvcSeat is not null";
				//				DataTable dtSeat = Helper.Query(strSeatSql);
				//				if (dtSeat.Rows.Count > 0)
				//				{
				
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
				//}
			}
			this.ugbShow.Height = iHeight+100;
            this.ugbShow.Top = (this.Height - this.ugbShow.Height) / 2;
            this.ugbShow.Left = (this.Width - this.ugbShow.Width) / 2;
            //this.ugbShow.Top = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - this.ugbShow.Height) / 2;
            //this.ugbShow.Left = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - this.ugbShow.Width) / 2;

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
		private void DispError(string strError,string strType)
		{
//			this.ultraGroupBox4.Visible = false;
//			this.ultraGroupBox5.Visible = false;
//			this.ultraGroupBox6.Visible = true;
			
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
			btnReturn.Tag = strType;
			this.ultraGroupBox6.Visible = true;
			this.ultraGroupBox6.Top = (this.Height-this.ultraGroupBox6.Height)/2;
			this.ultraGroupBox6.Left = (this.Width-this.ultraGroupBox6.Width)/2;
			this.lblBookError.Text = strError;			
		}		
		
		private void btnCardBook_Click(object sender, System.EventArgs e)
		{
			//刷卡预订
			try
			{
				if (ms.cnvcSeat == "")
				{
					throw new BusinessException("展位预订","请选择展位");
				}
				if (ms.cnvcInfoWay == "")
				{
					DispError("请选择信息提交方式","InfoWay");
					return;
					//throw new BusinessException("展位预订","请选择信息提交方式");
				}
				if (Form1.constApp.htMemberSeats.Contains(Form1.pMember.cnvcMemberRight))
				{
					DataTable dtSeats = Helper.Query("select count(*) from tbMemberSeat where cnvcMemberCardNo='"+Form1.pMember.cnvcMemberCardNo+"' and (cnvcState = '"+ConstApp.Show_Seat_State_Booking+"' or cnvcState='"+ConstApp.Show_Seat_State_SignIn+"') and cnnID="+ms.cnnID.ToString());
					string strBookSeats = Form1.constApp.htMemberSeats[Form1.pMember.cnvcMemberRight].ToString();
					string strBookedSeats = dtSeats.Rows[0][0].ToString();
					if (strBookedSeats != ConstApp.Free_Time_NoLimit)
					{
						int iBookSeats = int.Parse(strBookSeats);//展位数限制
						int iBookedSeats = int.Parse(strBookedSeats);//已预订展位数
						if (iBookedSeats >= iBookSeats)
						{
							throw new BusinessException("展位预订","已到限制展位数！");
						}
					}
				}

				DataTable dtMemberSeat = Helper.Query("select * from tbShowSeat where cnnJobID="+ms.cnnID+" and cnvcSeat='"+ms.cnvcSeat+"' and cnvcFloor='"+ms.cnvcFloor+"' and cnvcState is null");
				if (dtMemberSeat.Rows.Count == 0)
				{
					throw new BusinessException("会员预订","此展位已被使用！");
				}
				
				ms.cnvcOperName = Form1.pMember.cnvcMemberCardNo;
				ms.cndOperDate = DateTime.Now;
				ms.cniSynch = 2;

				ms.cnvcState = ConstApp.Show_Seat_State_Booking;//"预订";
				JobManage jobManage = new JobManage();				


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
				ugbInfoConfirm.Text = "会员预订信息确认";
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
				DispError(bex.Type+"："+bex.Message,"");
				//MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				DispError("信息提示"+ex.Message,"");
				//MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			
			//LoadPanel();
		}

		private void btnCancelCardBook_Click(object sender, System.EventArgs e)
		{
			//会员刷卡取消预订
			try
			{
				if (ms.cnvcSeat == "")
				{
					throw new BusinessException("展位取消预订","请选择展位");
				}
				
				ms.cnvcOperName = Form1.pMember.cnvcMemberCardNo;
				ms.cndOperDate = DateTime.Now;				
				ms.cnvcState = ConstApp.Show_Seat_State_No_Booking;
				DataTable dtMemberSeat = Helper.Query("select * from tbMemberSeat where cnvcMemberCardNo='"+ms.cnvcMemberCardNo+"' and cnnID="+ms.cnnID+" and cnvcSeat='"+ms.cnvcSeat+"' and cnvcFloor='"+ms.cnvcFloor+"' and cnvcState='"+ConstApp.Show_Seat_State_Booking+"'");
				if (dtMemberSeat.Rows.Count == 0)
				{
					throw new BusinessException("会员取消预订","此会员未预订此展位！");
				}

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
				ugbInfoConfirm.Text = "展位取消预订信息确认";
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
				DispError(bex.Type+"："+bex.Message,"");
				//MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				DispError("信息提示"+ex.Message,"");
				//MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			Form1.pMember = null;
			this.boxLogin.Visible = true;
			this.boxOper.Visible = false;
			this.txtMemberCardNo.Text = "";
			this.txtMemberPwd.Text = "";
			this.Close();
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			//DispMain();
			//错误信息返回
			string strType = btnReturn.Tag.ToString();
			
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
			if (strType == "Job")
			{
				btnShowReturn_Click(null,null);
			}
			else if (strType == "InfoWay")
			{
				ultraButton3_Click(null,null);
			}			
			else
			{
				this.ultraLabel8.Visible = true;
				this.lblSelectedSeat.Text = "";
				ms.cnvcSeat = "";
				ms.cnvcFloor = "";
				ms.cnvcShowName = "";
				this.ugbShow.Visible = true;
			}
			
			//this.ugbInfoDisp.Visible = true;

		}

		private void ultraButton3_Click(object sender, System.EventArgs e)
		{
			//错误信息返回
			//预订返回
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
			this.btnCardBook.Visible = false;
			this.ugbBook.Visible = true;
		}

		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (ms.cnvcState == ConstApp.Show_Seat_State_Booking)
				{
					
					TouchPrintedBill pBill = new TouchPrintedBill(Form1.pMember.ToTable());	
					pBill.cndOperDate = DateTime.Now;
					pBill.cnnMemberFee = 0;
					pBill.cnnPrepay = 0;					
					pBill.cnvcBillType = "预订";
					pBill.cnvcMemberPwd = "";
					//pBill.cnvcFreeLast = Form1.pMember.cnvcFree;
					pBill.cnvcSeat = ms.cnvcSeat;//txtSeat.Text;
					pBill.cnvcShow = ms.cnvcShowName;//strShowName;
					pBill.cnvcProduct = "";
					pBill.cnvcJobInfo = "请于"+dtJobBeginDate.ToString("yyyy-MM-dd")+" 上午 9:30以前到";
					JobManage jobManage = new JobManage();	
					PrintedBill bill = new PrintedBill(pBill.ToTable());
					bill.cnvcOperName = ms.cnvcMemberCardNo;
					jobManage.MemberSeatBooking(ms,bill);
					

					

					Helper.PrintTouchTicket(pBill);
					
					this.lblPrintTip.Visible = true;
					this.ultraButton1.Visible = false;
					this.ultraButton3.Visible = false;//请取预订小票！
					this.lblPrintTip.Text = "预订成功，请在刷卡器下面取预订小票。";

				
					this.timer1.Interval = 1000;
					this.timer1.Start();
				}
				if (ms.cnvcState == ConstApp.Show_Seat_State_No_Booking)
				{
					JobManage jobManage = new JobManage();
					jobManage.CancelMemberSeatBooking(ms);
					
					btnExit_Click(null,null);
					
				}
			}
			catch (BusinessException bex)
			{
				DispError(bex.Type+"："+bex.Message,"");
				//MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				DispError("信息提示："+ex.Message,"");
				//MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}	
			
		}

		private delegate void PrintDelegate(TouchPrintedBill pBill);


		private void PrintProc(TouchPrintedBill pBill)
		{
		
//			this.lblPrintTip.Visible = true;
//			this.ultraButton1.Visible = false;
//			this.ultraButton3.Visible = false;
//			this.lblPrintTip.Text = "预订成功，请在刷卡器下面取小票";
			//Helper.PrintTouchTicket(pBill);
		}		


		private void btnSelectLogin_Click(object sender, System.EventArgs e)
		{
			//主菜单
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
			ugbShow.Visible = true;
			
		}

		private void btn_Click(object sender, System.EventArgs e)
		{
			if (null != ms)
			{
				UltraButton ub = (UltraButton)sender;
				ms.cnvcInfoWay = ub.Text;
			}
		
		}

		private int iCount = 0;
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			
			if (iCount < 5)
			{			
				this.lblPrintTip.Text = "预订成功，请在刷卡器下面取预订小票，"+(5-iCount)+"秒后自动退出";
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
