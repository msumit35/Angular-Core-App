using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccessLayer;
using Core.Repositories.Interfaces;

namespace Core.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IExceptionLogRepository ExceptionLogRepository { get; }
        Task<int> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoreContext _context;

        public UnitOfWork(CoreContext context, IUserRepository userRepository, IExceptionLogRepository exceptionLogRepository)
        {
            _context = context;
            UserRepository = userRepository;
            ExceptionLogRepository = exceptionLogRepository;
        }

        public IUserRepository UserRepository { get; }

        public IExceptionLogRepository ExceptionLogRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
