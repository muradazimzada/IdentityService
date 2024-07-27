using IdentityService.Domain.Contract.Services;
using IdentityService.Domain.Entities;
using IdentityService.Dtos.RequestDtos.Authentication;
using IdentityService.Dtos.ResponseDtos;
using IdentityService.Extensions;
using IdentityService.Specifications;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace IdentityService.Services
{
    public class TokenService(IConfiguration configuration, IUserService userService) : ITokenService
    {
        private readonly string _secretKey = configuration["Jwt:Key"];
        private readonly string _validIssuer = configuration["Jwt:Issuer"];

        public ClaimsPrincipal ParseToken(string token)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token), "Token cannot be null.");

            token = token.StartsWith("Bearer ") ? token[7..] : token;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _validIssuer,
                    ValidateAudience = false
                };

                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

                return principal;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool IsTokenValid(string token, string[] roles)
        {
            try
            {
                var principal = ParseToken(token);

                var userAccessInfoClaim = principal.FindFirst("UserAccessInfo")?.Value;

                if (userAccessInfoClaim == null)
                    return false;

                var userAccessInfo = JsonSerializer.Deserialize<UserAccessInfo>(userAccessInfoClaim);
                return userAccessInfo != null && userAccessInfo.Roles.Any(role => roles.Contains(role));
            }
            catch
            {
                return false;
            }
        }
        private static List<string> ConvertAccessesToList(UserPageAccess upg)
        {
            var accesses = new List<string>();
            if (upg.ViewAccess) accesses.Add("View");
            if (upg.EditAccess) accesses.Add("Edit");
            if (upg.DeleteAccess) accesses.Add("Delete");
            if (upg.CreateAccess) accesses.Add("Create");
            return accesses;
        }

        private UserAccessInfo GenerateAccessInfo(User user)
        {
            var userAccessInfo = new UserAccessInfo
            {
                Roles = user.UserRoles.Select(x => x.Role.Name),
                GrantedAccesses = user.UserPageAccesses.Select(upg => new GrantedAccess
                {
                    AppId = upg.AppPage.AppId,
                    PageAccesses = user.UserPageAccesses.Select(pa => new PageAccess
                    {
                        PageId = pa.AppPageId,
                        Accesses = [.. ConvertAccessesToList(pa)],
                    })
                })
            };

            return userAccessInfo;
        }

        public string GenerateAccessToken(User user)
        {
            var userAccessInfo = GenerateAccessInfo(user);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", user.Id.ToString()),
                new Claim("UserName", user.UserName),
                new Claim("Email", user.Email),
                new Claim("UserAccessInfo", JsonSerializer.Serialize(userAccessInfo))
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _validIssuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        public bool ValidateRefreshToken(string token)
        {
            // Implement refresh token validation logic
            return true;
        }

        public string RefreshAccessToken(string refreshToken, User user)
        {
            if (!ValidateRefreshToken(refreshToken) || !user.AllowsTokenRefreshEnabled)
            {
                throw new SecurityTokenException("Invalid refresh token");
            }

            return GenerateAccessToken(user);
        }
        public async Task<bool> IsRequirementsMetAsync(string accessToken, UserAccessInfo accessInfo)
        {
            var principal = ParseToken(accessToken) ?? throw new NotImplementedException();

            var userId = principal.GetGuidClaimValue("Id");

            var user = await userService.GetUserBySpecification(new UserByIdWithIncludes(userId));

            var currentAccessInfo = GenerateAccessInfo(user);

            return CompareAccessInfo(currentAccessInfo, accessInfo);
        }
        /// <summary>
        /// Compares the current access information of the user with the expected access information.
        /// </summary>
        /// <param name="current">The current access information of the user.</param>
        /// <param name="expected">The expected access information to validate against.</param>
        /// <returns>True if the current access information meets or exceeds the expected; otherwise, false.</returns>
        private static bool CompareAccessInfo(UserAccessInfo current, UserAccessInfo expected)
        {
            // Compare roles
            if (!expected.Roles.All(role => current.Roles.Contains(role)))
            {
                return false; // If any expected role is missing, return false.
            }

            // Compare granted accesses
            foreach (var expectedAccess in expected.GrantedAccesses)
            {
                var currentAccess = current.GrantedAccesses.FirstOrDefault(a => a.AppId == expectedAccess.AppId);
                if (currentAccess == null)
                {
                    return false; // Current user does not have any access to an app that is expected.
                }

                foreach (var expectedPageAccess in expectedAccess.PageAccesses)
                {
                    var currentPageAccess = currentAccess.PageAccesses.FirstOrDefault(p => p.PageId == expectedPageAccess.PageId);
                    if (currentPageAccess == null)
                    {
                        return false; // Current user does not have access to a page that is expected.
                    }

                    if (!expectedPageAccess.Accesses.All(access => currentPageAccess.Accesses.Contains(access)))
                    {
                        return false; // Current user does not have all the expected types of access on a page.
                    }
                }
            }

            return true; // All checks passed.
        }

        public async Task<AuthenticationResponseDto> GenerateTokens(User user)
        {
            var accessToken = GenerateAccessToken(user);
            var refreshToken = user.AllowsTokenRefreshEnabled ? GenerateRefreshToken() : null;

            if (refreshToken != null)
            {
                user.RefreshToken = refreshToken;
                await userService.UpdateUser(user);
                await userService.SaveChanges();
            }

            return new AuthenticationResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Code = 200 // Assuming 200 is the success code
            };
        }
    }

}

