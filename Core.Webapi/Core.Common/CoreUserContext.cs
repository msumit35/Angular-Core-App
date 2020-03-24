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
        private const string MasterUserId = "ab3c1a56-50bf-4aad-a481-49ab73e3bcee"; //in case of register, use this user id

        public CoreUserContext(IHttpContextAccessor httpContextAccessor)
        {
            _claims = httpContextAccessor.HttpContext.User.Claims;
        }

        public Guid UserId
        {
            get
            {
                var id = _claims?.FirstOrDefault(x => x.Type == ClaimsTypes.UserId.ToString())?.Value ?? MasterUserId;
                return Guid.Parse(id);
            }
        }
    }
}
