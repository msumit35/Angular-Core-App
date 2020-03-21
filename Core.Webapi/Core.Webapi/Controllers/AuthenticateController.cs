using Core.Repositories;
using Core.Webapi.Attributes;
using Core.Webapi.Helpers;
using Core.Webapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Core.Webapi.Enums;

namespace Core.Webapi.Controllers
{
    [ExceptionLogger]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthenticateController(IUnitOfWork unitOfWork, IJwtTokenService jwtTokenService)
        {
            _unitOfWork = unitOfWork;
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
            var user = await _unitOfWork.UserRepository.GetUserByUserName(authenticate.Username);

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
    }
}
