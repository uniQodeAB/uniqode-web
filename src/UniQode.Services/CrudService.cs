using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using UniQode.Common;
using UniQode.Contracts;
using UniQode.Contracts.Providers;
using UniQode.Contracts.Repositories;
using UniQode.Contracts.Services;
using UniQode.Entities.Data.Core;

namespace UniQode.Services
{
    public class CrudService<TEntity, TIdentifier> : ICrudService<TEntity, TIdentifier>
        where TEntity : class, IEntity<TIdentifier>, new()
    {
        public CrudService(IRepository<TEntity> repository, ICacheProvider cacheProvider, string cachePrefix = "")
        {
            _cachePrefix = cachePrefix;
            _type = typeof (TEntity);
            _repository = repository;
            _cacheProvider = cacheProvider;
        }

        private readonly string _cachePrefix;
        private readonly Type _type;

        private readonly IRepository<TEntity> _repository;
        private volatile object _repoLock = new object();
        private IRepository<TEntity> Repository
        {
            get
            {
                //lock (_repoLock)
                {
                    return _repository;
                }
            }
        }

        private readonly ICacheProvider _cacheProvider;
        private volatile object _cacheLock = new object();
        private ICacheProvider CacheProvider
        {
            get
            {
                //lock (_cacheLock)
                {
                    return _cacheProvider;
                }
            }
        }

        public TEntity Get(TIdentifier id, bool invalidateCache = false)
        {
            return Get(o => o.Id.Equals(id), invalidateCache);
        }

        public TEntity Get(Func<TEntity, bool> predicate, bool invalidateCache = false)
        {
            var list = List(invalidateCache);
            return list.FirstOrDefault(predicate);
        }

        public ICollection<TEntity> List(bool invalidateCache = false)
        {
            var cacheKey = !string.IsNullOrEmpty(_cachePrefix) ? $"{_cachePrefix}_" : "";
            cacheKey += $"{_type.Name}_List";

            if (invalidateCache)
                CacheProvider.Invalidate(cacheKey);

            if (CacheProvider.IsSet(cacheKey))
                return CacheProvider.Get<ICollection<TEntity>>(cacheKey);

            var list = Repository.GetAll().ToList();

            if (list.Any())
                CacheProvider.Set(cacheKey, list);

            return list;
        }

        public TEntity Create(TEntity obj, IIdentity identity)
        {
            if (identity == null || !identity.IsAuthenticated)
                throw new ErrorCodeException(ErrorCode.AuthenticationFailed);

            try
            {
                Repository.Add(obj);
                Repository.Commit();

                return Get(obj.Id, true);
            }
            catch (Exception ex)
            {
                throw new ErrorCodeException(ErrorCode.CreateFailed, ex);
            }
        }

        public TEntity Update(TEntity obj, IIdentity identity)
        {
            if (identity == null || !identity.IsAuthenticated)
                throw new ErrorCodeException(ErrorCode.AuthenticationFailed);

            try
            {
                Repository.Update(obj);

                Repository.Commit();

                // clear cache
                return Get(obj.Id, true);
            }
            catch (ErrorCodeException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ErrorCodeException(ErrorCode.UpdateFailed, ex);
            }
        }

        public void Delete(TIdentifier id, IIdentity identity)
        {
            if (identity == null || !identity.IsAuthenticated)
                throw new ErrorCodeException(ErrorCode.AuthenticationFailed);

            try
            {
                var obj = Get(id);

                if (obj == null)
                    throw new ErrorCodeException(ErrorCode.DataNotFound);

                Repository.Delete(obj.Id);
                Repository.Commit();

                // clear cache
                Get(obj.Id, true);
            }
            catch (ErrorCodeException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ErrorCodeException(ErrorCode.DeleteFailed, ex);
            }
        }
    }
}