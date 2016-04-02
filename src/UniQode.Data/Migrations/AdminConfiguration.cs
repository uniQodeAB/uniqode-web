namespace UniQode.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class AdminConfiguration : DbMigrationsConfiguration<Models.AdminModel>
    {
        public AdminConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\AdminModel";
            ContextKey = "AdminModel";
            MigrationsNamespace = "UniQode.Data.Migrations.AdminModel";
        }

        protected override void Seed(Models.AdminModel context)
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
