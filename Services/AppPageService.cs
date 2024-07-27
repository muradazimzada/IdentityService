using IdentityService.Domain.Contract.Repositories;
using IdentityService.Domain.Contract.Services;
using IdentityService.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.Services
{
    public class AppPageService(IService systemService, ILogger<AppPageService> logger) : IAppPageService
    {
        private readonly IService _systemService = systemService;
        private readonly ILogger<AppPageService> _logger = logger;

        public async Task<AppPage> CreateAppPageAsync(AppPage appPage)
        {
            if (appPage == null) throw new ArgumentNullException(nameof(appPage));

            await _systemService.AddNew(appPage);
            _logger.LogInformation($"AppPage {appPage.Name} created successfully.");
            return appPage;
        }

        public async Task<AppPage> GetAppPageByIdAsync(Guid id)
        {
            var appPage = await _systemService.GetById<AppPage>(id);
            if (appPage == null) throw new KeyNotFoundException("AppPage not found.");

            return appPage;
        }
         
        public async Task<IEnumerable<AppPage>> GetAllAppPagesAsync()
        {
            return await _systemService.GetAll<AppPage>(null);
        }

        public async Task UpdateAppPageAsync(AppPage appPage)
        {
            if (appPage == null) throw new ArgumentNullException(nameof(appPage));

            await _systemService.Update(appPage);
            _logger.LogInformation($"AppPage {appPage.Name} updated successfully.");
        }

        public async Task DeleteAppPageAsync(Guid id)
        {
            var appPage = await _systemService.GetById<AppPage>(id);
            if (appPage == null) throw new KeyNotFoundException("AppPage not found.");

            await _systemService.Remove(appPage);
            _logger.LogInformation($"AppPage {appPage.Name} deleted successfully.");
        }
    }
}
