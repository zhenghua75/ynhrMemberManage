using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace TouchHold
{
    public partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);

            Assembly asm = Assembly.GetExecutingAssembly();
            Stream imgStream = asm.GetManifestResourceStream("TouchHold.Logo.jpg");
            Bitmap MDIbg_Image = new Bitmap(imgStream);//new Bitmap("logo.jpg");
            e.Graphics.DrawImage(MDIbg_Image, this.ClientRectangle);
        }
    }
}