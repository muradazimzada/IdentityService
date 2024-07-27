using IdentityService.Domain.Contract.Repositories;
using IdentityService.Domain.Contract.Services;
using IdentityService.Domain.Entities;
using IdentityService.Dtos.ResponseDtos;
using IdentityService.Repositories;
using IdentityService.Specifications;

namespace IdentityService.Services
{
    public class UserService( IService systemService) : IUserService
    {

        public async Task AddUser(User user)
        {
            await systemService.AddNew(user);
        }

        public async Task UpdateUser(User user)
        {
            await systemService.Update(user);
        }

        public async Task DeleteUser(User user)
        {
            await systemService.Remove(user);
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await systemService.GetById<User>(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await systemService.GetAll<User>(null); ;
        }

        public async Task<IEnumerable<User>> GetUsersBySpecification(BaseSpecification<User> spec)
        {
            return await systemService.GetAll(spec);
        }

        public async Task<User> GetUserBySpecification(BaseSpecification<User> spec)
        {
            var baseSpec = spec as BaseSpecification<User>;
            return (await systemService.GetAll(spec, baseSpec?.Includes)).FirstOrDefault();
        }
     

        public async Task SaveChanges()
        {
           await systemService.SaveChanges();
        }
    }

}
