using UniQode.Contracts;
using UniQode.Data.Models;

namespace UniQode.Data.Repositories
{
    public class AdminRepository<TEntity> : Repository<TEntity>, IAdminRepository<TEntity> where TEntity : class, new()
    {
        public AdminRepository(AdminModel dbContext) : base(dbContext)
        {

        }
    }
}