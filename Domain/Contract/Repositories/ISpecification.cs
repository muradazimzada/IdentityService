using System.Linq.Expressions;

namespace IdentityService.Domain.Contract.Repositories
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }

        public int Skip { get; set; }
        public int Take { get; set; }

    }
}
