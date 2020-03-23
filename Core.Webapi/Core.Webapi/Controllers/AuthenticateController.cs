using Core.Webapi.Attributes;
using Core.Webapi.Enums;
using Core.Webapi.Helpers;
using Core.Webapi.Models;
using Core.Webapi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Core.Webapi.Controllers
{
    [ExceptionLogger]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthenticateController(IUserService userService, IJwtTokenService jwtTokenService)
        {
            _userService = userService;
            _jwtTokenService = jwtTokenService;
        }

        [HttpGet("Test")]
        public async Task<string> GetTestValue()
        {
            return "Hello World";
        }

        [HttpPost("CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] AuthenticateModel authenticate)
        {
            try
            {
                var user = await _userService.GetUserByUserName(authenticate.Username);

                if (user == null)
                {
                    return Ok(new Response
                    {
                        Status = (int)ResponseStatus.UserNotExist,
                        Data = null,
                        ErrorMessage = "User does not exist"
                    });
                }

                if (Hasher.Verify(authenticate.Password, user.Password))
                {
                    var model = new UserModel(user, _jwtTokenService.GetToken(user));
                    return Ok(new Response
                    {
                        Status = (int)ResponseStatus.Success,
                        Data = model,
                        ErrorMessage = null
                    });
                }

                return Ok(new Response
                {
                    Status = (int)ResponseStatus.UsernamePasswordNotMatch,
                    Data = null,
                    ErrorMessage = "Username or password does not match"
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
