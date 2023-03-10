using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using DuAnCuoiKi.Common.Entities;
using DuAnCuoiKi.Common.Resources;

namespace DuAnCuoiKi.DL.AuthDL
{
    public class LoginDL:ILoginDL
    {
        public object CheckLogin(string userName, string UserPassword) {
            object inforUser;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"userName", userName);
            parameters.Add($"userPassword", UserPassword);
            string storeProcedureName = string.Format(Procedures.Proc_CheckLogin, typeof(User).Name);
            using (var mysqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                inforUser = mysqlConnection.QueryFirstOrDefault<User>(
                storeProcedureName,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );
            }
            return inforUser;
        }
    }
}
