using Core.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Core.Common.Enums;

namespace Core.Common
{
    public class CoreUserContext : ICoreUserContext
    {
        private readonly IEnumerable<Claim> _claims;

        public CoreUserContext(IHttpContextAccessor httpContextAccessor)
        {
            _claims = httpContextAccessor.HttpContext.User.Claims;
        }

        public Guid UserId
        {
            get
            {
                return Guid.Parse(_claims?.FirstOrDefault(x => x.Type == ClaimsTypes.UserId.ToString())?.Value);
            }
        }
    }
}
