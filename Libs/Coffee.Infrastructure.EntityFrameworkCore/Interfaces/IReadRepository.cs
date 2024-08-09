using System.Linq.Expressions;
using Coffee.Infrastructure.Interfaces;

namespace Coffee.Infrastructure.EntityFrameworkCore.Interfaces
{
    public interface IReadRepository<TEntity> where TEntity : IEntityRoot
    {
        TEntity Get(params object[] keyValues);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
    }
}

