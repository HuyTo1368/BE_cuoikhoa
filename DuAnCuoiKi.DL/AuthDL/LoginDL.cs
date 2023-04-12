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
    public class LoginDL : ILoginDL
    {
        /// <summary>
        /// Kiểm tra thông tin đăng nhập
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="UserPassword"></param>
        /// <returns></returns>
        public Guid CheckLogin(string userName, string UserPassword) {
            Guid userID;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"userName", userName);
            parameters.Add($"userPassword", UserPassword);
            string storeProcedureName = string.Format(Procedures.Proc_CheckLogin, typeof(User).Name);
            using (var mysqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                userID = mysqlConnection.QueryFirstOrDefault<Guid>(
                storeProcedureName,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );
            }
            return userID;
        }

        /// <summary>
        /// Thực hiện thêm thông tin 
        /// </summary>
        /// <param name="userInformation"></param>
        /// <returns></returns>
        public Guid InsertUser(UserInformation userInformation, string userName, string passWord)
        {
            var userID = Guid.NewGuid();
            var user = new User();

            DynamicParameters parameters_checkUserName = new DynamicParameters();
            parameters_checkUserName.Add($"userName", userName);

            DynamicParameters parameters = new DynamicParameters();
            var properties = typeof(UserInformation).GetProperties();

            parameters.Add($"userID", userID);
            parameters.Add($"userName", userName);
            parameters.Add($"passWord", user.MD5String(passWord));

            foreach (var property in properties)
            {
                string propertyName = property.Name;
                var propertyValue = property.GetValue(userInformation, null);
                parameters.Add($"{propertyName}", propertyValue);
            }

            string storeProdureName = String.Format(Procedures.Proc_UserInfor_Add, typeof(UserInformation).Name);
            string storeProdureName_CheckLogin = String.Format(Procedures.Proc_UserLogin_CheckUserName, typeof(UserInformation).Name);
            int numberOfAffectdRows = 0;

            using (var mysqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                string checkUserName = mysqlConnection.QueryFirstOrDefault<string>(storeProdureName_CheckLogin,
                parameters_checkUserName,
                commandType: System.Data.CommandType.StoredProcedure
                );
                if(checkUserName == null && checkUserName == "" )
                {
                    numberOfAffectdRows = mysqlConnection.Execute(storeProdureName,
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
                }
                else
                {
                    numberOfAffectdRows = 0;
                }
            }

            /// Kiểm tra xem số dòng kết quả được thực hiện
            if (numberOfAffectdRows > 0)
            {
                return userID;
            }
            else 
            { 
                return Guid.Empty; 
            }
        }
    }
}
