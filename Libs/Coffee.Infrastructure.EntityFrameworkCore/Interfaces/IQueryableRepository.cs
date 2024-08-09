using System;
using Coffee.Infrastructure.Interfaces;

namespace Coffee.Infrastructure.EntityFrameworkCore.Interfaces
{
    public interface IQueryableRepository<TEntity> where TEntity : IEntityRoot
    {
        IQueryable<TEntity> GetQuery();
    }
}

