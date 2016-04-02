namespace UniQode.Contracts
{
    public interface ISecondaryRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
    }
}