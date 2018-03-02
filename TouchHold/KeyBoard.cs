using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace TouchHold
{
	/// <summary>
	/// KeyBoard 的摘要说明。
	/// </summary>
	public class KeyBoard : System.Windows.Forms.UserControl
	{
		private Infragistics.Win.Misc.UltraButton btnNumber1;
		private Infragistics.Win.Misc.UltraButton btnNumber2;
		private Infragistics.Win.Misc.UltraButton btnNumber13;
		private Infragistics.Win.Misc.UltraButton btnNumber4;
		private Infragistics.Win.Misc.UltraButton btnNumber15;
		private Infragistics.Win.Misc.UltraButton btnNumber6;
		private Infragistics.Win.Misc.UltraButton btnNumber7;
		private Infragistics.Win.Misc.UltraButton btnNumber8;
		private Infragistics.Win.Misc.UltraButton btnNumber9;
		private Infragistics.Win.Misc.UltraButton btnNumber0;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Infragistics.Win.Misc.UltraButton btnBackSpace;

		[DllImport("user32.dll")]
		public extern static IntPtr GetDesktopWindow();

		[DllImport("user32.dll")]
		public extern static bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
		public static uint  LWA_COLORKEY = 0x00000001;
		public static uint LWA_ALPHA = 0x00000002;

		[DllImport("user32.dll")]
		public extern static uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);
		[DllImport("user32.dll")]
		public extern static uint GetWindowLong(IntPtr hwnd, int nIndex);

		public enum WindowStyle : int
		{
			GWL_EXSTYLE = -20
		}

		public enum ExWindowStyle : uint
		{
			WS_EX_LAYERED = 0x00080000
		}



		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public KeyBoard()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化

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

		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.btnNumber1 = new Infragistics.Win.Misc.UltraButton();
			this.btnNumber2 = new Infragistics.Win.Misc.UltraButton();
			this.btnNumber13 = new Infragistics.Win.Misc.UltraButton();
			this.btnNumber4 = new Infragistics.Win.Misc.UltraButton();
			this.btnNumber15 = new Infragistics.Win.Misc.UltraButton();
			this.btnNumber6 = new Infragistics.Win.Misc.UltraButton();
			this.btnNumber7 = new Infragistics.Win.Misc.UltraButton();
			this.btnNumber8 = new Infragistics.Win.Misc.UltraButton();
			this.btnNumber9 = new Infragistics.Win.Misc.UltraButton();
			this.btnNumber0 = new Infragistics.Win.Misc.UltraButton();
			this.btnCancel = new Infragistics.Win.Misc.UltraButton();
			this.btnBackSpace = new Infragistics.Win.Misc.UltraButton();
			this.SuspendLayout();
			// 
			// btnNumber1
			// 
			this.btnNumber1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnNumber1.Location = new System.Drawing.Point(64, 24);
			this.btnNumber1.Name = "btnNumber1";
			this.btnNumber1.Size = new System.Drawing.Size(75, 48);
			this.btnNumber1.TabIndex = 0;
			this.btnNumber1.Text = "1";
			this.btnNumber1.Click += new System.EventHandler(this.btnNumber1_Click);
			// 
			// btnNumber2
			// 
			this.btnNumber2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnNumber2.Location = new System.Drawing.Point(152, 24);
			this.btnNumber2.Name = "btnNumber2";
			this.btnNumber2.Size = new System.Drawing.Size(75, 48);
			this.btnNumber2.TabIndex = 1;
			this.btnNumber2.Text = "2";
			this.btnNumber2.Click += new System.EventHandler(this.btnNumber2_Click);
			// 
			// btnNumber13
			// 
			this.btnNumber13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnNumber13.Location = new System.Drawing.Point(240, 24);
			this.btnNumber13.Name = "btnNumber13";
			this.btnNumber13.Size = new System.Drawing.Size(75, 48);
			this.btnNumber13.TabIndex = 2;
			this.btnNumber13.Text = "3";
			this.btnNumber13.Click += new System.EventHandler(this.btnNumber13_Click);
			// 
			// btnNumber4
			// 
			this.btnNumber4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnNumber4.Location = new System.Drawing.Point(64, 88);
			this.btnNumber4.Name = "btnNumber4";
			this.btnNumber4.Size = new System.Drawing.Size(75, 48);
			this.btnNumber4.TabIndex = 3;
			this.btnNumber4.Text = "4";
			this.btnNumber4.Click += new System.EventHandler(this.btnNumber4_Click);
			// 
			// btnNumber15
			// 
			this.btnNumber15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnNumber15.Location = new System.Drawing.Point(152, 88);
			this.btnNumber15.Name = "btnNumber15";
			this.btnNumber15.Size = new System.Drawing.Size(75, 48);
			this.btnNumber15.TabIndex = 4;
			this.btnNumber15.Text = "5";
			this.btnNumber15.Click += new System.EventHandler(this.btnNumber15_Click);
			// 
			// btnNumber6
			// 
			this.btnNumber6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnNumber6.Location = new System.Drawing.Point(240, 88);
			this.btnNumber6.Name = "btnNumber6";
			this.btnNumber6.Size = new System.Drawing.Size(75, 48);
			this.btnNumber6.TabIndex = 5;
			this.btnNumber6.Text = "6";
			this.btnNumber6.Click += new System.EventHandler(this.btnNumber6_Click);
			// 
			// btnNumber7
			// 
			this.btnNumber7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnNumber7.Location = new System.Drawing.Point(64, 152);
			this.btnNumber7.Name = "btnNumber7";
			this.btnNumber7.Size = new System.Drawing.Size(75, 48);
			this.btnNumber7.TabIndex = 6;
			this.btnNumber7.Text = "7";
			this.btnNumber7.Click += new System.EventHandler(this.btnNumber7_Click);
			// 
			// btnNumber8
			// 
			this.btnNumber8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnNumber8.Location = new System.Drawing.Point(152, 152);
			this.btnNumber8.Name = "btnNumber8";
			this.btnNumber8.Size = new System.Drawing.Size(75, 48);
			this.btnNumber8.TabIndex = 7;
			this.btnNumber8.Text = "8";
			this.btnNumber8.Click += new System.EventHandler(this.btnNumber8_Click);
			// 
			// btnNumber9
			// 
			this.btnNumber9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnNumber9.Location = new System.Drawing.Point(240, 152);
			this.btnNumber9.Name = "btnNumber9";
			this.btnNumber9.Size = new System.Drawing.Size(75, 48);
			this.btnNumber9.TabIndex = 8;
			this.btnNumber9.Text = "9";
			this.btnNumber9.Click += new System.EventHandler(this.btnNumber9_Click);
			// 
			// btnNumber0
			// 
			this.btnNumber0.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnNumber0.Location = new System.Drawing.Point(64, 216);
			this.btnNumber0.Name = "btnNumber0";
			this.btnNumber0.Size = new System.Drawing.Size(75, 48);
			this.btnNumber0.TabIndex = 9;
			this.btnNumber0.Text = "0";
			this.btnNumber0.Click += new System.EventHandler(this.btnNumber0_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnCancel.Location = new System.Drawing.Point(152, 216);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 48);
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnBackSpace
			// 
			this.btnBackSpace.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnBackSpace.Location = new System.Drawing.Point(240, 216);
			this.btnBackSpace.Name = "btnBackSpace";
			this.btnBackSpace.Size = new System.Drawing.Size(75, 48);
			this.btnBackSpace.TabIndex = 11;
			this.btnBackSpace.Text = "←";
			this.btnBackSpace.Click += new System.EventHandler(this.btnBackSpace_Click);
			// 
			// KeyBoard
			// 
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.btnBackSpace);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnNumber0);
			this.Controls.Add(this.btnNumber9);
			this.Controls.Add(this.btnNumber8);
			this.Controls.Add(this.btnNumber7);
			this.Controls.Add(this.btnNumber6);
			this.Controls.Add(this.btnNumber15);
			this.Controls.Add(this.btnNumber4);
			this.Controls.Add(this.btnNumber13);
			this.Controls.Add(this.btnNumber2);
			this.Controls.Add(this.btnNumber1);
			this.Name = "KeyBoard";
			this.Size = new System.Drawing.Size(376, 296);
			this.Load += new System.EventHandler(this.KeyBoard_Load);
			this.ResumeLayout(false);

		}
		#endregion

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;

				cp.Parent = GetDesktopWindow();
				cp.ExStyle = 0x00000080 | 0x00000008;//WS_EX_TOOLWINDOW | WS_EX_TOPMOST

				return cp;
			}
		}

		private void SetWindowTransparent(byte bAlpha)
		{
			try
			{
				SetWindowLong(this.Handle, (int)WindowStyle.GWL_EXSTYLE,
					GetWindowLong(this.Handle, (int)WindowStyle.GWL_EXSTYLE) | (uint)ExWindowStyle.WS_EX_LAYERED);

				SetLayeredWindowAttributes(this.Handle, 0, bAlpha, LWA_COLORKEY | LWA_ALPHA);
			}
			catch
			{
			}
		}



		public event EventHandler KeyOneClicked;
		private string currentKey;
		public string CurrentKey
		{
			set { currentKey = value; }
			get { return currentKey; }           
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (KeyOneClicked != null)
			{
				Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
				currentKey = btn.Text;
				KeyOneClicked(this, e);
			}
		}

		private void btnBackSpace_Click(object sender, System.EventArgs e)
		{
			if (KeyOneClicked != null)
			{
				Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
				currentKey = btn.Text;
				KeyOneClicked(this, e);
			}
		}

		private void btnNumber1_Click(object sender, System.EventArgs e)
		{
			if (KeyOneClicked != null)
			{
				Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
				currentKey = btn.Text;
				KeyOneClicked(this, e);
			}
		}

		private void btnNumber2_Click(object sender, System.EventArgs e)
		{
			if (KeyOneClicked != null)
			{
				Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
				currentKey = btn.Text;
				KeyOneClicked(this, e);
			}
		}

		private void btnNumber13_Click(object sender, System.EventArgs e)
		{
			if (KeyOneClicked != null)
			{
				Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
				currentKey = btn.Text;
				KeyOneClicked(this, e);
			}
		}

		private void btnNumber4_Click(object sender, System.EventArgs e)
		{
			if (KeyOneClicked != null)
			{
				Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
				currentKey = btn.Text;
				KeyOneClicked(this, e);
			}
		}

		private void btnNumber15_Click(object sender, System.EventArgs e)
		{
			if (KeyOneClicked != null)
			{
				Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
				currentKey = btn.Text;
				KeyOneClicked(this, e);
			}
		}

		private void btnNumber6_Click(object sender, System.EventArgs e)
		{
			if (KeyOneClicked != null)
			{
				Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
				currentKey = btn.Text;
				KeyOneClicked(this, e);
			}
		}

		private void btnNumber7_Click(object sender, System.EventArgs e)
		{
			if (KeyOneClicked != null)
			{
				Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
				currentKey = btn.Text;
				KeyOneClicked(this, e);
			}
		}

		private void btnNumber8_Click(object sender, System.EventArgs e)
		{
			if (KeyOneClicked != null)
			{
				Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
				currentKey = btn.Text;
				KeyOneClicked(this, e);
			}
		}

		private void btnNumber9_Click(object sender, System.EventArgs e)
		{
			if (KeyOneClicked != null)
			{
				Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
				currentKey = btn.Text;
				KeyOneClicked(this, e);
			}
		}

		private void btnNumber0_Click(object sender, System.EventArgs e)
		{
			if (KeyOneClicked != null)
			{
				Infragistics.Win.Misc.UltraButton btn = (Infragistics.Win.Misc.UltraButton)sender;
				currentKey = btn.Text;
				KeyOneClicked(this, e);
			}
		}

		private void KeyBoard_Load(object sender, System.EventArgs e)
		{
			//this.SetWindowTransparent(100);

		}
	}
}
