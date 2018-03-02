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
using ynhrMemberManage.Print;
using ynhrMemberManage.BusinessFacade.MemberBusiness;
using ynhrMemberManage.Common;
using MemberManage.Business;
using ynhrMemberManage.CardCommon.CardRef;
using ynhrMemberManage.CardCommon.CardDef;
namespace MemberManage.MemberBusiness
{
	/// <summary>
	/// Summary description for MemberCardInMoney.
	/// </summary>
    public class MemberCardInMoney : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraButton btnInMoney;
		public static bool IsShowing ;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtAddMoney;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private Infragistics.Win.Printing.UltraPrintDocument ultraPrintDocument1;
        private System.ComponentModel.IContainer components;
        private Infragistics.Win.Misc.UltraButton btnCancel;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtInMoney;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtBalance;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberRight;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.Misc.UltraButton ultraButton2;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cmdEndDate;
        private Infragistics.Win.Misc.UltraLabel lblInMoney;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cmdEndDateInMoney;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbSales;
        private Infragistics.Win.Misc.UltraLabel ultraLabel20;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDiscount;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Label label1;
		private Member pMember = null;
        private string defaultDsicount = "";
		public MemberCardInMoney()
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
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDiscount = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbSales = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.cmdEndDateInMoney = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.cmdEndDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblInMoney = new Infragistics.Win.Misc.UltraLabel();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.txtMemberRight = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.txtInMoney = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.txtBalance = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.txtAddMoney = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.txtPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.btnInMoney = new Infragistics.Win.Misc.UltraButton();
            this.txtMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ultraPrintDocument1 = new Infragistics.Win.Printing.UltraPrintDocument(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEndDateInMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.cmbDiscount);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel9);
            this.ultraGroupBox1.Controls.Add(this.cmbSales);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel20);
            this.ultraGroupBox1.Controls.Add(this.cmdEndDateInMoney);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel8);
            this.ultraGroupBox1.Controls.Add(this.cmdEndDate);
            this.ultraGroupBox1.Controls.Add(this.lblInMoney);
            this.ultraGroupBox1.Controls.Add(this.ultraButton2);
            this.ultraGroupBox1.Controls.Add(this.txtMemberRight);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel7);
            this.ultraGroupBox1.Controls.Add(this.txtInMoney);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel6);
            this.ultraGroupBox1.Controls.Add(this.txtBalance);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox1.Controls.Add(this.ultraButton1);
            this.ultraGroupBox1.Controls.Add(this.btnCancel);
            this.ultraGroupBox1.Controls.Add(this.txtAddMoney);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox1.Controls.Add(this.txtMemberName);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox1.Controls.Add(this.txtPaperNo);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox1.Controls.Add(this.btnInMoney);
            this.ultraGroupBox1.Controls.Add(this.txtMemberCardNo);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(314, 65);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(462, 493);
            this.ultraGroupBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 64;
            this.label1.Text = "折";
            // 
            // cmbDiscount
            // 
            this.cmbDiscount.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbDiscount.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbDiscount.Location = new System.Drawing.Point(153, 363);
            this.cmbDiscount.Name = "cmbDiscount";
            this.cmbDiscount.Size = new System.Drawing.Size(152, 21);
            this.cmbDiscount.TabIndex = 63;
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.Location = new System.Drawing.Point(49, 363);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel9.TabIndex = 62;
            this.ultraLabel9.Text = "折扣：";
            // 
            // cmbSales
            // 
            this.cmbSales.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbSales.Location = new System.Drawing.Point(153, 332);
            this.cmbSales.Name = "cmbSales";
            this.cmbSales.Size = new System.Drawing.Size(152, 21);
            this.cmbSales.TabIndex = 61;
            // 
            // ultraLabel20
            // 
            this.ultraLabel20.Location = new System.Drawing.Point(49, 332);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel20.TabIndex = 60;
            this.ultraLabel20.Text = "销售人员：";
            // 
            // cmdEndDateInMoney
            // 
            this.cmdEndDateInMoney.BackColor = System.Drawing.SystemColors.Window;
            this.cmdEndDateInMoney.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.cmdEndDateInMoney.Format = "yyyy-MM-dd";
            this.cmdEndDateInMoney.Location = new System.Drawing.Point(152, 301);
            this.cmdEndDateInMoney.Name = "cmdEndDateInMoney";
            this.cmdEndDateInMoney.NonAutoSizeHeight = 23;
            this.cmdEndDateInMoney.Size = new System.Drawing.Size(152, 21);
            this.cmdEndDateInMoney.TabIndex = 58;
            this.cmdEndDateInMoney.Value = new System.DateTime(2013, 3, 10, 0, 0, 0, 0);
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.Location = new System.Drawing.Point(28, 299);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(124, 23);
            this.ultraLabel8.TabIndex = 59;
            this.ultraLabel8.Text = "卡使用时限(充值)：";
            // 
            // cmdEndDate
            // 
            this.cmdEndDate.BackColor = System.Drawing.SystemColors.Window;
            this.cmdEndDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.cmdEndDate.Enabled = false;
            this.cmdEndDate.Format = "yyyy-MM-dd";
            this.cmdEndDate.Location = new System.Drawing.Point(152, 201);
            this.cmdEndDate.Name = "cmdEndDate";
            this.cmdEndDate.NonAutoSizeHeight = 23;
            this.cmdEndDate.Size = new System.Drawing.Size(152, 21);
            this.cmdEndDate.TabIndex = 56;
            this.cmdEndDate.Value = new System.DateTime(2013, 3, 10, 0, 0, 0, 0);
            // 
            // lblInMoney
            // 
            this.lblInMoney.Location = new System.Drawing.Point(261, 265);
            this.lblInMoney.Name = "lblInMoney";
            this.lblInMoney.Size = new System.Drawing.Size(164, 23);
            this.lblInMoney.TabIndex = 57;
            this.lblInMoney.Text = "充值后余额：";
            // 
            // ultraButton2
            // 
            this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton2.Location = new System.Drawing.Point(350, 32);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(75, 23);
            this.ultraButton2.TabIndex = 30;
            this.ultraButton2.Text = "输入卡号";
            this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
            // 
            // txtMemberRight
            // 
            this.txtMemberRight.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberRight.Enabled = false;
            this.txtMemberRight.Location = new System.Drawing.Point(152, 125);
            this.txtMemberRight.Name = "txtMemberRight";
            this.txtMemberRight.Size = new System.Drawing.Size(100, 21);
            this.txtMemberRight.TabIndex = 29;
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Location = new System.Drawing.Point(48, 125);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel7.TabIndex = 28;
            this.ultraLabel7.Text = "会员资格：";
            // 
            // txtInMoney
            // 
            this.txtInMoney.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtInMoney.Location = new System.Drawing.Point(152, 238);
            this.txtInMoney.Name = "txtInMoney";
            this.txtInMoney.Size = new System.Drawing.Size(100, 21);
            this.txtInMoney.TabIndex = 27;
            this.txtInMoney.ValueChanged += new System.EventHandler(this.txtInMoney_ValueChanged);
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(48, 238);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel6.TabIndex = 26;
            this.ultraLabel6.Text = "充值金额：";
            // 
            // txtBalance
            // 
            this.txtBalance.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtBalance.Enabled = false;
            this.txtBalance.Location = new System.Drawing.Point(152, 168);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(100, 21);
            this.txtBalance.TabIndex = 25;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(48, 168);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel4.TabIndex = 24;
            this.ultraLabel4.Text = "当前余额：";
            // 
            // ultraButton1
            // 
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton1.Location = new System.Drawing.Point(258, 32);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 12;
            this.ultraButton1.Text = "刷卡";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnCancel.Location = new System.Drawing.Point(261, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtAddMoney
            // 
            this.txtAddMoney.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtAddMoney.Location = new System.Drawing.Point(152, 267);
            this.txtAddMoney.Name = "txtAddMoney";
            this.txtAddMoney.ReadOnly = true;
            this.txtAddMoney.Size = new System.Drawing.Size(100, 21);
            this.txtAddMoney.TabIndex = 15;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(48, 267);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel5.TabIndex = 14;
            this.ultraLabel5.Text = "赠送金额：";
            // 
            // txtMemberName
            // 
            this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberName.Enabled = false;
            this.txtMemberName.Location = new System.Drawing.Point(152, 62);
            this.txtMemberName.Multiline = true;
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(273, 21);
            this.txtMemberName.TabIndex = 3;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(48, 64);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 2;
            this.ultraLabel3.Text = "单位名称：";
            // 
            // txtPaperNo
            // 
            this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPaperNo.Enabled = false;
            this.txtPaperNo.Location = new System.Drawing.Point(152, 96);
            this.txtPaperNo.Name = "txtPaperNo";
            this.txtPaperNo.Size = new System.Drawing.Size(273, 21);
            this.txtPaperNo.TabIndex = 5;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(48, 96);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 4;
            this.ultraLabel2.Text = "工商注册号：";
            // 
            // btnInMoney
            // 
            this.btnInMoney.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnInMoney.Location = new System.Drawing.Point(152, 403);
            this.btnInMoney.Name = "btnInMoney";
            this.btnInMoney.Size = new System.Drawing.Size(75, 23);
            this.btnInMoney.TabIndex = 7;
            this.btnInMoney.Text = "充值";
            this.btnInMoney.Click += new System.EventHandler(this.btnInMoney_Click);
            // 
            // txtMemberCardNo
            // 
            this.txtMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberCardNo.Enabled = false;
            this.txtMemberCardNo.Location = new System.Drawing.Point(152, 32);
            this.txtMemberCardNo.MaxLength = 6;
            this.txtMemberCardNo.Name = "txtMemberCardNo";
            this.txtMemberCardNo.Size = new System.Drawing.Size(100, 21);
            this.txtMemberCardNo.TabIndex = 1;
            this.txtMemberCardNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMemberCardNo_KeyPress);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(48, 32);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "会员卡号：";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ultraPrintDocument1
            // 
            this.ultraPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.ultraPrintDocument1_PrintPage);
            // 
            // MemberCardInMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1028, 606);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "MemberCardInMoney";
            this.Text = "一通卡充值";
            this.Load += new System.EventHandler(this.MemberCardInMoney_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEndDateInMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private void btnQuery_Click(string strCardNo)
        {
            string strSql = "select cnvcMemberCardNo,cnvcMemberName,cnvcPaperNo,cnvcMemberRight,cnvcDiscount,cnvcFree,cnnMemberFee,cnnPrepay,cndEndDate from tbMember where Len(cnvcMemberCardNo)=6 and cnvcState='" + ConstApp.Card_State_InUse + "' and cnvcMemberCardNo='" + strCardNo + "'";

            DataTable dtMember = Helper.Query(strSql);
            if (dtMember.Rows.Count == 0)
            {
                setdisp();
                throw new BusinessException("会员充值", "未找到会员，卡号：" + strCardNo);
            }
            
            Member m = new Member(dtMember);
            if (!this.GetIsInMoney(m.cnvcMemberRight))
            {
                setdisp();
                throw new BusinessException("会员充值", "此会员不能充值，卡号：" + strCardNo);
            }
            btnInMoney.Enabled = true;
            this.txtMemberCardNo.Text = m.cnvcMemberCardNo;
            this.txtMemberName.Text = m.cnvcMemberName;
            this.txtBalance.Text = m.cnnPrepay.ToString();
            this.txtPaperNo.Text = m.cnvcPaperNo;
            txtMemberRight.Text = m.cnvcMemberRight;
            this.cmdEndDate.Text = m.cndEndDate;
            this.cmbDiscount.Text = m.cnvcDiscount;

            
        }

		private void btnInMoney_Click(object sender, System.EventArgs e)
		{
			//充值
			try
			{
				if (txtInMoney.Text.Trim().Length == 0)
				{
					throw new BusinessException("充值","充值金额不能为空");
				}
                DateTime dtEndDate = Convert.ToDateTime(cmdEndDateInMoney.Text);
                if (dtEndDate < DateTime.Now)
                {
                    throw new BusinessException("充值","卡使用时限不能小于当前日期");
                }
                if (string.IsNullOrEmpty(txtAddMoney.Text)) txtAddMoney.Text = "0";
                //if (txtFree.Text.Trim().Length == 0)
                //{
                //    throw new BusinessException("充值","场次不能为空");
                //}

//				if (null == cmbShow.SelectedItem)
//				{
//					throw new BusinessException("充值","请选择招聘会");
//				}
                //UltraGridRow row = this.ultraGrid1.ActiveRow;
                //if (null == row)
                //{
                //    throw new BusinessException("充值","请选择充值的会员");
                //}
                //string strFree = row.Cells["cnvcFree"].Value.ToString();
                //if (strFree == ConstApp.Free_Time_NoLimit)
                //{
                //    MessageBox.Show("场次，\""+ConstApp.Free_Time_NoLimit+"\"将被修改成"+txtFree.Text,"充值");
                //}
                decimal dBalance = Convert.ToDecimal(txtBalance.Text) + Convert.ToDecimal(txtInMoney.Text) + Convert.ToDecimal(txtAddMoney.Text);
				DialogResult dr2 = MessageBox.Show(this,"【会员卡号："+txtMemberCardNo.Text+"】\n【单位名称："+txtMemberName.Text+"】\n【工商注册号："+txtPaperNo.Text+"】\n【充值金额："+txtInMoney.Text+"】\n"
                    + "【赠送金额：" + this.txtAddMoney.Text + "】\n"
                    + "\n【充值后余额：" + dBalance.ToString() + "】\n", "充值信息确认", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (dr2 == DialogResult.Yes)
				{
					Member member = new Member();
					member.cnvcMemberCardNo = txtMemberCardNo.Text;

                    //DataTable dt = Helper.Query("select * from tbMember where cnvcMemberCardNo='"+txtMemberCardNo.Text+"'");
                    //if(dt.Rows.Count==0) throw new BusinessException("会员充值","未找到会员");
                    //Member oldmember = new Member(dt);
					member.cnnPrepay = Decimal.Parse(txtInMoney.Text);
					//member.cnvcFree = txtFree.Text;
					member.cnvcOperName = this.oper.cnvcOperName;
					member.cnvcPaperNo = txtPaperNo.Text;
					member.cndOperDate = DateTime.Now;
					member.cnvcMemberName = txtMemberName.Text;
                    member.cndEndDate = cmdEndDateInMoney.Text;
                    member.cnvcSales = cmbSales.Text;
                    member.cnvcDiscount = cmbDiscount.Text;
                    MemberManageFacade memberManage = new MemberManageFacade();
					PrintedBill pBill = new PrintedBill(member.ToTable());
                    pBill.cnnLastBalance = Convert.ToDecimal(txtBalance.Text);
                    pBill.cnnPrepay = Convert.ToDecimal(txtInMoney.Text);
                    pBill.cnnDonate = Convert.ToDecimal(txtAddMoney.Text);
                    pBill.cnnBalance = Convert.ToDecimal(txtBalance.Text) + Convert.ToDecimal(txtInMoney.Text) + Convert.ToDecimal(txtAddMoney.Text);
					pBill.cnvcBillType = ConstApp.Bill_Type_InMoney;
                    pBill.cndEndDate = cmdEndDateInMoney.Text;
                    pBill.cnvcDiscount = cmbDiscount.Text;

					memberManage.MemberInMoney(member,pBill);
					//pMember = member;
									
					DialogResult dr = MessageBox.Show(this,"恭喜！充值成功。打印小票吗？\n【否】继续充值，\n【取消】关闭充值界面。","充值成功",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information);
					if (dr == DialogResult.Yes)
					{
						//清空进行充值操作
						Helper.PrintTicket(pBill);
						//this.ultraPrintDocument1.Print();
						
//						txtInMoney.Text = "";
//						txtFree.Text = "";
						
						//btnQuery_Click(null,null);
                        
                        setdisp();
					
					}
					else if(dr == DialogResult.No)
					{
                        btnQuery_Click(txtMemberCardNo.Text);
						txtInMoney.Text = "";
                        txtAddMoney.Text = "";
                        lblInMoney.Text = "充值后余额：";
						//txtFree.Text = "";
                        //setdisp();
					}
					else
					{
						this.Close();
					}
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
        private void setdisp()
        {
            btnInMoney.Enabled = false;
            txtAddMoney.Text = "";
            txtBalance.Text = "";
            txtInMoney.Text = "";
            txtMemberCardNo.Text = "";
            txtMemberName.Text = "";
            txtMemberRight.Text = "";
            txtPaperNo.Text = "";
            cmdEndDate.Text = "";
            cmdEndDateInMoney.Text = "";
            cmbSales.Text = "";
            cmbDiscount.Text = defaultDsicount;
            lblInMoney.Text = "充值后余额：";
        }
		private void MemberCardInMoney_Load(object sender, System.EventArgs e)
		{
			Helper.SetTextBox(txtInMoney,"Prepay");
			this.btnInMoney.Enabled = false;
            Helper.AddTodayButton(cmdEndDate);
            cmdEndDate.Text = "";
            Helper.AddTodayButton(cmdEndDateInMoney);
            cmdEndDateInMoney.Text = "";

            ClientHelper.BindSales(cmbSales);//, this.oper.cnnOperID.ToString());
            ClientHelper.BindInMoneyDiscount(cmbDiscount);
            this.defaultDsicount = this.GetMemberDiscount("一通卡会员");
            cmbDiscount.Text = defaultDsicount;
		}


		private void ultraPrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			//
			Font drawFontTitle = new Font("Arial", 14);
			Font drawFontBody = new Font("Arial", 8);
			SolidBrush drawBrush = new SolidBrush(Color.Black);			

			StringFormat drawFormat = new StringFormat();
			drawFormat.FormatFlags = StringFormatFlags.DisplayFormatControl;
			e.Graphics.DrawString("云南人才市场", drawFontTitle, drawBrush, 50.0f, 40.0f, drawFormat);
			e.Graphics.DrawLine(new Pen(drawBrush,1.0f),0.0f,68.0f,300.0f,68.0f);
			e.Graphics.DrawString("会员卡号：", drawFontBody, drawBrush, 35.0f, 70.0F, drawFormat);
			e.Graphics.DrawString(pMember.cnvcMemberCardNo, drawFontBody, drawBrush, 115.0f, 70.0F, drawFormat);
			e.Graphics.DrawString("充值金额：", drawFontBody, drawBrush, 35.0f, 85.0F, drawFormat);
			e.Graphics.DrawString(pMember.cnnPrepay.ToString(), drawFontBody, drawBrush, 115.0f, 85.0F, drawFormat);
			e.Graphics.DrawLine(new Pen(drawBrush,1.0f),0.0f,100.0f,300.0f,100.0f);
			e.Graphics.DrawString("操作员：", drawFontBody, drawBrush, 35.0f, 100.0F, drawFormat);
			e.Graphics.DrawString(pMember.cnvcOperName, drawFontBody, drawBrush, 115.0f, 100.0F, drawFormat);

			e.Graphics.DrawString("操作时间："+DateTime.Now.ToShortDateString(), drawFontBody, drawBrush, 35.0f, 115.0F, drawFormat);

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
            e.Layout.Bands[0].Columns["cnvcFree"].Hidden = true;
			e.Layout.Bands[0].Columns["cnnMemberFee"].Header.Caption = "会员费";
            e.Layout.Bands[0].Columns["cnnMemberFee"].Hidden = true;
			e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "余额";
			e.Layout.Bands[0].Columns["cndEndDate"].Header.Caption = "卡使用时限";

			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Width = 60;
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Width = 100;
			e.Layout.Bands[0].Columns["cnvcDiscount"].Width = 30;
			e.Layout.Bands[0].Columns["cnvcFree"].Width = 60;

		}


		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            this.txtMemberCardNo.Enabled = false;
            this.ultraButton2.Text = "输入卡号";
            CardM1 m1 = new CardM1();
            string strCardNo = "";
            string strRet = m1.ReadCard(out strCardNo);//,out dtemp,out itemp);

            if (strRet != ConstMsg.RFOK)
            {
                throw new BusinessException("卡操作失败", "读取会员卡失败！");
            }
            if (strCardNo.Length > 6) throw new BusinessException("刷卡签到", "请放入一通卡");
            //string strCardNo = "123465";// "00201346";
            this.btnQuery_Click(strCardNo);
        }


        private void txtInMoney_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInMoney.Text)) return;
            decimal dinvalue = Convert.ToDecimal(txtInMoney.Text);
            ynhrMemberManage.BusinessFacade.MemberBusiness.MemberManageFacade mf = new MemberManageFacade();
            this.txtAddMoney.Text = mf.GetInMoneySetting(dinvalue).ToString();
            decimal dBalance = Convert.ToDecimal(txtBalance.Text) + Convert.ToDecimal(txtInMoney.Text) + Convert.ToDecimal(txtAddMoney.Text);
            lblInMoney.Text = "充值后余额：" + dBalance.ToString() ;
            if (Login.constApp.htDisabledDate.ContainsKey(Login.constApp.strCardTypeL6Name + "会员"))
            {
                //string strDisabledDate = Login.constApp.htDisabledDate[Login.constApp.strCardTypeL6Name + "会员"].ToString();
                //string strCurDate = DateTime.Now.AddMonths(int.Parse(strDisabledDate)).ToString();
                //DateTime dtEndDate = Convert.ToDateTime(m.cndEndDate);
                //if (dtEndDate > DateTime.Now)
                //{
                //    strCurDate = dtEndDate.AddMonths(int.Parse(strDisabledDate)).ToString();
                //}
                //cmdEndDateInMoney.Text = strCurDate;
                //this.errorProvider1.SetError(cmdEndDateInMoney, "");
                if (Login.constApp.htDisabledDateMinAmount.ContainsKey(Login.constApp.strCardTypeL6Name + "会员"))
                {
                    string strDisabledDateMinAmount = Login.constApp.htDisabledDateMinAmount[Login.constApp.strCardTypeL6Name + "会员"].ToString();
                    decimal minAmount = Convert.ToDecimal(strDisabledDateMinAmount);
                    string strEndDate = SqlHelper.ExecuteScalar(CommandType.Text, "select GETDATE()").ToString();
                    DateTime dtEndDate = Convert.ToDateTime(strEndDate).Date;//cmdEndDate.Text);
                    string strCurDate = dtEndDate.ToString();
                    if (dinvalue >= minAmount)
                    {
                        string strDisabledDate = Login.constApp.htDisabledDate[Login.constApp.strCardTypeL6Name + "会员"].ToString();
                        //string strCurDate = DateTime.Now.AddMonths(int.Parse(strDisabledDate)).ToString();
                        
                        //if (dtEndDate < DateTime.Now)
                        //{
                        strCurDate = dtEndDate.AddMonths(int.Parse(strDisabledDate)).ToString();
                        //}
                        //else
                        //{
                        //    strCurDate = DateTime.Now.AddMonths(int.Parse(strDisabledDate)).ToString("yyyy-MM-dd");
                        //}
                        

                    }
                    cmdEndDateInMoney.Text = strCurDate;
                    //else
                    //{
                    //    cmdEndDateInMoney.Text = cmdEndDate.Text;
                    //}
                    this.errorProvider1.SetError(cmdEndDateInMoney, "");
                }
                else
                {
                    MessageBox.Show(this, Login.constApp.strCardTypeL6Name + "的“卡有效月份最小充值金额”参数未设置", "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.errorProvider1.SetError(cmdEndDateInMoney, Login.constApp.strCardTypeL6Name + " 的“卡有效月份最小充值金额”参数未设置");
                }
            }
            else
            {
                MessageBox.Show(this, Login.constApp.strCardTypeL6Name + "的“卡有效月份”参数未设置", "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.errorProvider1.SetError(cmdEndDateInMoney, Login.constApp.strCardTypeL6Name + " 的“卡有效月份”参数未设置");
            }
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            switch (this.ultraButton2.Text)
            {
                case "输入卡号":
                    setdisp();
                    this.txtMemberCardNo.Enabled = true;
                    this.ultraButton2.Text = "查询";
                    this.btnInMoney.Enabled = false;
                    break;
                case "查询":
                    this.txtMemberCardNo.Enabled = false;
                    this.ultraButton2.Text = "输入卡号";
                    this.btnQuery_Click(txtMemberCardNo.Text);
                    break;
            }

        }

        private void txtMemberCardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtMemberCardNo.Enabled = false;
                this.ultraButton2.Text = "输入卡号";
                this.btnQuery_Click(txtMemberCardNo.Text);
            }
        }
	}
}
