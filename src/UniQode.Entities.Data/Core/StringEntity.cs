namespace UniQode.Entities.Data.Core
{
    public abstract class StringEntity : Entity<string>
    {
        protected StringEntity()
        { }

        protected StringEntity(string id)
            : base(id)
        { }
    }
}