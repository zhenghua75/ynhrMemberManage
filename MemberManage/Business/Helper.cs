
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	SecurityManage.cs
* 作者:	     郑华
* 创建日期:    2008-01-04
* 功能描述:    报表查询

*                                                           Copyright(C) 2007 zhenghua
*************************************************************************************/
using System;
using ynhrMemberManage.ORM;
using ynhrMemberManage.Domain;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using ynhrMemberManage.Print;
using Infragistics;
using Infragistics.Win;
using Infragistics.Win.Printing;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using Infragistics.Win.UltraWinSchedule;
using Infragistics.Win.UltraWinSchedule.CalendarCombo;
using Infragistics.Win.UltraWinEditors;
using System.Windows;
using System.Windows.Forms;
using ynhrMemberManage.Common;
using ynhrMemeberManage.Security;
using System.Threading;
namespace MemberManage.Business
{
	
	/// <summary>
	/// Summary description for Query.
	/// </summary>
	public class ClientHelper
	{
        public ClientHelper()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        
         ///<summary>
         ///绑定行业
         ///</summary>
         ///<param name="cmbTrade"></param>
        public static void BindTrade(UltraComboEditor cmbTrade)
        {
            cmbTrade.SetDataBinding(Login.constApp.alTrade,null);
        }
         ///<summary>
         ///绑定会员资格
         ///</summary>
         ///<param name="cmbTrade"></param>
        public static void BindMemberRight(UltraComboEditor cmbMemberRight)
        {
            cmbMemberRight.SetDataBinding(Login.constApp.alMemberType,null);
        }
         ///<summary>
         ///绑定企业性质
         ///</summary>
        /// <param name="cmbTrade"></param>
        public static void BindEnterpriseType(UltraComboEditor cmbEnterpriseType)
        {
            cmbEnterpriseType.SetDataBinding(Login.constApp.alEnterpriseType,null);
        }
        public static void BindProduct(UltraComboEditor cmbProduct)
        {
            cmbProduct.SetDataBinding(Login.constApp.alProduct,null);
        }
        /// <summary>
        /// 绑定充值折扣
        /// </summary>
        /// <param name="cmbDiscount"></param>
        public static void BindInMoneyDiscount(UltraComboEditor cmbDiscount)
        {
            cmbDiscount.SetDataBinding(Login.constApp.alInMoneyDiscount, null);
        }
        public static void AddGridColumn(UltraGrid grid,string strOperName)
        {
            grid.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True;
            grid.DisplayLayout.Bands[0].UseRowLayout = true;

            ColumnsCollection cc = grid.DisplayLayout.Bands[0].Columns;
            int iCC = cc.Count;
            for (int i = 0; i < cc.Count; i++)
            {
                UltraGridColumn gc = cc[i];
                string strTemp = gc.Header.Caption;
                gc.RowLayoutColumnInfo.OriginX = i;
                gc.RowLayoutColumnInfo.OriginY = 1;
                gc.RowLayoutColumnInfo.SpanX = 1;
                gc.RowLayoutColumnInfo.SpanY = 1;

            }
            grid.DisplayLayout.Bands[0].Columns.Add("oper");
            grid.DisplayLayout.Bands[0].Columns.Add("date");
            grid.DisplayLayout.Bands[0].Columns["oper"].Header.Appearance.TextHAlign = HAlign.Left;
            grid.DisplayLayout.Bands[0].Columns["oper"].Header.Appearance.BackColor = Color.White;
            grid.DisplayLayout.Bands[0].Columns["oper"].Header.Appearance.BorderColor = Color.White;
            grid.DisplayLayout.Bands[0].Columns["oper"].Header.Caption = "操作员：" + strOperName;
            grid.DisplayLayout.Bands[0].Columns["oper"].CellActivation = Activation.Disabled;
            grid.DisplayLayout.Bands[0].Columns["oper"].SortIndicator = SortIndicator.Disabled;
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.OriginX = 0;
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.OriginY = 0;
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.SpanX = iCC - 2;
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.SpanY = 1;
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.PreferredCellSize = new Size(1, 1);
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.None;
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;

            grid.DisplayLayout.Bands[0].Columns["date"].Header.Appearance.TextHAlign = HAlign.Left;
            grid.DisplayLayout.Bands[0].Columns["date"].Header.Appearance.BackColor = Color.White;
            grid.DisplayLayout.Bands[0].Columns["date"].Header.Appearance.BorderColor = Color.White;
            grid.DisplayLayout.Bands[0].Columns["date"].Header.Caption = "操作时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm");//DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToShortTimeString();
            grid.DisplayLayout.Bands[0].Columns["date"].CellActivation = Activation.Disabled;
            grid.DisplayLayout.Bands[0].Columns["date"].SortIndicator = SortIndicator.Disabled;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.OriginX = iCC - 2;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.OriginY = 0;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.SpanX = 2;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.SpanY = 1;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.PreferredCellSize = new Size(1, 1);
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.None;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;

        }
        public static void ExportExcel(SaveFileDialog sfd ,UltraGridExcelExporter exporter,UltraGrid grid,string strTitle,string strOperName)
        {
            //Helper.ExportExcel(saveFileDialog1,ultraGridExcelExporter1,ultraGrid1);
            try
            {					
                if (grid.Rows.Count == 0)
                {
                    throw new BusinessException("导出","请先查询出结果再导出");
                }
                grid.BeginUpdate();			
                //grid.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
                //grid.UseAppStyling = false;			
                //grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;;
                AddGridTitle(grid, strTitle, strOperName);
                grid.EndUpdate();






                sfd.Filter = "Excel文件 (*.xls)|*.xls|All files (*.*)|*.*"  ;
                sfd.FilterIndex = 1 ;
                sfd.RestoreDirectory = true ;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string strFileName = sfd.FileName;
                    exporter.Export(grid, strFileName);
                }
                grid.BeginUpdate();
                //this.ultraGrid1.DisplayLayout.Bands[0].Columns[0].Hidden = false;
                //grid.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;
                //grid.UseAppStyling = true;
                //grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
                RemoveGridTitle(grid, strOperName);
                grid.EndUpdate();
            }				
            catch (BusinessException bex)
            {
                MessageBox.Show(bex.Message, bex.Type,MessageBoxButtons.OK,MessageBoxIcon.Error);				
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message,"系统错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private static void AddGridTitle(UltraGrid grid, string strTitle,string strOperName)
        {
            grid.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True;			
            grid.DisplayLayout.Bands[0].UseRowLayout = true;

            ColumnsCollection cc = grid.DisplayLayout.Bands[0].Columns;		

            grid.DisplayLayout.Bands[0].Columns.Remove("oper");
            grid.DisplayLayout.Bands[0].Columns.Remove("date");
            if (grid.DisplayLayout.Bands[0].Columns.Exists("title"))
            {
                grid.DisplayLayout.Bands[0].Columns.Remove("title");
            }

            for (int i = 0;i<cc.Count ; i++)
            {
                UltraGridColumn gc = cc[i];
                gc.RowLayoutColumnInfo.OriginX = i;
                gc.RowLayoutColumnInfo.OriginY = gc.RowLayoutColumnInfo.OriginY +1;

            }

            int iCC = cc.Count;

            grid.DisplayLayout.Bands[0].Columns.Add("oper");
            grid.DisplayLayout.Bands[0].Columns.Add("date");
            grid.DisplayLayout.Bands[0].Columns["oper"].Header.Appearance.TextHAlign = HAlign.Left;
            grid.DisplayLayout.Bands[0].Columns["oper"].Header.Appearance.BackColor = Color.White;
            grid.DisplayLayout.Bands[0].Columns["oper"].Header.Appearance.BorderColor = Color.White;
            grid.DisplayLayout.Bands[0].Columns["oper"].Header.Caption = "操作员："+strOperName;
            grid.DisplayLayout.Bands[0].Columns["oper"].CellActivation = Activation.Disabled;
            grid.DisplayLayout.Bands[0].Columns["oper"].SortIndicator = SortIndicator.Disabled;			
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.OriginX = 0;
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.OriginY = 1;
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.SpanX = iCC-2 ;
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.SpanY = 1;
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.PreferredCellSize = new Size(1,1);
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.None;
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;

            grid.DisplayLayout.Bands[0].Columns["date"].Header.Appearance.TextHAlign = HAlign.Left;
            grid.DisplayLayout.Bands[0].Columns["date"].Header.Appearance.BackColor = Color.White;
            grid.DisplayLayout.Bands[0].Columns["date"].Header.Appearance.BorderColor = Color.White;
            grid.DisplayLayout.Bands[0].Columns["date"].Header.Caption = "操作时间："+DateTime.Now.ToString("yyyy-MM-dd hh:mm");//DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToShortTimeString();
            grid.DisplayLayout.Bands[0].Columns["date"].CellActivation = Activation.Disabled;
            grid.DisplayLayout.Bands[0].Columns["date"].SortIndicator = SortIndicator.Disabled;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.OriginX = iCC-2;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.OriginY = 1;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.SpanX = 2;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.SpanY = 1;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.PreferredCellSize = new Size(1,1);
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.None;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;

            //ColumnsCollection cc = grid.DisplayLayout.Bands[0].Columns;
            //int i = grid.DisplayLayout.Bands[0].Columns.Count;
            grid.DisplayLayout.Bands[0].Columns.Add("title");
            //grid.DisplayLayout.Bands[0].Columns.Add("date");
            grid.DisplayLayout.Bands[0].Columns["title"].Header.Appearance.TextHAlign = HAlign.Center;
            grid.DisplayLayout.Bands[0].Columns["title"].Header.Appearance.BackColor = Color.White;
            grid.DisplayLayout.Bands[0].Columns["title"].Header.Appearance.BorderColor = Color.White;
            grid.DisplayLayout.Bands[0].Columns["title"].Header.Caption = strTitle;
            grid.DisplayLayout.Bands[0].Columns["title"].CellActivation = Activation.Disabled;
            grid.DisplayLayout.Bands[0].Columns["title"].SortIndicator = SortIndicator.Disabled;			
            grid.DisplayLayout.Bands[0].Columns["title"].RowLayoutColumnInfo.OriginX = 0;
            grid.DisplayLayout.Bands[0].Columns["title"].RowLayoutColumnInfo.OriginY = 0;
            grid.DisplayLayout.Bands[0].Columns["title"].RowLayoutColumnInfo.SpanX = iCC ;
            grid.DisplayLayout.Bands[0].Columns["title"].RowLayoutColumnInfo.SpanY = 1;
            grid.DisplayLayout.Bands[0].Columns["title"].RowLayoutColumnInfo.PreferredCellSize = new Size(1,1);
            grid.DisplayLayout.Bands[0].Columns["title"].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.None;
            grid.DisplayLayout.Bands[0].Columns["title"].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;

            //return grid;

        }

        private static  void RemoveGridTitle(UltraGrid grid,string strOperName)
        {
            grid.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True;			
            grid.DisplayLayout.Bands[0].UseRowLayout = true;

            ColumnsCollection cc = grid.DisplayLayout.Bands[0].Columns;		

            grid.DisplayLayout.Bands[0].Columns.Remove("oper");
            grid.DisplayLayout.Bands[0].Columns.Remove("date");
            if (grid.DisplayLayout.Bands[0].Columns.Exists("title"))
            {
                grid.DisplayLayout.Bands[0].Columns.Remove("title");
            }

            for (int i = 0;i<cc.Count ; i++)
            {
                UltraGridColumn gc = cc[i];
                gc.RowLayoutColumnInfo.OriginX = i;
                gc.RowLayoutColumnInfo.OriginY = gc.RowLayoutColumnInfo.OriginY +1;

            }

            int iCC = cc.Count;

            grid.DisplayLayout.Bands[0].Columns.Add("oper");
            grid.DisplayLayout.Bands[0].Columns.Add("date");
            grid.DisplayLayout.Bands[0].Columns["oper"].Header.Appearance.TextHAlign = HAlign.Left;
            grid.DisplayLayout.Bands[0].Columns["oper"].Header.Appearance.BackColor = Color.White;
            grid.DisplayLayout.Bands[0].Columns["oper"].Header.Appearance.BorderColor = Color.White;
            grid.DisplayLayout.Bands[0].Columns["oper"].Header.Caption = "操作员："+strOperName;
            grid.DisplayLayout.Bands[0].Columns["oper"].CellActivation = Activation.Disabled;
            grid.DisplayLayout.Bands[0].Columns["oper"].SortIndicator = SortIndicator.Disabled;			
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.OriginX = 0;
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.OriginY = 1;
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.SpanX = iCC-2 ;
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.SpanY = 1;
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.PreferredCellSize = new Size(1,1);
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.None;
            grid.DisplayLayout.Bands[0].Columns["oper"].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;

            grid.DisplayLayout.Bands[0].Columns["date"].Header.Appearance.TextHAlign = HAlign.Left;
            grid.DisplayLayout.Bands[0].Columns["date"].Header.Appearance.BackColor = Color.White;
            grid.DisplayLayout.Bands[0].Columns["date"].Header.Appearance.BorderColor = Color.White;
            grid.DisplayLayout.Bands[0].Columns["date"].Header.Caption = "操作时间："+DateTime.Now.ToString("yyyy-MM-dd hh:mm");//DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToShortTimeString();
            grid.DisplayLayout.Bands[0].Columns["date"].CellActivation = Activation.Disabled;
            grid.DisplayLayout.Bands[0].Columns["date"].SortIndicator = SortIndicator.Disabled;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.OriginX = iCC-2;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.OriginY = 1;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.SpanX = 2;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.SpanY = 1;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.PreferredCellSize = new Size(1,1);
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.None;
            grid.DisplayLayout.Bands[0].Columns["date"].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;

        }
        public static void BindSales(UltraComboEditor cmbSales)
        {
            string strsql = "select cnvcSales from tbSales ";
            DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);
            ArrayList al = new ArrayList();
            foreach (DataRow dr in dt.Rows)
            {
                al.Add(dr[0]);
            }
            cmbSales.SetDataBinding(al, null);
        }
        public static void BindSales(UltraComboEditor cmbSales,string strOperId)
        {
            string strsql = string.Format(@"select a.cnvcSales from tbSales a
join tbOperDept b on a.cnnDeptID=b.cnnDeptID
where b.cnnOperID={0}", strOperId);
            DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);
            ArrayList al = new ArrayList();
            foreach (DataRow dr in dt.Rows)
            {
                al.Add(dr[0]);
            }
            cmbSales.SetDataBinding(al, null);
        }
        public static void BindDept(UltraComboEditor cmbSales, string strOperId)
        {
            string strsql = string.Format(@"select b.* from tbOperDept a
join tbDept b on a.cnnDeptID=b.cnnDeptID
where a.cnnOperID={0}
", strOperId);
            DataTable dt = SqlHelper.ExecuteDataTable(CommandType.Text, strsql);
            cmbSales.DataSource = dt;
            cmbSales.DisplayMember = "cnvcDeptName";
            cmbSales.ValueMember = "cnnDeptId";
            cmbSales.DataBind();
        }
        public static string GetCredentials(string strSales)
        {
            string strsql = string.Format(@"select cnvcCredentials from tbSales where cnvcSales='{0}'", strSales);
            object o = SqlHelper.ExecuteScalar(CommandType.Text, strsql);
            string str = "";
            if (o != null)
            {
                str = o.ToString();
            }
            return str;
        }

        public static void BindOper(UltraComboEditor cmbOper, Oper oper,Dept dept)
        {
            string strsql = string.Format(@"select a.* from tbOper a
left join tbDept b
on a.cnnDeptID=b.cnnDeptID
where (b.cnnParentDeptID={0} or b.cnnDeptID={0}) and cnvcOperName <> 'admin'", oper.cnnDeptID.ToString());
            DataTable dtOper = SqlHelper.ExecuteDataTable(CommandType.Text,strsql);
            cmbOper.DataSource = dtOper;
            cmbOper.DisplayMember = "cnvcOperName";
            cmbOper.ValueMember = "cnnOperID";
            cmbOper.DataBind();

            if (oper.cnnDeptID != 0 && oper.cnvcOperName!=dept.cnvcManager)
            {
                cmbOper.FindString(oper.cnvcOperName);
                cmbOper.Enabled = false;
            }
        }
	}
}
