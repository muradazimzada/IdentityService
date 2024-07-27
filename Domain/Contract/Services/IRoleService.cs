using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.Domain.Contract.Services
{
    public interface IRoleService
    {
        Task<Role> CreateRoleAsync(Role role);
        Task<Role> GetRoleByIdAsync(Guid id);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(Guid id);
    }
}
