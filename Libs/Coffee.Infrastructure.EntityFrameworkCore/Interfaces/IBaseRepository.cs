using Coffee.Infrastructure.Interfaces;

namespace Coffee.Infrastructure.EntityFrameworkCore.Interfaces
{
    public interface IBaseRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>, IQueryableRepository<TEntity>
        where TEntity : class, IEntityRoot
    {
    }
}

