using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

using Infragistics;
using Infragistics.Win;
using Infragistics.Win.UltraWinTree;

using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using ynhrMemberManage.Common;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Business;
namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for NDeptManage.
	/// </summary>
    public class NDeptManage : frmBase
	{
		private Infragistics.Win.UltraWinTree.UltraTree ultraTree1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList1;
		private Infragistics.Win.Misc.UltraButton btnAddOper;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPwd;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtOperName;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraButton btnAddDept;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDiscount;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDeptName;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraGroupBox gbOper;
		private Infragistics.Win.Misc.UltraGroupBox gbDept;
		private Infragistics.Win.Misc.UltraButton btnDeleteOper;
		private Infragistics.Win.Misc.UltraButton btnModifyOper;
		private Infragistics.Win.Misc.UltraButton btnDeleteDept;
		private Infragistics.Win.Misc.UltraButton btnModifyDept;
		private Infragistics.Win.Misc.UltraButton btnManager;
		private Infragistics.Win.Misc.UltraButton btnModifyPwd;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbParentDept;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDept;
		private Infragistics.Win.Misc.UltraButton btnMoveDept;
		private Infragistics.Win.Misc.UltraButton btnMoveParentDept;
		private Infragistics.Win.Misc.UltraLabel lblDept;
		private Infragistics.Win.Misc.UltraLabel lblParentDept;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPwdConfirm;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCardNo;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.Misc.UltraButton btnCardNo;
		private Infragistics.Win.Misc.UltraButton btnCancelCard;
		public static bool IsShowing ;
		public NDeptManage()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NDeptManage));
			this.ultraTree1 = new Infragistics.Win.UltraWinTree.UltraTree();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.gbOper = new Infragistics.Win.Misc.UltraGroupBox();
			this.btnCardNo = new Infragistics.Win.Misc.UltraButton();
			this.txtCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
			this.txtPwdConfirm = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
			this.btnMoveDept = new Infragistics.Win.Misc.UltraButton();
			this.lblDept = new Infragistics.Win.Misc.UltraLabel();
			this.cmbDept = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.btnModifyPwd = new Infragistics.Win.Misc.UltraButton();
			this.btnManager = new Infragistics.Win.Misc.UltraButton();
			this.btnDeleteOper = new Infragistics.Win.Misc.UltraButton();
			this.btnModifyOper = new Infragistics.Win.Misc.UltraButton();
			this.btnAddOper = new Infragistics.Win.Misc.UltraButton();
			this.txtPwd = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.txtOperName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.gbDept = new Infragistics.Win.Misc.UltraGroupBox();
			this.btnMoveParentDept = new Infragistics.Win.Misc.UltraButton();
			this.lblParentDept = new Infragistics.Win.Misc.UltraLabel();
			this.cmbParentDept = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.btnDeleteDept = new Infragistics.Win.Misc.UltraButton();
			this.btnModifyDept = new Infragistics.Win.Misc.UltraButton();
			this.btnAddDept = new Infragistics.Win.Misc.UltraButton();
			this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
			this.txtDiscount = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.txtDeptName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
			this.btnCancelCard = new Infragistics.Win.Misc.UltraButton();
			((System.ComponentModel.ISupportInitialize)(this.ultraTree1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gbOper)).BeginInit();
			this.gbOper.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtCardNo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPwdConfirm)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbDept)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPwd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOperName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gbDept)).BeginInit();
			this.gbDept.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbParentDept)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDeptName)).BeginInit();
			this.SuspendLayout();
			// 
			// ultraTree1
			// 
			this.ultraTree1.AllowDrop = true;
			this.ultraTree1.ImageList = this.imageList1;
			this.ultraTree1.Location = new System.Drawing.Point(64, 32);
			this.ultraTree1.Name = "ultraTree1";
			this.ultraTree1.Size = new System.Drawing.Size(416, 432);
			this.ultraTree1.TabIndex = 0;
			this.ultraTree1.ViewStyle = Infragistics.Win.UltraWinTree.ViewStyle.Standard;
			this.ultraTree1.AfterActivate += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.ultraTree1_AfterActivate);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// gbOper
			// 
			this.gbOper.Controls.Add(this.btnCancelCard);
			this.gbOper.Controls.Add(this.btnCardNo);
			this.gbOper.Controls.Add(this.txtCardNo);
			this.gbOper.Controls.Add(this.ultraLabel6);
			this.gbOper.Controls.Add(this.txtPwdConfirm);
			this.gbOper.Controls.Add(this.ultraLabel3);
			this.gbOper.Controls.Add(this.btnMoveDept);
			this.gbOper.Controls.Add(this.lblDept);
			this.gbOper.Controls.Add(this.cmbDept);
			this.gbOper.Controls.Add(this.btnModifyPwd);
			this.gbOper.Controls.Add(this.btnManager);
			this.gbOper.Controls.Add(this.btnDeleteOper);
			this.gbOper.Controls.Add(this.btnModifyOper);
			this.gbOper.Controls.Add(this.btnAddOper);
			this.gbOper.Controls.Add(this.txtPwd);
			this.gbOper.Controls.Add(this.ultraLabel2);
			this.gbOper.Controls.Add(this.txtOperName);
			this.gbOper.Controls.Add(this.ultraLabel1);
			this.gbOper.Location = new System.Drawing.Point(528, 32);
			this.gbOper.Name = "gbOper";
			this.gbOper.Size = new System.Drawing.Size(376, 232);
			this.gbOper.TabIndex = 1;
			this.gbOper.Text = "操作员";
			// 
			// btnCardNo
			// 
			this.btnCardNo.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnCardNo.Location = new System.Drawing.Point(80, 168);
			this.btnCardNo.Name = "btnCardNo";
			this.btnCardNo.Size = new System.Drawing.Size(56, 23);
			this.btnCardNo.TabIndex = 28;
			this.btnCardNo.Text = "发卡";
			this.btnCardNo.Click += new System.EventHandler(this.btnCardNo_Click);
			// 
			// txtCardNo
			// 
			this.txtCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtCardNo.Location = new System.Drawing.Point(144, 112);
			this.txtCardNo.MaxLength = 5;
			this.txtCardNo.Name = "txtCardNo";
			this.txtCardNo.Size = new System.Drawing.Size(100, 21);
			this.txtCardNo.TabIndex = 27;
			// 
			// ultraLabel6
			// 
			this.ultraLabel6.Location = new System.Drawing.Point(24, 112);
			this.ultraLabel6.Name = "ultraLabel6";
			this.ultraLabel6.TabIndex = 26;
			this.ultraLabel6.Text = "操作员卡号：";
			// 
			// txtPwdConfirm
			// 
			this.txtPwdConfirm.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtPwdConfirm.Location = new System.Drawing.Point(144, 88);
			this.txtPwdConfirm.Name = "txtPwdConfirm";
			this.txtPwdConfirm.PasswordChar = '*';
			this.txtPwdConfirm.Size = new System.Drawing.Size(100, 21);
			this.txtPwdConfirm.TabIndex = 25;
			// 
			// ultraLabel3
			// 
			this.ultraLabel3.Location = new System.Drawing.Point(24, 88);
			this.ultraLabel3.Name = "ultraLabel3";
			this.ultraLabel3.TabIndex = 24;
			this.ultraLabel3.Text = "密码确认：";
			// 
			// btnMoveDept
			// 
			this.btnMoveDept.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnMoveDept.Location = new System.Drawing.Point(288, 168);
			this.btnMoveDept.Name = "btnMoveDept";
			this.btnMoveDept.Size = new System.Drawing.Size(72, 23);
			this.btnMoveDept.TabIndex = 23;
			this.btnMoveDept.Text = "移动";
			this.btnMoveDept.Click += new System.EventHandler(this.btnMoveDept_Click);
			// 
			// lblDept
			// 
			this.lblDept.Location = new System.Drawing.Point(24, 136);
			this.lblDept.Name = "lblDept";
			this.lblDept.TabIndex = 22;
			this.lblDept.Text = "所属部门：";
			// 
			// cmbDept
			// 
			this.cmbDept.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbDept.Location = new System.Drawing.Point(144, 136);
			this.cmbDept.Name = "cmbDept";
			this.cmbDept.Size = new System.Drawing.Size(104, 21);
			this.cmbDept.TabIndex = 21;
			// 
			// btnModifyPwd
			// 
			this.btnModifyPwd.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnModifyPwd.Location = new System.Drawing.Point(120, 200);
			this.btnModifyPwd.Name = "btnModifyPwd";
			this.btnModifyPwd.Size = new System.Drawing.Size(80, 24);
			this.btnModifyPwd.TabIndex = 18;
			this.btnModifyPwd.Text = "修改密码";
			this.btnModifyPwd.Click += new System.EventHandler(this.btnModifyPwd_Click);
			// 
			// btnManager
			// 
			this.btnManager.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnManager.Location = new System.Drawing.Point(216, 200);
			this.btnManager.Name = "btnManager";
			this.btnManager.Size = new System.Drawing.Size(104, 23);
			this.btnManager.TabIndex = 17;
			this.btnManager.Text = "设为部门管理员";
			this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
			// 
			// btnDeleteOper
			// 
			this.btnDeleteOper.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnDeleteOper.Location = new System.Drawing.Point(224, 168);
			this.btnDeleteOper.Name = "btnDeleteOper";
			this.btnDeleteOper.Size = new System.Drawing.Size(56, 23);
			this.btnDeleteOper.TabIndex = 16;
			this.btnDeleteOper.Text = "删除";
			this.btnDeleteOper.Click += new System.EventHandler(this.btnDeleteOper_Click);
			// 
			// btnModifyOper
			// 
			this.btnModifyOper.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnModifyOper.Location = new System.Drawing.Point(16, 200);
			this.btnModifyOper.Name = "btnModifyOper";
			this.btnModifyOper.Size = new System.Drawing.Size(80, 23);
			this.btnModifyOper.TabIndex = 15;
			this.btnModifyOper.Text = "修改名称";
			this.btnModifyOper.Click += new System.EventHandler(this.btnModifyOper_Click);
			// 
			// btnAddOper
			// 
			this.btnAddOper.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnAddOper.Location = new System.Drawing.Point(16, 168);
			this.btnAddOper.Name = "btnAddOper";
			this.btnAddOper.Size = new System.Drawing.Size(56, 23);
			this.btnAddOper.TabIndex = 6;
			this.btnAddOper.Text = "添加";
			this.btnAddOper.Click += new System.EventHandler(this.btnAddOper_Click);
			// 
			// txtPwd
			// 
			this.txtPwd.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtPwd.Location = new System.Drawing.Point(144, 64);
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.PasswordChar = '*';
			this.txtPwd.Size = new System.Drawing.Size(100, 21);
			this.txtPwd.TabIndex = 3;
			// 
			// ultraLabel2
			// 
			this.ultraLabel2.Location = new System.Drawing.Point(24, 64);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.TabIndex = 2;
			this.ultraLabel2.Text = "操作员密码：";
			// 
			// txtOperName
			// 
			this.txtOperName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtOperName.Location = new System.Drawing.Point(144, 40);
			this.txtOperName.Name = "txtOperName";
			this.txtOperName.Size = new System.Drawing.Size(100, 21);
			this.txtOperName.TabIndex = 1;
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.Location = new System.Drawing.Point(24, 40);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.TabIndex = 0;
			this.ultraLabel1.Text = "操作员名称：";
			// 
			// gbDept
			// 
			this.gbDept.Controls.Add(this.btnMoveParentDept);
			this.gbDept.Controls.Add(this.lblParentDept);
			this.gbDept.Controls.Add(this.cmbParentDept);
			this.gbDept.Controls.Add(this.btnDeleteDept);
			this.gbDept.Controls.Add(this.btnModifyDept);
			this.gbDept.Controls.Add(this.btnAddDept);
			this.gbDept.Controls.Add(this.ultraLabel4);
			this.gbDept.Controls.Add(this.txtDiscount);
			this.gbDept.Controls.Add(this.txtDeptName);
			this.gbDept.Controls.Add(this.ultraLabel5);
			this.gbDept.Location = new System.Drawing.Point(528, 304);
			this.gbDept.Name = "gbDept";
			this.gbDept.Size = new System.Drawing.Size(328, 144);
			this.gbDept.TabIndex = 2;
			this.gbDept.Text = "部门";
			// 
			// btnMoveParentDept
			// 
			this.btnMoveParentDept.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnMoveParentDept.Location = new System.Drawing.Point(240, 104);
			this.btnMoveParentDept.Name = "btnMoveParentDept";
			this.btnMoveParentDept.Size = new System.Drawing.Size(72, 23);
			this.btnMoveParentDept.TabIndex = 24;
			this.btnMoveParentDept.Text = "移动";
			this.btnMoveParentDept.Click += new System.EventHandler(this.btnMoveParentDept_Click);
			// 
			// lblParentDept
			// 
			this.lblParentDept.Location = new System.Drawing.Point(40, 80);
			this.lblParentDept.Name = "lblParentDept";
			this.lblParentDept.TabIndex = 20;
			this.lblParentDept.Text = "上级部门：";
			// 
			// cmbParentDept
			// 
			this.cmbParentDept.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbParentDept.Location = new System.Drawing.Point(144, 80);
			this.cmbParentDept.Name = "cmbParentDept";
			this.cmbParentDept.Size = new System.Drawing.Size(104, 21);
			this.cmbParentDept.TabIndex = 19;
			// 
			// btnDeleteDept
			// 
			this.btnDeleteDept.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnDeleteDept.Location = new System.Drawing.Point(176, 104);
			this.btnDeleteDept.Name = "btnDeleteDept";
			this.btnDeleteDept.Size = new System.Drawing.Size(48, 23);
			this.btnDeleteDept.TabIndex = 18;
			this.btnDeleteDept.Text = "删除";
			this.btnDeleteDept.Click += new System.EventHandler(this.btnDeleteDept_Click);
			// 
			// btnModifyDept
			// 
			this.btnModifyDept.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnModifyDept.Location = new System.Drawing.Point(112, 104);
			this.btnModifyDept.Name = "btnModifyDept";
			this.btnModifyDept.Size = new System.Drawing.Size(48, 23);
			this.btnModifyDept.TabIndex = 17;
			this.btnModifyDept.Text = "修改";
			this.btnModifyDept.Click += new System.EventHandler(this.btnModifyDept_Click);
			// 
			// btnAddDept
			// 
			this.btnAddDept.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnAddDept.Location = new System.Drawing.Point(40, 104);
			this.btnAddDept.Name = "btnAddDept";
			this.btnAddDept.Size = new System.Drawing.Size(48, 23);
			this.btnAddDept.TabIndex = 6;
			this.btnAddDept.Text = "添加";
			this.btnAddDept.Click += new System.EventHandler(this.btnAddDept_Click);
			// 
			// ultraLabel4
			// 
			this.ultraLabel4.Location = new System.Drawing.Point(40, 56);
			this.ultraLabel4.Name = "ultraLabel4";
			this.ultraLabel4.TabIndex = 5;
			this.ultraLabel4.Text = "折扣：";
			// 
			// txtDiscount
			// 
			this.txtDiscount.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtDiscount.Location = new System.Drawing.Point(144, 56);
			this.txtDiscount.Name = "txtDiscount";
			this.txtDiscount.Size = new System.Drawing.Size(100, 21);
			this.txtDiscount.TabIndex = 3;
			// 
			// txtDeptName
			// 
			this.txtDeptName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtDeptName.Location = new System.Drawing.Point(144, 32);
			this.txtDeptName.Name = "txtDeptName";
			this.txtDeptName.Size = new System.Drawing.Size(100, 21);
			this.txtDeptName.TabIndex = 1;
			// 
			// ultraLabel5
			// 
			this.ultraLabel5.Location = new System.Drawing.Point(40, 32);
			this.ultraLabel5.Name = "ultraLabel5";
			this.ultraLabel5.TabIndex = 0;
			this.ultraLabel5.Text = "部门名称：";
			// 
			// btnCancelCard
			// 
			this.btnCancelCard.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnCancelCard.Location = new System.Drawing.Point(144, 168);
			this.btnCancelCard.Name = "btnCancelCard";
			this.btnCancelCard.Size = new System.Drawing.Size(64, 23);
			this.btnCancelCard.TabIndex = 29;
			this.btnCancelCard.Text = "取消卡";
			this.btnCancelCard.Click += new System.EventHandler(this.btnCancelCard_Click);
			// 
			// NDeptManage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(936, 533);
			this.Controls.Add(this.gbDept);
			this.Controls.Add(this.gbOper);
			this.Controls.Add(this.ultraTree1);
			this.Name = "NDeptManage";
			this.Text = "部门管理";
			this.Load += new System.EventHandler(this.NDeptManage_Load);
			((System.ComponentModel.ISupportInitialize)(this.ultraTree1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gbOper)).EndInit();
			this.gbOper.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtCardNo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPwdConfirm)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbDept)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPwd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOperName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gbDept)).EndInit();
			this.gbDept.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbParentDept)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDeptName)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void NDeptManage_Load(object sender, System.EventArgs e)
		{
			Helper.SetTextBox(txtCardNo,"Prepay");
			BindTree();
			BindDept();
			gbDept.Visible = false;
			gbOper.Visible = false;

			
			
		}
		private void BindDept()
		{
			DataTable dtDept = getDept();
			cmbDept.DataSource = dtDept;
			cmbDept.DisplayMember = "cnvcDeptName";
			cmbDept.ValueMember = "cnnDeptID";
			cmbDept.DataBind();
			cmbParentDept.DataSource = dtDept;
			cmbParentDept.DisplayMember = "cnvcDeptName";
			cmbParentDept.ValueMember = "cnnDeptID";
			cmbParentDept.DataBind();
		}

		private DataTable getDept()
		{
			int iDeptID = this.dept.cnnDeptID;
			string strSql = "";
			if (iDeptID == 0)
			{
				strSql = "select * from tbDept";
			} 
			else
			{
				if (Login.constApp.htDept.Contains(iDeptID))
				{
					Dept dept = Login.constApp.htDept[iDeptID] as Dept;
					if (dept.cnvcManager == this.oper.cnvcOperName)
					{
						strSql = "select * from tbDept where cnnDeptID="+iDeptID.ToString()+" or cnnParentDeptID="+iDeptID.ToString();
					}
					else
					{
						strSql = "select * from tbDept where 1<>1";
					}
				}
			}
			DataTable dtDept = Helper.Query(strSql);
			return dtDept;
			
		}
		private void BindTree()
		{
			DataTable dtDept = getDept();//Helper.Query("select * from tbDept");
			DataTable dtOper = Helper.Query("select * from tbOper");	
			if (this.dept.cnnDeptID == 0)
			{
				UltraTreeNode tnParent = new UltraTreeNode("0","云南人才市场");
				DataRow[] drOpers = dtOper.Select("cnnDeptID=0 and cnvcOperName<>'admin'");
				foreach (DataRow drOper in drOpers)
				{
					UltraTreeNode tnOper = new UltraTreeNode("oper-"+drOper["cnnOperID"].ToString(),drOper["cnvcOperName"].ToString());
					tnOper.Tag = "0";
					tnParent.Nodes.Add(tnOper);
				}
				AddNodes(tnParent,dtDept,dtOper,"0");
				tnParent.ExpandAll();
				this.ultraTree1.Nodes.Clear();
				this.ultraTree1.Nodes.Add(tnParent);
			}
			else
			{
				if (dtDept.Rows.Count > 0)
				{
					UltraTreeNode tnParent = new UltraTreeNode("0","云南人才市场");

					//系统管理员
//					if (ClientHelper.idept.cnnDeptID == 0)
//					{
//						DataRow[] drOpers = dtOper.Select("cnnDeptID=0 and cnvcOperName<>'admin'");
//						foreach (DataRow drOper in drOpers)
//						{
//							UltraTreeNode tnOper = new UltraTreeNode("oper-"+drOper["cnnOperID"].ToString(),drOper["cnvcOperName"].ToString());
//							tnOper.Tag = "0";
//							tnParent.Nodes.Add(tnOper);
//						}
//					}


					AddNodes(tnParent,dtDept,dtOper,"0");
					tnParent.ExpandAll();
					this.ultraTree1.Nodes.Clear();
					this.ultraTree1.Nodes.Add(tnParent);
				}
				else
				{
					MessageBox.Show("普通操作员无权限操作","部门管理");
				}
			}

//			if (dtDept.Rows.Count > 0)
//			{
//				UltraTreeNode tnParent = new UltraTreeNode("0","云南人才市场");
//
//				//系统管理员
//				if (ClientHelper.idept.cnnDeptID == 0)
//				{
//					DataRow[] drOpers = dtOper.Select("cnnDeptID=0 and cnvcOperName<>'admin'");
//					foreach (DataRow drOper in drOpers)
//					{
//						UltraTreeNode tnOper = new UltraTreeNode("oper-"+drOper["cnnOperID"].ToString(),drOper["cnvcOperName"].ToString());
//						tnOper.Tag = "0";
//						tnParent.Nodes.Add(tnOper);
//					}
//				}
//
//
//				AddNodes(tnParent,dtDept,dtOper,"0");
//				tnParent.ExpandAll();
//				this.ultraTree1.Nodes.Clear();
//				this.ultraTree1.Nodes.Add(tnParent);
//			}
//			else
//			{
//				MessageBox.Show("普通操作员无权限操作","部门管理");
//			}
		
			
		}
		private void AddNodes(UltraTreeNode tnParent,DataTable dtDept,DataTable dtOper,string strDeptID)
		{
			DataRow[] drSubDepts = dtDept.Select("cnnParentDeptID="+strDeptID);
			if (drSubDepts.Length > 0)
			{
				foreach (DataRow drSubDept in drSubDepts)
				{
					UltraTreeNode tnChild = new UltraTreeNode("dept-"+drSubDept["cnnDeptID"].ToString(),drSubDept["cnvcDeptName"].ToString());				
					tnChild.Tag = drSubDept["cnnDiscount"].ToString();
					DataRow[] drOpers = dtOper.Select("cnnDeptID="+drSubDept["cnnDeptID"].ToString());
					foreach (DataRow drOper in drOpers)
					{
						UltraTreeNode tnOper = new UltraTreeNode("oper-"+drOper["cnnOperID"].ToString(),drOper["cnvcOperName"].ToString());
						if (drSubDept["cnvcManager"].ToString() == drOper["cnvcOperName"].ToString())
						{
							tnOper.Override.NodeAppearance.Image = 0;
						}
						else
						{
							tnOper.Override.NodeAppearance.Image = 1;
						}
						tnOper.Tag = drSubDept["cnnDeptID"].ToString();
						tnChild.Nodes.Add(tnOper);
					}
					AddNodes(tnChild,dtDept,dtOper,drSubDept["cnnDeptID"].ToString());
					tnParent.Nodes.Add(tnChild);
				}			
			}
			
		}

		private void ultraTree1_AfterActivate(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
		{
			if (e.TreeNode.Key.StartsWith("dept"))
			{
				gbDept.Visible = true;
				gbOper.Visible = true;

				txtOperName.Text = "";
				txtPwd.Text = "";
				txtPwdConfirm.Text = "";

//				cmbDept.FindString(e.TreeNode.Text);
//				cmbParentDept.FindString(e.TreeNode.Text);

				gbDept.Left = gbOper.Left;
				gbDept.Top = gbOper.Top+210;

				btnManager.Visible = false;
				btnModifyOper.Visible = false;
				btnModifyPwd.Visible = false;
				btnDeleteOper.Visible = false;
				btnMoveDept.Visible = false;
				btnCardNo.Visible = false;
				btnCancelCard.Visible = false;

				lblDept.Visible = false;
				cmbDept.Visible = false;

				btnModifyDept.Visible = true;
				btnDeleteDept.Visible = true;
				lblParentDept.Visible = true;
				cmbParentDept.Visible = true;
				btnMoveParentDept.Visible = true;

				txtDeptName.Text = e.TreeNode.Text;
				txtDiscount.Text = e.TreeNode.Tag.ToString();
				txtDeptName.Tag = e.TreeNode.Key.Substring(5);
				if (e.TreeNode.Parent.Key.Length <5)
				{
					txtDiscount.Tag = "0";
				}
				else
				{
					txtDiscount.Tag = e.TreeNode.Parent.Key.Substring(5);
				}
				
				txtOperName.Tag = e.TreeNode.Key.Substring(5);				
			}
			if (e.TreeNode.Key.StartsWith("oper"))
			{
				gbDept.Visible = false;
				gbOper.Visible = true;
				btnManager.Visible = true;

				gbDept.Left = gbOper.Left;
				gbDept.Top = gbOper.Top+210;

				btnModifyOper.Visible = true;
				btnModifyPwd.Visible = true;
				btnDeleteOper.Visible = true;
				btnCardNo.Visible = true;
				btnCancelCard.Visible = true;

				lblDept.Visible = true;
				cmbDept.Visible = true;
				btnMoveDept.Visible = true;

				txtOperName.Text = e.TreeNode.Text;
				txtOperName.Tag = e.TreeNode.Tag.ToString();//e.TreeNode.Parent.Key.Substring(5);
				txtPwd.Text = "";
				txtPwdConfirm.Text = "";
				txtPwd.Tag = e.TreeNode.Key.Substring(5);

				if (txtOperName.Tag.ToString().Equals("0"))
				{
					btnManager.Visible = false;
				}
				else
				{
					btnManager.Visible = true;
				}
			}
			if (e.TreeNode.Key == "0")
			{
				if (this.dept.cnnDeptID != 0)
				{
					gbDept.Visible = false;
					gbOper.Visible = false;
				}
				else
				{
					gbDept.Visible = true;
					gbOper.Visible = true;
				}
				
				gbDept.Left = gbOper.Left;
				gbDept.Top = gbOper.Top+210;

				btnModifyDept.Visible = false;
				btnDeleteDept.Visible = false;
				btnMoveParentDept.Visible = false;
				lblParentDept.Visible = false;
				cmbParentDept.Visible = false;
				btnCancelCard.Visible = false;

				btnManager.Visible = false;
				btnModifyOper.Visible = false;
				btnModifyPwd.Visible = false;
				btnDeleteOper.Visible = false;
				btnMoveDept.Visible = false;
				btnCardNo.Visible = false;

				lblDept.Visible = false;
				cmbDept.Visible = false;
			

				txtDeptName.Tag = "0";
				txtOperName.Tag = "0";
				txtDeptName.Text = "";
				txtDiscount.Text = "";
				txtOperName.Text = "";
				txtPwd.Text = "";
				txtPwdConfirm.Text = "";
			}
			//txtDeptName.Text = e.TreeNode.Text;
		}

		private void btnAddOper_Click(object sender, System.EventArgs e)
		{
			//添加操作员
			try
			{
				if (txtOperName.Text == "admin")
				{
					throw new BusinessException("操作员管理","操作员添加错误！");
				}
				if (txtOperName.Text.Trim().Length == 0)
				{
					throw new BusinessException("操作员","操作员名称不能为空！");
				}
				if (txtPwd.Text.Trim().Length == 0)
				{
					throw new BusinessException("操作员","操作员密码不能为空！");
				}
				if (txtOperName.Tag == null)
				{
					throw new BusinessException("操作员","请选择要添加操作员的部门！");
				}
				if (txtOperName.Tag.ToString().Length == 0)
				{
					throw new BusinessException("操作员","请选择要添加操作员的部门！");
				}
				DataTable dtOper = Helper.Query("select * from tbOper where cnvcOperName = '"+txtOperName.Text+"'");
				if (dtOper.Rows.Count > 0)
				{
					throw new BusinessException("操作员","同名操作员已存在，不能添加！");
				}
				Oper opers = new Oper();
				opers.cnvcOperName = txtOperName.Text;				
				opers.cnvcPwd = DataSecurity.Encrypt(txtPwd.Text);
				opers.cnnDeptID = int.Parse(txtOperName.Tag.ToString());
				opers.cnvcCardNo = txtCardNo.Text;
				SecurityManage security = new SecurityManage();
				security.AddOper(opers);
				string strMsg = "";
				if (txtCardNo.Text.Length > 0)
				{
					strMsg = "操作员添加成功！发卡成功";
				}
				else
				{
					strMsg = "操作员添加成功！未发卡";
				}
				MessageBox.Show(this,strMsg,"操作员管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindTree();
				BindDept();
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

		private void btnModifyOper_Click(object sender, System.EventArgs e)
		{
			//修改操作员
			try
			{
				if (txtOperName.Text == "admin")
				{
					throw new BusinessException("操作员管理","操作员添加错误！");
				}
				if (txtOperName.Text.Trim().Length == 0)
				{
					throw new BusinessException("操作员","操作员名称不能为空！");
				}
				if (txtPwd.Tag == null)
				{
					throw new BusinessException("操作员","请选择要修改的操作员！");
				}
				if (txtPwd.Tag.ToString().Length == 0)
				{
					throw new BusinessException("操作员","请选择要修改的操作员！");
				}
//				if (txtOperName.Tag == null)
//				{
//					throw new BusinessException("操作员","请选择操作员所属部门！");
//				}
//				if (txtOperName.Tag.ToString().Length == 0)
//				{
//					throw new BusinessException("操作员","请选择操作员所属部门！");
//				}
				DataTable dtOper = Helper.Query("select * from tbOper where cnvcOperName = '"+txtOperName.Text+"'");
				if (dtOper.Rows.Count > 0)
				{
					throw new BusinessException("操作员","同名操作员已存在，不能修改！");
				}
				
				Oper opers = new Oper();
				opers.cnvcOperName = txtOperName.Text;				
				//opers.cnvcPwd = DataSecurity.Encrypt(txtPwd.Text);
				opers.cnnOperID = int.Parse(txtPwd.Tag.ToString());
				//opers.cnnDeptID = int.Parse(txtOperName.Tag.ToString());
				SecurityManage security = new SecurityManage();
				security.ModifyOper(opers);
				MessageBox.Show(this,"操作员修改成功！","操作员管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindTree();
				BindDept();
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

		private void btnModifyPwd_Click(object sender, System.EventArgs e)
		{
			//修改密码
			try
			{
				if (txtPwd.Text.Trim().Length == 0)
				{
					throw new BusinessException("操作员","操作员密码不能为空！");
				}
				if (txtPwdConfirm.Text.Trim().Length == 0)
				{
					throw new BusinessException("操作员","操作员密码确认不能为空！");
				}
				if (txtPwd.Tag == null)
				{
					throw new BusinessException("操作员","请选择要修改密码的操作员！");
				}
				if (txtPwd.Tag.ToString().Length == 0)
				{
					throw new BusinessException("操作员","请选择要修改密码的操作员！");
				}
				if (txtPwd.Text != txtPwdConfirm.Text)
				{
					throw new BusinessException("操作员","确认密码不一致！");
				}
				
				Oper oper = new Oper();
				oper.cnnOperID = int.Parse(txtPwd.Tag.ToString());
				oper.cnvcPwd = DataSecurity.Encrypt(txtPwd.Text);
				SecurityManage securityManage = new SecurityManage();
				securityManage.ModifyPwdByOperID(oper);
				MessageBox.Show(this,"操作员密码修改成功！","操作员密码修改",MessageBoxButtons.OK,MessageBoxIcon.Information);

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

		private void btnDeleteOper_Click(object sender, System.EventArgs e)
		{
			//删除操作员
			try
			{
				if (txtPwd.Tag == null)
				{
					throw new BusinessException("操作员","请选择要删除的操作员！");
				}
				if (txtPwd.Tag.ToString().Length == 0)
				{
					throw new BusinessException("操作员","请选择要删除的操作员！");
				}
				Oper oper = new Oper();
				oper.cnnOperID = int.Parse(txtPwd.Tag.ToString());
				
				SecurityManage securityManage = new SecurityManage();
				securityManage.DeleteOper(oper);
				MessageBox.Show(this,"操作员删除成功！","操作员密码修改",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindTree();
				BindDept();
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

		private void btnAddDept_Click(object sender, System.EventArgs e)
		{
			//添加部门
			try
			{
				if (txtDeptName.Tag == null)
				{
					throw new BusinessException("部门","请选择上级部门！");
				}
				if (txtDeptName.Tag.ToString().Length == 0)
				{
					throw new BusinessException("部门","请选择上级部门！");
				}
				if (txtDeptName.Text.Trim().Length == 0)
				{
					throw new BusinessException("部门","请输入部门名称！");
				}
				if (txtDiscount.Text.Trim().Length == 0)
				{
					throw new BusinessException("部门","请输入部门折扣！");
				}
				DataTable dtDept = Helper.Query("select * from tbDept where cnvcDeptName = '"+txtDeptName.Text+"'");
				if (dtDept.Rows.Count > 0)
				{
					throw new BusinessException("部门","同名部门已存在，不能添加！");
				}
				Dept dept = new Dept();
				dept.cnvcDeptName = txtDeptName.Text;
				dept.cnnDiscount = int.Parse(txtDiscount.Text);
				dept.cnnParentDeptID = int.Parse(txtDeptName.Tag.ToString());									
				SecurityManage security = new SecurityManage();
				security.AddDept(dept);
				MessageBox.Show(this,"部门添加成功！","部门管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindTree();
				BindDept();
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

		private void btnModifyDept_Click(object sender, System.EventArgs e)
		{
			//修改部门
			try
			{
				if (txtDeptName.Tag == null)
				{
					throw new BusinessException("部门","请选择部门！");
				}
				if (txtDeptName.Tag.ToString().Length == 0)
				{
					throw new BusinessException("部门","请选择部门！");
				}
				if (txtDeptName.Text.Trim().Length == 0)
				{
					throw new BusinessException("部门","请输入部门名称！");
				}
				if (txtDiscount.Text.Trim().Length == 0)
				{
					throw new BusinessException("部门","请输入部门折扣！");
				}
				Dept dept = new Dept();
				dept.cnnDeptID = int.Parse(txtDeptName.Tag.ToString());
				dept.cnvcDeptName = txtDeptName.Text;
				dept.cnnDiscount = int.Parse(txtDiscount.Text);
				//dept.cnnParentDeptID = int.Parse(txtDeptName.Tag.ToString());									
				SecurityManage security = new SecurityManage();
				security.ModifyDept(dept);
				MessageBox.Show(this,"部门修改成功！","部门管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindTree();
				BindDept();
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

		private void btnDeleteDept_Click(object sender, System.EventArgs e)
		{
			//删除部门
			try
			{
				if (txtDeptName.Tag == null)
				{
					throw new BusinessException("部门","请选择部门！");
				}
				if (txtDeptName.Tag.ToString().Length == 0)
				{
					throw new BusinessException("部门","请选择部门！");
				}
				
				Dept dept = new Dept();
				dept.cnnDeptID = int.Parse(txtDeptName.Tag.ToString());		
				
				DataTable dtOper = Helper.Query("select * from tbOper where cnnDeptID ="+dept.cnnDeptID.ToString());
				if (dtOper.Rows.Count >0)
				{
					throw new BusinessException("部门","此部门下有操作员不能删除！");
				}
				DataTable dtDept = Helper.Query("select * from tbDept where cnnParentDeptID="+dept.cnnDeptID.ToString());
				if (dtDept.Rows.Count > 0)
				{
					throw new BusinessException("部门","此部门下还有部门不能删除！");
				}

				SecurityManage security = new SecurityManage();
				security.DeleteDept(dept);
				MessageBox.Show(this,"部门删除成功！","部门管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindTree();
				BindDept();
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

		private void btnManager_Click(object sender, System.EventArgs e)
		{
			//设为部门管理员
			try
			{
				if (txtPwd.Tag == null)
				{
					throw new BusinessException("操作员","请选择要设为部门管理员的操作员！");
				}
				if (txtPwd.Tag.ToString().Length == 0)
				{
					throw new BusinessException("操作员","请选择要设为部门管理员的操作员！");
				}
				if (txtOperName.Tag == null)
				{
					throw new BusinessException("操作员","请选择要设置部门管理员的部门");
				}
				if (txtOperName.Tag.ToString().Length == 0)
				{
					throw new BusinessException("操作员","请选择要设置部门管理员的部门");
				}
				Dept dept = new Dept();
				dept.cnnDeptID = int.Parse(txtOperName.Tag.ToString());

				DataTable dtOper = Helper.Query("select * from tbOper where cnnOperID="+txtPwd.Tag.ToString());
				if (dtOper.Rows.Count == 0)
				{
					throw new BusinessException("操作员","无此操作员！");
				}
				dept.cnvcManager = dtOper.Rows[0]["cnvcOperName"].ToString();
				SecurityManage securityManage = new SecurityManage();
				securityManage.SetDeptManager(dept);
				MessageBox.Show(this,"部门管理员设置成功！","操作员密码修改",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindTree();
				BindDept();
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

		private void btnMoveDept_Click(object sender, System.EventArgs e)
		{
			//移动操作员
			try
			{
				if (txtPwd.Tag == null)
				{
					throw new BusinessException("操作员","请选择要移动的操作员！");
				}
				if (txtPwd.Tag.ToString().Length == 0)
				{
					throw new BusinessException("操作员","请选择要移动的操作员！");
				}
				if (cmbDept.Text == "")
				{
					throw new BusinessException("操作员","请选择部门！");
				}
				Oper opers = new Oper();
				opers.cnnOperID = int.Parse(txtPwd.Tag.ToString());
				opers.cnnDeptID = int.Parse(cmbDept.Value.ToString());
				SecurityManage security = new SecurityManage();
				security.DragOper(opers);
				MessageBox.Show(this,"操作员修改成功！","操作员管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindTree();
				BindDept();
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

		private void btnMoveParentDept_Click(object sender, System.EventArgs e)
		{
			//移动部门
			try
			{
				if (txtDeptName.Tag == null)
				{
					throw new BusinessException("部门","请选择部门！");
				}
				if (txtDeptName.Tag.ToString().Length == 0)
				{
					throw new BusinessException("部门","请选择部门！");
				}
				if (cmbParentDept.Text == "")
				{
					throw new BusinessException("部门","请选择上级部门！");
				}
				Dept dept = new Dept();
				dept.cnnDeptID = int.Parse(txtDeptName.Tag.ToString());
				dept.cnnParentDeptID = int.Parse(cmbParentDept.Value.ToString());								
				SecurityManage security = new SecurityManage();
				security.DragDept(dept);
				MessageBox.Show(this,"部门移动成功！","部门管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindTree();
				BindDept();
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

		private void btnCardNo_Click(object sender, System.EventArgs e)
		{
			//发卡
			try
			{
				if (txtCardNo.Text.Trim().Length == 0)
				{
					throw new BusinessException("发卡","请输入操作员卡号");
				}
				if (txtCardNo.Text.Length < 5)
				{
					throw new BusinessException("发卡","操作员卡号必须5位");
				}
				if (txtPwd.Tag == null)
				{
					throw new BusinessException("操作员","请选择要修改的操作员！");
				}
				if (txtPwd.Tag.ToString().Length == 0)
				{
					throw new BusinessException("操作员","请选择要修改的操作员！");
				}
				DataTable dtOper = Helper.Query("select * from tbOper where cnnOperID="+txtPwd.Tag.ToString());
				Oper oldOper = new Oper(dtOper);
				if (oldOper.cnvcCardNo.Trim().Length > 0)
				{
					
					DialogResult dr = MessageBox.Show(this,"已发卡，操作员卡号为："+oldOper.cnvcCardNo+"，是否继续发卡？","操作员管理",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
					if (dr == DialogResult.Yes)
					{
						Oper oper = new Oper();
						oper.cnnOperID = int.Parse(txtPwd.Tag.ToString());
						oper.cnvcCardNo = txtCardNo.Text;
						SecurityManage sm = new SecurityManage();
						sm.AddCard(oper);
						MessageBox.Show(this,"发卡成功！","操作员管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
					}
				}
				else
				{
					Oper oper = new Oper();
					oper.cnnOperID = int.Parse(txtPwd.Tag.ToString());
					oper.cnvcCardNo = txtCardNo.Text;
					SecurityManage sm = new SecurityManage();
					sm.AddCard(oper);
					MessageBox.Show(this,"发卡成功！","操作员管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

		private void btnCancelCard_Click(object sender, System.EventArgs e)
		{
			//取消卡
			try
			{
				if (txtPwd.Tag == null)
				{
					throw new BusinessException("操作员","请选择要取消卡的操作员！");
				}
				if (txtPwd.Tag.ToString().Length == 0)
				{
					throw new BusinessException("操作员","请选择要取消卡的操作员！");
				}
				Oper oper = new Oper();
				oper.cnnOperID = int.Parse(txtPwd.Tag.ToString());
				SecurityManage sm = new SecurityManage();
				sm.CancelCard(oper);
				MessageBox.Show(this,"取消卡成功！","操作员管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				
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
