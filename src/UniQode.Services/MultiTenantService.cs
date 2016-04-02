using UniQode.Contracts;
using UniQode.Contracts.Services;
using UniQode.Entities.Data.Core;

namespace UniQode.Services
{
    public class MultiTenantService<TEntity, TIdentifier> : IMultiTenantService<TEntity, TIdentifier> where TEntity : class, IEntity<TIdentifier>, new()
    {
        public MultiTenantService(IPrimaryRepository<TEntity> primaryRepository, ISecondaryRepository<TEntity> secondaryRepository, ICacheProvider cacheProvider)
        {
            _primaryService = new CrudService<TEntity,TIdentifier>(primaryRepository, cacheProvider, "1");
            _secondaryService = new CrudService<TEntity, TIdentifier>(secondaryRepository, cacheProvider, "2");
        }

        private readonly ICrudService<TEntity, TIdentifier> _primaryService;
        public ICrudService<TEntity, TIdentifier> Primary => _primaryService;


        private readonly ICrudService<TEntity, TIdentifier> _secondaryService;
        public ICrudService<TEntity, TIdentifier> Secondary => _secondaryService;
    }
}