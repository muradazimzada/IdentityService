using IdentityService.Domain.Contract.Services;
using IdentityService.Domain.Entities;


namespace IdentityService.Services
{
    public class DivisionService(IService divisionService, ILogger<DivisionService> logger) : IDivisionService
    {
        private readonly IService _divisionService = divisionService;
        private readonly ILogger<DivisionService> _logger = logger;

        public async Task<Division> CreateDivisionAsync(Division division)
        {
            if (division == null) throw new ArgumentNullException(nameof(division));

            await _divisionService.AddNew(division);
            _logger.LogInformation($"Division {division.Name} created successfully.");
            return division;
        }

        public async Task<Division> GetDivisionByIdAsync(Guid id)
        {
            var division = await _divisionService.GetById<Division>(id);
            if (division == null) throw new KeyNotFoundException("Division not found.");

            return division;
        }

        public async Task<IEnumerable<Division>> GetAllDivisionsAsync()
        {
            return await _divisionService.GetAll<Division>(null);
        }

        public async Task UpdateDivisionAsync(Division division)
        {
            if (division == null) throw new ArgumentNullException(nameof(division));

            await _divisionService.Update(division);
            _logger.LogInformation($"Division {division.Name} updated successfully.");
        }

        public async Task DeleteDivisionAsync(Guid id)
        {
            var division = await _divisionService.GetById<Division>(id);
            if (division == null) throw new KeyNotFoundException("Division not found.");

            await _divisionService.Remove(division);
            _logger.LogInformation($"Division {division.Name} deleted successfully.");
        }
    }
}
