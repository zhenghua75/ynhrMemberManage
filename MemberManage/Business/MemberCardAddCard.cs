using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using System.Data;
using System.Data.SqlClient;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Text.RegularExpressions;
using ynhrMemberManage.Print;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Common;
namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for MemberCardAddCard.
	/// </summary>
    public class MemberCardAddCard : frmBase
	{
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private IContainer components;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraButton btnQuery;
		private Infragistics.Win.Misc.UltraButton btnAddCard;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtFree;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQMemberCardNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQPaperNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		private Infragistics.Win.Misc.UltraLabel ultraLabel8;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtNewMemberCardNo;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCost;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		public static bool IsShowing ;
		public MemberCardAddCard()
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
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.txtQMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtQPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnQuery = new Infragistics.Win.Misc.UltraButton();
            this.txtQMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.btnAddCard = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtCost = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.txtNewMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtFree = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.txtPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewMemberCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Location = new System.Drawing.Point(88, 48);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(224, 64);
            this.ultraGrid1.TabIndex = 0;
            this.ultraGrid1.Text = "已挂失会员卡";
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            this.ultraGrid1.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.ultraGrid1_AfterSelectChange);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(8, 32);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 1;
            this.ultraLabel1.Text = "会员卡号：";
            // 
            // txtQMemberCardNo
            // 
            this.txtQMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQMemberCardNo.Location = new System.Drawing.Point(136, 32);
            this.txtQMemberCardNo.MaxLength = 8;
            this.txtQMemberCardNo.Name = "txtQMemberCardNo";
            this.txtQMemberCardNo.Size = new System.Drawing.Size(100, 21);
            this.txtQMemberCardNo.TabIndex = 2;
            // 
            // txtQPaperNo
            // 
            this.txtQPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQPaperNo.Location = new System.Drawing.Point(136, 72);
            this.txtQPaperNo.Name = "txtQPaperNo";
            this.txtQPaperNo.Size = new System.Drawing.Size(100, 21);
            this.txtQPaperNo.TabIndex = 4;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(8, 72);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 3;
            this.ultraLabel2.Text = "工商注册号：";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.btnQuery);
            this.ultraGroupBox1.Controls.Add(this.txtQMemberName);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox1.Controls.Add(this.txtQMemberCardNo);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox1.Controls.Add(this.txtQPaperNo);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox1.Location = new System.Drawing.Point(200, 72);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(616, 112);
            this.ultraGroupBox1.TabIndex = 5;
            this.ultraGroupBox1.Text = "已挂失会员卡查询";
            // 
            // btnQuery
            // 
            this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnQuery.Location = new System.Drawing.Point(296, 72);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // txtQMemberName
            // 
            this.txtQMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQMemberName.Location = new System.Drawing.Point(408, 32);
            this.txtQMemberName.Name = "txtQMemberName";
            this.txtQMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtQMemberName.TabIndex = 6;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(280, 32);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 5;
            this.ultraLabel3.Text = "单位名称：";
            // 
            // btnAddCard
            // 
            this.btnAddCard.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnAddCard.Location = new System.Drawing.Point(56, 224);
            this.btnAddCard.Name = "btnAddCard";
            this.btnAddCard.Size = new System.Drawing.Size(72, 23);
            this.btnAddCard.TabIndex = 8;
            this.btnAddCard.Text = "补卡";
            this.btnAddCard.Click += new System.EventHandler(this.btnAddCard_Click);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.txtCost);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel9);
            this.ultraGroupBox2.Controls.Add(this.btnCancel);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel8);
            this.ultraGroupBox2.Controls.Add(this.txtNewMemberCardNo);
            this.ultraGroupBox2.Controls.Add(this.txtFree);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox2.Controls.Add(this.txtMemberName);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox2.Controls.Add(this.txtPaperNo);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel6);
            this.ultraGroupBox2.Controls.Add(this.txtMemberCardNo);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel7);
            this.ultraGroupBox2.Controls.Add(this.btnAddCard);
            this.ultraGroupBox2.Location = new System.Drawing.Point(720, 200);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(272, 264);
            this.ultraGroupBox2.TabIndex = 9;
            this.ultraGroupBox2.Text = "补卡操作";
            // 
            // txtCost
            // 
            this.txtCost.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtCost.Location = new System.Drawing.Point(138, 192);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(100, 21);
            this.txtCost.TabIndex = 24;
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.Location = new System.Drawing.Point(34, 192);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel9.TabIndex = 23;
            this.ultraLabel9.Text = "工本费：";
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnCancel.Location = new System.Drawing.Point(152, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.Location = new System.Drawing.Point(32, 64);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel8.TabIndex = 20;
            this.ultraLabel8.Text = "新会员卡号：";
            // 
            // txtNewMemberCardNo
            // 
            this.txtNewMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtNewMemberCardNo.Location = new System.Drawing.Point(136, 64);
            this.txtNewMemberCardNo.MaxLength = 8;
            this.txtNewMemberCardNo.Name = "txtNewMemberCardNo";
            this.txtNewMemberCardNo.Size = new System.Drawing.Size(100, 21);
            this.txtNewMemberCardNo.TabIndex = 21;
            // 
            // txtFree
            // 
            this.txtFree.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtFree.Enabled = false;
            this.txtFree.Location = new System.Drawing.Point(138, 160);
            this.txtFree.Name = "txtFree";
            this.txtFree.Size = new System.Drawing.Size(100, 21);
            this.txtFree.TabIndex = 19;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(34, 160);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel5.TabIndex = 18;
            this.ultraLabel5.Text = "场次：";
            // 
            // txtMemberName
            // 
            this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberName.Location = new System.Drawing.Point(138, 96);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtMemberName.TabIndex = 15;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(34, 104);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel4.TabIndex = 14;
            this.ultraLabel4.Text = "单位名称：";
            // 
            // txtPaperNo
            // 
            this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPaperNo.Location = new System.Drawing.Point(138, 128);
            this.txtPaperNo.Name = "txtPaperNo";
            this.txtPaperNo.Size = new System.Drawing.Size(100, 21);
            this.txtPaperNo.TabIndex = 17;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(34, 128);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel6.TabIndex = 16;
            this.ultraLabel6.Text = "工商注册号：";
            // 
            // txtMemberCardNo
            // 
            this.txtMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberCardNo.Location = new System.Drawing.Point(138, 32);
            this.txtMemberCardNo.MaxLength = 8;
            this.txtMemberCardNo.Name = "txtMemberCardNo";
            this.txtMemberCardNo.Size = new System.Drawing.Size(100, 21);
            this.txtMemberCardNo.TabIndex = 13;
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Location = new System.Drawing.Point(34, 32);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel7.TabIndex = 12;
            this.ultraLabel7.Text = "会员卡号：";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ultraGroupBox3
            // 
            this.ultraGroupBox3.Controls.Add(this.ultraGrid1);
            this.ultraGroupBox3.Location = new System.Drawing.Point(16, 200);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(696, 408);
            this.ultraGroupBox3.TabIndex = 10;
            // 
            // MemberCardAddCard
            // 
            this.AcceptButton = this.btnQuery;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1008, 654);
            this.Controls.Add(this.ultraGroupBox3);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "MemberCardAddCard";
            this.Text = Login.constApp.strCardTypeL8Name + "补卡";
            this.Load += new System.EventHandler(this.MemberCardAddCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewMemberCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			//查询
			try
			{
                string strSql = "select top 10 cnvcMemberCardNo,cnvcMemberName,cnvcPaperNo,cnvcMemberRight,cnvcDiscount,cnvcFree,cnnMemberFee,cnnPrepay from tbMember where Len(cnvcMemberCardNo)=8 and cnvcState='" + ConstApp.Card_State_InLose + "' and cndEndDate>=getdate()";
				if (txtQMemberCardNo.Text.Length > 0)
				{
					strSql += " and cnvcMemberCardNo like '%"+txtQMemberCardNo.Text+"%'";
				}
				if (txtQPaperNo.Text.Length > 0)
				{
					strSql += " and cnvcPaperNo like '%"+txtQPaperNo.Text+"%'";
				}
				if (txtQMemberName.Text.Length > 0)
				{
					strSql += " and cnvcMemberName like '%"+txtQMemberName.Text+"%'";
				}
				DataTable dtMember = Helper.Query(strSql);
				this.ultraGrid1.DataSource = null;
				this.ultraGrid1.DataSource = dtMember;
				this.ultraGrid1.SetDataBinding(dtMember,null);

				txtMemberCardNo.Text = "";
				txtMemberName.Text = "";
				txtPaperNo.Text = "";
				//txtInMoney.Text = "";
				txtFree.Text = "";
				txtNewMemberCardNo.Text = "";
				txtCost.Text = "";

				btnAddCard.Enabled = false;
				
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

		private void btnAddCard_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				if (txtNewMemberCardNo.Text.Trim().Length == 0 || txtNewMemberCardNo.Text.Trim().Length != 8)
				{
					throw new BusinessException("补卡","请输入新会员卡号并且是8位数字！");
				}
				string strNewMemberCardNo = txtNewMemberCardNo.Text;
				DataTable dtMember = Helper.Query("select * from tbMember where cnvcMemberCardNo = '"+strNewMemberCardNo+"'");
				if (dtMember.Rows.Count >0)
				{
					throw new BusinessException("补卡","输入的新会员卡号已存在！");
				}
				string strCost = "0";
				if (txtCost.Text.Trim().Length > 0)
				{
					strCost = txtCost.Text;
				}
				Member member = new Member();
				member.cnvcMemberCardNo = txtMemberCardNo.Text;//老会员卡号
				member.cnvcMemberName = txtNewMemberCardNo.Text;
				member.cnvcPaperNo = txtPaperNo.Text;
				member.cnvcOperName = this.oper.cnvcOperName;
				member.cndOperDate = DateTime.Now;
				member.cnnPrepay = Decimal.Parse(strCost);
                MemberManageFacade memberManage = new MemberManageFacade();
												
				PrintedBill pBill = new PrintedBill(member.ToTable());
				pBill.cnvcMemberCardNo = strNewMemberCardNo;
				pBill.cnvcOldMemberCardNo = txtMemberCardNo.Text;
				pBill.cnvcMemberName = txtMemberName.Text;
				pBill.cnvcBillType = ConstApp.Bill_Type_AddCard;
				memberManage.AddCard(member,pBill);
				DialogResult dr = MessageBox.Show(this,"补卡操作,是否继续操作","补卡成功！",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if (dr == DialogResult.Yes)
				{
					Helper.PrintTicket(pBill);
					ultraButton1_Click(null,null);
				}
				else
				{
					this.Close();
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

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e);
			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "会员卡号";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Header.Caption = "会员资格";
			e.Layout.Bands[0].Columns["cnvcDiscount"].Header.Caption = "折扣";
			e.Layout.Bands[0].Columns["cnvcFree"].Header.Caption = "场次";
			e.Layout.Bands[0].Columns["cnnMemberFee"].Header.Caption = "会员费";
			e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "实收";

			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Width = 60;
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Width = 100;
			e.Layout.Bands[0].Columns["cnvcDiscount"].Width = 30;
			e.Layout.Bands[0].Columns["cnvcFree"].Width = 60;
		}

		private void ultraGrid1_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			UltraGridRow row = this.ultraGrid1.ActiveRow;
			if (row != null)
			{
				txtMemberCardNo.Text = row.Cells["cnvcMemberCardNo"].Value.ToString();
				txtMemberName.Text = row.Cells["cnvcMemberName"].Value.ToString();
				txtPaperNo.Text = row.Cells["cnvcPaperNo"].Value.ToString();
				
				txtFree.Text = row.Cells["cnvcFree"].Value.ToString();

				btnAddCard.Enabled = true;

			}
		}

		private void MemberCardAddCard_Load(object sender, System.EventArgs e)
		{
			Helper.SetTextBox(txtNewMemberCardNo,"MemberCardNo");
			this.btnAddCard.Enabled = false;
			this.ultraGrid1.Dock       = DockStyle.Fill;
			this.ultraGroupBox3.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
			this.ultraGroupBox3.BringToFront();

			txtMemberCardNo.Enabled = false;
			txtMemberName.Enabled = false;
			txtPaperNo.Enabled = false;
			txtFree.Enabled = false;

			Helper.SetTextBox(txtCost,"Prepay");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		
	}
}
