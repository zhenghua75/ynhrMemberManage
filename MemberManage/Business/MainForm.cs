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
            ultraStatusPanel1.Text = "操作员：";
            ultraStatusPanel1.ToolTipText = "操作员";
            ultraStatusPanel1.Width = 200;
            ultraStatusPanel2.Key = "Dept";
            ultraStatusPanel2.Text = "部门";
            ultraStatusPanel2.ToolTipText = "部门";
            ultraStatusPanel2.Width = 200;
            ultraStatusPanel3.DateTimeFormat = "yyyy年-MM月-dd日";
            ultraStatusPanel3.Key = "OperDate";
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel3.Text = "操作日期";
            ultraStatusPanel3.ToolTipText = "操作日期";
            ultraStatusPanel3.Width = 110;
            ultraStatusPanel4.DateTimeFormat = "hh时:mm分";
            ultraStatusPanel4.Key = "OperTime";
            ultraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel4.Text = "操作时间";
            ultraStatusPanel4.ToolTipText = "操作时间";
            ultraStatusPanel5.Key = "func";
            ultraStatusPanel5.Text = "当前功能：无";
            ultraStatusPanel5.ToolTipText = "当前功能";
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
            this.Text = "云南人才市场综合会员管理系统";
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
			//LogAdapter.WriteFeaturesException(new Exception("开始主窗体创建"));
			#region 汉化
			Infragistics.Shared.ResourceCustomizer rc= Infragistics.Win.UltraWinToolbars.Resources.Customizer;//Resources.Customizer;
			rc.SetCustomizedString("AddRemoveButtons","添加删除按钮(&A)");
			rc.SetCustomizedString("ResetToolbar","重置工具条(&R)");
			rc.SetCustomizedString("Customize","自定义...");
			rc.SetCustomizedString("CustomizeCategoryAllCommands","所有命令");
			rc.SetCustomizedString("CustomizeCategoryUnassigned","未分类");

			rc.SetCustomizedString("CustomizeDialog_AllProps","所有属性");
			rc.SetCustomizedString("CustomizeDialog_AlwaysShowFullMenus","总是显示所有菜单");
			rc.SetCustomizedString("CustomizeDialog_AlwaysShowFullMenus_AccessibleDescription","总是显示所有命令，包括最近未使用的");
			rc.SetCustomizedString("CustomizeDialog_BasicProps","基本属性");
			rc.SetCustomizedString("CustomizeDialog_CantModifyInheritedToolbarProperties","注意：不能修改选择的工具条属性");
			rc.SetCustomizedString("CustomizeDialog_CantModifyInheritedToolProperties","注意：不能修改选择的工具条属性");
			rc.SetCustomizedString("CustomizeDialog_Caption","标题");
			rc.SetCustomizedString("CustomizeDialog_CaptionCategoryKey","(&C)标题，目录，键");
			rc.SetCustomizedString("CustomizeDialog_CategoriesMidAmp","目录(&G)");
			rc.SetCustomizedString("CustomizeDialog_Category","目录");
			rc.SetCustomizedString("CustomizeDialog_CloseNoAmp","关闭");
			rc.SetCustomizedString("CustomizeDialog_Commands","命令");
			rc.SetCustomizedString("CustomizeDialog_CommandsEndAmp","命令(&D)");
			rc.SetCustomizedString("CustomizeDialog_CreateCopyOfTool","新建工具条副本(&C)");
			rc.SetCustomizedString("CustomizeDialog_CustomizeMain","自定义");
			rc.SetCustomizedString("CustomizeDialog_CustomizeMain_AccessibleDescription","自定义工具和工具条");
			rc.SetCustomizedString("CustomizeDialog_Delete","删除(&D)");
			rc.SetCustomizedString("CustomizeDialog_Delete_Tool_AccessibleDescription","删除选定工具");
			rc.SetCustomizedString("CustomizeDialog_Delete_Toolbar_AccessibleDescription","删除选定工具条");
			rc.SetCustomizedString("CustomizeDialog_DeleteTool","删除工具");
			rc.SetCustomizedString("CustomizeDialog_Description","描述");
			rc.SetCustomizedString("CustomizeDialog_Enabled","可用");
			rc.SetCustomizedString("CustomizeDialog_EnabledVisible","可用，可见");
			rc.SetCustomizedString("CustomizeDialog_FloatingToolbarFadeDelay","浮动工具条渐隐延迟");
			rc.SetCustomizedString("CustomizeDialog_FloatingToolbarFadeDelay_AccessibleDescription","鼠标离开浮动工具条它将渐隐");
			rc.SetCustomizedString("CustomizeDialog_Image","图片(&I)");
			rc.SetCustomizedString("CustomizeDialog_Import","导入");
			rc.SetCustomizedString("CustomizeDialog_ImportMenusFromForm","导入菜单");
			rc.SetCustomizedString("CustomizeDialog_ImportToolbarsFromForm","导入工具栏");
			rc.SetCustomizedString("CustomizeDialog_Key","键");
			rc.SetCustomizedString("CustomizeDialog_KeyboardBeginAmp","键盘(&K)");
			rc.SetCustomizedString("CustomizeDialog_KeyboardBeginAmp_AccessibleDescription","自定义键盘快捷键");
			rc.SetCustomizedString("CustomizeDialog_LargeIconsOnMenus","菜单大图标");
			rc.SetCustomizedString("CustomizeDialog_LargeIconsOnMenus_AccessibleDescription","显示菜单大图标");
			rc.SetCustomizedString("CustomizeDialog_LargeIconsOnToolbars","工具栏大图标");
			rc.SetCustomizedString("CustomizeDialog_LargeIconsOnToolbars_AccessibleDescription","显示工具栏大图标");
			rc.SetCustomizedString("CustomizeDialog_LargeImage","大图标");
			rc.SetCustomizedString("CustomizeDialog_ListFontNamesInTheirFont","字体名称列表");
			rc.SetCustomizedString("CustomizeDialog_ListFontNamesInTheirFont_AccessibleDescription","显示字体名称列表");
			rc.SetCustomizedString("CustomizeDialog_LoadSave","导入、保存");
			rc.SetCustomizedString("CustomizeDialog_MenuAnimations","菜单动画");
			rc.SetCustomizedString("CustomizeDialog_MenuAnimations_AccessibleDescription","菜单动画类型");
			rc.SetCustomizedString("CustomizeDialog_Milliseconds","毫秒");
			rc.SetCustomizedString("CustomizeDialog_ModifySelection","修改选择项");
			rc.SetCustomizedString("CustomizeDialog_ModifySelection_AccessibleDescription","修改选择的命令");
			rc.SetCustomizedString("CustomizeDialog_New","新建(&N)");
			rc.SetCustomizedString("CustomizeDialog_New_Toolbar_AccessibleDescription","新工具栏");
			rc.SetCustomizedString("CustomizeDialog_NewBeginAmp","新建");
			rc.SetCustomizedString("CustomizeDialog_NewTool","新建工具");
			rc.SetCustomizedString("CustomizeDialog_NewToolbar","新建工具栏");
			rc.SetCustomizedString("CustomizeDialog_Options","设置");
			rc.SetCustomizedString("CustomizeDialog_Other","其它");
			rc.SetCustomizedString("CustomizeDialog_PersonalizedMenusAndToolbars","个性化菜单工具栏");
			rc.SetCustomizedString("CustomizeDialog_PgTools","工具栏");
			rc.SetCustomizedString("CustomizeDialog_PopupMenuDesigner","菜单设计");
			rc.SetCustomizedString("CustomizeDialog_QuestionProperties","疑问属性");
			rc.SetCustomizedString("CustomizeDialog_RearrangeCommands","重排命令");
			rc.SetCustomizedString("CustomizeDialog_RearrangeCommands_AccessibleDescription","重排菜单、工具栏上命令");
			rc.SetCustomizedString("CustomizeDialog_Rename","重命名(&E)");
			rc.SetCustomizedString("CustomizeDialog_Rename_Toolbar_AccessibleDescription","重命名工具栏");
			rc.SetCustomizedString("CustomizeDialog_RenameAmp","重命名");
			rc.SetCustomizedString("CustomizeDialog_Reset_Toolbar_AccessibleDescription","重置工具栏");
			rc.SetCustomizedString("CustomizeDialog_ResetAmp","重置");
			rc.SetCustomizedString("CustomizeDialog_ResetMidAmp","重置");
			rc.SetCustomizedString("CustomizeDialog_ResetMyUsageData","重置数据");
			rc.SetCustomizedString("CustomizeDialog_ResetMyUsageData_AccessibleDescription","重置数据");
			rc.SetCustomizedString("CustomizeDialog_SelectedCommand","选择的命令");
			rc.SetCustomizedString("CustomizeDialog_Shortcut","快捷键");
			rc.SetCustomizedString("CustomizeDialog_ShowFullMenusAfterAShortDelay","显示所有菜单");
			rc.SetCustomizedString("CustomizeDialog_ShowFullMenusAfterAShortDelay_AccessibleDescription","显示所有菜单");
			rc.SetCustomizedString("CustomizeDialog_ShowScreenTipsOnToolbars","工具栏显示提示");
			rc.SetCustomizedString("CustomizeDialog_ShowScreenTipsOnToolbars_AccessibleDescription","工具栏显示提示");
			rc.SetCustomizedString("CustomizeDialog_ShowShortcutKeysInScreenTips","显示快捷键提示");
			rc.SetCustomizedString("CustomizeDialog_ShowShortcutKeysInScreenTips_AccessibleDescription","显示快捷键提示");
			rc.SetCustomizedString("CustomizeDialog_SmallImage","小图标");
			rc.SetCustomizedString("CustomizeDialog_SortCommands","字母排序命令");
			rc.SetCustomizedString("CustomizeDialog_SortToolsAlphabetically","字母排序工具栏");
			rc.SetCustomizedString("CustomizeDialog_Toolbars","工具栏");
			rc.SetCustomizedString("CustomizeDialog_ToolbarsList","工具栏列表");
			rc.SetCustomizedString("CustomizeDialog_Tools","工具");
			rc.SetCustomizedString("CustomizeDialog_ToolsByCategory","工具目录");
			rc.SetCustomizedString("CustomizeDialog_Visible","可见");

			Infragistics.Shared.ResourceCustomizer rc2= Infragistics.Win.UltraWinTabbedMdi.Resources.Customizer;//Resources.Customizer;
			rc2.SetCustomizedString("MenuItemCancel","取消");
			rc2.SetCustomizedString("MenuItemClose","关闭");
			rc2.SetCustomizedString("MenuItemMaximize","最大化");
			rc2.SetCustomizedString("MenuItemMoveToNextGroup","下一个");
			rc2.SetCustomizedString("MenuItemMoveToPreviousGroup","前一个");
			rc2.SetCustomizedString("MenuItemNewHorizontalGroup","水平分组");
			rc2.SetCustomizedString("MenuItemNewVerticalGroup","垂直分组");
			rc2.SetCustomizedString("UltraTabbedMdiManagerActionList_P_AllowHorizontalTabGroups_DisplayName","允许水平分组");
			rc2.SetCustomizedString("UltraTabbedMdiManagerActionList_P_AllowMaximize_DisplayName","允许最大化");
			rc2.SetCustomizedString("UltraTabbedMdiManagerActionList_P_AllowNestedTabGroups_DisplayName","允许嵌套分组");
			rc2.SetCustomizedString("UltraTabbedMdiManagerActionList_P_AllowVerticalTabGroups_DisplayName","允许垂直分组");
			rc2.SetCustomizedString("UltraTabbedMdiManagerActionList_P_TabGroupSettings_TextOrientation_DisplayName","文本方向");
			rc2.SetCustomizedString("UltraTabbedMdiManagerActionList_P_ViewStyle_DisplayName","样式");
			#endregion
			//LogAdapter.WriteFeaturesException(new Exception("主窗体汉化完成"));
			MDI_Set();
			//LogAdapter.WriteFeaturesException(new Exception("主窗体背景控制完成"));
			this.WindowState = FormWindowState.Maximized;
			//LogAdapter.WriteFeaturesException(new Exception("主菜单创建前")); 
            this.ultraToolbarsManager1.MdiMergeable = true;
            this.ultraToolbarsManager1.Tools.Clear();
            this.ultraToolbarsManager1.Toolbars.Clear();


            this.ultraToolbarsManager1.Toolbars.AddToolbarRange(new string[] { "工具栏", Login.constApp.strCardTypeL8Name + "工具栏", Login.constApp.strCardTypeL6Name + "工具栏", "主菜单条" });
            this.ultraToolbarsManager1.Toolbars["主菜单条"].IsMainMenuBar = true;
            this.ultraToolbarsManager1.Toolbars["主菜单条"].DockedRow = 0;            
            switch (Login.constApp.strCardType)
            {
                case "l6":
                    MainMenuBarL6();
                    MainMenuBar();
                    this.ultraToolbarsManager1.Toolbars["主菜单条"].Tools.InsertToolRange(0, new string[] { 
                "招聘会管理",Login.constApp.strCardTypeL6Name +"管理",Login.constApp.strCardTypeL6Name +"展位管理",Login.constApp.strCardTypeL6Name +"报表",
                "非会员管理",  "报表", "系统管理", "系统退出" });
                    this.ultraToolbarsManager1.Toolbars[Login.constApp.strCardTypeL8Name + "工具栏"].Visible = false;
                    break;
                case "l8":
                    MainMenuBarL8();
                    MainMenuBar();
                    this.ultraToolbarsManager1.Toolbars["主菜单条"].Tools.InsertToolRange(0, new string[] { 
                "招聘会管理",
                Login.constApp.strCardTypeL8Name +"管理",Login.constApp.strCardTypeL8Name +"费用管理",Login.constApp.strCardTypeL8Name +"展位管理",Login.constApp.strCardTypeL8Name +"报表",
                "非会员管理",  "报表", "系统管理", "系统退出" });
                    this.ultraToolbarsManager1.Toolbars[Login.constApp.strCardTypeL6Name + "工具栏"].Visible = false;
                    break;
                case "l6l8":
                    MainMenuBarL6();
                    MainMenuBarL8();
                    MainMenuBar();
                    this.ultraToolbarsManager1.Toolbars["主菜单条"].Tools.InsertToolRange(0, new string[] { 
                "招聘会管理",Login.constApp.strCardTypeL6Name +"管理",Login.constApp.strCardTypeL6Name +"展位管理",Login.constApp.strCardTypeL6Name +"报表",
                Login.constApp.strCardTypeL8Name +"管理",Login.constApp.strCardTypeL8Name +"费用管理",Login.constApp.strCardTypeL8Name +"展位管理",Login.constApp.strCardTypeL8Name +"报表",
                "非会员管理",  "报表", "系统管理", "系统退出" });

                    break;
                default:
                    break;
            }
            
			//LogAdapter.WriteFeaturesException(new Exception("主菜单准备完成"));
			#region 权限菜单
            MyPrincipal mp = Thread.CurrentPrincipal as MyPrincipal;
            MyIdentity mi = mp.Identity as MyIdentity;
            if (mi.dept.cnnDeptID != 0)
            {

                foreach (object tools in ultraToolbarsManager1.Tools.All)
                {
                    if (tools is PopupMenuTool)
                    {
                        PopupMenuTool pTools = tools as PopupMenuTool;
                        if (pTools.Key != "系统退出")
                        {
                            foreach (object tool2 in pTools.Tools.All)
                            {
                                ToolBase tb = tool2 as ToolBase;
                                if (!(tool2 is PopupMenuTool) && tb.Key != "操作员密码修改")
                                {
                                    if (tb.Key == "卡型选择" || tb.Key=="ekey管理") tb.SharedProps.Visible = false;
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
			//LogAdapter.WriteFeaturesException(new Exception("完成权限控制"));
            if (mi.dept.cnnDeptID == 0)
			{
				this.ultraStatusBar1.Panels["Dept"].Text = "所属部门：系统管理员";
			}
			else
			{
                Dept dept = Login.constApp.htDept[mi.dept.cnnDeptID] as Dept;
				this.ultraStatusBar1.Panels["Dept"].Text = "所属部门："+dept.cnvcDeptName;
			}

            this.ultraStatusBar1.Panels["OperName"].Text = "当前操作员：" + mi.oper.cnvcOperName;
#if !DEBUG
			productRegister();	
#endif
			//LogAdapter.WriteFeaturesException(new Exception("完成注册判断"));
			
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

				//标志       
				myGraphics.Clear(this.BackColor);
				//定位
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
						//this.ultraStatusBar1.Panels["func"].Text = "当前功能："+strTabText;
						return; 
					}
								
				} 
			} 
		}

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            //this.ultraStatusBar1.Panels["func"].Text = "当前功能："+e.Tool.Key;
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
                case "招聘会新设":
                    if (!MemberBusiness.JobAdd.IsShowing)
                    {
                        MemberBusiness.JobAdd job = new MemberBusiness.JobAdd();
                        MemberBusiness.JobAdd.IsShowing = true;
                        job.MdiParent = this;
                        job.Show();
                    }
                    else
                    {
                        setTab("招聘会新设");
                    }
                    break;
                case "招聘会信息查询":
                    if (!MemberBusiness.JobQuery.IsShowing)
                    {
                        MemberBusiness.JobQuery jobQuery = new MemberBusiness.JobQuery();
                        MemberBusiness.JobQuery.IsShowing = true;
                        jobQuery.MdiParent = this;
                        jobQuery.Show();
                    }
                    else
                    {
                        setTab("招聘会信息查询");
                    }
                    break;
                case "招聘会信息修改":
                    if (!MemberBusiness.JobModify.IsShowing)
                    {
                        MemberBusiness.JobModify jobModify = new MemberBusiness.JobModify();
                        MemberBusiness.JobModify.IsShowing = true;
                        jobModify.MdiParent = this;
                        jobModify.Show();
                    }
                    else
                    {
                        setTab("招聘会信息修改");
                    }
                    break;
                case "部门管理":
                    if (!NDeptManage.IsShowing)
                    {
                        NDeptManage deptManage = new NDeptManage();
                        NDeptManage.IsShowing = true;
                        deptManage.MdiParent = this;
                        deptManage.Show();
                    }
                    else
                    {
                        setTab("部门管理");
                    }
                    break;
                case "业务员管理"://zhh 20130313
                    if (!SalesManage.IsShowing)
                    {
                        SalesManage salesManage = new SalesManage();
                        SalesManage.IsShowing = true;
                        salesManage.MdiParent = this;
                        salesManage.Show();
                    }
                    else
                    {
                        setTab("业务员管理");
                    }
                    break;
                case "权限管理":
                    if (!MemberBusiness.RightManage.IsShowing)
                    {

                        MemberBusiness.RightManage rightManage = new MemberBusiness.RightManage();
                        MemberBusiness.RightManage.IsShowing = true;
                        rightManage.MdiParent = this;
                        rightManage.Show();
                    }
                    else
                    {
                        setTab("权限管理");
                    }
                    break;
                case "数据权限管理":
                    if (!MemberBusiness.DataRightManage.IsShowing)
                    {

                        MemberBusiness.DataRightManage datarightManage = new MemberBusiness.DataRightManage();
                        MemberBusiness.DataRightManage.IsShowing = true;
                        datarightManage.MdiParent = this;
                        datarightManage.Show();
                    }
                    else
                    {
                        setTab("数据权限管理");
                    }
                    break;
                case "操作员密码修改":
                    if (!OperPwdModify.IsShowing)
                    {
                        OperPwdModify operPwdModify = new OperPwdModify();
                        OperPwdModify.IsShowing = true;
                        operPwdModify.MdiParent = this;
                        operPwdModify.Show();
                    }
                    else
                    {
                        setTab("操作员密码修改");
                    }
                    break;
                case "签到报表":
                    if (!SignInReport.IsShowing)
                    {
                        SignInReport signInReport = new SignInReport();
                        SignInReport.IsShowing = true;
                        signInReport.MdiParent = this;
                        signInReport.Show();
                    }
                    else
                    {
                        setTab("签到报表");
                    }
                    break;
                case "展位调整报表":
                    if (!NoSignInReport.IsShowing)
                    {
                        NoSignInReport noSignInReport = new NoSignInReport();
                        NoSignInReport.IsShowing = true;
                        noSignInReport.MdiParent = this;
                        noSignInReport.Show();
                    }
                    else
                    {
                        setTab("展位调整报表");
                    }
                    break;
                case "预留报表":
                    if (!RemainReport.IsShowing)
                    {
                        RemainReport remainReport = new RemainReport();
                        RemainReport.IsShowing = true;
                        remainReport.MdiParent = this;
                        remainReport.Show();
                    }
                    else
                    {
                        setTab("预留报表");
                    }
                    break;
                case "取消预订报表":
                    if (!NoBookingReport.IsShowing)
                    {
                        NoBookingReport noBookingReport = new NoBookingReport();
                        NoBookingReport.IsShowing = true;
                        noBookingReport.MdiParent = this;
                        noBookingReport.Show();
                    }
                    else
                    {
                        setTab("取消预订报表");
                    }
                    break;
                case "小票重打":
                    if (!BillRepeat.IsShowing)
                    {
                        BillRepeat billRepeat = new BillRepeat();
                        BillRepeat.IsShowing = true;
                        billRepeat.MdiParent = this;
                        billRepeat.Show();
                    }
                    else
                    {
                        setTab("小票重打");
                    }
                    break;
                case "客服会员报表":
                    if (!CustomerServiceReport.IsShowing)
                    {
                        CustomerServiceReport productReport = new CustomerServiceReport();
                        CustomerServiceReport.IsShowing = true;
                        productReport.MdiParent = this;
                        productReport.Show();
                    }
                    else
                    {
                        setTab("客服会员报表");
                    }
                    break;
                case "操作员卡回收":
                    try
                    {
                        SecurityManage sm = new SecurityManage();
                        string strRet = sm.OperCardCallBack(mi.oper.cnvcOperName);
                        if (strRet == "")
                        {
                            MessageBox.Show("操作员卡回收成功", "操作员卡回收");
                        }
                        else
                        {
                            throw new BusinessException("操作员卡回收", strRet);
                        }
                    }
                    catch (BusinessException bex)
                    {
                        MessageBox.Show(this, bex.Message, bex.Type, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "退出":
                    Application.Exit();
                    break;
                case "注销":
                    this.isUserClose = true;
                    this.Close();
                    break;
                case "帮助":
                    string helpfile = Application.StartupPath + @"\Help.chm";
                    Help.ShowHelp(this, helpfile);
                    //Application.Exit();
                    break;
                //充值规则
                case "充值规则":
                    if (!InMoneySetting.IsShowing)
                    {
                        InMoneySetting ims = new InMoneySetting();
                        InMoneySetting.IsShowing = true;
                        ims.MdiParent = this;
                        ims.Show();
                    }
                    else
                    {
                        setTab("充值规则");
                    }
                    break;
                case "卡型选择":
                    CardType ct = new CardType();
                    ct.ShowDialog(this);
                    break;
                case "ekey管理":
                    MemberBusiness.ManageNT77 mnt = new MemberManage.MemberBusiness.ManageNT77();
                    mnt.ShowDialog(this);
                    break;
                case "非会员录入":
                    if (!MemberBusiness.FMemberCardProvide.IsShowing)
                    {
                        MemberBusiness.FMemberCardProvide fMemberCardProvide = new MemberBusiness.FMemberCardProvide();
                        MemberBusiness.FMemberCardProvide.IsShowing = true;
                        fMemberCardProvide.MdiParent = this;
                        fMemberCardProvide.Show();
                    }
                    else
                    {
                        setTab("非会员录入");
                    }
                    break;
                case "非会员修改":
                    if (!MemberBusiness.FMemberFileModify.IsShowing)
                    {
                        MemberBusiness.FMemberFileModify fmemberFileModify = new MemberBusiness.FMemberFileModify();
                        MemberBusiness.FMemberFileModify.IsShowing = true;
                        fmemberFileModify.MdiParent = this;
                        fmemberFileModify.Show();
                    }
                    else
                    {
                        setTab("非会员修改");
                    }
                    break;
                case "商品管理":
                    if (!ProductSetting.IsShowing)
                    {
                        ProductSetting ps = new ProductSetting();
                        ProductSetting.IsShowing = true;
                        ps.MdiParent = this;
                        ps.Show();
                    }
                    else
                    {
                        setTab("商品管理");
                    }
                    break;
                
                
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "会员参数设置")
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
                    setTab(Login.constApp.strCardTypeL8Name + "会员参数设置");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "会员参数设置")
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
                    setTab(Login.constApp.strCardTypeL6Name + "会员参数设置");
                }
            }
        }
        private void ToolClickL6(string strkey)
        {
            MyPrincipal mp = Thread.CurrentPrincipal as MyPrincipal;
            MyIdentity mi = mp.Identity as MyIdentity;
            if (strkey == Login.constApp.strCardTypeL6Name + "招聘会展位方案设置")
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
                    setTab(Login.constApp.strCardTypeL6Name + "招聘会展位方案设置");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "展位预订")
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
                    setTab(Login.constApp.strCardTypeL6Name + "展位预订");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "展位签到")
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
                    setTab(Login.constApp.strCardTypeL6Name + "展位签到");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "展位预留")
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
                    setTab(Login.constApp.strCardTypeL6Name + "展位预留");
                }
            }

            if (strkey == Login.constApp.strCardTypeL6Name + "会员档案报表")
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
                    setTab(Login.constApp.strCardTypeL6Name + "会员档案报表");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "非会员档案报表")
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
                    setTab(Login.constApp.strCardTypeL6Name + "非会员档案报表");
                }
            }

            if (strkey == Login.constApp.strCardTypeL6Name + "预订报表")
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
                    setTab(Login.constApp.strCardTypeL6Name + "预订报表");
                }
            }

            if (strkey == Login.constApp.strCardTypeL6Name + "非会员充值报表")
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
                    setTab(Login.constApp.strCardTypeL6Name + "非会员充值报表");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "操作日志报表")
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
                    setTab(Login.constApp.strCardTypeL6Name + "操作日志报表");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "产品消费")
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
                    setTab(Login.constApp.strCardTypeL6Name + "产品消费");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "服务产品消费报表")
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
                    setTab(Login.constApp.strCardTypeL6Name + "服务产品消费报表");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "消费明细报表")
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
                    setTab(Login.constApp.strCardTypeL6Name + "消费明细报表");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "充值报表")
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
                    setTab(Login.constApp.strCardTypeL6Name + "充值报表");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "录入")
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
                    setTab(Login.constApp.strCardTypeL6Name + "录入");

                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "挂失")
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
                    setTab(Login.constApp.strCardTypeL6Name + "挂失");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "解挂")
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
                    setTab(Login.constApp.strCardTypeL6Name + "解挂");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "充值")
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
                    setTab(Login.constApp.strCardTypeL6Name + "充值");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "补卡")
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
                    setTab(Login.constApp.strCardTypeL6Name + "补卡");
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "回收")
            {
                try
                {

                    ynhrMemberManage.BusinessFacade.MemberBusiness.MemberManageFacade memberManage = new ynhrMemberManage.BusinessFacade.MemberBusiness.MemberManageFacade();
                    Member member = new Member();
                    member.cnvcOperName = mi.oper.cnvcOperName;
                    member.cndOperDate = DateTime.Now;
                    memberManage.MemberCardCallBack(member);
                    MessageBox.Show("会员卡回收成功", "回收");
                }
                catch (BusinessException bex)
                {
                    MessageBox.Show(this, bex.Message, bex.Type, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "发卡")
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
                    setTab(Login.constApp.strCardTypeL6Name + "发卡");

                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "无卡会员删除")
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
                    setTab(Login.constApp.strCardTypeL6Name + "无卡会员删除");

                }
            }
            if (strkey == Login.constApp.strCardTypeL6Name + "会员修改")
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
                    setTab(Login.constApp.strCardTypeL6Name + "会员修改");
                }
            }

            if (strkey == Login.constApp.strCardTypeL6Name + "非会员充值")
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
                    setTab(Login.constApp.strCardTypeL6Name + "非会员充值");
                }
            }
        }
        private void ToolClickL8(string strkey)
        {
            MyPrincipal mp = Thread.CurrentPrincipal as MyPrincipal;
            MyIdentity mi = mp.Identity as MyIdentity;
            if (strkey == Login.constApp.strCardTypeL8Name + "会员信息录入")
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
                    setTab(Login.constApp.strCardTypeL8Name + "会员信息录入");

                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "挂失")
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
                    setTab(Login.constApp.strCardTypeL8Name + "挂失");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "解挂")
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
                    setTab(Login.constApp.strCardTypeL8Name + "解挂");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "充值")
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
                    setTab(Login.constApp.strCardTypeL8Name + "充值");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "补卡")
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
                    setTab(Login.constApp.strCardTypeL8Name + "补卡");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "回收")
            {
                try
                {
                    MemberManageFacade memberManage = new MemberManageFacade();
                    Member member = new Member();
                    member.cnvcOperName = mi.oper.cnvcOperName;
                    member.cndOperDate = DateTime.Now;
                    memberManage.MemberCardCallBack(member);
                    MessageBox.Show("会员卡回收成功", "回收");
                }
                catch (BusinessException bex)
                {
                    MessageBox.Show(this, bex.Message, bex.Type, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "发卡")
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
                    setTab(Login.constApp.strCardTypeL8Name + "发卡");

                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "删除未发卡会员")
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
                    setTab(Login.constApp.strCardTypeL8Name + "删除未发卡会员");

                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "会员档案报表")
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
                    setTab(Login.constApp.strCardTypeL8Name + "会员档案报表");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "非会员档案报表")
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
                    setTab(Login.constApp.strCardTypeL8Name + "非会员档案报表");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "会员档案修改")
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
                    setTab(Login.constApp.strCardTypeL8Name + "会员档案修改");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "会员免费场次修改")
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
                    setTab(Login.constApp.strCardTypeL8Name + "会员免费场次修改");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "非会员档案修改")
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
                    setTab(Login.constApp.strCardTypeL8Name + "非会员档案修改");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "招聘会展位方案设置")
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
                    setTab(Login.constApp.strCardTypeL8Name + "招聘会展位方案设置");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "展位预订")
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
                    setTab(Login.constApp.strCardTypeL8Name + "展位预订");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "展位签到")
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
                    setTab(Login.constApp.strCardTypeL8Name + "展位签到");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "展位预留")
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
                    setTab(Login.constApp.strCardTypeL8Name + "展位预留");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "缴费")
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
                    setTab(Login.constApp.strCardTypeL8Name + "缴费");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "退费")
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
                    setTab(Login.constApp.strCardTypeL8Name + "退费");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "预订报表")
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
                    setTab(Login.constApp.strCardTypeL8Name + "预订报表");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "缴费报表")
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
                    setTab(Login.constApp.strCardTypeL8Name + "缴费报表");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "操作日志报表")
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
                    setTab(Login.constApp.strCardTypeL8Name + "操作日志报表");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "服务产品消费")
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
                    setTab(Login.constApp.strCardTypeL8Name + "服务产品消费");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "服务产品消费报表")
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
                    setTab(Login.constApp.strCardTypeL8Name + "服务产品消费报表");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "服务产品充值缴费报表")
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
                    setTab(Login.constApp.strCardTypeL8Name + "服务产品充值缴费报表");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "收入报表")
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
                    setTab(Login.constApp.strCardTypeL8Name + "收入报表");
                }
            }
            if (strkey == Login.constApp.strCardTypeL8Name + "充值报表")
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
                    setTab(Login.constApp.strCardTypeL8Name + "充值报表");
                }
            }
        }

        private void MainMenuBar()
        {
            Dictionary<string, Dictionary<string, int>> dmenu = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> dcard = new Dictionary<string, int>();           
            dcard.Add("非会员录入", 16);
            dcard.Add("非会员修改", 16);

            dmenu.Add("非会员管理", dcard);

            Dictionary<string, int> djob = new Dictionary<string, int>();
            djob.Add("招聘会新设", 9);
            djob.Add("招聘会信息修改", 10);
            djob.Add("招聘会信息查询", 6);
            //djob.Add("小票重打", 18);
            dmenu.Add("招聘会管理", djob);

            Dictionary<string, int> dreport = new Dictionary<string, int>();
            dreport.Add("签到报表", 18);
            dreport.Add("展位调整报表", 18);
            dreport.Add("预留报表", 18);
            dreport.Add("取消预订报表", 18);
            dreport.Add("客服会员报表", 18);
            dreport.Add("小票重打", 18);
            dmenu.Add("报表", dreport);

            Dictionary<string, int> dsys = new Dictionary<string, int>();
            dsys.Add("部门管理", 15);
            dsys.Add("业务员管理", 15);//zhh 20130313
            dsys.Add("操作员密码修改", 15);
            dsys.Add("操作员卡回收", 15);
            //dsys.Add(Login.constApp.strCardTypeL8Name + "会员参数设置", 15);
            dsys.Add(Login.constApp.strCardTypeL6Name + "会员参数设置", 15);
            dsys.Add("权限管理", 15);
            dsys.Add("数据权限管理", 15);
            dsys.Add("商品管理", 8);
            dsys.Add("充值规则", 8);

            dsys.Add("ekey管理",8);
            dsys.Add("卡型选择", 8);
            dmenu.Add("系统管理", dsys);

            Dictionary<string, int> dexit = new Dictionary<string, int>();
            dexit.Add("帮助", 19);
            dexit.Add("已注册", 17);
            dexit.Add("注销", 20);
            dexit.Add("退出", 20);

            dmenu.Add("系统退出", dexit);

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
                    if (kvpmenu.Key == "报表") continue;
                    if (kvpmenu.Key == "系统退出") continue;
                    if (kvpmenu.Key == "系统管理") continue;
                    this.ultraToolbarsManager1.Toolbars["工具栏"].Tools.Add(btntl);
                }                
            }
            
        }
		private void MainMenuBarL8()
		{

            Dictionary<string, Dictionary<string, int>> dmenu = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> dcard = new Dictionary<string, int>();
            dcard.Add(Login.constApp.strCardTypeL8Name + "会员信息录入", 0);
            dcard.Add(Login.constApp.strCardTypeL8Name + "充值", 1);
            dcard.Add(Login.constApp.strCardTypeL8Name + "挂失", 2);
            dcard.Add(Login.constApp.strCardTypeL8Name + "解挂", 3);
            dcard.Add(Login.constApp.strCardTypeL8Name + "补卡", 4);
            dcard.Add(Login.constApp.strCardTypeL8Name + "回收", 5);
            //dmenu.Add(Login.constApp.strCardTypeL8Name + "会员卡", dcard);

            //Dictionary<string, int> dmem = new Dictionary<string, int>();
            dcard.Add(Login.constApp.strCardTypeL8Name + "发卡", 0);
            dcard.Add(Login.constApp.strCardTypeL8Name + "删除未发卡会员", 0);
            dcard.Add(Login.constApp.strCardTypeL8Name + "会员档案修改", 7);
            dcard.Add(Login.constApp.strCardTypeL8Name + "会员免费场次修改", 7);
            //dcard.Add(Login.constApp.strCardTypeL8Name + "添加非会员信息", 16);
            //dcard.Add(Login.constApp.strCardTypeL8Name + "非会员档案修改", 16);

            //Dictionary<string,int> dindex = new Dictionary<string,int>();            
            dmenu.Add(Login.constApp.strCardTypeL8Name + "管理", dcard);
            
            //Dictionary<string, int> djob = new Dictionary<string, int>();
            //djob.Add(Login.constApp.strCardTypeL8Name + "招聘会新设", 9);
            //djob.Add(Login.constApp.strCardTypeL8Name + "招聘会信息修改", 10);
            //djob.Add(Login.constApp.strCardTypeL8Name + "招聘会信息查询", 6);

            //dmenu.Add(Login.constApp.strCardTypeL8Name + "招聘会管理", djob);

            Dictionary<string, int> dfee = new Dictionary<string, int>();
            dfee.Add(Login.constApp.strCardTypeL8Name + "缴费", 21);
            dfee.Add(Login.constApp.strCardTypeL8Name + "退费", 21);
            //dfee.Add(Login.constApp.strCardTypeL8Name + "小票重打", 18);
            dmenu.Add(Login.constApp.strCardTypeL8Name + "费用管理", dfee);

            Dictionary<string, int> dshow = new Dictionary<string, int>();
            dshow.Add(Login.constApp.strCardTypeL8Name + "招聘会展位方案设置", 8);
            dshow.Add(Login.constApp.strCardTypeL8Name + "展位预订", 12);
            dshow.Add(Login.constApp.strCardTypeL8Name + "展位预留", 13);
            dshow.Add(Login.constApp.strCardTypeL8Name + "展位签到", 14);
            dshow.Add(Login.constApp.strCardTypeL8Name + "服务产品消费", 14);

            dmenu.Add(Login.constApp.strCardTypeL8Name + "展位管理", dshow);

            Dictionary<string, int> dreport = new Dictionary<string, int>();
            dreport.Add(Login.constApp.strCardTypeL8Name + "会员档案报表", 18);
            dreport.Add(Login.constApp.strCardTypeL8Name + "非会员档案报表", 18);
            //dreport.Add(Login.constApp.strCardTypeL8Name + "签到报表", 18);
            //dreport.Add(Login.constApp.strCardTypeL8Name + "展位调整报表", 18);
            dreport.Add(Login.constApp.strCardTypeL8Name + "预订报表", 18);
            //dreport.Add(Login.constApp.strCardTypeL8Name + "预留报表", 18);
            //dreport.Add(Login.constApp.strCardTypeL8Name + "取消预订报表", 18);
            dreport.Add(Login.constApp.strCardTypeL8Name + "缴费报表", 18);
            dreport.Add(Login.constApp.strCardTypeL8Name + "充值报表", 18);
            dreport.Add(Login.constApp.strCardTypeL8Name + "服务产品消费报表", 18);
            dreport.Add(Login.constApp.strCardTypeL8Name + "服务产品充值缴费报表", 18);
            dreport.Add(Login.constApp.strCardTypeL8Name + "收入报表", 18);
            dreport.Add(Login.constApp.strCardTypeL8Name + "操作日志报表", 18);
            //dreport.Add(Login.constApp.strCardTypeL8Name + "客服会员报表", 18);
            dmenu.Add(Login.constApp.strCardTypeL8Name + "报表", dreport);

            //Dictionary<string, int> dsys = new Dictionary<string, int>();
            //dsys.Add(Login.constApp.strCardTypeL8Name + "部门管理", 15);
            //dsys.Add(Login.constApp.strCardTypeL8Name + "操作员密码修改", 15);
            //dsys.Add(Login.constApp.strCardTypeL8Name + "操作员卡回收", 15);
            //dsys.Add(Login.constApp.strCardTypeL8Name + "会员参数设置", 15);
            //dsys.Add(Login.constApp.strCardTypeL8Name + "权限管理", 15);
            //dsys.Add(Login.constApp.strCardTypeL8Name + "卡型选择", 8);
            //dmenu.Add(Login.constApp.strCardTypeL8Name + "系统管理", dsys);

            //Dictionary<string, int> dexit = new Dictionary<string, int>();
            //dexit.Add(Login.constApp.strCardTypeL8Name + "帮助", 19);
            //dexit.Add(Login.constApp.strCardTypeL8Name + "产品注册", 17);
            //dexit.Add(Login.constApp.strCardTypeL8Name + "注销", 20);
            //dexit.Add(Login.constApp.strCardTypeL8Name + "退出", 20);

            //dmenu.Add(Login.constApp.strCardTypeL8Name + "系统退出", dexit);
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
                    if (kvpmenu.Key == Login.constApp.strCardTypeL8Name + "报表") continue;
                    this.ultraToolbarsManager1.Toolbars[Login.constApp.strCardTypeL8Name + "工具栏"].Tools.Add(btntl);
                }
                //this.ultraToolbarsManager1.Toolbars["主菜单条"].Tools.Add(menu);
            }
		}
        private void MainMenuBarL6()
        {
            
            Dictionary<string, Dictionary<string, int>> dmenu = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> dcard = new Dictionary<string, int>();
            dcard.Add(Login.constApp.strCardTypeL6Name + "录入", 0);
            dcard.Add(Login.constApp.strCardTypeL6Name + "发卡", 0);
            dcard.Add(Login.constApp.strCardTypeL6Name + "充值", 1);
            dcard.Add(Login.constApp.strCardTypeL6Name + "挂失", 2);
            dcard.Add(Login.constApp.strCardTypeL6Name + "解挂", 3);
            dcard.Add(Login.constApp.strCardTypeL6Name + "补卡", 4);
            dcard.Add(Login.constApp.strCardTypeL6Name + "回收", 5);
            dcard.Add(Login.constApp.strCardTypeL6Name + "无卡会员删除", 0);
            dcard.Add(Login.constApp.strCardTypeL6Name + "会员修改", 7);
            //dcard.Add(Login.constApp.strCardTypeL6Name + "非会员录入", 16);
            //dcard.Add(Login.constApp.strCardTypeL6Name + "非会员修改", 7);
            dcard.Add(Login.constApp.strCardTypeL6Name + "非会员充值", 1);
            dcard.Add(Login.constApp.strCardTypeL6Name + "产品消费", 22);
            dmenu.Add(Login.constApp.strCardTypeL6Name + "管理", dcard);

            //Dictionary<string, int> dfee = new Dictionary<string, int>();
            //dfee.Add(Login.constApp.strCardTypeL6Name + "产品消费", 22);
            //dfee.Add(Login.constApp.strCardTypeL6Name + "小票重打", 18);

            //dmenu.Add(Login.constApp.strCardTypeL6Name + "消费管理", dfee);

            //Dictionary<string, int> djob = new Dictionary<string, int>();
            //djob.Add(Login.constApp.strCardTypeL6Name + "招聘会新设", 9);
            //djob.Add(Login.constApp.strCardTypeL6Name + "招聘会信息修改", 10);
            //djob.Add(Login.constApp.strCardTypeL6Name + "招聘会信息查询", 6);

            //dmenu.Add(Login.constApp.strCardTypeL6Name + "招聘会管理", djob);

            Dictionary<string, int> dshow = new Dictionary<string, int>();
            dshow.Add(Login.constApp.strCardTypeL6Name + "招聘会展位方案设置", 8);
            dshow.Add(Login.constApp.strCardTypeL6Name + "展位预订", 12);
            dshow.Add(Login.constApp.strCardTypeL6Name + "展位预留", 13);
            dshow.Add(Login.constApp.strCardTypeL6Name + "展位签到", 14);

            dmenu.Add(Login.constApp.strCardTypeL6Name + "展位管理", dshow);

            Dictionary<string, int> dreport = new Dictionary<string, int>();
            dreport.Add(Login.constApp.strCardTypeL6Name + "会员档案报表", 18);
            dreport.Add(Login.constApp.strCardTypeL6Name + "非会员档案报表", 18);
            //dreport.Add(Login.constApp.strCardTypeL6Name + "签到报表", 18);
            //dreport.Add(Login.constApp.strCardTypeL6Name + "展位调整报表", 18);
            dreport.Add(Login.constApp.strCardTypeL6Name + "预订报表", 18);
            //dreport.Add(Login.constApp.strCardTypeL6Name + "预留报表", 18);
            //dreport.Add(Login.constApp.strCardTypeL6Name + "取消预订报表", 18);
            dreport.Add(Login.constApp.strCardTypeL6Name + "非会员充值报表", 18);
            dreport.Add(Login.constApp.strCardTypeL6Name + "充值报表", 18);
            dreport.Add(Login.constApp.strCardTypeL6Name + "服务产品消费报表", 18);
            dreport.Add(Login.constApp.strCardTypeL6Name + "消费明细报表", 18);
            dreport.Add(Login.constApp.strCardTypeL6Name + "操作日志报表", 18);
            //dreport.Add(Login.constApp.strCardTypeL6Name + "客服会员报表", 18);

            dmenu.Add(Login.constApp.strCardTypeL6Name + "报表", dreport);

            //Dictionary<string, int> dsys = new Dictionary<string, int>();
            //dsys.Add(Login.constApp.strCardTypeL6Name + "部门管理", 15);
            //dsys.Add(Login.constApp.strCardTypeL6Name + "操作员密码修改", 15);
            //dsys.Add(Login.constApp.strCardTypeL6Name + "操作员卡回收", 15);
            //dsys.Add(Login.constApp.strCardTypeL6Name + "会员参数设置", 15);
            //dsys.Add(Login.constApp.strCardTypeL6Name + "权限管理", 15);
            //dsys.Add(Login.constApp.strCardTypeL6Name + "商品管理", 8);
            //dsys.Add(Login.constApp.strCardTypeL6Name + "充值规则", 8);

            //dsys.Add(Login.constApp.strCardTypeL6Name + "卡型选择", 8);
            //dmenu.Add(Login.constApp.strCardTypeL6Name + "系统管理", dsys);

            //Dictionary<string, int> dexit = new Dictionary<string, int>();
            //dexit.Add(Login.constApp.strCardTypeL6Name + "帮助", 19);
            //dexit.Add(Login.constApp.strCardTypeL6Name + "已注册", 17);
            //dexit.Add(Login.constApp.strCardTypeL6Name + "注销", 20);
            //dexit.Add(Login.constApp.strCardTypeL6Name + "退出", 20);

            //dmenu.Add(Login.constApp.strCardTypeL6Name + "系统退出", dexit);
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
                    if (kvpmenu.Key == Login.constApp.strCardTypeL6Name + "报表") continue;
                    this.ultraToolbarsManager1.Toolbars[Login.constApp.strCardTypeL6Name + "工具栏"].Tools.Add(btntl);
                }
                //this.ultraToolbarsManager1.Toolbars["主菜单条"].Tools.Add(menu);
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
				
				this.ultraStatusBar1.Panels["func"].Text = "当前功能："+e.Tab.Text;
			}
			else
			{
				this.ultraStatusBar1.Panels["func"].Text = "当前功能："+e.Form.Text;
			}
		}

		private void ultraTabbedMdiManager1_TabActivated(object sender, Infragistics.Win.UltraWinTabbedMdi.MdiTabEventArgs e)
		{
			if (null != e.Tab&&null != e.Tab.Text)
			{
				
				this.ultraStatusBar1.Panels["func"].Text = "当前功能："+e.Tab.Text;
			}
			else
			{
				this.ultraStatusBar1.Panels["func"].Text = "当前功能："+e.Tab.Form.Text;
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
                ((PopupMenuTool)this.ultraToolbarsManager1.Toolbars["主菜单条"].Tools["系统退出"]).Tools["已注册"].SharedProps.Caption = "未注册";
                MessageBox.Show("尚未注册，有些功能会受限制！请与系统管理员联系", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            //return;
            
		}

		private void NoRegister()
		{
            //this.ultraToolbarsManager1.Toolbars["工具栏"].Tools["招聘会新设"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["工具栏"].Tools["招聘会信息修改"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["工具栏"].Tools["招聘会信息查询"].SharedProps.Visible = false;			
            //this.ultraToolbarsManager1.Toolbars["工具栏"].Tools["展位预订"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["工具栏"].Tools["展位预留"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["工具栏"].Tools["展位签到"].SharedProps.Visible = false;
            ////this.ultraToolbarsManager1.Toolbars["工具栏"].Tools["添加非会员信息"].SharedProps.Visible = false;
            ////this.ultraToolbarsManager1.Toolbars["工具栏"].Tools["缴费"].SharedProps.Visible = false;
            ////this.ultraToolbarsManager1.Toolbars["工具栏"].Tools["退费"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["工具栏"].Tools["小票重打"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["工具栏"].Tools["会员档案报表"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["工具栏"].Tools["签到报表"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["工具栏"].Tools["展位调整报表"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["工具栏"].Tools["预订报表"].SharedProps.Visible = false;
            //this.ultraToolbarsManager1.Toolbars["工具栏"].Tools["取消预订报表"].SharedProps.Visible = false;
            ////this.ultraToolbarsManager1.Toolbars["工具栏"].Tools["缴费报表"].SharedProps.Visible = false;
            string[] menus = new string[] { "招聘会新设", "招聘会信息修改", "招聘会信息查询", 
                Login.constApp.strCardTypeL8Name + "展位预订", Login.constApp.strCardTypeL8Name + "展位预留", Login.constApp.strCardTypeL8Name + "展位签到", 
                Login.constApp.strCardTypeL6Name + "展位预订", Login.constApp.strCardTypeL6Name + "展位预留", Login.constApp.strCardTypeL6Name + "展位签到", 
                "非会员录入","缴费","退费",
                "小票重打",Login.constApp.strCardTypeL8Name + "会员档案报表","展位调整报表",Login.constApp.strCardTypeL8Name + "预订报表","取消预订报表",Login.constApp.strCardTypeL8Name + "缴费报表",
                Login.constApp.strCardTypeL6Name + "会员档案报表",Login.constApp.strCardTypeL6Name + "消费明细报表",
                "部门管理","操作员密码修改","操作员卡回收",Login.constApp.strCardTypeL8Name + "会员参数设置",Login.constApp.strCardTypeL6Name + "会员参数设置", 
            "权限管理","商品管理","充值规则","ekey管理","卡型选择",
Login.constApp.strCardTypeL8Name + "会员信息录入",Login.constApp.strCardTypeL8Name + "充值",Login.constApp.strCardTypeL8Name + "挂失",Login.constApp.strCardTypeL8Name + "解挂",Login.constApp.strCardTypeL8Name + "补卡",Login.constApp.strCardTypeL8Name + "回收",Login.constApp.strCardTypeL8Name + "发卡",
 Login.constApp.strCardTypeL8Name + "删除未发卡会员", Login.constApp.strCardTypeL8Name + "会员档案修改",Login.constApp.strCardTypeL8Name + "会员免费场次修改",Login.constApp.strCardTypeL8Name + "管理", Login.constApp.strCardTypeL8Name + "缴费",Login.constApp.strCardTypeL8Name + "退费",
 Login.constApp.strCardTypeL8Name + "费用管理",Login.constApp.strCardTypeL6Name + "录入",Login.constApp.strCardTypeL6Name + "发卡",Login.constApp.strCardTypeL6Name + "充值",Login.constApp.strCardTypeL6Name + "挂失",Login.constApp.strCardTypeL6Name + "解挂", Login.constApp.strCardTypeL6Name + "补卡", 
Login.constApp.strCardTypeL6Name + "回收", Login.constApp.strCardTypeL6Name + "无卡会员删除",Login.constApp.strCardTypeL6Name + "会员修改", Login.constApp.strCardTypeL6Name + "非会员充值",Login.constApp.strCardTypeL6Name + "产品消费",Login.constApp.strCardTypeL6Name + "管理","招聘会管理",Login.constApp.strCardTypeL6Name + "管理",
                Login.constApp.strCardTypeL8Name + "管理",Login.constApp.strCardTypeL8Name + "费用管理",Login.constApp.strCardTypeL8Name + "服务产品消费",
                "非会员管理","非会员修改"
            };
            foreach (object tools in ultraToolbarsManager1.Tools.All)
            {
                if (tools is PopupMenuTool)
                {
                    PopupMenuTool pTools = tools as PopupMenuTool;
                    if (pTools.Key != "系统退出")
                    {
                        foreach (object tool2 in pTools.Tools.All)
                        {
                            ToolBase tb = tool2 as ToolBase;
                            if (!(tool2 is PopupMenuTool) && tb.Key != "操作员密码修改")
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
                ((PopupMenuTool)this.ultraToolbarsManager1.Toolbars["主菜单条"].Tools["系统退出"]).Tools["已注册"].SharedProps.Caption = "未注册";
                timer1.Stop();
                MessageBox.Show("尚未注册，有些功能会受限制！请与系统管理员联系", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

            }
#endif

            return;

        }
	}

}
