using IdentityService.Domain.Entities;
using IdentityService.Dtos.RequestDtos.Authentication;
using IdentityService.Dtos.ResponseDtos;
using System.Security.Claims;

namespace IdentityService.Domain.Contract.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        ClaimsPrincipal ParseToken(string accessToken);
        string GenerateRefreshToken();
        //  bool ValidateAccessToken(string token);
        bool ValidateRefreshToken(string token);
        string RefreshAccessToken(string refreshToken, User user);
        Task<AuthenticationResponseDto> GenerateTokens(User user);
        bool IsTokenValid(string token, string[] roles);
        Task<bool> IsRequirementsMetAsync(string accessToken, UserAccessInfo accessInfo);
    }

}
