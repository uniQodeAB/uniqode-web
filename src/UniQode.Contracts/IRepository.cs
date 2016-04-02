using System;
using System.Linq;
using System.Linq.Expressions;

namespace UniQode.Contracts
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> where);

        TEntity Find(Expression<Func<TEntity, bool>> where);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(object id);

        void Commit(bool dispose = false);
    }
}