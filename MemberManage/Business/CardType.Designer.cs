namespace MemberManage.Business
{
    partial class CardType
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.l8 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.l6 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.txtL6 = new System.Windows.Forms.TextBox();
            this.txtL8 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtL8);
            this.ultraGroupBox1.Controls.Add(this.txtL6);
            this.ultraGroupBox1.Controls.Add(this.l8);
            this.ultraGroupBox1.Controls.Add(this.l6);
            this.ultraGroupBox1.Controls.Add(this.ultraButton2);
            this.ultraGroupBox1.Controls.Add(this.ultraButton1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(68, 45);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(259, 156);
            this.ultraGroupBox1.TabIndex = 2;
            // 
            // l8
            // 
            this.l8.Location = new System.Drawing.Point(43, 50);
            this.l8.Name = "l8";
            this.l8.Size = new System.Drawing.Size(120, 20);
            this.l8.TabIndex = 5;
            // 
            // l6
            // 
            this.l6.Location = new System.Drawing.Point(43, 24);
            this.l6.Name = "l6";
            this.l6.Size = new System.Drawing.Size(23, 20);
            this.l6.TabIndex = 4;
            // 
            // ultraButton2
            // 
            this.ultraButton2.Location = new System.Drawing.Point(141, 111);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(75, 23);
            this.ultraButton2.TabIndex = 3;
            this.ultraButton2.Text = "关闭";
            this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(43, 111);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 2;
            this.ultraButton1.Text = "确定";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // txtL6
            // 
            this.txtL6.Location = new System.Drawing.Point(73, 24);
            this.txtL6.Name = "txtL6";
            this.txtL6.Size = new System.Drawing.Size(100, 21);
            this.txtL6.TabIndex = 6;
            this.txtL6.Text = Login.constApp.strCardTypeL6Name + "";
            // 
            // txtL8
            // 
            this.txtL8.Location = new System.Drawing.Point(73, 48);
            this.txtL8.Name = "txtL8";
            this.txtL8.Size = new System.Drawing.Size(100, 21);
            this.txtL8.TabIndex = 7;
            this.txtL8.Text = Login.constApp.strCardTypeL8Name + "";
            // 
            // CardType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(417, 280);
            this.ControlBox = false;
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "CardType";
            this.Text = "卡型选择";
            this.Load += new System.EventHandler(this.CardType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.Misc.UltraButton ultraButton2;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor l8;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor l6;
        private System.Windows.Forms.TextBox txtL8;
        private System.Windows.Forms.TextBox txtL6;

    }
}
