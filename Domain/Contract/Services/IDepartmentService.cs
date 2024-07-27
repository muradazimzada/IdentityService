using IdentityService.Domain.Entities;

namespace IdentityService.Domain.Contract.Services
{
    public interface IDepartmentService
    {
        Task<Department> CreateDepartmentAsync(Department department);
        Task<Department> GetDepartmentByIdAsync(Guid id);
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(Guid id);
    }
}
