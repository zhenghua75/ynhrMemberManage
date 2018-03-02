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
		//定义一个枚举类型，描述光标状态
		private enum EnumMousePointPosition
		{
			MouseSizeNone  = 0, //'无
			MouseSizeRight  = 1, //'拉伸右边框
			MouseSizeLeft  = 2, //'拉伸左边框
			MouseSizeBottom  = 3, //'拉伸下边框
			MouseSizeTop  = 4, //'拉伸上边框
			MouseSizeTopLeft = 5, //'拉伸左上角
			MouseSizeTopRight = 6, //'拉伸右上角
			MouseSizeBottomLeft = 7, //'拉伸左下角
			MouseSizeBottomRight= 8, //'拉伸右下角
			MouseDrag   = 9  // '鼠标拖动
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
            this.ultraGroupBox1.Text = "展位：界面操作";
            // 
            // btnModify
            // 
            this.btnModify.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnModify.Location = new System.Drawing.Point(192, 104);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 33;
            this.btnModify.Text = "修改";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnDelete.Location = new System.Drawing.Point(104, 104);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSeat
            // 
            this.btnSeat.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnSeat.Location = new System.Drawing.Point(16, 104);
            this.btnSeat.Name = "btnSeat";
            this.btnSeat.Size = new System.Drawing.Size(75, 23);
            this.btnSeat.TabIndex = 0;
            this.btnSeat.Text = "添加";
            this.btnSeat.Click += new System.EventHandler(this.btnSeat_Click);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(40, 56);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(64, 23);
            this.ultraLabel3.TabIndex = 29;
            this.ultraLabel3.Text = "朝向：";
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
            this.ultraLabel1.Text = "名称：";
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
            this.btnSave.Text = "保存展位方案";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(16, 16);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 33;
            this.ultraLabel2.Text = "招聘会：";
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
            this.ultraLabel4.Text = "展厅：";
            // 
            // ultraButton1
            // 
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton1.Location = new System.Drawing.Point(80, 56);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(120, 23);
            this.ultraButton1.TabIndex = 41;
            this.ultraButton1.Text = "导入默认展位方案";
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
            this.ultraGroupBox2.Text = "展厅：界面操作";
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
            this.ultraLabel6.Text = "展厅：";
            // 
            // ultraButton4
            // 
            this.ultraButton4.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton4.Location = new System.Drawing.Point(24, 64);
            this.ultraButton4.Name = "ultraButton4";
            this.ultraButton4.Size = new System.Drawing.Size(75, 23);
            this.ultraButton4.TabIndex = 41;
            this.ultraButton4.Text = "添加";
            this.ultraButton4.Click += new System.EventHandler(this.ultraButton4_Click);
            // 
            // ultraButton2
            // 
            this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton2.Location = new System.Drawing.Point(104, 64);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(75, 23);
            this.ultraButton2.TabIndex = 43;
            this.ultraButton2.Text = "修改";
            this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
            // 
            // ultraButton3
            // 
            this.ultraButton3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton3.Location = new System.Drawing.Point(184, 64);
            this.ultraButton3.Name = "ultraButton3";
            this.ultraButton3.Size = new System.Drawing.Size(75, 23);
            this.ultraButton3.TabIndex = 44;
            this.ultraButton3.Text = "删除";
            this.ultraButton3.Click += new System.EventHandler(this.ultraButton3_Click);
            // 
            // ultraButton5
            // 
            this.ultraButton5.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton5.Location = new System.Drawing.Point(104, 32);
            this.ultraButton5.Name = "ultraButton5";
            this.ultraButton5.Size = new System.Drawing.Size(104, 23);
            this.ultraButton5.TabIndex = 44;
            this.ultraButton5.Text = "导入展位方案";
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
            this.ultraGroupBox3.Text = "展厅设置：数据库操作";
            // 
            // ultraButton6
            // 
            this.ultraButton6.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.ultraButton6.Location = new System.Drawing.Point(104, 96);
            this.ultraButton6.Name = "ultraButton6";
            this.ultraButton6.Size = new System.Drawing.Size(104, 23);
            this.ultraButton6.TabIndex = 45;
            this.ultraButton6.Text = "删除展位方案";
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
            this.ultraGroupBox4.Text = "默认展位方案";
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
            this.Text = Login.constApp.strCardTypeL8Name + "招聘会展位方案设置";
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

		#region 拖动控制
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
		//确定光标在控件不同位置的样式
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
						p1.Y=e.Y; //'记录光标拖动的当前点
						break;
					case EnumMousePointPosition.MouseSizeBottomRight:
						lCtrl.Width  = lCtrl.Width + e.X - p1.X;
						lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
						p1.X=e.X;
						p1.Y=e.Y; //'记录光标拖动的当前点
						break;
					case EnumMousePointPosition.MouseSizeRight:
						lCtrl.Width  = lCtrl.Width + e.X - p1.X;     
						//      lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
						p1.X=e.X;
						p1.Y=e.Y; //'记录光标拖动的当前点
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
						p1.Y=e.Y; //'记录光标拖动的当前点
						break;
					case EnumMousePointPosition.MouseSizeTopRight:
						lCtrl.Top  = lCtrl.Top + (e.Y - p.Y);
						lCtrl.Width  = lCtrl.Width + (e.X - p1.X);
						lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
						p1.X=e.X;
						p1.Y=e.Y; //'记录光标拖动的当前点
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
				m_MousePointPosition = MousePointPosition(lCtrl.Size, e);  //'判断光标的位置状态
				switch (m_MousePointPosition)  //'改变光标
				{
					case EnumMousePointPosition.MouseSizeNone:
						this.Cursor = Cursors.Arrow;       //'箭头
						break;
					case EnumMousePointPosition.MouseDrag:
						this.Cursor = Cursors.SizeAll;     //'四方向
						break;
					case EnumMousePointPosition.MouseSizeBottom:
						this.Cursor = Cursors.SizeNS;      //'南北
						break;
					case EnumMousePointPosition.MouseSizeTop:
						this.Cursor = Cursors.SizeNS;      //'南北
						break;
					case EnumMousePointPosition.MouseSizeLeft:
						this.Cursor = Cursors.SizeWE;      //'东西
						break;
					case EnumMousePointPosition.MouseSizeRight:
						this.Cursor = Cursors.SizeWE;      //'东西
						break;
					case EnumMousePointPosition.MouseSizeBottomLeft:
						this.Cursor = Cursors.SizeNESW;    //'东北到南西
						break;
					case EnumMousePointPosition.MouseSizeBottomRight:
						this.Cursor = Cursors.SizeNWSE;    //'东南到西北
						break;
					case EnumMousePointPosition.MouseSizeTopLeft:
						this.Cursor = Cursors.SizeNWSE;    //'东南到西北
						break;
					case EnumMousePointPosition.MouseSizeTopRight:
						this.Cursor = Cursors.SizeNESW;    //'东北到南西
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
		#region 展位操作
		private void btnSeat_Click(object sender, System.EventArgs e)
		{
			try
			{
				Panel panel = getPanel();
				if (null == panel)
				{
					throw new BusinessException("展位","请添加展厅！");
				}
				if (txtSeat.Text.Trim().Length == 0)
				{
					throw new BusinessException("展位","请输入展位名称");
				}
				if (null == cmbShow.SelectedItem)
				{
					throw new BusinessException("展位","请选择招聘会");
				}
			    DataTable dtShowSeat = Helper.Query("select * from tbShowSeat where cnnJobID = "+cmbShow.SelectedItem.DataValue.ToString()+" and cnvcControlName = '"+txtSeat.Text+"'");
				if (dtShowSeat.Rows.Count > 0)
				{
					throw new BusinessException("展位","同名展位已存在");
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


				if (txtSeat.Text.StartsWith("黑"))
				{
					lbl.BackColor = Color.Black;
				}
				if (txtSeat.Text.StartsWith("空"))
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
				MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				Panel panel = getPanel();
				if (null == panel)
				{
					throw new BusinessException("展位","请添加展厅！");
				}
				if (txtSeat.Text.Trim().Length == 0)
				{
					throw new BusinessException("展位","请输入展位名称");
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
				MessageBox.Show(this,"展位删除成功！","招聘会展位方案设置",MessageBoxButtons.OK,MessageBoxIcon.Information);
				

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

		private void btnModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				Panel panel = getPanel();
				if (null == panel)
				{
					throw new BusinessException("展位","请添加展厅！");
				}
				if (txtSeat.Text.Trim().Length == 0)
				{
					throw new BusinessException("展位","请输入展位名称");
				}
				DataTable dtShowSeat = Helper.Query("select * from tbShowSeat where cnnJobID = "+cmbShow.SelectedItem.DataValue.ToString()+" and cnvcControlName = '"+txtSeat.Text+"'");
				if (dtShowSeat.Rows.Count > 0)
				{
					throw new BusinessException("展位","同名展位已存在");
				}

				for(int i = 0; i < panel.Controls.Count; i++)
				{
					zhhLabel ctrl = panel.Controls[i] as zhhLabel;
					if (ctrl.Name.Substring(3) == txtSeat.Tag.ToString())
					{
						ctrl.Text = txtSeat.Text;
						ctrl.Name = "lbl"+txtSeat.Text;
						if (txtSeat.Text.StartsWith("黑"))
						{
							ctrl.BackColor = Color.Black;
						}
						if (txtSeat.Text.StartsWith("空"))
						{
							ctrl.Text = "";
						}
						Helper.SetlblDirection(ctrl,cmbDirection.Text);
						break;
					}
					
				}
				MessageBox.Show(this,"展位修改成功！","招聘会展位方案设置",MessageBoxButtons.OK,MessageBoxIcon.Information);
				

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
		#endregion 
		#region 添加展厅
		private void ultraButton4_Click(object sender, System.EventArgs e)
		{
			//添加展厅
			try
			{
				if (cmbFloor.Text.Trim().Length == 0)
				{
					throw new BusinessException("展厅","请选择或者输入展厅名称");
				}				
				
				if (null == cmbShow.SelectedItem)
				{
					throw new BusinessException("展厅","请选择招聘会");
				}
				DataTable dtShow = Helper.Query("select * from tbShow where cnnJobID="+cmbShow.SelectedItem.DataValue.ToString()+" and cnvcShowName='"+cmbFloor.Text+"'");
				if (dtShow.Rows.Count > 0)
				{
					throw new BusinessException("展厅","同名展厅已存在");
				}
				if (cmbFloor.Text=="招聘会一厅"||cmbFloor.Text=="招聘会二厅")
				{
					throw new BusinessException("展厅","同名展厅已存在");
				}
				DialogResult dr = MessageBox.Show(this, "添加展厅后展厅方案将被重置，是否添加展厅？", "展厅",MessageBoxButtons.YesNo,MessageBoxIcon.Error);				
				
				//不做库操作
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
				MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
					//throw new BusinessException("展厅","当前已有展厅");
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
		#region 导入默认展位方案
		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			//导入默认展位方案
			try
			{
				if (cmbDefaultFloor.Text.Length == 0)
				{
					throw new BusinessException("展厅","请选择默认展厅");
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
				MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
				if (seat.cnvcControlName.StartsWith("黑"))
				{
					lbl.BackColor = Color.Black;
				}
				if (seat.cnvcControlName.StartsWith("空"))
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
			//保存展位方案
			try
			{
				Panel pl = getPanel();
				if (null == pl)
				{
					throw new BusinessException("招聘会展位方案设置","请导入或者添加展厅！");
				}
				if (null == cmbShow.SelectedItem)
				{
					throw new BusinessException("招聘会展位方案设置","请选择招聘会！");
				}
				JobManage jobManage = new JobManage();
				string strJobID = cmbShow.SelectedItem.DataValue.ToString();
				string strJobName = cmbShow.SelectedItem.DisplayText;
				string strOperName = this.oper.cnvcOperName;
				jobManage.SaveShowPlan(pl,strJobID,strJobName,strOperName,DateTime.Now);
				MessageBox.Show(this,"招聘会展位方案设置成功！","招聘会展位方案设置",MessageBoxButtons.OK,MessageBoxIcon.Information);
				

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
		#region  修改展厅名称	
		private void ultraButton2_Click(object sender, System.EventArgs e)
		{
			//修改展厅名称			
			try
			{				
				if (cmbFloor.Text.Trim().Length == 0)
				{
					throw new BusinessException("展厅","请选择或输入展厅名称");
				}
				
				if (null == cmbShow.SelectedItem)
				{
					throw new BusinessException("展厅","请选择招聘会");
				}
				DataTable dtShow = Helper.Query("select * from tbShow where cnnJobID="+cmbShow.SelectedItem.DataValue.ToString()+" and cnvcShowName='"+cmbFloor.Text+"'");
				if (dtShow.Rows.Count > 0)
				{
					throw new BusinessException("展厅","同名展厅已存在");
				}
				if (cmbFloor.Text=="招聘会一厅"||cmbFloor.Text=="招聘会二厅")
				{
					throw new BusinessException("展厅","同名展厅已存在");
				}

				Panel pl = getPanel();
				if (null == pl)
				{
					MessageBox.Show(this, "请首先导入或者添加展厅", "展厅",MessageBoxButtons.OK,MessageBoxIcon.Information);				
				}
				else
				{
					pl.Name = "panel"+cmbFloor.Text;
					MessageBox.Show(this, "展厅名称已修改", "展厅",MessageBoxButtons.OK,MessageBoxIcon.Information);				
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

		#endregion

		#region 删除展厅
		private void ultraButton3_Click(object sender, System.EventArgs e)
		{
			//删除展厅
			DialogResult dr = MessageBox.Show(this, "确定删除展厅吗？", "展厅",MessageBoxButtons.YesNo,MessageBoxIcon.Information);				
			if (dr == DialogResult.Yes)
			{
				Panel pl = getPanel();
				this.Controls.Remove(pl);
				cmbFloor.Text = "";
			}			
		}		

		#endregion

		#region  导入展位方案
		private void ultraButton5_Click(object sender, System.EventArgs e)
		{
			//导入展位方案
			try
			{
				if (null == cmbShow.SelectedItem)
				{
					throw new BusinessException("展位方案","请选择招聘会");
				}
				if (null == cmbFloor.SelectedItem)
				{
					throw new BusinessException("展位方案","请选择展厅");
				}
				string strJobID = cmbShow.SelectedItem.DataValue.ToString();
				string strShowID = cmbFloor.SelectedItem.DataValue.ToString();

				

				DataTable dtShow = Helper.Query("select * from tbShow where cnnShowID="+strShowID);
				if (dtShow.Rows.Count == 0)
				{
					throw new BusinessException("展位方案","未找到展厅展厅");
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
				MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
				if (seat.cnvcControlName.StartsWith("黑"))
				{
					lbl.BackColor = Color.Black;
				}
				if (seat.cnvcControlName.StartsWith("空"))
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
			//删除展位方案
			try
			{
				if (null == cmbShow.SelectedItem)
				{
					throw new BusinessException("展位方案","请选择招聘会");
				}
				if (null == cmbFloor.SelectedItem)
				{
					throw new BusinessException("展位方案","请选择展厅");
				}
				string strJobID = cmbShow.SelectedItem.DataValue.ToString();
				string strShowID = cmbFloor.SelectedItem.DataValue.ToString();

				DataTable dtShowSeat = Helper.Query("select * from tbShowSeat where cnnJobID="+strJobID+" and cnvcFloor = '"+strShowID+"' and cnvcState is not null");				
				if (dtShowSeat.Rows.Count > 0)
				{
					throw new BusinessException("展位方案","展位已被使用无法删除");
				}
				DialogResult dr = MessageBox.Show(this, "要删除此展位方案吗？","展位方案",MessageBoxButtons.YesNo,MessageBoxIcon.Information);				
				if (dr == DialogResult.Yes)
				{
					JobManage jobManage = new JobManage();
					string strOperName = this.oper.cnvcOperName;
					jobManage.DeleteShowSeat(strJobID,strShowID,strOperName,DateTime.Now);
					MessageBox.Show(this, "展位方案删除成功","展位方案",MessageBoxButtons.OK,MessageBoxIcon.Information);				
					Helper.BindShow(cmbFloor,strJobID);
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
	}
}
