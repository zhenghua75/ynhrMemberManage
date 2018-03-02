using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MemberManage.MemberBusiness;
using Infragistics.Win.Misc;
using System.Threading;
using MemberManage.Business;
using ynhrMemeberManage.Security;
using ynhrMemberManage.Domain;
using System.Runtime.InteropServices;
using ynhrMemberManage.BusinessFacade.MemberBusiness;
using System.Collections;
namespace MemberManage
{
    public partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.identity != null && this.dept != null)
            {
                if (this.dept.cnnDeptID != 0)
                {
                    if (this.Controls.Count > 0)
                    {
                        foreach (Control ctl in this.Controls)
                        {
                            if (ctl is UltraButton)
                            {
                                ctl.Visible = Thread.CurrentPrincipal.IsInRole(this.Text + ctl.Text);
                            }
                            else
                            {
                                if (ctl.Controls.Count > 0)
                                {
                                    foreach (Control ctl2 in ctl.Controls)
                                    {
                                        if (ctl2 is UltraButton)
                                        {
                                            ctl2.Visible = Thread.CurrentPrincipal.IsInRole(this.Text + ctl2.Text);
                                        }
                                        else
                                        {
                                            if (ctl2.Controls.Count > 0)
                                            {
                                                foreach (Control ctl3 in ctl2.Controls)
                                                {
                                                    if (ctl3 is UltraButton)
                                                    {
                                                        ctl3.Visible = Thread.CurrentPrincipal.IsInRole(this.Text + ctl3.Text);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        
#region ��������л����뷨��ȫ�ǵ�����--From Aking

        //����һЩAPI����
        [DllImport("imm32.dll")]
        internal static extern IntPtr ImmGetContext(IntPtr hwnd);
        [DllImport("imm32.dll")]
        internal static extern bool ImmGetOpenStatus(IntPtr himc);
        [DllImport("imm32.dll")]
        internal static extern bool ImmSetOpenStatus(IntPtr himc, bool b);
        [DllImport("imm32.dll")]
        internal static extern bool ImmGetConversionStatus(IntPtr himc, ref int lpdw, ref int lpdw2);
        [DllImport("imm32.dll")]
        internal static extern int ImmSimulateHotKey(IntPtr hwnd, int lngHotkey);
        private const int IME_CMODE_FULLSHAPE = 0x8;
        private const int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;
        //����Form��OnActivated

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            IntPtr HIme = ImmGetContext(this.Handle);
            if (ImmGetOpenStatus(HIme))  //������뷨���ڴ�״̬
            {
                int iMode = 0;
                int iSentence = 0;
                bool bSuccess = ImmGetConversionStatus(HIme, ref iMode, ref iSentence);  //�������뷨��Ϣ
                if (bSuccess)
                {
                    if ((iMode & IME_CMODE_FULLSHAPE) > 0)   //�����ȫ��
                        ImmSimulateHotKey(this.Handle, IME_CHOTKEY_SHAPE_TOGGLE);  //ת���ɰ��
                }
            }
        }
        #endregion ��������л����뷨��ȫ�ǵ�����
        public MyPrincipal principal
        {
            get { return Thread.CurrentPrincipal as MyPrincipal; }
        }
        public MyIdentity identity
        {
            get
            {
                if (principal != null)
                    return principal.Identity as MyIdentity;
                else
                    return null;
            }
        }
        public Oper oper
        {
            get
            {
                if (identity != null)
                    return identity.oper;
                else
                    return null;
            }
        }
        public Dept dept
        {
            get
            {
                if (identity != null)
                    return identity.dept;
                else
                    return null;
            }
        }
        public int iDiscount
        {
            get
            {
                if (dept.cnnDeptID == 0)
                    return 0;
                else
                    return dept.cnnDiscount;
            }
        }

        public bool GetIsProduct(string strMemberRight)
        {
            bool isProduct = true;
            if (Login.constApp.htIsProduct.ContainsKey(strMemberRight))
            {
                isProduct = !Login.constApp.htIsProduct[strMemberRight].ToString().Equals("��");
            }
            return isProduct;
        }
        public bool GetIsProductSelect(string strMemberRight)
        {
            bool isProductSelect = false;
            if (Login.constApp.htIsProductSelect.ContainsKey(strMemberRight))
            {
                isProductSelect = Login.constApp.htIsProductSelect[strMemberRight].ToString().Equals("��");
            }
            return isProductSelect;
        }
        public bool GetIsMemberFee(string strMemberRight)
        {
            bool isMemberFee = false;
            if (Login.constApp.htIsMemberFee.ContainsKey(strMemberRight))
            {
                isMemberFee = Login.constApp.htIsMemberFee[strMemberRight].ToString().Equals("��");
            }
            return isMemberFee;
        }
        public bool GetIsDisabledDate(string strMemberRight)
        {
            bool isDisabledDate = false;
            if (Login.constApp.htIsDisabledDate.ContainsKey(strMemberRight))
            {
                isDisabledDate = Login.constApp.htIsDisabledDate[strMemberRight].ToString().Equals("��");
            }
            return isDisabledDate;
        }
        public string GetEndDate(string strMemberRight)
        {
            string strEndDate = DateTime.Now.ToString("yyyy-MM-dd");
            if (GetIsDisabledDate(strMemberRight))
            {
                if (Login.constApp.htDisabledDate.ContainsKey(strMemberRight))
                {
                    string strDisabledDate = Login.constApp.htDisabledDate[strMemberRight].ToString();
                    strEndDate = DateTime.Now.AddMonths(int.Parse(strDisabledDate)).ToString();
                }
                else
                {
                    MessageBox.Show(this, strMemberRight + " �ġ�����Ч�·ݡ�����δ����", "��������", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
            }
            return strEndDate;
        }
        public decimal GetMemberFee(string strMemberRight)
        {
            decimal dMemberFee = 0;
            if (GetIsMemberFee(strMemberRight))
            {
                if (Login.constApp.htMemberFee.ContainsKey(strMemberRight))
                {
                    string strMemberFee = Login.constApp.htMemberFee[strMemberRight].ToString();
                    dMemberFee = Convert.ToDecimal(strMemberFee);
                }
                else
                {
                    MessageBox.Show(this, strMemberRight + " �ġ���Ա�ѡ�����δ����", "��������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dMemberFee;
        }

        public bool GetIsFeeType(string strMemberRight)
        {
            bool IsFeeType = false;
            if (Login.constApp.htIsFeeType.ContainsKey(strMemberRight))
            {
                IsFeeType = Login.constApp.htIsFeeType[strMemberRight].ToString().Equals("��");
            }
            return IsFeeType;
        }

        public string GetFeeType(string strMemberRight)
        {
            string strFeeType = "0";
            if (GetIsFeeType(strMemberRight))
            {
                if (Login.constApp.htFree.ContainsKey(strMemberRight))
                {
                    strFeeType = Login.constApp.htFree[strMemberRight].ToString();
                }
                else
                {
                    MessageBox.Show(this, strMemberRight + " �ġ����Ρ�����δ����", "��������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return strFeeType;
        }
        public bool GetIsJob(string strMemberRight)
        {
            bool isJob = true;
            if (Login.constApp.htIsJob.ContainsKey(strMemberRight))
            {
                isJob = !Login.constApp.htIsJob[strMemberRight].ToString().Equals("��");
            }
            return isJob;
        }
        public bool GetIsInMoney(string strMemberRight)
        {
            bool isInMoney = true;
            if (Login.constApp.htIsInMoney.ContainsKey(strMemberRight))
            {
                isInMoney = !Login.constApp.htIsInMoney[strMemberRight].ToString().Equals("��");
            }
            return isInMoney;
        }

        public string GetMemberRight(string strCardNo)
        {
            string strMemberRight = "";
            DataTable dt = Helper.Query("select cnvcMemberRight from tbMember where cnvcMemberCardNo='" + strCardNo + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                strMemberRight = dt.Rows[0][0].ToString();
            }
            return strMemberRight;
        }
        public ArrayList GetMemberProduct(string strCardNo)
        {
            ArrayList arr = new ArrayList();
            DataTable dt = Helper.Query("select cnvcProductName from tbMemberProduct where cnvcMemberCardNo='" + strCardNo + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    arr.Add(dr[0].ToString());
                }
            }
            return arr;
        }

        public string GetMemberDiscount(string strMemberRight)
        {
            string discount = "60";
            if (Login.constApp.htMemberDiscount.ContainsKey(strMemberRight))
            {
                discount = Login.constApp.htMemberDiscount[strMemberRight].ToString();
            }
            return discount;
        }
    }
}