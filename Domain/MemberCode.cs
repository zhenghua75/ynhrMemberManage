
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	MemberCode.cs
* ����:	     ֣��
* ��������:    2007-12-25
* ��������:    ��Ա�����

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
	/// **�������ƣ���Ա�����ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbMemberCode")]
	public class MemberCode: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region ���ݱ����ɱ���
		private int _cnnMemberCodeID;
		private string _cnvcMemberName = String.Empty;
		private string _cnvcMemberType = String.Empty;
		private string _cnvcMemberValue = String.Empty;
		#endregion
		
		#region ���캯��
		public MemberCode():base()
		{
		}
		
		public MemberCode(DataRow row):base(row)
		{
		}
		
		public MemberCode(DataTable table):base(table)
		{
		}
		
		public MemberCode(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������
	
		/// <summary>
		/// ��Ա����ID
		/// </summary>
		[ColumnMapping("cnnMemberCodeID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public int cnnMemberCodeID
		{
			get {return _cnnMemberCodeID;}
			set {_cnnMemberCodeID = value;}
		}

		/// <summary>
		/// ��Ա����
		/// </summary>
		[ColumnMapping("cnvcMemberName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMemberName
		{
			get {return _cnvcMemberName;}
			set {_cnvcMemberName = value;}
		}

		/// <summary>
		/// ��Ա��������
		/// </summary>
		[ColumnMapping("cnvcMemberType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMemberType
		{
			get {return _cnvcMemberType;}
			set {_cnvcMemberType = value;}
		}

		/// <summary>
		/// ��Ա��������ֵ
		/// </summary>
		[ColumnMapping("cnvcMemberValue",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMemberValue
		{
			get {return _cnvcMemberValue;}
			set {_cnvcMemberValue = value;}
		}
		#endregion
	}	
}
