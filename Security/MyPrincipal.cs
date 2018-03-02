using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;

namespace ynhrMemeberManage.Security
{
    public class MyPrincipal : System.Security.Principal.IPrincipal
    {
        private MyIdentity _Identity;
        private List<string> _Func;
        private List<string> _allFunc;
        public MyPrincipal(MyIdentity identity, List<string> lFunc,List<string> allFunc)
        {
            this._Identity = identity;
            this._Func = lFunc;
            this._allFunc = allFunc;
        }
        public MyPrincipal()
        {
            this._Identity = new MyIdentity();//new MyIdentity(new ynhrMemberManage.Domain.Oper(), new ynhrMemberManage.Domain.Dept(), "MyPrincipal");
            this._Func = new List<string>();
        }
        #region IPrincipal ≥…‘±

        public System.Security.Principal.IIdentity Identity
        {
            get { return _Identity; }
        }

        public bool IsInRole(string role)
        {
            if (!_allFunc.Contains(role)) return true;
            return _Func.Contains(role);            
        }
        public List<string> Func
        {
            get { return _Func; }
        }
        public List<string> AllFunc
        {
            get { return _allFunc; }
        }
        #endregion
    }
}
