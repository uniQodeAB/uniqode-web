namespace UniQode.Contracts.Repositories
{
    public interface ISecondaryRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
    }
}