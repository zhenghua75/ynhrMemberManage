using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Infragistics.Win; 
using Infragistics.Win.UltraWinToolbars; 
using ynhrMemberManage.CardCommon.CardRef;
using ynhrMemberManage.CardCommon.CardDef;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using MemberManage.Business;
using System.Reflection;
using System.IO;
//using Infragistics.Win; 
using Infragistics.Win.UltraWinTabs; 
using Infragistics.Win.UltraWinTabbedMdi; 
using Infragistics.Win.AppStyling;
using MemberManage.Reports;
using ynhrMemberManage.Print;
//using cc;
using Microsoft.Win32;
using Sunmast.Hardware;
using ynhrMemberManage.Common;
using ynhrMemberManage.Business;
using ynhrMemberManage.BusinessFacade;
using Microsoft.Practices.EnterpriseLibrary.Security;
using System.Security.Principal;
using ynhrMemeberManage.Security;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using CardCommon.CardRef;
namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager ultraTabbedMdiManager1;   
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MainForm_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MainForm_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MainForm_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MainForm_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private System.Windows.Forms.ImageList imageList1;
		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
		private System.Windows.Forms.MdiClient   bgMDIClient;
        private System.Windows.Forms.Timer timer1;
        private bool isUserClose = false;
        public MainForm()
		{
            InitializeComponent();
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
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinToolbars.RibbonTab ribbonTab1 = new Infragistics.Win.UltraWinToolbars.RibbonTab("ribbon1", "ribbon1");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup1 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup1", "ribbonGroup1");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup2 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup2", "ribbonGroup2");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup3 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup3", "ribbonGroup3");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup4 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup4", "ribbonGroup4");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup5 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup5", "ribbonGroup5");
            Infragistics.Win.UltraWinToolbars.RibbonTab ribbonTab2 = new Infragistics.Win.UltraWinToolbars.RibbonTab("ribbon2", "ribbon2");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup6 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup1", "ribbonGroup1");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup7 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup2", "ribbonGroup2");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup8 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup3", "ribbonGroup3");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup9 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup4", "ribbonGroup4");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup10 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup5", "ribbonGroup5");
            Infragistics.Win.UltraWinToolbars.RibbonTab ribbonTab3 = new Infragistics.Win.UltraWinToolbars.RibbonTab("ribbon3", "ribbon3");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup11 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup1", "ribbonGroup1");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup12 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup2", "ribbonGroup2");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup13 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup3", "ribbonGroup3");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup14 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup4", "ribbonGroup4");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup15 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup5", "ribbonGroup5");
            Infragistics.Win.UltraWinToolbars.RibbonTab ribbonTab4 = new Infragistics.Win.UltraWinToolbars.RibbonTab("ribbon4", "ribbon4");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup16 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup1", "ribbonGroup1");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup17 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup2", "ribbonGroup2");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup18 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup3", "ribbonGroup3");
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ultraTabbedMdiManager1 = new Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this._MainForm_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._MainForm_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MainForm_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MainForm_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            this.imageList1.Images.SetKeyName(20, "");
            this.imageList1.Images.SetKeyName(21, "");
            this.imageList1.Images.SetKeyName(22, "");
            // 
            // ultraTabbedMdiManager1
            // 
            this.ultraTabbedMdiManager1.AllowMaximize = true;
            this.ultraTabbedMdiManager1.ImageList = this.imageList1;
            this.ultraTabbedMdiManager1.MdiParent = this;
            this.ultraTabbedMdiManager1.ViewStyle = Infragistics.Win.UltraWinTabbedMdi.ViewStyle.VisualStudio2005;
            this.ultraTabbedMdiManager1.TabActivated += new Infragistics.Win.UltraWinTabbedMdi.MdiTabEventHandler(this.ultraTabbedMdiManager1_TabActivated);
            this.ultraTabbedMdiManager1.RestoreTab += new Infragistics.Win.UltraWinTabbedMdi.RestoreTabEventHandler(this.ultraTabbedMdiManager1_RestoreTab);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.ImageList = this.imageList1;
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 422);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            ultraStatusPanel1.Key = "OperName";
            ultraStatusPanel1.Text = "����Ա��";
            ultraStatusPanel1.ToolTipText = "����Ա";
            ultraStatusPanel1.Width = 200;
            ultraStatusPanel2.Key = "Dept";
            ultraStatusPanel2.Text = "����";
            ultraStatusPanel2.ToolTipText = "����";
            ultraStatusPanel2.Width = 200;
            ultraStatusPanel3.DateTimeFormat = "yyyy��-MM��-dd��";
            ultraStatusPanel3.Key = "OperDate";
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel3.Text = "��������";
            ultraStatusPanel3.ToolTipText = "��������";
            ultraStatusPanel3.Width = 110;
            ultraStatusPanel4.DateTimeFormat = "hhʱ:mm��";
            ultraStatusPanel4.Key = "OperTime";
            ultraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel4.Text = "����ʱ��";
            ultraStatusPanel4.ToolTipText = "����ʱ��";
            ultraStatusPanel5.Key = "func";
            ultraStatusPanel5.Text = "��ǰ���ܣ���";
            ultraStatusPanel5.ToolTipText = "��ǰ����";
            ultraStatusPanel5.Width = 300;
            this.ultraStatusBar1.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4,
            ultraStatusPanel5});
            this.ultraStatusBar1.ResizeStyle = Infragistics.Win.UltraWinStatusBar.ResizeStyle.Deferred;
            this.ultraStatusBar1.Size = new System.Drawing.Size(728, 23);
            this.ultraStatusBar1.TabIndex = 11;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.VisualStudio2005;
            this.ultraStatusBar1.WrapText = false;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Office2007;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // _MainForm_Toolbars_Dock_Area_Left
            // 
            this._MainForm_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MainForm_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._MainForm_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._MainForm_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MainForm_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 25);
            this._MainForm_Toolbars_Dock_Area_Left.Name = "_MainForm_Toolbars_Dock_Area_Left";
            this._MainForm_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 397);
            this._MainForm_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.ImageListSmall = this.imageList1;
            this.ultraToolbarsManager1.MenuAnimationStyle = Infragistics.Win.UltraWinToolbars.MenuAnimationStyle.Slide;
            this.ultraToolbarsManager1.Office2007UICompatibility = false;
            ribbonGroup1.Key = "ribbonGroup1";
            ribbonGroup2.Key = "ribbonGroup2";
            ribbonGroup3.Key = "ribbonGroup3";
            ribbonGroup4.Key = "ribbonGroup4";
            ribbonGroup5.Key = "ribbonGroup5";
            ribbonTab1.Groups.AddRange(new Infragistics.Win.UltraWinToolbars.RibbonGroup[] {
            ribbonGroup1,
            ribbonGroup2,
            ribbonGroup3,
            ribbonGroup4,
            ribbonGroup5});
            ribbonTab1.Key = "ribbon1";
            ribbonGroup6.Key = "ribbonGroup1";
            ribbonGroup7.Key = "ribbonGroup2";
            ribbonGroup8.Key = "ribbonGroup3";
            ribbonGroup9.Key = "ribbonGroup4";
            ribbonGroup10.Key = "ribbonGroup5";
            ribbonTab2.Groups.AddRange(new Infragistics.Win.UltraWinToolbars.RibbonGroup[] {
            ribbonGroup6,
            ribbonGroup7,
            ribbonGroup8,
            ribbonGroup9,
            ribbonGroup10});
            ribbonTab2.Key = "ribbon2";
            ribbonGroup11.Key = "ribbonGroup1";
            ribbonGroup12.Key = "ribbonGroup2";
            ribbonGroup13.Key = "ribbonGroup3";
            ribbonGroup14.Key = "ribbonGroup4";
            ribbonGroup15.Key = "ribbonGroup5";
            ribbonTab3.Groups.AddRange(new Infragistics.Win.UltraWinToolbars.RibbonGroup[] {
            ribbonGroup11,
            ribbonGroup12,
            ribbonGroup13,
            ribbonGroup14,
            ribbonGroup15});
            ribbonTab3.Key = "ribbon3";
            ribbonGroup16.Key = "ribbonGroup1";
            ribbonGroup17.Key = "ribbonGroup2";
            ribbonGroup18.Key = "ribbonGroup3";
            ribbonTab4.Groups.AddRange(new Infragistics.Win.UltraWinToolbars.RibbonGroup[] {
            ribbonGroup16,
            ribbonGroup17,
            ribbonGroup18});
            ribbonTab4.Key = "ribbon4";
            this.ultraToolbarsManager1.Ribbon.NonInheritedRibbonTabs.AddRange(new Infragistics.Win.UltraWinToolbars.RibbonTab[] {
            ribbonTab1,
            ribbonTab2,
            ribbonTab3,
            ribbonTab4});
            this.ultraToolbarsManager1.SaveSettingsFormat = Infragistics.Win.SaveSettingsFormat.Xml;
            this.ultraToolbarsManager1.SettingsKey = "MainForm.ultraToolbarsManager1";
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007;
            this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            // 
            // _MainForm_Toolbars_Dock_Area_Right
            // 
            this._MainForm_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MainForm_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._MainForm_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._MainForm_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MainForm_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(728, 25);
            this._MainForm_Toolbars_Dock_Area_Right.Name = "_MainForm_Toolbars_Dock_Area_Right";
            this._MainForm_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 397);
            this._MainForm_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _MainForm_Toolbars_Dock_Area_Top
            // 
            this._MainForm_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MainForm_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._MainForm_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._MainForm_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MainForm_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._MainForm_Toolbars_Dock_Area_Top.Name = "_MainForm_Toolbars_Dock_Area_Top";
            this._MainForm_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(728, 25);
            this._MainForm_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _MainForm_Toolbars_Dock_Area_Bottom
            // 
            this._MainForm_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MainForm_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._MainForm_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._MainForm_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MainForm_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 422);
            this._MainForm_Toolbars_Dock_Area_Bottom.Name = "_MainForm_Toolbars_Dock_Area_Bottom";
            this._MainForm_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(728, 0);
            this._MainForm_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(728, 445);
            this.Controls.Add(this._MainForm_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._MainForm_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._MainForm_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._MainForm_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.ultraStatusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "MainForm";
            this.Text = "�����˲��г��ۺϻ�Ա����ϵͳ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void MainForm_Load(object sender, System.EventArgs e)
		{		
			//LogAdapter.WriteFeaturesException(new Exception("��ʼ�����崴��"));
			#region ����
			Infragistics.Shared.ResourceCustomizer rc= Infragistics.Win.UltraWinToolbars.Resources.Customizer;//Resources.Customizer;
			rc.SetCustomizedString("AddRemoveButtons","���ɾ����ť(&A)");
			rc.SetCustomizedString("ResetToolbar","���ù�����(&R)");
			rc.SetCustomizedString("Customize","�Զ���...");
			rc.SetCustomizedString("CustomizeCategoryAllCommands","��������");
			rc.SetCustomizedString("CustomizeCategoryUnassigned","δ����");

			rc.SetCustomizedString("CustomizeDialog_AllProps","��������");
			rc.SetCustomizedString("CustomizeDialog_AlwaysShowFullMenus","������ʾ���в˵�");
			rc.SetCustomizedString("CustomizeDialog_AlwaysShowFullMenus_AccessibleDescription","������ʾ��������������δʹ�õ�");
			rc.SetCustomizedString("CustomizeDialog_BasicProps","��������");
			rc.SetCustomizedString("CustomizeDialog_CantModifyInheritedToolbarProperties","ע�⣺�����޸�ѡ��Ĺ���������");
			rc.SetCustomizedString("CustomizeDialog_CantModifyInheritedToolProperties","ע�⣺�����޸�ѡ��Ĺ���������");
			rc.SetCustomizedString("CustomizeDialog_Caption","����");
			rc.SetCustomizedString("CustomizeDialog_CaptionCategoryKey","(&C)���⣬Ŀ¼����");
			rc.SetCustomizedString("CustomizeDialog_CategoriesMidAmp","Ŀ¼(&G)");
			rc.SetCustomizedString("CustomizeDialog_Category","Ŀ¼");
			rc.SetCustomizedString("CustomizeDialog_CloseNoAmp","�ر�");
			rc.SetCustomizedString("CustomizeDialog_Commands","����");
			rc.SetCustomizedString("CustomizeDialog_CommandsEndAmp","����(&D)");
			rc.SetCustomizedString("CustomizeDialog_CreateCopyOfTool","�½�����������(&C)");
			rc.SetCustomizedString("CustomizeDialog_CustomizeMain","�Զ���");
			rc.SetCustomizedString("CustomizeDialog_CustomizeMain_AccessibleDescription","�Զ��幤�ߺ͹�����");
			rc.SetCustomizedString("CustomizeDialog_Delete","ɾ��(&D)");
			rc.SetCustomizedString("CustomizeDialog_Delete_Tool_AccessibleDescription","ɾ��ѡ������");
			rc.SetCustomizedString("CustomizeDialog_Delete_Toolbar_AccessibleDescription","ɾ��ѡ��������");
			rc.SetCustomizedString("CustomizeDialog_DeleteTool","ɾ������");
			rc.SetCustomizedString("CustomizeDialog_Description","����");
			rc.SetCustomizedString("CustomizeDialog_Enabled","����");
			rc.SetCustomizedString("CustomizeDialog_EnabledVisible","���ã��ɼ�");
			rc.SetCustomizedString("CustomizeDialog_FloatingToolbarFadeDelay","���������������ӳ�");
			rc.SetCustomizedString("CustomizeDialog_FloatingToolbarFadeDelay_AccessibleDescription","����뿪������������������");
			rc.SetCustomizedString("CustomizeDialog_Image","ͼƬ(&I)");
			rc.SetCustomizedString("CustomizeDialog_Import","����");
			rc.SetCustomizedString("CustomizeDialog_ImportMenusFromForm","����˵�");
			rc.SetCustomizedString("CustomizeDialog_ImportToolbarsFromForm","���빤����");
			rc.SetCustomizedString("CustomizeDialog_Key","��");
			rc.SetCustomizedString("CustomizeDialog_KeyboardBeginAmp","����(&K)");
			rc.SetCustomizedString("CustomizeDialog_KeyboardBeginAmp_AccessibleDescription","�Զ�����̿�ݼ�");
			rc.SetCustomizedString("CustomizeDialog_LargeIconsOnMenus","�˵���ͼ��");
			rc.SetCustomizedString("CustomizeDialog_LargeIconsOnMenus_AccessibleDescription","��ʾ�˵���ͼ��");
			rc.SetCustomizedString("CustomizeDialog_LargeIconsOnToolbars","��������ͼ��");
			rc.SetCustomizedString("CustomizeDialog_LargeIconsOnToolbars_AccessibleDescription","��ʾ��������ͼ��");
			rc.SetCustomizedString("CustomizeDialog_LargeImage","��ͼ��");
			rc.SetCustomizedString("CustomizeDialog_ListFontNamesInTheirFont","���������б�");
			rc.SetCustomizedString("CustomizeDialog_ListFontNamesInTheirFont_AccessibleDescription","��ʾ���������б�");
			rc.SetCustomizedString("CustomizeDialog_LoadSave","���롢����");
			rc.SetCustomizedString("CustomizeDialog_MenuAnimations","�˵�����");
			rc.SetCustomizedString("CustomizeDialog_MenuAnimations_AccessibleDescription","�˵���������");
			rc.SetCustomizedString("CustomizeDialog_Milliseconds","����");
			rc.SetCustomizedString("CustomizeDialog_ModifySelection","�޸�ѡ����");
			rc.SetCustomizedString("CustomizeDialog_ModifySelection_AccessibleDescription","�޸�ѡ�������");
			rc.SetCustomizedString("CustomizeDialog_New","�½�(&N)");
			rc.SetCustomizedString("CustomizeDialog_New_Toolbar_AccessibleDescription","�¹�����");
			rc.SetCustomizedString("CustomizeDialog_NewBeginAmp","�½�");
			rc.SetCustomizedString("CustomizeDialog_NewTool","�½�����");
			rc.SetCustomizedString("CustomizeDialog_NewToolbar","�½�������");
			rc.SetCustomizedString("CustomizeDialog_Options","����");
			rc.SetCustomizedString("CustomizeDialog_Other","����");
			rc.SetCustomizedString("CustomizeDialog_PersonalizedMenusAndToolbars","���Ի��˵�������");
			rc.SetCustomizedString("CustomizeDialog_PgTools","������");
			rc.SetCustomizedString("CustomizeDialog_PopupMenuDesigner","�˵����");
			rc.SetCustomizedString("CustomizeDialog_QuestionProperties","��������");
			rc.SetCustomizedString("CustomizeDialog_RearrangeCommands","��������");
			rc.SetCustomizedString("CustomizeDialog_RearrangeCommands_AccessibleDescription","���Ų˵���������������");
			rc.SetCustomizedString("CustomizeDialog_Rename","������(&E)");
			rc.SetCustomizedString("CustomizeDialog_Rename_Toolbar_AccessibleDescription","������������");
			rc.SetCustomizedString("CustomizeDialog_RenameAmp","������");
			rc.SetCustomizedString("CustomizeDialog_Reset_Toolbar_AccessibleDescription","���ù�����");
			rc.SetCustomizedString("CustomizeDialog_ResetAmp","����");
			rc.SetCustomizedString("CustomizeDialog_ResetMidAmp","����");
			rc.SetCustomizedString("CustomizeDialog_ResetMyUsageData","��������");
			rc.SetCustomizedString("CustomizeDialog_ResetMyUsageData_AccessibleDescription","��������");
			rc.SetCustomizedString("CustomizeDialog_SelectedCommand","ѡ�������");
			rc.SetCustomizedString("CustomizeDialog_Shortcut","��ݼ�");
			rc.SetCustomizedString("CustomizeDialog_ShowFullMenusAfterAShortDelay","��ʾ���в˵�");
			rc.SetCustomizedString("CustomizeDialog_ShowFullMenusAfterAShortDelay_AccessibleDescription","��ʾ���в˵�");
			rc.SetCustomizedString("CustomizeDialog_ShowScreenTipsOnToolbars","��������ʾ��ʾ");
			rc.SetCustomizedString("CustomizeDialog_ShowScreenTipsOnToolbars_AccessibleDescription","��������ʾ��ʾ");
			rc.SetCustomizedString("CustomizeDialog_ShowShortcutKeysInScreenTips","��ʾ��ݼ���ʾ");
			rc.SetCustomizedString("CustomizeDialog_ShowShortcutKeysInScreenTips_AccessibleDescription","��ʾ��ݼ���ʾ");
			rc.SetCustomizedString("CustomizeDialog_SmallImage","Сͼ��");
			rc.SetCustomizedString("CustomizeDialog_SortCommands","��ĸ��������");
			rc.SetCustomizedString("CustomizeDialog_SortToolsAlphabetically","��ĸ���򹤾���");
			rc.SetCustomizedString("CustomizeDialog_Toolbars","������");
			rc.SetCustomizedString("CustomizeDialog_ToolbarsList","�������б�");
			rc.SetCustomizedString("CustomizeDialog_Tools","����");
			rc.SetCustomizedString("CustomizeDialog_ToolsByCategory","����Ŀ¼");
			rc.SetCustomizedString("CustomizeDialog_Visible","�ɼ�");

			Infragistics.Shared.ResourceCustomizer rc2= Infragistics.Win.UltraWinTabbedMdi.Resources.Customizer;//Resources.Customizer;
			rc2.SetCustomizedString("MenuItemCancel","ȡ��");
			rc2.SetCustomizedString("MenuItemClose","�ر�");
			rc2.SetCustomizedString("MenuItemMaximize","���");
			rc2.SetCustomizedString("MenuItemMoveToNextGroup","��һ��");
			rc2.SetCustomizedString("MenuItemMoveToPreviousGroup","ǰһ��");
			rc2.SetCustomizedString("MenuItemNewHorizontalGroup","ˮƽ����");
			rc2.SetCustomizedString("MenuItemNewVerticalGroup","��ֱ����");
			rc2.SetCustomizedString("UltraTabbedMdiManagerActionList_P_AllowHorizontalTabGroups_DisplayName","����ˮƽ����");
			rc2.SetCustomizedString("UltraTabbedMdiManagerActionList_P_AllowMaximize_DisplayName","�������");
			rc2.SetCustomizedString("UltraTabbedMdiManagerActionList_P_AllowNestedTabGroups_DisplayName","����Ƕ�׷���");
			rc2.SetCustomizedString("UltraTabbedMdiManagerActionList_P_AllowVerticalTabGroups_DisplayName","����ֱ����");
			rc2.SetCustomizedString("UltraTabbedMdiManagerActionList_P_TabGroupSettings_TextOrientation_DisplayName","�ı�����");
			rc2.SetCustomizedString("UltraTabbedMdiManagerActionList_P_ViewStyle_DisplayName","��ʽ");
			#endregion
			//LogAdapter.WriteFeaturesException(new Exception("�����庺�����"));
			MDI_Set();
			//LogAdapter.WriteFeaturesException(new Exception("�����屳���������"));
			this.WindowState = FormWindowState.Maximized;
			//LogAdapter.WriteFeaturesException(new Exception("���˵�����ǰ")); 
            this.ultraToolbarsManager1.MdiMergeable = true;
            this.ultraToolbarsManager1.Tools.Clear();
            this.ultraToolbarsManager1.Toolbars.Clear();


            this.ultraToolbarsManager1.Toolbars.AddToolbarRange(new string[] { "������", Login.constApp.strCardTypeL8Name + "������", Login.constApp.strCardTypeL6Name + "������", "���˵���" });
            this.ultraToolbarsManager1.Toolbars["���˵���"].IsMainMenuBar = true;
            this.ultraToolbarsManager1.Toolbars["���˵���"].DockedRow = 0;            
            switch (Login.constApp.strCardType)
            {
                case "l6":
                    MainMenuBarL6();
                    MainMenuBar();
                    this.ultraToolbarsManager1.Toolbars["���˵���"].Tools.InsertToolRange(0, new string[] { 
                "��Ƹ�����",Login.constApp.strCardTypeL6Name +"����",Login.constApp.strCardTypeL6Name +"չλ����",Login.constApp.strCardTypeL6Name +"����",
                "�ǻ�Ա����",  "����", "ϵͳ����", "ϵͳ�˳�" });
                    this.ultraToolbarsManager1.Toolbars[Login.constApp.strCardTypeL8Name + "������"].Visible = false;
                    break;
                case "l8":
                    MainMenuBarL8();
                    MainMenuBar();
                    this.ultraToolbarsManager1.Toolbars["���˵���"].Tools.InsertToolRange(0, new string[] { 
                "��Ƹ�����",
                Login.constApp.strCardTypeL8Name +"����",Login.constApp.strCardTypeL8Name +"���ù���",Login.constApp.strCardTypeL8Name +"չλ����",Login.constApp.strCardTypeL8Name +"����",
                "�ǻ�Ա����",  "����", "ϵͳ����", "ϵͳ�˳�" });
                    this.ultraToolbarsManager1.Toolbars[Login.constApp.strCardTypeL6Name + "������"].Visible = false;
                    break;
                case "l6l8":
                    MainMenuBarL6();
                    MainMenuBarL8();
                    MainMenuBar();
                    this.ultraToolbarsManager1.Toolbars["���˵���"].Tools.InsertToolRange(0, new string[] { 
                "��Ƹ�����",Login.constApp.strCardTypeL6Name +"����",Login.constApp.strCardTypeL6Name +"չλ����",Login.constApp.strCardTypeL6Name +"����",
                Login.constApp.strCardTypeL8Name +"����",Login.constApp.strCardTypeL8Name +"���ù���",Login.constApp.strCardTypeL8Name +"չλ����",Login.constApp.strCardTypeL8Name +"����",
                "�ǻ�Ա����",  "����", "ϵͳ����", "ϵͳ�˳�" });

                    break;
                default:
                    break;
            }
            
			//LogAdapter.WriteFeaturesException(new Exception("���˵�׼�����"));
			#region Ȩ�޲˵�
            MyPrincipal mp = Thread.CurrentPrincipal as MyPrincipal;
            MyIdentity mi = mp.Identity as MyIdentity;
            if (mi.dept.cnnDeptID != 0)
            {

                foreach (object tools in ultraToolbarsManager1.Tools.All)
                {
                    if (tools is PopupMenuTool)
                    {
                        PopupMenuTool pTools = tools as PopupMenuTool;
                        if (pTools.Key != "ϵͳ�˳�")
                        {
                            foreach (object tool2 in pTools.Tools.All)
                            {
                                ToolBase tb = tool2 as ToolBase;
                                if (!(tool2 is PopupMenuTool) && tb.Key != "����Ա�����޸�")
                                {
                                    if (tb.Key == "����ѡ��" || tb.Key=="ekey����") tb.SharedProps.Visible = false;
                                    else
                                        tb.SharedProps.Visible = mp.IsInRole(tb.Key);
                                }
                            }
                        }
                    }
                }
                //ultraToolbarsManager1.Toolbars
                
                foreach (object tools in ultraToolbarsManager1.Tools.All)
                {
                    if (tools is PopupMenuTool)
                    {
                        PopupMenuTool pTools = tools as PopupMenuTool;
                        int iVisible = 0;
                        foreach (object tool2 in pTools.Tools.All)
                        {
                            ToolBase tb = tool2 as ToolBase;
                            if (tb.SharedProps.Visible && !(tool2 is PopupMenuTool))
                            {
                                iVisible++;
                            }
                        }
                        if (iVisible == 0)
                        {
                            pTools.SharedProps.Visible = false;
                        }
                    }
                    //if (tools is ToolBar)
                    //{
                    //    ToolBar tb = tools as ToolBar;
                    //    int iVIsible = 0;
                    //    foreach (ToolBarButton tool2 in tb.Buttons)
                    //    {
                    //        if (tool2.Visible) iVIsible++;
                    //    }
                    //    if (iVIsible == 0) tb.Visible = false;
                    //}
                }
                foreach (UltraToolbar tb in ultraToolbarsManager1.Toolbars)
                {
                    int iVisible = 0;
                    foreach (ToolBase tb2 in tb.Tools)
                    {
                        if (tb2.SharedProps.Visible) iVisible++;
                    }
                    if (iVisible == 0) tb.Visible = false;
                }
            }	
			#endregion
			//LogAdapter.WriteFeaturesException(new Exception("���Ȩ�޿���"));
            if (mi.dept.cnnDeptID == 0)
			{
				this.ultraStatusBar1.Panels["Dept"].Text = "�������ţ�ϵͳ����Ա";
			}
			else
			{
                Dept dept = Login.constApp.htDept[mi.dept.cnnDeptID] as Dept;
				this.ultraStatusBar1.Panels["Dept"].Text = "�������ţ�"+dept.cnvcDeptName;
			}

            this.ultraStatusBar1.Panels["OperName"].Text = "��ǰ����Ա��" + mi.oper.cnvcOperName;
#if !DEBUG
			productRegister();	
#endif
			//LogAdapter.WriteFeaturesException(new Exception("���ע���ж�"));
			
		}

		private void MDI_Set()
		{
			foreach(System.Windows.Forms.Control myControl in this.Controls)
			{
				if(myControl.GetType().ToString() == "System.Windows.Forms.MdiClient")
				{
					bgMDIClient = (System.Windows.Forms.MdiClient)myControl;     
					break;
				}
			}	
			if(bgMDIClient.ClientSize.Width>0&&bgMDIClient.ClientSize.Height>0)
			{
				Assembly   asm   =   Assembly.GetExecutingAssembly();  
				Stream  imgStream = asm.GetManifestResourceStream("MemberManage.Resources.Logo.jpg");
				Bitmap MDIbg_Image = new Bitmap(imgStream);//new Bitmap("logo.jpg");
				System.Drawing.Bitmap myImg = new Bitmap(bgMDIClient.ClientSize.Width,bgMDIClient.ClientSize.Height);   
				System.Drawing.Graphics myGraphics = System.Drawing.Graphics.FromImage(myImg); 
				myGraphics.Clear(this.BackColor);

				//��־       
				myGraphics.Clear(this.BackColor);
				//��λ
				int myX,myY;
				myX=(myImg.Width-MDIbg_Image.Width)/2;
				myY=(myImg.Height -MDIbg_Image.Height)/2;
				myGraphics.DrawImage(MDIbg_Image,myX,myY,MDIbg_Image.Width,MDIbg_Image.Height);
				bgMDIClient.BackgroundImage = myImg;
				myGraphics.Dispose();
			}
		}

		private void setTab(string strTabText)
		{
			foreach(MdiTabGroup tabGroup in this.ultraTabbedMdiManager1.TabGroups) 
			{  
				foreach(MdiTab tab in tabGroup.Tabs) 
				{ 
					if (tab.Form.Text == strTabText) 
					{
		
						tab.Activate();
						//this.ultraStatusBar1.Panels["func"].Text = "��ǰ���ܣ�"+strTabText;
						return; 
					}
								
				} 
			} 
		}

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            //this.ultraStatusBar1.Panels["func"].Text = "��ǰ���ܣ�"+e.Tool.Key;
            switch (Login.constApp.strCardType)
            {
                case "l6":
                    ToolClick(e.Tool.Key);
                    ToolClickL6(e.Tool.Key);
                    break;
                case "l8":
                    ToolClick(e.Tool.Key);
                    ToolClickL8(e.Tool.Key);
                    break;
                case "l6l8":
                    ToolClick(e.Tool.Key);
                    ToolClickL6(e.Tool.Key);
                    ToolClickL8(e.Tool.Key);
                    break;
            }

        }
        private void ToolClick(string strkey)
        {
            MyPrincipal mp = Thread.CurrentPrincipal as MyPrincipal;
            MyIdentity mi = mp.Identity as MyIdentity;
            switch (strkey)
            {
                case "��Ƹ������":
                    if (!MemberBusiness.JobAdd.IsShowing)
                    {
                        MemberBusiness.JobAdd job = new MemberBusiness.JobAdd();
                        MemberBusiness.JobAdd.IsShowing = true;
                        job.MdiParent = this;
                        job.Show();
                    }
                    else
                    {
                        setTab("��Ƹ������");
                    }
                    break;
                case "��Ƹ����Ϣ��ѯ":
                    if (!MemberBusiness.JobQuery.IsShowing)
                    {
                        MemberBusiness.JobQuery jobQuery = new MemberBusiness.JobQuery();
                        MemberBusiness.JobQuery.IsShowing = true;
                        jobQuery.MdiParent = this;
                        jobQuery.Show();
                    }
                    else
                    {
                        setTab("��Ƹ����Ϣ��ѯ");
                    }
                    break;
                case "��Ƹ����Ϣ�޸�":
                    if (!MemberBusiness.JobModify.IsShowing)
                    {
                        MemberBusiness.JobModify jobModify = new MemberBusiness.JobModify();
                        MemberBusiness.JobModify.IsShowing = true;
                        jobModify.MdiParent = this;
                        jobModify.Show();
                    }
                    else
                    {
                        setTab("��Ƹ����Ϣ�޸�");
                    }
                    break;
                case "���Ź���":
                    if (!NDeptManage.IsShowing)
                    {
                        NDeptManage deptManage = new NDeptManage();
                        NDeptManage.IsShowing = true;
                        deptManage.MdiParent = this;
                        deptManage.Show();
                    }
                    else
                    {
                        setTab("���Ź���");
                    }
                    break;
                case "ҵ��Ա����"://zhh 20130313
                    if (!SalesManage.IsShowing)
                    {
                        SalesManage salesManage = new SalesManage();
                        SalesManage.IsShowing = true;
                        salesManage.MdiParent = this;
                        salesManage.Show();
                    }
                    else
                    {
                        setTab("ҵ��Ա����");
                    }
                    break;
                case "Ȩ�޹���":
                    if (!MemberBusiness.RightManage.IsShowing)
                    {

                        MemberBusiness.RightManage rightManage = new MemberBusiness.RightManage();
                        MemberBusiness.RightManage.IsShowing = true;
                        rightManage.MdiParent = this;
                        rightManage.Show();
                    }
                    else
                    {
                        setTab("Ȩ�޹���");
                    }
                    break;
                case "����Ȩ�޹���":
                    if (!MemberBusiness.DataRightManage.IsShowing)
                    {

                        MemberBusiness.DataRightManage datarightManage = new MemberBusiness.DataRightManage();
                        MemberBusiness.DataRightManage.IsShowing = true;
                        datarightManage.MdiParent = this;
                        datarightManage.Show();
                    }
                    else
                    {
                        setTab("����Ȩ�޹���");
                    }
                    break;
                case "����Ա�����޸�":
                    if (!OperPwdModify.IsShowing)
                    {
                        OperPwdModify operPwdModify = new OperPwdModify();
                        OperPwdModify.IsShowing = true;
                        operPwdModify.MdiParent = this;
                        operPwdModify.Show();
                    }
                    else
                    {
                        setTab("����Ա�����޸�");
                    }
                    break;
                case "ǩ������":
                    if (!SignInReport.IsShowing)
                    {
                        SignInReport signInReport = new SignInReport();
                        SignInReport.IsShowing = true;
                        signInReport.MdiParent = this;
                        signInReport.Show();
                    }
                    else
                    {
                        setTab("ǩ������");
                    }
                    break;
                case "չλ��������":
                    if (!NoSignInReport.IsShowing)
                    {
                        NoSignInReport noSignInReport = new NoSignInReport();
                        NoSignInReport.IsShowing = true;
                        noSignInReport.MdiParent = this;
                        noSignInReport.Show();
                    }
                    else
                    {
                        setTab("չλ��������");
                    }
                    break;
                case "Ԥ������":
                    if (!RemainReport.IsShowing)
                    {
                        RemainReport remainReport = new RemainReport();
                        RemainReport.IsShowing = true;
                        remainReport.MdiParent = this;
                        remainReport.Show();
                    }
                    else
                    {
                        setTab("Ԥ������");
                    }
                    break;
                case "ȡ��Ԥ������":
                    if (!NoBookingReport.IsShowing)
                    {
                        NoBookingReport noBookingReport = new NoBookingReport();
                        NoBookingReport.IsShowing = true;
                        noBookingReport.MdiParent = this;
                        noBookingReport.Show();
                    }
                    else
                    {
                        setTab("ȡ��Ԥ������");
                    }
                    break;
                case "СƱ�ش�":
                    if (!BillRepeat.IsShowing)
                    {
                        BillRepeat billRepeat = new BillRepeat();
                        BillRepeat.IsShowing = true;
                        billRepeat.MdiParent = this;
                        billRepeat.Show();
                    }
                    else
                    {
                        setTab("СƱ�ش�");
                    }
                    break;
                case "�ͷ���Ա����":
                    if (!CustomerServiceReport.IsShowing)
                    {
                        CustomerServiceReport productReport = new CustomerServiceReport();
                        CustomerServiceReport.IsShowing = true;
                        productReport.MdiParent = this;
                        productReport.Show();
                    }
                    else
                    {
                        setTab("�ͷ���Ա����");
                    }
                    break;
                case "����Ա������":
                    try
                    {
                        SecurityManage sm = new SecurityManage();
                        string strRet = sm.OperCardCallBack(mi.oper.cnvcOperName);
                        if (strRet == "")
                        {
                            MessageBox.Show("����Ա�����ճɹ�", "����Ա������");
                        }
                        else
                        {
                            throw new BusinessException("����Ա������", strRet);
                        }
                    }
                    catch (BusinessException bex)
                    {
                        MessageBox.Show(this, bex.Message, bex.Type, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "�˳�":
                    Application.Exit();
                    break;
                case "ע��":
                    this.isUserClose = true;
                    this.Close();
                    break;
                case "����":
                    string helpfile = Application.StartupPath + @"\Help.chm";
                    Help.ShowHelp(this, helpfile);
                    //Application.Exit();
                    break;
                //��ֵ����
                case "��ֵ����":
                    if (!InMoneySetting.IsShowing)
                    {
                        InMoneySetting ims = new InMoneySetting();
                        InMoneySetting.IsShowing = true;
                        ims.MdiParent = this;
                        ims.Show();
                    }
                    else
                    {
                        setTab("��ֵ����");
                    }
                    break;
                case "����ѡ��":
                    CardType ct = new CardType();
                    ct.ShowDialog(this);
                    break;
                case "ekey����":
                    MemberBusiness.ManageNT77 mnt = new MemberManage.MemberBusiness.ManageNT77();
                    mnt.ShowDialog(this);
                    break;
                case "�ǻ�Ա¼��":
                    if (!MemberBusiness.FMemberCardProvide.IsShowing)
                    {
                        MemberBusiness.FMemberCardProvide fMemberCardProvide = new MemberBusiness.FMemberCardProvide();
                        MemberBusiness.FMemberCardProvide.IsShowing = true;
                        fMemberCardProvide.MdiParent = this;
                        fMemberCardProvide.Show();
                    }
                    else
                    {
                        setTab("�ǻ�Ա¼��");
                    }
                    break;
                case "�ǻ�Ա�޸�":
                    if (!MemberBusiness.FMemberFileModify.IsShowing)
                    {
                        MemberBusiness.FMemberFileModify fmemberFileModify = new MemberBusiness.FMemberFileModify();
                        MemberBusiness.FMemberFileModify.IsShowing = true;
                        fmemberFileModify.MdiParent = this;
                        fmemberFileModify.Show();
                    }
                    else
                    {
                        setTab("�ǻ�Ա�޸�");
                    }
                    break;
                case "��Ʒ����":
                    if (!ProductSetting.IsShowing)
                    {
                        ProductSetting ps = new ProductSetting();
                        ProductSetting.IsShowing = true;
                        ps.MdiParent = this;
                        ps.Show();
                    }
                    else
                    {
                        setTab("��Ʒ����");
                    }
                    break;
                
                
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "��Ա��������")
            {
                if (!MemberSetting.IsShowing)
                {
                    MemberSetting memberSetting = new MemberSetting();
                    memberSetting.Text = strkey;
                    MemberSetting.IsShowing = true;
                    memberSetting.MdiParent = this;
                    memberSetting.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "��Ա��������");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "��Ա��������")
            {
                if (!MemberBusiness.MemberSetting.IsShowing)
                {
                    MemberBusiness.MemberSetting memberSetting = new MemberBusiness.MemberSetting();
                    MemberBusiness.MemberSetting.IsShowing = true;
                    memberSetting.MdiParent = this;
                    memberSetting.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "��Ա��������");
                }
            }
        }
        private void ToolClickL6(string strkey)
        {
            MyPrincipal mp = Thread.CurrentPrincipal as MyPrincipal;
            MyIdentity mi = mp.Identity as MyIdentity;
            if (strkey == Login.constApp.strCardTypeL6Name + "��Ƹ��չλ��������")
            {
                if (!MemberBusiness.ShowPlan.IsShowing)
                {
                    MemberBusiness.ShowPlan floor = new MemberBusiness.ShowPlan();
                    MemberBusiness.ShowPlan.IsShowing = true;
                    floor.Text = strkey;
                    floor.MdiParent = this;
                    floor.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "��Ƹ��չλ��������");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "չλԤ��")
            {
                if (!MemberBusiness.ShowBooking.IsShowing)
                {
                    MemberBusiness.ShowBooking showBooking = new MemberBusiness.ShowBooking();
                    MemberBusiness.ShowBooking.IsShowing = true;
                    showBooking.Text = strkey;
                    showBooking.MdiParent = this;
                    showBooking.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "չλԤ��");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "չλǩ��")
            {
                if (!Business.ConsumeBusiness.ShowSignIn.IsShowing)
                {
                    Business.ConsumeBusiness.ShowSignIn showSignIn = new Business.ConsumeBusiness.ShowSignIn();
                    Business.ConsumeBusiness.ShowSignIn.IsShowing = true;
                    showSignIn.Text = strkey;
                    showSignIn.MdiParent = this;
                    showSignIn.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "չλǩ��");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "չλԤ��")
            {
                if (!MemberBusiness.ShowRemain.IsShowing)
                {
                    MemberBusiness.ShowRemain showRemain = new MemberBusiness.ShowRemain();
                    MemberBusiness.ShowRemain.IsShowing = true;
                    showRemain.Text = strkey;
                    showRemain.MdiParent = this;
                    showRemain.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "չλԤ��");
                }
            }

            if (strkey == Login.constApp.strCardTypeL6Name + "��Ա��������")
            {
                if (!MemberReport.MemberFileQuery.IsShowing)
                {
                    MemberReport.MemberFileQuery memberFileQuery = new MemberReport.MemberFileQuery();
                    MemberReport.MemberFileQuery.IsShowing = true;
                    memberFileQuery.Text = strkey;
                    memberFileQuery.MdiParent = this;
                    memberFileQuery.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "��Ա��������");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "�ǻ�Ա��������")
            {
                if (!MemberReport.FMemberFileReport.IsShowing)
                {
                    MemberReport.FMemberFileReport fMemberFileReport = new MemberReport.FMemberFileReport();
                    MemberReport.FMemberFileReport.IsShowing = true;
                    fMemberFileReport.Text = strkey;
                    fMemberFileReport.MdiParent = this;
                    fMemberFileReport.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "�ǻ�Ա��������");
                }
            }

            if (strkey == Login.constApp.strCardTypeL6Name + "Ԥ������")
            {
                if (!MemberReport.BookingReport.IsShowing)
                {
                    MemberReport.BookingReport bookingReport = new MemberReport.BookingReport();
                    MemberReport.BookingReport.IsShowing = true;
                    bookingReport.Text = strkey;
                    bookingReport.MdiParent = this;
                    bookingReport.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "Ԥ������");
                }
            }

            if (strkey == Login.constApp.strCardTypeL6Name + "�ǻ�Ա��ֵ����")
            {
                if (!MemberReport.AddPrepayReport.IsShowing)
                {
                    MemberReport.AddPrepayReport addPrepayReport = new MemberReport.AddPrepayReport();
                    MemberReport.AddPrepayReport.IsShowing = true;
                    addPrepayReport.Text = strkey;
                    addPrepayReport.MdiParent = this;
                    addPrepayReport.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "�ǻ�Ա��ֵ����");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "������־����")
            {
                if (!MemberReport.OperLogReport.IsShowing)
                {
                    MemberReport.OperLogReport operLogReport = new MemberReport.OperLogReport();
                    MemberReport.OperLogReport.IsShowing = true;
                    operLogReport.Text = strkey;
                    operLogReport.MdiParent = this;
                    operLogReport.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "������־����");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "��Ʒ����")
            {
                if (!ConsumeBusiness.UseProduct.IsShowing)
                {
                    ConsumeBusiness.UseProduct useProduct = new ConsumeBusiness.UseProduct();
                    ConsumeBusiness.UseProduct.IsShowing = true;
                    useProduct.Text = strkey;
                    useProduct.MdiParent = this;
                    useProduct.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "��Ʒ����");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "�����Ʒ���ѱ���")
            {
                if (!MemberReport.ProductConsumeReport.IsShowing)
                {
                    MemberReport.ProductConsumeReport productReport = new MemberReport.ProductConsumeReport();
                    MemberReport.ProductConsumeReport.IsShowing = true;
                    productReport.Text = strkey;
                    productReport.MdiParent = this;
                    productReport.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "�����Ʒ���ѱ���");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "������ϸ����")
            {
                if (!MemberReport.AllMoneyReport.IsShowing)
                {
                    MemberReport.AllMoneyReport productReport = new MemberReport.AllMoneyReport();
                    MemberReport.AllMoneyReport.IsShowing = true;
                    productReport.Text = strkey;
                    productReport.MdiParent = this;
                    productReport.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "������ϸ����");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "��ֵ����")
            {
                if (!MemberReport.InMoneyReport.IsShowing)
                {
                    MemberReport.InMoneyReport inMoneyReport = new MemberReport.InMoneyReport();
                    MemberReport.InMoneyReport.IsShowing = true;
                    inMoneyReport.Text = strkey;
                    inMoneyReport.MdiParent = this;
                    inMoneyReport.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "��ֵ����");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "¼��")
            {
                if (!MemberBusiness.MemberCardProvide.IsShowing)
                {
                    MemberBusiness.MemberCardProvide memberCardProvide = new MemberBusiness.MemberCardProvide();
                    MemberBusiness.MemberCardProvide.IsShowing = true;
                    memberCardProvide.Text = strkey;
                    memberCardProvide.MdiParent = this;
                    memberCardProvide.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "¼��");

                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "��ʧ")
            {
                if (!MemberBusiness.MemberCardInlose.IsShowing)
                {
                    MemberBusiness.MemberCardInlose memberCardInLose = new MemberBusiness.MemberCardInlose();
                    MemberBusiness.MemberCardInlose.IsShowing = true;
                    memberCardInLose.Text = strkey;
                    memberCardInLose.MdiParent = this;
                    memberCardInLose.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "��ʧ");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "���")
            {
                if (!MemberBusiness.MemberCardInUser.IsShowing)
                {
                    MemberBusiness.MemberCardInUser memberCardInUse = new MemberBusiness.MemberCardInUser();
                    MemberBusiness.MemberCardInUser.IsShowing = true;
                    memberCardInUse.Text = strkey;
                    memberCardInUse.MdiParent = this;
                    memberCardInUse.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "���");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "��ֵ")
            {
                if (!MemberBusiness.MemberCardInMoney.IsShowing)
                {
                    MemberBusiness.MemberCardInMoney memberCardInMoney = new MemberBusiness.MemberCardInMoney();
                    MemberBusiness.MemberCardInMoney.IsShowing = true;
                    memberCardInMoney.Text = strkey;
                    memberCardInMoney.MdiParent = this;
                    memberCardInMoney.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "��ֵ");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "����")
            {
                if (!MemberBusiness.MemberCardAddCard.IsShowing)
                {
                    MemberBusiness.MemberCardAddCard memberCardAddCard = new MemberBusiness.MemberCardAddCard();
                    MemberBusiness.MemberCardAddCard.IsShowing = true;
                    memberCardAddCard.Text = strkey;
                    memberCardAddCard.MdiParent = this;
                    memberCardAddCard.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "����");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "����")
            {
                try
                {

                    ynhrMemberManage.BusinessFacade.MemberBusiness.MemberManageFacade memberManage = new ynhrMemberManage.BusinessFacade.MemberBusiness.MemberManageFacade();
                    Member member = new Member();
                    member.cnvcOperName = mi.oper.cnvcOperName;
                    member.cndOperDate = DateTime.Now;
                    memberManage.MemberCardCallBack(member);
                    MessageBox.Show("��Ա�����ճɹ�", "����");
                }
                catch (BusinessException bex)
                {
                    MessageBox.Show(this, bex.Message, bex.Type, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "����")
            {
                if (!MemberBusiness.MemberCardRenew.IsShowing)
                {
                    MemberBusiness.MemberCardRenew memberCardRenew = new MemberBusiness.MemberCardRenew();
                    MemberBusiness.MemberCardRenew.IsShowing = true;
                    memberCardRenew.Text = strkey;
                    memberCardRenew.MdiParent = this;
                    memberCardRenew.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "����");

                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "�޿���Աɾ��")
            {
                if (!MemberBusiness.NoCardDelete.IsShowing)
                {
                    MemberBusiness.NoCardDelete memberCardRenew = new MemberBusiness.NoCardDelete();
                    MemberBusiness.NoCardDelete.IsShowing = true;
                    memberCardRenew.Text = strkey;
                    memberCardRenew.MdiParent = this;
                    memberCardRenew.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "�޿���Աɾ��");

                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "��Ա�޸�")
            {
                if (!MemberBusiness.MemberFileModify.IsShowing)
                {
                    MemberBusiness.MemberFileModify memberFileModify = new MemberBusiness.MemberFileModify();
                    MemberBusiness.MemberFileModify.IsShowing = true;
                    memberFileModify.Text = strkey;
                    memberFileModify.MdiParent = this;
                    memberFileModify.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "��Ա�޸�");
                }
            }

            if (strkey == Login.constApp.strCardTypeL6Name + "�ǻ�Ա��ֵ")
            {
                if (!Business.ConsumeBusiness.AddPrepay.IsShowing)
                {
                    Business.ConsumeBusiness.AddPrepay ims = new Business.ConsumeBusiness.AddPrepay();
                    Business.ConsumeBusiness.AddPrepay.IsShowing = true;
                    ims.Text = strkey;
                    ims.MdiParent = this;
                    ims.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL6Name + "�ǻ�Ա��ֵ");
                }
            }
        }
        private void ToolClickL8(string strkey)
        {
            MyPrincipal mp = Thread.CurrentPrincipal as MyPrincipal;
            MyIdentity mi = mp.Identity as MyIdentity;
            if (strkey == Login.constApp.strCardTypeL8Name + "��Ա��Ϣ¼��")
            {
                if (!MemberCardProvide.IsShowing)
                {
                    MemberCardProvide memberCardProvide = new MemberCardProvide();
                    MemberCardProvide.IsShowing = true;
                    memberCardProvide.Text = strkey;
                    memberCardProvide.MdiParent = this;
                    memberCardProvide.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "��Ա��Ϣ¼��");

                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "��ʧ")
            {
                if (!MemberCardInlose.IsShowing)
                {
                    MemberCardInlose memberCardInLose = new MemberCardInlose();
                    MemberCardInlose.IsShowing = true;
                    memberCardInLose.Text = strkey;
                    memberCardInLose.MdiParent = this;
                    memberCardInLose.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "��ʧ");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "���")
            {
                if (!MemberCardInUser.IsShowing)
                {
                    MemberCardInUser memberCardInUse = new MemberCardInUser();
                    MemberCardInUser.IsShowing = true;
                    memberCardInUse.Text = strkey;
                    memberCardInUse.MdiParent = this;
                    memberCardInUse.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "���");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "��ֵ")
            {
                if (!MemberCardInMoney.IsShowing)
                {
                    MemberCardInMoney memberCardInMoney = new MemberCardInMoney();
                    MemberCardInMoney.IsShowing = true;
                    memberCardInMoney.Text = strkey;
                    memberCardInMoney.MdiParent = this;
                    memberCardInMoney.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "��ֵ");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "����")
            {
                if (!MemberCardAddCard.IsShowing)
                {
                    MemberCardAddCard memberCardAddCard = new MemberCardAddCard();
                    MemberCardAddCard.IsShowing = true;
                    memberCardAddCard.Text = strkey;
                    memberCardAddCard.MdiParent = this;
                    memberCardAddCard.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "����");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "����")
            {
                try
                {
                    MemberManageFacade memberManage = new MemberManageFacade();
                    Member member = new Member();
                    member.cnvcOperName = mi.oper.cnvcOperName;
                    member.cndOperDate = DateTime.Now;
                    memberManage.MemberCardCallBack(member);
                    MessageBox.Show("��Ա�����ճɹ�", "����");
                }
                catch (BusinessException bex)
                {
                    MessageBox.Show(this, bex.Message, bex.Type, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "����")
            {
                if (!MemberCardRenew.IsShowing)
                {
                    MemberCardRenew memberCardRenew = new MemberCardRenew();
                    MemberCardRenew.IsShowing = true;
                    memberCardRenew.Text = strkey;
                    memberCardRenew.MdiParent = this;
                    memberCardRenew.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "����");

                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "ɾ��δ������Ա")
            {
                if (!NoCardDelete.IsShowing)
                {
                    NoCardDelete memberCardRenew = new NoCardDelete();
                    NoCardDelete.IsShowing = true;
                    memberCardRenew.Text = strkey;
                    memberCardRenew.MdiParent = this;
                    memberCardRenew.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "ɾ��δ������Ա");

                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "��Ա��������")
            {
                if (!MemberFileQuery.IsShowing)
                {
                    MemberFileQuery memberFileQuery = new MemberFileQuery();
                    MemberFileQuery.IsShowing = true;
                    memberFileQuery.Text = strkey;
                    memberFileQuery.MdiParent = this;
                    memberFileQuery.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "��Ա��������");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "�ǻ�Ա��������")
            {
                if (!FMemberFileReport.IsShowing)
                {
                    FMemberFileReport fMemberFileReport = new FMemberFileReport();
                    FMemberFileReport.IsShowing = true;
                    fMemberFileReport.Text = strkey;
                    fMemberFileReport.MdiParent = this;
                    fMemberFileReport.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "�ǻ�Ա��������");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "��Ա�����޸�")
            {
                if (!MemberFileModify.IsShowing)
                {
                    MemberFileModify memberFileModify = new MemberFileModify();
                    MemberFileModify.IsShowing = true;
                    memberFileModify.Text = strkey;
                    memberFileModify.MdiParent = this;
                    memberFileModify.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "��Ա�����޸�");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "��Ա��ѳ����޸�")
            {
                if (!MemberFreeModify.IsShowing)
                {
                    MemberFreeModify memberFreeModify = new MemberFreeModify();
                    MemberFreeModify.IsShowing = true;
                    memberFreeModify.Text = strkey;
                    memberFreeModify.MdiParent = this;
                    memberFreeModify.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "��Ա��ѳ����޸�");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "�ǻ�Ա�����޸�")
            {
                if (!FMemberFileModify.IsShowing)
                {
                    FMemberFileModify fmemberFileModify = new FMemberFileModify();
                    FMemberFileModify.IsShowing = true;
                    fmemberFileModify.Text = strkey;
                    fmemberFileModify.MdiParent = this;
                    fmemberFileModify.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "�ǻ�Ա�����޸�");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "��Ƹ��չλ��������")
            {
                if (!ShowPlan.IsShowing)
                {
                    ShowPlan floor = new ShowPlan();
                    ShowPlan.IsShowing = true;
                    floor.Text = strkey;
                    floor.MdiParent = this;
                    floor.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "��Ƹ��չλ��������");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "չλԤ��")
            {
                if (!ShowBooking.IsShowing)
                {
                    ShowBooking showBooking = new ShowBooking();
                    ShowBooking.IsShowing = true;
                    showBooking.Text = strkey;
                    showBooking.MdiParent = this;
                    showBooking.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "չλԤ��");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "չλǩ��")
            {
                if (!ShowSignIn.IsShowing)
                {
                    ShowSignIn showSignIn = new ShowSignIn();
                    ShowSignIn.IsShowing = true;
                    showSignIn.Text = strkey;
                    showSignIn.MdiParent = this;
                    showSignIn.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "չλǩ��");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "չλԤ��")
            {
                if (!ShowRemain.IsShowing)
                {
                    ShowRemain showRemain = new ShowRemain();
                    ShowRemain.IsShowing = true;
                    showRemain.Text = strkey;
                    showRemain.MdiParent = this;
                    showRemain.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "չλԤ��");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "�ɷ�")
            {
                if (!AddPrepay.IsShowing)
                {
                    AddPrepay addPrepay = new AddPrepay();
                    AddPrepay.IsShowing = true;
                    addPrepay.Text = strkey;
                    addPrepay.MdiParent = this;
                    addPrepay.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "�ɷ�");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "�˷�")
            {
                if (!ReturnPrepay.IsShowing)
                {
                    ReturnPrepay returnPrepay = new ReturnPrepay();
                    ReturnPrepay.IsShowing = true;
                    returnPrepay.Text = strkey;
                    returnPrepay.MdiParent = this;
                    returnPrepay.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "�˷�");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "Ԥ������")
            {
                if (!BookingReport.IsShowing)
                {
                    BookingReport bookingReport = new BookingReport();
                    BookingReport.IsShowing = true;
                    bookingReport.Text = strkey;
                    bookingReport.MdiParent = this;
                    bookingReport.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "Ԥ������");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "�ɷѱ���")
            {
                if (!AddPrepayReport.IsShowing)
                {
                    AddPrepayReport addPrepayReport = new AddPrepayReport();
                    AddPrepayReport.IsShowing = true;
                    addPrepayReport.Text = strkey;
                    addPrepayReport.MdiParent = this;
                    addPrepayReport.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "�ɷѱ���");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "������־����")
            {
                if (!OperLogReport.IsShowing)
                {
                    OperLogReport operLogReport = new OperLogReport();
                    OperLogReport.IsShowing = true;
                    operLogReport.Text = strkey;
                    operLogReport.MdiParent = this;
                    operLogReport.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "������־����");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "�����Ʒ����")
            {
                if (!UseProduct.IsShowing)
                {
                    UseProduct useProduct = new UseProduct();
                    UseProduct.IsShowing = true;
                    useProduct.Text = strkey;
                    useProduct.MdiParent = this;
                    useProduct.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "�����Ʒ����");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "�����Ʒ���ѱ���")
            {
                if (!ProductReport.IsShowing)
                {
                    ProductReport productReport = new ProductReport();
                    ProductReport.IsShowing = true;
                    productReport.Text = strkey;
                    productReport.MdiParent = this;
                    productReport.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "�����Ʒ���ѱ���");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "�����Ʒ��ֵ�ɷѱ���")
            {
                if (!ProductConsumeReport.IsShowing)
                {
                    ProductConsumeReport productReport = new ProductConsumeReport();
                    ProductConsumeReport.IsShowing = true;
                    productReport.Text = strkey;
                    productReport.MdiParent = this;
                    productReport.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "�����Ʒ��ֵ�ɷѱ���");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "���뱨��")
            {
                if (!AllMoneyReport.IsShowing)
                {
                    AllMoneyReport productReport = new AllMoneyReport();
                    AllMoneyReport.IsShowing = true;
                    productReport.Text = strkey;
                    productReport.MdiParent = this;
                    productReport.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "���뱨��");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "��ֵ����")
            {
                if (!InMoneyReport.IsShowing)
                {
                    InMoneyReport inMoneyReport = new InMoneyReport();
                    InMoneyReport.IsShowing = true;
                    inMoneyReport.Text = strkey;
                    inMoneyReport.MdiParent = this;
                    inMoneyReport.Show();
                }
                else
                {
                    setTab(Login.constApp.strCardTypeL8Name + "��ֵ����");
                }
            }
        }

        private void MainMenuBar()
        {
            Dictionary<string, Dictionary<string, int>> dmenu = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> dcard = new Dictionary<string, int>();           
            dcard.Add("�ǻ�Ա¼��", 16);
            dcard.Add("�ǻ�Ա�޸�", 16);

            dmenu.Add("�ǻ�Ա����", dcard);

            Dictionary<string, int> djob = new Dictionary<string, int>();
            djob.Add("��Ƹ������", 9);
            djob.Add("��Ƹ����Ϣ�޸�", 10);
            djob.Add("��Ƹ����Ϣ��ѯ", 6);
            //djob.Add("СƱ�ش�", 18);
            dmenu.Add("��Ƹ�����", djob);

            Dictionary<string, int> dreport = new Dictionary<string, int>();
            dreport.Add("ǩ������", 18);
            dreport.Add("չλ��������", 18);
            dreport.Add("Ԥ������", 18);
            dreport.Add("ȡ��Ԥ������", 18);
            dreport.Add("�ͷ���Ա����", 18);
            dreport.Add("СƱ�ش�", 18);
            dmenu.Add("����", dreport);

            Dictionary<string, int> dsys = new Dictionary<string, int>();
            dsys.Add("���Ź���", 15);
            dsys.Add("ҵ��Ա����", 15);//zhh 20130313
            dsys.Add("����Ա�����޸�", 15);
            dsys.Add("����Ա������", 15);
            //dsys.Add(Login.constApp.strCardTypeL8Name + "��Ա��������", 15);
            dsys.Add(Login.constApp.strCardTypeL6Name + "��Ա��������", 15);
            dsys.Add("Ȩ�޹���", 15);
            dsys.Add("����Ȩ�޹���", 15);
            dsys.Add("��Ʒ����", 8);
            dsys.Add("��ֵ����", 8);

            dsys.Add("ekey����",8);
            dsys.Add("����ѡ��", 8);
            dmenu.Add("ϵͳ����", dsys);

            Dictionary<string, int> dexit = new Dictionary<string, int>();
            dexit.Add("����", 19);
            dexit.Add("��ע��", 17);
            dexit.Add("ע��", 20);
            dexit.Add("�˳�", 20);

            dmenu.Add("ϵͳ�˳�", dexit);

            foreach (KeyValuePair<string, Dictionary<string, int>> kvpmenu in dmenu)
            {
                PopupMenuTool menu = new PopupMenuTool(kvpmenu.Key);
                this.ultraToolbarsManager1.Tools.Add(menu);
                menu.SharedProps.Caption = kvpmenu.Key;
                
                foreach (KeyValuePair<string, int> kvp in kvpmenu.Value)
                {
                    ButtonTool btntl = new ButtonTool(kvp.Key);
                    this.ultraToolbarsManager1.Tools.Add(btntl);
                    btntl.SharedProps.Caption = kvp.Key;
                    btntl.SharedProps.DisplayStyle = ToolDisplayStyle.ImageAndText;
                    btntl.SharedProps.AppearancesSmall.Appearance.Image = this.imageList1.Images[kvp.Value];
                    menu.Tools.Add(btntl);
                    if (kvpmenu.Key == "����") continue;
                    if (kvpmenu.Key == "ϵͳ�˳�") continue;
                    if (kvpmenu.Key == "ϵͳ����") continue;
                    this.ultraToolbarsManager1.Toolbars["������"].Tools.Add(btntl);
                }                
            }
            
        }
		private void MainMenuBarL8()
		{

            Dictionary<string, Dictionary<string, int>> dmenu = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> dcard = new Dictionary<string, int>();
            dcard.Add(Login.constApp.strCardTypeL8Name + "��Ա��Ϣ¼��", 0);
            dcard.Add(Login.constApp.strCardTypeL8Name + "��ֵ", 1);
            dcard.Add(Login.constApp.strCardTypeL8Name + "��ʧ", 2);
            dcard.Add(Login.constApp.strCardTypeL8Name + "���", 3);
            dcard.Add(Login.constApp.strCardTypeL8Name + "����", 4);
            dcard.Add(Login.constApp.strCardTypeL8Name + "����", 5);
            //dmenu.Add(Login.constApp.strCardTypeL8Name + "��Ա��", dcard);

            //Dictionary<string, int> dmem = new Dictionary<string, int>();
            dcard.Add(Login.constApp.strCardTypeL8Name + "����", 0);
            dcard.Add(Login.constApp.strCardTypeL8Name + "ɾ��δ������Ա", 0);
            dcard.Add(Login.constApp.strCardTypeL8Name + "��Ա�����޸�", 7);
            dcard.Add(Login.constApp.strCardTypeL8Name + "��Ա��ѳ����޸�", 7);
            //dcard.Add(Login.constApp.strCardTypeL8Name + "��ӷǻ�Ա��Ϣ", 16);
            //dcard.Add(Login.constApp.strCardTypeL8Name + "�ǻ�Ա�����޸�", 16);

            //Dictionary<string,int> dindex = new Dictionary<string,int>();            
            dmenu.Add(Login.constApp.strCardTypeL8Name + "����", dcard);
            
            //Dictionary<string, int> djob = new Dictionary<string, int>();
            //djob.Add(Login.constApp.strCardTypeL8Name + "��Ƹ������", 9);
            //djob.Add(Login.constApp.strCardTypeL8Name + "��Ƹ����Ϣ�޸�", 10);
            //djob.Add(Login.constApp.strCardTypeL8Name + "��Ƹ����Ϣ��ѯ", 6);

            //dmenu.Add(Login.constApp.strCardTypeL8Name + "��Ƹ�����", djob);

            Dictionary<string, int> dfee = new Dictionary<string, int>();
            dfee.Add(Login.constApp.strCardTypeL8Name + "�ɷ�", 21);
            dfee.Add(Login.constApp.strCardTypeL8Name + "�˷�", 21);
            //dfee.Add(Login.constApp.strCardTypeL8Name + "СƱ�ش�", 18);
            dmenu.Add(Login.constApp.strCardTypeL8Name + "���ù���", dfee);

            Dictionary<string, int> dshow = new Dictionary<string, int>();
            dshow.Add(Login.constApp.strCardTypeL8Name + "��Ƹ��չλ��������", 8);
            dshow.Add(Login.constApp.strCardTypeL8Name + "չλԤ��", 12);
            dshow.Add(Login.constApp.strCardTypeL8Name + "չλԤ��", 13);
            dshow.Add(Login.constApp.strCardTypeL8Name + "չλǩ��", 14);
            dshow.Add(Login.constApp.strCardTypeL8Name + "�����Ʒ����", 14);

            dmenu.Add(Login.constApp.strCardTypeL8Name + "չλ����", dshow);

            Dictionary<string, int> dreport = new Dictionary<string, int>();
            dreport.Add(Login.constApp.strCardTypeL8Name + "��Ա��������", 18);
            dreport.Add(Login.constApp.strCardTypeL8Name + "�ǻ�Ա��������", 18);
            //dreport.Add(Login.constApp.strCardTypeL8Name + "ǩ������", 18);
            //dreport.Add(Login.constApp.strCardTypeL8Name + "չλ��������", 18);
            dreport.Add(Login.constApp.strCardTypeL8Name + "Ԥ������", 18);
            //dreport.Add(Login.constApp.strCardTypeL8Name + "Ԥ������", 18);
            //dreport.Add(Login.constApp.strCardTypeL8Name + "ȡ��Ԥ������", 18);
            dreport.Add(Login.constApp.strCardTypeL8Name + "�ɷѱ���", 18);
            dreport.Add(Login.constApp.strCardTypeL8Name + "��ֵ����", 18);
            dreport.Add(Login.constApp.strCardTypeL8Name + "�����Ʒ���ѱ���", 18);
            dreport.Add(Login.constApp.strCardTypeL8Name + "�����Ʒ��ֵ�ɷѱ���", 18);
            dreport.Add(Login.constApp.strCardTypeL8Name + "���뱨��", 18);
            dreport.Add(Login.constApp.strCardTypeL8Name + "������־����", 18);
            //dreport.Add(Login.constApp.strCardTypeL8Name + "�ͷ���Ա����", 18);
            dmenu.Add(Login.constApp.strCardTypeL8Name + "����", dreport);

            //Dictionary<string, int> dsys = new Dictionary<string, int>();
            //dsys.Add(Login.constApp.strCardTypeL8Name + "���Ź���", 15);
            //dsys.Add(Login.constApp.strCardTypeL8Name + "����Ա�����޸�", 15);
            //dsys.Add(Login.constApp.strCardTypeL8Name + "����Ա������", 15);
            //dsys.Add(Login.constApp.strCardTypeL8Name + "��Ա��������", 15);
            //dsys.Add(Login.constApp.strCardTypeL8Name + "Ȩ�޹���", 15);
            //dsys.Add(Login.constApp.strCardTypeL8Name + "����ѡ��", 8);
            //dmenu.Add(Login.constApp.strCardTypeL8Name + "ϵͳ����", dsys);

            //Dictionary<string, int> dexit = new Dictionary<string, int>();
            //dexit.Add(Login.constApp.strCardTypeL8Name + "����", 19);
            //dexit.Add(Login.constApp.strCardTypeL8Name + "��Ʒע��", 17);
            //dexit.Add(Login.constApp.strCardTypeL8Name + "ע��", 20);
            //dexit.Add(Login.constApp.strCardTypeL8Name + "�˳�", 20);

            //dmenu.Add(Login.constApp.strCardTypeL8Name + "ϵͳ�˳�", dexit);
            foreach (KeyValuePair<string, Dictionary<string, int>> kvpmenu in dmenu)
            {
                PopupMenuTool menu = new PopupMenuTool(kvpmenu.Key);
                this.ultraToolbarsManager1.Tools.Add(menu);
                menu.SharedProps.Caption = kvpmenu.Key;
                foreach (KeyValuePair<string, int> kvp in kvpmenu.Value)
                {
                    ButtonTool btntl = new ButtonTool(kvp.Key);
                    this.ultraToolbarsManager1.Tools.Add(btntl);
                    btntl.SharedProps.Caption = kvp.Key;
                    btntl.SharedProps.DisplayStyle = ToolDisplayStyle.ImageAndText;
                    btntl.SharedProps.AppearancesSmall.Appearance.Image = this.imageList1.Images[kvp.Value];
                    menu.Tools.Add(btntl);
                    if (kvpmenu.Key == Login.constApp.strCardTypeL8Name + "����") continue;
                    this.ultraToolbarsManager1.Toolbars[Login.constApp.strCardTypeL8Name + "������"].Tools.Add(btntl);
                }
                //this.ultraToolbarsManager1.Toolbars["���˵���"].Tools.Add(menu);
            }
		}
        private void MainMenuBarL6()
        {
            
            Dictionary<string, Dictionary<string, int>> dmenu = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> dcard = new Dictionary<string, int>();
            dcard.Add(Login.constApp.strCardTypeL6Name + "¼��", 0);
            dcard.Add(Login.constApp.strCardTypeL6Name + "����", 0);
            dcard.Add(Login.constApp.strCardTypeL6Name + "��ֵ", 1);
            dcard.Add(Login.constApp.strCardTypeL6Name + "��ʧ", 2);
            dcard.Add(Login.constApp.strCardTypeL6Name + "���", 3);
            dcard.Add(Login.constApp.strCardTypeL6Name + "����", 4);
            dcard.Add(Login.constApp.strCardTypeL6Name + "����", 5);
            dcard.Add(Login.constApp.strCardTypeL6Name + "�޿���Աɾ��", 0);
            dcard.Add(Login.constApp.strCardTypeL6Name + "��Ա�޸�", 7);
            //dcard.Add(Login.constApp.strCardTypeL6Name + "�ǻ�Ա¼��", 16);
            //dcard.Add(Login.constApp.strCardTypeL6Name + "�ǻ�Ա�޸�", 7);
            dcard.Add(Login.constApp.strCardTypeL6Name + "�ǻ�Ա��ֵ", 1);
            dcard.Add(Login.constApp.strCardTypeL6Name + "��Ʒ����", 22);
            dmenu.Add(Login.constApp.strCardTypeL6Name + "����", dcard);

            //Dictionary<string, int> dfee = new Dictionary<string, int>();
            //dfee.Add(Login.constApp.strCardTypeL6Name + "��Ʒ����", 22);
            //dfee.Add(Login.constApp.strCardTypeL6Name + "СƱ�ش�", 18);

            //dmenu.Add(Login.constApp.strCardTypeL6Name + "���ѹ���", dfee);

            //Dictionary<string, int> djob = new Dictionary<string, int>();
            //djob.Add(Login.constApp.strCardTypeL6Name + "��Ƹ������", 9);
            //djob.Add(Login.constApp.strCardTypeL6Name + "��Ƹ����Ϣ�޸�", 10);
            //djob.Add(Login.constApp.strCardTypeL6Name + "��Ƹ����Ϣ��ѯ", 6);

            //dmenu.Add(Login.constApp.strCardTypeL6Name + "��Ƹ�����", djob);

            Dictionary<string, int> dshow = new Dictionary<string, int>();
            dshow.Add(Login.constApp.strCardTypeL6Name + "��Ƹ��չλ��������", 8);
            dshow.Add(Login.constApp.strCardTypeL6Name + "չλԤ��", 12);
            dshow.Add(Login.constApp.strCardTypeL6Name + "չλԤ��", 13);
            dshow.Add(Login.constApp.strCardTypeL6Name + "չλǩ��", 14);

            dmenu.Add(Login.constApp.strCardTypeL6Name + "չλ����", dshow);

            Dictionary<string, int> dreport = new Dictionary<string, int>();
            dreport.Add(Login.constApp.strCardTypeL6Name + "��Ա��������", 18);
            dreport.Add(Login.constApp.strCardTypeL6Name + "�ǻ�Ա��������", 18);
            //dreport.Add(Login.constApp.strCardTypeL6Name + "ǩ������", 18);
            //dreport.Add(Login.constApp.strCardTypeL6Name + "չλ��������", 18);
            dreport.Add(Login.constApp.strCardTypeL6Name + "Ԥ������", 18);
            //dreport.Add(Login.constApp.strCardTypeL6Name + "Ԥ������", 18);
            //dreport.Add(Login.constApp.strCardTypeL6Name + "ȡ��Ԥ������", 18);
            dreport.Add(Login.constApp.strCardTypeL6Name + "�ǻ�Ա��ֵ����", 18);
            dreport.Add(Login.constApp.strCardTypeL6Name + "��ֵ����", 18);
            dreport.Add(Login.constApp.strCardTypeL6Name + "�����Ʒ���ѱ���", 18);
            dreport.Add(Login.constApp.strCardTypeL6Name + "������ϸ����", 18);
            dreport.Add(Login.constApp.strCardTypeL6Name + "������־����", 18);
            //dreport.Add(Login.constApp.strCardTypeL6Name + "�ͷ���Ա����", 18);

            dmenu.Add(Login.constApp.strCardTypeL6Name + "����", dreport);

            //Dictionary<string, int> dsys = new Dictionary<string, int>();
            //dsys.Add(Login.constApp.strCardTypeL6Name + "���Ź���", 15);
            //dsys.Add(Login.constApp.strCardTypeL6Name + "����Ա�����޸�", 15);
            //dsys.Add(Login.constApp.strCardTypeL6Name + "����Ա������", 15);
            //dsys.Add(Login.constApp.strCardTypeL6Name + "��Ա��������", 15);
            //dsys.Add(Login.constApp.strCardTypeL6Name + "Ȩ�޹���", 15);
            //dsys.Add(Login.constApp.strCardTypeL6Name + "��Ʒ����", 8);
            //dsys.Add(Login.constApp.strCardTypeL6Name + "��ֵ����", 8);

            //dsys.Add(Login.constApp.strCardTypeL6Name + "����ѡ��", 8);
            //dmenu.Add(Login.constApp.strCardTypeL6Name + "ϵͳ����", dsys);

            //Dictionary<string, int> dexit = new Dictionary<string, int>();
            //dexit.Add(Login.constApp.strCardTypeL6Name + "����", 19);
            //dexit.Add(Login.constApp.strCardTypeL6Name + "��ע��", 17);
            //dexit.Add(Login.constApp.strCardTypeL6Name + "ע��", 20);
            //dexit.Add(Login.constApp.strCardTypeL6Name + "�˳�", 20);

            //dmenu.Add(Login.constApp.strCardTypeL6Name + "ϵͳ�˳�", dexit);
            foreach (KeyValuePair<string, Dictionary<string, int>> kvpmenu in dmenu)
            {
                PopupMenuTool menu = new PopupMenuTool(kvpmenu.Key);
                this.ultraToolbarsManager1.Tools.Add(menu);
                menu.SharedProps.Caption = kvpmenu.Key;
                foreach (KeyValuePair<string, int> kvp in kvpmenu.Value)
                {
                    ButtonTool btntl = new ButtonTool(kvp.Key);
                    this.ultraToolbarsManager1.Tools.Add(btntl);
                    btntl.SharedProps.Caption = kvp.Key;
                    btntl.SharedProps.DisplayStyle = ToolDisplayStyle.ImageAndText;
                    btntl.SharedProps.AppearancesSmall.Appearance.Image = this.imageList1.Images[kvp.Value];
                    menu.Tools.Add(btntl);
                    if (kvpmenu.Key == Login.constApp.strCardTypeL6Name + "����") continue;
                    this.ultraToolbarsManager1.Toolbars[Login.constApp.strCardTypeL6Name + "������"].Tools.Add(btntl);
                }
                //this.ultraToolbarsManager1.Toolbars["���˵���"].Tools.Add(menu);
            }

        }
        
        private void MainForm_Resize(object sender, System.EventArgs e)
		{
			MDI_Set();
		}

		private void MainForm_Closed(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void ultraTabbedMdiManager1_RestoreTab(object sender, Infragistics.Win.UltraWinTabbedMdi.RestoreTabEventArgs e)
		{
			if (null != e.Tab&&null != e.Tab.Text)
			{
				
				this.ultraStatusBar1.Panels["func"].Text = "��ǰ���ܣ�"+e.Tab.Text;
			}
			else
			{
				this.ultraStatusBar1.Panels["func"].Text = "��ǰ���ܣ�"+e.Form.Text;
			}
		}

		private void ultraTabbedMdiManager1_TabActivated(object sender, Infragistics.Win.UltraWinTabbedMdi.MdiTabEventArgs e)
		{
			if (null != e.Tab&&null != e.Tab.Text)
			{
				
				this.ultraStatusBar1.Panels["func"].Text = "��ǰ���ܣ�"+e.Tab.Text;
			}
			else
			{
				this.ultraStatusBar1.Panels["func"].Text = "��ǰ���ܣ�"+e.Tab.Form.Text;
			}
		}
		
        private void productRegister()
		{
            MyPrincipal mp = Thread.CurrentPrincipal as MyPrincipal;
            MyIdentity mi = mp.Identity as MyIdentity;
            string strret = "";
            StringBuilder sbHardWareID = new StringBuilder(32);
            StringBuilder sbCardNo = new StringBuilder(9);
            if (CardCommon.CardRef.NT77.GetHardwareID(out sbHardWareID, out sbCardNo, out strret)) //throw new Exception(strret);
            {
                ynhrMemberManage.BusinessFacade.MemberBusiness.SecurityManage sm = new ynhrMemberManage.BusinessFacade.MemberBusiness.SecurityManage();
                sm.InsertNT77(sbHardWareID.ToString(), sbCardNo.ToString(), mi.oper.cnvcOperName);
            }
            if (!CardCommon.CardRef.NT77.Verify())
            {
                NoRegister();
                ((PopupMenuTool)this.ultraToolbarsManager1.Toolbars["���˵���"].Tools["ϵͳ�˳�"]).Tools["��ע��"].SharedProps.Caption = "δע��";
                MessageBox.Show("��δע�ᣬ��Щ���ܻ������ƣ�����ϵͳ����Ա��ϵ", "ϵͳ��ʾ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            //return;
            
		}

		private void NoRegister()
		{
            //this.ultraToolbarsManager1.Toolbars["������"].Tools["��Ƹ������"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["������"].Tools["��Ƹ����Ϣ�޸�"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["������"].Tools["��Ƹ����Ϣ��ѯ"].SharedProps.Visible = false;			
            //this.ultraToolbarsManager1.Toolbars["������"].Tools["չλԤ��"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["������"].Tools["չλԤ��"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["������"].Tools["չλǩ��"].SharedProps.Visible = false;
            ////this.ultraToolbarsManager1.Toolbars["������"].Tools["��ӷǻ�Ա��Ϣ"].SharedProps.Visible = false;
            ////this.ultraToolbarsManager1.Toolbars["������"].Tools["�ɷ�"].SharedProps.Visible = false;
            ////this.ultraToolbarsManager1.Toolbars["������"].Tools["�˷�"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["������"].Tools["СƱ�ش�"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["������"].Tools["��Ա��������"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["������"].Tools["ǩ������"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["������"].Tools["չλ��������"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["������"].Tools["Ԥ������"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["������"].Tools["ȡ��Ԥ������"].SharedProps.Visible = false;
            ////this.ultraToolbarsManager1.Toolbars["������"].Tools["�ɷѱ���"].SharedProps.Visible = false;
            string[] menus = new string[] { "��Ƹ������", "��Ƹ����Ϣ�޸�", "��Ƹ����Ϣ��ѯ", 
                Login.constApp.strCardTypeL8Name + "չλԤ��", Login.constApp.strCardTypeL8Name + "չλԤ��", Login.constApp.strCardTypeL8Name + "չλǩ��", 
                Login.constApp.strCardTypeL6Name + "չλԤ��", Login.constApp.strCardTypeL6Name + "չλԤ��", Login.constApp.strCardTypeL6Name + "չλǩ��", 
                "�ǻ�Ա¼��","�ɷ�","�˷�",
                "СƱ�ش�",Login.constApp.strCardTypeL8Name + "��Ա��������","չλ��������",Login.constApp.strCardTypeL8Name + "Ԥ������","ȡ��Ԥ������",Login.constApp.strCardTypeL8Name + "�ɷѱ���",
                Login.constApp.strCardTypeL6Name + "��Ա��������",Login.constApp.strCardTypeL6Name + "������ϸ����",
                "���Ź���","����Ա�����޸�","����Ա������",Login.constApp.strCardTypeL8Name + "��Ա��������",Login.constApp.strCardTypeL6Name + "��Ա��������", 
            "Ȩ�޹���","��Ʒ����","��ֵ����","ekey����","����ѡ��",
Login.constApp.strCardTypeL8Name + "��Ա��Ϣ¼��",Login.constApp.strCardTypeL8Name + "��ֵ",Login.constApp.strCardTypeL8Name + "��ʧ",Login.constApp.strCardTypeL8Name + "���",Login.constApp.strCardTypeL8Name + "����",Login.constApp.strCardTypeL8Name + "����",Login.constApp.strCardTypeL8Name + "����",
 Login.constApp.strCardTypeL8Name + "ɾ��δ������Ա", Login.constApp.strCardTypeL8Name + "��Ա�����޸�",Login.constApp.strCardTypeL8Name + "��Ա��ѳ����޸�",Login.constApp.strCardTypeL8Name + "����", Login.constApp.strCardTypeL8Name + "�ɷ�",Login.constApp.strCardTypeL8Name + "�˷�",
 Login.constApp.strCardTypeL8Name + "���ù���",Login.constApp.strCardTypeL6Name + "¼��",Login.constApp.strCardTypeL6Name + "����",Login.constApp.strCardTypeL6Name + "��ֵ",Login.constApp.strCardTypeL6Name + "��ʧ",Login.constApp.strCardTypeL6Name + "���", Login.constApp.strCardTypeL6Name + "����", 
Login.constApp.strCardTypeL6Name + "����", Login.constApp.strCardTypeL6Name + "�޿���Աɾ��",Login.constApp.strCardTypeL6Name + "��Ա�޸�", Login.constApp.strCardTypeL6Name + "�ǻ�Ա��ֵ",Login.constApp.strCardTypeL6Name + "��Ʒ����",Login.constApp.strCardTypeL6Name + "����","��Ƹ�����",Login.constApp.strCardTypeL6Name + "����",
                Login.constApp.strCardTypeL8Name + "����",Login.constApp.strCardTypeL8Name + "���ù���",Login.constApp.strCardTypeL8Name + "�����Ʒ����",
                "�ǻ�Ա����","�ǻ�Ա�޸�"
            };
            foreach (object tools in ultraToolbarsManager1.Tools.All)
            {
                if (tools is PopupMenuTool)
                {
                    PopupMenuTool pTools = tools as PopupMenuTool;
                    if (pTools.Key != "ϵͳ�˳�")
                    {
                        foreach (object tool2 in pTools.Tools.All)
                        {
                            ToolBase tb = tool2 as ToolBase;
                            if (!(tool2 is PopupMenuTool) && tb.Key != "����Ա�����޸�")
                            {
                                for (int i = 0; i < menus.Length; i++)
                                {
                                    if (tb.Key == menus[i]) tb.SharedProps.Visible = false;
                                }
                                //else
                                //    tb.SharedProps.Visible = mp.IsInRole(tb.Key);
                            }
                        }
                    }
                }
            }

		}

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && this.isUserClose)
            {
                if (this.Owner is Login)
                {
                    Login login = this.Owner as Login;
                    login.txtPWD.Text = "";
                    login.Show();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
#if !DEBUG
            MyPrincipal mp = Thread.CurrentPrincipal as MyPrincipal;
            MyIdentity mi = mp.Identity as MyIdentity;

            string strret = "";
            StringBuilder sbHardWareID = new StringBuilder(32);
            StringBuilder sbCardNo = new StringBuilder(9);
            if (CardCommon.CardRef.NT77.GetHardwareID(out sbHardWareID, out sbCardNo, out strret)) //throw new Exception(strret);
            {
                ynhrMemberManage.BusinessFacade.MemberBusiness.SecurityManage sm = new ynhrMemberManage.BusinessFacade.MemberBusiness.SecurityManage();
                sm.InsertNT77(sbHardWareID.ToString(), sbCardNo.ToString(), mi.oper.cnvcOperName);
            }
            if (!CardCommon.CardRef.NT77.Verify())
            {
//#if !DEBUG
                NoRegister();
//#endif
                ((PopupMenuTool)this.ultraToolbarsManager1.Toolbars["���˵���"].Tools["ϵͳ�˳�"]).Tools["��ע��"].SharedProps.Caption = "δע��";
                timer1.Stop();
                MessageBox.Show("��δע�ᣬ��Щ���ܻ������ƣ�����ϵͳ����Ա��ϵ", "ϵͳ��ʾ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

            }
#endif

            return;

        }
	}

}
