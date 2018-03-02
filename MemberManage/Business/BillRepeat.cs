using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.ORM;
//using ynhrMemberManage.MemberManage;
using ynhrMemberManage.Domain;
using MemberManage.Reports;
using System.Data;
using System.Data.SqlClient;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using MemberManage.Business;
using ynhrMemberManage.Print;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Common;
using ynhrMemberManage.Business;
namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for BillRepeat.
	/// </summary>
    public class BillRepeat : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.Misc.UltraButton ultraButton2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberCardNo;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbBillType;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor cmbEndDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBeginDate;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEndDate;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbOperName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMemberName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPaperNo;
		public static bool IsShowing ;
		public Member pMember = null;//= new Member();
		private Infragistics.Win.Printing.UltraPrintDocument ultraPrintDocument1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private System.ComponentModel.IContainer components;

		public BillRepeat()
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
			this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.txtPaperNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.txtMemberName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
			this.cmbOperName = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.chkEndDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.chkBeginDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.cmbEndDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.cmbBeginDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.cmbBillType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.txtMemberCardNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
			this.ultraPrintDocument1 = new Infragistics.Win.Printing.UltraPrintDocument(this.components);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
			this.ultraGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbOperName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBillType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
			this.ultraGroupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// ultraGroupBox1
			// 
			this.ultraGroupBox1.Controls.Add(this.ultraLabel5);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel4);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
			this.ultraGroupBox1.Controls.Add(this.txtPaperNo);
			this.ultraGroupBox1.Controls.Add(this.txtMemberName);
			this.ultraGroupBox1.Controls.Add(this.ultraButton1);
			this.ultraGroupBox1.Controls.Add(this.cmbOperName);
			this.ultraGroupBox1.Controls.Add(this.chkEndDate);
			this.ultraGroupBox1.Controls.Add(this.chkBeginDate);
			this.ultraGroupBox1.Controls.Add(this.cmbEndDate);
			this.ultraGroupBox1.Controls.Add(this.cmbBeginDate);
			this.ultraGroupBox1.Controls.Add(this.cmbBillType);
			this.ultraGroupBox1.Controls.Add(this.txtMemberCardNo);
			this.ultraGroupBox1.Location = new System.Drawing.Point(72, 32);
			this.ultraGroupBox1.Name = "ultraGroupBox1";
			this.ultraGroupBox1.Size = new System.Drawing.Size(704, 200);
			this.ultraGroupBox1.TabIndex = 0;
			// 
			// ultraLabel5
			// 
			this.ultraLabel5.Location = new System.Drawing.Point(264, 72);
			this.ultraLabel5.Name = "ultraLabel5";
			this.ultraLabel5.TabIndex = 23;
			this.ultraLabel5.Text = "СƱ���ͣ�";
			// 
			// ultraLabel4
			// 
			this.ultraLabel4.Location = new System.Drawing.Point(32, 72);
			this.ultraLabel4.Name = "ultraLabel4";
			this.ultraLabel4.TabIndex = 22;
			this.ultraLabel4.Text = "����Ա��";
			// 
			// ultraLabel3
			// 
			this.ultraLabel3.Location = new System.Drawing.Point(496, 32);
			this.ultraLabel3.Name = "ultraLabel3";
			this.ultraLabel3.TabIndex = 21;
			this.ultraLabel3.Text = "����ע��ţ�";
			// 
			// ultraLabel2
			// 
			this.ultraLabel2.Location = new System.Drawing.Point(264, 32);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.TabIndex = 20;
			this.ultraLabel2.Text = "��λ���ƣ�";
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.Location = new System.Drawing.Point(32, 32);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.TabIndex = 19;
			this.ultraLabel1.Text = "��Ա���ţ�";
			// 
			// txtPaperNo
			// 
			this.txtPaperNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtPaperNo.Location = new System.Drawing.Point(592, 32);
			this.txtPaperNo.Name = "txtPaperNo";
			this.txtPaperNo.Size = new System.Drawing.Size(100, 21);
			this.txtPaperNo.TabIndex = 17;
			// 
			// txtMemberName
			// 
			this.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtMemberName.Location = new System.Drawing.Point(368, 32);
			this.txtMemberName.Name = "txtMemberName";
			this.txtMemberName.Size = new System.Drawing.Size(100, 21);
			this.txtMemberName.TabIndex = 15;
			// 
			// ultraButton1
			// 
			this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.ultraButton1.Location = new System.Drawing.Point(288, 152);
			this.ultraButton1.Name = "ultraButton1";
			this.ultraButton1.TabIndex = 14;
			this.ultraButton1.Text = "��ѯ";
			this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
			// 
			// cmbOperName
			// 
			this.cmbOperName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbOperName.Location = new System.Drawing.Point(136, 72);
			this.cmbOperName.Name = "cmbOperName";
			this.cmbOperName.Size = new System.Drawing.Size(104, 21);
			this.cmbOperName.TabIndex = 13;
			// 
			// chkEndDate
			// 
			this.chkEndDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.chkEndDate.Location = new System.Drawing.Point(376, 112);
			this.chkEndDate.Name = "chkEndDate";
			this.chkEndDate.TabIndex = 11;
			this.chkEndDate.Text = "��������ʱ��";
			// 
			// chkBeginDate
			// 
			this.chkBeginDate.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.chkBeginDate.Location = new System.Drawing.Point(16, 112);
			this.chkBeginDate.Name = "chkBeginDate";
			this.chkBeginDate.TabIndex = 10;
			this.chkBeginDate.Text = "������ʼʱ��";
			// 
			// cmbEndDate
			// 
			this.cmbEndDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbEndDate.Location = new System.Drawing.Point(504, 112);
			this.cmbEndDate.MaskInput = "{date} {time}";
			this.cmbEndDate.Name = "cmbEndDate";
			this.cmbEndDate.TabIndex = 5;
			// 
			// cmbBeginDate
			// 
			this.cmbBeginDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbBeginDate.Location = new System.Drawing.Point(136, 112);
			this.cmbBeginDate.MaskInput = "{date} {time}";
			this.cmbBeginDate.Name = "cmbBeginDate";
			this.cmbBeginDate.TabIndex = 4;
			// 
			// cmbBillType
			// 
			this.cmbBillType.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbBillType.Location = new System.Drawing.Point(368, 72);
			this.cmbBillType.Name = "cmbBillType";
			this.cmbBillType.Size = new System.Drawing.Size(104, 21);
			this.cmbBillType.TabIndex = 2;
			// 
			// txtMemberCardNo
			// 
			this.txtMemberCardNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtMemberCardNo.Location = new System.Drawing.Point(136, 32);
			this.txtMemberCardNo.Name = "txtMemberCardNo";
			this.txtMemberCardNo.Size = new System.Drawing.Size(100, 21);
			this.txtMemberCardNo.TabIndex = 1;
			// 
			// ultraGrid1
			// 
			this.ultraGrid1.Location = new System.Drawing.Point(80, 248);
			this.ultraGrid1.Name = "ultraGrid1";
			this.ultraGrid1.Size = new System.Drawing.Size(704, 224);
			this.ultraGrid1.TabIndex = 1;
			this.ultraGrid1.Text = "СƱ�б�";
			this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
			// 
			// ultraGroupBox2
			// 
			this.ultraGroupBox2.Controls.Add(this.ultraButton2);
			this.ultraGroupBox2.Location = new System.Drawing.Point(168, 488);
			this.ultraGroupBox2.Name = "ultraGroupBox2";
			this.ultraGroupBox2.Size = new System.Drawing.Size(552, 72);
			this.ultraGroupBox2.TabIndex = 2;
			// 
			// ultraButton2
			// 
			this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.ultraButton2.Location = new System.Drawing.Point(239, 25);
			this.ultraButton2.Name = "ultraButton2";
			this.ultraButton2.TabIndex = 15;
			this.ultraButton2.Text = "�ش�";
			this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
			// 
			// ultraPrintDocument1
			// 
			this.ultraPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.ultraPrintDocument1_PrintPage);
			// 
			// BillRepeat
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(864, 621);
			this.Controls.Add(this.ultraGroupBox2);
			this.Controls.Add(this.ultraGrid1);
			this.Controls.Add(this.ultraGroupBox1);
			this.Name = "BillRepeat";
			this.Text = "СƱ�ش�";
			this.Load += new System.EventHandler(this.BillRepeat_Load);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
			this.ultraGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtPaperNo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbOperName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbEndDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBeginDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBillType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberCardNo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
			this.ultraGroupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			//��ѯСƱ
            //try
            //{
				string strSql = "select * from tbBill where 1=1 ";
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
				if (cmbBillType.Text.Trim().Length > 0)
				{
					strSql += " and cnvcBillType like '%"+cmbBillType.Text+"%'";
				}
				if (chkBeginDate.Checked)
				{
					strSql += " and cndOperDate >= '"+cmbBeginDate.Value.ToString()+"'";
				}
				if (chkEndDate.Checked)
				{
					strSql += " and cndOperDate <= '"+cmbEndDate.Value.ToString()+"'";
				}

				if (cmbOperName.Text.Trim().Length > 0)
				{
					strSql += " and cnvcOperName = '"+cmbOperName.Text+"'";
				}

				//Query query = new Query();
				DataTable dt = Helper.Query(strSql);//query.Report(strSql);
				this.ultraGrid1.DataSource = null;
				this.ultraGrid1.DataSource = dt;
				this.ultraGrid1.DataBind();
            //}
            //catch (BusinessException bex)
            //{
            //    MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(this,ex.Message,"ϵͳ����",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}
		}

		private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			Helper.SetGridDisplay(e);
			e.Layout.Bands[0].Columns["cnnID"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcMemberCardNo"].Header.Caption = "��Ա����";
			e.Layout.Bands[0].Columns["cnvcMemberPwd"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcMemberName"].Header.Caption = "��λ����";
			e.Layout.Bands[0].Columns["cnvcOperName"].Header.Caption = "����Ա";
			e.Layout.Bands[0].Columns["cndOperDate"].Header.Caption = "����ʱ��";
			e.Layout.Bands[0].Columns["cnvcBillType"].Header.Caption = "СƱ����";
			e.Layout.Bands[0].Columns["cnvcPaperNo"].Header.Caption = "����ע���";
			e.Layout.Bands[0].Columns["cnvcProduct"].Header.Caption = "�����Ʒ";
			e.Layout.Bands[0].Columns["cnvcFree"].Header.Caption = "ʣ�ೡ��";
            e.Layout.Bands[0].Columns["cnvcFree"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcSeat"].Header.Caption = "չλ";
			e.Layout.Bands[0].Columns["cnvcMemberRight"].Header.Caption = "��Ա�ʸ�";
			e.Layout.Bands[0].Columns["cnvcShow"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcJobInfo"].Hidden = true;
			e.Layout.Bands[0].Columns["cnnRepeats"].Hidden = true;
			e.Layout.Bands[0].Columns["cnnMemberFee"].Hidden = true;
			e.Layout.Bands[0].Columns["cnvcDiscount"].Hidden = true;
			//e.Layout.Bands[0].Columns["cnnPrepay"].Hidden = true;
			e.Layout.Bands[0].Columns["cndEndDate"].Hidden = true;
			e.Layout.Bands[0].Columns["cndOperDate"].CellActivation = Activation.NoEdit;
			e.Layout.Bands[0].Columns["cndOperDate"].Format = "yyyy-MM-dd hh:mm";

            e.Layout.Bands[0].Columns["cnnPrepay"].Header.Caption = "��ֵ���";
            e.Layout.Bands[0].Columns["cnnLastBalance"].Header.Caption = "�ϴ����";
            e.Layout.Bands[0].Columns["cnnBalance"].Header.Caption = "��ǰ���";
            e.Layout.Bands[0].Columns["cnnDonate"].Header.Caption = "���ͽ��";
            e.Layout.Bands[0].Columns["cnvcSynch"].Header.Caption = "ͬ����־";
		}

		private void ultraButton2_Click(object sender, System.EventArgs e)
		{
            //try
            //{

				//�ش�
				UltraGridRow  selectedRow = this.ultraGrid1.ActiveRow;//.Selected.Rows[0];
				if (null == selectedRow)
				{
					throw new BusinessException("СƱ�ش�","��ѡ���ش��СƱ");
				}
				ArrayList alRow = new ArrayList();
				DataRowView dr = selectedRow.ListObject as DataRowView;
				Bill bill = new Bill(dr.Row);
//				pMember = new Member(dr.Row);
//				pMember.cnvcComments = bill.cnvcBillType;
                MemberManageFacade memberManage = new MemberManageFacade();
				memberManage.UpdateBillRepeats(bill);

                PrintedBill pBill = new PrintedBill(dr.Row);
                Helper.PrintTicket(pBill);




                //TouchPrintedBill pBill2 = new TouchPrintedBill(dr.Row);
                //TouchPrintEngine printEngine = new TouchPrintEngine();
                //printEngine.AddPrintObject(pBill2);
                //printEngine.Print();
				//this.ultraPrintDocument1.Print();
				
            //}
            //catch (BusinessException bex)
            //{
            //    MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(this,ex.Message,"ϵͳ����",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}
		}

		private void PrintBill(System.Drawing.Printing.PrintPageEventArgs e,Member pMember,string strBillType)
		{
			Font drawFontTitle = new Font("Arial", 14);
			Font drawFontBody = new Font("Arial", 8);
			SolidBrush drawBrush = new SolidBrush(Color.Black);			

			StringFormat drawFormat = new StringFormat();
			drawFormat.FormatFlags = StringFormatFlags.DisplayFormatControl;
			if (strBillType == ConstApp.Bill_Type_Provide)
			{				
				e.Graphics.DrawString("�����˲��г�", drawFontTitle, drawBrush, 50.0f, 40.0f, drawFormat);
				e.Graphics.DrawLine(new Pen(drawBrush,1.0f),0.0f,68.0f,300.0f,68.0f);
				e.Graphics.DrawString("��Ա���ţ�", drawFontBody, drawBrush, 35.0f, 70.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnvcMemberCardNo, drawFontBody, drawBrush, 115.0f, 70.0F, drawFormat);
				e.Graphics.DrawString("��Ա���룺", drawFontBody, drawBrush, 35.0f, 85.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnvcMemberPwd, drawFontBody, drawBrush, 115.0f, 85.0F, drawFormat);
				e.Graphics.DrawString("��Ա�ѣ�", drawFontBody, drawBrush, 35.0f, 100.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnnMemberFee.ToString(), drawFontBody, drawBrush, 115.0f, 100.0F, drawFormat);
				e.Graphics.DrawString("�ۿۣ�", drawFontBody, drawBrush, 35.0f, 115.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnvcDiscount, drawFontBody, drawBrush, 115.0f, 115.0F, drawFormat);
				e.Graphics.DrawString("ʵ�գ�", drawFontBody, drawBrush, 35.0f, 130.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnnPrepay.ToString(), drawFontBody, drawBrush, 115.0f, 130.0F, drawFormat);
				e.Graphics.DrawString("��ʹ��ʱ�ޣ�", drawFontBody, drawBrush, 35.0f, 145.0F, drawFormat);
				e.Graphics.DrawString(pMember.cndEndDate, drawFontBody, drawBrush, 115.0f, 145.0F, drawFormat);
				e.Graphics.DrawLine(new Pen(drawBrush,1.0f),0.0f,160.0f,300.0f,160.0f);
				e.Graphics.DrawString("����Ա��", drawFontBody, drawBrush, 35.0f, 165.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnvcOperName, drawFontBody, drawBrush, 115.0f, 165.0F, drawFormat);
				e.Graphics.DrawString("����ʱ�䣺"+DateTime.Now.ToShortDateString(), drawFontBody, drawBrush, 35.0f, 180.0F, drawFormat);


			}

			if (strBillType == ConstApp.Bill_Type_InMoney)
			{
				e.Graphics.DrawString("�����˲��г�", drawFontTitle, drawBrush, 50.0f, 40.0f, drawFormat);
				e.Graphics.DrawLine(new Pen(drawBrush,1.0f),0.0f,68.0f,300.0f,68.0f);
				e.Graphics.DrawString("��Ա���ţ�", drawFontBody, drawBrush, 35.0f, 70.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnvcMemberCardNo, drawFontBody, drawBrush, 115.0f, 70.0F, drawFormat);
				e.Graphics.DrawString("��ֵ��", drawFontBody, drawBrush, 35.0f, 85.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnnPrepay.ToString(), drawFontBody, drawBrush, 115.0f, 85.0F, drawFormat);
				e.Graphics.DrawLine(new Pen(drawBrush,1.0f),0.0f,100.0f,300.0f,100.0f);
				e.Graphics.DrawString("����Ա��", drawFontBody, drawBrush, 35.0f, 100.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnvcOperName, drawFontBody, drawBrush, 115.0f, 100.0F, drawFormat);

				e.Graphics.DrawString("����ʱ�䣺"+DateTime.Now.ToShortDateString(), drawFontBody, drawBrush, 35.0f, 115.0F, drawFormat);

			}
			if (strBillType == ConstApp.Bill_Type_AddPrepay)
			{
				e.Graphics.DrawString("�����˲��г�", drawFontTitle, drawBrush, 50.0f, 40.0f, drawFormat);
				e.Graphics.DrawLine(new Pen(drawBrush,1.0f),0.0f,68.0f,300.0f,68.0f);
				e.Graphics.DrawString("��Ա���ţ�", drawFontBody, drawBrush, 35.0f, 70.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnvcMemberCardNo, drawFontBody, drawBrush, 115.0f, 70.0F, drawFormat);
				e.Graphics.DrawString("��λ���ƣ�", drawFontBody, drawBrush, 35.0f, 85.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnvcMemberName, drawFontBody, drawBrush, 115.0f, 85.0F, drawFormat);
				e.Graphics.DrawString("����ע��ţ�", drawFontBody, drawBrush, 35.0f, 100.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnvcPaperNo, drawFontBody, drawBrush, 115.0f, 100.0F, drawFormat);
				e.Graphics.DrawString("չλ�ѣ�", drawFontBody, drawBrush, 35.0f, 115.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnnPrepay.ToString(), drawFontBody, drawBrush, 115.0f, 115.0F, drawFormat);
				e.Graphics.DrawLine(new Pen(drawBrush,1.0f),0.0f,130.0f,300.0f,130.0f);
				e.Graphics.DrawString("����Ա��", drawFontBody, drawBrush, 35.0f, 130.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnvcOperName, drawFontBody, drawBrush, 115.0f, 130.0F, drawFormat);
				e.Graphics.DrawString("����ʱ�䣺"+DateTime.Now.ToShortDateString(), drawFontBody, drawBrush, 35.0f, 145.0F, drawFormat);

			}
			if (strBillType == ConstApp.Bill_Type_SignIn)
			{
				e.Graphics.DrawString("�����˲��г�", drawFontTitle, drawBrush, 50.0f, 40.0f, drawFormat);
				e.Graphics.DrawLine(new Pen(drawBrush,1.0f),0.0f,68.0f,300.0f,68.0f);
				e.Graphics.DrawString("��Ա���ţ�", drawFontBody, drawBrush, 35.0f, 70.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnvcMemberCardNo, drawFontBody, drawBrush, 115.0f, 70.0F, drawFormat);
				e.Graphics.DrawString("��λ���ƣ�", drawFontBody, drawBrush, 35.0f, 85.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnvcMemberName, drawFontBody, drawBrush, 115.0f, 85.0F, drawFormat);
				e.Graphics.DrawString("����ע��ţ�", drawFontBody, drawBrush, 35.0f, 100.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnvcPaperNo, drawFontBody, drawBrush, 115.0f, 100.0F, drawFormat);
				e.Graphics.DrawString("չλ��", drawFontBody, drawBrush, 35.0f, 115.0F, drawFormat);
				e.Graphics.DrawString(pMember.cnvcProduct, drawFontBody, drawBrush, 115.0f, 115.0F, drawFormat);
				e.Graphics.DrawLine(new Pen(drawBrush,1.0f),0.0f,130.0f,300.0f,130.0f);
				e.Graphics.DrawString("����Ա��", drawFontBody, drawBrush, 35.0f, 130.0F, drawFormat);			
				e.Graphics.DrawString(pMember.cnvcOperName, drawFontBody, drawBrush, 115.0f, 130.0F, drawFormat);
			
			
				e.Graphics.DrawString("ǩ��ʱ�䣺"+DateTime.Now.ToShortDateString()+"  "+DateTime.Now.ToShortTimeString(), drawFontBody, drawBrush, 35.0f, 145.0F, drawFormat);
				

			}

		}

		private void ultraPrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			PrintBill(e,pMember,pMember.cnvcComments);
		}

		private void BillRepeat_Load(object sender, System.EventArgs e)
		{
			//��ʼ������Ա
			SecurityManage security = new SecurityManage();
			DataTable dtOper = security.getOpers();
			cmbOperName.DataSource = dtOper;
			cmbOperName.DisplayMember = "cnvcOperName";
			cmbOperName.ValueMember = "cnnOperID";
			cmbOperName.DataBind();

			cmbBillType.Items.Add(ConstApp.Bill_Type_AddPrepay);
			cmbBillType.Items.Add(ConstApp.Bill_Type_InMoney);
			cmbBillType.Items.Add(ConstApp.Bill_Type_Provide);
			cmbBillType.Items.Add(ConstApp.Bill_Type_SignIn);
			cmbBillType.Items.Add("Ԥ��");


            this.cmbBeginDate.MaskInput = "yyyy-mm-dd hh:mm";
            cmbEndDate.MaskInput = "yyyy-mm-dd hh:mm";
            this.cmbBeginDate.Value = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00";
            cmbEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd") + " 23:59";
			//cmbOperName.Items.Add("%","*");
		}
	}
}
