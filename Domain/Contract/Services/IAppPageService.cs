using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.Domain.Contract.Services
{
    public interface IAppPageService
    {
        Task<AppPage> CreateAppPageAsync(AppPage appPage);
        Task<AppPage> GetAppPageByIdAsync(Guid id);
        Task<IEnumerable<AppPage>> GetAllAppPagesAsync();
        Task UpdateAppPageAsync(AppPage appPage);
        Task DeleteAppPageAsync(Guid id);
    }
}
