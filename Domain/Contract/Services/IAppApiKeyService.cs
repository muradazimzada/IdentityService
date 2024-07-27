using IdentityService.Domain.Entities;

namespace IdentityService.Domain.Contract.Services
{
    public interface IAppApiKeyService
    {
        Task<AppApiKey> CreateApiKeyAsync(AppApiKey appApiKey);
        Task<AppApiKey> GetApiKeyByIdAsync(Guid id);
        Task<IEnumerable<AppApiKey>> GetAllApiKeysAsync();
        Task UpdateApiKeyAsync(AppApiKey appApiKey);
        Task DeleteApiKeyAsync(Guid id);
    }
}
