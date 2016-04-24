namespace UniQode.Contracts.Repositories
{
    public interface IPrimaryRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
    }
}