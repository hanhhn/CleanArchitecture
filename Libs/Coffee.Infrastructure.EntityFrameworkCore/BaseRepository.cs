using System.Linq.Expressions;
using Coffee.Infrastructure.EntityFrameworkCore.Interfaces;
using Coffee.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Infrastructure.EntityFrameworkCore
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IEntityRoot
    {
        public readonly DbContext DbContext;

        public BaseRepository(DbContext context)
        {
            DbContext = context;
        }

        protected DbSet<TEntity> DbSet
        {
            get
            {
                DbSet<TEntity> entity = DbContext.Set<TEntity>();
                if (entity == null)
                {
                    throw new NullReferenceException("Entity can not be set!");
                }

                return entity;
            }
        }

        public virtual IQueryable<TEntity> GetQuery()
        {
            return DbSet;
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Where(filter);
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            return orderBy(DbSet.Where(filter));
        }

        public virtual TEntity Get(params object[] keyValues)
        {
            return DbSet.Find(keyValues);
        }

        public virtual TEntity Add(TEntity entity)
        {
            return DbSet.Add(entity).Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            return DbSet.Update(entity).Entity;
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity is IDeleteEntity common)
            {
                common.Delete();
                DbSet.Update(entity);
            }
        }

        public virtual void UnDelete(TEntity entity)
        {
            if (entity is IDeleteEntity common)
            {
                common.UnDelete();
                DbSet.Update(entity);
            }
        }
    }
}

