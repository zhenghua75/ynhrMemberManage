using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ynhrMemberManage.BusinessFacade.MemberBusiness;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ynhrMemberManage.Domain;

namespace MemberManage.MemberBusiness
{
    public partial class ManageNT77 : MemberManage.frmBase
    {
        public ManageNT77()
        {
            InitializeComponent();
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageNT77_Load(object sender, EventArgs e)
        {
            //this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;            
            PopulateValueList();
            BindGrid();
        }
        private void BindGrid()
        {
            string strsql = "select HardwareID,CardNo,CreateDate,OperName,case when bIsUse=1 then 1 else 0 end as bIsUse from tbNT77";
            DataTable dt = Helper.Query(strsql);
            this.ultraGrid1.DataSource = null;
            this.ultraGrid1.DataSource = dt;
            this.ultraGrid1.DataBind();
        }
        private void PopulateValueList()
        {
            if (!this.ultraGrid1.DisplayLayout.ValueLists.Exists("bIsUse"))
            {
                ValueList objValueList = this.ultraGrid1.DisplayLayout.ValueLists.Add("bIsUse");
                //DataTable dtCustomerService = Helper.Query("select distinct cnvcCustomerService from tbMember where Len(cnvcMemberCardNo)=6 and cnvcCustomerService is not null");

                //for (int i = 0; i < dtCustomerService.Rows.Count; i++)
                //    objValueList.ValueListItems.Add(dtCustomerService.Rows[i].ItemArray[0], dtCustomerService.Rows[i].ItemArray[0].ToString());
                objValueList.ValueListItems.Add(0, "不可用");
                objValueList.ValueListItems.Add(1, "可用");
            }
            if (!this.ultraGrid1.DisplayLayout.ValueLists.Exists("OperName"))
            {
                ValueList objValueList = this.ultraGrid1.DisplayLayout.ValueLists.Add("OperName");
                DataTable dtOper = Helper.Query("select distinct cnvcOperName from tbOper");

                for (int i = 0; i < dtOper.Rows.Count; i++)
                    objValueList.ValueListItems.Add(dtOper.Rows[i].ItemArray[0], dtOper.Rows[i].ItemArray[0].ToString());                
            }
        }
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Helper.SetGridDisplay(e);
            //e.Layout.ScrollBounds = ScrollBounds.ScrollToFill;
            //e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
            {
                col.CellActivation = Activation.NoEdit;
            }
            e.Layout.Bands[0].Columns["bIsUse"].ValueList = this.ultraGrid1.DisplayLayout.ValueLists["bIsUse"];
            e.Layout.Bands[0].Columns["OperName"].ValueList = this.ultraGrid1.DisplayLayout.ValueLists["OperName"];
            e.Layout.Bands[0].Columns["HardwareID"].Header.Caption = "序列号";
            e.Layout.Bands[0].Columns["CardNo"].Header.Caption = "加密卡号";
            e.Layout.Bands[0].Columns["CreateDate"].Header.Caption = "第一次使用时间";
            e.Layout.Bands[0].Columns["bIsUse"].Header.Caption = "可用状态";
            //e.Layout.Bands[0].Columns["bIsUse"].
            e.Layout.Bands[0].Columns["OperName"].Header.Caption = "使用人";
            e.Layout.Bands[0].Columns["bIsUse"].CellActivation = Activation.AllowEdit;
            e.Layout.Bands[0].Columns["OperName"].CellActivation = Activation.AllowEdit;
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            List<NT77> lnt = new List<NT77>();
            //ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            //ultraGrid1.UpdateData();
            
            foreach (UltraGridRow gr in this.ultraGrid1.Rows)
            {
                NT77 nt = new NT77();
                nt.HardwareID = gr.Cells["HardwareID"].Value.ToString();
                nt.CardNo = gr.Cells["CardNo"].Value.ToString();
                nt.CreateDate = Convert.ToDateTime(gr.Cells["CreateDate"].Value);
                nt.bIsUse = Convert.ToBoolean(gr.Cells["bIsUse"].Value);
                nt.OperName = gr.Cells["OperName"].Value.ToString();

                lnt.Add(nt);
            }
            ynhrMemberManage.BusinessFacade.MemberBusiness.SecurityManage sm = new SecurityManage();
            sm.UpdateNT77(lnt);
            MessageBox.Show("ekey使用信息更新成功","ekey管理");
        }
    }
}

