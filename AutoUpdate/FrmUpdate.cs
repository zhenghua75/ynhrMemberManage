using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace AutoUpdate
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class FrmUpdate : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ColumnHeader chFileName;
		private System.Windows.Forms.ColumnHeader chVersion;
		private System.Windows.Forms.ColumnHeader chProgress;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListView lvUpdateList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lbState;
		private System.Windows.Forms.ProgressBar pbDownFile;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnFinish;
		private System.Threading.Thread threadDown;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;


		public FrmUpdate()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			//this.CheckForIllegalCrossThreadCalls = false; 
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
				if (components != null) 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpdate));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvUpdateList = new System.Windows.Forms.ListView();
            this.chFileName = new System.Windows.Forms.ColumnHeader();
            this.chVersion = new System.Windows.Forms.ColumnHeader();
            this.chProgress = new System.Windows.Forms.ColumnHeader();
            this.pbDownFile = new System.Windows.Forms.ProgressBar();
            this.lbState = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 240);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.lvUpdateList);
            this.panel1.Controls.Add(this.pbDownFile);
            this.panel1.Controls.Add(this.lbState);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(120, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 240);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "以下为更新文件列表";
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 2);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // lvUpdateList
            // 
            this.lvUpdateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileName,
            this.chVersion,
            this.chProgress});
            this.lvUpdateList.Location = new System.Drawing.Point(0, 48);
            this.lvUpdateList.Name = "lvUpdateList";
            this.lvUpdateList.Size = new System.Drawing.Size(376, 120);
            this.lvUpdateList.TabIndex = 6;
            this.lvUpdateList.UseCompatibleStateImageBehavior = false;
            this.lvUpdateList.View = System.Windows.Forms.View.Details;
            // 
            // chFileName
            // 
            this.chFileName.Text = "组件名";
            this.chFileName.Width = 123;
            // 
            // chVersion
            // 
            this.chVersion.Text = "版本号";
            this.chVersion.Width = 98;
            // 
            // chProgress
            // 
            this.chProgress.Text = "进度";
            this.chProgress.Width = 47;
            // 
            // pbDownFile
            // 
            this.pbDownFile.Location = new System.Drawing.Point(3, 200);
            this.pbDownFile.Name = "pbDownFile";
            this.pbDownFile.Size = new System.Drawing.Size(373, 17);
            this.pbDownFile.TabIndex = 5;
            // 
            // lbState
            // 
            this.lbState.Location = new System.Drawing.Point(3, 176);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(240, 16);
            this.lbState.TabIndex = 4;
            this.lbState.Text = "点击“下一步”开始更新文件";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 2);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(224, 264);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 24);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "下一步(&N)>";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(312, 264);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(8, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(112, 32);
            this.panel2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(144, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "昆明道讯科技有限公司";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(136, 208);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(228, 16);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.dxkj.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "欢迎以后继续关注我们的产品。";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 48);
            this.label2.TabIndex = 10;
            this.label2.Text = "     程序更新完成,如果程序更新期间被关闭,点击\"完成\"自动更新程序会自动重新启动系统。";
            // 
            // groupBox3
            // 
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(112, 2);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox2";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(0, 32);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(280, 8);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(24, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "感谢使用在线升级";
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(136, 264);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(80, 24);
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "完成(&F)";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // FrmUpdate
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(530, 301);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFinish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "云南人才市场会员管理自动更新";
            this.Load += new System.EventHandler(this.FrmUpdate_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmUpdate_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private string updateUrl = string.Empty;
		private string tempUpdatePath = string.Empty;
		XmlFiles updaterXmlFiles = null;
		private int availableUpdate = 0;
		bool isRun = false;
		string mainAppExe = "";

		[DllImport("wininet.dll")]
		private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);
		//可能的connectionDescription值
		private enum InetConnState
		{
			modem = 0x1,
			lan = 0x2,
			proxy = 0x4,
			ras = 0x10,
			offline = 0x20,
			configured = 0x40
		}
		/// <summary>
		/// 网络连接状态
		/// </summary>
		/// <returns>   true: On Line   false: Off Line</returns>
		private bool CheckInetConnection()
		{
			int I = 0;
			bool state = InternetGetConnectedState(out I, 0);
			return state;

		}
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FrmUpdate());
		}

		
		private void FrmUpdate_Load(object sender, System.EventArgs e)
		{
//			if (!CheckInetConnection())
//			{
//				MessageBox.Show("无网络连接!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
//				this.Close();
//				return;
//			}
			
			panel2.Visible = false;
			btnFinish.Visible = false;

			string localXmlFile = Application.StartupPath + "\\UpdateList.xml";
			string serverXmlFile = string.Empty;

			
			try
			{
				//从本地读取更新配置文件信息
				updaterXmlFiles = new XmlFiles(localXmlFile );
			}
			catch
			{
				MessageBox.Show("配置文件出错!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				this.Close();
				return;
			}
			//获取服务器地址
			updateUrl = updaterXmlFiles.GetNodeValue("//Url");

			AppUpdater appUpdater = new AppUpdater();
			appUpdater.UpdaterUrl = updateUrl + "/UpdateList.xml";

			//与服务器连接,下载更新配置文件
			try
			{
				tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\"+ "_"+ updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value+"_"+"y"+"_"+"x"+"_"+"m"+"_"+"\\";
				appUpdater.DownAutoUpdateFile(tempUpdatePath);
			}
			catch
			{
				MessageBox.Show("与服务器连接失败,操作超时!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.Close();
				return;

			}

			//获取更新文件列表
			Hashtable htUpdateFile = new Hashtable();

			serverXmlFile = tempUpdatePath + "\\UpdateList.xml";
			if(!File.Exists(serverXmlFile))
			{
				return;
			}

			availableUpdate = appUpdater.CheckForUpdate(serverXmlFile,localXmlFile,out htUpdateFile);
			if (availableUpdate > 0)
			{
				for(int i=0;i<htUpdateFile.Count;i++)
				{
					string [] fileArray =(string []) htUpdateFile[i];
					lvUpdateList.Items.Add(new ListViewItem(fileArray));
				}
			}
//			else
//				btnNext.Enabled = false;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
			Application.ExitThread();
			Application.Exit();
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			if (availableUpdate > 0)
			{
					threadDown=new Thread(new ThreadStart(DownUpdateFile));
					threadDown.IsBackground = true;
					threadDown.Start();
			}
			else
			{
				MessageBox.Show("没有可用的更新!","自动更新",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

		}
		private void DownUpdateFile()
		{
			this.Cursor = Cursors.WaitCursor;
			mainAppExe = updaterXmlFiles.GetNodeValue("//EntryPoint");
			Process [] allProcess = Process.GetProcesses();
			foreach(Process p in allProcess)
			{
				
				if (p.ProcessName.ToLower() + ".exe" == mainAppExe.ToLower() )
				{
					for(int i=0;i<p.Threads.Count;i++)
						p.Threads[i].Dispose();
					p.Kill();
					isRun = true;
					//break;
				}
			}
			WebClient wcClient = new WebClient();
			
			try
			{
				for(int i = 0;i < this.lvUpdateList.Items.Count;i++)
				{
					
					string UpdateFile = lvUpdateList.Items[i].Text.Trim();
					string updateFileUrl = updateUrl + lvUpdateList.Items[i].Text.Trim();
					long fileLength = 0;

					WebRequest webReq = WebRequest.Create(updateFileUrl);
					WebResponse webRes = webReq.GetResponse();
					fileLength = webRes.ContentLength;
				
					lbState.Text = "正在下载更新文件,请稍后...";
					pbDownFile.Value = 0;
					pbDownFile.Maximum = (int)fileLength;

				
					Stream srm = webRes.GetResponseStream();
					StreamReader srmReader = new StreamReader(srm);
					byte[] bufferbyte = new byte[fileLength];
					int allByte = (int)bufferbyte.Length;
					int startByte = 0;
					while(fileLength > 0)
					{
						Application.DoEvents();
						int downByte = srm.Read(bufferbyte,startByte,allByte);
						if (downByte == 0) {break;};
						startByte += downByte;
						allByte -= downByte;
						pbDownFile.Value += downByte;

						float part = (float)startByte / 1024;
						float total = (float)bufferbyte.Length / 1024;
						int percent =Convert.ToInt32((part/total)*100);

						this.lvUpdateList.Items[i].SubItems[2].Text = percent.ToString() + "%";

					}
					//解析网站路径一级目录结构
					string strLocalPath = UpdateFile.Replace("/","\\");
					string tempPath = tempUpdatePath + strLocalPath;
					CreateDirtory(tempPath);
					FileStream fs = new FileStream(tempPath,FileMode.OpenOrCreate,FileAccess.Write);
					fs.Write(bufferbyte,0,bufferbyte.Length);
					srm.Close();
					srmReader.Close();
					fs.Close();				
				}
				InvalidateControl();
				this.Cursor = Cursors.Default;
			}
			catch(WebException ex)
			{
				this.Cursor = Cursors.Default;
				System.IO.Directory.Delete(tempUpdatePath,true);
				MessageBox.Show("更新文件下载失败！"+ex.Message.ToString(),"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			
		}
		//创建目录
		private void CreateDirtory(string path)
		{
			if(!File.Exists(path))
			{
				string [] dirArray = path.Split('\\'); 
				string temp = string.Empty;
				for(int i = 0;i<dirArray.Length - 1;i++)
				{
					temp += dirArray[i].Trim() + "\\";
					if(!Directory.Exists(temp))
						Directory.CreateDirectory(temp);
				}
			}
		}



		//复制文件;		public void CopyFile(string sourcePath,string objPath)		{//			char[] split = @"\".ToCharArray();			if(!Directory.Exists(objPath))			{				Directory.CreateDirectory(objPath);			}			string[] files = Directory.GetFiles(sourcePath);			for(int i=0;i<files.Length;i++)			{				string[] childfile = files[i].Split('\\');				if(childfile[childfile.Length-1] == "AutoUpdate.exe")				{						File.Move(objPath + @"\" + childfile[childfile.Length-1], objPath + @"\" + childfile[childfile.Length-1] + ".delete");                    // 1
						File.Copy(files[i],objPath + @"\" + childfile[childfile.Length-1],true);				}				else				{					File.Copy(files[i],objPath + @"\" + childfile[childfile.Length-1],true);				}			}			string[] dirs = Directory.GetDirectories(sourcePath);			for(int i=0;i<dirs.Length;i++)			{				string[] childdir = dirs[i].Split('\\');				CopyFile(dirs[i],objPath + @"\" + childdir[childdir.Length-1]);			}		} 

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(linkLabel1.Text);
		}
		//点击完成复制更新文件到应用程序目录
		private void btnFinish_Click(object sender, System.EventArgs e)
		{
			
			this.Close();
			this.Dispose();
			try
			{
				CopyFile(tempUpdatePath,Directory.GetCurrentDirectory());
				System.IO.Directory.Delete(tempUpdatePath,true);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}
			if(true == this.isRun) Process.Start(mainAppExe);
			Application.Exit();
		}
		
		//重新绘制窗体部分控件属性
		private void InvalidateControl()
		{
			panel2.Location = panel1.Location;
			panel2.Size = panel1.Size;
			panel1.Visible = false;
			panel2.Visible = true;

			btnNext.Visible = false;
			btnCancel.Visible = false;
			btnFinish.Location = btnCancel.Location;
			btnFinish.Visible = true;
		}
		//判断主应用程序是否正在运行
		private bool IsMainAppRun()
		{
			string mainAppExe = updaterXmlFiles.GetNodeValue("//EntryPoint");
			bool isRun = false;
			Process [] allProcess = Process.GetProcesses();
			foreach(Process p in allProcess)
			{
				
				if (p.ProcessName.ToLower() + ".exe" == mainAppExe.ToLower() )
				{
					isRun = true;
					//break;
				}
			}
			return isRun;
		}

		private void FrmUpdate_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(threadDown!=null)
			{
				threadDown.Abort();
				threadDown = null;
			}
		}
	}
}
