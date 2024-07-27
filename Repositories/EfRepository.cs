using IdentityService.Domain.Context;
using IdentityService.Domain.Contract.Repositories;
using IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IdentityService.Repositories
{
    public class EfRepository(IdentityServiceDbContext dbContext) : IRepository
    {
        public async Task Add<T>(T entity) where T : BaseEntity
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddRange<T>(IEnumerable<T> entities) where T : BaseEntity
        {
            await dbContext.Set<T>().AddRangeAsync(entities);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete<T>(T entity) where T : BaseEntity
        {
            entity.RecordStatus = Domain.Enums.RecordStatus.InActive; 
            dbContext.Set<T>().Update(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteRange<T>(IEnumerable<T> entities) where T : BaseEntity
        {
            foreach (var entity in entities)
            {
                entity.RecordStatus = Domain.Enums.RecordStatus.InActive;
            }

            dbContext.Set<T>().UpdateRange(entities);

            await dbContext.SaveChangesAsync();
        }

        public async Task<long> GetCount<T>(BaseSpecification<T> spec = null) where T : BaseEntity
        {
            var query = ApplySpecification(spec);
            return await query.LongCountAsync();
        }

        public async Task<T> GetById<T>(Guid id) where T : BaseEntity
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetById<T>(Guid id, List<Expression<Func<T, object>>> includes) where T : BaseEntity
        {
            IQueryable<T> query = dbContext.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<T>> List<T>(BaseSpecification<T> spec) where T : BaseEntity
        {
            var query = ApplySpecification(spec);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> List<T>(BaseSpecification<T> spec, List<Expression<Func<T, object>>> includes) where T : BaseEntity
        {
            IQueryable<T> query = ApplySpecification(spec);
            //foreach (var include in includes)
            //{
            //    query = query.Include(include);
            //}

            return await query.ToListAsync();
        }

        public async Task Update<T>(T entity) where T : BaseEntity
        {
            dbContext.Set<T>().Update(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateRange<T>(IEnumerable<T> entities) where T : BaseEntity
        {
            dbContext.Set<T>().UpdateRange(entities);
            await dbContext.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification<T>(BaseSpecification<T> spec) where T : BaseEntity
        {
            IQueryable<T> query = dbContext.Set<T>();

            if (spec != null)
            {
                if (spec.Criteria != null)
                {
                    query = query.Where(spec.Criteria);
                }

                if (spec is BaseSpecification<T> baseSpec)
                {
                    foreach (var include in baseSpec.Includes)
                    {
                        query = query.Include(include);
                    }

                    foreach (var include in baseSpec.IncludeStrings)
                    {
                        query = query.Include(include.ToString());
                    }
                }
            }

            return query;
        }
        public async Task SaveChanges()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
