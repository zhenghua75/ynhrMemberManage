using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using QuartzTypeLib;
namespace TouchHold
{
	/// <summary>
	/// vodExplorer 的摘要说明。
	/// </summary>
	public class vodExplorer : System.Windows.Forms.Form
	{
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private System.ComponentModel.IContainer components;

		private const int WM_APP = 0x8000;
		private const int WM_GRAPHNOTIFY = WM_APP + 1;
		private const int EC_COMPLETE = 0x01;
		private const int WS_CHILD = 0x40000000;
		private const int WS_CLIPCHILDREN = 0x2000000;

		private FilgraphManager m_objFilterGraph = null;
		private IBasicAudio m_objBasicAudio = null;
		private IVideoWindow m_objVideoWindow = null;
		private IMediaEvent m_objMediaEvent = null;
		private IMediaEventEx m_objMediaEventEx = null;
		private IMediaPosition m_objMediaPosition = null;
		private IMediaControl m_objMediaControl = null;
		private System.Windows.Forms.Panel panel1;
		private Infragistics.Win.UltraWinDock.UltraDockManager ultraDockManager1;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _vodExplorerUnpinnedTabAreaLeft;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _vodExplorerUnpinnedTabAreaRight;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _vodExplorerUnpinnedTabAreaTop;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _vodExplorerUnpinnedTabAreaBottom;
		private Infragistics.Win.UltraWinDock.AutoHideControl _vodExplorerAutoHideControl;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;

		public string strVodPath = "";

		public vodExplorer()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
//			ApplicationIdleTimer idle = new ApplicationIdleTimer();
//			System.Windows.Forms.Application.AddMessageFilter(idle);
//			idle.ApplicationIdle += new ApplicationIdleTimer.ApplicationIdleEventHandler(this.App_Idle);
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

		protected override void WndProc( ref Message m)
		{
			if (m.Msg == WM_GRAPHNOTIFY)
			{
				int lEventCode;
				int lParam1, lParam2;

				while (true)
				{
					try
					{
						m_objMediaEventEx.GetEvent(out lEventCode, 
							out lParam1,
							out lParam2,
							0); 
 
						m_objMediaEventEx.FreeEventParams(lEventCode, lParam1, lParam2);

						if (lEventCode == EC_COMPLETE)
						{
							m_objMediaControl.Stop();
							m_objMediaPosition.CurrentPosition = 0;
						}
					} 
					catch (Exception)
					{
						break;
					}
				}
			}

			if(m.Msg   !=   0x0003   &&   m.WParam   !=   (IntPtr)0xF012)   
			{   
				base.WndProc(ref   m);   
			}
			//base.WndProc(ref m);
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedBottom, new System.Guid("0da254c1-31a3-405f-a281-05bd1b227034"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("ce52614f-c634-42b0-8790-54e0c10eef4a"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("0da254c1-31a3-405f-a281-05bd1b227034"), -1);
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ultraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._vodExplorerUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._vodExplorerUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._vodExplorerUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._vodExplorerUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._vodExplorerAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).BeginInit();
            this._vodExplorerAutoHideControl.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraButton1
            // 
            this.ultraButton1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraButton1.Location = new System.Drawing.Point(0, 32);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(544, 75);
            this.ultraButton1.TabIndex = 6;
            this.ultraButton1.Text = "返回";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 372);
            this.panel1.TabIndex = 7;
            // 
            // ultraDockManager1
            // 
            dockableControlPane1.Control = this.ultraButton1;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(-1, 107);
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(208, 272, 128, 37);
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
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.TextTab = "返回";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane1.Settings.AllowDockAsTab = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane1.Settings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane1.Settings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane1.Settings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane1.Settings.AllowDockTop = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane1.Settings.AllowDragging = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane1.Settings.AllowMaximize = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane1.Settings.AllowMinimize = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane1.Settings.AllowResize = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane1.Size = new System.Drawing.Size(544, 95);
            this.ultraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.ultraDockManager1.HostControl = this;
            // 
            // _vodExplorerUnpinnedTabAreaLeft
            // 
            this._vodExplorerUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._vodExplorerUnpinnedTabAreaLeft.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._vodExplorerUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._vodExplorerUnpinnedTabAreaLeft.Name = "_vodExplorerUnpinnedTabAreaLeft";
            this._vodExplorerUnpinnedTabAreaLeft.Owner = this.ultraDockManager1;
            this._vodExplorerUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 411);
            this._vodExplorerUnpinnedTabAreaLeft.TabIndex = 8;
            // 
            // _vodExplorerUnpinnedTabAreaRight
            // 
            this._vodExplorerUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._vodExplorerUnpinnedTabAreaRight.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._vodExplorerUnpinnedTabAreaRight.Location = new System.Drawing.Point(544, 0);
            this._vodExplorerUnpinnedTabAreaRight.Name = "_vodExplorerUnpinnedTabAreaRight";
            this._vodExplorerUnpinnedTabAreaRight.Owner = this.ultraDockManager1;
            this._vodExplorerUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 411);
            this._vodExplorerUnpinnedTabAreaRight.TabIndex = 9;
            // 
            // _vodExplorerUnpinnedTabAreaTop
            // 
            this._vodExplorerUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._vodExplorerUnpinnedTabAreaTop.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._vodExplorerUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._vodExplorerUnpinnedTabAreaTop.Name = "_vodExplorerUnpinnedTabAreaTop";
            this._vodExplorerUnpinnedTabAreaTop.Owner = this.ultraDockManager1;
            this._vodExplorerUnpinnedTabAreaTop.Size = new System.Drawing.Size(544, 0);
            this._vodExplorerUnpinnedTabAreaTop.TabIndex = 10;
            // 
            // _vodExplorerUnpinnedTabAreaBottom
            // 
            this._vodExplorerUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._vodExplorerUnpinnedTabAreaBottom.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._vodExplorerUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 372);
            this._vodExplorerUnpinnedTabAreaBottom.Name = "_vodExplorerUnpinnedTabAreaBottom";
            this._vodExplorerUnpinnedTabAreaBottom.Owner = this.ultraDockManager1;
            this._vodExplorerUnpinnedTabAreaBottom.Size = new System.Drawing.Size(544, 39);
            this._vodExplorerUnpinnedTabAreaBottom.TabIndex = 11;
            // 
            // _vodExplorerAutoHideControl
            // 
            this._vodExplorerAutoHideControl.Controls.Add(this.dockableWindow1);
            this._vodExplorerAutoHideControl.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._vodExplorerAutoHideControl.Location = new System.Drawing.Point(0, 422);
            this._vodExplorerAutoHideControl.Name = "_vodExplorerAutoHideControl";
            this._vodExplorerAutoHideControl.Owner = this.ultraDockManager1;
            this._vodExplorerAutoHideControl.Size = new System.Drawing.Size(544, 0);
            this._vodExplorerAutoHideControl.TabIndex = 12;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.ultraButton1);
            this.dockableWindow1.Location = new System.Drawing.Point(0, 5);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.ultraDockManager1;
            this.dockableWindow1.Size = new System.Drawing.Size(544, 107);
            this.dockableWindow1.TabIndex = 14;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowDockingArea1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.windowDockingArea1.Location = new System.Drawing.Point(0, 272);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.ultraDockManager1;
            this.windowDockingArea1.Size = new System.Drawing.Size(544, 100);
            this.windowDockingArea1.TabIndex = 13;
            // 
            // vodExplorer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(14, 31);
            this.ClientSize = new System.Drawing.Size(544, 411);
            this.ControlBox = false;
            this.Controls.Add(this._vodExplorerAutoHideControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this._vodExplorerUnpinnedTabAreaTop);
            this.Controls.Add(this._vodExplorerUnpinnedTabAreaBottom);
            this.Controls.Add(this._vodExplorerUnpinnedTabAreaLeft);
            this.Controls.Add(this._vodExplorerUnpinnedTabAreaRight);
            this.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "vodExplorer";
            this.Text = "vodExplorer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.vodExplorer_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.vodExplorer_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).EndInit();
            this._vodExplorerAutoHideControl.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void vodExplorer_Load(object sender, System.EventArgs e)
		{
            //this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle=FormBorderStyle.None;
			m_objFilterGraph = new FilgraphManager();
			m_objFilterGraph.RenderFile(strVodPath);

			m_objBasicAudio = m_objFilterGraph as IBasicAudio;
                
			try
			{
				m_objVideoWindow = m_objFilterGraph as IVideoWindow;
				m_objVideoWindow.Owner = (int) panel1.Handle;
				m_objVideoWindow.WindowStyle = WS_CHILD | WS_CLIPCHILDREN;
				m_objVideoWindow.SetWindowPosition(panel1.ClientRectangle.Left,
					panel1.ClientRectangle.Top,
					panel1.ClientRectangle.Width,
					panel1.ClientRectangle.Height);
			}
			catch (Exception)
			{
				m_objVideoWindow = null;
			}

			m_objMediaEvent = m_objFilterGraph as IMediaEvent;

			m_objMediaEventEx = m_objFilterGraph as IMediaEventEx;
			m_objMediaEventEx.SetNotifyWindow((int) this.Handle,WM_GRAPHNOTIFY, 0);

			m_objMediaPosition = m_objFilterGraph as IMediaPosition;

			m_objMediaControl = m_objFilterGraph as IMediaControl;

			//this.Text = "DirectShow - [" + openFileDialog.FileName + "]";

			m_objMediaControl.Run();
		}
        //private void App_Idle(ApplicationIdleTimer.ApplicationIdleEventArgs e)
        //{
        //    //if (e.IdleDuration.TotalSeconds>120)
        //    if (e.IdleDuration.TotalSeconds>30)
        //    {
        //        ultraButton1_Click(null,null);
        //    }
			
        //}
		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			//this.Dispose();
			m_objMediaControl.Stop();
			this.Close();
		}

        private void vodExplorer_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_objMediaControl.Stop();
        }
	}
}
