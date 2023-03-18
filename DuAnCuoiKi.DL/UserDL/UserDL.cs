using Dapper;
using DuAnCuoiKi.Common.Entities;
using DuAnCuoiKi.Common.Resources;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.DL.UserDL
{
    public class UserDL:IUserDL
    {
        public object GetInforUser(Guid userID)
        {
            object userInfor;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"userInforID", userID);
            string storeProcedureName = string.Format(Procedures.Proc_UserInfor_GetInfor, typeof(UserInformation).Name);
            using (var mysqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                userInfor = mysqlConnection.QueryFirstOrDefault<UserInformation>(
                storeProcedureName,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );
            }

            return userInfor;
        }
    }
}
