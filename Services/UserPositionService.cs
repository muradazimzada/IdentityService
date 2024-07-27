using IdentityService.Domain.Contract.Services;
using IdentityService.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.Services
{
    public class UserPositionService(IService service, ILogger<UserPositionService> logger) : IUserPositionService
    {
        private readonly IService _service = service;
        private readonly ILogger<UserPositionService> _logger = logger;

        public async Task<UserPosition> CreateUserPositionAsync(UserPosition userPosition)
        {
            if (userPosition == null) throw new ArgumentNullException(nameof(userPosition));

            await _service.AddNew(userPosition);
            _logger.LogInformation($"UserPosition for User {userPosition.UserId} created successfully.");
            return userPosition;
        }

        public async Task<UserPosition> GetUserPositionByIdAsync(Guid id)
        {
            var userPosition = await _service.GetById<UserPosition>(id);
            if (userPosition == null) throw new KeyNotFoundException("UserPosition not found.");

            return userPosition;
        }

        public async Task<IEnumerable<UserPosition>> GetAllUserPositionsAsync()
        {
            return await _service.GetAll<UserPosition>(null);
        }

        public async Task UpdateUserPositionAsync(UserPosition userPosition)
        {
            if (userPosition == null) throw new ArgumentNullException(nameof(userPosition));

            await _service.Update(userPosition);
            _logger.LogInformation($"UserPosition for User {userPosition.UserId} updated successfully.");
        }

        public async Task DeleteUserPositionAsync(Guid id)
        {
            var userPosition = await _service.GetById<UserPosition>(id);
            if (userPosition == null) throw new KeyNotFoundException("UserPosition not found.");

            await _service.Remove(userPosition);
            _logger.LogInformation($"UserPosition for User {userPosition.UserId} deleted successfully.");
        }
    }
}
