using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using DuAnCuoiKi.Common.Entities

namespace DuAnCuoiKi.DL.AuthDL
{
    public class LoginDL:ILoginDL
    {
        public object CheckLogin(string userName, string UserPassword) {
            object user;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"userName", userName);
            parameters.Add($"userPassword", UserPassword);
            string storeProcedureName = string.Format(Procedures.Proc_InforOne, typeof(User).Name);
            return { }
        };
    }
}
