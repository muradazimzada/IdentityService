using IdentityService.Domain.Contract.Services;
using IdentityService.Domain.Entities;
using IdentityService.Repositories;
 

namespace IdentityService.Services
{
    public class AppService(IService systemService, ILogger<AppService> logger) : IAppService
    {
        private readonly IService _systemService = systemService;
        private readonly ILogger<AppService> _logger = logger;

        public async Task AddApp(App app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            await _systemService.AddNew(app);
            _logger.LogInformation($"App {app.Name} created successfully.");
        }

        public async Task UpdateApp(App app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            await _systemService.Update(app);
            _logger.LogInformation($"App {app.Name} updated successfully.");
        }

        public async Task DeleteApp(App app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            await _systemService.Remove(app);
            _logger.LogInformation($"App {app.Name} deleted successfully.");
        }

        public async Task<App> GetAppById(Guid id)
        {
            var app = await _systemService.GetById<App>(id);
            if (app == null) throw new KeyNotFoundException("App not found.");

            return app;
        }

        public async Task<IEnumerable<App>> GetAllApps()
        {
            return await _systemService.GetAll<App>(null);
        }

        public async Task<IEnumerable<App>> GetAppsBySpecification(BaseSpecification<App> spec)
        {
            return await _systemService.GetAll(spec);
        }

        public async Task<App> GetAppBySpecification(BaseSpecification<App> spec)
        {
            var baseSpec = spec as BaseSpecification<App>;
            return (await _systemService.GetAll(spec, baseSpec?.Includes)).FirstOrDefault();
        }

        public async Task SaveChanges()
        {
            await _systemService.SaveChanges();
        }
    }
}
