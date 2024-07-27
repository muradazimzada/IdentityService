using IdentityService.Domain.Contract.Repositories;
using IdentityService.Domain.Entities;
using IdentityService.Dtos.ResponseDtos;
using IdentityService.Repositories;

namespace IdentityService.Domain.Contract.Services
{
    public interface IUserService
    {
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
        Task<User> GetUserById(Guid id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetUsersBySpecification(BaseSpecification<User> spec);
        Task<User> GetUserBySpecification(BaseSpecification<User> spec);
        //Task<AuthenticationResponseDto> GenerateTokens(User user);

        Task SaveChanges ();



    }
}
