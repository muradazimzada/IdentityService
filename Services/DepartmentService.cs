using IdentityService.Domain.Contract.Services;
using IdentityService.Domain.Entities;

namespace IdentityService.Services
{
    public class DepartmentService(IService systemService, ILogger<DepartmentService> logger) : IDepartmentService
    {
        private readonly IService _systemService = systemService;
        private readonly ILogger<DepartmentService> _logger = logger;

        public async Task<Department> CreateDepartmentAsync(Department department)
        {
            if (department == null) throw new ArgumentNullException(nameof(department));

            await _systemService.AddNew(department);
            _logger.LogInformation($"Department {department.Name} created successfully.");
            return department;
        }

        public async Task<Department> GetDepartmentByIdAsync(Guid id)
        {
            var department = await _systemService.GetById<Department>(id);
            if (department == null) throw new KeyNotFoundException("Department not found.");

            return department;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _systemService.GetAll<Department>(null);
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            ArgumentNullException.ThrowIfNull(department);

            await _systemService.Update(department);
            _logger.LogInformation($"Department {department.Name} updated successfully.");
        }

        public async Task DeleteDepartmentAsync(Guid id)
        {
            var department = await _systemService.GetById<Department>(id);

            if (department == null) throw new KeyNotFoundException("Department not found.");

            await _systemService.Remove(department);
            _logger.LogInformation($"Department {department.Name} deleted successfully.");
        }
    }
}
