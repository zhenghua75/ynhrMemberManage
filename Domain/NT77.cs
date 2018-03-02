
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	NT77.cs
* ����:	     ֣��
* ��������:    2011/2/21
* ��������:    ���ܹ���

*                                                           Copyright(C) 2011 zhenghua
*************************************************************************************/
#region Import NameSpace
using System;
using System.Data;
using ynhrMemberManage.ORM;
#endregion

namespace ynhrMemberManage.Domain
{
    /// <summary>
    /// **�������ƣ����ܹ���ʵ����
    /// </summary>
    [Serializable]
    [TableMapping("tbNT77")]
    public class NT77 : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region ���ݱ����ɱ���
        private string _HardwareID = String.Empty;
        private string _CardNo = String.Empty;
        private DateTime _CreateDate;
        private bool _bIsUse;
        private string _OperName = String.Empty;
        #endregion

        #region ���캯��
        public NT77()
            : base()
        {
        }

        public NT77(DataRow row)
            : base(row)
        {
        }

        public NT77(DataTable table)
            : base(table)
        {
        }

        public NT77(string strXML)
            : base(strXML)
        {
        }
        #endregion

        #region ϵͳ��������

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("HardwareID", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
        public string HardwareID
        {
            get { return _HardwareID; }
            set { _HardwareID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("CardNo", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string CardNo
        {
            get { return _CardNo; }
            set { _CardNo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("CreateDate", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("bIsUse", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public bool bIsUse
        {
            get { return _bIsUse; }
            set { _bIsUse = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("OperName", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public string OperName
        {
            get { return _OperName; }
            set { _OperName = value; }
        }
        #endregion
    }
}
