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
using Microsoft.CodeAnalysis.Operations;
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

        [AllowAnonymous]
        [HttpGet("GetTestData")]
        public async Task<string> TestData()
        {
            return "Its working...";
        }

        [AllowAnonymous]
        [HttpGet("GetTestDbData")]
        public async Task<string> TestDbData()
        {
            var test = (await _userService.GetUsersAsync()).FirstOrDefault()?.FirstName;
            return test;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetUsersAsync();

                return Ok(new Response
                {
                    Status = 200,
                    Data = users
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    ErrorMessage = "Something went wrong"
                });
            }
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

                var exist = await _userService.IsUserExistsAsync(model.Username, model.Email);

                if (exist)
                {
                    return Ok(new Response
                    {
                        Data = null,
                        ErrorMessage = "Username or Email already exists",
                        Status = (int) ResponseStatus.UserNotExist
                    });
                }

                var user = await _userService.CreateAsync(model);

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

        [HttpPut("EditUser/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserModel model)
        {
            try
            {
                await _userService.UpdateUserAsync(id, model);
                return Ok(new Response
                {
                    Status = 200,
                    Data = "success"
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    ErrorMessage = "Something went wrong"
                });
            }
        }

        [HttpOptions("Activate/{id}")]
        public async Task<IActionResult> ActivateUser(Guid id)
        {
            try
            {
                await _userService.ActivateUserAsync(id);

                return Ok(new Response
                {
                    Status = 200,
                    Data = "success"
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    ErrorMessage = "Something went wrong"
                });
            }
        }

        [HttpOptions("Deactivate/{id}")]
        public async Task<IActionResult> DeactivateUser(Guid id)
        {
            try
            {
                await _userService.DeactivateUserAsync(id);

                return Ok(new Response
                {
                    Status = 200,
                    Data = "success"
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    ErrorMessage = "Something went wrong"
                });
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);

                return Ok(new Response
                {
                    Status = 200,
                    Data = "success"
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    ErrorMessage = "Something went wrong"
                });
            }
        }

        [HttpOptions("UnDelete/{id}")]
        public async Task<IActionResult> UnDeleteUser(Guid id)
        {
            try
            {
                await _userService.UnDeleteUserAsync(id);

                return Ok(new Response
                {
                    Status = 200,
                    Data = "success"
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    ErrorMessage = "Something went wrong"
                });
            }
        }
    }
}