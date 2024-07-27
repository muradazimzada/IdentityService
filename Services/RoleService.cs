using IdentityService.Domain.Contract.Services;
using IdentityService.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.Services
{
    public class RoleService(IService service, ILogger<RoleService> logger) : IRoleService
    {
        private readonly IService _service = service;
        private readonly ILogger<RoleService> _logger = logger;

        public async Task<Role> CreateRoleAsync(Role role)
        {
            if (role == null) throw new ArgumentNullException(nameof(role));

            await _service.AddNew<Role>(role);
            _logger.LogInformation($"Role {role.Name} created successfully.");
            return role;
        }

        public async Task<Role> GetRoleByIdAsync(Guid id)
        {
            var role = await _service.GetById<Role>(id);
            if (role == null) throw new KeyNotFoundException("Role not found.");

            return role;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _service.GetAll<Role>(null); // Passing null as specification
        }

        public async Task UpdateRoleAsync(Role role)
        {
            if (role == null) throw new ArgumentNullException(nameof(role));

            await _service.Update<Role>(role);
            _logger.LogInformation($"Role {role.Name} updated successfully.");
        }

        public async Task DeleteRoleAsync(Guid id)
        {
            var role = await _service.GetById<Role>(id);
            if (role == null) throw new KeyNotFoundException("Role not found.");

            await _service.Remove<Role>(role);
            _logger.LogInformation($"Role {role.Name} deleted successfully.");
        }
    }
}
