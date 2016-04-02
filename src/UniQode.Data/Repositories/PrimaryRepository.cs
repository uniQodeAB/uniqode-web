using UniQode.Contracts;
using UniQode.Data.Models;

namespace UniQode.Data.Repositories
{
    public class PrimaryRepository<TEntity> : Repository<TEntity>, IPrimaryRepository<TEntity> where TEntity : class, new()
    {
        public PrimaryRepository(PrimaryModel dbContext) : base(dbContext)
        {

        }
    }
}