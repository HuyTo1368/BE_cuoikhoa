using DuAnCuoiKi.BL.Auth;
using DuAnCuoiKi.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace DuAnCuoiKi.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginBL _loginBL;

        public AuthController(ILoginBL loginBL)
        {
            _loginBL = loginBL;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult CheckLogin([FromQuery] string? userName, [FromQuery] string? userPassword)
        {
            try
            {
                var result = _loginBL.CheckLogin(userName, userPassword);
                if(result.Success)
                {
                    return StatusCode(StatusCodes.Status200OK, result.Data);
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, result.Data);
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Route("SingUp")]
        public IActionResult AddUser([FromBody] UserInformation UserInfor, [FromQuery] string userName, [FromQuery] string passWord)
        {
            try
            {
                var result = _loginBL.InsertUser(UserInfor, userName, passWord);
                if(result.Success)
                {
                    return StatusCode(StatusCodes.Status200OK, result.Data);
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, result.Data);
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
