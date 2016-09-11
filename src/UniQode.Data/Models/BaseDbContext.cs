using System;
using System.Data.Entity;

namespace UniQode.Data.Models
{
    [DbConfigurationType(typeof(AzureDbConfiguration))]
    public abstract class BaseDbContext : DbContext
    {
        protected BaseDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime?>().Configure(c => c.HasColumnType("datetime2"));
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }
    }
}