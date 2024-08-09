using System;
using Coffee.Infrastructure.Interfaces;

namespace Coffee.Infrastructure.EntityFrameworkCore.Interfaces
{
    public interface IWriteRepository<TEntity> where TEntity : class, IEntityRoot
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        void Delete(TEntity entity);
        void UnDelete(TEntity entity);
    }
}

