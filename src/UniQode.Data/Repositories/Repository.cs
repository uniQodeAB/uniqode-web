using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using UniQode.Contracts;
using UniQode.Contracts.Repositories;

namespace UniQode.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class, new()
    {
        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        ~Repository()
        {
            Dispose();
        }
        
        public DbContext DbContext { get; set; }

        private DbSet<TEntity> DbSet { get; }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where(where);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            return GetAll(where).FirstOrDefault();
        }

        public virtual void Add(TEntity entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.AddOrUpdate(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entity = DbSet.Find(id);
            Delete(entity);
        }

        public virtual void Commit(bool dispose = false)
        {
            DbContext.SaveChanges();
            if (dispose)
                Dispose();
        }
        
        public void Dispose()
        {
            DbContext?.Dispose();
        }
    }
}