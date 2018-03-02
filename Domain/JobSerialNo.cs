
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	JobSerialNo.cs
* ����:	     ֣��
* ��������:    2008-1-15
* ��������:    ��Ƹ��ID��ˮ

*                                                           Copyright(C) 2008 zhenghua
*************************************************************************************/
#region Import NameSpace
using System;
using System.Data;
using ynhrMemberManage.ORM;
#endregion

namespace ynhrMemberManage.Domain
{
	/// <summary>
	/// **�������ƣ���Ƹ��ID��ˮʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbJobSerialNo")]
	public class JobSerialNo: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region ���ݱ����ɱ���
		private int _ID;
		private string _cnvcFill = String.Empty;
		#endregion
		
		#region ���캯��
		public JobSerialNo():base()
		{
		}
		
		public JobSerialNo(DataRow row):base(row)
		{
		}
		
		public JobSerialNo(DataTable table):base(table)
		{
		}
		
		public JobSerialNo(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������
	
		/// <summary>
		/// ID
		/// </summary>
		[ColumnMapping("ID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public int ID
		{
			get {return _ID;}
			set {_ID = value;}
		}

		/// <summary>
		/// cnvcFill
		/// </summary>
		[ColumnMapping("cnvcFill",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFill
		{
			get {return _cnvcFill;}
			set {_cnvcFill = value;}
		}
		#endregion
	}	
}
