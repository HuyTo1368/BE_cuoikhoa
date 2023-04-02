using DuAnCuoiKi.DL.AuthDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DuAnCuoiKi.Common.DTO;
using DuAnCuoiKi.Common.Resources;
using DuAnCuoiKi.Common.Entities;

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
            var user = new User();
            string password_md5 = user.MD5String(userPassword);

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
                    Data = new ErrorResult(ErrorLogin.DevMsg, ErrorLogin.UserMsg, ErrorLogin.MoreInfo)
                };
            }
        }

        public ServiceResponse InsertUser(UserInformation userInformation, string userName, string passWord)
        {
            var userID = _loginDL.InsertUser(userInformation, userName, passWord);

            if(userID != Guid.Empty)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Data = userID
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Data = new ErrorResult(ErrorLogin.DevMsg, ErrorLogin.UserMsg_CheckUserName, ErrorLogin.MoreInfo)
                };
            }
        }
    }
}
