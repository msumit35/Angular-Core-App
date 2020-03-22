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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMobileRechargeService _mobileRechargeService;

        public PaymentController(IUnitOfWork unitOfWork, IMobileRechargeService mobileRechargeService)
        {
            _unitOfWork = unitOfWork;
            _mobileRechargeService = mobileRechargeService;
        }

        [HttpGet("Modes")]
        public async Task<IActionResult> GetPaymentModes()
        {
            try
            {
                var modes = await _unitOfWork.PaymentModeRepository.GetAllAsync();

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
                    entity = await _mobileRechargeService.MakePayment(payment);

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