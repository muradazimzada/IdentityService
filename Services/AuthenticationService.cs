using IdentityService.Domain.Contract.Services;
using IdentityService.Dtos.ResponseDtos;
using IdentityService.Specifications;

namespace IdentityService.Services
{
    public class AuthenticationService(IUserService userService, ITokenService tokenService) : IAuthenticationService
    {
        public async Task<AuthenticationResponseDto> Login(string username, string password)
        {
            var users = await userService.GetUsersBySpecification(new UserByUsernameAndPasswordSpecification(username, password));

            var user = users.FirstOrDefault();

            if (user == null || user.IsLocked)
            {
                throw new UnauthorizedAccessException("Invalid credentials or account is locked");
            }

            var accessToken = tokenService.GenerateAccessToken(user);
            var refreshToken = user.AllowsTokenRefreshEnabled ? tokenService.GenerateRefreshToken() : null;

            return new AuthenticationResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Code = 200 // Assuming 200 is the success code
            };
        }

        public async Task<AuthenticationResponseDto> RefreshToken(string refreshToken)
        {
            var user = await userService.GetUserBySpecification(new UserByRefreshTokenSpecification(refreshToken));
            if (user == null || !user.AllowsTokenRefreshEnabled)
            {
                throw new UnauthorizedAccessException("Invalid refresh token or user does not allow token refresh");
            }

            var newAccessToken = tokenService.RefreshAccessToken(refreshToken, user);

            return new AuthenticationResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = refreshToken, // You can choose to regenerate the refresh token if needed
                Code = 200 // Assuming 200 is the success code
            };
        }
    }

}
