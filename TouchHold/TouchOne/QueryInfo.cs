using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace TouchHold.TouchOne
{
	/// <summary>
	/// QueryInfo 的摘要说明。
	/// </summary>
	public class QueryInfo : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.Misc.UltraLabel lblJobTimes;
        private Infragistics.Win.Misc.UltraLabel lblMemberName;
        private Infragistics.Win.Misc.UltraLabel lblFree;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public QueryInfo()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.lblFree = new Infragistics.Win.Misc.UltraLabel();
            this.lblJobTimes = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.lblMemberName = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.Controls.Add(this.ultraButton1);
            this.ultraGroupBox1.Controls.Add(this.lblFree);
            this.ultraGroupBox1.Controls.Add(this.lblJobTimes);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox1.Controls.Add(this.lblMemberName);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
            appearance8.ForeColor = System.Drawing.Color.White;
            this.ultraGroupBox1.HeaderAppearance = appearance8;
            this.ultraGroupBox1.Location = new System.Drawing.Point(184, 56);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(688, 376);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.Text = "会员信息";
            this.ultraGroupBox1.UseAppStyling = false;
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(224, 166);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(160, 40);
            this.ultraButton1.TabIndex = 10;
            this.ultraButton1.Text = "返回";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // lblFree
            // 
            appearance2.ForeColor = System.Drawing.Color.White;
            this.lblFree.Appearance = appearance2;
            this.lblFree.Location = new System.Drawing.Point(168, 128);
            this.lblFree.Name = "lblFree";
            this.lblFree.Size = new System.Drawing.Size(504, 23);
            this.lblFree.TabIndex = 8;
            this.lblFree.UseAppStyling = false;
            // 
            // lblJobTimes
            // 
            appearance3.ForeColor = System.Drawing.Color.White;
            this.lblJobTimes.Appearance = appearance3;
            this.lblJobTimes.Location = new System.Drawing.Point(168, 88);
            this.lblJobTimes.Name = "lblJobTimes";
            this.lblJobTimes.Size = new System.Drawing.Size(504, 23);
            this.lblJobTimes.TabIndex = 7;
            this.lblJobTimes.UseAppStyling = false;
            // 
            // ultraLabel5
            // 
            appearance4.ForeColor = System.Drawing.Color.White;
            this.ultraLabel5.Appearance = appearance4;
            this.ultraLabel5.Location = new System.Drawing.Point(16, 128);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(112, 23);
            this.ultraLabel5.TabIndex = 4;
            this.ultraLabel5.Text = "当前余额：";
            this.ultraLabel5.UseAppStyling = false;
            // 
            // ultraLabel3
            // 
            appearance5.ForeColor = System.Drawing.Color.White;
            this.ultraLabel3.Appearance = appearance5;
            this.ultraLabel3.Location = new System.Drawing.Point(16, 88);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(120, 23);
            this.ultraLabel3.TabIndex = 2;
            this.ultraLabel3.Text = "参展次数：";
            this.ultraLabel3.UseAppStyling = false;
            // 
            // lblMemberName
            // 
            appearance6.ForeColor = System.Drawing.Color.White;
            this.lblMemberName.Appearance = appearance6;
            this.lblMemberName.Location = new System.Drawing.Point(168, 48);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(504, 23);
            this.lblMemberName.TabIndex = 1;
            this.lblMemberName.UseAppStyling = false;
            // 
            // ultraLabel1
            // 
            appearance7.ForeColor = System.Drawing.Color.White;
            this.ultraLabel1.Appearance = appearance7;
            this.ultraLabel1.Location = new System.Drawing.Point(16, 48);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(120, 23);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "单位名称：";
            this.ultraLabel1.UseAppStyling = false;
            // 
            // QueryInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.ClientSize = new System.Drawing.Size(920, 523);
            this.Controls.Add(this.ultraGroupBox1);
            this.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QueryInfo";
            this.Text = "QueryInfo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QueryInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        //private void App_Idle(ApplicationIdleTimer.ApplicationIdleEventArgs e)
        //{
        //    if (e.IdleDuration.TotalSeconds>10)
        //    {
        //        ultraButton1_Click(null,null);
        //    }
			
        //}
		private void QueryInfo_Load(object sender, System.EventArgs e)
		{
			//this.FormBorderStyle=FormBorderStyle.None;
			this.ultraGroupBox1.Left = (this.Width-this.ultraGroupBox1.Width)/2;
			this.ultraGroupBox1.Top = (this.ultraGroupBox1.Height)/2;
			if (null == Form1.pMember)
			{
				MessageBox.Show(this, "请登录！", "会员信息查询",MessageBoxButtons.OK,MessageBoxIcon.Information);	
			}
			this.lblMemberName.Text = Form1.pMember.cnvcMemberName;
			//this.lblEndDate.Text = DateTime.Parse(Form1.pMember.cndEndDate).ToString("yyyy-MM-dd");
			this.lblFree.Text = Form1.pMember.cnnPrepay.ToString();
			DataTable dtMember = ynhrMemberManage.BusinessFacade.Helper.Query("select count(distinct cnnID) from tbMemberSeat where cnvcMemberCardNo= '"+Form1.pMember.cnvcMemberCardNo+"' and cnvcState = '预订'");
			this.lblJobTimes.Text = dtMember.Rows[0][0].ToString();
		}
	}
}
