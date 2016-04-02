using System;

namespace UniQode.Entities.Data.Core
{
    public abstract class UniqueEntity : Entity<Guid>
    {
        protected UniqueEntity()
            : base(Guid.NewGuid())
        {

        }
    }
}