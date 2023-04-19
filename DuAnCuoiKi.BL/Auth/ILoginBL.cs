using DuAnCuoiKi.Common.DTO;
using DuAnCuoiKi.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.BL.Auth
{
    public interface ILoginBL
    {
        /// <summary>
        /// Kiểm tra thông tin đăng nhập
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public ServiceResponse CheckLogin(string userName, string userPassword);

        /// <summary>
        /// Đăng kí mới
        /// </summary>
        /// <param name="userInformation"></param>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public ServiceResponse InsertUser(UserInformation userInformation, string userName, string passWord);
    }
}
