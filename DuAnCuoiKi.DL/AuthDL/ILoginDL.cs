using DuAnCuoiKi.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.DL.AuthDL
{
    public interface ILoginDL
    {
        /// <summary>
        /// Kiểm tra thông tin đăng nhập
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="UserPassword"></param>
        /// <returns></returns>
        public Guid CheckLogin(string userName, string UserPassword);

        public Guid InsertUser(UserInformation userInformation, string userName, string passWord);
    }
}
