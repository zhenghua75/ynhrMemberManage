using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Infragistics.Shared; 
using Infragistics.Win; 
using Infragistics.Win.UltraWinGrid; 
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using ynhrMemberManage.Common;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Print;
namespace MemberManage.Business
{
	/// <summary>
	/// Summary description for ShowRemain.
	/// </summary>
    public class ShowRemain : frmBase
	{
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraButton btnLoadSeat;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbFloor;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbShow;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSeat;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraButton btnRemain;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Infragistics.Win.Misc.UltraButton btnCancelRemain;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Infragistics.Win.Misc.UltraButton btnHold;

		public static bool IsShowing ;

		public ShowRemain()
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnLoadSeat = new Infragistics.Win.Misc.UltraButton();
            this.cmbFloor = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbShow = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnHold = new Infragistics.Win.Misc.UltraButton();
            this.btnCancelRemain = new Infragistics.Win.Misc.UltraButton();
            this.txtSeat = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.btnRemain = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeat)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.btnLoadSeat);
            this.ultraGroupBox1.Controls.Add(this.cmbFloor);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox1.Controls.Add(this.cmbShow);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(736, 80);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(280, 168);
            this.ultraGroupBox1.TabIndex = 13;
            this.ultraGroupBox1.Text = "座位";
            // 
            // btnLoadSeat
            // 
            this.btnLoadSeat.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnLoadSeat.Location = new System.Drawing.Point(104, 128);
            this.btnLoadSeat.Name = "btnLoadSeat";
            this.btnLoadSeat.Size = new System.Drawing.Size(75, 23);
            this.btnLoadSeat.TabIndex = 6;
            this.btnLoadSeat.Text = "导入座位图";
            this.btnLoadSeat.Click += new System.EventHandler(this.btnLoadSeat_Click);
            // 
            // cmbFloor
            // 
            this.cmbFloor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbFloor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = "ValueListItem0";
            valueListItem1.DisplayText = "2";
            valueListItem2.DataValue = "ValueListItem1";
            valueListItem2.DisplayText = "3";
            this.cmbFloor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.cmbFloor.Location = new System.Drawing.Point(128, 80);
            this.cmbFloor.Name = "cmbFloor";
            this.cmbFloor.Size = new System.Drawing.Size(144, 21);
            this.cmbFloor.TabIndex = 4;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(24, 80);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel2.TabIndex = 3;
            this.ultraLabel2.Text = "展厅：";
            // 
            // cmbShow
            // 
            this.cmbShow.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cmbShow.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbShow.Location = new System.Drawing.Point(128, 32);
            this.cmbShow.Name = "cmbShow";
            this.cmbShow.Size = new System.Drawing.Size(144, 21);
            this.cmbShow.TabIndex = 1;
            this.cmbShow.ValueChanged += new System.EventHandler(this.cmbShow_ValueChanged);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(24, 32);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 2;
            this.ultraLabel1.Text = "招聘会：";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.btnHold);
            this.ultraGroupBox2.Controls.Add(this.btnCancelRemain);
            this.ultraGroupBox2.Controls.Add(this.txtSeat);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox2.Controls.Add(this.btnRemain);
            this.ultraGroupBox2.Location = new System.Drawing.Point(736, 264);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(280, 136);
            this.ultraGroupBox2.TabIndex = 14;
            // 
            // btnHold
            // 
            this.btnHold.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnHold.Location = new System.Drawing.Point(184, 88);
            this.btnHold.Name = "btnHold";
            this.btnHold.Size = new System.Drawing.Size(75, 23);
            this.btnHold.TabIndex = 10;
            this.btnHold.Text = "占位";
            this.btnHold.Click += new System.EventHandler(this.btnHold_Click);
            // 
            // btnCancelRemain
            // 
            this.btnCancelRemain.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnCancelRemain.Location = new System.Drawing.Point(104, 88);
            this.btnCancelRemain.Name = "btnCancelRemain";
            this.btnCancelRemain.Size = new System.Drawing.Size(75, 23);
            this.btnCancelRemain.TabIndex = 9;
            this.btnCancelRemain.Text = "取消预留";
            this.btnCancelRemain.Click += new System.EventHandler(this.btnCancelRemain_Click);
            // 
            // txtSeat
            // 
            this.txtSeat.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.txtSeat.Location = new System.Drawing.Point(152, 32);
            this.txtSeat.Name = "txtSeat";
            this.txtSeat.Size = new System.Drawing.Size(100, 21);
            this.txtSeat.TabIndex = 8;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(24, 32);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 7;
            this.ultraLabel3.Text = "选定的座位：";
            // 
            // btnRemain
            // 
            this.btnRemain.ButtonStyle = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
            this.btnRemain.Location = new System.Drawing.Point(24, 88);
            this.btnRemain.Name = "btnRemain";
            this.btnRemain.Size = new System.Drawing.Size(75, 23);
            this.btnRemain.TabIndex = 7;
            this.btnRemain.Text = "预留";
            this.btnRemain.Click += new System.EventHandler(this.btnRemain_Click);
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Location = new System.Drawing.Point(744, 8);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(248, 40);
            this.ultraLabel7.TabIndex = 15;
            this.ultraLabel7.Text = "红色-预订，蓝色-签到，绿色-占位";
            // 
            // ShowRemain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1028, 677);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.ultraGroupBox2);
            this.Name = "ShowRemain";
            this.Text = Login.constApp.strCardTypeL8Name + "展位预留";
            this.Load += new System.EventHandler(this.ShowRemain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeat)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		private void ShowRemain_Load(object sender, System.EventArgs e)
		{
			//Helper.BindJob(cmbShow);
            string strSql = "select * from tbJob where cndEndDate>=getdate() order by cndBeginDate";
            //			string strSql = "select * from tbJob  order by cndBeginDate";
            if (Login.constApp.strJobRemainBeginDate != "")
            {
                strSql = "select * from tbJob where convert(varchar(10),cndBeginDate,121)>='" + Login.constApp.strJobRemainBeginDate + "'";
                if (Login.constApp.strJobRemainEndDate != "")
                    strSql += " and convert(varchar(10),cndEndDate,121)<='" + Login.constApp.strJobRemainEndDate + "'";
                strSql += " order by cndBeginDate";
            }
            else
            {
                if (Login.constApp.strJobRemainEndDate != "")
                {
                    strSql = "select * from tbJob where convert(varchar(10),cndEndDate,121)<='" + Login.constApp.strJobRemainEndDate + "'";
                    strSql += " order by cndBeginDate";
                }
            }
            //JobManage jobManage = new JobManage();
            DataTable dtJob = Helper.Query(strSql);//jobManage.GetAllJob();
            cmbShow.DataSource = dtJob;
            cmbShow.ValueMember = "cnnID";
            cmbShow.DisplayMember = "cnvcJobName";
            cmbShow.DataBind();
		}

		
		private void btnLoadSeat_Click(object sender, System.EventArgs e)
		{
			LoadPanel();
		}

		private void LoadSeat(Panel pl,string strFloor,string strJobID)
		{
			DataTable dtSeat = Helper.Query("select * from tbShowSeat where cnvcFloor='"+strFloor+"' and cnnJobID="+strJobID);
			foreach (DataRow drSeat in dtSeat.Rows)
			{
				ShowSeat seat = new ShowSeat(drSeat);
				zhhLabel lbl = new zhhLabel();
				lbl.Name = "lbl"+seat.cnvcControlName;
				lbl.Text = seat.cnvcControlName;//seat.cnvcSeat;
				if (seat.cnvcControlName.StartsWith("黑"))
				{
					lbl.BackColor = Color.Black;
				}
				if (seat.cnvcControlName.StartsWith("空"))
				{
					lbl.Text = "";
				}
				if (seat.cnvcState == ConstApp.Show_Seat_State_Booking)
				{
					lbl.BackColor = Color.Red;
				}
				else if (seat.cnvcState == ConstApp.Show_Seat_State_Remain)
				{
					lbl.BackColor = Color.Yellow;
				}
				else if (seat.cnvcState == ConstApp.Show_Seat_State_SignIn)
				{
					lbl.BackColor = Color.Blue;
				}
				else if (seat.cnvcState.Length > 0)//== this.oper.cnvcOperName)
				{
					lbl.BackColor = Color.Green;
				}
				Point p1 = new Point(seat.cnnX,seat.cnnY);
				lbl.Location = p1;
				lbl.Height = seat.cnnHeight;
				lbl.Width = seat.cnnWidth;
				lbl.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
				lbl.TextAlign = ContentAlignment.MiddleCenter;
				lbl.BorderStyle = BorderStyle.None;
				Helper.SetlblDirection(lbl,seat.cnvcDirection);
				if (Helper.IsNumber(seat.cnvcControlName))
				{
					lbl.Click +=new EventHandler(lbl_Click);
				}				
				pl.Controls.Add(lbl);
					
			}

		}
		private void lbl_Click(object sender, EventArgs e)
		{
			Control lCtrl =(sender as Control);
			txtSeat.Text = lCtrl.Text;
			txtSeat.Tag = lCtrl.Text;
		}
		private void JudgePanel()
		{
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl.Name.StartsWith("panel"))
				{
					this.Controls.Remove(ctrl);
					break;
					//throw new BusinessException("展厅","当前已有展厅");
				}
					
			}
		}
		private void LoadPanel()
		{
			//导入展位方案
			try
			{
				if (null == cmbShow.SelectedItem)
				{
					throw new BusinessException("展位方案","请选择招聘会");
				}
				if (null == cmbFloor.SelectedItem)
				{
					throw new BusinessException("展位方案","请选择展厅");
				}
				string strJobID = cmbShow.SelectedItem.DataValue.ToString();
				string strShowID = cmbFloor.SelectedItem.DataValue.ToString();

				

				DataTable dtShow = Helper.Query("select * from tbShow where cnnShowID="+strShowID);
				if (dtShow.Rows.Count == 0)
				{
					throw new BusinessException("展位方案","未找到展厅展厅");
				}
				Show show = new Show(dtShow);
				JudgePanel();
				Panel pl = new Panel();
				pl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				pl.Location = new System.Drawing.Point(show.cnnX, show.cnnY);
				pl.Name = "panel"+show.cnvcShowName;
				pl.Size = new System.Drawing.Size(show.cnnWeight, show.cnnHeight);
				this.Controls.Add(pl);
				LoadSeat(pl,strShowID,strJobID);


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

		private void cmbShow_ValueChanged(object sender, System.EventArgs e)
		{
			//LoadLabel();
			if (cmbShow.SelectedItem != null)
			{
				string strJobID = cmbShow.SelectedItem.DataValue.ToString();
				Helper.BindShow(cmbFloor,strJobID);
			}
			
		}

		

		private void btnRemain_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (txtSeat.Text == "")
				{
					throw new BusinessException("展位预留","请选择展位");
				}
				if (txtSeat.Tag == null || txtSeat.Tag.ToString() == "")
				{
					throw new BusinessException("展位预留","请选择展位");
				}
				if (null == cmbShow.SelectedItem)
				{
					throw new BusinessException("展位预留","请选择招聘会");
				}
				if (null == cmbFloor.SelectedItem)
				{
					throw new BusinessException("展位预留","请选择展位大厅");
				}
				ShowSeat seat = new ShowSeat();
				seat.cnnJobID = int.Parse(cmbShow.SelectedItem.DataValue.ToString());
				seat.cnvcJobName = cmbShow.SelectedItem.DisplayText;
				seat.cnvcSeat = txtSeat.Text;
				seat.cnvcFloor = cmbFloor.SelectedItem.DataValue.ToString();
				seat.cnvcState = ConstApp.Show_Seat_State_Remain;
				seat.cnvcOperName = this.oper.cnvcOperName;
				seat.cndOperDate = DateTime.Now;
				JobManage jobManage = new JobManage();
				jobManage.SeatRemain(seat);
				MessageBox.Show(this,"展位预留成功！","展位预留",MessageBoxButtons.OK,MessageBoxIcon.Information);
				LoadPanel();

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

		private void btnCancelRemain_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (txtSeat.Text == "")
				{
					throw new BusinessException("展位预留","请选择展位");
				}
				if (txtSeat.Tag == null || txtSeat.Tag.ToString() == "")
				{
					throw new BusinessException("展位预留","请选择展位");
				}
				if (null == cmbShow.SelectedItem)
				{
					throw new BusinessException("展位预留","请选择招聘会");
				}
				if (null == cmbFloor.SelectedItem)
				{
					throw new BusinessException("展位预留","请选择展位大厅");
				}
				ShowSeat seat = new ShowSeat();
				seat.cnnJobID = int.Parse(cmbShow.SelectedItem.DataValue.ToString());
				seat.cnvcJobName = cmbShow.SelectedItem.DisplayText;
				seat.cnvcSeat = txtSeat.Text;
				seat.cnvcFloor = cmbFloor.SelectedItem.DataValue.ToString();
				seat.cnvcOperName = this.oper.cnvcOperName;
				seat.cndOperDate = DateTime.Now;	
				JobManage jobManage = new JobManage();
				jobManage.CancelSeatRemain(seat);
				MessageBox.Show(this,"展位取消预留成功！","展位预留",MessageBoxButtons.OK,MessageBoxIcon.Information);
				LoadPanel();

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

		private void btnHold_Click(object sender, System.EventArgs e)
		{
			//占位
			try
			{
				if (txtSeat.Text == "")
				{
					throw new BusinessException("展位预留","请选择展位");
				}
				if (txtSeat.Tag == null || txtSeat.Tag.ToString() == "")
				{
					throw new BusinessException("展位预留","请选择展位");
				}
				if (null == cmbShow.SelectedItem)
				{
					throw new BusinessException("展位预留","请选择招聘会");
				}
				if (null == cmbFloor.SelectedItem)
				{
					throw new BusinessException("展位预留","请选择展位大厅");
				}		

				ShowSeat seat = new ShowSeat();
				seat.cnvcSeat = txtSeat.Text;
				seat.cnnJobID = int.Parse(cmbShow.SelectedItem.DataValue.ToString());
				seat.cnvcFloor = cmbFloor.SelectedItem.DataValue.ToString();
				seat.cnvcOperName = this.oper.cnvcOperName;
				seat.cndOperDate = DateTime.Now;

				DataTable dtSeat = Helper.Query("select * from tbShowSeat where cnnJobID="+seat.cnnJobID+" and cnvcState='"+seat.cnvcOperName+"'");
				if (dtSeat.Rows.Count > 0)
				{
					ShowSeat oldSeat = new ShowSeat(dtSeat);
					throw new BusinessException("展位预留","你已经占了一个位置，不能再占了。你占的位置是："+oldSeat.cnvcSeat);
				}
				JobManage jm = new JobManage();
				jm.HoldSeat(seat);
				MessageBox.Show(this, "占位成功", "展位预留",MessageBoxButtons.OK,MessageBoxIcon.Information);				
				//LoadPanel();
				this.btnLoadSeat_Click(null,null);

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
