using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MemberManage.Business;

namespace MemberManage.Reports
{
	/// <summary>
	/// Summary description for MemberReport.
	/// </summary>
    public class MemberReport : frmBase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MemberReport()
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
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// MemberReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(488, 413);
			this.Name = "MemberReport";
			this.Text = "会员资料报表";
			this.Load += new System.EventHandler(this.MemberReport_Load);

		}
		#endregion

		private void MemberReport_Load(object sender, System.EventArgs e)
		{
			//
		}
	}
}
