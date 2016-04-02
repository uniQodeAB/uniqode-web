using System.Data.Entity;
using UniQode.Entities.Data;

namespace UniQode.Data.Models
{
    public class AdminModel : BaseDbContext
    {
        public AdminModel(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer<AdminModel>(null);
        }
        public AdminModel()
            : this("name=DbContext")
        {

        }
        
        public virtual DbSet<Account> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("admin");

        }
    }
}