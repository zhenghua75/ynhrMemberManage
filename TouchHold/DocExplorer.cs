using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
namespace TouchHold
{
	/// <summary>
	/// DocExplorer 的摘要说明。
	/// </summary>
	public class DocExplorer : System.Windows.Forms.Form
	{
		private AxSHDocVw.AxWebBrowser axWebBrowser1;
		private System.ComponentModel.IContainer components;
		public string strPath = "";
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private Infragistics.Win.UltraWinDock.UltraDockManager ultraDockManager1;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _DocExplorerUnpinnedTabAreaLeft;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _DocExplorerUnpinnedTabAreaRight;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _DocExplorerUnpinnedTabAreaTop;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _DocExplorerUnpinnedTabAreaBottom;
		private Infragistics.Win.UltraWinDock.AutoHideControl _DocExplorerAutoHideControl;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
		public string strName = "";
		public DocExplorer()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            //ApplicationIdleTimer idle = new ApplicationIdleTimer();
            //System.Windows.Forms.Application.AddMessageFilter(idle);
            //idle.ApplicationIdle += new ApplicationIdleTimer.ApplicationIdleEventHandler(this.App_Idle);
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocExplorer));
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedBottom, new System.Guid("01e093ff-df4d-4770-a1dd-3aece8ce7706"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("8d224fea-b240-43cf-95bb-5673db4e581c"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("01e093ff-df4d-4770-a1dd-3aece8ce7706"), -1);
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.axWebBrowser1 = new AxSHDocVw.AxWebBrowser();
            this.ultraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._DocExplorerUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._DocExplorerUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._DocExplorerUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._DocExplorerUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._DocExplorerAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            ((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).BeginInit();
            this._DocExplorerAutoHideControl.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraButton1
            // 
            this.ultraButton1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraButton1.Location = new System.Drawing.Point(0, 0);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(648, 74);
            this.ultraButton1.TabIndex = 2;
            this.ultraButton1.Text = "返回";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // axWebBrowser1
            // 
            this.axWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWebBrowser1.Enabled = true;
            this.axWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.axWebBrowser1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebBrowser1.OcxState")));
            this.axWebBrowser1.Size = new System.Drawing.Size(648, 382);
            this.axWebBrowser1.TabIndex = 0;
            this.axWebBrowser1.NavigateComplete2 += new AxSHDocVw.DWebBrowserEvents2_NavigateComplete2EventHandler(this.axWebBrowser1_NavigateComplete2);
            // 
            // ultraDockManager1
            // 
            dockableControlPane1.Control = this.ultraButton1;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(-1, 74);
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(416, 104, 128, 37);
            dockableControlPane1.Pinned = false;
            dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Settings.AllowDockAsTab = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Settings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Settings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Settings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Settings.AllowDockTop = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Settings.AllowDragging = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Settings.AllowMaximize = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Settings.AllowMinimize = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Settings.AllowResize = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Settings.ShowCaption = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.TextTab = "返回";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(648, 48);
            dockAreaPane1.TextTab = "";
            this.ultraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.ultraDockManager1.HostControl = this;
            // 
            // _DocExplorerUnpinnedTabAreaLeft
            // 
            this._DocExplorerUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._DocExplorerUnpinnedTabAreaLeft.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._DocExplorerUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._DocExplorerUnpinnedTabAreaLeft.Name = "_DocExplorerUnpinnedTabAreaLeft";
            this._DocExplorerUnpinnedTabAreaLeft.Owner = this.ultraDockManager1;
            this._DocExplorerUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 438);
            this._DocExplorerUnpinnedTabAreaLeft.TabIndex = 4;
            // 
            // _DocExplorerUnpinnedTabAreaRight
            // 
            this._DocExplorerUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._DocExplorerUnpinnedTabAreaRight.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._DocExplorerUnpinnedTabAreaRight.Location = new System.Drawing.Point(648, 0);
            this._DocExplorerUnpinnedTabAreaRight.Name = "_DocExplorerUnpinnedTabAreaRight";
            this._DocExplorerUnpinnedTabAreaRight.Owner = this.ultraDockManager1;
            this._DocExplorerUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 438);
            this._DocExplorerUnpinnedTabAreaRight.TabIndex = 5;
            // 
            // _DocExplorerUnpinnedTabAreaTop
            // 
            this._DocExplorerUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._DocExplorerUnpinnedTabAreaTop.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._DocExplorerUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._DocExplorerUnpinnedTabAreaTop.Name = "_DocExplorerUnpinnedTabAreaTop";
            this._DocExplorerUnpinnedTabAreaTop.Owner = this.ultraDockManager1;
            this._DocExplorerUnpinnedTabAreaTop.Size = new System.Drawing.Size(648, 0);
            this._DocExplorerUnpinnedTabAreaTop.TabIndex = 6;
            // 
            // _DocExplorerUnpinnedTabAreaBottom
            // 
            this._DocExplorerUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._DocExplorerUnpinnedTabAreaBottom.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._DocExplorerUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 382);
            this._DocExplorerUnpinnedTabAreaBottom.Name = "_DocExplorerUnpinnedTabAreaBottom";
            this._DocExplorerUnpinnedTabAreaBottom.Owner = this.ultraDockManager1;
            this._DocExplorerUnpinnedTabAreaBottom.Size = new System.Drawing.Size(648, 56);
            this._DocExplorerUnpinnedTabAreaBottom.TabIndex = 7;
            // 
            // _DocExplorerAutoHideControl
            // 
            this._DocExplorerAutoHideControl.Controls.Add(this.dockableWindow1);
            this._DocExplorerAutoHideControl.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._DocExplorerAutoHideControl.Location = new System.Drawing.Point(0, 363);
            this._DocExplorerAutoHideControl.Name = "_DocExplorerAutoHideControl";
            this._DocExplorerAutoHideControl.Owner = this.ultraDockManager1;
            this._DocExplorerAutoHideControl.Size = new System.Drawing.Size(648, 19);
            this._DocExplorerAutoHideControl.TabIndex = 8;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.ultraButton1);
            this.dockableWindow1.Location = new System.Drawing.Point(-10000, 5);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.ultraDockManager1;
            this.dockableWindow1.Size = new System.Drawing.Size(648, 74);
            this.dockableWindow1.TabIndex = 10;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowDockingArea1.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.windowDockingArea1.Location = new System.Drawing.Point(0, 364);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.ultraDockManager1;
            this.windowDockingArea1.Size = new System.Drawing.Size(648, 53);
            this.windowDockingArea1.TabIndex = 9;
            // 
            // DocExplorer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(21, 46);
            this.ClientSize = new System.Drawing.Size(648, 438);
            this.ControlBox = false;
            this.Controls.Add(this._DocExplorerAutoHideControl);
            this.Controls.Add(this.axWebBrowser1);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this._DocExplorerUnpinnedTabAreaBottom);
            this.Controls.Add(this._DocExplorerUnpinnedTabAreaTop);
            this.Controls.Add(this._DocExplorerUnpinnedTabAreaRight);
            this.Controls.Add(this._DocExplorerUnpinnedTabAreaLeft);
            this.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocExplorer";
            this.Text = "DocExplorer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DocExplorer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).EndInit();
            this._DocExplorerAutoHideControl.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void axWebBrowser1_NavigateComplete2(object sender, AxSHDocVw.DWebBrowserEvents2_NavigateComplete2Event e)
		{
			//Note: You can use the reference to the document object to 
			// automate the document server. 

			Object o = e.pDisp;
			Object oDocument = new object();
			oDocument = o.GetType().InvokeMember("Document",BindingFlags.GetProperty,null,o,null); 

			Object oApplication = o.GetType().InvokeMember("Application",BindingFlags.GetProperty,null,oDocument,null); 

			Object oName = o.GetType().InvokeMember("Name",BindingFlags.GetProperty ,null,oApplication,null); 

			//MessageBox.Show("File opened by: " + oName.ToString() ); 

		}
		protected   override   void   WndProc(ref   System.Windows.Forms.Message   m)     
		{     
			if(m.Msg   !=   0x0003   &&   m.WParam   !=   (IntPtr)0xF012)   
			{   
				base.WndProc(ref   m);   
			}
    
		}  

		private void DocExplorer_Load(object sender, System.EventArgs e)
		{
			//Find the Office document. 
			//openFileDialog1.FileName = ""; 
			//openFileDialog1.ShowDialog(); 
			//strFileName = openFileDialog1.FileName; 

			//If the user does not cancel, open the document. 

			//this.FormBorderStyle=FormBorderStyle.None;
			//this.WindowState= FormWindowState.Maximized;
			//this.MaximizeBox = false;
			//this.FormBorderStyle=FormBorderStyle.None;
			//this.ultraDockManager1

			if(strPath.Length != 0) 
			{ 
				Object refmissing = System.Reflection.Missing.Value; 
				//oDocument = null; 
				axWebBrowser1.Navigate(strPath, ref refmissing , ref refmissing , ref refmissing , ref refmissing); 
				this.Text = strName;
			} 

		}
        //private void App_Idle(ApplicationIdleTimer.ApplicationIdleEventArgs e)
        //{
        //    if (e.IdleDuration.TotalSeconds>30)
        //    {
        //        ultraButton1_Click(null,null);
        //    }
			
        //}
		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
