using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Repositories.Interfaces;
using Core.Webapi.Enums;
using Core.Webapi.Models;
using Core.Webapi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Webapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IMobileRechargeService _mobileRechargeService;

        public MobileController(IMobileRechargeService mobileRechargeService)
        {
            _mobileRechargeService = mobileRechargeService;
        }

        [HttpGet("RechargeTypes")]
        public async Task<IActionResult> GetRechargeTypes()
        {
            try
            {
                var types = await _mobileRechargeService.GetRechargeTypesAsync();

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
                var providers = await _mobileRechargeService.GetServiceProvidersAsync();

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

        [HttpGet("RechargePayments")]
        public async Task<IActionResult> GetMobileRechargeBills()
        {
            try
            {
                var bills = await _mobileRechargeService.GetMobileRechargeBillsAsync();

                return Ok(new Response
                {
                    Data = bills,
                    Status = 200
                });
            }
            catch (Exception e)
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