using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace ynhrMemberManage.Print
{
	public class zhhLabel:Label
	{

		private Color _BorderTop = Color.Transparent;
		private Color _BorderRight = Color.Transparent;
		private Color _BorderBottom = Color.Transparent;
		private Color _BorderLeft = Color.Transparent;
		[Category("Appearance")]
		public Color BorderTop 
		{
			get
			{
				return this._BorderTop;
			}
			set
			{
				this._BorderTop = value;
				this.Invalidate();
			}
		}
		[Category("Appearance")]
		public Color BorderRight 
		{
			get
			{
				return this._BorderRight;
			}
			set
			{
				this._BorderRight = value;
				this.Invalidate();
			}
		}
		[Category("Appearance")]
		public Color BorderBottom 
		{
			get
			{
				return this._BorderBottom;
			}
			set
			{
				this._BorderBottom = value;
				this.Invalidate();
			}
		}

		[Category("Appearance")]
		public Color BorderLeft 
		{
			get
			{
				return this._BorderLeft;
			}
			set
			{
				this._BorderLeft = value;
				this.Invalidate();
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);
			if (this.BorderStyle == BorderStyle.None)
			{
				e.Graphics.DrawLine(new Pen(this.BorderTop,1),0,0,this.Width,0);
				e.Graphics.DrawLine(new Pen(this.BorderBottom,1),0,this.Height-1,this.Width,this.Height-1);
				e.Graphics.DrawLine(new Pen(this.BorderLeft,1),-0,0,-0,this.Height);
				e.Graphics.DrawLine(new Pen(this.BorderRight,1),this.Width-1,0,this.Width-1,this.Height-1);


			}
		}


	}
}


