using System;
using System.Collections.Generic;
using System.Text;
using ynhrMemberManage.Domain;

namespace ynhrMemeberManage.Security
{
    /// <summary>
    /// 自定义用户信息
    /// </summary>
    public class MyIdentity : System.Security.Principal.IIdentity 
    {
        private Oper _oper;
        private Dept _dept;
        private string _AuthenticationType;
        //private int _iDiscount;
        public MyIdentity(Oper oper,Dept dept, string authenticationType)
        {
            this._oper = oper;
            this._AuthenticationType = authenticationType;
            //this._iDiscount = discount;
            this._dept = dept;
        }
        public MyIdentity()
        {
            this._oper = new Oper();
            this._AuthenticationType = "MyIdentity";
            this._dept = new Dept();
        }
        public Oper oper
        {
            get { return _oper; }
        }
        public int iDiscount
        {
            get 
            {
                if (_dept.cnnDeptID == 0) return 0;
                else return _dept.cnnDiscount; 
            }
        }
        public Dept dept
        {
            get { return _dept; }
        }
        #region IIdentity 成员       
        public string AuthenticationType
        {
            get { return _AuthenticationType; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get { return _oper.cnvcOperName; }
        }

        #endregion
    }
}
