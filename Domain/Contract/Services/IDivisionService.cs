using IdentityService.Domain.Entities;
namespace IdentityService.Domain.Contract.Services
{
    public interface IDivisionService
    {
        Task<Division> CreateDivisionAsync(Division division);
        Task<Division> GetDivisionByIdAsync(Guid id);
        Task<IEnumerable<Division>> GetAllDivisionsAsync();
        Task UpdateDivisionAsync(Division division);
        Task DeleteDivisionAsync(Guid id);
    }
}
