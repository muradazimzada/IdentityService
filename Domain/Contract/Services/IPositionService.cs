using IdentityService.Domain.Entities;

namespace IdentityService.Domain.Contract.Services
{
    public interface IPositionService
    {
        Task<Position> CreatePositionAsync(Position position);
        Task<Position> GetPositionByIdAsync(Guid id);
        Task<IEnumerable<Position>> GetAllPositionsAsync();
        Task UpdatePositionAsync(Position position);
        Task DeletePositionAsync(Guid id);
    }
}
