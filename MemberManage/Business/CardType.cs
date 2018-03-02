using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ynhrMemberManage.BusinessFacade.MemberBusiness;
using ynhrMemberManage.Common;
using ynhrMemberManage.Domain;
namespace MemberManage.Business
{
    public partial class CardType : MemberManage.frmBase
    {
        public CardType()
        {
            InitializeComponent();
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            //设置卡型   
            string strtype = "";// this.ultraOptionSet1.Value.ToString();
            if (l6.Checked) strtype = "l6";
            if (l8.Checked) strtype = "l8";
            if (l6.Checked && l8.Checked) strtype = "l6l8";
            if (string.IsNullOrEmpty(txtL6.Text) || string.IsNullOrEmpty(txtL8.Text))
            {
                MessageBox.Show("卡型名称为空", "卡型设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MemberManageFacade mf = new MemberManageFacade();
            mf.SetCardType(strtype);
            mf.SetCardTypeName(ConstApp.CardType_L6, this.txtL6.Text);
            mf.SetCardTypeName(ConstApp.CardType_L8, this.txtL8.Text);
            MessageBox.Show("卡型设置成功");
        }

        private void CardType_Load(object sender, EventArgs e)
        {
            string strsql = "select * from tbNameCode where cnvcType='"+ConstApp.CardType+"'";
            DataTable dt = Helper.Query(strsql);
            if (dt.Rows.Count > 0)
            {
                NameCode nc = new NameCode(dt);
                switch (nc.cnvcValue)
                {
                    case "l6":
                        this.l6.Checked = true;
                        this.l8.Checked = false;
                        break;
                    case "l8":
                        this.l6.Checked = false;
                        this.l8.Checked = true;
                        break;
                    case "l6l8":
                        this.l6.Checked = true;
                        this.l8.Checked = true;
                        break;
                }
                //this.ultraOptionSet1.Value = nc.cnvcValue;
            }
            MemberManageFacade mf = new MemberManageFacade();
            this.txtL6.Text = mf.GetCardTypeName(ConstApp.CardType_L6);
            this.txtL8.Text = mf.GetCardTypeName(ConstApp.CardType_L8);
        }
    }
}

