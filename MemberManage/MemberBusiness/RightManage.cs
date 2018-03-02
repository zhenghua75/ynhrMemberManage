using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ynhrMemberManage.BusinessFacade;
using ynhrMemberManage.Domain;
using ynhrMemberManage.Business;
using MemberManage.Business;

namespace MemberManage.MemberBusiness
{
    public partial class RightManage : frmBase
    {
        public static bool IsShowing;
        public RightManage()
        {
            InitializeComponent();            
        }

        private DataTable getDept()
        {
            int iDeptID = this.dept.cnnDeptID;
            string strSql = "";
            if (iDeptID == 0)
            {
                strSql = "select * from tbDept";
            }
            else
            {
                if (Login.constApp.htDept.Contains(iDeptID))
                {
                    Dept dept = Login.constApp.htDept[iDeptID] as Dept;
                    if (dept.cnvcManager == this.oper.cnvcOperName)
                    {
                        strSql = "select * from tbDept where cnnDeptID=" + iDeptID.ToString() + " or cnnParentDeptID=" + iDeptID.ToString();
                    }
                    else
                    {
                        strSql = "select * from tbDept where 1<>1";
                    }
                }
            }
            DataTable dtDept = Helper.Query(strSql);
            return dtDept;

        }
        private void InitDeptOper()
        {
            DataTable dtDept = getDept();//Helper.Query("select * from tbDept");
            DataTable dtOper = Helper.Query("select * from tbOper");
            if (this.dept.cnnDeptID == 0)
            {
                //TreeNode tnParent = new TreeNode("0", "云南人才市场");
                TreeNode tnParent = new TreeNode();
                tnParent.Name = "dept-0";
                tnParent.Text = "云南人才市场";
                DataRow[] drOpers = dtOper.Select("cnnDeptID=0 and cnvcOperName<>'admin'");
                foreach (DataRow drOper in drOpers)
                {
                    TreeNode tnOper = new TreeNode();// (drOper["cnvcOperName"].ToString());
                    tnOper.Name = "oper-" + drOper["cnnOperID"].ToString();
                    tnOper.Text = drOper["cnvcOperName"].ToString();
                    tnOper.Tag = "0";
                    tnParent.Nodes.Add(tnOper);
                }
                AddNodes(tnParent, dtDept, dtOper, "0");
                tnParent.ExpandAll();
                this.treeView1.Nodes.Clear();
                this.treeView1.Nodes.Add(tnParent);
            }
            else
            {
                if (dtDept.Rows.Count > 0)
                {
                    TreeNode tnParent = new TreeNode();// ("云南人才市场");
                    tnParent.Name = "dept-0";
                    tnParent.Text = "云南人才市场";
                    AddNodes(tnParent, dtDept, dtOper, "0");
                    tnParent.ExpandAll();
                    this.treeView1.Nodes.Clear();
                    this.treeView1.Nodes.Add(tnParent);
                }
                else
                {
                    MessageBox.Show("普通操作员无权限操作", "部门管理");
                }
            }
        }
        private void AddNodes(TreeNode tnParent, DataTable dtDept, DataTable dtOper, string strDeptID)
        {
            DataRow[] drSubDepts = dtDept.Select("cnnParentDeptID=" + strDeptID);
            if (drSubDepts.Length > 0)
            {
                foreach (DataRow drSubDept in drSubDepts)
                {
                    TreeNode tnChild = new TreeNode();//("dept-" + drSubDept["cnnDeptID"].ToString(), drSubDept["cnvcDeptName"].ToString());
                    tnChild.Name = "dept-" + drSubDept["cnnDeptID"].ToString();
                    tnChild.Text = drSubDept["cnvcDeptName"].ToString();
                    tnChild.Tag = drSubDept["cnnDiscount"].ToString();
                    DataRow[] drOpers = dtOper.Select("cnnDeptID=" + drSubDept["cnnDeptID"].ToString());
                    foreach (DataRow drOper in drOpers)
                    {
                        TreeNode tnOper = new TreeNode();//("oper-" + drOper["cnnOperID"].ToString(), drOper["cnvcOperName"].ToString());
                        tnOper.Name = "oper-" + drOper["cnnOperID"].ToString();
                        tnOper.Text = drOper["cnvcOperName"].ToString();
                        if (drSubDept["cnvcManager"].ToString() == drOper["cnvcOperName"].ToString())
                        {
                            tnOper.ImageIndex = 0;
                        }
                        else
                        {
                            tnOper.ImageIndex = 1;
                        }
                        tnOper.Tag = drSubDept["cnnDeptID"].ToString();
                        tnChild.Nodes.Add(tnOper);
                    }
                    AddNodes(tnChild, dtDept, dtOper, drSubDept["cnnDeptID"].ToString());
                    tnParent.Nodes.Add(tnChild);
                }
            }

        }
        private void InitFuncList()
        {
            string strsql = "";
            switch (Login.constApp.strCardType)
            {
                case "l6":
                    strsql = "select * from tbFuncList where cnvcCardType in('l6','l6l8')";
                    break;
                case "l8":
                    strsql = "select * from tbFuncList where cnvcCardType in('l8','l6l8')";
                    break;
                case "l6l8":
                    strsql = "select * from tbFuncList where cnvcCardType in('l6','l8','l6l8')";
                    break;
            }
            
            DataTable dtFuncList = Helper.Query(strsql);
            //TreeNode tnParent;// = new TreeNode();
            //TreeNode tnChild;// = new TreeNode();
            treeView2.CheckBoxes = true;
            treeView2.BeginUpdate();
            treeView2.Nodes.Clear();
            
            foreach (DataRow dr in dtFuncList.Rows)
            {
                FuncList fl = new FuncList(dr);
                if (this.dept.cnnDeptID != 0 && !this.principal.IsInRole(fl.cnvcFuncCode))
                {
                    continue;
                }
                    TreeNode tn = new TreeNode(fl.cnvcFuncCode);
                    tn.Tag = fl;
                    tn.Name = fl.cnvcFuncCode;
                    if (treeView2.Nodes.IndexOfKey(fl.cnvcFuncName) < 0)
                    {
                        treeView2.Nodes.Add(fl.cnvcFuncName, fl.cnvcFuncName);
                    }
                    treeView2.Nodes[treeView2.Nodes.IndexOfKey(fl.cnvcFuncName)].Nodes.Add(tn);
                
                //if (!tnParent.Nodes.ContainsKey(fl.cnvcFuncCode))
                //{
                    //tnParent.Nodes.Add(fl.cnvcFuncCode);
               //}
            }
            treeView2.EndUpdate();
        }
        private void RightManage2_Load(object sender, EventArgs e)
        {
            InitDeptOper();
            InitFuncList();
        }

        private void treeView2_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                if (e.Node.Level == 0 && e.Node.Nodes.Count > 0)
                {
                    foreach (TreeNode tn in e.Node.Nodes)
                    {
                        if (!tn.Checked)
                            tn.Checked = true;
                    }
                }
                if (e.Node.Level == 1)
                {
                    TreeNode tnParent = e.Node.Parent;
                    int i = 0;
                    foreach (TreeNode tn in tnParent.Nodes)
                    {
                        if (tn.Checked)
                        {
                            i++;
                        }
                    }

                    if (i == tnParent.Nodes.Count)
                    {
                        if (!tnParent.Checked)
                            tnParent.Checked = true;
                    }
                }
            }
            else
            {
                if (e.Node.Level == 0 && e.Node.Nodes.Count > 0)
                {
                    foreach (TreeNode tn in e.Node.Nodes)
                    {
                        if (tn.Checked)
                            tn.Checked = false;
                    }
                }                
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode tnParent in treeView2.Nodes)
            {
                tnParent.Checked = false;                
            }
            string strdeptsql = "";
            string stropersql = "";
            switch (Login.constApp.strCardType)
            {
                case "l6":
                    strdeptsql = "select * from tbDeptFunc where cnnDeptID={0} and cnvcCardType in('l6','l6l8')";
                    stropersql = "select * from tbOperFunc where cnnOperID={0} and cnvcCardType in('l6','l6l8')";
                    break;
                case "l8":
                    strdeptsql = "select * from tbDeptFunc where cnnDeptID={0} and cnvcCardType in('l8','l6l8')";
                    stropersql = "select * from tbOperFunc where cnnOperID={0} and cnvcCardType in('l8','l6l8')";
                    break;
                case "l6l8":
                    strdeptsql = "select * from tbDeptFunc where cnnDeptID={0} and cnvcCardType in('l6','l8','l6l8')";
                    stropersql = "select * from tbOperFunc where cnnOperID={0} and cnvcCardType in('l6','l8','l6l8')";
                    break;
            }
            if (e.Node.Name.StartsWith("dept-"))
            {
                string deptid = e.Node.Name.Substring("dept-".Length);
                DataTable dt = Helper.Query(string.Format(strdeptsql,deptid));//("select * from tbDeptFunc where cnnDeptID=" + deptid+" and cnvcCardType='"+Login.constApp.strCardType+"'");
                foreach (DataRow dr in dt.Rows)
                {
                    DeptFunc df = new DeptFunc(dr);
                    TreeNode[] tns = treeView2.Nodes.Find(df.cnvcFuncCode, true);
                    if (tns.Length > 0)
                    {
                        for (int i = 0; i < tns.Length; i++)
                        {
                            tns[i].Checked = true;
                        }
                    }
                }                
            }
            if (e.Node.Name.StartsWith("oper-"))
            {
                string operid = e.Node.Name.Substring("oper-".Length);
                DataTable dt = Helper.Query(string.Format(stropersql,operid));//("select * from tbOperFunc where cnnOperID=" + operid + " and cnvcCardType='" + Login.constApp.strCardType + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    OperFunc of = new OperFunc(dr);
                    TreeNode[] tns = treeView2.Nodes.Find(of.cnvcFuncCode, true);
                    
                    if (tns.Length > 0)
                    {
                        for (int i = 0; i < tns.Length; i++)
                        {
                            tns[i].Checked = true;
                        }
                    }
                }            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //展开
            treeView1.ExpandAll();
            treeView2.ExpandAll();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //保存
            List<FuncList> lfunc = new List<FuncList>();
            foreach(TreeNode tnParent in treeView2.Nodes)
            {
                foreach(TreeNode tn in tnParent.Nodes)
                {
                    if(tn.Checked)
                        lfunc.Add(tn.Tag as FuncList);
                }
            }
            TreeNode tnSel = treeView1.SelectedNode;
            if (tnSel != null && lfunc.Count > 0)
            {
                SecurityManage sm = new SecurityManage();
                if (tnSel.Name.StartsWith("dept-"))
                {
                    string deptid = tnSel.Name.Substring("dept-".Length);
                    if (deptid != "0")
                    {
                        sm.AddDeptFunc(lfunc, deptid);
                    }
                }
                if (tnSel.Name.StartsWith("oper-"))
                {
                    string operid = tnSel.Name.Substring("oper-".Length);
                    sm.ModifyOperFunc(lfunc, operid);
                }
            }
            MessageBox.Show("权限修改成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

