using IdentityService.Domain.Contract.Services;
using IdentityService.Domain.Entities;

namespace IdentityService.Services
{
    public class PositionService(IService service, ILogger<PositionService> logger) : IPositionService
    {
        private readonly IService _service = service;
        private readonly ILogger<PositionService> _logger = logger;

        public async Task<Position> CreatePositionAsync(Position position)
        {
            if (position == null) throw new ArgumentNullException(nameof(position));

            await _service.AddNew<Position>(position);
            _logger.LogInformation($"Position {position.Name} created successfully.");
            return position;
        }

        public async Task<Position> GetPositionByIdAsync(Guid id)
        {
            var position = await _service.GetById<Position>(id);
            if (position == null) throw new KeyNotFoundException("Position not found.");

            return position;
        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync()
        {
            return await _service.GetAll<Position>(null);
        }

        public async Task UpdatePositionAsync(Position position)
        {
            if (position == null) throw new ArgumentNullException(nameof(position));

            await _service.Update<Position>(position);
            _logger.LogInformation($"Position {position.Name} updated successfully.");
        }

        public async Task DeletePositionAsync(Guid id)
        {
            var position = await _service.GetById<Position>(id);
            if (position == null) throw new KeyNotFoundException("Position not found.");

            await _service.Remove<Position>(position);
            _logger.LogInformation($"Position {position.Name} deleted successfully.");
        }
    }
}
