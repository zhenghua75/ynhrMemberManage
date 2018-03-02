
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	NameCode.cs
* ����:	     ֣��
* ��������:    2007-12-23
* ��������:    �����

*                                                           Copyright(C) 2007 zhenghua
*************************************************************************************/
#region Import NameSpace
using System;
using System.Data;
using ynhrMemberManage.ORM;
#endregion

namespace ynhrMemberManage.Domain
{
	/// <summary>
	/// **�������ƣ������ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbNameCode")]
	public class NameCode: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region ���ݱ����ɱ���
		private int _cnvcCodeID;
		private string _cnvcType = String.Empty;
		private string _cnvcValue = String.Empty;
		#endregion
		
		#region ���캯��
		public NameCode():base()
		{
		}
		
		public NameCode(DataRow row):base(row)
		{
		}
		
		public NameCode(DataTable table):base(table)
		{
		}
		
		public NameCode(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������
	
		/// <summary>
		/// ����ID
		/// </summary>
		[ColumnMapping("cnvcCodeID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public int cnvcCodeID
		{
			get {return _cnvcCodeID;}
			set {_cnvcCodeID = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		[ColumnMapping("cnvcType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcType
		{
			get {return _cnvcType;}
			set {_cnvcType = value;}
		}

		/// <summary>
		/// ����ֵ
		/// </summary>
		[ColumnMapping("cnvcValue",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcValue
		{
			get {return _cnvcValue;}
			set {_cnvcValue = value;}
		}
		#endregion
	}	
}
