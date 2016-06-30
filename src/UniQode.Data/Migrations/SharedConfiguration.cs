namespace UniQode.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class SharedConfiguration : DbMigrationsConfiguration<Models.SharedModel>
    {
        public SharedConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Shared";
            ContextKey = "Shared";
            MigrationsNamespace = "UniQode.Data.Migrations.Shared";
        }

        protected override void Seed(Models.SharedModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
