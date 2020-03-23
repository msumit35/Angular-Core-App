using Core.Entities;
using Core.Repositories.Interfaces;
using Core.Webapi.Models;
using Core.Webapi.Services.Interfaces;
using System;
using System.Threading.Tasks;
using PaymentStatus = Core.Webapi.Models.PaymentStatus;

namespace Core.Webapi.Services
{
    public class MobileRechargeService : MakePaymentService, IMobileRechargeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MobileRechargeService(IUnitOfWork unitOfWork)
        : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<Payment> MakePayment(PaymentModel model)
        {
            try
            {
                var payment = await base.MakePayment(model);
                var mobileRecharge = new MobileRechargeBill();
                mobileRecharge.Type = await _unitOfWork.MobileRechargeTypeRepository.GetByIdAsync(model.MobileRecharge.MobileRechargeTypeId);
                mobileRecharge.ServiceProvider =
                    await _unitOfWork.ServiceProviderRepository.GetByIdAsync(model.MobileRecharge.ServiceProviderId);

                payment = await _unitOfWork.PaymentRepository.Create(payment);
                mobileRecharge = await _unitOfWork.MobileRechargeBillRepository.Create(mobileRecharge);

                var link = new LinkPaymentMobileRechargeBill();
                link.MobileRechargeBill = mobileRecharge;
                link.Payment = payment;

                await _unitOfWork.LinkPaymentsMobileRechargeRepository.Create(link);

                await _unitOfWork.SaveChangesAsync();

                return payment;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
