using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using ynhrMemberManage.Common;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Print;

namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for ShowPlan.
	/// </summary>
    public class ShowPlan : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraButton btnModify;
		private Infragistics.Win.Misc.UltraButton btnDelete;
		private Infragistics.Win.Misc.UltraButton btnSeat;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSeat;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDirection;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbShow;
		private Infragistics.Win.Misc.UltraButton btnSave;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;

		public static bool IsShowing ;
		//����һ��ö�����ͣ��������״̬
		private enum EnumMousePointPosition
		{
			MouseSizeNone  = 0, //'��
			MouseSizeRight  = 1, //'�����ұ߿�
			MouseSizeLeft  = 2, //'������߿�
			MouseSizeBottom  = 3, //'�����±߿�
			MouseSizeTop  = 4, //'�����ϱ߿�
			MouseSizeTopLeft = 5, //'�������Ͻ�
			MouseSizeTopRight = 6, //'�������Ͻ�
			MouseSizeBottomLeft = 7, //'�������½�
			MouseSizeBottomRight= 8, //'�������½�
			MouseDrag   = 9  // '����϶�
		}
		const int Band = 5;
		const int MinWidth=10;
		const int MinHeight=10;
		private EnumMousePointPosition m_MousePointPosition;
		private Point p;
		private Point p1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
		private Infragistics.Win.Misc.UltraButton ultraButton2;
		private Infragistics.Win.Misc.UltraButton ultraButton4;
		private Infragistics.Win.Misc.UltraButton ultraButton5;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox4;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox5;
		private Infragistics.Win.Misc.UltraButton ultraButton3;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDefaultFloor;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbFloor;
		private Infragistics.Win.Misc.UltraButton ultraButton6;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ShowPlan()
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
            this.btnModify = new Infragistics.Win.Misc.UltraButton();
            this.btnDelete = new Infragistics.Win.Misc.UltraButton();
            this.btnSeat = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.txtSeat = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.cmbDirection = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbShow = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnSave = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbDefaultFloor = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmbFloor = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraButton4 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton3 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton5 = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraButton6 = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox4 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGroupBox5 = new Infragistics.Win.Misc.UltraGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDefaultFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).BeginInit();
            this.ultraGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).BeginInit();
            this.ultraGroupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.btnModify);
            this.ultraGroupBox1.Controls.Add(this.btnDelete);
            this.ultraGroupBox1.Controls.Add(this.btnSeat);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox1.Controls.Add(this.txtSeat);
            this.ultraGroupBox1.Controls.Add(this.cmbDirection);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(728, 280);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(272, 144);
            this.ultraGroupBox1.TabIndex = 36;
            this.ultraGroupBox1.Text = "չλ���������";
            // 
            // btnModify
            // 
            this.btnModify.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnModify.Location = new System.Drawing.Point(192, 104);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 33;
            this.btnModify.Text = "�޸�";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnDelete.Location = new System.Drawing.Point(104, 104);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "ɾ��";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSeat
            // 
            this.btnSeat.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnSeat.Location = new System.Drawing.Point(16, 104);
            this.btnSeat.Name = "btnSeat";
            this.btnSeat.Size = new System.Drawing.Size(75, 23);
            this.btnSeat.TabIndex = 0;
            this.btnSeat.Text = "���";
            this.btnSeat.Click += new System.EventHandler(this.btnSeat_Click);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(40, 56);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(64, 23);
            this.ultraLabel3.TabIndex = 29;
            this.ultraLabel3.Text = "����";
            // 
            // txtSeat
            // 
            this.txtSeat.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtSeat.Location = new System.Drawing.Point(120, 24);
            this.txtSeat.Name = "txtSeat";
            this.txtSeat.Size = new System.Drawing.Size(100, 21);
            this.txtSeat.TabIndex = 23;
            // 
            // cmbDirection
            // 
            this.cmbDirection.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbDirection.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbDirection.Location = new System.Drawing.Point(120, 56);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(104, 21);
            this.cmbDirection.TabIndex = 31;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(40, 24);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(48, 23);
            this.ultraLabel1.TabIndex = 24;
            this.ultraLabel1.Text = "���ƣ�";
            // 
            // cmbShow
            // 
            this.cmbShow.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbShow.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbShow.Location = new System.Drawing.Point(120, 16);
            this.cmbShow.MaxDropDownItems = 20;
            this.cmbShow.Name = "cmbShow";
            this.cmbShow.Size = new System.Drawing.Size(120, 21);
            this.cmbShow.TabIndex = 35;
            this.cmbShow.ValueChanged += new System.EventHandler(this.cmbShow_ValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnSave.Location = new System.Drawing.Point(104, 64);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "����չλ����";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(16, 16);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 33;
            this.ultraLabel2.Text = "��Ƹ�᣺";
            // 
            // cmbDefaultFloor
            // 
            this.cmbDefaultFloor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbDefaultFloor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbDefaultFloor.Location = new System.Drawing.Point(136, 24);
            this.cmbDefaultFloor.MaxDropDownItems = 20;
            this.cmbDefaultFloor.Name = "cmbDefaultFloor";
            this.cmbDefaultFloor.Size = new System.Drawing.Size(120, 21);
            this.cmbDefaultFloor.TabIndex = 38;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(24, 24);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel4.TabIndex = 37;
            this.ultraLabel4.Text = "չ����";
            // 
            // ultraButton1
            // 
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton1.Location = new System.Drawing.Point(80, 56);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(120, 23);
            this.ultraButton1.TabIndex = 41;
            this.ultraButton1.Text = "����Ĭ��չλ����";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.cmbFloor);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel6);
            this.ultraGroupBox2.Controls.Add(this.ultraButton4);
            this.ultraGroupBox2.Controls.Add(this.ultraButton2);
            this.ultraGroupBox2.Controls.Add(this.ultraButton3);
            this.ultraGroupBox2.Location = new System.Drawing.Point(728, 176);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(272, 96);
            this.ultraGroupBox2.TabIndex = 42;
            this.ultraGroupBox2.Text = "չ�����������";
            // 
            // cmbFloor
            // 
            this.cmbFloor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbFloor.Location = new System.Drawing.Point(136, 32);
            this.cmbFloor.MaxDropDownItems = 20;
            this.cmbFloor.Name = "cmbFloor";
            this.cmbFloor.Size = new System.Drawing.Size(120, 21);
            this.cmbFloor.TabIndex = 43;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(32, 32);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel6.TabIndex = 42;
            this.ultraLabel6.Text = "չ����";
            // 
            // ultraButton4
            // 
            this.ultraButton4.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton4.Location = new System.Drawing.Point(24, 64);
            this.ultraButton4.Name = "ultraButton4";
            this.ultraButton4.Size = new System.Drawing.Size(75, 23);
            this.ultraButton4.TabIndex = 41;
            this.ultraButton4.Text = "���";
            this.ultraButton4.Click += new System.EventHandler(this.ultraButton4_Click);
            // 
            // ultraButton2
            // 
            this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton2.Location = new System.Drawing.Point(104, 64);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(75, 23);
            this.ultraButton2.TabIndex = 43;
            this.ultraButton2.Text = "�޸�";
            this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
            // 
            // ultraButton3
            // 
            this.ultraButton3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton3.Location = new System.Drawing.Point(184, 64);
            this.ultraButton3.Name = "ultraButton3";
            this.ultraButton3.Size = new System.Drawing.Size(75, 23);
            this.ultraButton3.TabIndex = 44;
            this.ultraButton3.Text = "ɾ��";
            this.ultraButton3.Click += new System.EventHandler(this.ultraButton3_Click);
            // 
            // ultraButton5
            // 
            this.ultraButton5.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton5.Location = new System.Drawing.Point(104, 32);
            this.ultraButton5.Name = "ultraButton5";
            this.ultraButton5.Size = new System.Drawing.Size(104, 23);
            this.ultraButton5.TabIndex = 44;
            this.ultraButton5.Text = "����չλ����";
            this.ultraButton5.Click += new System.EventHandler(this.ultraButton5_Click);
            // 
            // ultraGroupBox3
            // 
            this.ultraGroupBox3.Controls.Add(this.ultraButton6);
            this.ultraGroupBox3.Controls.Add(this.ultraButton5);
            this.ultraGroupBox3.Controls.Add(this.btnSave);
            this.ultraGroupBox3.Location = new System.Drawing.Point(728, 432);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(272, 144);
            this.ultraGroupBox3.TabIndex = 43;
            this.ultraGroupBox3.Text = "չ�����ã����ݿ����";
            // 
            // ultraButton6
            // 
            this.ultraButton6.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton6.Location = new System.Drawing.Point(104, 96);
            this.ultraButton6.Name = "ultraButton6";
            this.ultraButton6.Size = new System.Drawing.Size(104, 23);
            this.ultraButton6.TabIndex = 45;
            this.ultraButton6.Text = "ɾ��չλ����";
            this.ultraButton6.Click += new System.EventHandler(this.ultraButton6_Click);
            // 
            // ultraGroupBox4
            // 
            this.ultraGroupBox4.Controls.Add(this.cmbDefaultFloor);
            this.ultraGroupBox4.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox4.Controls.Add(this.ultraButton1);
            this.ultraGroupBox4.Location = new System.Drawing.Point(728, 88);
            this.ultraGroupBox4.Name = "ultraGroupBox4";
            this.ultraGroupBox4.Size = new System.Drawing.Size(272, 88);
            this.ultraGroupBox4.TabIndex = 44;
            this.ultraGroupBox4.Text = "Ĭ��չλ����";
            // 
            // ultraGroupBox5
            // 
            this.ultraGroupBox5.Controls.Add(this.cmbShow);
            this.ultraGroupBox5.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox5.Location = new System.Drawing.Point(736, 32);
            this.ultraGroupBox5.Name = "ultraGroupBox5";
            this.ultraGroupBox5.Size = new System.Drawing.Size(264, 48);
            this.ultraGroupBox5.TabIndex = 45;
            // 
            // ShowPlan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1008, 753);
            this.Controls.Add(this.ultraGroupBox5);
            this.Controls.Add(this.ultraGroupBox4);
            this.Controls.Add(this.ultraGroupBox3);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "ShowPlan";
            this.Text = Login.constApp.strCardTypeL8Name + "��Ƹ��չλ��������";
            this.Load += new System.EventHandler(this.ShowPlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDefaultFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).EndInit();
            this.ultraGroupBox4.ResumeLayout(false);
            this.ultraGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).EndInit();
            this.ultraGroupBox5.ResumeLayout(false);
            this.ultraGroupBox5.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region �϶�����
		private void MyMouseDown(object sender,System.Windows.Forms.MouseEventArgs e)
		{
			p.X=e.X;
			p.Y=e.Y;

			p1.X=e.X;
			p1.Y=e.Y;  
		}
		private void MyMouseLeave(object sender, System.EventArgs e)
		{
			m_MousePointPosition = EnumMousePointPosition.MouseSizeNone;
			this.Cursor=Cursors.Arrow;
		}
		//ȷ������ڿؼ���ͬλ�õ���ʽ
		private EnumMousePointPosition MousePointPosition(Size size,System.Windows.Forms.MouseEventArgs e)
		{
  
			if ((e.X >= -1 * Band) | (e.X <= size.Width) | (e.Y >= -1 * Band) | (e.Y <= size.Height))
			{
				if (e.X < Band)
				{
					if (e.Y < Band) {return EnumMousePointPosition.MouseSizeTopLeft;}
					else
					{
						if (e.Y > -1 * Band + size.Height)
						{return EnumMousePointPosition.MouseSizeBottomLeft;}
						else
						{return EnumMousePointPosition.MouseSizeLeft;}
					}
				}
				else
				{
					if (e.X > -1 * Band + size.Width)
					{
						if (e.Y < Band)
						{return EnumMousePointPosition.MouseSizeTopRight;}
						else
						{
							if (e.Y > -1 * Band + size.Height)
							{return EnumMousePointPosition.MouseSizeBottomRight;}
							else
							{return EnumMousePointPosition.MouseSizeRight;}
						}
					}
					else
					{
						if (e.Y < Band)
						{return EnumMousePointPosition.MouseSizeTop;}
						else
						{
							if (e.Y > -1 * Band + size.Height)
							{return EnumMousePointPosition.MouseSizeBottom;}
							else
							{return EnumMousePointPosition.MouseDrag;}
						}
					}
				}
			}
			else
			{return EnumMousePointPosition.MouseSizeNone;}
		}

		private void MyMouseMove(object sender,System.Windows.Forms.MouseEventArgs e)
		{
			Control lCtrl =(sender as Control);

			if (e.Button==MouseButtons.Left)
			{
				switch (m_MousePointPosition)
				{
					case EnumMousePointPosition.MouseDrag:     
						lCtrl.Left =lCtrl.Left+ e.X - p.X;
						lCtrl.Top =lCtrl.Top+ e.Y - p.Y;
						break;
					case EnumMousePointPosition.MouseSizeBottom:
						lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
						p1.X=e.X;
						p1.Y=e.Y; //'��¼����϶��ĵ�ǰ��
						break;
					case EnumMousePointPosition.MouseSizeBottomRight:
						lCtrl.Width  = lCtrl.Width + e.X - p1.X;
						lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
						p1.X=e.X;
						p1.Y=e.Y; //'��¼����϶��ĵ�ǰ��
						break;
					case EnumMousePointPosition.MouseSizeRight:
						lCtrl.Width  = lCtrl.Width + e.X - p1.X;     
						//      lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
						p1.X=e.X;
						p1.Y=e.Y; //'��¼����϶��ĵ�ǰ��
						break;
					case EnumMousePointPosition.MouseSizeTop:
						lCtrl.Top  = lCtrl.Top + (e.Y - p.Y);
						lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
						break;
					case EnumMousePointPosition.MouseSizeLeft:
						lCtrl.Left  = lCtrl.Left + e.X - p.X;
						lCtrl.Width  = lCtrl.Width - (e.X - p.X);
						break;
					case EnumMousePointPosition.MouseSizeBottomLeft:
						lCtrl.Left  = lCtrl.Left + e.X - p.X;
						lCtrl.Width  = lCtrl.Width - (e.X - p.X);
						lCtrl.Height = lCtrl.Height+ e.Y - p1.Y;
						p1.X=e.X;
						p1.Y=e.Y; //'��¼����϶��ĵ�ǰ��
						break;
					case EnumMousePointPosition.MouseSizeTopRight:
						lCtrl.Top  = lCtrl.Top + (e.Y - p.Y);
						lCtrl.Width  = lCtrl.Width + (e.X - p1.X);
						lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
						p1.X=e.X;
						p1.Y=e.Y; //'��¼����϶��ĵ�ǰ��
						break;
					case EnumMousePointPosition.MouseSizeTopLeft:
						lCtrl.Left  = lCtrl.Left + e.X - p.X;
						lCtrl.Top  = lCtrl.Top + (e.Y - p.Y);
						lCtrl.Width  = lCtrl.Width - (e.X - p.X);
						lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
						break;
					default:
						break;
				}
				if (lCtrl.Width<MinWidth) lCtrl.Width=MinWidth;
				if (lCtrl.Height<MinHeight) lCtrl.Height=MinHeight;     

			}
			else
			{
				m_MousePointPosition = MousePointPosition(lCtrl.Size, e);  //'�жϹ���λ��״̬
				switch (m_MousePointPosition)  //'�ı���
				{
					case EnumMousePointPosition.MouseSizeNone:
						this.Cursor = Cursors.Arrow;       //'��ͷ
						break;
					case EnumMousePointPosition.MouseDrag:
						this.Cursor = Cursors.SizeAll;     //'�ķ���
						break;
					case EnumMousePointPosition.MouseSizeBottom:
						this.Cursor = Cursors.SizeNS;      //'�ϱ�
						break;
					case EnumMousePointPosition.MouseSizeTop:
						this.Cursor = Cursors.SizeNS;      //'�ϱ�
						break;
					case EnumMousePointPosition.MouseSizeLeft:
						this.Cursor = Cursors.SizeWE;      //'����
						break;
					case EnumMousePointPosition.MouseSizeRight:
						this.Cursor = Cursors.SizeWE;      //'����
						break;
					case EnumMousePointPosition.MouseSizeBottomLeft:
						this.Cursor = Cursors.SizeNESW;    //'����������
						break;
					case EnumMousePointPosition.MouseSizeBottomRight:
						this.Cursor = Cursors.SizeNWSE;    //'���ϵ�����
						break;
					case EnumMousePointPosition.MouseSizeTopLeft:
						this.Cursor = Cursors.SizeNWSE;    //'���ϵ�����
						break;
					case EnumMousePointPosition.MouseSizeTopRight:
						this.Cursor = Cursors.SizeNESW;    //'����������
						break;
					default:
						break;
				}
			}

		}

		#endregion
		private void ShowPlan_Load(object sender, System.EventArgs e)
		{


			Helper.AddDirection(cmbDirection);
			Helper.BindJob(cmbShow);
			Helper.SetDefaultFloor(cmbDefaultFloor);
		}

		private void lbl_Click(object sender, EventArgs e)
		{
			Control ctrl = (Control)sender;
			txtSeat.Tag = ctrl.Name.Substring(3);
			if (ctrl.Text == "")
			{
				txtSeat.Text = ctrl.Name.Substring(3);
			}
			else
			{
				txtSeat.Text = ctrl.Text;
			}
			
		}
		#region չλ����
		private void btnSeat_Click(object sender, System.EventArgs e)
		{
			try
			{
				Panel panel = getPanel();
				if (null == panel)
				{
					throw new BusinessException("չλ","�����չ����");
				}
				if (txtSeat.Text.Trim().Length == 0)
				{
					throw new BusinessException("չλ","������չλ����");
				}
				if (null == cmbShow.SelectedItem)
				{
					throw new BusinessException("չλ","��ѡ����Ƹ��");
				}
			    DataTable dtShowSeat = Helper.Query("select * from tbShowSeat where cnnJobID = "+cmbShow.SelectedItem.DataValue.ToString()+" and cnvcControlName = '"+txtSeat.Text+"'");
				if (dtShowSeat.Rows.Count > 0)
				{
					throw new BusinessException("չλ","ͬ��չλ�Ѵ���");
				}
				zhhLabel lbl = new zhhLabel();		
				lbl.Name = "lbl"+txtSeat.Text;
				lbl.Text = txtSeat.Text;
				lbl.Width = 30;
				lbl.Height = 20;

				lbl.Left = 100;
				lbl.Top = 100;
				lbl.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
				lbl.TextAlign = ContentAlignment.MiddleCenter;

				lbl.BorderStyle = BorderStyle.None;

				Helper.SetlblDirection(lbl,cmbDirection.Text);


				if (txtSeat.Text.StartsWith("��"))
				{
					lbl.BackColor = Color.Black;
				}
				if (txtSeat.Text.StartsWith("��"))
				{
					lbl.Text = "";
				}

				lbl.AllowDrop = true;
				lbl.MouseDown+= new System.Windows.Forms.MouseEventHandler(MyMouseDown);
				lbl.MouseLeave+= new System.EventHandler(MyMouseLeave);
				lbl.MouseMove += new System.Windows.Forms.MouseEventHandler(MyMouseMove);

				lbl.Click +=new EventHandler(lbl_Click);

				panel.Controls.Add(lbl);
			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"ϵͳ����",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				Panel panel = getPanel();
				if (null == panel)
				{
					throw new BusinessException("չλ","�����չ����");
				}
				if (txtSeat.Text.Trim().Length == 0)
				{
					throw new BusinessException("չλ","������չλ����");
				}
				for(int i = 0; i < panel.Controls.Count; i++)
				{
					Control ctrl = panel.Controls[i];
					if (ctrl.Name.Substring(3) == txtSeat.Text)
					{
						panel.Controls.Remove(ctrl);
						break;
					}
					
				}
				MessageBox.Show(this,"չλɾ���ɹ���","��Ƹ��չλ��������",MessageBoxButtons.OK,MessageBoxIcon.Information);
				

			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"ϵͳ����",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void btnModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				Panel panel = getPanel();
				if (null == panel)
				{
					throw new BusinessException("չλ","�����չ����");
				}
				if (txtSeat.Text.Trim().Length == 0)
				{
					throw new BusinessException("չλ","������չλ����");
				}
				DataTable dtShowSeat = Helper.Query("select * from tbShowSeat where cnnJobID = "+cmbShow.SelectedItem.DataValue.ToString()+" and cnvcControlName = '"+txtSeat.Text+"'");
				if (dtShowSeat.Rows.Count > 0)
				{
					throw new BusinessException("չλ","ͬ��չλ�Ѵ���");
				}

				for(int i = 0; i < panel.Controls.Count; i++)
				{
					zhhLabel ctrl = panel.Controls[i] as zhhLabel;
					if (ctrl.Name.Substring(3) == txtSeat.Tag.ToString())
					{
						ctrl.Text = txtSeat.Text;
						ctrl.Name = "lbl"+txtSeat.Text;
						if (txtSeat.Text.StartsWith("��"))
						{
							ctrl.BackColor = Color.Black;
						}
						if (txtSeat.Text.StartsWith("��"))
						{
							ctrl.Text = "";
						}
						Helper.SetlblDirection(ctrl,cmbDirection.Text);
						break;
					}
					
				}
				MessageBox.Show(this,"չλ�޸ĳɹ���","��Ƹ��չλ��������",MessageBoxButtons.OK,MessageBoxIcon.Information);
				

			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"ϵͳ����",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		#endregion 
		#region ���չ��
		private void ultraButton4_Click(object sender, System.EventArgs e)
		{
			//���չ��
			try
			{
				if (cmbFloor.Text.Trim().Length == 0)
				{
					throw new BusinessException("չ��","��ѡ���������չ������");
				}				
				
				if (null == cmbShow.SelectedItem)
				{
					throw new BusinessException("չ��","��ѡ����Ƹ��");
				}
				DataTable dtShow = Helper.Query("select * from tbShow where cnnJobID="+cmbShow.SelectedItem.DataValue.ToString()+" and cnvcShowName='"+cmbFloor.Text+"'");
				if (dtShow.Rows.Count > 0)
				{
					throw new BusinessException("չ��","ͬ��չ���Ѵ���");
				}
				if (cmbFloor.Text=="��Ƹ��һ��"||cmbFloor.Text=="��Ƹ�����")
				{
					throw new BusinessException("չ��","ͬ��չ���Ѵ���");
				}
				DialogResult dr = MessageBox.Show(this, "���չ����չ�������������ã��Ƿ����չ����", "չ��",MessageBoxButtons.YesNo,MessageBoxIcon.Error);				
				
				//���������
//				Show show = new Show();
//				show.cnvcShowName = txtShow.Text;
//				show.cnnJobID = int.Parse(cmbShow.SelectedItem.DataValue.ToString());
//				show.cnnX = 256;
//				show.cnnY = 8;
//				show.cnnWeight = 288;
//				show.cnnHeight = 592;
//				show.cnvcOperName = this.oper.cnvcOperName;
//				show.cndOperDate = DateTime.Now;
//				JobManage jobManage = new JobManage();
//				jobManage.AddShow(show);

				if (dr == DialogResult.Yes)
				{
					JudgePanel();
					Panel pl = new Panel();
					pl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					pl.Location = new System.Drawing.Point(256, 8);
					pl.Name = "panel"+cmbFloor.Text;
					pl.Size = new System.Drawing.Size(288, 592);

					pl.MouseDown+= new System.Windows.Forms.MouseEventHandler(MyMouseDown);
					pl.MouseLeave+= new System.EventHandler(MyMouseLeave);
					pl.MouseMove += new System.Windows.Forms.MouseEventHandler(MyMouseMove);
					pl.Click += new EventHandler(panel_Click);
					this.Controls.Add(pl);					
				}

			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"ϵͳ����",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		#endregion
		private void JudgePanel()
		{
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl.Name.StartsWith("panel"))
				{
					this.Controls.Remove(ctrl);
					break;
					//throw new BusinessException("չ��","��ǰ����չ��");
				}
					
			}
		}

		private void panel_Click(object sender, EventArgs e)
		{
			Control ctrl = (Control)sender;
			cmbFloor.Tag = ctrl.Name;
			cmbFloor.Text = ctrl.Name.Substring(5);
			txtSeat.Text = "";
		}
		

		private void cmbShow_ValueChanged(object sender, System.EventArgs e)
		{
			Helper.BindShow(cmbFloor,cmbShow.SelectedItem.DataValue.ToString());
		}

		private Panel getPanel()
		{
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl is Panel)
				{
					return ctrl as Panel;
				}
			}
			return null;
		}
		#region ����Ĭ��չλ����
		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			//����Ĭ��չλ����
			try
			{
				if (cmbDefaultFloor.Text.Length == 0)
				{
					throw new BusinessException("չ��","��ѡ��Ĭ��չ��");
				}
				JudgePanel();
				Panel pl = new Panel();
				string strFloor = cmbDefaultFloor.Value.ToString();
				Helper.SetDefaultFloor(pl,strFloor);
				pl.MouseDown+= new System.Windows.Forms.MouseEventHandler(MyMouseDown);
				pl.MouseLeave+= new System.EventHandler(MyMouseLeave);
				pl.MouseMove += new System.Windows.Forms.MouseEventHandler(MyMouseMove);
				pl.Click += new EventHandler(panel_Click);
				this.Controls.Add(pl);
				LoadDefaultSeat(pl,strFloor);
			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"ϵͳ����",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			
		}

		
		private void LoadDefaultSeat(Panel pl,string strFloor)
		{
			DataTable dtSeat = Helper.Query("select * from tbDefaultShowSeat where cnvcFloor='"+strFloor+"'");
			foreach (DataRow drSeat in dtSeat.Rows)
			{
				ShowSeat seat = new ShowSeat(drSeat);
				zhhLabel lbl = new zhhLabel();
				lbl.Name = "lbl"+seat.cnvcControlName;
				lbl.Text = seat.cnvcControlName;//seat.cnvcSeat;
				if (seat.cnvcControlName.StartsWith("��"))
				{
					lbl.BackColor = Color.Black;
				}
				if (seat.cnvcControlName.StartsWith("��"))
				{
					lbl.Text = "";
				}
				Point p1 = new Point(seat.cnnX,seat.cnnY);
				lbl.Location = p1;
				lbl.Height = seat.cnnHeight;
				lbl.Width = seat.cnnWidth;
				lbl.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
				lbl.TextAlign = ContentAlignment.MiddleCenter;
				lbl.BorderStyle = BorderStyle.None;
				Helper.SetlblDirection(lbl,seat.cnvcDirection);
				lbl.AllowDrop = true;				
				lbl.MouseDown+= new System.Windows.Forms.MouseEventHandler(MyMouseDown);
				lbl.MouseLeave+= new System.EventHandler(MyMouseLeave);
				lbl.MouseMove += new System.Windows.Forms.MouseEventHandler(MyMouseMove);
				lbl.Click +=new EventHandler(lbl_Click);
				pl.Controls.Add(lbl);
					
			}

		}

		#endregion
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			//����չλ����
			try
			{
				Panel pl = getPanel();
				if (null == pl)
				{
					throw new BusinessException("��Ƹ��չλ��������","�뵼��������չ����");
				}
				if (null == cmbShow.SelectedItem)
				{
					throw new BusinessException("��Ƹ��չλ��������","��ѡ����Ƹ�ᣡ");
				}
				JobManage jobManage = new JobManage();
				string strJobID = cmbShow.SelectedItem.DataValue.ToString();
				string strJobName = cmbShow.SelectedItem.DisplayText;
				string strOperName = this.oper.cnvcOperName;
				jobManage.SaveShowPlan(pl,strJobID,strJobName,strOperName,DateTime.Now);
				MessageBox.Show(this,"��Ƹ��չλ�������óɹ���","��Ƹ��չλ��������",MessageBoxButtons.OK,MessageBoxIcon.Information);
				

			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"ϵͳ����",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		#region  �޸�չ������	
		private void ultraButton2_Click(object sender, System.EventArgs e)
		{
			//�޸�չ������			
			try
			{				
				if (cmbFloor.Text.Trim().Length == 0)
				{
					throw new BusinessException("չ��","��ѡ�������չ������");
				}
				
				if (null == cmbShow.SelectedItem)
				{
					throw new BusinessException("չ��","��ѡ����Ƹ��");
				}
				DataTable dtShow = Helper.Query("select * from tbShow where cnnJobID="+cmbShow.SelectedItem.DataValue.ToString()+" and cnvcShowName='"+cmbFloor.Text+"'");
				if (dtShow.Rows.Count > 0)
				{
					throw new BusinessException("չ��","ͬ��չ���Ѵ���");
				}
				if (cmbFloor.Text=="��Ƹ��һ��"||cmbFloor.Text=="��Ƹ�����")
				{
					throw new BusinessException("չ��","ͬ��չ���Ѵ���");
				}

				Panel pl = getPanel();
				if (null == pl)
				{
					MessageBox.Show(this, "�����ȵ���������չ��", "չ��",MessageBoxButtons.OK,MessageBoxIcon.Information);				
				}
				else
				{
					pl.Name = "panel"+cmbFloor.Text;
					MessageBox.Show(this, "չ���������޸�", "չ��",MessageBoxButtons.OK,MessageBoxIcon.Information);				
				}
				
			}	
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"ϵͳ����",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		#endregion

		#region ɾ��չ��
		private void ultraButton3_Click(object sender, System.EventArgs e)
		{
			//ɾ��չ��
			DialogResult dr = MessageBox.Show(this, "ȷ��ɾ��չ����", "չ��",MessageBoxButtons.YesNo,MessageBoxIcon.Information);				
			if (dr == DialogResult.Yes)
			{
				Panel pl = getPanel();
				this.Controls.Remove(pl);
				cmbFloor.Text = "";
			}			
		}		

		#endregion

		#region  ����չλ����
		private void ultraButton5_Click(object sender, System.EventArgs e)
		{
			//����չλ����
			try
			{
				if (null == cmbShow.SelectedItem)
				{
					throw new BusinessException("չλ����","��ѡ����Ƹ��");
				}
				if (null == cmbFloor.SelectedItem)
				{
					throw new BusinessException("չλ����","��ѡ��չ��");
				}
				string strJobID = cmbShow.SelectedItem.DataValue.ToString();
				string strShowID = cmbFloor.SelectedItem.DataValue.ToString();

				

				DataTable dtShow = Helper.Query("select * from tbShow where cnnShowID="+strShowID);
				if (dtShow.Rows.Count == 0)
				{
					throw new BusinessException("չλ����","δ�ҵ�չ��չ��");
				}
				Show show = new Show(dtShow);
				JudgePanel();
				Panel pl = new Panel();
				pl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				pl.Location = new System.Drawing.Point(show.cnnX, show.cnnY);
				pl.Name = "panel"+show.cnvcShowName;
				pl.Size = new System.Drawing.Size(show.cnnWeight, show.cnnHeight);
				//string strFloor = cmbDefaultFloor.Value.ToString();
				//Helper.SetDefaultFloor(pl,strFloor);
				pl.MouseDown+= new System.Windows.Forms.MouseEventHandler(MyMouseDown);
				pl.MouseLeave+= new System.EventHandler(MyMouseLeave);
				pl.MouseMove += new System.Windows.Forms.MouseEventHandler(MyMouseMove);
				pl.Click += new EventHandler(panel_Click);
				this.Controls.Add(pl);
				LoadSeat(pl,strShowID,strJobID);


			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"ϵͳ����",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

		}

		private void LoadSeat(Panel pl,string strFloor,string strJobID)
		{
			DataTable dtSeat = Helper.Query("select * from tbShowSeat where cnvcFloor='"+strFloor+"' and cnnJobID="+strJobID);
			foreach (DataRow drSeat in dtSeat.Rows)
			{
				ShowSeat seat = new ShowSeat(drSeat);
				zhhLabel lbl = new zhhLabel();
				lbl.Name = "lbl"+seat.cnvcControlName;
				lbl.Text = seat.cnvcControlName;//seat.cnvcSeat;
				if (seat.cnvcControlName.StartsWith("��"))
				{
					lbl.BackColor = Color.Black;
				}
				if (seat.cnvcControlName.StartsWith("��"))
				{
					lbl.Text = "";
				}
				Point p1 = new Point(seat.cnnX,seat.cnnY);
				lbl.Location = p1;
				lbl.Height = seat.cnnHeight;
				lbl.Width = seat.cnnWidth;
				lbl.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
				lbl.TextAlign = ContentAlignment.MiddleCenter;
				lbl.BorderStyle = BorderStyle.None;
				Helper.SetlblDirection(lbl,seat.cnvcDirection);
				lbl.AllowDrop = true;				
				lbl.MouseDown+= new System.Windows.Forms.MouseEventHandler(MyMouseDown);
				lbl.MouseLeave+= new System.EventHandler(MyMouseLeave);
				lbl.MouseMove += new System.Windows.Forms.MouseEventHandler(MyMouseMove);
				lbl.Click +=new EventHandler(lbl_Click);
				pl.Controls.Add(lbl);
					
			}

		}

		#endregion

		private void ultraButton6_Click(object sender, System.EventArgs e)
		{
			//ɾ��չλ����
			try
			{
				if (null == cmbShow.SelectedItem)
				{
					throw new BusinessException("չλ����","��ѡ����Ƹ��");
				}
				if (null == cmbFloor.SelectedItem)
				{
					throw new BusinessException("չλ����","��ѡ��չ��");
				}
				string strJobID = cmbShow.SelectedItem.DataValue.ToString();
				string strShowID = cmbFloor.SelectedItem.DataValue.ToString();

				DataTable dtShowSeat = Helper.Query("select * from tbShowSeat where cnnJobID="+strJobID+" and cnvcFloor = '"+strShowID+"' and cnvcState is not null");				
				if (dtShowSeat.Rows.Count > 0)
				{
					throw new BusinessException("չλ����","չλ�ѱ�ʹ���޷�ɾ��");
				}
				DialogResult dr = MessageBox.Show(this, "Ҫɾ����չλ������","չλ����",MessageBoxButtons.YesNo,MessageBoxIcon.Information);				
				if (dr == DialogResult.Yes)
				{
					JobManage jobManage = new JobManage();
					string strOperName = this.oper.cnvcOperName;
					jobManage.DeleteShowSeat(strJobID,strShowID,strOperName,DateTime.Now);
					MessageBox.Show(this, "չλ����ɾ���ɹ�","չλ����",MessageBoxButtons.OK,MessageBoxIcon.Information);				
					Helper.BindShow(cmbFloor,strJobID);
				}
				

			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"ϵͳ����",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

		}
	}
}
