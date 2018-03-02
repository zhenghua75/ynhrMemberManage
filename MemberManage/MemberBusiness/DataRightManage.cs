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
    public partial class DataRightManage : frmBase
    {
        public static bool IsShowing;
        public DataRightManage()
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
        //private void InitFuncList()
        //{
        //    string strsql = "";
        //    switch (Login.constApp.strCardType)
        //    {
        //        case "l6":
        //            strsql = "select * from tbFuncList where cnvcCardType in('l6','l6l8')";
        //            break;
        //        case "l8":
        //            strsql = "select * from tbFuncList where cnvcCardType in('l8','l6l8')";
        //            break;
        //        case "l6l8":
        //            strsql = "select * from tbFuncList where cnvcCardType in('l6','l8','l6l8')";
        //            break;
        //    }
            
        //    DataTable dtFuncList = Helper.Query(strsql);
        //    treeView2.CheckBoxes = true;
        //    treeView2.BeginUpdate();
        //    treeView2.Nodes.Clear();
            
        //    foreach (DataRow dr in dtFuncList.Rows)
        //    {
        //        FuncList fl = new FuncList(dr);
        //        if (this.dept.cnnDeptID != 0 && !this.principal.IsInRole(fl.cnvcFuncCode))
        //        {
        //            continue;
        //        }
        //            TreeNode tn = new TreeNode(fl.cnvcFuncCode);
        //            tn.Tag = fl;
        //            tn.Name = fl.cnvcFuncCode;
        //            if (treeView2.Nodes.IndexOfKey(fl.cnvcFuncName) < 0)
        //            {
        //                treeView2.Nodes.Add(fl.cnvcFuncName, fl.cnvcFuncName);
        //            }
        //            treeView2.Nodes[treeView2.Nodes.IndexOfKey(fl.cnvcFuncName)].Nodes.Add(tn);
                
        //    }
        //    treeView2.EndUpdate();
        //}
        private void InitDeptList()
        {
            string strsql = "select * from tbDept";
            DataTable dtDeptList = Helper.Query(strsql);
            treeView2.CheckBoxes = true;
            treeView2.BeginUpdate();
            treeView2.Nodes.Clear();
            foreach (DataRow dr in dtDeptList.Rows)
            {
                Dept dept = new Dept(dr);
                TreeNode tn = new TreeNode(dept.cnvcDeptName);
                tn.Tag = dept;
                tn.Name = dept.cnnDeptID.ToString();

                treeView2.Nodes.Add(tn);

            }
            treeView2.EndUpdate();
        }
        private void DataRightManage2_Load(object sender, EventArgs e)
        {
            InitDeptOper();
            InitDeptList();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode tnParent in treeView2.Nodes)
            {
                tnParent.Checked = false;                
            }
            string strsql = "select * from tbOperDept where cnnOperID={0}";
            if (e.Node.Name.StartsWith("oper-"))
            {
                string operid = e.Node.Name.Substring("oper-".Length);
                DataTable dt = Helper.Query(string.Format(strsql, operid));
                foreach (DataRow dr in dt.Rows)
                {
                    OperDept of = new OperDept(dr);
                    TreeNode[] tns = treeView2.Nodes.Find(of.cnnDeptID.ToString(), true);
                    
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
            List<Dept> ldept = new List<Dept>();
            foreach(TreeNode tn in treeView2.Nodes)
            {
                if (tn.Checked)
                    ldept.Add(tn.Tag as Dept);
            }
            TreeNode tnSel = treeView1.SelectedNode;
            if (tnSel != null && ldept.Count > 0)
            {
                if (tnSel.Name.StartsWith("oper-"))
                {
                    string operid = tnSel.Name.Substring("oper-".Length);
                    SecurityManage sm = new SecurityManage();
                    sm.ModifyOperDept(ldept, operid);
                    MessageBox.Show("数据权限修改成功");
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

