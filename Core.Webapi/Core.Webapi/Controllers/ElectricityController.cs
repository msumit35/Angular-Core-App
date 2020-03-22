using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Repositories.Interfaces;
using Core.Webapi.Enums;
using Core.Webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ElectricityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Providers")]
        public async Task<IActionResult> GetProviders()
        {
            try
            {
                var providers = await _unitOfWork.ElectricityProviderRepository.GetAllAsync();

                return Ok(new Response
                {
                    Status = (int) ResponseStatus.Success,
                    Data = providers
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = (int) ResponseStatus.InternalServerError,
                    ErrorMessage = "Something went wrong"
                });
            }
        }
    }
}