using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccessLayer;
using Core.Repositories.Interfaces;

namespace Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoreContext _context;

        public UnitOfWork(CoreContext context, IUserRepository userRepository, IExceptionLogRepository exceptionLogRepository,
            IElectricityBillRepository electricityBillRepository, IElectricityProviderRepository electricityProviderRepository,
            IMobileRechargeBillRepository mobileRechargeBillRepository, IMobileRechargeTypeRepository mobileRechargeTypeRepository,
            IPaymentModeRepository paymentModeRepository, IPaymentRepository paymentRepository, IPaymentStatusRepository paymentStatusRepository,
            IServiceProviderRepository serviceProviderRepository)
        {
            _context = context;
            UserRepository = userRepository;
            ExceptionLogRepository = exceptionLogRepository;
            ElectricityBillRepository = electricityBillRepository;
            ElectricityProviderRepository = electricityProviderRepository;
            MobileRechargeBillRepository = mobileRechargeBillRepository;
            MobileRechargeTypeRepository = mobileRechargeTypeRepository;
            PaymentModeRepository = paymentModeRepository;
            PaymentRepository = paymentRepository;
            PaymentStatusRepository = paymentStatusRepository;
            ServiceProviderRepository = serviceProviderRepository;
        }

        public IUserRepository UserRepository { get; }

        public IExceptionLogRepository ExceptionLogRepository { get; }

        public IElectricityBillRepository ElectricityBillRepository { get; }

        public IElectricityProviderRepository ElectricityProviderRepository { get; }

        public IMobileRechargeBillRepository MobileRechargeBillRepository { get; }

        public IMobileRechargeTypeRepository MobileRechargeTypeRepository { get; }

        public IPaymentModeRepository PaymentModeRepository { get; }

        public IPaymentRepository PaymentRepository { get; }

        public IPaymentStatusRepository PaymentStatusRepository { get; }

        public IServiceProviderRepository ServiceProviderRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
