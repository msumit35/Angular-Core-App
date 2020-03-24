using Core.Repositories.Interfaces;
using Core.Webapi.Enums;
using Core.Webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Webapi.Services.Interfaces;

namespace Core.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMobileRechargeService _mobileRechargeService;
        private readonly IPaymentService _paymentService;

        public PaymentController(IMobileRechargeService mobileRechargeService, IPaymentService paymentService)
        {
            _mobileRechargeService = mobileRechargeService;
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

        [HttpPost("MakePayment")]
        public async Task<IActionResult> PostPayment(PaymentModel payment)
        {
            try
            {
                var entity = new Payment();
                if (payment.Module == PaymentModule.MobileRecharge)
                {
                    entity = await _mobileRechargeService.MakePaymentAsync(payment);
                }
                else
                {

                }

                return Ok(new Response
                {
                    Status = 200,
                    Data = entity.Id
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
    }
}