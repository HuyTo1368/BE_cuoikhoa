using DuAnCuoiKi.BL.Auth;
using DuAnCuoiKi.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAnCuoiKi.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginBL _loginBL;

        public LoginController(ILoginBL loginBL)
        {
            _loginBL = loginBL;
        }

        [HttpGet]
        [Route("login")]
        public IActionResult CheckLogin([FromQuery] string? userName, [FromQuery] string? userPassword)
        {
            try
            {
                var result = _loginBL.CheckLogin(userName, userPassword);
                return StatusCode(StatusCodes.Status200OK, result);
                
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
