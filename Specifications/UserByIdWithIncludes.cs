using IdentityService.Domain.Entities;
using IdentityService.Repositories;

namespace IdentityService.Specifications
{
    public class UserByIdWithIncludes : BaseSpecification<User>
    {
        public UserByIdWithIncludes(Guid userId)
        {
            Criteria = user => user.Id == userId;

            AddInclude(u => u.UserRoles);
            AddInclude("UserRoles.Role");
            AddInclude("UserPageAccesses.AppPage");
            AddInclude(u => u.UserPageAccesses);
            AddInclude(u => u.UserPositions);
        }
    }
}
