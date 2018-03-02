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
	/// 业务员管理
	/// </summary>
    public class SalesManage : frmBase
	{
		private Infragistics.Win.UltraWinTree.UltraTree ultraTree1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList1;
        private Infragistics.Win.Misc.UltraButton btnAddOper;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtOperName;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraGroupBox gbOper;
		private Infragistics.Win.Misc.UltraButton btnDeleteOper;
        private Infragistics.Win.Misc.UltraButton btnModifyOper;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDept;
        private Infragistics.Win.Misc.UltraLabel lblDept;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCredentials;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtTel;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		public static bool IsShowing ;
		public SalesManage()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesManage));
            this.ultraTree1 = new Infragistics.Win.UltraWinTree.UltraTree();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gbOper = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtTel = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.txtCredentials = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.lblDept = new Infragistics.Win.Misc.UltraLabel();
            this.cmbDept = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnDeleteOper = new Infragistics.Win.Misc.UltraButton();
            this.btnModifyOper = new Infragistics.Win.Misc.UltraButton();
            this.btnAddOper = new Infragistics.Win.Misc.UltraButton();
            this.txtOperName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbOper)).BeginInit();
            this.gbOper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCredentials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperName)).BeginInit();
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
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // gbOper
            // 
            this.gbOper.Controls.Add(this.txtTel);
            this.gbOper.Controls.Add(this.ultraLabel2);
            this.gbOper.Controls.Add(this.txtCredentials);
            this.gbOper.Controls.Add(this.ultraLabel6);
            this.gbOper.Controls.Add(this.lblDept);
            this.gbOper.Controls.Add(this.cmbDept);
            this.gbOper.Controls.Add(this.btnDeleteOper);
            this.gbOper.Controls.Add(this.btnModifyOper);
            this.gbOper.Controls.Add(this.btnAddOper);
            this.gbOper.Controls.Add(this.txtOperName);
            this.gbOper.Controls.Add(this.ultraLabel1);
            this.gbOper.Location = new System.Drawing.Point(528, 32);
            this.gbOper.Name = "gbOper";
            this.gbOper.Size = new System.Drawing.Size(376, 232);
            this.gbOper.TabIndex = 1;
            this.gbOper.Text = "业务员";
            // 
            // txtTel
            // 
            this.txtTel.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtTel.Location = new System.Drawing.Point(144, 67);
            this.txtTel.MaxLength = 20;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(100, 21);
            this.txtTel.TabIndex = 31;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(24, 67);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 30;
            this.ultraLabel2.Text = "电话：";
            // 
            // txtCredentials
            // 
            this.txtCredentials.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtCredentials.Location = new System.Drawing.Point(144, 93);
            this.txtCredentials.MaxLength = 40;
            this.txtCredentials.Name = "txtCredentials";
            this.txtCredentials.Size = new System.Drawing.Size(100, 21);
            this.txtCredentials.TabIndex = 27;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(24, 93);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel6.TabIndex = 26;
            this.ultraLabel6.Text = "证件号：";
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(24, 117);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(100, 23);
            this.lblDept.TabIndex = 22;
            this.lblDept.Text = "所属部门：";
            // 
            // cmbDept
            // 
            this.cmbDept.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbDept.Location = new System.Drawing.Point(144, 117);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(104, 21);
            this.cmbDept.TabIndex = 21;
            // 
            // btnDeleteOper
            // 
            this.btnDeleteOper.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnDeleteOper.Location = new System.Drawing.Point(185, 168);
            this.btnDeleteOper.Name = "btnDeleteOper";
            this.btnDeleteOper.Size = new System.Drawing.Size(72, 23);
            this.btnDeleteOper.TabIndex = 16;
            this.btnDeleteOper.Text = "删除";
            this.btnDeleteOper.Click += new System.EventHandler(this.btnDeleteOper_Click);
            // 
            // btnModifyOper
            // 
            this.btnModifyOper.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnModifyOper.Location = new System.Drawing.Point(107, 168);
            this.btnModifyOper.Name = "btnModifyOper";
            this.btnModifyOper.Size = new System.Drawing.Size(72, 23);
            this.btnModifyOper.TabIndex = 15;
            this.btnModifyOper.Text = "修改";
            this.btnModifyOper.Click += new System.EventHandler(this.btnModifyOper_Click);
            // 
            // btnAddOper
            // 
            this.btnAddOper.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnAddOper.Location = new System.Drawing.Point(24, 168);
            this.btnAddOper.Name = "btnAddOper";
            this.btnAddOper.Size = new System.Drawing.Size(72, 23);
            this.btnAddOper.TabIndex = 6;
            this.btnAddOper.Text = "添加";
            this.btnAddOper.Click += new System.EventHandler(this.btnAddOper_Click);
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
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "业务员：";
            // 
            // SalesManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(936, 533);
            this.Controls.Add(this.gbOper);
            this.Controls.Add(this.ultraTree1);
            this.Name = "SalesManage";
            this.Text = "业务员管理";
            this.Load += new System.EventHandler(this.SalesManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbOper)).EndInit();
            this.gbOper.ResumeLayout(false);
            this.gbOper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCredentials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperName)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void SalesManage_Load(object sender, System.EventArgs e)
		{
			BindTree();
			BindDept();
            gbOper.Visible = false;
		}
		private void BindDept()
		{
			DataTable dtDept = getDept();
			cmbDept.DataSource = dtDept;
			cmbDept.DisplayMember = "cnvcDeptName";
			cmbDept.ValueMember = "cnnDeptID";
			cmbDept.DataBind();
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
			DataTable dtOper = Helper.Query("select * from tbSales");	
			if (this.dept.cnnDeptID == 0)
			{
				UltraTreeNode tnParent = new UltraTreeNode("0","云南人才市场");
				DataRow[] drOpers = dtOper.Select("cnnDeptID=0");
				foreach (DataRow drOper in drOpers)
				{
					UltraTreeNode tnOper = new UltraTreeNode("oper-"+drOper["cnnSales"].ToString(),drOper["cnvcSales"].ToString());
                    Sales sales = new Sales(drOper);
					tnOper.Tag = sales;
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
					AddNodes(tnParent,dtDept,dtOper,"0");
					tnParent.ExpandAll();
					this.ultraTree1.Nodes.Clear();
					this.ultraTree1.Nodes.Add(tnParent);
				}
				else
				{
					MessageBox.Show("普通业务员无权限操作","部门管理");
				}
			}
			
		}
        private void AddNodes(UltraTreeNode tnParent, DataTable dtDept, DataTable dtOper, string strDeptID)
        {
            DataRow[] drSubDepts = dtDept.Select("cnnParentDeptID=" + strDeptID);
            if (drSubDepts.Length > 0)
            {
                foreach (DataRow drSubDept in drSubDepts)
                {
                    UltraTreeNode tnChild = new UltraTreeNode("dept-" + drSubDept["cnnDeptID"].ToString(), drSubDept["cnvcDeptName"].ToString());
                    Dept dept = new Dept(drSubDept);
                    tnChild.Tag = dept;
                    DataRow[] drOpers = dtOper.Select("cnnDeptID=" + drSubDept["cnnDeptID"].ToString());
                    foreach (DataRow drOper in drOpers)
                    {
                        UltraTreeNode tnOper = new UltraTreeNode("oper-" + drOper["cnnSales"].ToString(), drOper["cnvcSales"].ToString());
                        tnOper.Override.NodeAppearance.Image = 1;
                        Sales sales = new Sales(drOper);
                        tnOper.Tag = sales;
                        tnChild.Nodes.Add(tnOper);
                    }
                    AddNodes(tnChild, dtDept, dtOper, drSubDept["cnnDeptID"].ToString());
                    tnParent.Nodes.Add(tnChild);
                }
            }

        }
		private void ultraTree1_AfterActivate(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
		{
			if (e.TreeNode.Key.StartsWith("dept"))
			{
                gbOper.Visible = true;
                Dept dept = e.TreeNode.Tag as Dept;
				txtOperName.Text = "";
                txtOperName.Tag = "";
                txtCredentials.Text = "";
                txtTel.Text = "";
                cmbDept.Value = dept.cnnDeptID;

                btnAddOper.Visible = true;
				btnModifyOper.Visible = false;
				btnDeleteOper.Visible = false;						
			}
			if (e.TreeNode.Key.StartsWith("oper"))
			{
                gbOper.Visible = true;
                Sales sales = e.TreeNode.Tag as Sales;
                btnAddOper.Visible = false;
				btnModifyOper.Visible = true;
				btnDeleteOper.Visible = true;

                txtOperName.Text = sales.cnvcSales;
                txtCredentials.Text = sales.cnvcCredentials;
                txtTel.Text = sales.cnvcTel;
                cmbDept.Value = sales.cnnDeptID;

                txtOperName.Tag = sales;
			}
            //if (e.TreeNode.Key == "0")
            //{
            //    if (this.dept.cnnDeptID != 0)
            //    {
            //        gbOper.Visible = false;
            //    }
            //    else
            //    {
            //        gbOper.Visible = true;

            //        btnAddOper.Visible = true;
            //        btnModifyOper.Visible = false;
            //        btnDeleteOper.Visible = false;

            //        txtOperName.Text = "";
            //        txtTel.Text = "";
            //        txtCredentials.Text = "";
            //    }
                
            //}
		}

		private void btnAddOper_Click(object sender, System.EventArgs e)
		{
			//添加业务员
			try
			{
				if (txtOperName.Text.Trim().Length == 0)
				{
					throw new BusinessException("业务员","业务员名称不能为空！");
				}
                if (cmbDept.Value == null)
                {
                    throw new BusinessException("业务员", "请选择要添加业务员的部门！");
                }
				DataTable dtOper = Helper.Query("select * from tbSales where cnvcSales = '"+txtOperName.Text+"'");
				if (dtOper.Rows.Count > 0)
				{
					throw new BusinessException("业务员","同名业务员已存在，不能添加！");
				}
                Sales opers = new Sales();
				opers.cnvcSales = txtOperName.Text;
                opers.cnnDeptID = Convert.ToInt32(this.cmbDept.Value);
                opers.cnvcTel = txtTel.Text;
                opers.cnvcCredentials = txtCredentials.Text;

				SecurityManage security = new SecurityManage();
				security.AddSales(opers);
                string strMsg = "业务员员添加成功！";
				MessageBox.Show(this,strMsg,"业务员管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindTree();
				//BindDept();
                gbOper.Visible = false;
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
			//修改业务员
			try
			{
				if (txtOperName.Text.Trim().Length == 0)
				{
                    throw new BusinessException("业务员", "业务员名称不能为空！");
				}
                if (cmbDept.Value == null)
                {
                    throw new BusinessException("业务员", "请选择要添加业务员的部门！");
                }
                Sales oldSales = txtOperName.Tag as Sales;
                if (!oldSales.cnvcSales.Equals(txtOperName.Text))
                {
                    DataTable dtOper = Helper.Query("select * from tbSales where cnvcSales = '" + txtOperName.Text + "'");
                    if (dtOper.Rows.Count > 0)
                    {
                        throw new BusinessException("业务员", "同名业务员已存在，不能修改！");
                    }
                }
				Sales opers = new Sales();
                opers.cnnSales = oldSales.cnnSales;
				opers.cnvcSales = txtOperName.Text;
                opers.cnvcTel = txtTel.Text;
                opers.cnvcCredentials = txtCredentials.Text;
                opers.cnnDeptID = Convert.ToInt32(cmbDept.Value);

				SecurityManage security = new SecurityManage();
				security.ModifySales(opers);
				MessageBox.Show(this,"业务员修改成功！","业务员管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindTree();
				//BindDept();
                gbOper.Visible = false;
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
			//删除业务员
			try
			{
                Sales oldSales = txtOperName.Tag as Sales;
				
				SecurityManage securityManage = new SecurityManage();
                securityManage.DeleteSales(oldSales);
				MessageBox.Show(this,"业务员删除成功！","业务员管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
				BindTree();
				//BindDept();
                gbOper.Visible = false;
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
