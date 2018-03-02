using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using ynhrMemberManage.Domain;
using ynhrMemberManage.ORM;
using Infragistics;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;

using MemberManage.Reports;
using ynhrMemberManage.Print;
using ynhrMemberManage.Common;
using ynhrMemberManage.BusinessFacade;
namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for MemberFileQuery.
	/// </summary>
    public class NoCardDelete : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
		private Infragistics.Win.Misc.UltraButton btnQuery;
		private System.ComponentModel.IContainer components = null;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraButton btnCard;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
		public static bool IsShowing ;
		public NoCardDelete()
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
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.btnQuery = new Infragistics.Win.Misc.UltraButton();
            this.txtPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnCard = new Infragistics.Win.Misc.UltraButton();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox1.Controls.Add(this.btnQuery);
            this.ultraGroupBox1.Controls.Add(this.txtPaperNo);
            this.ultraGroupBox1.Controls.Add(this.txtMemberName);
            this.ultraGroupBox1.Location = new System.Drawing.Point(120, 48);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(736, 48);
            this.ultraGroupBox1.TabIndex = 0;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(64, 16);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 18;
            this.ultraLabel3.Text = "工商注册号：";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(304, 16);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 17;
            this.ultraLabel2.Text = "单位名称：";
            // 
            // btnQuery
            // 
            this.btnQuery.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnQuery.Location = new System.Drawing.Point(552, 16);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtPaperNo
            // 
            this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPaperNo.Location = new System.Drawing.Point(168, 16);
            this.txtPaperNo.Name = "txtPaperNo";
            this.txtPaperNo.Size = new System.Drawing.Size(100, 21);
            this.txtPaperNo.TabIndex = 5;
            // 
            // txtMemberName
            // 
            this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberName.Location = new System.Drawing.Point(408, 16);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtMemberName.TabIndex = 3;
            // 
            // btnCard
            // 
            this.btnCard.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnCard.Location = new System.Drawing.Point(272, 32);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(104, 23);
            this.btnCard.TabIndex = 9;
            this.btnCard.Text = "删除";
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraGrid1.Location = new System.Drawing.Point(72, 64);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(200, 80);
            this.ultraGrid1.TabIndex = 1;
            this.ultraGrid1.Text = "会员档案";
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            this.ultraGrid1.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.ultraGrid1_AfterSelectChange);
            this.ultraGrid1.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ultraGrid1_InitializeRow);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.ultraGrid1);
            this.ultraGroupBox2.Location = new System.Drawing.Point(40, 104);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(936, 272);
            this.ultraGroupBox2.TabIndex = 2;
            // 
            // ultraGroupBox3
            // 
            this.ultraGroupBox3.Controls.Add(this.btnCard);
            this.ultraGroupBox3.Location = new System.Drawing.Point(128, 392);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(720, 110);
            this.ultraGroupBox3.TabIndex = 3;
            // 
            // NoCardDelete
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(984, 581);
            this.Controls.Add(this.ultraGroupBox3);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "NoCardDelete";
            this.Text = Login.constApp.strCardTypeL8Name + "删除未发卡会员";
            this.Load += new System.EventHandler(this.MemberFileQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void MemberFileQuery_Load(object sender, System.EventArgs e)
		{
			
			this.ultraGrid1.Dock       = DockStyle.Fill;
			this.ultraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
			this.ultraGroupBox2.BringToFront();		
			//Helper.SetTextBox(txtMemberCardNo,"MemberCardNo");	
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//查询
			try
			{
                string strSql = "select * from tbMember where Len(cnvcMemberCardNo)=8 and cnvcState='" + ConstApp.Card_State_NoCard + "' ";
				
				if (txtMemberName.Text.Trim().Length > 0)
				{
					strSql += " and cnvcMemberName like '%"+txtMemberName.Text+"%'";
				}
				if (txtPaperNo.Text.Trim().Length > 0)
				{
					strSql += " and cnvcPaperNo like '%"+txtPaperNo.Text+"%'";
				}				
				Query query = new Query();
				DataTable dtMember = query.Report(strSql);

				this.ultraGrid1.DataSource = null;
				this.ultraGrid1.DataSource = dtMember;
				this.ultraGrid1.DataBind();	
				
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
//			e.Layout.ScrollBounds = ScrollBounds.ScrollToFill; 
//			//e.Layout.Override.CellClickAction = CellClickAction.;
//			e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;//UltraWinGrid.SelectType.Single;
//
//			e.Layout.Bands[0].Override.SummaryFooterCaptionAppearance.FontData.Bold = DefaultableBoolean.True; 
//			e.Layout.Bands[0].Override.SummaryValueAppearance.BackColor = Color.White;
//			e.Layout.Bands[0].Override.SummaryValueAppearance.TextHAlign = HAlign.Right;
//			e.Layout.Bands[0].Override.SummaryFooterCaptionAppearance.BackColor = Color.White;
//
//			foreach (UltraGridColumn  col in e.Layout.Bands[0].Columns)
//			{
//				col.CellActivation = Activation.NoEdit;
//			}

			//e.Layout.Bands[0].Columns["cnvcJobName"].Header.Caption = "招聘会";			
			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "会员卡号";			
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "实收";
			e.Layout.Bands[0].Columns["cnnMemberFee"].Header.Caption = "会员费";
			e.Layout.Bands[0].Columns["cnvcFree"].Header.Caption = "剩余场次";
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Header.Caption = "会员资格";
			e.Layout.Bands[0].Columns["cnvcState"].Header.Caption = "操作状态";
			e.Layout.Bands[0].Columns["cnvcOperName"].Header.Caption = "操作员名称";
			e.Layout.Bands[0].Columns["cndOperDate"].Header.Caption = "操作时间";
			e.Layout.Bands[0].Columns["cnvcDiscount"].Header.Caption = "折扣";
			e.Layout.Bands[0].Columns["cndEndDate"].Header.Caption = "到期时间";


			e.Layout.Bands[0].Columns["cnvcMemberPwd"].Hidden = true;
			//e.Layout.Bands[0].Columns["cnvcOldMemberCardNo"].Hidden = true;
			e.Layout.Bands[0].Columns["cniSynch"].Hidden = true;
			e.Layout.Bands[0].Columns["cniRecid"].Hidden = true;
			e.Layout.Bands[0].Columns["cndInNetDate"].Hidden = true;

			e.Layout.Bands[0].Columns["cnvcCorporation"].Header.Caption = "法人代表";
			e.Layout.Bands[0].Columns["cnvcCompanyAddress"].Header.Caption = "单位地址";
			e.Layout.Bands[0].Columns["cnvcLinkMan"].Header.Caption = "联系人";
			e.Layout.Bands[0].Columns["cnvcLinkPhone"].Header.Caption = "办公电话";
			e.Layout.Bands[0].Columns["cnvcEmail"].Header.Caption = "电子邮箱";
			e.Layout.Bands[0].Columns["cnvcComments"].Header.Caption = "备注";
			e.Layout.Bands[0].Columns["cnvcProduct"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcEnterpriseType"].Header.Caption = "企业性质";
			e.Layout.Bands[0].Columns["cnvcMobileTelephone"].Header.Caption = "手机号码";
			e.Layout.Bands[0].Columns["cnvcPostalCode"].Header.Caption = "邮政编码";
			e.Layout.Bands[0].Columns["cnvcSales"].Header.Caption = "销售人员";
			e.Layout.Bands[0].Columns["cnvcHandleman"].Header.Caption = "经办人";
			e.Layout.Bands[0].Columns["cnvcHandlemanPaperNo"].Header.Caption = "经办人身份证号";
			e.Layout.Bands[0].Columns["cnvcTrade"].Header.Caption = "行业";
			e.Layout.Bands[0].Columns["cnvcCustomerService"].Header.Caption = "客户姓名";
			e.Layout.Bands[0].Columns["cnvcFax"].Header.Caption = "传真";		

			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Width = 60;
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Width = 100;
			e.Layout.Bands[0].Columns["cnvcDiscount"].Width = 30;
			e.Layout.Bands[0].Columns["cnvcFree"].Width = 60;

			e.Layout.Bands[0].Columns["cndOperDate"].CellActivation = Activation.NoEdit;
			//e.Layout.Bands[0].Columns["cnvcMemberCardNo"].CellActivation = Activation.AllowEdit;



			//e.Layout.Bands[0].SummaryFooterCaption = "合计：会员数量"; 

		}

		private void btnCard_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				UltraGridRow row = this.ultraGrid1.ActiveRow;
				if (null == row)
				{
					throw new BusinessException("删除未发卡会员","请从查询结果中选择进行删除的会员资料");										
				}
				
				string strMemberCardNo = row.Cells["cnvcMemberCardNo"].Value.ToString();
				DataTable dtMember = Helper.Query("select * from tbMember where cnvcState='"+ConstApp.Card_State_NoCard+"' and cnvcMemberCardNo ='"+strMemberCardNo+"'");
				if (dtMember.Rows.Count != 1)
				{
					throw new BusinessException("删除未发卡会员","未找到相应的未发卡会员资料");
				}
				Member member = new Member(dtMember);
				member.cnvcMemberCardNo = strMemberCardNo;
				member.cnvcOperName = this.oper.cnvcOperName;
				member.cndOperDate = DateTime.Now;
				DataTable dtMemberProduct = Helper.Query("select * from tbMemberProduct where cnvcMemberCardNo = '"+strMemberCardNo+"'");
				string strProduct = "";
				foreach (DataRow drProduct in dtMemberProduct.Rows)
				{
					MemberProduct product = new MemberProduct(drProduct);
					strProduct += product.cnvcProductName+",,,,"+product.cnvcFree+",|";
				}				
				
				DialogResult dr = MessageBox.Show(this,"【会员卡号】"+member.cnvcMemberCardNo+"\n【工商注册号】"+member.cnvcPaperNo+"\n【单位名称】"+member.cnvcMemberName,"信息确认",MessageBoxButtons.YesNo,MessageBoxIcon.Information);

				if (dr == DialogResult.Yes)
				{
                    MemberManageFacade mm = new MemberManageFacade();
					mm.NoCardDelete(member);					
					MessageBox.Show(this,"删除成功！","删除未发卡会员");
					
					btnQuery_Click(null,null);
					
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

		private void ultraGrid1_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
		{

		}

		private void ultraGrid1_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			
		}

}
}
