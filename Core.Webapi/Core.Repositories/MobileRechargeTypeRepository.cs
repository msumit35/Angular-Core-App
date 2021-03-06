﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccessLayer;
using Core.Entities;
using Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class MobileRechargeTypeRepository : Repository<MobileRechargeType>, IMobileRechargeTypeRepository
    {
        public MobileRechargeTypeRepository(CoreContext context)
            : base(context)
        {
        }
    }
}
