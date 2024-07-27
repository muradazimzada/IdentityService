using IdentityService.Domain.Entities;
namespace IdentityService.Domain.Contract.Services
{
    public interface IUserPositionService
    {
        Task<UserPosition> CreateUserPositionAsync(UserPosition userPosition);
        Task<UserPosition> GetUserPositionByIdAsync(Guid id);
        Task<IEnumerable<UserPosition>> GetAllUserPositionsAsync();
        Task UpdateUserPositionAsync(UserPosition userPosition);
        Task DeleteUserPositionAsync(Guid id);
    }
}
