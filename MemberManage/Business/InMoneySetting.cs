using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Domain;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace MemberManage.Business
{
    public partial class InMoneySetting : MemberManage.frmBase
    {
        public static bool IsShowing;
        public InMoneySetting()
        {
            InitializeComponent();
        }

        private void InMoneySetting_Load(object sender, EventArgs e)
        {
            this.ultraCheckEditor1.Checked = Login.constApp.bInMoneyDonate;
            this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti; 
            GetInMoneySetting();
        }

        private void ultraCheckEditor1_CheckedChanged(object sender, EventArgs e)
        {
            MemberManageFacade mm = new MemberManageFacade();
            mm.InMoneySetting(ultraCheckEditor1.Checked);
            Login.constApp.bInMoneyDonate = ultraCheckEditor1.Checked;
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            int icount = 0;
            for (int i = 0; i < ultraGrid1.Rows.Count; i++)
            {
                if (Convert.ToInt32(ultraGrid1.Rows[i].Cells["id"].Value.ToString())+1 > icount)
                    icount = Convert.ToInt32(ultraGrid1.Rows[i].Cells["id"].Value.ToString())+1;
            }
            //int icount = ultraGrid1.Rows.Count;
            int ibegin = Convert.ToInt32(this.ultraTextEditor1.Text);
            int ipercent = Convert.ToInt32(this.ultraTextEditor2.Text);
            int iup = Convert.ToInt32(this.ultraTextEditor3.Text);

            MemberManageFacade mm = new MemberManageFacade();
            mm.AddInMoney(icount, ibegin, ipercent, iup);

            MessageBox.Show("添加成功！");
            GetInMoneySetting();
        }

        private void GetInMoneySetting()
        {
            string strsql = @"select convert(int,a.id) as id,convert(int,a.cnnBegin) as [begin],convert(int,b.cnnPercent) as [percent],convert(int,c.cnnUp) as up from 
(select SUBSTRING(cnvctype,5,len(cnvctype)-9) as id ,cnvcvalue as cnnBegin from tbNameCode where cnvcType like '充值赠送%' and cnvcType<>'充值赠送'
and SUBSTRING(cnvctype,len(cnvctype)-4+1,4)='起始金额') a left join 
(select SUBSTRING(cnvctype,5,len(cnvctype)-9) as id,cnvcvalue as cnnPercent from tbNameCode where cnvcType like '充值赠送%' and cnvcType<>'充值赠送'
and SUBSTRING(cnvctype,len(cnvctype)-4+1,4)='赠送比例') b on a.id=b.id left join 
(select SUBSTRING(cnvctype,5,len(cnvctype)-9) as id,cnvcvalue as cnnUp from tbNameCode where cnvcType like '充值赠送%' and cnvcType<>'充值赠送'
and SUBSTRING(cnvctype,len(cnvctype)-4+1,4)='赠送限额') c on a.id=c.id";
            DataTable dt = Helper.Query(strsql);
            DataView dv = new DataView(dt);
            dv.Sort = "begin";
            this.ultraGrid1.SetDataBinding(dv, null, true, true);
        }

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //Helper.SetGridDisplay(e);
            //Infragistics.Win.UltraWinGrid.UltraGridColumn uc = new UltraGridColumn()
            //Infragistics.Shared.IKeyedSubObject ik = Infragistics.Win.UltraWinGrid.UltraGridColumn
            //e.Layout.Bands[0].Columns.Contains()

            //Helper.SetGridDisplay(e);
            //
            //Helper.SetGridDisplay(e);
            e.Layout.ScrollBounds = ScrollBounds.ScrollToFill;
            //e.Layout.Override.CellClickAction = CellClickAction.;
            e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;//UltraWinGrid.SelectType.Single;

            e.Layout.Bands[0].Override.SummaryFooterCaptionAppearance.FontData.Bold = DefaultableBoolean.True;
            e.Layout.Bands[0].Override.SummaryValueAppearance.BackColor = Color.White;
            e.Layout.Bands[0].Override.SummaryValueAppearance.TextHAlign = HAlign.Right;
            e.Layout.Bands[0].Override.SummaryFooterCaptionAppearance.BackColor = Color.White;

            foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
            {
                col.CellActivation = Activation.NoEdit;
            }


            e.Layout.Bands[0].Columns["id"].Header.Caption = "id";
            e.Layout.Bands[0].Columns["id"].Hidden = true;
            e.Layout.Bands[0].Columns["begin"].Header.Caption = "起始金额";
            e.Layout.Bands[0].Columns["percent"].Header.Caption = "赠送比例%";
            //e.Layout.Bands[0].Columns["percent"].Hidden = true;
            e.Layout.Bands[0].Columns["up"].Header.Caption = "赠送限额";
            
        }

        private void ultraGrid1_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {

        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            UltraGridRow row = this.ultraGrid1.ActiveRow;
            if (row != null)
            {
                string strid = row.Cells["id"].Value.ToString();
                MemberManageFacade mm = new MemberManageFacade();
                mm.DelInMoney(strid);
                MessageBox.Show("删除成功！");
            }
            else
                MessageBox.Show("请选择行");
            GetInMoneySetting();
        }
    }
}

