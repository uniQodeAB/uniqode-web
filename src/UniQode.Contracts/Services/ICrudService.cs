using System;
using System.Collections.Generic;
using System.Security.Principal;
using UniQode.Entities.Data.Core;

namespace UniQode.Contracts.Services
{
    public interface ICrudService<TEntity, in TIdentifier>
        where TEntity : class, IEntity<TIdentifier>, new()
    {
        TEntity Get(TIdentifier id, bool invalidateCache = false);
        TEntity Get(Func<TEntity, bool> predicate, bool invalidateCache = false);
        ICollection<TEntity> List(bool invalidateCache = false);
        TEntity Create(TEntity obj, IIdentity identity);
        TEntity Update(TEntity obj, IIdentity identity);
        void Delete(TIdentifier id, IIdentity identity);
    }
}