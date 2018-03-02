using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.Domain;
using ynhrMemberManage.ORM;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using Infragistics;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using ynhrMemberManage.Print;
using ynhrMemberManage.Common;
using ynhrMemberManage.BusinessFacade;
namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for UseProduct.
	/// </summary>
    public class UseProduct : frmBase
	{
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.Printing.UltraPrintDocument ultraPrintDocument1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQMemberName;
		private Infragistics.Win.Misc.UltraLabel ultraLabel8;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQPaperNo;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQMemberCardNo;
		private Infragistics.Win.Misc.UltraLabel ultraLabel10;
		private Infragistics.Win.Misc.UltraButton btnQuery;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.ComponentModel.IContainer components;
		//private Member pMember = null;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkIsMember;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid2;
		private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox1;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
		private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox2;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel2;
		private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox3;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.Misc.UltraButton ultraButton2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPrepay;
		private Infragistics.Win.Misc.UltraButton btnPrepay;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		public static bool IsShowing ;

		public UseProduct()
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
            this.components = new System.ComponentModel.Container();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraPrintDocument1 = new Infragistics.Win.Printing.UltraPrintDocument(this.components);
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.chkIsMember = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtQMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.txtQPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.txtQMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.btnQuery = new Infragistics.Win.Misc.UltraButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ultraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraExpandableGroupBox1 = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.ultraExpandableGroupBox2 = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel2 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.ultraExpandableGroupBox3 = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel3 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.btnPrepay = new Infragistics.Win.Misc.UltraButton();
            this.txtPrepay = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.txtPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).BeginInit();
            this.ultraExpandableGroupBox1.SuspendLayout();
            this.ultraExpandableGroupBoxPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox2)).BeginInit();
            this.ultraExpandableGroupBox2.SuspendLayout();
            this.ultraExpandableGroupBoxPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox3)).BeginInit();
            this.ultraExpandableGroupBox3.SuspendLayout();
            this.ultraExpandableGroupBoxPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrepay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Location = new System.Drawing.Point(152, 32);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(256, 56);
            this.ultraGrid1.TabIndex = 0;
            this.ultraGrid1.Text = "查询结果";
            this.ultraGrid1.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.ultraGrid1_ClickCellButton);
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            this.ultraGrid1.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.ultraGrid1_AfterSelectChange);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.chkIsMember);
            this.ultraGroupBox2.Controls.Add(this.txtQMemberName);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel8);
            this.ultraGroupBox2.Controls.Add(this.txtQPaperNo);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel9);
            this.ultraGroupBox2.Controls.Add(this.txtQMemberCardNo);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel10);
            this.ultraGroupBox2.Controls.Add(this.btnQuery);
            this.ultraGroupBox2.Location = new System.Drawing.Point(152, 8);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(640, 88);
            this.ultraGroupBox2.TabIndex = 5;
            // 
            // chkIsMember
            // 
            this.chkIsMember.Checked = true;
            this.chkIsMember.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsMember.Location = new System.Drawing.Point(288, 48);
            this.chkIsMember.Name = "chkIsMember";
            this.chkIsMember.Size = new System.Drawing.Size(88, 20);
            this.chkIsMember.TabIndex = 12;
            this.chkIsMember.Text = "是否会员";
            this.chkIsMember.CheckedChanged += new System.EventHandler(this.chkIsMember_CheckedChanged);
            // 
            // txtQMemberName
            // 
            this.txtQMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQMemberName.Location = new System.Drawing.Point(152, 48);
            this.txtQMemberName.Name = "txtQMemberName";
            this.txtQMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtQMemberName.TabIndex = 9;
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.Location = new System.Drawing.Point(48, 48);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel8.TabIndex = 8;
            this.ultraLabel8.Text = "单位名称：";
            // 
            // txtQPaperNo
            // 
            this.txtQPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQPaperNo.Location = new System.Drawing.Point(392, 16);
            this.txtQPaperNo.Name = "txtQPaperNo";
            this.txtQPaperNo.Size = new System.Drawing.Size(100, 21);
            this.txtQPaperNo.TabIndex = 11;
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.Location = new System.Drawing.Point(288, 16);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel9.TabIndex = 10;
            this.ultraLabel9.Text = "工商注册号：";
            // 
            // txtQMemberCardNo
            // 
            this.txtQMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQMemberCardNo.Location = new System.Drawing.Point(152, 17);
            this.txtQMemberCardNo.MaxLength = 8;
            this.txtQMemberCardNo.Name = "txtQMemberCardNo";
            this.txtQMemberCardNo.Size = new System.Drawing.Size(100, 21);
            this.txtQMemberCardNo.TabIndex = 7;
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.Location = new System.Drawing.Point(48, 16);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel10.TabIndex = 6;
            this.ultraLabel10.Text = "会员卡号：";
            // 
            // btnQuery
            // 
            this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnQuery.Location = new System.Drawing.Point(392, 48);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(96, 23);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ultraGrid2
            // 
            this.ultraGrid2.Location = new System.Drawing.Point(80, 48);
            this.ultraGrid2.Name = "ultraGrid2";
            this.ultraGrid2.Size = new System.Drawing.Size(256, 56);
            this.ultraGrid2.TabIndex = 1;
            this.ultraGrid2.Text = "服务产品";
            this.ultraGrid2.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid2_InitializeLayout);
            this.ultraGrid2.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ultraGrid2_InitializeRow);
            // 
            // ultraExpandableGroupBox1
            // 
            this.ultraExpandableGroupBox1.Controls.Add(this.ultraExpandableGroupBoxPanel1);
            this.ultraExpandableGroupBox1.Expanded = false;
            this.ultraExpandableGroupBox1.ExpandedSize = new System.Drawing.Size(768, 344);
            this.ultraExpandableGroupBox1.Location = new System.Drawing.Point(160, 120);
            this.ultraExpandableGroupBox1.Name = "ultraExpandableGroupBox1";
            this.ultraExpandableGroupBox1.Size = new System.Drawing.Size(768, 21);
            this.ultraExpandableGroupBox1.TabIndex = 6;
            this.ultraExpandableGroupBox1.Text = "查询结果";
            this.ultraExpandableGroupBox1.ExpandedStateChanged += new System.EventHandler(this.ultraExpandableGroupBox1_ExpandedStateChanged);
            // 
            // ultraExpandableGroupBoxPanel1
            // 
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraGrid1);
            this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
            this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(208, 108);
            this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
            this.ultraExpandableGroupBoxPanel1.Visible = false;
            // 
            // ultraExpandableGroupBox2
            // 
            this.ultraExpandableGroupBox2.Controls.Add(this.ultraExpandableGroupBoxPanel2);
            this.ultraExpandableGroupBox2.Expanded = false;
            this.ultraExpandableGroupBox2.ExpandedSize = new System.Drawing.Size(776, 312);
            this.ultraExpandableGroupBox2.Location = new System.Drawing.Point(160, 152);
            this.ultraExpandableGroupBox2.Name = "ultraExpandableGroupBox2";
            this.ultraExpandableGroupBox2.Size = new System.Drawing.Size(776, 21);
            this.ultraExpandableGroupBox2.TabIndex = 7;
            this.ultraExpandableGroupBox2.Text = "服务产品";
            this.ultraExpandableGroupBox2.ExpandedStateChanged += new System.EventHandler(this.ultraExpandableGroupBox2_ExpandedStateChanged);
            // 
            // ultraExpandableGroupBoxPanel2
            // 
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraGrid2);
            this.ultraExpandableGroupBoxPanel2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraExpandableGroupBoxPanel2.Name = "ultraExpandableGroupBoxPanel2";
            this.ultraExpandableGroupBoxPanel2.Size = new System.Drawing.Size(208, 108);
            this.ultraExpandableGroupBoxPanel2.TabIndex = 0;
            this.ultraExpandableGroupBoxPanel2.Visible = false;
            // 
            // ultraExpandableGroupBox3
            // 
            this.ultraExpandableGroupBox3.Controls.Add(this.ultraExpandableGroupBoxPanel3);
            this.ultraExpandableGroupBox3.ExpandedSize = new System.Drawing.Size(656, 120);
            this.ultraExpandableGroupBox3.Location = new System.Drawing.Point(152, 480);
            this.ultraExpandableGroupBox3.Name = "ultraExpandableGroupBox3";
            this.ultraExpandableGroupBox3.Size = new System.Drawing.Size(656, 120);
            this.ultraExpandableGroupBox3.TabIndex = 8;
            this.ultraExpandableGroupBox3.Text = "ultraExpandableGroupBox3";
            // 
            // ultraExpandableGroupBoxPanel3
            // 
            this.ultraExpandableGroupBoxPanel3.Controls.Add(this.btnPrepay);
            this.ultraExpandableGroupBoxPanel3.Controls.Add(this.txtPrepay);
            this.ultraExpandableGroupBoxPanel3.Controls.Add(this.ultraButton2);
            this.ultraExpandableGroupBoxPanel3.Controls.Add(this.txtMemberName);
            this.ultraExpandableGroupBoxPanel3.Controls.Add(this.ultraLabel1);
            this.ultraExpandableGroupBoxPanel3.Controls.Add(this.txtPaperNo);
            this.ultraExpandableGroupBoxPanel3.Controls.Add(this.ultraLabel2);
            this.ultraExpandableGroupBoxPanel3.Controls.Add(this.txtMemberCardNo);
            this.ultraExpandableGroupBoxPanel3.Controls.Add(this.ultraLabel3);
            this.ultraExpandableGroupBoxPanel3.Controls.Add(this.ultraButton1);
            this.ultraExpandableGroupBoxPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel3.Location = new System.Drawing.Point(3, 19);
            this.ultraExpandableGroupBoxPanel3.Name = "ultraExpandableGroupBoxPanel3";
            this.ultraExpandableGroupBoxPanel3.Size = new System.Drawing.Size(650, 98);
            this.ultraExpandableGroupBoxPanel3.TabIndex = 0;
            // 
            // btnPrepay
            // 
            this.btnPrepay.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnPrepay.Location = new System.Drawing.Point(352, 56);
            this.btnPrepay.Name = "btnPrepay";
            this.btnPrepay.Size = new System.Drawing.Size(72, 23);
            this.btnPrepay.TabIndex = 22;
            this.btnPrepay.Text = "实收合计";
            this.btnPrepay.Click += new System.EventHandler(this.btnPrepay_Click);
            // 
            // txtPrepay
            // 
            this.txtPrepay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPrepay.Location = new System.Drawing.Point(448, 56);
            this.txtPrepay.Name = "txtPrepay";
            this.txtPrepay.Size = new System.Drawing.Size(100, 21);
            this.txtPrepay.TabIndex = 21;
            // 
            // ultraButton2
            // 
            this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton2.Location = new System.Drawing.Point(560, 56);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(72, 23);
            this.ultraButton2.TabIndex = 19;
            this.ultraButton2.Text = "取消";
            // 
            // txtMemberName
            // 
            this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberName.Enabled = false;
            this.txtMemberName.Location = new System.Drawing.Point(207, 54);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtMemberName.TabIndex = 16;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(103, 54);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 15;
            this.ultraLabel1.Text = "单位名称：";
            // 
            // txtPaperNo
            // 
            this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPaperNo.Enabled = false;
            this.txtPaperNo.Location = new System.Drawing.Point(447, 22);
            this.txtPaperNo.Name = "txtPaperNo";
            this.txtPaperNo.Size = new System.Drawing.Size(100, 21);
            this.txtPaperNo.TabIndex = 18;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(343, 22);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 17;
            this.ultraLabel2.Text = "工商注册号：";
            // 
            // txtMemberCardNo
            // 
            this.txtMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberCardNo.Enabled = false;
            this.txtMemberCardNo.Location = new System.Drawing.Point(207, 23);
            this.txtMemberCardNo.MaxLength = 8;
            this.txtMemberCardNo.Name = "txtMemberCardNo";
            this.txtMemberCardNo.Size = new System.Drawing.Size(100, 21);
            this.txtMemberCardNo.TabIndex = 14;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(103, 22);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 13;
            this.ultraLabel3.Text = "会员卡号：";
            // 
            // ultraButton1
            // 
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton1.Location = new System.Drawing.Point(560, 24);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(72, 23);
            this.ultraButton1.TabIndex = 12;
            this.ultraButton1.Text = "确定";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // UseProduct
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(952, 621);
            this.Controls.Add(this.ultraExpandableGroupBox3);
            this.Controls.Add(this.ultraExpandableGroupBox2);
            this.Controls.Add(this.ultraExpandableGroupBox1);
            this.Controls.Add(this.ultraGroupBox2);
            this.Name = "UseProduct";
            this.Text = Login.constApp.strCardTypeL8Name + "服务产品消费";
            this.Load += new System.EventHandler(this.UseProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).EndInit();
            this.ultraExpandableGroupBox1.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox2)).EndInit();
            this.ultraExpandableGroupBox2.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox3)).EndInit();
            this.ultraExpandableGroupBox3.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel3.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrepay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void UseProduct_Load(object sender, System.EventArgs e)
		{
			this.ultraGrid1.Dock       = DockStyle.Fill;
			Helper.SetTextBox(txtPrepay,"Prepay");
//			this.ultraGroupBox3.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
//			this.ultraGroupBox3.BringToFront();
			//Helper.BindProduct(cmbProduct);
			//this.btnProduct.Enabled = false;

			this.ultraGrid2.Dock = DockStyle.Fill;			
			chkIsMember_CheckedChanged(null,null);
		
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//查询
			try
			{
				//string strDateNow = DateTime.Now.ToString("yyyy-MM-dd");
				string strSql = "";
				string strProductSql = "";
				if (chkIsMember.Checked)
				{
					//会员
					strSql = "select cnvcMemberCardNo,cnvcMemberName,cnvcPaperNo from tbMember where cnvcState='"+ConstApp.Card_State_InUse+"'";
					strProductSql = "select a.cnvcMemberCardNo,a.cnvcMemberName,a.cnvcPaperNo,a.cnvcProductName,a.cnvcFree,1 as cnnCount,'消费产品' as cnvcConsume from tbMemberProduct a"
								  + " join tbMember b on a.cnvcMemberCardNo = b.cnvcMemberCardNo and b.cnvcState='"+ConstApp.Card_State_InUse+"' where 1=1";
					if (txtQMemberCardNo.Text.Length > 0)
					{
						strSql += " and cnvcMemberCardNo like '%"+txtQMemberCardNo.Text+"%'";
						strProductSql += " and a.cnvcMemberCardNo like '%"+txtQMemberCardNo.Text+"%'";
					}
					if (txtQPaperNo.Text.Length > 0)
					{
						strSql += " and cnvcPaperNo like '%"+txtQPaperNo.Text+"%'";
						strProductSql += " and a.cnvcPaperNo like '%"+txtQPaperNo.Text+"%'";
					}
					if (txtQMemberName.Text.Length > 0)
					{
						strSql += " and cnvcMemberName like '%"+txtQMemberName.Text+"%'";
						strProductSql += " and a.cnvcMemberName like '%"+txtQMemberName.Text+"%'";
					}
					
				}
				else
				{
					//非会员
					strSql = "select cnvcMemberName,cnvcPaperNo from tbFMember where 1=1";
					strProductSql = "select a.cnvcMemberName,a.cnvcPaperNo,a.cnvcProductName,a.cnvcFree,1 as cnnCount,'消费产品' as cnvcConsume from tbFMemberProduct a join tbFmember b on a.cnvcPaperNo=b.cnvcPaperNo where 1=1";
					if (txtQPaperNo.Text.Length > 0)
					{
						strSql += " and cnvcPaperNo like '%"+txtQPaperNo.Text+"%'";
						strProductSql += " and a.cnvcPaperNo like '%"+txtQPaperNo.Text+"%'";
					}
					if (txtQMemberName.Text.Length > 0)
					{
						strSql += " and cnvcMemberName like '%"+txtQMemberName.Text+"%'";
						strProductSql += " and a.cnvcMemberName like '%"+txtQMemberName.Text+"%'";
					}
				}
				
				DataTable dtMember = Helper.Query(strSql);
				dtMember.TableName = "tbMember";
				DataTable dtProduct = Helper.Query(strProductSql);
				dtProduct.TableName = "tbProduct";
				//DataTable dtAllProduct = Helper.BindProduct();
//				dtAllProduct.TableName = "tbAllProduct";
				DataSet ds = new DataSet();
				ds.Tables.Add(dtMember);
				ds.Tables.Add(dtProduct);
				if (chkIsMember.Checked)
				{
										
					ds.Relations.Add("Member-Product",ds.Tables["tbMember"].Columns["cnvcMemberCardNo"],ds.Tables["tbProduct"].Columns["cnvcMemberCardNo"]);					
				}
				else
				{
					ds.Relations.Add("Member-Product",ds.Tables["tbMember"].Columns["cnvcPaperNo"],ds.Tables["tbProduct"].Columns["cnvcPaperNo"]);
				}
				//ds.Relations.Add()
				this.ultraGrid1.DataSource = null;
				//this.ultraGrid1.DataSource = ds;//dtMember;
				this.ultraGrid1.SetDataBinding(ds,null);

				this.ultraExpandableGroupBox1.Expanded = true;
				this.ultraGrid2.DataSource = null;
				Helper.BindProduct(this.ultraGrid2);

//				txtMemberCardNo.Text = "";
//				txtMemberName.Text = "";
//				txtPaperNo.Text = "";
//				txtFree.Text = "";
//				//txtFree.Text = "";
//
//				btnProduct.Enabled = false;
				
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

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			//Helper.SetGridDisplay(e);
			//Infragistics.Win.UltraWinGrid.UltraGridColumn uc = new UltraGridColumn()
			//Infragistics.Shared.IKeyedSubObject ik = Infragistics.Win.UltraWinGrid.UltraGridColumn
			//e.Layout.Bands[0].Columns.Contains()

			//Helper.SetGridDisplay(e);
			//
			//Helper.SetGridDisplay(e);
			e.Layout.ScrollBounds = ScrollBounds.ScrollToFill; 
			//e.Layout.Override.CellClickAction = CellClickAction.;
			e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;//UltraWinGrid.SelectType.Single;

			e.Layout.Bands[0].Override.SummaryFooterCaptionAppearance.FontData.Bold = DefaultableBoolean.True; 
			e.Layout.Bands[0].Override.SummaryValueAppearance.BackColor = Color.White;
			e.Layout.Bands[0].Override.SummaryValueAppearance.TextHAlign = HAlign.Right;
			e.Layout.Bands[0].Override.SummaryFooterCaptionAppearance.BackColor = Color.White;

			e.Layout.Bands[1].Override.SummaryFooterCaptionAppearance.FontData.Bold = DefaultableBoolean.True; 
			e.Layout.Bands[1].Override.SummaryValueAppearance.BackColor = Color.White;
			e.Layout.Bands[1].Override.SummaryValueAppearance.TextHAlign = HAlign.Right;
			e.Layout.Bands[1].Override.SummaryFooterCaptionAppearance.BackColor = Color.White;

			foreach (UltraGridColumn  col in e.Layout.Bands[0].Columns)
			{
				col.CellActivation = Activation.NoEdit;
			}

			foreach (UltraGridColumn  col in e.Layout.Bands[1].Columns)
			{
				col.CellActivation = Activation.NoEdit;
			}

			
			if (e.Layout.Bands[0].Columns[0].Key == "cnvcMemberCardNo")
			{
				e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "会员卡号";
			}			
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";

			if (e.Layout.Bands[1].Columns[0].Key == "cnvcMemberCardNo")
			{
				e.Layout.Bands[1].Columns["cnvcMemberCardNo"].Header.Caption = "会员卡号";
			}	
			e.Layout.Bands[1].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[1].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[1].Columns["cnvcProductName"].Header.Caption = "产品名称";
			e.Layout.Bands[1].Columns["cnvcFree"].Header.Caption = "场次";
			e.Layout.Bands[1].Columns["cnnCount"].Header.Caption = "次数";
			e.Layout.Bands[1].Columns["cnnCount"].CellActivation = Activation.AllowEdit;
			e.Layout.Bands[1].Columns["cnvcConsume"].Header.Caption = "消费";

			e.Layout.Bands[1].Columns["cnvcConsume"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
		}

		private void ultraGrid1_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			UltraGridRow row = this.ultraGrid1.ActiveRow;
			if (row != null)
			{
				
				if (row.Cells.Exists("cnvcMemberCardNo"))
				{
					txtMemberCardNo.Text = row.Cells["cnvcMemberCardNo"].Value.ToString();
				}
				else
				{
					txtMemberCardNo.Text = "";
				}
				txtMemberName.Text = row.Cells["cnvcMemberName"].Value.ToString();
				txtPaperNo.Text = row.Cells["cnvcPaperNo"].Value.ToString();

			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

//		private void ultraPrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
//		{
//			Font drawFontTitle = new Font("Arial", 14);
//			Font drawFontBody = new Font("Arial", 8);
//			SolidBrush drawBrush = new SolidBrush(Color.Black);			
//
//			StringFormat drawFormat = new StringFormat();
//			drawFormat.FormatFlags = StringFormatFlags.DisplayFormatControl;
//			e.Graphics.DrawString("云南人才市场", drawFontTitle, drawBrush, 50.0f, 40.0f, drawFormat);
//			e.Graphics.DrawLine(new Pen(drawBrush,1.0f),0.0f,68.0f,300.0f,68.0f);
//			e.Graphics.DrawString("会员卡号：", drawFontBody, drawBrush, 35.0f, 70.0F, drawFormat);
//			e.Graphics.DrawString(pMember.cnvcMemberCardNo, drawFontBody, drawBrush, 115.0f, 70.0F, drawFormat);
//			e.Graphics.DrawString("服务产品：", drawFontBody, drawBrush, 35.0f, 85.0F, drawFormat);
//			e.Graphics.DrawString(pMember.cnvcProduct, drawFontBody, drawBrush, 115.0f, 85.0F, drawFormat);
//			e.Graphics.DrawLine(new Pen(drawBrush,1.0f),0.0f,100.0f,300.0f,100.0f);
//			e.Graphics.DrawString("操作员：", drawFontBody, drawBrush, 35.0f, 100.0F, drawFormat);
//			e.Graphics.DrawString(pMember.cnvcOperName, drawFontBody, drawBrush, 115.0f, 100.0F, drawFormat);
//
//			e.Graphics.DrawString("操作时间："+DateTime.Now.ToShortDateString(), drawFontBody, drawBrush, 35.0f, 115.0F, drawFormat);
		//}

		private void ultraExpandableGroupBox1_ExpandedStateChanged(object sender, System.EventArgs e)
		{
			if (this.ultraExpandableGroupBox1.Expanded)
			{
				this.ultraExpandableGroupBox2.Visible = false;
				this.ultraExpandableGroupBox3.Visible = true;
			}
			else
			{
				this.ultraExpandableGroupBox2.Visible = true;
				if (this.ultraExpandableGroupBox2.Expanded)
				{
					this.ultraExpandableGroupBox3.Visible = true;
				}
				else
				{
					this.ultraExpandableGroupBox3.Visible = false;
				}
			}
			
		}

		private void ultraExpandableGroupBox2_ExpandedStateChanged(object sender, System.EventArgs e)
		{
			if (this.ultraExpandableGroupBox2.Expanded)
			{
				this.ultraExpandableGroupBox3.Visible = true;
			}
			else
			{
				this.ultraExpandableGroupBox3.Visible = false;
			}
		}

		private void chkIsMember_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkIsMember.Checked)
			{
				this.ultraExpandableGroupBox3.Text = "会员服务产品充值";
				this.ultraLabel3.Visible = true;
				this.txtMemberCardNo.Visible = true;
			} 
			else
			{
				this.ultraExpandableGroupBox3.Text = "非会员服务产品缴费";
				this.ultraLabel3.Visible = false;
				this.txtMemberCardNo.Visible = false;
			}
		}

		private void ultraGrid2_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			e.Layout.Bands[0].Columns["cnvcProductName"].CellActivation = Activation.NoEdit;
			e.Layout.Bands[0].Columns["cnnProductPrice"].CellActivation = Activation.NoEdit;
			e.Layout.Bands[0].Columns["cnvcIsSelected"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;

			e.Layout.Bands[0].Columns["cnvcIsSelected"].Header.Caption = "选择";
			e.Layout.Bands[0].Columns["cnvcProductName"].Header.Caption = "产品名称";
			e.Layout.Bands[0].Columns["cnnProductPrice"].Header.Caption = "产品单价";
			e.Layout.Bands[0].Columns["cnnProductDiscount"].Header.Caption = "产品折扣";
			e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "实收";
			e.Layout.Bands[0].Columns["cnvcFree"].Header.Caption = "场次";
		}

		private void ultraGrid2_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
		{
			EmbeddableEditorBase editor = null;
			DefaultEditorOwnerSettings editorSettings = null;

			editorSettings = new DefaultEditorOwnerSettings( );
			editorSettings.DataType = typeof( int );
			editor = new EditorWithMask( new DefaultEditorOwner( editorSettings ) );
			editorSettings.MaskInput = "nnn";
			e.Row.Cells[ "cnnProductDiscount" ].Editor = editor;

			editorSettings = new DefaultEditorOwnerSettings( );
			editorSettings.DataType = typeof( int );
			editor = new EditorWithMask( new DefaultEditorOwner( editorSettings ) );
			editorSettings.MaskInput = "nnnnnnnn";
			e.Row.Cells[ "cnnPrepay" ].Editor = editor;
			
			editorSettings = new DefaultEditorOwnerSettings( );
			editorSettings.DataType = typeof( int );
			editor = new EditorWithMask( new DefaultEditorOwner( editorSettings ) );
			editorSettings.MaskInput = "nnnn";
			e.Row.Cells[ "cnvcFree" ].Editor = editor;
		}

		private void btnPrepay_Click(object sender, System.EventArgs e)
		{
			//ColumnStyle.CheckBox
			int iPrepay = 0;
			foreach (UltraGridRow row in this.ultraGrid2.Rows)
			{
				//row.Cells[""].Style
				//UltraCheckEditor chk = (UltraCheckEditor)row.Cells["cnvcIsSelected"].Value;
				string strSelected = row.Cells["cnvcIsSelected"].Value.ToString();
				bool   bSelected = bool.Parse(strSelected);
				if (bSelected)
				{
					string strPrepay = row.Cells["cnnPrepay"].Value.ToString();
					iPrepay += int.Parse(strPrepay);
				}
			}
			txtPrepay.Text = iPrepay.ToString();
		}

		private void ultraGrid1_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			try
			{								
				string strMsg = "";
				Product p = new Product();
				
				if (e.Cell.Row.Cells.Exists("cnvcMemberCardNo"))
				{
					p.cnvcMemberCardNo = e.Cell.Row.Cells["cnvcMemberCardNo"].Value.ToString();
					strMsg += "【会员卡号："+p.cnvcMemberCardNo+"】\n";
				}
				
				p.cnvcPaperNo = e.Cell.Row.Cells["cnvcPaperNo"].Value.ToString();
				p.cnvcMemberName = e.Cell.Row.Cells["cnvcMemberName"].Value.ToString();
				p.cnvcProduct = e.Cell.Row.Cells["cnvcProductName"].Value.ToString();
				int iCount = int.Parse(e.Cell.Row.Cells["cnnCount"].Value.ToString());
				strMsg += "【单位名称："+p.cnvcMemberName+"】\n【工商注册号："+p.cnvcPaperNo+"】\n【服务产品："+p.cnvcProduct+"】\n【消费次数："+iCount.ToString()+"】";
				p.cnvcOperName = this.oper.cnvcOperName;
				p.cndOperDate = DateTime.Now;
				DialogResult dr2 = MessageBox.Show(this,strMsg,"服务产品消费信息确认",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if (dr2 == DialogResult.Yes)
				{
					PrintedBill pBill = new PrintedBill(p.ToTable());
					pBill.cnvcBillType = ConstApp.Bill_Type_Product_Use;
					pBill.cnvcProduct = p.cnvcProduct+",,,,"+iCount.ToString()+",";
                    MemberManageFacade memberManage = new MemberManageFacade();
					PrintedBill retBill = memberManage.UserProduct(p,pBill,iCount);
					Helper.PrintTicket(retBill);
					//pMember = new Member(p.ToTable());
					//this.ultraPrintDocument1.Print();
					this.btnQuery_Click(null,null);
				}
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
			//充值缴费
			try
			{
				UltraGridRow row = this.ultraGrid1.ActiveRow;
				if (null == row)
				{
					throw new BusinessException("服务产品消费","请选择会员或者非会员");
				}
				ArrayList alProduct = new ArrayList();
				PrintedBill pBill = new PrintedBill();
				string strProduct = "";
				if (txtMemberCardNo.Text == "")
				{
					//非会员					
					foreach (UltraGridRow selRow in this.ultraGrid2.Rows)
					{
						string strSelected = selRow.Cells["cnvcIsSelected"].Value.ToString();
						bool   bSelected = bool.Parse(strSelected);
						if (bSelected)
						{
							FMemberProductLog productLog = new FMemberProductLog();
							productLog.cndOperDate = DateTime.Now;
							productLog.cnvcOperName = this.oper.cnvcOperName;
							productLog.cnvcPaperNo = txtPaperNo.Text;
							productLog.cnvcMemberName = txtMemberName.Text;
							productLog.cnvcProductName = selRow.Cells["cnvcProductName"].Value.ToString();
							productLog.cnnProductPrice = Decimal.Parse(selRow.Cells["cnnProductPrice"].Value.ToString());
							productLog.cnvcProductDiscount = selRow.Cells["cnnProductDiscount"].Value.ToString();
							productLog.cnnPrepay = Decimal.Parse(selRow.Cells["cnnPrepay"].Value.ToString());
							productLog.cnvcFree = selRow.Cells["cnvcFree"].Value.ToString();
							alProduct.Add(productLog);
							strProduct += productLog.cnvcProductName+","+productLog.cnnProductPrice.ToString()+","+productLog.cnvcProductDiscount+","+productLog.cnnPrepay+","+productLog.cnvcFree+",|";
						}
					}
					if (alProduct.Count < 1)
					{
						throw new BusinessException("服务产品消费","请选择充值产品");
					}
					if (txtPrepay.Text != "")
					{
						pBill.cnnPrepay = Decimal.Parse(txtPrepay.Text);
					}
					pBill.cndOperDate = DateTime.Now;
					pBill.cnvcOperName = this.oper.cnvcOperName;
					pBill.cnvcPaperNo = txtPaperNo.Text;
					pBill.cnvcMemberName = txtMemberName.Text;
					pBill.cnvcProduct = strProduct;
					pBill.cnvcBillType = ConstApp.Bill_Type_Product_Consume;
                    MemberManageFacade mm = new MemberManageFacade();
					mm.ConsumeProduct(alProduct,false,"",pBill);
					
				}
				else
				{
					//会员
					foreach (UltraGridRow selRow in this.ultraGrid2.Rows)
					{
						string strSelected = selRow.Cells["cnvcIsSelected"].Value.ToString();
						bool   bSelected = bool.Parse(strSelected);
						if (bSelected)
						{
							MemberProductLog productLog = new MemberProductLog();
							productLog.cndOperDate = DateTime.Now;
							productLog.cnvcOperName = this.oper.cnvcOperName;
							productLog.cnvcMemberCardNo = txtMemberCardNo.Text;
							productLog.cnvcPaperNo = txtPaperNo.Text;
							productLog.cnvcMemberName = txtMemberName.Text;
							productLog.cnvcProductName = selRow.Cells["cnvcProductName"].Value.ToString();
							productLog.cnnProductPrice = Decimal.Parse(selRow.Cells["cnnProductPrice"].Value.ToString());
							productLog.cnvcProductDiscount = selRow.Cells["cnnProductDiscount"].Value.ToString();
							productLog.cnnPrepay = Decimal.Parse(selRow.Cells["cnnPrepay"].Value.ToString());
							productLog.cnvcFree = selRow.Cells["cnvcFree"].Value.ToString();
							alProduct.Add(productLog);
							strProduct += productLog.cnvcProductName+","+productLog.cnnProductPrice.ToString()+","+productLog.cnvcProductDiscount+","+productLog.cnnPrepay+","+productLog.cnvcFree+",|";
						}
					}
					if (alProduct.Count < 1)
					{
						throw new BusinessException("服务产品消费","请选择充值产品");
					}
					
					if (txtPrepay.Text != "")
					{
						pBill.cnnPrepay = Decimal.Parse(txtPrepay.Text);
					}
					pBill.cndOperDate = DateTime.Now;
					pBill.cnvcOperName = this.oper.cnvcOperName;
					pBill.cnvcMemberCardNo = txtMemberCardNo.Text;
					pBill.cnvcPaperNo = txtPaperNo.Text;
					pBill.cnvcMemberName = txtMemberName.Text;
					pBill.cnvcProduct = strProduct;
					pBill.cnvcBillType = ConstApp.Bill_Type_Product_Consume;
                    MemberManageFacade mm = new MemberManageFacade();
					mm.ConsumeProduct(alProduct,true,"",pBill);
				}
				Helper.PrintTicket(pBill);	
				this.btnQuery_Click(null,null);
				MessageBox.Show(this,"充值缴费成功！","服务产品消费");
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
