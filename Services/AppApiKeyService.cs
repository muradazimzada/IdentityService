using IdentityService.Domain.Contract.Repositories;
using IdentityService.Domain.Contract.Services;
using IdentityService.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.Services
{
    public class AppApiKeyService(IService systemService, ILogger<AppApiKeyService> logger) : IAppApiKeyService
    {
        private readonly IService _systemService = systemService;
        private readonly ILogger<AppApiKeyService> _logger = logger;

        public async Task<AppApiKey> CreateApiKeyAsync(AppApiKey appApiKey)
        {
            if (appApiKey == null) throw new ArgumentNullException(nameof(appApiKey));

            await _systemService.AddNew(appApiKey);
            _logger.LogInformation($"API Key for App {appApiKey.AppId} created successfully.");
            return appApiKey;
        }

        public async Task<AppApiKey> GetApiKeyByIdAsync(Guid id)
        {
            var apiKey = await _systemService.GetById<AppApiKey>(id);
            if (apiKey == null) throw new KeyNotFoundException("API Key not found.");

            return apiKey;
        }

    

        public async Task<IEnumerable<AppApiKey>> GetAllApiKeysAsync()
        {
            return await _systemService.GetAll<AppApiKey>(null);
        }

        public async Task UpdateApiKeyAsync(AppApiKey appApiKey)
        {
            if (appApiKey == null) throw new ArgumentNullException(nameof(appApiKey));

            await _systemService.Update(appApiKey);
            _logger.LogInformation($"API Key for App {appApiKey.AppId} updated successfully.");
        }

        public async Task DeleteApiKeyAsync(Guid id)
        {
            var apiKey = await _systemService.GetById<AppApiKey>(id);
            if (apiKey == null) throw new KeyNotFoundException("API Key not found.");

            await _systemService.Remove(apiKey);
            _logger.LogInformation($"API Key for App {apiKey.AppId} deleted successfully.");
        }
    }
}
