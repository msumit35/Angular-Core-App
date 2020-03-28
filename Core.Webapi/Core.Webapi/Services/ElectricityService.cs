using Core.Common.Interfaces;
using Core.Entities;
using Core.Repositories.Interfaces;
using Core.Webapi.Models;
using Core.Webapi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exception = System.Exception;

namespace Core.Webapi.Services
{
    public class ElectricityService : MakePaymentService, IElectricityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoreUserContext _userContext;

        public ElectricityService(IUnitOfWork unitOfWork, ICoreUserContext userContext)
            : base(unitOfWork, userContext)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
        }

        public async Task<IEnumerable<ElectricityProvider>> GetElectricityProviders()
        {
            return await _unitOfWork.ElectricityProviderRepository.GetAllAsync();
        }

        public async Task<IEnumerable<ElectricityBillModel>> GetElectricityBills()
        {
            try
            {
                var bills = await _unitOfWork.ElectricityBillRepository.GetElectricityBillsByCreatedById(_userContext.UserId);
                var paymentIds = bills.Select(s => s.PaymentElectricityBills.FirstOrDefault()?.PaymentId ?? Guid.Empty);
                var payments = await _unitOfWork.PaymentRepository.GetPaymentsByIds(paymentIds);

                var list = from b in bills
                    join p in payments on b.PaymentElectricityBills.FirstOrDefault()?.PaymentId equals p.Id
                    select new ElectricityBillModel
                    {
                        ConsumerNumber = b.ConsumerNumber,
                        Provider = b.Provider.Name,
                        Status = p.PaymentStatus.Name,
                        PaymentMode = p.PaymentMode.Name,
                        Amount = p.Amount,
                        CreatedOn = p.CreatedOn
                    };

                return list;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public override async Task<Payment> MakePaymentAsync(PaymentModel model)
        {
            try
            {
                var payment = await base.MakePaymentAsync(model);

                var electricityBill = new ElectricityBill
                {
                    ConsumerNumber = model.ElectricityRecharge.ConsumerNumber,
                    Provider = await _unitOfWork.ElectricityProviderRepository.GetByIdAsync(model.ElectricityRecharge
                        .ElectricityProviderId),
                    User = payment.User
                };

                var link = new LinkPaymentElectricityBill
                {
                    Payment = payment,
                    ElectricityBill = electricityBill
                };

                electricityBill.PaymentElectricityBills.Add(link);

                await _unitOfWork.ElectricityBillRepository.Create(electricityBill);

                await _unitOfWork.SaveChangesAsync();

                return payment;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
