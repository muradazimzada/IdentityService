using IdentityService.Domain.Contract.Repositories;
using IdentityService.Domain.Contract.Services;
using IdentityService.Domain.Entities;
using IdentityService.Repositories;
using System.Linq.Expressions;

namespace IdentityService.Services
{
    public class SystemService(IRepository repository) : IService
    {
        private readonly IRepository _repository = repository;

        public async Task AddNew<T>(T item) where T : BaseEntity
        {
            await _repository.Add(item);
        }

        public async Task AddNewRange<T>(IEnumerable<T> list) where T : BaseEntity
        {
            await _repository.AddRange(list);
        }

        public async Task<IEnumerable<T>> GetAll<T>(BaseSpecification<T>? spec = null) where T : BaseEntity
        {
            return await _repository.List(spec);
        }

        public async Task<long> GetCount<T>(BaseSpecification<T> spec = null) where T : BaseEntity
        {
            return await _repository.GetCount(spec);
        }

        public async Task<IEnumerable<T>> GetAll<T>(BaseSpecification<T>? spec = null, List<Expression<Func<T, object>>>? includes = null) where T : BaseEntity
        {
            return await _repository.List(spec, includes);
        }

        public async Task<T> GetById<T>(Guid id) where T : BaseEntity
        {
            return await _repository.GetById<T>(id);
        }

        public async Task<T> GetById<T>(Guid id, List<Expression<Func<T, object>>>? includes) where T : BaseEntity
        {
            return await _repository.GetById<T>(id, includes);
        }

        public async Task Remove<T>(T item) where T : BaseEntity
        {
            await _repository.Delete(item);
        }

        public async Task RemoveRange<T>(IEnumerable<T> list) where T : BaseEntity
        {
            await _repository.DeleteRange(list);
        }

        public async Task Update<T>(T item) where T : BaseEntity
        {
            await _repository.Update(item);
        }

        public async Task UpdateRange<T>(IEnumerable<T> list) where T : BaseEntity
        {
            await _repository.UpdateRange(list);
        }

        public async Task SaveChanges()
        {
            await _repository.SaveChanges();
        }
    }
}
