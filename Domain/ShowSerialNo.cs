
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	ShowSerialNo.cs
* ����:	     ֣��
* ��������:    2008-1-15
* ��������:    չ��ID��ˮ

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
	/// **�������ƣ�չ��ID��ˮʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbShowSerialNo")]
	public class ShowSerialNo: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region ���ݱ����ɱ���
		private int _ID;
		private string _cnvcFill = String.Empty;
		#endregion
		
		#region ���캯��
		public ShowSerialNo():base()
		{
		}
		
		public ShowSerialNo(DataRow row):base(row)
		{
		}
		
		public ShowSerialNo(DataTable table):base(table)
		{
		}
		
		public ShowSerialNo(string  strXML):base(strXML)
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
