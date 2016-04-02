namespace UniQode.Contracts
{
    public interface IPrimaryRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
    }
}