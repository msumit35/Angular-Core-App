using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories.Interfaces;
using Core.Webapi.Enums;
using Core.Webapi.Models;
using Core.Webapi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentStatus = Core.Webapi.Models.PaymentStatus;

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

        [HttpPost("MakePayment")]
        public async Task<IActionResult> PostPayment(PaymentModel payment)
        {
            try
            {
                var entity = new Payment();
                entity = await _mobileRechargeService.MakePaymentAsync(payment);

                if (entity != null && entity.Id != Guid.Empty && entity.PaymentStatus.Name == PaymentStatus.Success.ToString())
                {
                    return Ok(new Response
                    {
                        Status = 200,
                        Data = new { TransactionId = entity.Id, Status = entity.PaymentStatus.Name }
                    });
                }

                return Ok(new Response
                {
                    Status = 301,
                    Data = new { TransactionId = entity.Id, Status = entity.PaymentStatus.Name, ErrorMessage = entity.FailureDescription }
                });

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = 500,
                    ErrorMessage = "Something went wrong"
                });
            }
        }

        [HttpPost("ServiceProviders")]
        public async Task<IActionResult> PostServiceProvider(MasterModel provider)
        {
            try
            {
                var entity = await _mobileRechargeService.CreateServiceProviderAsync(provider);

                return Ok(new Response
                {
                    Status = 200,
                    Data = new { TransactionId = entity.Id }
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = 500,
                    ErrorMessage = "Something went wrong"
                });
            }
        }

        [HttpPut("ServiceProviders/{id}")]
        public async Task<IActionResult> UpdateServiceProvider(Guid id, [FromBody] MasterModel model)
        {
            try
            {
                await _mobileRechargeService.UpdateServiceProviderAsync(id, model);
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

        [HttpDelete("ServiceProviders/{id}")]
        public async Task<IActionResult> DeleteServiceProvider(Guid id)
        {
            try
            {
                await _mobileRechargeService.RemoveServiceProviderAsync(id);

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