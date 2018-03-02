using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Common;

namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for ReturnPrepay.
	/// </summary>
    public class ReturnPrepay : frmBase
	{
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbShow;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Infragistics.Win.Misc.UltraButton btnOK;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraButton btnQuery;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQPaperNo;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private IContainer components;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtQMemberName;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtReturnPrepay;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEndDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBeginDate;
		public static bool IsShowing ;

		public ReturnPrepay()
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtReturnPrepay = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbShow = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.btnOK = new Infragistics.Win.Misc.UltraButton();
            this.txtPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmbEndDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.chkEndDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cmbBeginDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.chkBeginDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtQMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.btnQuery = new Infragistics.Win.Misc.UltraButton();
            this.txtQPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReturnPrepay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQPaperNo)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Location = new System.Drawing.Point(16, 200);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(624, 304);
            this.ultraGrid1.TabIndex = 5;
            this.ultraGrid1.Text = "查询结果";
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            this.ultraGrid1.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.ultraGrid1_AfterSelectChange);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtReturnPrepay);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel7);
            this.ultraGroupBox1.Controls.Add(this.cmbShow);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel9);
            this.ultraGroupBox1.Controls.Add(this.btnCancel);
            this.ultraGroupBox1.Controls.Add(this.btnOK);
            this.ultraGroupBox1.Controls.Add(this.txtPaperNo);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel6);
            this.ultraGroupBox1.Controls.Add(this.txtMemberName);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox1.Location = new System.Drawing.Point(656, 232);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(360, 240);
            this.ultraGroupBox1.TabIndex = 3;
            this.ultraGroupBox1.Text = "退费";
            // 
            // txtReturnPrepay
            // 
            this.txtReturnPrepay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtReturnPrepay.Location = new System.Drawing.Point(200, 128);
            this.txtReturnPrepay.Name = "txtReturnPrepay";
            this.txtReturnPrepay.Size = new System.Drawing.Size(100, 21);
            this.txtReturnPrepay.TabIndex = 21;
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Location = new System.Drawing.Point(88, 128);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel7.TabIndex = 20;
            this.ultraLabel7.Text = "退费：";
            // 
            // cmbShow
            // 
            this.cmbShow.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbShow.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbShow.Enabled = false;
            this.cmbShow.Location = new System.Drawing.Point(200, 32);
            this.cmbShow.Name = "cmbShow";
            this.cmbShow.Size = new System.Drawing.Size(104, 21);
            this.cmbShow.TabIndex = 19;
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.Location = new System.Drawing.Point(88, 32);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel9.TabIndex = 18;
            this.ultraLabel9.Text = "招聘会：";
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnCancel.Location = new System.Drawing.Point(216, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnOK.Location = new System.Drawing.Point(104, 168);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtPaperNo
            // 
            this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPaperNo.Enabled = false;
            this.txtPaperNo.Location = new System.Drawing.Point(198, 96);
            this.txtPaperNo.Name = "txtPaperNo";
            this.txtPaperNo.Size = new System.Drawing.Size(100, 21);
            this.txtPaperNo.TabIndex = 11;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(86, 96);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel6.TabIndex = 10;
            this.ultraLabel6.Text = "工商注册号：";
            // 
            // txtMemberName
            // 
            this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberName.Enabled = false;
            this.txtMemberName.Location = new System.Drawing.Point(198, 64);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtMemberName.TabIndex = 9;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(86, 64);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel5.TabIndex = 8;
            this.ultraLabel5.Text = "单位名称：";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.cmbEndDate);
            this.ultraGroupBox2.Controls.Add(this.chkEndDate);
            this.ultraGroupBox2.Controls.Add(this.cmbBeginDate);
            this.ultraGroupBox2.Controls.Add(this.chkBeginDate);
            this.ultraGroupBox2.Controls.Add(this.txtQMemberName);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox2.Controls.Add(this.btnQuery);
            this.ultraGroupBox2.Controls.Add(this.txtQPaperNo);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox2.Location = new System.Drawing.Point(248, 40);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(496, 144);
            this.ultraGroupBox2.TabIndex = 4;
            this.ultraGroupBox2.Text = "退费查询";
            // 
            // cmbEndDate
            // 
            this.cmbEndDate.DateTime = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
            this.cmbEndDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbEndDate.Location = new System.Drawing.Point(336, 64);
            this.cmbEndDate.MaskInput = "{date} {time}";
            this.cmbEndDate.Name = "cmbEndDate";
            this.cmbEndDate.Size = new System.Drawing.Size(144, 21);
            this.cmbEndDate.TabIndex = 45;
            this.cmbEndDate.Value = new System.DateTime(2008, 3, 10, 23, 59, 59, 0);
            // 
            // chkEndDate
            // 
            this.chkEndDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.chkEndDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkEndDate.Location = new System.Drawing.Point(264, 64);
            this.chkEndDate.Name = "chkEndDate";
            this.chkEndDate.Size = new System.Drawing.Size(72, 20);
            this.chkEndDate.TabIndex = 47;
            this.chkEndDate.Text = "结束时间";
            // 
            // cmbBeginDate
            // 
            this.cmbBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbBeginDate.Location = new System.Drawing.Point(336, 40);
            this.cmbBeginDate.MaskInput = "{date} {time}";
            this.cmbBeginDate.Name = "cmbBeginDate";
            this.cmbBeginDate.Size = new System.Drawing.Size(144, 21);
            this.cmbBeginDate.TabIndex = 44;
            // 
            // chkBeginDate
            // 
            this.chkBeginDate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.chkBeginDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkBeginDate.Location = new System.Drawing.Point(264, 40);
            this.chkBeginDate.Name = "chkBeginDate";
            this.chkBeginDate.Size = new System.Drawing.Size(80, 20);
            this.chkBeginDate.TabIndex = 46;
            this.chkBeginDate.Text = "开始时间";
            // 
            // txtQMemberName
            // 
            this.txtQMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQMemberName.Location = new System.Drawing.Point(152, 40);
            this.txtQMemberName.Name = "txtQMemberName";
            this.txtQMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtQMemberName.TabIndex = 21;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(40, 40);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 20;
            this.ultraLabel1.Text = "单位名称：";
            // 
            // btnQuery
            // 
            this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnQuery.Location = new System.Drawing.Point(216, 104);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 18;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtQPaperNo
            // 
            this.txtQPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtQPaperNo.Location = new System.Drawing.Point(152, 64);
            this.txtQPaperNo.Name = "txtQPaperNo";
            this.txtQPaperNo.Size = new System.Drawing.Size(100, 21);
            this.txtQPaperNo.TabIndex = 17;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(40, 64);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 16;
            this.ultraLabel2.Text = "工商注册号：";
            // 
            // ReturnPrepay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1028, 549);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGrid1);
            this.Name = "ReturnPrepay";
            this.Text = Login.constApp.strCardTypeL8Name + "退费";
            this.Load += new System.EventHandler(this.ReturnPrepay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReturnPrepay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQPaperNo)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			try
			{
				string strSql = "select top 20 a.cnnPrepayID,b.cnnJobID as cnnJobID,b.cnvcJobName as cnvcJobName,c.cnvcPaperNo as cnvcPaperNo,c.cnvcMemberName as cnvcMemberName,a.cnnPrepay,a.cnnReturn,a.cnnBalance,a.cndOperDate from tbPrepay a "
								+" join tbJob b on a.cnnJobID=b.cnnJobID"
								+" join tbFMember c on a.cnvcPaperNo=c.cnvcPaperNo"
								+" where a.cnvcMemberCardNo is null and (a.cnvcState<>'"+ConstApp.Show_Seat_State_SignIn+"' or a.cnvcState is null)  and b.cndEndDate>=getdate()";
				if (txtQMemberName.Text.Trim().Length > 0)
				{
					strSql += " and c.cnvcMemberName like '%"+txtQMemberName.Text+"%'";
				}
				if (txtQPaperNo.Text.Trim().Length > 0)
				{
					strSql += " and c.cnvcPaperNo like '%"+txtQPaperNo.Text+"%'";
				}
				if (chkBeginDate.Checked)
				{
					strSql += " and a.cndOperDate >= '"+cmbBeginDate.Text+"'";
				}
				if (chkEndDate.Checked)
				{
					strSql += " and a.cndOperDate <= '"+cmbEndDate.Text+"'";
				}
				DataTable dtFMember = Helper.Query(strSql);

//				string strSql2 ="select top 10 a.cnnPrepayID,b.cnnJobID as cnnJobID,b.cnvcJobName as cnvcJobName,c.cnvcMemberCardNo,c.cnvcPaperNo as cnvcPaperNo,c.cnvcMemberName as cnvcMemberName,a.cnnPrepay,a.cnnReturn,a.cnnBalance from tbPrepay a"
//								+" join tbJob b on a.cnnJobID=b.cnnJobID "
//								+" join tbMember c on a.cnvcMemberCardNo=c.cnvcMemberCardNo"
//								+" where a.cnvcMemberCardNo is not null and (a.cnvcState<>'"+ConstApp.Show_Seat_State_SignIn+"' or a.cnvcState is null) ";
//				if (txtQMemberName.Text.Trim().Length > 0)
//				{
//					strSql2 += " and c.cnvcMemberName like '%"+txtQMemberName.Text+"%'";
//				}
//				if (txtQPaperNo.Text.Trim().Length > 0)
//				{
//					strSql2 += " and c.cnvcPaperNo like '%"+txtQPaperNo.Text+"%'";
//				}
//				if (txtQMemberCardNo.Text.Trim().Length > 0)
//				{
//					strSql2 += " and c.cnvcMemberCardNo like '%"+txtQMemberCardNo.Text+"%'";
//				}
//				DataTable dtMember = Helper.Query(strSql2);
//				foreach (DataRow drMember in dtMember.Rows)
//				{
//					dtFMember.Rows.Add(drMember.ItemArray);
//				}
				this.ultraGrid1.DataSource = null;
				this.ultraGrid1.DataSource = dtFMember;
				this.ultraGrid1.DataBind();
				txtMemberName.Text = "";
				txtPaperNo.Text = "";
				txtReturnPrepay.Text = "";
				btnOK.Enabled = false;
				cmbShow.Text = "";

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
			e.Layout.Bands[0].Columns["cnnJobID"].Hidden = true;
			e.Layout.Bands[0].Columns["cnnPrepayID"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcJobName"].Header.Caption = "招聘会名称";
			//e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "会员卡号";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";		
			e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "展位费";
			e.Layout.Bands[0].Columns["cnnReturn"].Header.Caption = "已退费";
			e.Layout.Bands[0].Columns["cnnBalance"].Header.Caption = "余额";
			e.Layout.Bands[0].Columns["cndOperDate"].Header.Caption = "操作时间";

			e.Layout.Bands[0].Columns["cndOperDate"].CellActivation = Activation.NoEdit;


		}

		private void ReturnPrepay_Load(object sender, System.EventArgs e)
		{
			Helper.BindJob(cmbShow);
			Helper.SetTextBox(txtReturnPrepay,"Prepay");
			cmbBeginDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEndDate.MaskInput = "yyyy-mm-dd hh:mm";
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			//退费
			try
			{
				if (txtReturnPrepay.Text.Trim().Length == 0)
				{
					throw new BusinessException("退费","请输入退费金额");
				}
				UltraGridRow row = this.ultraGrid1.ActiveRow;
				if (null == row)
				{
					throw new BusinessException("退费","请选择进行退费的非会员");
				}
				string strBalance = row.Cells["cnnBalance"].Value.ToString();
				Decimal dBalance = Decimal.Parse(strBalance);
				Prepay prepay = new Prepay();
				//prepay.cnvcMemberCardNo = txtMemberCardNo.Text;
				prepay.cnnPrepayID = int.Parse(row.Cells["cnnPrepayID"].Value.ToString());
				prepay.cnnJobID = int.Parse(row.Cells["cnnJobID"].Value.ToString());
				prepay.cnvcPaperNo = row.Cells["cnvcPaperNo"].Value.ToString();
				//prepay.cnvcMemberCardNo = row.Cells["cnvcMemberCardNo"].Value.ToString();
				prepay.cnnReturn = Decimal.Parse(txtReturnPrepay.Text);
				prepay.cnvcOperName = this.oper.cnvcOperName;
				prepay.cndOperDate = DateTime.Now;

				if (prepay.cnnReturn > dBalance)
				{
					throw new BusinessException("退费","退费金额过大");
				}
				MemberManageFacade memberManage= new MemberManageFacade();
				memberManage.ReturnPrepay(prepay);
				//PrintedBill pBill = 
				MessageBox.Show(this,"退费成功","退费",MessageBoxButtons.OK,MessageBoxIcon.Information);
				btnQuery_Click(null,null);
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

		private void ultraGrid1_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			UltraGridRow row = this.ultraGrid1.ActiveRow;
			if (null != row)
			{
				cmbShow.Text = row.Cells["cnvcJobName"].Value.ToString();
				txtMemberName.Text = row.Cells["cnvcMemberName"].Value.ToString();
				txtPaperNo.Text = row.Cells["cnvcPaperNo"].Value.ToString();
				//txtMemberCardNo.Text = row.Cells["cnvcMemberCardNo"].Value.ToString();
				btnOK.Enabled = true;
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
