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
using ynhrMemberManage.BusinessFacade.MemberBusiness;
using MemberManage.Business;
namespace MemberManage.MemberBusiness
{
	/// <summary>
	/// Summary description for MemberFileQuery.
	/// </summary>
    public class MemberCardRenew : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
		private Infragistics.Win.Misc.UltraButton btnQuery;
		private System.ComponentModel.IContainer components = null;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraButton btnCard;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPPaperNo;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPMemberName;
        private Infragistics.Win.Misc.UltraLabel txtNewMemberCount;
		public static bool IsShowing ;
		public MemberCardRenew()
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
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.btnCard = new Infragistics.Win.Misc.UltraButton();
            this.txtMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.txtPPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtPMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtNewMemberCount = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPPaperNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPMemberName)).BeginInit();
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
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(128, 8);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 16;
            this.ultraLabel1.Text = "会员卡号：";
            // 
            // btnCard
            // 
            this.btnCard.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnCard.Location = new System.Drawing.Point(392, 40);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(75, 23);
            this.btnCard.TabIndex = 9;
            this.btnCard.Text = "重新发卡";
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // txtMemberCardNo
            // 
            this.txtMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberCardNo.Location = new System.Drawing.Point(232, 8);
            this.txtMemberCardNo.MaxLength = 6;
            this.txtMemberCardNo.Name = "txtMemberCardNo";
            this.txtMemberCardNo.NullText = "请输入会员卡号";
            this.txtMemberCardNo.Size = new System.Drawing.Size(100, 21);
            this.txtMemberCardNo.TabIndex = 1;
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
            this.ultraGroupBox3.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox3.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox3.Controls.Add(this.txtPPaperNo);
            this.ultraGroupBox3.Controls.Add(this.txtPMemberName);
            this.ultraGroupBox3.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox3.Controls.Add(this.txtMemberCardNo);
            this.ultraGroupBox3.Controls.Add(this.btnCard);
            this.ultraGroupBox3.Location = new System.Drawing.Point(128, 392);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(720, 110);
            this.ultraGroupBox3.TabIndex = 3;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(128, 32);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel4.TabIndex = 22;
            this.ultraLabel4.Text = "工商注册号：";
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(128, 56);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel5.TabIndex = 21;
            this.ultraLabel5.Text = "单位名称：";
            // 
            // txtPPaperNo
            // 
            this.txtPPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPPaperNo.Enabled = false;
            this.txtPPaperNo.Location = new System.Drawing.Point(232, 32);
            this.txtPPaperNo.Name = "txtPPaperNo";
            this.txtPPaperNo.Size = new System.Drawing.Size(100, 21);
            this.txtPPaperNo.TabIndex = 20;
            // 
            // txtPMemberName
            // 
            this.txtPMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtPMemberName.Enabled = false;
            this.txtPMemberName.Location = new System.Drawing.Point(232, 56);
            this.txtPMemberName.Name = "txtPMemberName";
            this.txtPMemberName.Size = new System.Drawing.Size(100, 21);
            this.txtPMemberName.TabIndex = 19;
            // 
            // txtNewMemberCount
            // 
            this.txtNewMemberCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewMemberCount.Location = new System.Drawing.Point(139, 3);
            this.txtNewMemberCount.Name = "txtNewMemberCount";
            this.txtNewMemberCount.Size = new System.Drawing.Size(627, 39);
            this.txtNewMemberCount.TabIndex = 4;
            // 
            // MemberCardRenew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(984, 581);
            this.Controls.Add(this.txtNewMemberCount);
            this.Controls.Add(this.ultraGroupBox3);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "MemberCardRenew";
            this.Text = Login.constApp.strCardTypeL6Name + "发卡";
            this.Load += new System.EventHandler(this.MemberFileQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            this.ultraGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPPaperNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPMemberName)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void MemberFileQuery_Load(object sender, System.EventArgs e)
		{
            this.txtMemberCardNo.MaxLength = 6;
			this.ultraGrid1.Dock       = DockStyle.Fill;
			this.ultraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
			this.ultraGroupBox2.BringToFront();		
			Helper.SetTextBox(txtMemberCardNo,"MemberCardNo");
            QueryCount();
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//查询
            //try
            //{
				//this.btnInlose.Enabled = true;
            string strSql = "select cnvcMemberCardNo,cnvcMemberName,cnvcPaperNo,cnvcCorporation,cnvcCompanyAddress,cnvcLinkMan,cnvcLinkPhone,cnvcMemberRight,cnvcEmail,cnvcComments,cnvcEnterpriseType,cnvcDiscount,"
                + "cnvcFree,cnvcState,cnnMemberFee,cnnPrepay,cndEndDate,cnvcOperName,cndOperDate,cnvcMobileTelephone,cnvcPostalCode,cnvcSales,cnvcHandleman,cnvcHandlemanPaperNo,cnvcTrade,cnvcCustomerService,cnvcFax,"
            + "cnvcMemberPwd,cniSynch,cniRecid,cndInNetDate,cnvcProduct,cnvcMemberCardNo as cnvcOldMemberCardNo from tbMember where Len(cnvcMemberCardNo)=6 and cnvcState='" + ConstApp.Card_State_NoCard + "' ";
				if (txtMemberCardNo.Text.Trim().Length > 0)
				{
					strSql += " and cnvcMemberCardNo like '%"+txtMemberCardNo.Text+"%'";
				}
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
				
            //}
            //catch (BusinessException bex)
            //{
            //    MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}
			
		}
        private void QueryCount()
        {
            //查询
            //try
            //{
                //this.btnInlose.Enabled = true;
                string strSql = "select count(*) from tbMember where Len(cnvcMemberCardNo)=6 and cnvcState='" + ConstApp.Card_State_NoCard + "' ";
                
                Query query = new Query();
                DataTable dtMember = query.Report(strSql);

                if (dtMember.Rows.Count > 0)
                {
                    this.txtNewMemberCount.Text = "有" + dtMember.Rows[0][0].ToString() + "位新会员没有发卡";
                }
                else
                {
                    this.txtNewMemberCount.Text = "有0位新会员没有发卡";
                }
            //}
            //catch (BusinessException bex)
            //{
            //    MessageBox.Show(this, bex.Message, bex.Type, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(this, ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			e.Layout.ScrollBounds = ScrollBounds.ScrollToFill; 
			//e.Layout.Override.CellClickAction = CellClickAction.;
			e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;//UltraWinGrid.SelectType.Single;

			e.Layout.Bands[0].Override.SummaryFooterCaptionAppearance.FontData.Bold = DefaultableBoolean.True; 
			e.Layout.Bands[0].Override.SummaryValueAppearance.BackColor = Color.White;
			e.Layout.Bands[0].Override.SummaryValueAppearance.TextHAlign = HAlign.Right;
			e.Layout.Bands[0].Override.SummaryFooterCaptionAppearance.BackColor = Color.White;

			foreach (UltraGridColumn  col in e.Layout.Bands[0].Columns)
			{
				col.CellActivation = Activation.NoEdit;
			}

			e.Layout.Bands[0].Columns["cnvcFax"].Header.Caption = "传真";			
			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "会员卡号";			
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "工商注册号";
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "单位名称";
			e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "余额";
			e.Layout.Bands[0].Columns["cnnMemberFee"].Header.Caption = "会员费";
            //e.Layout.Bands[0].Columns["cnnMemberFee"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcFree"].Header.Caption = "剩余场次";
            //e.Layout.Bands[0].Columns["cnvcFree"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Header.Caption = "会员资格";
			e.Layout.Bands[0].Columns["cnvcState"].Header.Caption = "操作状态";
			e.Layout.Bands[0].Columns["cnvcOperName"].Header.Caption = "操作员名称";
			e.Layout.Bands[0].Columns["cndOperDate"].Header.Caption = "操作时间";
			e.Layout.Bands[0].Columns["cnvcDiscount"].Header.Caption = "折扣";
			e.Layout.Bands[0].Columns["cndEndDate"].Header.Caption = "到期时间";


			e.Layout.Bands[0].Columns["cnvcMemberPwd"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcOldMemberCardNo"].Hidden = true;
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

			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Width = 60;
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Width = 100;
			e.Layout.Bands[0].Columns["cnvcDiscount"].Width = 30;
			e.Layout.Bands[0].Columns["cnvcFree"].Width = 60;

			e.Layout.Bands[0].Columns["cndOperDate"].CellActivation = Activation.NoEdit;
			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].CellActivation = Activation.AllowEdit;



			//e.Layout.Bands[0].SummaryFooterCaption = "合计：会员数量"; 

		}

		private void btnCard_Click(object sender, System.EventArgs e)
		{
			
            //try
            //{
				UltraGridRow row = this.ultraGrid1.ActiveRow;
				if (null == row)
				{
					throw new BusinessException("重新发卡","请从查询结果中选择进行发卡的会员资料");										
				}
				if (txtMemberCardNo.Text.Trim().Length == 0)
				{
					throw new BusinessException("重新发卡","请输入卡号");
				}
				string strNewMemberCardNo = txtMemberCardNo.Text;//row.Cells["cnvcMemberCardNo"].Value.ToString();
//				if (strNewMemberCardNo.StartsWith("A")||strNewMemberCardNo.StartsWith("B"))
//				{
//					throw new BusinessException("重新发卡","卡号必须为数字，现在卡号是："+strNewMemberCardNo);
//				}
				if (strNewMemberCardNo.Trim().Length < 6)
				{
					throw new BusinessException("重新发卡","卡号必须6位");
				}
                if (strNewMemberCardNo.Trim().Length < 6 )
                {
                    throw new BusinessException("重新发卡","会员卡号必须是6位！");
                }
                else
                {
					//string strMemberCardNo = txtMemberCardNo.Text.Trim();
					if (strNewMemberCardNo.Trim('0')=="")
					{
						throw new BusinessException("重新发卡","会员卡号不能都为零");
					}
					else
					{
						//判断卡号是否存在
						DataTable dtIsMember = Helper.Query("select * from tbMember where cnvcMemberCardNo = '"+strNewMemberCardNo+"'");
						if (dtIsMember.Rows.Count > 0)
						{
							throw new BusinessException("重新发卡","会员卡号已存在");
						}
					
					}		
				}
				string strMemberCardNo = row.Cells["cnvcOldMemberCardNo"].Value.ToString();
				DataTable dtMember = Helper.Query("select * from tbMember where cnvcState='"+ConstApp.Card_State_NoCard+"' and cnvcMemberCardNo ='"+strMemberCardNo+"'");
				if (dtMember.Rows.Count != 1)
				{
					throw new BusinessException("重新发卡","未找到相应的会员资料");
				}
				Member member = new Member(dtMember);
				//member.cnvcMemberCardNo = strNewMemberCardNo;
				member.cnvcProduct = strNewMemberCardNo;
				member.cnvcOperName = this.oper.cnvcOperName;
				member.cndOperDate = DateTime.Now;
                //DataTable dtMemberProduct = Helper.Query("select * from tbMemberProduct where cnvcMemberCardNo = '"+strMemberCardNo+"'");
                //string strProduct = "";
                //foreach (DataRow drProduct in dtMemberProduct.Rows)
                //{
                //    MemberProduct product = new MemberProduct(drProduct);
                //    strProduct += product.cnvcProductName+",,,,"+product.cnvcFree+",|";
                //}				
				
				DialogResult dr = MessageBox.Show(this,"【会员卡号】"+member.cnvcProduct+"\n【工商注册号】"+member.cnvcPaperNo+"\n【单位名称】"+member.cnvcMemberName,"信息确认",MessageBoxButtons.YesNo,MessageBoxIcon.Information);

				if (dr == DialogResult.Yes)
				{
					PrintedBill pBill = new PrintedBill(member.ToTable());
                    pBill.cnvcProduct = "";
					pBill.cnvcMemberCardNo = strNewMemberCardNo;
					pBill.cnvcBillType = ConstApp.Bill_Type_Provide;
					//pBill.cnvcProduct = strProduct;
                    MemberManageFacade mm = new MemberManageFacade();
					mm.RenewCard(member,pBill);
					pBill.cnvcProduct = "";
					Helper.PrintTicket(pBill);
					MessageBox.Show(this,"发卡成功！","发卡");
					this.txtMemberCardNo.Text = "";
					this.txtPPaperNo.Text = "";
					this.txtPMemberName.Text = "";
					//this.txtPrepay.Text = "";
				}
                QueryCount();
                this.btnQuery_Click(null, null);
            //}
            //catch (BusinessException bex)
            //{
            //    MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}
		}

		private void ultraGrid1_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
		{
			EmbeddableEditorBase editor = null;
			DefaultEditorOwnerSettings editorSettings = null;

			editorSettings = new DefaultEditorOwnerSettings( );
			editorSettings.DataType = typeof( int );
			editor = new EditorWithMask( new DefaultEditorOwner( editorSettings ) );
			editorSettings.MaskInput = "nnnnnnnn";
			e.Row.Cells[ "cnvcMemberCardNo" ].Editor = editor;

			e.Row.Cells["cnvcMemberCardNo"].Tag = e.Row.Cells["cnvcMemberCardNo"].Value;
		}

		private void ultraGrid1_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			UltraGridRow row = this.ultraGrid1.ActiveRow;
			if (null != row)
			{
				this.txtPPaperNo.Text = row.Cells["cnvcPaperNo"].Value.ToString();
				this.txtPMemberName.Text = row.Cells["cnvcMemberName"].Value.ToString();
				//this.txtPrepay.Text = row.Cells["cnnPrepay"].Value.ToString();
			}
		}

}
}
