using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccessLayer;
using Core.Entities;
using Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class ServiceProviderRepository : Repository<ServiceProvider>, IServiceProviderRepository
    {
        public ServiceProviderRepository(CoreContext context)
            : base(context)
        {
        }
    }
}
