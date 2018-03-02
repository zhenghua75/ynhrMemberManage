using System;
using System.Collections;

namespace ynhrMemberManage.ORM
{
	/// <summary>
    /// 表映射属性存储类.
    /// zhenghua@create 2007.11.09
	/// </summary>
	public class TableAttributes
	{
        // 表名称
        private string strTableName = String.Empty;
        // 字段
        private ArrayList caColumns = new ArrayList();

        public string TableName
        {
            get{return strTableName;}
            set{strTableName = value;}
        }

        public ArrayList Columns
        {
            get{return caColumns;}
            set{caColumns = value;}
        }
	}
}
