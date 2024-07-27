using IdentityService.Domain.Contract.Services;
using IdentityService.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.Services
{
    public class UserRoleService(IService service, ILogger<UserRoleService> logger) : IUserRoleService
    {
        private readonly IService _service = service;
        private readonly ILogger<UserRoleService> _logger = logger;

        public async Task<UserRole> CreateUserRoleAsync(UserRole userRole)
        {
            if (userRole == null) throw new ArgumentNullException(nameof(userRole));

            await _service.AddNew(userRole);
            _logger.LogInformation($"UserRole for User {userRole.UserId} and Role {userRole.RoleId} created successfully.");
            return userRole;
        }

        public async Task<UserRole> GetUserRoleByIdAsync(Guid id)
        {
            var userRole = await _service.GetById<UserRole>(id);
            if (userRole == null) throw new KeyNotFoundException("UserRole not found.");

            return userRole;
        }

        public async Task<IEnumerable<UserRole>> GetAllUserRolesAsync()
        {
            return await _service.GetAll<UserRole>(null);
        }

        public async Task UpdateUserRoleAsync(UserRole userRole)
        {
            if (userRole == null) throw new ArgumentNullException(nameof(userRole));

            await _service.Update(userRole);
            _logger.LogInformation($"UserRole for User {userRole.UserId} and Role {userRole.RoleId} updated successfully.");
        }

        public async Task DeleteUserRoleAsync(Guid id)
        {
            var userRole = await _service.GetById<UserRole>(id);
            if (userRole == null) throw new KeyNotFoundException("UserRole not found.");

            await _service.Remove(userRole);
            _logger.LogInformation($"UserRole for User {userRole.UserId} and Role {userRole.RoleId} deleted successfully.");
        }
    }
}
