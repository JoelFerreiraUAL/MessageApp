using MessageApp.Application.Common.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Infrastructure.Tenant
{
    public class TenantService : ITenantService
    {
        private readonly IHttpContextAccessor _httpContext;
        public TenantService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public string GetTenantEmail()
        {
            return _httpContext.HttpContext.User?.FindFirst(ClaimTypes.Email).Value;
        }

        public int GetTenantId()
        {
            var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Convert.ToInt16(userId);
        }
    }
}
