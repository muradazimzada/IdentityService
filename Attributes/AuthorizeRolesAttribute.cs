using IdentityService.Domain.Contract.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IdentityService.Attributes
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class AuthorizeRolesAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public AuthorizeRolesAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenService = context.HttpContext.RequestServices.GetService<ITokenService>();
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (token == null || !tokenService.IsTokenValid(token, _roles))
            {
                context.Result = new ForbidResult();
                return;
            }
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}