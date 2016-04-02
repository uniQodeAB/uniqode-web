using UniQode.Entities.Data.Core;

namespace UniQode.Contracts.Services
{
    public interface IMultiTenantService<TEntity, in TIdentifier> where TEntity : class, IEntity<TIdentifier>, new()
    {
         ICrudService<TEntity, TIdentifier> Primary { get; }
         ICrudService<TEntity, TIdentifier> Secondary { get; }
    }
}