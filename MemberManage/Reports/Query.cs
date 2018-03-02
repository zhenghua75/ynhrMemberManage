
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
using MemberManage.Business;
using ynhrMemberManage.Common;

namespace MemberManage.Reports
{
	public class Query
	{
		public Query()
		{
		}
        public DataTable Report(string strSql)
        {
            DataTable dtRet = SqlHelper.ExecuteDataTable(CommandType.Text, strSql);
            return dtRet;
        }
	}
}
