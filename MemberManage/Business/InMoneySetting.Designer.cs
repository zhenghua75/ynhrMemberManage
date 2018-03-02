namespace MemberManage.Business
{
    partial class InMoneySetting
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
            IsShowing = false;
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraTextEditor3 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTextEditor2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraCheckEditor1 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.ultraButton2);
            this.ultraGroupBox1.Controls.Add(this.ultraButton1);
            this.ultraGroupBox1.Controls.Add(this.ultraTextEditor3);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox1.Controls.Add(this.ultraTextEditor2);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox1.Controls.Add(this.ultraTextEditor1);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox1.Controls.Add(this.ultraGrid1);
            this.ultraGroupBox1.Controls.Add(this.ultraCheckEditor1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(45, 26);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(859, 327);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.Text = "充值赠送规则";
            // 
            // ultraButton2
            // 
            this.ultraButton2.Location = new System.Drawing.Point(657, 166);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(75, 23);
            this.ultraButton2.TabIndex = 9;
            this.ultraButton2.Text = "删除行";
            this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(576, 166);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 8;
            this.ultraButton1.Text = "添加行";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // ultraTextEditor3
            // 
            this.ultraTextEditor3.Location = new System.Drawing.Point(642, 115);
            this.ultraTextEditor3.Name = "ultraTextEditor3";
            this.ultraTextEditor3.Size = new System.Drawing.Size(100, 21);
            this.ultraTextEditor3.TabIndex = 7;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(540, 119);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 6;
            this.ultraLabel3.Text = "赠送限额：";
            // 
            // ultraTextEditor2
            // 
            this.ultraTextEditor2.Location = new System.Drawing.Point(642, 94);
            this.ultraTextEditor2.Name = "ultraTextEditor2";
            this.ultraTextEditor2.Size = new System.Drawing.Size(100, 21);
            this.ultraTextEditor2.TabIndex = 5;
            this.ultraTextEditor2.Text = "0";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(540, 96);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 4;
            this.ultraLabel2.Text = "赠送比例：";
            // 
            // ultraTextEditor1
            // 
            this.ultraTextEditor1.Location = new System.Drawing.Point(642, 73);
            this.ultraTextEditor1.Name = "ultraTextEditor1";
            this.ultraTextEditor1.Size = new System.Drawing.Size(100, 21);
            this.ultraTextEditor1.TabIndex = 3;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(540, 73);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 2;
            this.ultraLabel1.Text = "起始金额：";
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Location = new System.Drawing.Point(24, 45);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(481, 268);
            this.ultraGrid1.TabIndex = 1;
            this.ultraGrid1.Text = "规则列表";
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            this.ultraGrid1.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ultraGrid1_InitializeRow);
            // 
            // ultraCheckEditor1
            // 
            this.ultraCheckEditor1.Location = new System.Drawing.Point(24, 18);
            this.ultraCheckEditor1.Name = "ultraCheckEditor1";
            this.ultraCheckEditor1.Size = new System.Drawing.Size(215, 20);
            this.ultraCheckEditor1.TabIndex = 0;
            this.ultraCheckEditor1.Text = "启用充值赠送功能";
            this.ultraCheckEditor1.CheckedChanged += new System.EventHandler(this.ultraCheckEditor1_CheckedChanged);
            // 
            // InMoneySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(947, 411);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "InMoneySetting";
            this.Text = "充值规则";
            this.Load += new System.EventHandler(this.InMoneySetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor1;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private Infragistics.Win.Misc.UltraButton ultraButton2;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
    }
}
