
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	MemberPoints.cs
* ����:	     ֣��
* ��������:    2011/2/11
* ��������:    ��Ա���ֱ�

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
    /// **�������ƣ���Ա���ֱ�ʵ����
    /// </summary>
    [Serializable]
    [TableMapping("tbMemberPoints")]
    public class MemberPoints : ynhrMemberManage.ORM.EntityObjectBase
    {
        #region ���ݱ����ɱ���
        private string _cnvcMemberCardNo = String.Empty;
        private int _cnnPoints;
        #endregion

        #region ���캯��
        public MemberPoints()
            : base()
        {
        }

        public MemberPoints(DataRow row)
            : base(row)
        {
        }

        public MemberPoints(DataTable table)
            : base(table)
        {
        }

        public MemberPoints(string strXML)
            : base(strXML)
        {
        }
        #endregion

        #region ϵͳ��������

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnvcMemberCardNo", IsPrimaryKey = true, IsIdentity = false, IsVersionNumber = false)]
        public string cnvcMemberCardNo
        {
            get { return _cnvcMemberCardNo; }
            set { _cnvcMemberCardNo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ColumnMapping("cnnPoints", IsPrimaryKey = false, IsIdentity = false, IsVersionNumber = false)]
        public int cnnPoints
        {
            get { return _cnnPoints; }
            set { _cnnPoints = value; }
        }
        #endregion
    }
}
