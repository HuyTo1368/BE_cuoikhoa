using DuAnCuoiKi.DL.AuthDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DuAnCuoiKi.Common.DTO;
using DuAnCuoiKi.Common.Resources;
using DuAnCuoiKi.Common.Entities;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Net.WebSockets;
using Microsoft.IdentityModel.JsonWebTokens;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace DuAnCuoiKi.BL.Auth
{
    public class LoginBL:ILoginBL
    {
        private ILoginDL _loginDL;

        public LoginBL(ILoginDL loginDL)
        {
            _loginDL = loginDL;
        }

        public ServiceResponse CheckLogin(string userName, string userPassword)
        {
            var user = new User();
            string password_md5 = user.MD5String(userPassword);

            var check_login = _loginDL.CheckLogin(userName, password_md5);

            if (check_login != Guid.Empty)
            {
                var tokeStr = GenerateJSONWebToken(check_login);
                return new ServiceResponse
                {
                    Success = true,
                    Data = tokeStr
                };
                
            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Data = new ErrorResult(ErrorLogin.DevMsg, ErrorLogin.UserMsg, ErrorLogin.MoreInfo)
                };
            }
        }

        public ServiceResponse InsertUser(UserInformation userInformation, string userName, string passWord)
        {
            var userID = _loginDL.InsertUser(userInformation, userName, passWord);

            if(userID != Guid.Empty)
            {
                var tokenStr = GenerateJSONWebToken(userID);
                return new ServiceResponse
                {
                    Success = true,
                    Data = tokenStr
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Data = new ErrorResult(ErrorLogin.DevMsg, ErrorLogin.UserMsg_CheckUserName, ErrorLogin.MoreInfo)
                };
            }
        }

        /// <summary>
        /// JWT Login
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public string GenerateJSONWebToken(Guid userID)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigJWT.SECRECTKEY));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,userID.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: ConfigJWT.ISSUER,
                audience: ConfigJWT.AUDIENCE,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
    }
}
