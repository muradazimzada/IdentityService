using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.Domain.Contract.Services
{
    public interface IUserPageAccessService
    {
        Task<UserPageAccess> CreateUserPageAccessAsync(UserPageAccess userPageAccess);
        Task<UserPageAccess> GetUserPageAccessByIdAsync(Guid id);
        Task<IEnumerable<UserPageAccess>> GetAllUserPageAccessesAsync();
        Task UpdateUserPageAccessAsync(UserPageAccess userPageAccess);
        Task DeleteUserPageAccessAsync(Guid id);
    }
}
