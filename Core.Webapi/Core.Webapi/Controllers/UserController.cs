using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Core.Repositories.Interfaces;
using Core.Webapi.Attributes;
using Core.Webapi.Enums;
using Core.Webapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Webapi.Controllers
{
    [ExceptionLogger]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
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
            if (model == null)
            {
                BadRequest();
            }

            var entity = Converter.GetUser(model);

            var user = await _unitOfWork.UserRepository.Create(entity);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new { UserId = user.Id });
        }
    }
}