using Core.Repositories.Interfaces;
using Core.Webapi.Enums;
using Core.Webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Webapi.Services.Interfaces;
using PaymentStatus = Core.Webapi.Models.PaymentStatus;

namespace Core.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("Modes")]
        public async Task<IActionResult> GetPaymentModes()
        {
            try
            {
                var modes = await _paymentService.GetPaymentModesAsync();

                return Ok(new Response
                {
                    Status = 200,
                    Data = modes
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

        [HttpPost("Modes")]
        public async Task<IActionResult> PostPaymentMode(MasterModel provider)
        {
            try
            {
                var entity = await _paymentService.CreatePaymentModeAsync(provider);

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

        [HttpPut("Modes/{id}")]
        public async Task<IActionResult> UpdatePaymentMode(Guid id, [FromBody] MasterModel model)
        {
            try
            {
                await _paymentService.UpdatePaymentModeAsync(id, model);
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

        [HttpDelete("Modes/{id}")]
        public async Task<IActionResult> DeletePaymentMode(Guid id)
        {
            try
            {
                await _paymentService.RemovePaymentModeAsync(id);

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