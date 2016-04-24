namespace UniQode.Contracts.Repositories
{
    public interface IAdminRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
    }
}