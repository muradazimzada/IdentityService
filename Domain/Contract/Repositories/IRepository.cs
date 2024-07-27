using IdentityService.Domain.Entities;
using IdentityService.Repositories;
using System.Linq.Expressions;

namespace IdentityService.Domain.Contract.Repositories
{
    public interface IRepository
    {
        Task Add<T>(T entity) where T : BaseEntity;
        Task AddRange<T>(IEnumerable<T> entities) where T : BaseEntity;
        Task Delete<T>(T entity) where T : BaseEntity;
        Task DeleteRange<T>(IEnumerable<T> entities) where T : BaseEntity;
        Task<long> GetCount<T>(BaseSpecification<T> spec = null) where T : BaseEntity;
        Task<T> GetById<T>(Guid id) where T : BaseEntity;
        Task<T> GetById<T>(Guid id, List<Expression<Func<T, object>>> includes) where T : BaseEntity;
        Task<IEnumerable<T>> List<T>(BaseSpecification<T> spec) where T : BaseEntity;
        Task<IEnumerable<T>> List<T>(BaseSpecification<T> spec, List<Expression<Func<T, object>>> includes) where T : BaseEntity;
        Task Update<T>(T entity) where T : BaseEntity;
        Task UpdateRange<T>(IEnumerable<T> entities) where T : BaseEntity;
        Task SaveChanges();
    }
}
