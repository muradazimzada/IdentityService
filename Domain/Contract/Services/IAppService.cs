using IdentityService.Domain.Entities;
using IdentityService.Repositories;
namespace IdentityService.Domain.Contract.Services
{
    public interface IAppService
    {
        Task AddApp(App app);
        Task UpdateApp(App app);
        Task DeleteApp(App app);
        Task<App> GetAppById(Guid id);
        Task<IEnumerable<App>> GetAllApps();
        Task<IEnumerable<App>> GetAppsBySpecification(BaseSpecification<App> spec);
        Task<App> GetAppBySpecification(BaseSpecification<App> spec);
        Task SaveChanges();
    }
} 

