using DuAnCuoiKi.DL.AuthDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DuAnCuoiKi.Common.DTO;

namespace DuAnCuoiKi.BL.Auth
{
    public class LoginBL:ILoginBL
    {
        private ILoginDL _loginDL;

        public LoginBL(ILoginDL loginDL)
        {
            _loginDL = loginDL;
        }

        public ServiceResponse CheckLogin(string userName, string userPassword)
        {
            string password_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(userPassword);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                password_md5 += b.ToString("X2");
            }

            var check_login = _loginDL.CheckLogin(userName, password_md5);

            if (check_login != Guid.Empty)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Data = check_login
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Data = check_login
                };
            }
        }
    }
}
