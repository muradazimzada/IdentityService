using IdentityService.Dtos.ResponseDtos;

namespace IdentityService.Domain.Contract.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponseDto> Login(string username, string password);
        Task<AuthenticationResponseDto> RefreshToken(string refreshToken);

    }
}
