using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Repositories.Interfaces;
using Core.Webapi.Enums;
using Core.Webapi.Models;
using Core.Webapi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace Core.Webapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricityController : ControllerBase
    {
        private readonly IElectricityService _electricityService;

        public ElectricityController(IElectricityService electricityService)
        {
            _electricityService = electricityService;
        }

        [HttpGet("Providers")]
        public async Task<IActionResult> GetProviders()
        {
            try
            {
                var providers = await _electricityService.GetElectricityProviders();

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

        [HttpGet("ElectricityPayments")]
        public async Task<IActionResult> GetElectricityBills()
        {
            try
            {
                var bills = await _electricityService.GetElectricityBills();

                return Ok(new Response
                {
                    Status = (int)ResponseStatus.Success,
                    Data = bills
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