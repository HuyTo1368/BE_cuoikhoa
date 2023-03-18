using DuAnCuoiKi.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.BL.UserBL
{
    public interface IUserBL
    {
        /// <summary>
        /// Lấy thông tin người dùng
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ServiceResponse GetInforUser(Guid userID);
    }
}
