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
        public ServiceResponse CheckLogin(string userName, string userPassword);

        public ServiceResponse InsertUser(UserInformation userInformation, string userName, string passWord);
    }
}
