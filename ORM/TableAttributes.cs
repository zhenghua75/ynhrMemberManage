using System;
using System.Collections;

namespace ynhrMemberManage.ORM
{
	/// <summary>
    /// ��ӳ�����Դ洢��.
    /// zhenghua@create 2007.11.09
	/// </summary>
	public class TableAttributes
	{
        // ������
        private string strTableName = String.Empty;
        // �ֶ�
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
