using System.Data.Entity;

namespace UniQode.Data.Models
{
    public class SharedModel : BaseDbContext
    {
        public SharedModel(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public SharedModel()
            : this("name=DbContext")
        {

        }
    }
}