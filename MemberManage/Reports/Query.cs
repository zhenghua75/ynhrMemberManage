
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	SecurityManage.cs
* ����:	     ֣��
* ��������:    2008-01-04
* ��������:    �����ѯ

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
