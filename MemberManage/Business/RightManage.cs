using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ynhrMemberManage.Domain;
using System.Data;
using System.Data.SqlClient;
using ynhrMemberManage.ORM;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.Misc;
using ynhrMemberManage.Common;
using ynhrMemberManage.Business;
namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for RightManage.
	/// </summary>
    public class RightManage : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor1;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor2;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor3;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor4;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor5;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor6;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor10;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor11;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor12;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor13;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor14;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor15;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox4;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor8;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor16;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor17;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor19;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox5;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor22;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor23;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor24;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox6;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbOper;
		private Infragistics.Win.Misc.UltraButton btnCance;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Infragistics.Win.Misc.UltraButton btnModify;
		public static bool IsShowing ;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor20;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor21;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor25;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox7;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor26;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor27;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor28;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor29;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor30;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor31;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor32;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor33;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor34;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor35;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor36;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor37;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox8;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor38;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor39;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor40;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor41;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox9;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor9;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor18;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor42;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor43;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor44;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor45;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor46;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor47;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor48;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox10;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor7;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor49;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor50;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor51;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor52;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor53;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor54;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor55;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor56;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor57;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor58;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor59;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor60;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor61;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor62;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox11;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor63;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor64;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor65;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor66;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor67;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor68;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor69;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor70;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor71;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor72;
		private ArrayList alOperFuncList = new ArrayList();
		public RightManage()
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
			IsShowing = false;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraCheckEditor6 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor5 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor4 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor3 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor2 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor1 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraCheckEditor67 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor11 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor12 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor20 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor56 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor10 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraCheckEditor13 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor14 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor15 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraGroupBox4 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraCheckEditor68 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor55 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor51 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor8 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor16 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor17 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor19 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor38 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor25 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor21 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraGroupBox5 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraCheckEditor22 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor23 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor24 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraGroupBox6 = new Infragistics.Win.Misc.UltraGroupBox();
			this.cmbOper = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.btnCance = new Infragistics.Win.Misc.UltraButton();
			this.btnModify = new Infragistics.Win.Misc.UltraButton();
			this.ultraGroupBox7 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraCheckEditor65 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor9 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor18 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor42 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor43 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor44 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor45 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor35 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor36 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor37 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor32 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor33 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor34 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor30 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor31 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor28 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor29 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor26 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor27 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor39 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor40 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor41 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor46 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor47 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor48 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraGroupBox8 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraGroupBox9 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraGroupBox10 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraCheckEditor69 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor70 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor71 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor66 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor60 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor61 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor62 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor57 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor58 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor59 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor52 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor53 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor54 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor7 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor49 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor50 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraGroupBox11 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraCheckEditor63 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor64 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.ultraCheckEditor72 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
			this.ultraGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
			this.ultraGroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
			this.ultraGroupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).BeginInit();
			this.ultraGroupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).BeginInit();
			this.ultraGroupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox6)).BeginInit();
			this.ultraGroupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbOper)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox7)).BeginInit();
			this.ultraGroupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox8)).BeginInit();
			this.ultraGroupBox8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox9)).BeginInit();
			this.ultraGroupBox9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox10)).BeginInit();
			this.ultraGroupBox10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox11)).BeginInit();
			this.ultraGroupBox11.SuspendLayout();
			this.SuspendLayout();
			// 
			// ultraGroupBox1
			// 
			this.ultraGroupBox1.Controls.Add(this.ultraCheckEditor6);
			this.ultraGroupBox1.Controls.Add(this.ultraCheckEditor5);
			this.ultraGroupBox1.Controls.Add(this.ultraCheckEditor4);
			this.ultraGroupBox1.Controls.Add(this.ultraCheckEditor3);
			this.ultraGroupBox1.Controls.Add(this.ultraCheckEditor2);
			this.ultraGroupBox1.Controls.Add(this.ultraCheckEditor1);
			this.ultraGroupBox1.Location = new System.Drawing.Point(24, 16);
			this.ultraGroupBox1.Name = "ultraGroupBox1";
			this.ultraGroupBox1.Size = new System.Drawing.Size(168, 184);
			this.ultraGroupBox1.TabIndex = 0;
			this.ultraGroupBox1.Text = "会员卡";
			// 
			// ultraCheckEditor6
			// 
			this.ultraCheckEditor6.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor6.Location = new System.Drawing.Point(24, 152);
			this.ultraCheckEditor6.Name = "ultraCheckEditor6";
			this.ultraCheckEditor6.TabIndex = 5;
			this.ultraCheckEditor6.Text = "回收";
			// 
			// ultraCheckEditor5
			// 
			this.ultraCheckEditor5.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor5.Location = new System.Drawing.Point(24, 128);
			this.ultraCheckEditor5.Name = "ultraCheckEditor5";
			this.ultraCheckEditor5.TabIndex = 4;
			this.ultraCheckEditor5.Text = "补卡";
			// 
			// ultraCheckEditor4
			// 
			this.ultraCheckEditor4.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor4.Location = new System.Drawing.Point(24, 104);
			this.ultraCheckEditor4.Name = "ultraCheckEditor4";
			this.ultraCheckEditor4.TabIndex = 3;
			this.ultraCheckEditor4.Text = "解挂";
			// 
			// ultraCheckEditor3
			// 
			this.ultraCheckEditor3.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor3.Location = new System.Drawing.Point(24, 80);
			this.ultraCheckEditor3.Name = "ultraCheckEditor3";
			this.ultraCheckEditor3.TabIndex = 2;
			this.ultraCheckEditor3.Text = "挂失";
			// 
			// ultraCheckEditor2
			// 
			this.ultraCheckEditor2.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor2.Location = new System.Drawing.Point(24, 56);
			this.ultraCheckEditor2.Name = "ultraCheckEditor2";
			this.ultraCheckEditor2.TabIndex = 1;
			this.ultraCheckEditor2.Text = "充值";
			// 
			// ultraCheckEditor1
			// 
			this.ultraCheckEditor1.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor1.Location = new System.Drawing.Point(24, 32);
			this.ultraCheckEditor1.Name = "ultraCheckEditor1";
			this.ultraCheckEditor1.TabIndex = 0;
			this.ultraCheckEditor1.Text = "会员信息录入";
			// 
			// ultraGroupBox2
			// 
			this.ultraGroupBox2.Controls.Add(this.ultraCheckEditor72);
			this.ultraGroupBox2.Controls.Add(this.ultraCheckEditor67);
			this.ultraGroupBox2.Controls.Add(this.ultraCheckEditor11);
			this.ultraGroupBox2.Controls.Add(this.ultraCheckEditor12);
			this.ultraGroupBox2.Controls.Add(this.ultraCheckEditor20);
			this.ultraGroupBox2.Controls.Add(this.ultraCheckEditor56);
			this.ultraGroupBox2.Location = new System.Drawing.Point(24, 200);
			this.ultraGroupBox2.Name = "ultraGroupBox2";
			this.ultraGroupBox2.Size = new System.Drawing.Size(168, 184);
			this.ultraGroupBox2.TabIndex = 1;
			this.ultraGroupBox2.Text = "会员档案管理";
			// 
			// ultraCheckEditor67
			// 
			this.ultraCheckEditor67.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor67.Location = new System.Drawing.Point(24, 96);
			this.ultraCheckEditor67.Name = "ultraCheckEditor67";
			this.ultraCheckEditor67.TabIndex = 7;
			this.ultraCheckEditor67.Text = "会员免费场次修改";
			// 
			// ultraCheckEditor11
			// 
			this.ultraCheckEditor11.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor11.Location = new System.Drawing.Point(24, 72);
			this.ultraCheckEditor11.Name = "ultraCheckEditor11";
			this.ultraCheckEditor11.TabIndex = 1;
			this.ultraCheckEditor11.Text = "会员档案修改";
			// 
			// ultraCheckEditor12
			// 
			this.ultraCheckEditor12.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor12.Location = new System.Drawing.Point(24, 144);
			this.ultraCheckEditor12.Name = "ultraCheckEditor12";
			this.ultraCheckEditor12.TabIndex = 0;
			this.ultraCheckEditor12.Text = "非会员档案修改";
			// 
			// ultraCheckEditor20
			// 
			this.ultraCheckEditor20.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor20.Location = new System.Drawing.Point(24, 120);
			this.ultraCheckEditor20.Name = "ultraCheckEditor20";
			this.ultraCheckEditor20.TabIndex = 5;
			this.ultraCheckEditor20.Text = "添加非会员信息";
			// 
			// ultraCheckEditor56
			// 
			this.ultraCheckEditor56.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor56.Location = new System.Drawing.Point(24, 24);
			this.ultraCheckEditor56.Name = "ultraCheckEditor56";
			this.ultraCheckEditor56.TabIndex = 6;
			this.ultraCheckEditor56.Text = "发卡";
			// 
			// ultraCheckEditor10
			// 
			this.ultraCheckEditor10.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor10.Location = new System.Drawing.Point(24, 80);
			this.ultraCheckEditor10.Name = "ultraCheckEditor10";
			this.ultraCheckEditor10.TabIndex = 2;
			this.ultraCheckEditor10.Text = "会员参数设置";
			// 
			// ultraGroupBox3
			// 
			this.ultraGroupBox3.Controls.Add(this.ultraCheckEditor13);
			this.ultraGroupBox3.Controls.Add(this.ultraCheckEditor14);
			this.ultraGroupBox3.Controls.Add(this.ultraCheckEditor15);
			this.ultraGroupBox3.Location = new System.Drawing.Point(216, 24);
			this.ultraGroupBox3.Name = "ultraGroupBox3";
			this.ultraGroupBox3.Size = new System.Drawing.Size(168, 112);
			this.ultraGroupBox3.TabIndex = 2;
			this.ultraGroupBox3.Text = "招聘会管理";
			// 
			// ultraCheckEditor13
			// 
			this.ultraCheckEditor13.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor13.Location = new System.Drawing.Point(24, 80);
			this.ultraCheckEditor13.Name = "ultraCheckEditor13";
			this.ultraCheckEditor13.TabIndex = 2;
			this.ultraCheckEditor13.Text = "招聘会信息查询";
			// 
			// ultraCheckEditor14
			// 
			this.ultraCheckEditor14.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor14.Location = new System.Drawing.Point(24, 56);
			this.ultraCheckEditor14.Name = "ultraCheckEditor14";
			this.ultraCheckEditor14.TabIndex = 1;
			this.ultraCheckEditor14.Text = "招聘会信息修改";
			// 
			// ultraCheckEditor15
			// 
			this.ultraCheckEditor15.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor15.Location = new System.Drawing.Point(24, 32);
			this.ultraCheckEditor15.Name = "ultraCheckEditor15";
			this.ultraCheckEditor15.TabIndex = 0;
			this.ultraCheckEditor15.Text = "招聘会新设";
			// 
			// ultraGroupBox4
			// 
			this.ultraGroupBox4.Controls.Add(this.ultraCheckEditor68);
			this.ultraGroupBox4.Controls.Add(this.ultraCheckEditor55);
			this.ultraGroupBox4.Controls.Add(this.ultraCheckEditor51);
			this.ultraGroupBox4.Controls.Add(this.ultraCheckEditor8);
			this.ultraGroupBox4.Controls.Add(this.ultraCheckEditor16);
			this.ultraGroupBox4.Controls.Add(this.ultraCheckEditor17);
			this.ultraGroupBox4.Controls.Add(this.ultraCheckEditor19);
			this.ultraGroupBox4.Location = new System.Drawing.Point(24, 400);
			this.ultraGroupBox4.Name = "ultraGroupBox4";
			this.ultraGroupBox4.Size = new System.Drawing.Size(168, 208);
			this.ultraGroupBox4.TabIndex = 3;
			this.ultraGroupBox4.Text = "展位管理";
			// 
			// ultraCheckEditor68
			// 
			this.ultraCheckEditor68.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor68.Location = new System.Drawing.Point(24, 152);
			this.ultraCheckEditor68.Name = "ultraCheckEditor68";
			this.ultraCheckEditor68.TabIndex = 7;
			this.ultraCheckEditor68.Text = "批量签到";
			// 
			// ultraCheckEditor55
			// 
			this.ultraCheckEditor55.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor55.Location = new System.Drawing.Point(24, 56);
			this.ultraCheckEditor55.Name = "ultraCheckEditor55";
			this.ultraCheckEditor55.TabIndex = 6;
			this.ultraCheckEditor55.Text = "批量取消预订";
			// 
			// ultraCheckEditor51
			// 
			this.ultraCheckEditor51.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor51.Location = new System.Drawing.Point(24, 176);
			this.ultraCheckEditor51.Name = "ultraCheckEditor51";
			this.ultraCheckEditor51.TabIndex = 5;
			this.ultraCheckEditor51.Text = "服务产品消费";
			// 
			// ultraCheckEditor8
			// 
			this.ultraCheckEditor8.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor8.Location = new System.Drawing.Point(24, 128);
			this.ultraCheckEditor8.Name = "ultraCheckEditor8";
			this.ultraCheckEditor8.TabIndex = 4;
			this.ultraCheckEditor8.Text = "展位签到";
			// 
			// ultraCheckEditor16
			// 
			this.ultraCheckEditor16.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor16.Location = new System.Drawing.Point(24, 104);
			this.ultraCheckEditor16.Name = "ultraCheckEditor16";
			this.ultraCheckEditor16.TabIndex = 3;
			this.ultraCheckEditor16.Text = "展位预留";
			// 
			// ultraCheckEditor17
			// 
			this.ultraCheckEditor17.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor17.Location = new System.Drawing.Point(24, 80);
			this.ultraCheckEditor17.Name = "ultraCheckEditor17";
			this.ultraCheckEditor17.TabIndex = 2;
			this.ultraCheckEditor17.Text = "展位预订";
			// 
			// ultraCheckEditor19
			// 
			this.ultraCheckEditor19.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor19.Location = new System.Drawing.Point(24, 32);
			this.ultraCheckEditor19.Name = "ultraCheckEditor19";
			this.ultraCheckEditor19.Size = new System.Drawing.Size(160, 20);
			this.ultraCheckEditor19.TabIndex = 0;
			this.ultraCheckEditor19.Text = "招聘会展位方案设置";
			// 
			// ultraCheckEditor38
			// 
			this.ultraCheckEditor38.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor38.Location = new System.Drawing.Point(24, 72);
			this.ultraCheckEditor38.Name = "ultraCheckEditor38";
			this.ultraCheckEditor38.TabIndex = 8;
			this.ultraCheckEditor38.Text = "小票重打";
			// 
			// ultraCheckEditor25
			// 
			this.ultraCheckEditor25.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor25.Location = new System.Drawing.Point(24, 48);
			this.ultraCheckEditor25.Name = "ultraCheckEditor25";
			this.ultraCheckEditor25.TabIndex = 7;
			this.ultraCheckEditor25.Text = "退费";
			// 
			// ultraCheckEditor21
			// 
			this.ultraCheckEditor21.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor21.Location = new System.Drawing.Point(24, 24);
			this.ultraCheckEditor21.Name = "ultraCheckEditor21";
			this.ultraCheckEditor21.TabIndex = 6;
			this.ultraCheckEditor21.Text = "缴费";
			// 
			// ultraGroupBox5
			// 
			this.ultraGroupBox5.Controls.Add(this.ultraCheckEditor22);
			this.ultraGroupBox5.Controls.Add(this.ultraCheckEditor23);
			this.ultraGroupBox5.Controls.Add(this.ultraCheckEditor24);
			this.ultraGroupBox5.Controls.Add(this.ultraCheckEditor10);
			this.ultraGroupBox5.Location = new System.Drawing.Point(656, 224);
			this.ultraGroupBox5.Name = "ultraGroupBox5";
			this.ultraGroupBox5.Size = new System.Drawing.Size(192, 136);
			this.ultraGroupBox5.TabIndex = 4;
			this.ultraGroupBox5.Text = "系统管理";
			// 
			// ultraCheckEditor22
			// 
			this.ultraCheckEditor22.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor22.Location = new System.Drawing.Point(24, 104);
			this.ultraCheckEditor22.Name = "ultraCheckEditor22";
			this.ultraCheckEditor22.TabIndex = 2;
			this.ultraCheckEditor22.Text = "权限管理";
			// 
			// ultraCheckEditor23
			// 
			this.ultraCheckEditor23.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor23.Location = new System.Drawing.Point(24, 56);
			this.ultraCheckEditor23.Name = "ultraCheckEditor23";
			this.ultraCheckEditor23.TabIndex = 1;
			this.ultraCheckEditor23.Text = "操作员卡回收";
			// 
			// ultraCheckEditor24
			// 
			this.ultraCheckEditor24.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor24.Location = new System.Drawing.Point(24, 32);
			this.ultraCheckEditor24.Name = "ultraCheckEditor24";
			this.ultraCheckEditor24.TabIndex = 0;
			this.ultraCheckEditor24.Text = "部门管理";
			// 
			// ultraGroupBox6
			// 
			this.ultraGroupBox6.Controls.Add(this.cmbOper);
			this.ultraGroupBox6.Location = new System.Drawing.Point(656, 360);
			this.ultraGroupBox6.Name = "ultraGroupBox6";
			this.ultraGroupBox6.Size = new System.Drawing.Size(160, 128);
			this.ultraGroupBox6.TabIndex = 5;
			this.ultraGroupBox6.Text = "操作员列表";
			// 
			// cmbOper
			// 
			this.cmbOper.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			this.cmbOper.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.cmbOper.Location = new System.Drawing.Point(8, 56);
			this.cmbOper.Name = "cmbOper";
			this.cmbOper.TabIndex = 0;
			this.cmbOper.ValueChanged += new System.EventHandler(this.cmbOper_ValueChanged);
			// 
			// btnCance
			// 
			this.btnCance.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnCance.Location = new System.Drawing.Point(48, 80);
			this.btnCance.Name = "btnCance";
			this.btnCance.TabIndex = 7;
			this.btnCance.Text = "取消";
			this.btnCance.Click += new System.EventHandler(this.btnCance_Click);
			// 
			// btnModify
			// 
			this.btnModify.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
			this.btnModify.Location = new System.Drawing.Point(48, 40);
			this.btnModify.Name = "btnModify";
			this.btnModify.TabIndex = 8;
			this.btnModify.Text = "保存";
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			// 
			// ultraGroupBox7
			// 
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor65);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor9);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor18);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor42);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor43);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor44);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor45);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor35);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor36);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor37);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor32);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor33);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor34);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor30);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor31);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor28);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor29);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor26);
			this.ultraGroupBox7.Controls.Add(this.ultraCheckEditor27);
			this.ultraGroupBox7.Location = new System.Drawing.Point(216, 144);
			this.ultraGroupBox7.Name = "ultraGroupBox7";
			this.ultraGroupBox7.Size = new System.Drawing.Size(168, 480);
			this.ultraGroupBox7.TabIndex = 9;
			this.ultraGroupBox7.Text = "报表";
			// 
			// ultraCheckEditor65
			// 
			this.ultraCheckEditor65.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor65.Location = new System.Drawing.Point(24, 96);
			this.ultraCheckEditor65.Name = "ultraCheckEditor65";
			this.ultraCheckEditor65.TabIndex = 21;
			this.ultraCheckEditor65.Text = "会员档案报表修改";
			// 
			// ultraCheckEditor9
			// 
			this.ultraCheckEditor9.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor9.Location = new System.Drawing.Point(24, 168);
			this.ultraCheckEditor9.Name = "ultraCheckEditor9";
			this.ultraCheckEditor9.Size = new System.Drawing.Size(136, 20);
			this.ultraCheckEditor9.TabIndex = 20;
			this.ultraCheckEditor9.Text = "非会员档案报表打印";
			// 
			// ultraCheckEditor18
			// 
			this.ultraCheckEditor18.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor18.Location = new System.Drawing.Point(24, 144);
			this.ultraCheckEditor18.Name = "ultraCheckEditor18";
			this.ultraCheckEditor18.Size = new System.Drawing.Size(136, 20);
			this.ultraCheckEditor18.TabIndex = 19;
			this.ultraCheckEditor18.Text = "非会员档案报表查询";
			// 
			// ultraCheckEditor42
			// 
			this.ultraCheckEditor42.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor42.Location = new System.Drawing.Point(24, 120);
			this.ultraCheckEditor42.Name = "ultraCheckEditor42";
			this.ultraCheckEditor42.TabIndex = 18;
			this.ultraCheckEditor42.Text = "非会员档案报表";
			// 
			// ultraCheckEditor43
			// 
			this.ultraCheckEditor43.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor43.Location = new System.Drawing.Point(24, 72);
			this.ultraCheckEditor43.Name = "ultraCheckEditor43";
			this.ultraCheckEditor43.TabIndex = 17;
			this.ultraCheckEditor43.Text = "会员档案报表打印";
			// 
			// ultraCheckEditor44
			// 
			this.ultraCheckEditor44.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor44.Location = new System.Drawing.Point(24, 48);
			this.ultraCheckEditor44.Name = "ultraCheckEditor44";
			this.ultraCheckEditor44.TabIndex = 16;
			this.ultraCheckEditor44.Text = "会员档案报表查询";
			// 
			// ultraCheckEditor45
			// 
			this.ultraCheckEditor45.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor45.Location = new System.Drawing.Point(24, 24);
			this.ultraCheckEditor45.Name = "ultraCheckEditor45";
			this.ultraCheckEditor45.TabIndex = 15;
			this.ultraCheckEditor45.Text = "会员档案报表";
			// 
			// ultraCheckEditor35
			// 
			this.ultraCheckEditor35.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor35.Location = new System.Drawing.Point(24, 456);
			this.ultraCheckEditor35.Name = "ultraCheckEditor35";
			this.ultraCheckEditor35.TabIndex = 11;
			this.ultraCheckEditor35.Text = "取消预订报表打印";
			// 
			// ultraCheckEditor36
			// 
			this.ultraCheckEditor36.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor36.Location = new System.Drawing.Point(24, 432);
			this.ultraCheckEditor36.Name = "ultraCheckEditor36";
			this.ultraCheckEditor36.TabIndex = 10;
			this.ultraCheckEditor36.Text = "取消预订报表查询";
			// 
			// ultraCheckEditor37
			// 
			this.ultraCheckEditor37.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor37.Location = new System.Drawing.Point(24, 408);
			this.ultraCheckEditor37.Name = "ultraCheckEditor37";
			this.ultraCheckEditor37.TabIndex = 9;
			this.ultraCheckEditor37.Text = "取消预订报表";
			// 
			// ultraCheckEditor32
			// 
			this.ultraCheckEditor32.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor32.Location = new System.Drawing.Point(24, 384);
			this.ultraCheckEditor32.Name = "ultraCheckEditor32";
			this.ultraCheckEditor32.TabIndex = 8;
			this.ultraCheckEditor32.Text = "预订报表打印";
			// 
			// ultraCheckEditor33
			// 
			this.ultraCheckEditor33.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor33.Location = new System.Drawing.Point(24, 360);
			this.ultraCheckEditor33.Name = "ultraCheckEditor33";
			this.ultraCheckEditor33.TabIndex = 7;
			this.ultraCheckEditor33.Text = "预订报表查询";
			// 
			// ultraCheckEditor34
			// 
			this.ultraCheckEditor34.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor34.Location = new System.Drawing.Point(24, 336);
			this.ultraCheckEditor34.Name = "ultraCheckEditor34";
			this.ultraCheckEditor34.TabIndex = 6;
			this.ultraCheckEditor34.Text = "预订报表";
			// 
			// ultraCheckEditor30
			// 
			this.ultraCheckEditor30.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor30.Location = new System.Drawing.Point(24, 312);
			this.ultraCheckEditor30.Name = "ultraCheckEditor30";
			this.ultraCheckEditor30.TabIndex = 5;
			this.ultraCheckEditor30.Text = "展位调整报表打印";
			// 
			// ultraCheckEditor31
			// 
			this.ultraCheckEditor31.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor31.Location = new System.Drawing.Point(24, 288);
			this.ultraCheckEditor31.Name = "ultraCheckEditor31";
			this.ultraCheckEditor31.TabIndex = 4;
			this.ultraCheckEditor31.Text = "展位调整报表查询";
			// 
			// ultraCheckEditor28
			// 
			this.ultraCheckEditor28.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor28.Location = new System.Drawing.Point(24, 264);
			this.ultraCheckEditor28.Name = "ultraCheckEditor28";
			this.ultraCheckEditor28.TabIndex = 3;
			this.ultraCheckEditor28.Text = "展位调整报表";
			// 
			// ultraCheckEditor29
			// 
			this.ultraCheckEditor29.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor29.Location = new System.Drawing.Point(24, 240);
			this.ultraCheckEditor29.Name = "ultraCheckEditor29";
			this.ultraCheckEditor29.TabIndex = 2;
			this.ultraCheckEditor29.Text = "签到报表打印";
			// 
			// ultraCheckEditor26
			// 
			this.ultraCheckEditor26.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor26.Location = new System.Drawing.Point(24, 216);
			this.ultraCheckEditor26.Name = "ultraCheckEditor26";
			this.ultraCheckEditor26.TabIndex = 1;
			this.ultraCheckEditor26.Text = "签到报表查询";
			// 
			// ultraCheckEditor27
			// 
			this.ultraCheckEditor27.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor27.Location = new System.Drawing.Point(24, 192);
			this.ultraCheckEditor27.Name = "ultraCheckEditor27";
			this.ultraCheckEditor27.TabIndex = 0;
			this.ultraCheckEditor27.Text = "签到报表";
			// 
			// ultraCheckEditor39
			// 
			this.ultraCheckEditor39.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor39.Location = new System.Drawing.Point(16, 72);
			this.ultraCheckEditor39.Name = "ultraCheckEditor39";
			this.ultraCheckEditor39.TabIndex = 14;
			this.ultraCheckEditor39.Text = "缴费报表打印";
			// 
			// ultraCheckEditor40
			// 
			this.ultraCheckEditor40.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor40.Location = new System.Drawing.Point(16, 48);
			this.ultraCheckEditor40.Name = "ultraCheckEditor40";
			this.ultraCheckEditor40.TabIndex = 13;
			this.ultraCheckEditor40.Text = "缴费报表查询";
			// 
			// ultraCheckEditor41
			// 
			this.ultraCheckEditor41.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor41.Location = new System.Drawing.Point(16, 24);
			this.ultraCheckEditor41.Name = "ultraCheckEditor41";
			this.ultraCheckEditor41.TabIndex = 12;
			this.ultraCheckEditor41.Text = "缴费报表";
			// 
			// ultraCheckEditor46
			// 
			this.ultraCheckEditor46.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor46.Location = new System.Drawing.Point(16, 144);
			this.ultraCheckEditor46.Name = "ultraCheckEditor46";
			this.ultraCheckEditor46.TabIndex = 23;
			this.ultraCheckEditor46.Text = "充值报表打印";
			// 
			// ultraCheckEditor47
			// 
			this.ultraCheckEditor47.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor47.Location = new System.Drawing.Point(16, 120);
			this.ultraCheckEditor47.Name = "ultraCheckEditor47";
			this.ultraCheckEditor47.TabIndex = 22;
			this.ultraCheckEditor47.Text = "充值报表查询";
			// 
			// ultraCheckEditor48
			// 
			this.ultraCheckEditor48.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor48.Location = new System.Drawing.Point(16, 96);
			this.ultraCheckEditor48.Name = "ultraCheckEditor48";
			this.ultraCheckEditor48.TabIndex = 21;
			this.ultraCheckEditor48.Text = "充值报表";
			// 
			// ultraGroupBox8
			// 
			this.ultraGroupBox8.Controls.Add(this.btnModify);
			this.ultraGroupBox8.Controls.Add(this.btnCance);
			this.ultraGroupBox8.Location = new System.Drawing.Point(656, 504);
			this.ultraGroupBox8.Name = "ultraGroupBox8";
			this.ultraGroupBox8.Size = new System.Drawing.Size(160, 112);
			this.ultraGroupBox8.TabIndex = 10;
			this.ultraGroupBox8.Text = "操作";
			// 
			// ultraGroupBox9
			// 
			this.ultraGroupBox9.Controls.Add(this.ultraCheckEditor25);
			this.ultraGroupBox9.Controls.Add(this.ultraCheckEditor21);
			this.ultraGroupBox9.Controls.Add(this.ultraCheckEditor38);
			this.ultraGroupBox9.Location = new System.Drawing.Point(664, 24);
			this.ultraGroupBox9.Name = "ultraGroupBox9";
			this.ultraGroupBox9.Size = new System.Drawing.Size(208, 96);
			this.ultraGroupBox9.TabIndex = 11;
			this.ultraGroupBox9.Text = "费用管理";
			// 
			// ultraGroupBox10
			// 
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor69);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor70);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor71);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor66);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor60);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor61);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor62);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor57);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor58);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor59);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor52);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor53);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor54);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor7);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor49);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor50);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor46);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor47);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor48);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor41);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor39);
			this.ultraGroupBox10.Controls.Add(this.ultraCheckEditor40);
			this.ultraGroupBox10.Location = new System.Drawing.Point(408, 16);
			this.ultraGroupBox10.Name = "ultraGroupBox10";
			this.ultraGroupBox10.Size = new System.Drawing.Size(216, 600);
			this.ultraGroupBox10.TabIndex = 12;
			this.ultraGroupBox10.Text = "报表";
			// 
			// ultraCheckEditor69
			// 
			this.ultraCheckEditor69.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor69.Location = new System.Drawing.Point(16, 528);
			this.ultraCheckEditor69.Name = "ultraCheckEditor69";
			this.ultraCheckEditor69.Size = new System.Drawing.Size(176, 20);
			this.ultraCheckEditor69.TabIndex = 39;
			this.ultraCheckEditor69.Text = "预留报表打印";
			// 
			// ultraCheckEditor70
			// 
			this.ultraCheckEditor70.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor70.Location = new System.Drawing.Point(16, 504);
			this.ultraCheckEditor70.Name = "ultraCheckEditor70";
			this.ultraCheckEditor70.Size = new System.Drawing.Size(184, 20);
			this.ultraCheckEditor70.TabIndex = 38;
			this.ultraCheckEditor70.Text = "预留报表查询";
			// 
			// ultraCheckEditor71
			// 
			this.ultraCheckEditor71.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor71.Location = new System.Drawing.Point(16, 480);
			this.ultraCheckEditor71.Name = "ultraCheckEditor71";
			this.ultraCheckEditor71.Size = new System.Drawing.Size(152, 20);
			this.ultraCheckEditor71.TabIndex = 37;
			this.ultraCheckEditor71.Text = "预留报表";
			// 
			// ultraCheckEditor66
			// 
			this.ultraCheckEditor66.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor66.Location = new System.Drawing.Point(16, 456);
			this.ultraCheckEditor66.Name = "ultraCheckEditor66";
			this.ultraCheckEditor66.Size = new System.Drawing.Size(176, 20);
			this.ultraCheckEditor66.TabIndex = 36;
			this.ultraCheckEditor66.Text = "客服会员报表";
			// 
			// ultraCheckEditor60
			// 
			this.ultraCheckEditor60.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor60.Location = new System.Drawing.Point(16, 432);
			this.ultraCheckEditor60.Name = "ultraCheckEditor60";
			this.ultraCheckEditor60.Size = new System.Drawing.Size(176, 20);
			this.ultraCheckEditor60.TabIndex = 35;
			this.ultraCheckEditor60.Text = "收入报表打印";
			// 
			// ultraCheckEditor61
			// 
			this.ultraCheckEditor61.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor61.Location = new System.Drawing.Point(16, 408);
			this.ultraCheckEditor61.Name = "ultraCheckEditor61";
			this.ultraCheckEditor61.Size = new System.Drawing.Size(184, 20);
			this.ultraCheckEditor61.TabIndex = 34;
			this.ultraCheckEditor61.Text = "收入报表查询";
			// 
			// ultraCheckEditor62
			// 
			this.ultraCheckEditor62.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor62.Location = new System.Drawing.Point(16, 384);
			this.ultraCheckEditor62.Name = "ultraCheckEditor62";
			this.ultraCheckEditor62.Size = new System.Drawing.Size(152, 20);
			this.ultraCheckEditor62.TabIndex = 33;
			this.ultraCheckEditor62.Text = "收入报表";
			// 
			// ultraCheckEditor57
			// 
			this.ultraCheckEditor57.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor57.Location = new System.Drawing.Point(16, 360);
			this.ultraCheckEditor57.Name = "ultraCheckEditor57";
			this.ultraCheckEditor57.Size = new System.Drawing.Size(176, 20);
			this.ultraCheckEditor57.TabIndex = 32;
			this.ultraCheckEditor57.Text = "服务产品充值缴费报表打印";
			// 
			// ultraCheckEditor58
			// 
			this.ultraCheckEditor58.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor58.Location = new System.Drawing.Point(16, 336);
			this.ultraCheckEditor58.Name = "ultraCheckEditor58";
			this.ultraCheckEditor58.Size = new System.Drawing.Size(184, 20);
			this.ultraCheckEditor58.TabIndex = 31;
			this.ultraCheckEditor58.Text = "服务产品充值缴费报表查询";
			// 
			// ultraCheckEditor59
			// 
			this.ultraCheckEditor59.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor59.Location = new System.Drawing.Point(16, 312);
			this.ultraCheckEditor59.Name = "ultraCheckEditor59";
			this.ultraCheckEditor59.Size = new System.Drawing.Size(152, 20);
			this.ultraCheckEditor59.TabIndex = 30;
			this.ultraCheckEditor59.Text = "服务产品充值缴费报表";
			// 
			// ultraCheckEditor52
			// 
			this.ultraCheckEditor52.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor52.Location = new System.Drawing.Point(16, 288);
			this.ultraCheckEditor52.Name = "ultraCheckEditor52";
			this.ultraCheckEditor52.Size = new System.Drawing.Size(152, 20);
			this.ultraCheckEditor52.TabIndex = 29;
			this.ultraCheckEditor52.Text = "服务产品消费报表打印";
			// 
			// ultraCheckEditor53
			// 
			this.ultraCheckEditor53.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor53.Location = new System.Drawing.Point(16, 264);
			this.ultraCheckEditor53.Name = "ultraCheckEditor53";
			this.ultraCheckEditor53.Size = new System.Drawing.Size(152, 20);
			this.ultraCheckEditor53.TabIndex = 28;
			this.ultraCheckEditor53.Text = "服务产品消费报表查询";
			// 
			// ultraCheckEditor54
			// 
			this.ultraCheckEditor54.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor54.Location = new System.Drawing.Point(16, 240);
			this.ultraCheckEditor54.Name = "ultraCheckEditor54";
			this.ultraCheckEditor54.TabIndex = 27;
			this.ultraCheckEditor54.Text = "服务产品消费报表";
			// 
			// ultraCheckEditor7
			// 
			this.ultraCheckEditor7.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor7.Location = new System.Drawing.Point(16, 216);
			this.ultraCheckEditor7.Name = "ultraCheckEditor7";
			this.ultraCheckEditor7.TabIndex = 26;
			this.ultraCheckEditor7.Text = "操作日志报表打印";
			// 
			// ultraCheckEditor49
			// 
			this.ultraCheckEditor49.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor49.Location = new System.Drawing.Point(16, 192);
			this.ultraCheckEditor49.Name = "ultraCheckEditor49";
			this.ultraCheckEditor49.TabIndex = 25;
			this.ultraCheckEditor49.Text = "操作日志报表查询";
			// 
			// ultraCheckEditor50
			// 
			this.ultraCheckEditor50.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor50.Location = new System.Drawing.Point(16, 168);
			this.ultraCheckEditor50.Name = "ultraCheckEditor50";
			this.ultraCheckEditor50.TabIndex = 24;
			this.ultraCheckEditor50.Text = "操作日志报表";
			// 
			// ultraGroupBox11
			// 
			this.ultraGroupBox11.Controls.Add(this.ultraCheckEditor63);
			this.ultraGroupBox11.Controls.Add(this.ultraCheckEditor64);
			this.ultraGroupBox11.Location = new System.Drawing.Point(656, 136);
			this.ultraGroupBox11.Name = "ultraGroupBox11";
			this.ultraGroupBox11.Size = new System.Drawing.Size(160, 80);
			this.ultraGroupBox11.TabIndex = 13;
			this.ultraGroupBox11.Text = "其它";
			// 
			// ultraCheckEditor63
			// 
			this.ultraCheckEditor63.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor63.Location = new System.Drawing.Point(24, 48);
			this.ultraCheckEditor63.Name = "ultraCheckEditor63";
			this.ultraCheckEditor63.TabIndex = 7;
			this.ultraCheckEditor63.Text = "换位";
			// 
			// ultraCheckEditor64
			// 
			this.ultraCheckEditor64.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor64.Location = new System.Drawing.Point(24, 24);
			this.ultraCheckEditor64.Name = "ultraCheckEditor64";
			this.ultraCheckEditor64.TabIndex = 6;
			this.ultraCheckEditor64.Text = "释放";
			// 
			// ultraCheckEditor72
			// 
			this.ultraCheckEditor72.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
			this.ultraCheckEditor72.Location = new System.Drawing.Point(24, 48);
			this.ultraCheckEditor72.Name = "ultraCheckEditor72";
			this.ultraCheckEditor72.TabIndex = 8;
			this.ultraCheckEditor72.Text = "删除未发卡会员";
			// 
			// RightManage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(952, 637);
			this.Controls.Add(this.ultraGroupBox11);
			this.Controls.Add(this.ultraGroupBox10);
			this.Controls.Add(this.ultraGroupBox9);
			this.Controls.Add(this.ultraGroupBox8);
			this.Controls.Add(this.ultraGroupBox7);
			this.Controls.Add(this.ultraGroupBox6);
			this.Controls.Add(this.ultraGroupBox5);
			this.Controls.Add(this.ultraGroupBox4);
			this.Controls.Add(this.ultraGroupBox3);
			this.Controls.Add(this.ultraGroupBox2);
			this.Controls.Add(this.ultraGroupBox1);
			this.Name = "RightManage";
			this.Text = "权限管理";
			this.Load += new System.EventHandler(this.RightManage_Load);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
			this.ultraGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
			this.ultraGroupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
			this.ultraGroupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).EndInit();
			this.ultraGroupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).EndInit();
			this.ultraGroupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox6)).EndInit();
			this.ultraGroupBox6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbOper)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox7)).EndInit();
			this.ultraGroupBox7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox8)).EndInit();
			this.ultraGroupBox8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox9)).EndInit();
			this.ultraGroupBox9.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox10)).EndInit();
			this.ultraGroupBox10.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox11)).EndInit();
			this.ultraGroupBox11.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void RightManage_Load(object sender, System.EventArgs e)
		{
			//绑定操作员列表
			
			try
			{
				SecurityManage secruty = new SecurityManage();
				DataTable dtOper = secruty.getAllOperNoSys(ClientHelper.oper);
				cmbOper.DataSource = dtOper;
				cmbOper.ValueMember = "cnnOperID";
				cmbOper.DisplayMember = "cnvcOperName";
				cmbOper.DataBind();
				cmbOper.SelectedIndex = 0;

				if (ClientHelper.dept.cnnDeptID != 0)
				{
					DataTable dtFunc = secruty.QueryOperFunc(ClientHelper.oper.cnnOperID);
					ArrayList alFunc = new ArrayList();
					foreach (DataRow drFunc in dtFunc.Rows)
					{
						OperFunc func = new OperFunc(drFunc);
						alFunc.Add(func.cnvcFuncCode);
					}
					foreach (Control box in this.Controls)
					{
						if (box is UltraGroupBox)
						{
							UltraGroupBox ultraBox = box as UltraGroupBox;
							foreach (Control ctrl in ultraBox.Controls)
							{
								if (ctrl is UltraCheckEditor)
								{
									UltraCheckEditor chk = ctrl as UltraCheckEditor;
									if (!alFunc.Contains(chk.Text))
									{	
										chk.Visible = false;
									}
								}
							}
						}
					}										
				}
			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		
		private void btnCance_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmbOper_ValueChanged(object sender, System.EventArgs e)
		{
			//
			BindRightList();
		}

		private void getRightList()
		{
			alOperFuncList.Clear();
			foreach (Control box in this.Controls)
			{
				if (box is UltraGroupBox)
				{
					UltraGroupBox ultraBox = box as UltraGroupBox;
					foreach (Control ctrl in ultraBox.Controls)
					{
						if (ctrl is UltraCheckEditor)
						{
							UltraCheckEditor chk = ctrl as UltraCheckEditor;
							if (chk.Checked)
							{
								alOperFuncList.Add(chk.Text);
							}
						}
					}
				}
			}
		}

		private void InitChk()
		{
			foreach (Control box in this.Controls)
			{
				if (box is UltraGroupBox)
				{
					UltraGroupBox ultraBox = box as UltraGroupBox;
					foreach (Control ctrl in ultraBox.Controls)
					{
						if (ctrl is UltraCheckEditor)
						{
							UltraCheckEditor chk = ctrl as UltraCheckEditor;
							chk.Checked = false;
						}
					}
				}
			}
		}

		private void BindRightList()
		{
			try
			{
				//getRightList();
				InitChk();
				SecurityManage security = new SecurityManage();
				int iOperID = int.Parse(cmbOper.SelectedItem.DataValue.ToString());

				DataTable dtOperFunc = security.QueryOperFunc(iOperID);
				foreach (DataRow drOperFunc in dtOperFunc.Rows)
				{
					OperFunc func = new OperFunc(drOperFunc);
					foreach (Control box in this.Controls)
					{
						if (box is UltraGroupBox)
						{
							UltraGroupBox ultraBox = box as UltraGroupBox;
							foreach (Control ctrl in ultraBox.Controls)
							{
								if (ctrl is UltraCheckEditor)
								{
									UltraCheckEditor chk = ctrl as UltraCheckEditor;
									if (chk.Text == func.cnvcFuncCode)
									{
										chk.Checked = true;
									}
								}
							}
						}
					}					

				}
				//MessageBox.Show(this,"权限添加成功！","权限管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				getRightList();
				SecurityManage security = new SecurityManage();
				int iOperID = int.Parse(cmbOper.SelectedItem.DataValue.ToString());
				security.AddOperFunc(alOperFuncList,iOperID);
				MessageBox.Show(this,"权限添加成功！","权限管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void btnModify_Click(object sender, System.EventArgs e)
		{
			//修改
			try
			{
				getRightList();
				SecurityManage security = new SecurityManage();
				int iOperID = int.Parse(cmbOper.SelectedItem.DataValue.ToString());
				security.ModifyOperFunc(alOperFuncList,iOperID);
				MessageBox.Show(this,"权限保存成功！","权限管理",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			catch (BusinessException bex)
			{
				MessageBox.Show(this, bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(this,ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
	}
}
