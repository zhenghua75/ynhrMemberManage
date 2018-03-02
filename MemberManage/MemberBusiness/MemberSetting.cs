using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using ynhrMemberManage.Domain;
using ynhrMemberManage.ORM;
using Infragistics.Shared; 
using Infragistics.Win; 
using Infragistics.Win.UltraWinDataSource; 
using Infragistics.Win.UltraWinGrid;
using ynhrMemberManage.Common;
using ynhrMemberManage.BusinessFacade.MemberBusiness;
//using ynhrMemberManage.BusinessFacade; 
//using Infragistics.Win.UltraWinDataSource;
namespace MemberManage.MemberBusiness
{
	/// <summary>
	/// Summary description for MemberSetting.
	/// </summary>
    public class MemberSetting : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private System.ComponentModel.IContainer components = null;
		private Infragistics.Win.Misc.UltraButton btnDelete;
		public static bool IsShowing ;
		private Infragistics.Win.Misc.UltraButton btnAdd;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtValue;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid2;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbMember;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberValue;
		private Infragistics.Win.Misc.UltraButton btnMemberModify;
		private Infragistics.Win.Misc.UltraButton btnMemberAdd;
		private Infragistics.Win.Misc.UltraButton btnMemberDelete;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbMemberType;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbType;
		private Infragistics.Win.Misc.UltraButton btnModify;		
		public MemberSetting()
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
            this.btnDelete = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmbType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtValue = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.btnModify = new Infragistics.Win.Misc.UltraButton();
            this.btnAdd = new Infragistics.Win.Misc.UltraButton();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmbMemberType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtMemberValue = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.btnMemberModify = new Infragistics.Win.Misc.UltraButton();
            this.btnMemberAdd = new Infragistics.Win.Misc.UltraButton();
            this.btnMemberDelete = new Infragistics.Win.Misc.UltraButton();
            this.cmbMember = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMemberType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMember)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnDelete.Location = new System.Drawing.Point(272, 128);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.cmbType);
            this.ultraGroupBox1.Controls.Add(this.txtValue);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox1.Controls.Add(this.btnModify);
            this.ultraGroupBox1.Controls.Add(this.btnAdd);
            this.ultraGroupBox1.Controls.Add(this.btnDelete);
            this.ultraGroupBox1.Location = new System.Drawing.Point(707, 72);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(384, 192);
            this.ultraGroupBox1.TabIndex = 5;
            this.ultraGroupBox1.Text = "参数设置";
            // 
            // cmbType
            // 
            this.cmbType.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbType.Location = new System.Drawing.Point(144, 32);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(216, 21);
            this.cmbType.TabIndex = 13;
            // 
            // txtValue
            // 
            this.txtValue.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtValue.Location = new System.Drawing.Point(144, 72);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(216, 21);
            this.txtValue.TabIndex = 12;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(40, 72);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 10;
            this.ultraLabel2.Text = "参数值：";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(40, 32);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 9;
            this.ultraLabel1.Text = "参数类型：";
            // 
            // btnModify
            // 
            this.btnModify.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnModify.Location = new System.Drawing.Point(168, 128);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 8;
            this.btnModify.Text = "修改";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnAdd.Location = new System.Drawing.Point(64, 128);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Location = new System.Drawing.Point(16, 32);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(685, 248);
            this.ultraGrid1.TabIndex = 6;
            this.ultraGrid1.Text = "参数列表";
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            this.ultraGrid1.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.ultraGrid1_AfterSelectChange);
            // 
            // ultraGrid2
            // 
            this.ultraGrid2.Location = new System.Drawing.Point(16, 304);
            this.ultraGrid2.Name = "ultraGrid2";
            this.ultraGrid2.Size = new System.Drawing.Size(685, 248);
            this.ultraGrid2.TabIndex = 7;
            this.ultraGrid2.Text = "会员参数设置";
            this.ultraGrid2.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid2_InitializeLayout);
            this.ultraGrid2.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.ultraGrid2_AfterSelectChange);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.cmbMemberType);
            this.ultraGroupBox2.Controls.Add(this.txtMemberValue);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox2.Controls.Add(this.btnMemberModify);
            this.ultraGroupBox2.Controls.Add(this.btnMemberAdd);
            this.ultraGroupBox2.Controls.Add(this.btnMemberDelete);
            this.ultraGroupBox2.Controls.Add(this.cmbMember);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox2.Location = new System.Drawing.Point(707, 320);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(384, 208);
            this.ultraGroupBox2.TabIndex = 8;
            this.ultraGroupBox2.Text = "会员参数设置";
            // 
            // cmbMemberType
            // 
            this.cmbMemberType.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbMemberType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbMemberType.Location = new System.Drawing.Point(152, 72);
            this.cmbMemberType.Name = "cmbMemberType";
            this.cmbMemberType.Size = new System.Drawing.Size(216, 21);
            this.cmbMemberType.TabIndex = 20;
            // 
            // txtMemberValue
            // 
            this.txtMemberValue.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtMemberValue.Location = new System.Drawing.Point(152, 104);
            this.txtMemberValue.Name = "txtMemberValue";
            this.txtMemberValue.Size = new System.Drawing.Size(216, 21);
            this.txtMemberValue.TabIndex = 19;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(48, 104);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel4.TabIndex = 17;
            this.ultraLabel4.Text = "参数值：";
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(48, 70);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel5.TabIndex = 16;
            this.ultraLabel5.Text = "参数类型：";
            // 
            // btnMemberModify
            // 
            this.btnMemberModify.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnMemberModify.Location = new System.Drawing.Point(176, 160);
            this.btnMemberModify.Name = "btnMemberModify";
            this.btnMemberModify.Size = new System.Drawing.Size(75, 23);
            this.btnMemberModify.TabIndex = 15;
            this.btnMemberModify.Text = "修改";
            this.btnMemberModify.Click += new System.EventHandler(this.btnMemberModify_Click);
            // 
            // btnMemberAdd
            // 
            this.btnMemberAdd.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnMemberAdd.Location = new System.Drawing.Point(80, 160);
            this.btnMemberAdd.Name = "btnMemberAdd";
            this.btnMemberAdd.Size = new System.Drawing.Size(75, 23);
            this.btnMemberAdd.TabIndex = 14;
            this.btnMemberAdd.Text = "添加";
            this.btnMemberAdd.Click += new System.EventHandler(this.btnMemberAdd_Click);
            // 
            // btnMemberDelete
            // 
            this.btnMemberDelete.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnMemberDelete.Location = new System.Drawing.Point(280, 160);
            this.btnMemberDelete.Name = "btnMemberDelete";
            this.btnMemberDelete.Size = new System.Drawing.Size(75, 23);
            this.btnMemberDelete.TabIndex = 13;
            this.btnMemberDelete.Text = "删除";
            this.btnMemberDelete.Click += new System.EventHandler(this.btnMemberDelete_Click);
            // 
            // cmbMember
            // 
            this.cmbMember.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbMember.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbMember.Location = new System.Drawing.Point(152, 32);
            this.cmbMember.Name = "cmbMember";
            this.cmbMember.Size = new System.Drawing.Size(216, 21);
            this.cmbMember.TabIndex = 1;
            this.cmbMember.ValueChanged += new System.EventHandler(this.cmbMember_ValueChanged);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(48, 36);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 0;
            this.ultraLabel3.Text = "会员类型：";
            // 
            // MemberSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1132, 589);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGrid2);
            this.Controls.Add(this.ultraGrid1);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "MemberSetting";
            this.Text = "一通卡会员参数设置";
            this.Load += new System.EventHandler(this.MemberSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMemberType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMember)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void MemberSetting_Load(object sender, System.EventArgs e)
		{
			
			BindNamecode();
			BindMemberRight();
			Helper.BindNameCodeType(cmbType);
			//Helper.BindMemberCode(cmbMemberType);

		}

		private void BindNamecode()
		{
			try
			{
                DataTable dtNameCode = Helper.Query("select * from tbNameCode where cnvcType<>'" + ConstApp.Product + "' and cnvcType not like '充值赠送%' and cnvcType<>'" + ConstApp.CardType + "'  order by cnvcType,cnvcValue");
				this.ultraGrid1.DataSource = dtNameCode;
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

		private void BindMemberRight()
		{
			try
			{
				DataTable dtNameCode = Helper.Query("select * from tbNameCode where cnvcType='"+ConstApp.MemberType+"'  order by cnvcType,cnvcValue");
				this.cmbMember.DisplayMember = "cnvcValue";
				this.cmbMember.ValueMember = "cnvcType";
				this.cmbMember.DataSource = dtNameCode;
				this.cmbMember.DataBind();

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

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				
				DialogResult strRet = MessageBox.Show(this,"是否删除？","会员参数设置",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if (strRet == DialogResult.Yes)
				{
					UltraGridRow row = this.ultraGrid1.ActiveRow;
					if (null == row )
					{
						throw new BusinessException("参数设置","请选择参数");
					}		
					if (cmbType.SelectedItem == null)
					{
						throw new BusinessException("参数设置","请选择参数类型");
					}
					if (txtValue.Text.Trim().Length == 0)
					{
						throw new BusinessException("参数设置","请输入参数值");
					}
					string strType = row.Cells["cnvcType"].Value.ToString();
					DataTable dtNameCode = Helper.Query("select * from tbNameCode where cnvcType='"+strType+"'");
					if (dtNameCode.Rows.Count < 2)
					{
						throw new BusinessException("会员参数设置","【参数类型】+【参数值】必须要有");
					}

					NameCode nameCode = new NameCode();
					nameCode.cnvcCodeID = int.Parse(row.Cells["cnvcCodeID"].Value.ToString());
                    MemberManageFacade memberManage = new MemberManageFacade();
					memberManage.DeleteNameCode(nameCode);
					MessageBox.Show(this,"参数删除成功！","参数设置",MessageBoxButtons.OK,MessageBoxIcon.Information);
					BindNamecode();
					BindMemberRight();
					cmbMember_ValueChanged(null,null);
					//Helper.BindMemberCode(cmbMemberType);
                    
					ynhrMemberManage.BusinessFacade.SysInit.LoadPara(Login.constApp);
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


		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (cmbType.SelectedItem == null)
				{
					throw new BusinessException("会员参数设置","请选择参数类型");
				}
				if (txtValue.Text.Trim().Length == 0)
				{
					throw new BusinessException("会员参数设置","请输入参数值");
				}				
				DataTable dtNameCode = Helper.Query("select * from tbNameCode where cnvcType='"+cmbType.Text+"' and cnvcValue='"+txtValue.Text+"'");
				if (dtNameCode.Rows.Count > 0)
				{
					throw new BusinessException("会员参数设置","【参数类型】+【参数值】已存在");
				}
				
				if (cmbType.Text == ConstApp.TouchFlash)
				{
					JudgeOne(cmbType.Text);
					int.Parse(txtValue.Text);
				}
				if (cmbType.Text == ConstApp.TouchBookBeginDate||
					cmbType.Text == ConstApp.TouchBookEndDate||
					cmbType.Text == ConstApp.TouchSignInBeginDate||
					cmbType.Text == ConstApp.TouchSignInEndDate
					)
				{
					JudgeOne(cmbType.Text);
					if (txtValue.Text.IndexOf(":") < 0)
					{
						throw new BusinessException("会员参数设置","请输入时间格式，例如05:01");
					}
					string strValue = txtValue.Text;
					string[] strValues = strValue.Split(':');
					string strHour = strValues[0];
					string strMinute = strValues[1];
					int.Parse(strHour);
					int.Parse(strMinute);
				}				
				if (cmbType.Text == ConstApp.BookDate)
				{
					JudgeOne(cmbType.Text);
					int.Parse(txtValue.Text);
				}
                if (cmbType.Text == ConstApp.NetBookBeforeDate)
                {
                    JudgeOne(cmbType.Text);
                    int.Parse(txtValue.Text);
                }
				if (cmbType.Text == ConstApp.tishi)
				{
					JudgeOne(cmbType.Text);
					int.Parse(txtValue.Text);
				}
                if (cmbType.Text == ConstApp.JobListBeginDate || cmbType.Text==ConstApp.JobBookingListBeginDate
                    ||cmbType.Text==ConstApp.JobBookingListEndDate||cmbType.Text==ConstApp.JobRemainListBeginDate
                    ||cmbType.Text==ConstApp.JobRemainListEndDate)
                {
                    JudgeOne(cmbType.Text);
                    DateTime.Parse(txtValue.Text);
                }
                if (cmbType.Text == ConstApp.JobListEndDate)
                {
                    JudgeOne(cmbType.Text);
                    DateTime.Parse(txtValue.Text);
                }
				NameCode nameCode = new NameCode();
				nameCode.cnvcType = cmbType.Text;
				nameCode.cnvcValue = txtValue.Text;
                if (cmbType.Text == ConstApp.JobListBeginDate || cmbType.Text == ConstApp.JobListEndDate
                    ||cmbType.Text==ConstApp.JobBookingListBeginDate||cmbType.Text==ConstApp.JobBookingListEndDate
                    ||cmbType.Text==ConstApp.JobRemainListBeginDate||cmbType.Text==ConstApp.JobRemainListEndDate)
                    nameCode.cnvcValue = Convert.ToDateTime(txtValue.Text).ToString("yyyy-MM-dd");
                MemberManageFacade memberManage = new MemberManageFacade();
				memberManage.AddNameCode(nameCode);
				MessageBox.Show(this,"参数添加成功！","会员参数设置",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindNamecode();
				BindMemberRight();
				cmbMember_ValueChanged(null,null);
                ynhrMemberManage.BusinessFacade.SysInit.LoadPara(Login.constApp);
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

		private void JudgeOne(string strType)
		{
			DataTable dtNameCode2 = Helper.Query("select * from tbNameCode where cnvcType='"+strType+"'");
			if (dtNameCode2.Rows.Count > 0)
			{
				throw new BusinessException("会员参数设置","【"+strType+"】已存在");
			}
		}
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				UltraGridRow row = this.ultraGrid1.ActiveRow;
				if (null == row )
				{
					throw new BusinessException("参数设置","请选择参数");
				}	
				if (cmbType.SelectedItem == null)
				{
					throw new BusinessException("参数设置","请选择参数类型");
				}
				if (txtValue.Text.Trim().Length == 0)
				{
					throw new BusinessException("参数设置","请输入参数值");
				}	
				string strType = row.Cells["cnvcType"].Value.ToString();
				string strValue = row.Cells["cnvcValue"].Value.ToString();
				if (strType != cmbType.Text)
				{
					throw new BusinessException("参数设置","参数类型不能修改");
				}
				if (strValue == txtValue.Text)
				{
					throw new BusinessException("参数设置","请修改参数值");
				}
				DataTable dtNameCode = Helper.Query("select * from tbNameCode where cnvcType='"+cmbType.Text+"' and cnvcValue='"+txtValue.Text+"'");
				if (dtNameCode.Rows.Count > 0)
				{
					throw new BusinessException("参数设置","【参数类型】+【参数值】已存在");
				}		
				if (cmbType.Text == ConstApp.TouchFlash)
				{
					//JudgeOne(cmbType.Text);
					int.Parse(txtValue.Text);
				}
				if (cmbType.Text == ConstApp.TouchBookBeginDate||
					cmbType.Text == ConstApp.TouchBookEndDate||
					cmbType.Text == ConstApp.TouchSignInBeginDate||
					cmbType.Text == ConstApp.TouchSignInEndDate
					)
				{
					//JudgeOne(cmbType.Text);
					if (txtValue.Text.IndexOf(":") < 0)
					{
						throw new BusinessException("会员参数设置","请输入时间格式，例如05:01");
					}
					//string strValue = txtValue.Text;
					string[] strValues = txtValue.Text.Split(':');
//					string strHour = strValues[0];
//					string strMinute = strValues[1];
					int.Parse(strValues[0]);
					int.Parse(strValues[1]);
				}				
				if (cmbType.Text == ConstApp.BookDate)
				{
					int.Parse(txtValue.Text);
				}
				if (cmbType.Text == ConstApp.tishi)
				{
					int.Parse(txtValue.Text);
				}
				NameCode nameCode = new NameCode(dtNameCode);
				nameCode.cnvcCodeID = int.Parse(row.Cells["cnvcCodeID"].Value.ToString());
				nameCode.cnvcType = cmbType.Text;
				nameCode.cnvcValue = txtValue.Text;


                MemberManageFacade memberManage = new MemberManageFacade();
				memberManage.ModifyNameCode(nameCode);
				MessageBox.Show(this,"参数修改成功！","会员参数设置",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindNamecode();
				BindMemberRight();
				cmbMember_ValueChanged(null,null);
                ynhrMemberManage.BusinessFacade.SysInit.LoadPara(Login.constApp);
			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message+"\n参数异常，请核查","系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}


		private void btnMemberAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (cmbMember.SelectedItem == null)
				{
					throw new BusinessException("会员参数设置","请选择会员类型");
				}
				if (cmbMemberType.SelectedItem == null)
				{
					throw new BusinessException("会员参数设置","请选择参数类型");
				}
				string strSql = "select * from tbMemberCode where cnvcMemberName ='"+cmbMember.Text+"' and cnvcMemberType='"+cmbMemberType.Text+"'";
				DataTable dtMemberCode = Helper.Query(strSql);
				if (dtMemberCode.Rows.Count > 0)
				{
					throw new BusinessException("会员参数设置","【会员类型+参数类型】已存在");
				}
				if (txtMemberValue.Text.Trim().Length ==0)
				{
					throw new BusinessException("会员参数设置","请输入参数值");
				}
				if (!(txtMemberValue.Text.Equals(ConstApp.Free_Time_NoLimit)||txtMemberValue.Text.Equals(ConstApp.YesNo_No)||txtMemberValue.Text.Equals(ConstApp.YesNo_Yes)))
				{
					int.Parse(txtMemberValue.Text);
					if (int.Parse(txtMemberValue.Text) < 0)
					{
						throw new BusinessException("会员参数设置","请输入正数");
					}
				}
				
				MemberCode memberCode = new MemberCode();
				memberCode.cnvcMemberName = cmbMember.Text;
				memberCode.cnvcMemberType = cmbMemberType.Text;
				memberCode.cnvcMemberValue = txtMemberValue.Text;
                MemberManageFacade memberManage = new MemberManageFacade();
				memberManage.AddMemberCode(memberCode);
				MessageBox.Show(this,"会员参数添加成功！","会员参数设置",MessageBoxButtons.OK,MessageBoxIcon.Information);
				cmbMember_ValueChanged(null,null);
                ynhrMemberManage.BusinessFacade.SysInit.LoadPara(Login.constApp);
			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message+"\n参数异常，请核查","系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		
		}

		private void btnMemberModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				UltraGridRow row = this.ultraGrid2.ActiveRow;
				if (null == row)
				{
					throw new BusinessException("会员参数设置","请选择会员参数");
				}
				if (cmbMember.SelectedItem == null)
				{
					throw new BusinessException("会员参数设置","请选择会员类型");
				}
				
				if (cmbMemberType.SelectedItem == null)
				{
					throw new BusinessException("会员参数设置","请选择参数类型");
				}
				string strType = row.Cells["cnvcMemberType"].Value.ToString();
				string strValue = row.Cells["cnvcMemberValue"].Value.ToString();
				if (strType != cmbMemberType.Text)
				{
					throw new BusinessException("会员参数设置","参数类型不能修改");
				}
				string strSql = "select * from tbMemberCode where cnvcMemberName ='"+cmbMember.Text+"' and cnvcMemberType='"+cmbMemberType.Text+"'";
				DataTable dtMemberCode = Helper.Query(strSql);
				if (dtMemberCode.Rows.Count == 0)
				{
					throw new BusinessException("会员参数设置","【会员类型+参数类型】不存在");
				}
				if (txtMemberValue.Text.Trim().Length ==0)
				{
					throw new BusinessException("会员参数设置","请输入参数值");
				}
				if (!txtMemberValue.Text.Equals(ConstApp.Free_Time_NoLimit))
				{
					int.Parse(txtMemberValue.Text);
					if (int.Parse(txtMemberValue.Text) < 0)
					{
						throw new BusinessException("会员参数设置","请输入正数");
					}
					if (strValue == txtMemberValue.Text)
					{
						throw new BusinessException("会员参数设置","请修改参数值");
					}
				}
				MemberCode memberCode = new MemberCode(dtMemberCode);
				memberCode.cnnMemberCodeID = int.Parse(row.Cells["cnnMemberCodeID"].Value.ToString());
				memberCode.cnvcMemberType = cmbMemberType.Text;
				memberCode.cnvcMemberValue = txtMemberValue.Text;
                MemberManageFacade memberManage = new MemberManageFacade();
				memberManage.ModifyMemberCode(memberCode);
				MessageBox.Show(this,"会员参数修改成功！","会员参数设置",MessageBoxButtons.OK,MessageBoxIcon.Information);
				cmbMember_ValueChanged(null,null);
                ynhrMemberManage.BusinessFacade.SysInit.LoadPara(Login.constApp);
			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message+"\n参数异常，请核查","系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void btnMemberDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				DialogResult strRet = MessageBox.Show(this,"是否删除？","会员参数设置",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if (strRet == DialogResult.Yes)
				{
					UltraGridRow row = this.ultraGrid2.ActiveRow;
					if (null == row)
					{
						throw new BusinessException("会员参数设置","请选择会员参数");
					}
					if (cmbMember.SelectedItem == null)
					{
						throw new BusinessException("会员参数设置","请选择会员类型");
					}
					if (cmbMemberType.SelectedItem == null)
					{
						throw new BusinessException("会员参数设置","请选择参数类型");
					}
					string strSql = "select * from tbMemberCode where cnvcMemberName ='"+cmbMember.Text+"' and cnvcMemberType='"+cmbMemberType.Text+"'";
					DataTable dtMemberCode = Helper.Query(strSql);
					if (dtMemberCode.Rows.Count ==0)
					{
						throw new BusinessException("会员参数设置","【会员类型+参数类型】不存在");
					}

					MemberCode memberCode = new MemberCode();
					memberCode.cnnMemberCodeID = int.Parse(row.Cells["cnnMemberCodeID"].Value.ToString());
                    MemberManageFacade memberManage = new MemberManageFacade();
					memberManage.DeleteMemberCode(memberCode);
					MessageBox.Show(this,"会员参数删除成功！","会员参数设置",MessageBoxButtons.OK,MessageBoxIcon.Information);
					cmbMember_ValueChanged(null,null);
                    ynhrMemberManage.BusinessFacade.SysInit.LoadPara(Login.constApp);
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
			e.Layout.Bands[0].Columns["cnvcCodeID"].Hidden = true;
            //e.Layout.Bands[0].Columns["cnvcCodeID"].Header.Caption = "参数ID";
			e.Layout.Bands[0].Columns["cnvcType"].Header.Caption = "参数类型";
			e.Layout.Bands[0].Columns["cnvcValue"].Header.Caption = "参数值";
			e.Layout.Bands[0].Columns["cnvcType"].Width = 150;
			e.Layout.Bands[0].Columns["cnvcValue"].Width = 350;
		}

		private void ultraGrid2_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e);
			e.Layout.Bands[0].Columns["cnnMemberCodeID"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "会员资格";
			e.Layout.Bands[0].Columns["cnvcMemberType"].Header.Caption = "参数类型";
			e.Layout.Bands[0].Columns["cnvcMemberValue"].Header.Caption = "参数值";
			e.Layout.Bands[0].Columns["cnvcMemberType"].Width = 500;
		}

		private void cmbMember_ValueChanged(object sender, System.EventArgs e)
		{
			if (cmbMember.SelectedItem != null)
			{

                string strSql = "select *  from tbMemberCode where  cnvcMemberName = '" + cmbMember.Text + "' and cnvcMemberType not in ('" + ConstApp.ProductPrice + "','" + ConstApp.ProductDiscount + "','" + ConstApp.ProductPoints + "')";
				DataTable dtMemberCode = Helper.Query(strSql);
				this.ultraGrid2.DataSource = dtMemberCode;//Login.constApp.dtMemberCode;
				this.ultraGrid2.DataBind();

				Helper.BindMemberCode(cmbMemberType,cmbMember.Value.ToString());
			}

		}

		private void ultraGrid1_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			UltraGridRow row = this.ultraGrid1.ActiveRow;
			if (null != row )
			{
			
				string strCodeID = this.ultraGrid1.ActiveRow.Cells["cnvcCodeID"].Value.ToString();
				string strType = this.ultraGrid1.ActiveRow.Cells["cnvcType"].Value.ToString();
				string strValue = this.ultraGrid1.ActiveRow.Cells["cnvcValue"].Value.ToString();

				//cmbType.Tag = strCodeID;
				cmbType.SelectedIndex = cmbType.FindString(strType);
				txtValue.Text = strValue;
			}
		}

		private void ultraGrid2_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			UltraGridRow row = this.ultraGrid2.ActiveRow;
			if (null != row)
			{
				string strMemberCodeID = this.ultraGrid2.ActiveRow.Cells["cnnMemberCodeID"].Value.ToString();
				string strMemberType = this.ultraGrid2.ActiveRow.Cells["cnvcMemberType"].Value.ToString();
				string strMemberValue = this.ultraGrid2.ActiveRow.Cells["cnvcMemberValue"].Value.ToString();
				string strMemberName = this.ultraGrid2.ActiveRow.Cells["cnvcMemberName"].Value.ToString();
	
				cmbMemberType.SelectedIndex = cmbMemberType.FindString(strMemberType);
				cmbMember.SelectedIndex = cmbMember.FindString(strMemberName);
				//cmbMemberType.Tag = strMemberCodeID;									
				txtMemberValue.Text = strMemberValue;
			}
		}
	}
}
