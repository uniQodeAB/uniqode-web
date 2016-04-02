using UniQode.Contracts;
using UniQode.Data.Models;

namespace UniQode.Data.Repositories
{
    public class SecondaryRepository<TEntity> : Repository<TEntity>, ISecondaryRepository<TEntity> where TEntity : class, new()
    {
        public SecondaryRepository(SecondaryModel dbContext) : base(dbContext)
        {

        }
    }
}