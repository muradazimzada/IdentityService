using IdentityService.Dtos.ResponseDtos;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Contract.Services;
using Microsoft.AspNetCore.Mvc;
using IdentityService.Specifications;
using IdentityService.Dtos.RequestDtos.Authentication;

namespace IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IUserService userService, ITokenService tokenService) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var user = await userService.GetUserBySpecification(new UserByUsernameAndPasswordSpecification(login.UserName, login.Password));
            if (user != null && !user.IsLocked)
            {
                var authResponse = await tokenService.GenerateTokens(user);
                return Ok(authResponse);
            }

            return Unauthorized();
        }

        
    }
}
