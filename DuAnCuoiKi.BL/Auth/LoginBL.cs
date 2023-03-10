using DuAnCuoiKi.DL.AuthDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.BL.Auth
{
    public class LoginBL:ILoginBL
    {
        private ILoginDL _loginDL;

        public LoginBL(ILoginDL loginDL)
        {
            _loginDL = loginDL;
        }

        public object CheckLogin(string userName, string userPassword)
        {
            return _loginDL.CheckLogin(userName, userPassword);
        }
    }
}
