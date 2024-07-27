using IdentityService.Domain.Contract.Services;
using IdentityService.Dtos.RequestDtos.Authentication;
using IdentityService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController(ITokenService tokenService) : ControllerBase
    {
        [HttpPost("CheckAccessRequirements")]
        public async Task<IActionResult> CheckAccessRequirements(string accessToken, UserAccessInfo requiredAccessInfo)
        {
            return Ok(await tokenService.IsRequirementsMetAsync(accessToken, requiredAccessInfo));
        }
    }
}
