using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.Domain.Contract.Services
{
    public interface IUserRoleService
    {
        Task<UserRole> CreateUserRoleAsync(UserRole userRole);
        Task<UserRole> GetUserRoleByIdAsync(Guid id);
        Task<IEnumerable<UserRole>> GetAllUserRolesAsync();
        Task UpdateUserRoleAsync(UserRole userRole);
        Task DeleteUserRoleAsync(Guid id);
    }
}
