using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.Domain;
using ynhrMemberManage.ORM;
using System.Data;
using System.Data.SqlClient;
using ynhrMemberManage.Common;
using ynhrMemberManage.BusinessFacade.MemberBusiness;
using MemberManage.Business;
using Infragistics.Win.UltraWinGrid;

namespace MemberManage.MemberBusiness
{
	/// <summary>
	/// Summary description for JobAdd.
	/// </summary>
    public class JobAdd : frmBase
	{
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;

		public static bool IsShowing ;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtJobName;
		private Infragistics.Win.Misc.UltraButton btnOK;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBegin;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEnd;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBookEndDate;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBookBeginDate;
        private Infragistics.Win.UltraWinGrid.UltraCombo ultraCombo1;
        private Infragistics.Win.Misc.UltraLabel txtPrice;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public JobAdd()
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
            this.btnOK = new Infragistics.Win.Misc.UltraButton();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.txtJobName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtPrice = new Infragistics.Win.Misc.UltraLabel();
            this.ultraCombo1 = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.cmbBookEndDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.cmbBookBeginDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbEnd = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.cmbBegin = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCombo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBookEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBookBeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBegin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnOK.Location = new System.Drawing.Point(96, 392);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnCancel.Location = new System.Drawing.Point(224, 392);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(64, 73);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 2;
            this.ultraLabel1.Text = "招聘会名称：";
            // 
            // txtJobName
            // 
            this.txtJobName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtJobName.Location = new System.Drawing.Point(168, 73);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(200, 21);
            this.txtJobName.TabIndex = 3;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(64, 112);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 4;
            this.ultraLabel2.Text = "所属服务产品：";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(52, 162);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(112, 23);
            this.ultraLabel3.TabIndex = 6;
            this.ultraLabel3.Text = "招聘会开始时间：";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(52, 202);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(112, 23);
            this.ultraLabel4.TabIndex = 7;
            this.ultraLabel4.Text = "招聘会结束时间：";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtPrice);
            this.ultraGroupBox1.Controls.Add(this.ultraCombo1);
            this.ultraGroupBox1.Controls.Add(this.cmbBookEndDate);
            this.ultraGroupBox1.Controls.Add(this.cmbBookBeginDate);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel6);
            this.ultraGroupBox1.Controls.Add(this.cmbEnd);
            this.ultraGroupBox1.Controls.Add(this.cmbBegin);
            this.ultraGroupBox1.Controls.Add(this.txtJobName);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox1.Controls.Add(this.btnOK);
            this.ultraGroupBox1.Controls.Add(this.btnCancel);
            this.ultraGroupBox1.Location = new System.Drawing.Point(248, 16);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(384, 472);
            this.ultraGroupBox1.TabIndex = 8;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(168, 133);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 23);
            this.txtPrice.TabIndex = 19;
            // 
            // ultraCombo1
            // 
            this.ultraCombo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ultraCombo1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Default;
            this.ultraCombo1.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.ultraCombo1.Location = new System.Drawing.Point(168, 113);
            this.ultraCombo1.Name = "ultraCombo1";
            this.ultraCombo1.Size = new System.Drawing.Size(200, 22);
            this.ultraCombo1.TabIndex = 18;
            this.ultraCombo1.AfterDropDown += new System.EventHandler(this.ultraCombo1_AfterDropDown);
            this.ultraCombo1.ValueChanged += new System.EventHandler(this.ultraCombo1_ValueChanged);
            this.ultraCombo1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraCombo1_InitializeLayout);
            // 
            // cmbBookEndDate
            // 
            this.cmbBookEndDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbBookEndDate.Location = new System.Drawing.Point(172, 282);
            this.cmbBookEndDate.MaskInput = "{date} {time}";
            this.cmbBookEndDate.Name = "cmbBookEndDate";
            this.cmbBookEndDate.Size = new System.Drawing.Size(200, 21);
            this.cmbBookEndDate.TabIndex = 16;
            // 
            // cmbBookBeginDate
            // 
            this.cmbBookBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbBookBeginDate.Location = new System.Drawing.Point(172, 242);
            this.cmbBookBeginDate.MaskInput = "{date} {time}";
            this.cmbBookBeginDate.Name = "cmbBookBeginDate";
            this.cmbBookBeginDate.Size = new System.Drawing.Size(200, 21);
            this.cmbBookBeginDate.TabIndex = 15;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(60, 242);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(96, 23);
            this.ultraLabel5.TabIndex = 13;
            this.ultraLabel5.Text = "预订开始时间：";
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(60, 282);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(104, 23);
            this.ultraLabel6.TabIndex = 14;
            this.ultraLabel6.Text = "预订结束时间：";
            // 
            // cmbEnd
            // 
            this.cmbEnd.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbEnd.Location = new System.Drawing.Point(172, 202);
            this.cmbEnd.MaskInput = "{date} {time}";
            this.cmbEnd.Name = "cmbEnd";
            this.cmbEnd.Size = new System.Drawing.Size(200, 21);
            this.cmbEnd.TabIndex = 12;
            this.cmbEnd.ValueChanged += new System.EventHandler(this.cmbEnd_ValueChanged);
            // 
            // cmbBegin
            // 
            this.cmbBegin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbBegin.Location = new System.Drawing.Point(172, 162);
            this.cmbBegin.MaskInput = "{date} {time}";
            this.cmbBegin.Name = "cmbBegin";
            this.cmbBegin.Size = new System.Drawing.Size(200, 21);
            this.cmbBegin.TabIndex = 11;
            this.cmbBegin.ValueChanged += new System.EventHandler(this.cmbBegin_ValueChanged);
            // 
            // JobAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(880, 517);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "JobAdd";
            this.Text = "招聘会新设";
            this.Load += new System.EventHandler(this.JobAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtJobName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCombo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBookEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBookBeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBegin)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (txtJobName.Text.Trim().Length == 0)
				{
					throw new BusinessException("招聘会新设","请输入招聘会名称！");
				}
				DataTable dtJob = Helper.Query("select * from tbJob where cnvcJobName ='"+txtJobName.Text+"'");
				if (dtJob.Rows.Count > 0)
				{
					throw new BusinessException("招聘会新设","同名招聘会已存在！");
				}
				Job job = new Job();
				job.cnvcJobName = txtJobName.Text;
                job.cnvcJobTheme = this.ultraCombo1.Value.ToString();//this.ultraComboEditor1.Text;//txtJobTheme.Text;
				job.cndBeginDate = DateTime.Parse(cmbBegin.Text);
				job.cndEndDate = DateTime.Parse(cmbEnd.Text);
				job.cndBookBeginDate = DateTime.Parse(cmbBookBeginDate.Text);
				job.cndBookEndDate = DateTime.Parse(cmbBookEndDate.Text);
				job.cnvcOperName = this.oper.cnvcOperName;
				job.cndOperDate = DateTime.Now;
				if (job.cndEndDate < job.cndBeginDate)
				{
					throw new BusinessException("招聘会新设","招聘会开始时间不能大于结束时间！");
				}
				if (job.cndBookEndDate < job.cndBookBeginDate)
				{
					throw new BusinessException("招聘会新设","招聘会预订开始时间不能大于预订结束时间！");
				}
				if (job.cndEndDate < job.cndBookEndDate)
				{
					throw new BusinessException("招聘会新设","招聘会预订开始时间不能大于招聘会结束时间！");
				}
				JobManage jobManage = new JobManage();
				jobManage.AddJob(job);
				MessageBox.Show(this,"添加招聘会成功！","招聘会新设",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtJobName.Text = "";
				//txtJobTheme.Text = "";

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

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void JobAdd_Load(object sender, System.EventArgs e)
		{
			cmbBegin.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEnd.MaskInput = "yyyy-mm-dd hh:mm";
			cmbBookBeginDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbBookEndDate.MaskInput = "yyyy-mm-dd hh:mm";
			cmbEnd.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 23:59";
			cmbBookEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd")+" 23:59";

			DateTime dtBegin = DateTime.Parse(cmbBegin.Value.ToString());
			cmbBookBeginDate.Value = dtBegin.AddDays(-(Login.constApp.iBookDate)).ToString("yyyy-MM-dd");

            //ClientHelper.BindProduct(this.ultraComboEditor1);
            //Bind();
            Helper.BindProduct(this.ultraCombo1);
		}
        
        //private void BindNamecode()
        //{
        //    DataTable dtNameCode = Helper.Query("select * from tbNameCode  where cnvcType='" + ConstApp.Product + "' order by cnvcType,cnvcValue");
        //    this.ultraComboEditor1.DataSource = dtNameCode;
        //    this.ultraComboEditor1.ValueMember = "cnvcValue";
        //    this.ultraComboEditor1.DisplayMember = "cnvcValue";
            
        //    this.ultraComboEditor1.DataBind();
        //}

		private void cmbBegin_ValueChanged(object sender, System.EventArgs e)
		{
			DateTime dtBegin = DateTime.Parse(cmbBegin.Value.ToString());
			cmbBookBeginDate.Value = dtBegin.AddDays(-(Login.constApp.iBookDate)).ToString("yyyy-MM-dd");			
		}

		private void cmbEnd_ValueChanged(object sender, System.EventArgs e)
		{
			cmbBookEndDate.Value = cmbEnd.Value;
		}

        private void ultraCombo1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Helper.SetGridDisplay(e);
            e.Layout.Bands[0].Columns["cnvcIsSelected"].Hidden = true;
            e.Layout.Bands[0].Columns["cnnPrepay"].Hidden = true;
            e.Layout.Bands[0].Columns["cnvcFree"].Hidden = true;
            e.Layout.Bands[0].Columns["cnnCount"].Hidden = true;
            e.Layout.Bands[0].Columns["cnvcProductName"].Header.Caption = "产品名称";
            e.Layout.Bands[0].Columns["cnnProductPrice"].Header.Caption = "产品单价";
            e.Layout.Bands[0].Columns["cnnProductDiscount"].Header.Caption = "产品折扣";
        }

        private void ultraCombo1_AfterDropDown(object sender, EventArgs e)
        {
           
        }

        private void ultraCombo1_ValueChanged(object sender, EventArgs e)
        {
            UltraGridRow cur = this.ultraCombo1.SelectedRow;
            if (cur != null)
            {
                this.txtPrice.Text = "产品单价：" + cur.Cells["cnnProductPrice"].Value.ToString() + "，产品折扣：" + cur.Cells["cnnProductDiscount"].Value.ToString();
            }
        }
	}
}
