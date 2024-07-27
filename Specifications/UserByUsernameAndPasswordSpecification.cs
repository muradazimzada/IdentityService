using IdentityService.Domain.Entities;
using IdentityService.Repositories;

namespace IdentityService.Specifications
{
    public class UserByUsernameAndPasswordSpecification : BaseSpecification<User>
    {
        public UserByUsernameAndPasswordSpecification(string username, string password)
        {
            Criteria = user => user.UserName == username && user.Password == password;
            AddInclude(u => u.UserRoles);

            AddInclude("UserRoles.Role");
            AddInclude("UserPageAccesses.AppPage");
            AddInclude(u => u.UserPageAccesses);
            AddInclude(u => u.UserPositions);
            // Add additional includes if necessary
        }
    }

}
