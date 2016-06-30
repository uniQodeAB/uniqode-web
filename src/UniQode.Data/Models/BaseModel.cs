using System.Data.Entity;
using UniQode.Entities.Data;

namespace UniQode.Data.Models
{
    public abstract class BaseModel<TClass> : BaseDbContext where TClass : BaseDbContext
    {
        private readonly string _schema;
        protected BaseModel(string nameOrConnectionString, string schema)
            : base(nameOrConnectionString)
        {
            _schema = schema;
            Database.SetInitializer<TClass>(null);
        }

        public virtual DbSet<Motto> Mottos { get; set; }
        public virtual DbSet<WorkField> WorkFields { get; set; }
        public virtual DbSet<NewsArticle> NewsArticles { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if(!string.IsNullOrEmpty(_schema))
                modelBuilder.HasDefaultSchema(_schema);

            modelBuilder.Entity<Employee>()
                .HasRequired(a => a.ProfilePicture)
                .WithRequiredPrincipal();
        }
    }
}