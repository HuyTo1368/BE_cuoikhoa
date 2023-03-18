using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.DL.UserDL
{
    public interface IUserDL
    {
        /// <summary>
        /// Lấy thông tin người dùng
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public object GetInforUser(Guid userID);
    }
}
