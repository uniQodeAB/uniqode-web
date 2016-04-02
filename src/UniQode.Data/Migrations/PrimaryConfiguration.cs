namespace UniQode.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class PrimaryConfiguration : DbMigrationsConfiguration<Models.PrimaryModel>
    {
        public PrimaryConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\PrimaryModel";
            ContextKey = "PrimaryModel";
            MigrationsNamespace = "UniQode.Data.Migrations.PrimaryModel";
        }

        protected override void Seed(Models.PrimaryModel context)
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
