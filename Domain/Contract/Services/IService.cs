using IdentityService.Domain.Contract.Repositories;
using IdentityService.Domain.Entities;
using IdentityService.Repositories;
using System.Linq.Expressions;

namespace IdentityService.Domain.Contract.Services
{
    public interface IService
    {
        Task AddNew<T>(T item) where T : BaseEntity;
        Task AddNewRange<T>(IEnumerable<T> list) where T : BaseEntity;
        Task<IEnumerable<T>> GetAll<T>(BaseSpecification<T>? spec = null) where T : BaseEntity;
        Task<long> GetCount<T>(BaseSpecification<T> spec = null) where T : BaseEntity;
        Task<IEnumerable<T>> GetAll<T>(BaseSpecification<T>? spec = null, List<Expression<Func<T, object>>>? includes = null) where T : BaseEntity;
        Task<T> GetById<T>(Guid id) where T : BaseEntity;
        Task<T> GetById<T>(Guid id, List<Expression<Func<T, object>>>? includes) where T : BaseEntity;
        Task Remove<T>(T item) where T : BaseEntity;
        Task RemoveRange<T>(IEnumerable<T> list) where T : BaseEntity;
        Task Update<T>(T item) where T : BaseEntity;
        Task UpdateRange<T>(IEnumerable<T> list) where T : BaseEntity;
        Task SaveChanges();
    }
}
