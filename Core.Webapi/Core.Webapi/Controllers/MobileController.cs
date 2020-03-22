using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Repositories.Interfaces;
using Core.Webapi.Enums;
using Core.Webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MobileController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("RechargeTypes")]
        public async Task<IActionResult> GetRechargeTypes()
        {
            try
            {
                var types = await _unitOfWork.MobileRechargeTypeRepository.GetAllAsync();

                return Ok(new Response
                {
                    Status = 200,
                    Data = types
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

        [HttpGet("ServiceProviders")]
        public async Task<IActionResult> GetServiceProviders()
        {
            try
            {
                var providers = await _unitOfWork.ServiceProviderRepository.GetAllAsync();

                return Ok(new Response
                {
                    Status = 200,
                    Data = providers
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = (int)ResponseStatus.InternalServerError,
                    ErrorMessage = "Something went wrong"
                });
            }
        }
    }
}