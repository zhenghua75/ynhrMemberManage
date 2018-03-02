
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	SeqSerialNo.cs
* ����:	     ֣��
* ��������:    2008-1-13
* ��������:    ��ˮ�ű�

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
	/// **�������ƣ���ˮ�ű�ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbSeqSerialNo")]
	public class SeqSerialNo: ynhrMemberManage.ORM.EntityObjectBase
	{
		#region ���ݱ����ɱ���
		private decimal _ID;
		private string _cnvcFill = String.Empty;
		#endregion
		
		#region ���캯��
		public SeqSerialNo():base()
		{
		}
		
		public SeqSerialNo(DataRow row):base(row)
		{
		}
		
		public SeqSerialNo(DataTable table):base(table)
		{
		}
		
		public SeqSerialNo(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������
	
		/// <summary>
		/// ID
		/// </summary>
		[ColumnMapping("ID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public decimal ID
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
