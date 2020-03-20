using Core.Repositories;
using Core.Webapi.Attributes;
using Core.Webapi.Helpers;
using Core.Webapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [AllowAnonymous]
        [HttpPost("CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] AuthenticateModel authenticate)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUserName(authenticate.Username);

            if (user == null)
            {
                return NotFound();
            }

            if (Hasher.Verify(authenticate.Password, user.Password))
            {
                var model = new UserModel(user, _jwtTokenService.GetToken(user));
                return Ok(model);
            }

            return Unauthorized();
        }
    }
}
