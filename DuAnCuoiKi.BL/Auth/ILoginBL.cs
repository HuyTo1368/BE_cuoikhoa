﻿using DuAnCuoiKi.Common.DTO;
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
    }
}
