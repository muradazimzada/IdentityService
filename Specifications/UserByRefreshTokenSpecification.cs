using IdentityService.Domain.Entities;
using IdentityService.Repositories;

namespace IdentityService.Specifications
{
    public class UserByRefreshTokenSpecification : BaseSpecification<User>
    {
        public UserByRefreshTokenSpecification(string refreshToken)
        {
            Criteria = user => user.RefreshToken == refreshToken;
            AddInclude(u => u.UserRoles);
            AddInclude("UserRoles.Role"); 

            AddInclude(u => u.UserPageAccesses);
            AddInclude(u => u.UserPositions);
            // Add additional includes if necessary
        }
    }
}
