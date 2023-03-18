using DuAnCuoiKi.Common.DTO;
using DuAnCuoiKi.DL.UserDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.BL.UserBL
{
    public class UserBL:IUserBL
    {
        private IUserDL _userDL;
        
        public UserBL(IUserDL userDL) {
            _userDL = userDL;
        }

        /// <summary>
        /// Lấy thông tin người dùng
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ServiceResponse GetInforUser(Guid userID)
        {

            var result = _userDL.GetInforUser(userID);

            if (result == null || result == String.Empty)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Data = "Sai rôi"
                };
               
            }
            else
            {
                return new ServiceResponse
                {
                    Success = true,
                    Data = result
                };
            }
        }
    }
}
