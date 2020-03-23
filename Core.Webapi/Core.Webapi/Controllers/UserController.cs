using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Core.Repositories.Interfaces;
using Core.Webapi.Attributes;
using Core.Webapi.Enums;
using Core.Webapi.Helpers;
using Core.Webapi.Models;
using Core.Webapi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Core.Webapi.Controllers
{
    [ExceptionLogger]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetUsersAsync();
            var response = new List<UserModel>();

            foreach (var item in users)
            {
                response.Add(new UserModel(item, null));
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> Create([FromBody] UserModel model)
        {
            try
            {
                if (model == null || !ModelState.IsValid)
                {
                    var errors = ModelStateError.GetErrors(ModelState);
                    return StatusCode(StatusCodes.Status400BadRequest, errors);
                }

                var exist = await _userService.IsUserExists(model.Username, model.Email);

                if (exist)
                {
                    return Ok(new Response
                    {
                        Data = null,
                        ErrorMessage = "Username or Email already exists",
                        Status = (int) ResponseStatus.UserNotExist
                    });
                }

                var user = await _userService.Create(model);

                return Ok(new Response
                {
                    Status = (int) ResponseStatus.Success,
                    Data = user.Id
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    ErrorMessage = "Something went wrong"
                });
            }
        }
    }
}