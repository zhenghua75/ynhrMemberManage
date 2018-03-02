using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using Infragistics;
using Infragistics.Win;
using Infragistics.Win.UltraWinListView;
using Infragistics.Win.UltraWinTree;
using System.Reflection;
using System.Diagnostics;
namespace TouchHold
{
	/// <summary>
	/// BusinessIntro 的摘要说明。
	/// </summary>
	public class BusinessIntro : System.Windows.Forms.Form
	{
		private Infragistics.Win.UltraWinTree.UltraTree ultraTree1;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
		//private AxDSOFramer.AxFramerControl m_axFramerControl = new AxDSOFramer.AxFramerControl();


		public BusinessIntro()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusinessIntro));
            this.ultraTree1 = new Infragistics.Win.UltraWinTree.UltraTree();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTree1
            // 
            this.ultraTree1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraTree1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraTree1.Location = new System.Drawing.Point(168, 56);
            this.ultraTree1.Name = "ultraTree1";
            this.ultraTree1.Size = new System.Drawing.Size(442, 234);
            this.ultraTree1.TabIndex = 0;
            this.ultraTree1.AfterSelect += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.ultraTree1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // BusinessIntro
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(746, 416);
            this.ControlBox = false;
            this.Controls.Add(this.ultraTree1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BusinessIntro";
            this.Text = "云南人才市场业务介绍";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BusinessIntro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void BusinessIntro_Load(object sender, System.EventArgs e)
		{
			//this.FormBorderStyle=FormBorderStyle.None;
			//this.WindowState= FormWindowState.Maximized;
			//this.TopMost = true;


            string strPath = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
			DirectoryInfo directory = new DirectoryInfo(strPath);
			FileInfo[] files = directory.GetFiles();
			UltraListViewItem[] itemArrayFiles = new UltraListViewItem[ files.Length ];
			for ( int i = 0; i < files.Length; i ++ )
			{
				FileInfo fileInfo = files[i];
				UltraTreeNode tn = new UltraTreeNode(fileInfo.Name,fileInfo.Name);
				tn.Tag = fileInfo.FullName;
				switch (fileInfo.Extension.ToUpper())
				{
					case ".DOC":
						tn.Override.NodeAppearance.Image = imageList1.Images[0];
						break;
					case ".XLS":
						tn.Override.NodeAppearance.Image = imageList1.Images[1];
						break;
					case ".PPT":
						tn.Override.NodeAppearance.Image = imageList1.Images[2];
						break;
					default:
						break;
				}
				this.ultraTree1.Nodes.Add(tn);
			}

			
			
			
		}

		protected   override   void   WndProc(ref   System.Windows.Forms.Message   m)     
		{     
			if(m.Msg   !=   0x0003   &&   m.WParam   !=   (IntPtr)0xF012)   
			{   
				base.WndProc(ref   m);   
			}
    
		}  

		private void ultraTree1_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
		{
			UltraTreeNode selectedNode = e.NewSelections.Count == 1 ? e.NewSelections[0] : null;
			if ( selectedNode == null )
				return;
			//DocDisplay doc = new DocDisplay();
			DocExplorer doc = new DocExplorer();
			doc.strPath = selectedNode.Tag.ToString();
			doc.strName = selectedNode.Text.Substring(0,selectedNode.Text.IndexOf("."));
			doc.Show();
		}




	}
}
