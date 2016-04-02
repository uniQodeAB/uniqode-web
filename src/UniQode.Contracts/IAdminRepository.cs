namespace UniQode.Contracts
{
    public interface IAdminRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
    }
}