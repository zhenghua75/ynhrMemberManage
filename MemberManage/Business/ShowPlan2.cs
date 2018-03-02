using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Infragistics.Shared; 
using Infragistics.Win; 
using Infragistics.Win.UltraWinGrid; 
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Common;
using ynhrMemberManage.Print;

namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for ShowPlan2Floor.
	/// </summary>
    public class ShowPlan2 : frmBase
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
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
		private Infragistics.Win.Misc.UltraButton btnSeat;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSeat;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraButton btnSave;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private System.Windows.Forms.Label dlblPrint;
		private System.Windows.Forms.Label dlblStair;
		private System.Windows.Forms.Label dlblEntry;
		private System.Windows.Forms.Label dlblToilet;
		private System.Windows.Forms.Label dlblSpace2;
		private System.Windows.Forms.Label dlblSpace1;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbShow;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDirection;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraButton btnDelete;
		private Infragistics.Win.Misc.UltraButton btnModify;
		private System.Windows.Forms.Panel panel1;

		public ShowPlan2()
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
			this.btnSeat = new Infragistics.Win.Misc.UltraButton();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.dlblPrint = new System.Windows.Forms.Label();
			this.dlblStair = new System.Windows.Forms.Label();
			this.dlblEntry = new System.Windows.Forms.Label();
			this.dlblToilet = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dlblSpace2 = new System.Windows.Forms.Label();
			this.dlblSpace1 = new System.Windows.Forms.Label();
			this.txtSeat = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.btnSave = new Infragistics.Win.Misc.UltraButton();
			this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
			this.cmbShow = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.cmbDirection = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
			this.btnModify = new Infragistics.Win.Misc.UltraButton();
			this.btnDelete = new Infragistics.Win.Misc.UltraButton();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSeat)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbShow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbDirection)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
			this.ultraGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnSeat
			// 
			this.btnSeat.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnSeat.Location = new System.Drawing.Point(16, 104);
			this.btnSeat.Name = "btnSeat";
			this.btnSeat.TabIndex = 0;
			this.btnSeat.Text = "�����λ";
			this.btnSeat.Click += new System.EventHandler(this.btnSeat_Click);
			// 
			// label13
			// 
			this.label13.BackColor = System.Drawing.Color.Black;
			this.label13.Location = new System.Drawing.Point(200, 144);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(40, 10);
			this.label13.TabIndex = 13;
			// 
			// label14
			// 
			this.label14.BackColor = System.Drawing.Color.Black;
			this.label14.Location = new System.Drawing.Point(176, 248);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(40, 10);
			this.label14.TabIndex = 14;
			// 
			// label15
			// 
			this.label15.BackColor = System.Drawing.Color.Black;
			this.label15.Location = new System.Drawing.Point(168, 216);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(40, 10);
			this.label15.TabIndex = 15;
			// 
			// label16
			// 
			this.label16.BackColor = System.Drawing.Color.Black;
			this.label16.Location = new System.Drawing.Point(184, 272);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(40, 10);
			this.label16.TabIndex = 16;
			// 
			// label17
			// 
			this.label17.BackColor = System.Drawing.Color.Black;
			this.label17.Location = new System.Drawing.Point(192, 184);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(40, 10);
			this.label17.TabIndex = 17;
			// 
			// dlblPrint
			// 
			this.dlblPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dlblPrint.Location = new System.Drawing.Point(224, 328);
			this.dlblPrint.Name = "dlblPrint";
			this.dlblPrint.Size = new System.Drawing.Size(112, 96);
			this.dlblPrint.TabIndex = 18;
			this.dlblPrint.Text = "��ӡ��|������ʾ��";
			this.dlblPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// dlblStair
			// 
			this.dlblStair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dlblStair.Location = new System.Drawing.Point(432, 432);
			this.dlblStair.Name = "dlblStair";
			this.dlblStair.Size = new System.Drawing.Size(120, 80);
			this.dlblStair.TabIndex = 19;
			this.dlblStair.Text = "��Ϣ������|¥�ݼ�";
			// 
			// dlblEntry
			// 
			this.dlblEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dlblEntry.Location = new System.Drawing.Point(480, 320);
			this.dlblEntry.Name = "dlblEntry";
			this.dlblEntry.Size = new System.Drawing.Size(80, 80);
			this.dlblEntry.TabIndex = 20;
			this.dlblEntry.Text = "���|����̨";
			// 
			// dlblToilet
			// 
			this.dlblToilet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dlblToilet.Location = new System.Drawing.Point(40, 32);
			this.dlblToilet.Name = "dlblToilet";
			this.dlblToilet.Size = new System.Drawing.Size(160, 64);
			this.dlblToilet.TabIndex = 21;
			this.dlblToilet.Text = "������";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.dlblSpace2);
			this.panel1.Controls.Add(this.dlblSpace1);
			this.panel1.Controls.Add(this.dlblToilet);
			this.panel1.Controls.Add(this.label13);
			this.panel1.Controls.Add(this.label17);
			this.panel1.Controls.Add(this.label15);
			this.panel1.Controls.Add(this.label14);
			this.panel1.Controls.Add(this.label16);
			this.panel1.Controls.Add(this.dlblEntry);
			this.panel1.Controls.Add(this.dlblStair);
			this.panel1.Controls.Add(this.dlblPrint);
			this.panel1.Location = new System.Drawing.Point(48, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(632, 568);
			this.panel1.TabIndex = 22;
			// 
			// dlblSpace2
			// 
			this.dlblSpace2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dlblSpace2.Location = new System.Drawing.Point(40, 448);
			this.dlblSpace2.Name = "dlblSpace2";
			this.dlblSpace2.Size = new System.Drawing.Size(16, 80);
			this.dlblSpace2.TabIndex = 23;
			// 
			// dlblSpace1
			// 
			this.dlblSpace1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dlblSpace1.Location = new System.Drawing.Point(448, 32);
			this.dlblSpace1.Name = "dlblSpace1";
			this.dlblSpace1.Size = new System.Drawing.Size(40, 80);
			this.dlblSpace1.TabIndex = 22;
			// 
			// txtSeat
			// 
			this.txtSeat.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.txtSeat.Location = new System.Drawing.Point(120, 24);
			this.txtSeat.Name = "txtSeat";
			this.txtSeat.Size = new System.Drawing.Size(100, 21);
			this.txtSeat.TabIndex = 23;
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.Location = new System.Drawing.Point(24, 24);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(72, 23);
			this.ultraLabel1.TabIndex = 24;
			this.ultraLabel1.Text = "��λ��";
			// 
			// ultraLabel2
			// 
			this.ultraLabel2.Location = new System.Drawing.Point(736, 48);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.TabIndex = 26;
			this.ultraLabel2.Text = "��Ƹ�᣺";
			// 
			// btnSave
			// 
			this.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnSave.Location = new System.Drawing.Point(792, 256);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(104, 23);
			this.btnSave.TabIndex = 27;
			this.btnSave.Text = "����չλ����";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// ultraLabel3
			// 
			this.ultraLabel3.Location = new System.Drawing.Point(16, 64);
			this.ultraLabel3.Name = "ultraLabel3";
			this.ultraLabel3.TabIndex = 29;
			this.ultraLabel3.Text = "��λ����";
			// 
			// cmbShow
			// 
			this.cmbShow.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbShow.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.cmbShow.Location = new System.Drawing.Point(848, 48);
			this.cmbShow.MaxDropDownItems = 20;
			this.cmbShow.Name = "cmbShow";
			this.cmbShow.Size = new System.Drawing.Size(120, 21);
			this.cmbShow.TabIndex = 30;
			this.cmbShow.ValueChanged += new System.EventHandler(this.cmbShow_ValueChanged);
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
			// ultraGroupBox1
			// 
			this.ultraGroupBox1.Controls.Add(this.btnModify);
			this.ultraGroupBox1.Controls.Add(this.btnDelete);
			this.ultraGroupBox1.Controls.Add(this.btnSeat);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
			this.ultraGroupBox1.Controls.Add(this.txtSeat);
			this.ultraGroupBox1.Controls.Add(this.cmbDirection);
			this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
			this.ultraGroupBox1.Location = new System.Drawing.Point(728, 80);
			this.ultraGroupBox1.Name = "ultraGroupBox1";
			this.ultraGroupBox1.Size = new System.Drawing.Size(272, 144);
			this.ultraGroupBox1.TabIndex = 32;
			this.ultraGroupBox1.Text = "�����λ";
			// 
			// btnModify
			// 
			this.btnModify.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnModify.Location = new System.Drawing.Point(192, 104);
			this.btnModify.Name = "btnModify";
			this.btnModify.TabIndex = 33;
			this.btnModify.Text = "�޸���λ";
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnDelete.Location = new System.Drawing.Point(104, 104);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.TabIndex = 32;
			this.btnDelete.Text = "ɾ����λ";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// ShowPlan2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1008, 753);
			this.Controls.Add(this.ultraGroupBox1);
			this.Controls.Add(this.cmbShow);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.ultraLabel2);
			this.Controls.Add(this.panel1);
			this.Name = "ShowPlan2";
			this.Text = "��Ƹ��һ��չλ��������";
			this.Load += new System.EventHandler(this.ShowPlan2Floor_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ShowPlan2_Paint);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtSeat)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbShow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbDirection)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
			this.ultraGroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private void ShowPlan2Floor_Load(object sender, System.EventArgs e)
		{

			DataTable dtDirection = new DataTable();
			dtDirection.Columns.Add("����");
			DataRow drDirection1 = dtDirection.NewRow();
			drDirection1["����"] = "��";
			dtDirection.Rows.Add(drDirection1);

			DataRow drDirection2 = dtDirection.NewRow();
			drDirection2["����"] = "��";
			dtDirection.Rows.Add(drDirection2);

			DataRow drDirection3 = dtDirection.NewRow();
			drDirection3["����"] = "��";
			dtDirection.Rows.Add(drDirection3);

			DataRow drDirection4 = dtDirection.NewRow();
			drDirection4["����"] = "��";
			dtDirection.Rows.Add(drDirection4);

			//this.cmbDirection.DropDownStyle = UltraComboStyle.DropDown; 

			cmbDirection.DataSource = dtDirection;
			cmbDirection.ValueMember = "����";
			cmbDirection.DisplayMember = "����";
			cmbDirection.DataBind();
			cmbDirection.SelectedIndex = 0;

			JobManage jobManage = new JobManage();
			DataTable dtJob = jobManage.GetAllJob();
			cmbShow.DataSource = dtJob;
			cmbShow.ValueMember = "cnnID";
			cmbShow.DisplayMember = "cnvcJobName";
			cmbShow.DataBind();
			//cmbShow.SelectedIndex = 0;

			this.panel1.Controls.Clear();
			
			
			
		}
		private void LoadSeat(string strID)
		{
			JobManage jobManage = new JobManage();
			DataTable dtSeat = jobManage.GetAll2DefaultSeat(strID);
			foreach (DataRow drSeat in dtSeat.Rows)
			{
				ShowSeat seat = new ShowSeat(drSeat);
				if (seat.cnvcControlName.StartsWith("lbl"))
				{
					zhhLabel lbl = new zhhLabel();
					lbl.Name = seat.cnvcControlName;
					lbl.Text = seat.cnvcSeat;
					Point p1 = new Point(seat.cnnX,seat.cnnY);
					lbl.Location = p1;
					lbl.Height = seat.cnnHeight;
					lbl.Width = seat.cnnWidth;
					lbl.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
					lbl.TextAlign = ContentAlignment.MiddleCenter;

					lbl.BorderStyle = BorderStyle.None;

					switch (seat.cnvcDirection)
					{
						case "��":
							lbl.BorderBottom = System.Drawing.Color.Black;
							lbl.BorderLeft = System.Drawing.Color.Black;
							lbl.BorderRight = System.Drawing.Color.Black;
							lbl.BorderTop = System.Drawing.Color.Transparent;
							break;
						case "��":
							lbl.BorderBottom = System.Drawing.Color.Transparent;
							lbl.BorderLeft = System.Drawing.Color.Black;
							lbl.BorderRight = System.Drawing.Color.Black;
							lbl.BorderTop = System.Drawing.Color.Black;
							break;
						case "��":
							lbl.BorderBottom = System.Drawing.Color.Black;
							lbl.BorderLeft = System.Drawing.Color.Transparent;
							lbl.BorderRight = System.Drawing.Color.Black;
							lbl.BorderTop = System.Drawing.Color.Black;
							break;
						case "��":
							lbl.BorderBottom = System.Drawing.Color.Black;
							lbl.BorderLeft = System.Drawing.Color.Black;
							lbl.BorderRight = System.Drawing.Color.Transparent;
							lbl.BorderTop = System.Drawing.Color.Black;
							break;
						default:
							lbl.BorderBottom = System.Drawing.Color.Black;
							lbl.BorderLeft = System.Drawing.Color.Black;
							lbl.BorderRight = System.Drawing.Color.Black;
							lbl.BorderTop = System.Drawing.Color.Transparent;
							break;
					}


					lbl.AllowDrop = true;
					
					this.panel1.Controls.Add(lbl);
					
				}
				else
				{
					Label lbl2 = new Label();
					lbl2.Name = seat.cnvcControlName;
					lbl2.BorderStyle = BorderStyle.FixedSingle;
					if (seat.cnvcControlName == "dlblEntry")
					{
						lbl2.Text = "���|����̨";
					}
					if (seat.cnvcControlName == "dlblPrint")
					{
						lbl2.Text = "��ӡ��|������ʾ��";
					}
					if (seat.cnvcControlName == "dlblSpace1")
					{

					}
					if (seat.cnvcControlName == "dlblSpace2")
					{

					}
					if (seat.cnvcControlName == "dlblStair")
					{
						lbl2.Text = "��Ϣ������|¥�ݼ�";
					}
					if (seat.cnvcControlName == "dlblToilet")
					{
						lbl2.Text = "������";
					}
					if (seat.cnvcControlName == "label1")
					{
						lbl2.Text = "ϴ�ּ�";
					}
					if (seat.cnvcControlName == "label2")
					{
						lbl2.Text = "����";
					}
					if (seat.cnvcControlName == "label13")
					{
						lbl2.BackColor = Color.Black;
					}
					if (seat.cnvcControlName == "label14")
					{
						lbl2.BackColor = Color.Black;
					}
					if (seat.cnvcControlName == "label15")
					{
						lbl2.BackColor = Color.Black;
					}
					if (seat.cnvcControlName == "label16")
					{
						lbl2.BackColor = Color.Black;
					}
					if (seat.cnvcControlName == "label17")
					{
						lbl2.BackColor = Color.Black;
					}
					Point p2 = new Point(seat.cnnX,seat.cnnY);
					lbl2.Location = p2;
					//						lbl2.Left = seat.cnnX;
					//						lbl2.Top = seat.cnnY;
					lbl2.Height = seat.cnnHeight;
					lbl2.Width = seat.cnnWidth;		
					this.panel1.Controls.Add(lbl2);

				}
			}

			initProperty();
		}

		private void ShowPlan2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		}

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

		private void initProperty()
		{
			for(int i = 0; i < this.panel1.Controls.Count; i++)
			{
				this.panel1.Controls[i].MouseDown+= new System.Windows.Forms.MouseEventHandler(MyMouseDown);
				this.panel1.Controls[i].MouseLeave+= new System.EventHandler(MyMouseLeave);
				this.panel1.Controls[i].MouseMove += new System.Windows.Forms.MouseEventHandler(MyMouseMove);
				this.panel1.Controls[i].Click +=new EventHandler(lbl_Click);
				
			}

		}

		private void btnSeat_Click(object sender, System.EventArgs e)
		{

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

			switch (cmbDirection.Text)
			{
				case "��":
					lbl.BorderBottom = System.Drawing.Color.Black;
					lbl.BorderLeft = System.Drawing.Color.Black;
					lbl.BorderRight = System.Drawing.Color.Black;
					lbl.BorderTop = System.Drawing.Color.Transparent;
					break;
				case "��":
					lbl.BorderBottom = System.Drawing.Color.Transparent;
					lbl.BorderLeft = System.Drawing.Color.Black;
					lbl.BorderRight = System.Drawing.Color.Black;
					lbl.BorderTop = System.Drawing.Color.Black;
					break;
				case "��":
					lbl.BorderBottom = System.Drawing.Color.Black;
					lbl.BorderLeft = System.Drawing.Color.Transparent;
					lbl.BorderRight = System.Drawing.Color.Black;
					lbl.BorderTop = System.Drawing.Color.Black;
					break;
				case "��":
					lbl.BorderBottom = System.Drawing.Color.Black;
					lbl.BorderLeft = System.Drawing.Color.Black;
					lbl.BorderRight = System.Drawing.Color.Transparent;
					lbl.BorderTop = System.Drawing.Color.Black;
					break;
				default:
					lbl.BorderBottom = System.Drawing.Color.Black;
					lbl.BorderLeft = System.Drawing.Color.Black;
					lbl.BorderRight = System.Drawing.Color.Black;
					lbl.BorderTop = System.Drawing.Color.Transparent;
					break;
			}


			lbl.AllowDrop = true;
			lbl.MouseDown+= new System.Windows.Forms.MouseEventHandler(MyMouseDown);
			lbl.MouseLeave+= new System.EventHandler(MyMouseLeave);
			lbl.MouseMove += new System.Windows.Forms.MouseEventHandler(MyMouseMove);

			lbl.Click +=new EventHandler(lbl_Click);

			this.panel1.Controls.Add(lbl);
		
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.panel1.Controls.Count == 0)
				{
					throw new BusinessException("��Ƹ��չλ��������","��ѡ����Ƹ�ᣡ");
				}
				for(int i = 0; i < this.panel1.Controls.Count; i++)
				{
					Control ctrl = this.panel1.Controls[i];
					ShowSeat seat = new ShowSeat();
					seat.cnnJobID = int.Parse(cmbShow.Value.ToString());
					seat.cnvcJobName = cmbShow.Text.ToString();
					seat.cnnX = ctrl.Location.X;
					seat.cnnY = ctrl.Location.Y;
					seat.cnnHeight = ctrl.Height;
					seat.cnnWidth = ctrl.Width;
					if (ctrl.Name.StartsWith("lbl"))
					{
						//����
						zhhLabel zhhlbl = this.panel1.Controls[i] as zhhLabel;
						if (zhhlbl.BorderTop == System.Drawing.Color.Transparent)
						{
							seat.cnvcDirection = "��";
						}
						if (zhhlbl.BorderBottom == System.Drawing.Color.Transparent)
						{
							seat.cnvcDirection = "��";
						}
						if (zhhlbl.BorderLeft == System.Drawing.Color.Transparent)
						{
							seat.cnvcDirection = "��";
						}
						if (zhhlbl.BorderRight == System.Drawing.Color.Transparent)
						{
							seat.cnvcDirection = "��";
						}
						//��λ��
						seat.cnvcSeat = ctrl.Name.Substring(3);
						
					}
					seat.cnvcControlName = ctrl.Name;
					seat.cnvcFloor = "2";
//					if (cmbShow.Text.StartsWith("Ĭ����Ƹ��չλ"))
//					{
//						seat.cnvcDefaultSeat = "1";
//					}
					JobManage jobManage = new JobManage();
					jobManage.AddSeat(seat);
				}
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

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				for(int i = 0; i < this.panel1.Controls.Count; i++)
				{
					Control ctrl = this.panel1.Controls[i];
					if (ctrl.Text == txtSeat.Text)
					{
						this.panel1.Controls.Remove(ctrl);
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
				for(int i = 0; i < this.panel1.Controls.Count; i++)
				{
					Control ctrl = this.panel1.Controls[i];
					if (ctrl.Text == txtSeat.Tag.ToString())
					{
						ctrl.Text = txtSeat.Text;

						//this.panel1.Controls.Remove(ctrl);
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

		private void lbl_Click(object sender, EventArgs e)
		{
			Control ctrl = (Control)sender;
			txtSeat.Tag = ctrl.Text;
			txtSeat.Text = ctrl.Text;
		}

		private void cmbShow_ValueChanged(object sender, System.EventArgs e)
		{
			//
			this.panel1.Controls.Clear();
			LoadSeat(cmbShow.SelectedItem.DataValue.ToString());
		}
	}


}
