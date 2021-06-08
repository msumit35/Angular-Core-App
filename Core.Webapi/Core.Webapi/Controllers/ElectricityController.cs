using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Core.Repositories.Interfaces;
using Core.Webapi.Enums;
using Core.Webapi.Models;
using Core.Webapi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using PaymentStatus = Core.Webapi.Models.PaymentStatus;

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

        [HttpPost("MakePayment")]
        public async Task<IActionResult> PostPayment(PaymentModel payment)
        {
            try
            {
                var entity = new Payment();
                entity = await _electricityService.MakePaymentAsync(payment);

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

        [HttpPost("Providers")]
        public async Task<IActionResult> PostElectricityProvider(MasterModel provider)
        {
            try
            {
                var entity = await _electricityService.CreateElectricityProviderAsync(provider);

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

        [HttpPut("Providers/{id}")]
        public async Task<IActionResult> UpdateElectricityProvider(Guid id, [FromBody] MasterModel model)
        {
            try
            {
                await _electricityService.UpdateElectricityProviderAsync(id, model);
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

        [HttpDelete("Providers/{id}")]
        public async Task<IActionResult> DeleteElectricityProvider(Guid id)
        {
            try
            {
                await _electricityService.RemoveElectricityProviderAsync(id);

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