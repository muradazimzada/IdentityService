using IdentityService.Domain.Contract.Services;
using IdentityService.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.Services
{
    public class UserPageAccessService(IService service, ILogger<UserPageAccessService> logger) : IUserPageAccessService
    {
        private readonly IService _service = service;
        private readonly ILogger<UserPageAccessService> _logger = logger;

        public async Task<UserPageAccess> CreateUserPageAccessAsync(UserPageAccess userPageAccess)
        {
            if (userPageAccess == null) throw new ArgumentNullException(nameof(userPageAccess));

            await _service.AddNew(userPageAccess);
            _logger.LogInformation($"UserPageAccess created for User {userPageAccess.UserId} on Page {userPageAccess.AppPageId}.");
            return userPageAccess;
        }

        public async Task<UserPageAccess> GetUserPageAccessByIdAsync(Guid id)
        {
            var userPageAccess = await _service.GetById<UserPageAccess>(id);
            if (userPageAccess == null) throw new KeyNotFoundException("UserPageAccess not found.");

            return userPageAccess;
        }

        public async Task<IEnumerable<UserPageAccess>> GetAllUserPageAccessesAsync()
        {
            return await _service.GetAll<UserPageAccess>(null);
        }

        public async Task UpdateUserPageAccessAsync(UserPageAccess userPageAccess)
        {
            if (userPageAccess == null) throw new ArgumentNullException(nameof(userPageAccess));

            await _service.Update(userPageAccess);
            _logger.LogInformation($"UserPageAccess updated for User {userPageAccess.UserId} on Page {userPageAccess.AppPageId}.");
        }

        public async Task DeleteUserPageAccessAsync(Guid id)
        {
            var userPageAccess = await _service.GetById<UserPageAccess>(id);
            if (userPageAccess == null) throw new KeyNotFoundException("UserPageAccess not found.");

            await _service.Remove(userPageAccess);
            _logger.LogInformation($"UserPageAccess deleted for User {userPageAccess.UserId} on Page {userPageAccess.AppPageId}.");
        }
    }
}
