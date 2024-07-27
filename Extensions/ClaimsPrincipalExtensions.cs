using System.Security.Claims;

namespace IdentityService.Extensions
{

    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Retrieves the value of the first claim with the specified type.
        /// </summary>
        /// <param name="principal">The claims principal from which to retrieve the claim.</param>
        /// <param name="claimName">The name of the claim to retrieve.</param>
        /// <returns>The value of the claim, or null if the claim is not found.</returns>
        public static string GetClaimValue(this ClaimsPrincipal principal, string claimName)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal), "ClaimsPrincipal cannot be null.");

            return principal.FindFirstValue(claimName);
        }

        /// <summary>
        /// Retrieves the value of a specific claim as a Guid, if it exists and is a valid Guid.
        /// </summary>
        /// <param name="principal">The ClaimsPrincipal from which to retrieve the claim.</param>
        /// <param name="claimName">The name of the claim to retrieve.</param>
        /// <returns>
        /// The Guid value of the claim if it exists and can be parsed; otherwise, null.
        /// This method returns null in two scenarios: if the claim does not exist or if the claim value
        /// is not a valid Guid. Consider throwing an exception if the claim must be valid for application logic.
        /// </returns>
        public static Guid GetGuidClaimValue(this ClaimsPrincipal principal, string claimName)
        {
            string value = principal.FindFirstValue(claimName);

            if (Guid.TryParse(value, out Guid result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid user ID in token");
            }

        }
    }


}
