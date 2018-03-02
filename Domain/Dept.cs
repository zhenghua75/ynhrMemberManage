
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	Dept.cs
* ����:	     ֣��
* ��������:    2007-12-25
* ��������:    ���ű�

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
	/// **�������ƣ����ű�ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbDept")]
	public class Dept: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region ���ݱ����ɱ���
		private int _cnnDeptID;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcManager = String.Empty;
		private int _cnnParentDeptID;
		private string _cnvcComments = String.Empty;
		private int _cnnDiscount;
		#endregion
		
		#region ���캯��
		public Dept():base()
		{
		}
		
		public Dept(DataRow row):base(row)
		{
		}
		
		public Dept(DataTable table):base(table)
		{
		}
		
		public Dept(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������
	
		/// <summary>
		/// ����ID
		/// </summary>
		[ColumnMapping("cnnDeptID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public int cnnDeptID
		{
			get {return _cnnDeptID;}
			set {_cnnDeptID = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		[ColumnMapping("cnvcDeptName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptName
		{
			get {return _cnvcDeptName;}
			set {_cnvcDeptName = value;}
		}

		/// <summary>
		/// ����Ա
		/// </summary>
		[ColumnMapping("cnvcManager",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcManager
		{
			get {return _cnvcManager;}
			set {_cnvcManager = value;}
		}

		/// <summary>
		/// �ϼ�����
		/// </summary>
		[ColumnMapping("cnnParentDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnParentDeptID
		{
			get {return _cnnParentDeptID;}
			set {_cnnParentDeptID = value;}
		}

		/// <summary>
		/// ����
		/// </summary>
		[ColumnMapping("cnvcComments",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcComments
		{
			get {return _cnvcComments;}
			set {_cnvcComments = value;}
		}

		/// <summary>
		/// �ۿ�
		/// </summary>
		[ColumnMapping("cnnDiscount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public int cnnDiscount
		{
			get {return _cnnDiscount;}
			set {_cnnDiscount = value;}
		}
		#endregion
	}	
}
