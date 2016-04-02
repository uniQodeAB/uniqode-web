namespace UniQode.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class SecondaryConfiguration : DbMigrationsConfiguration<Models.SecondaryModel>
    {
        public SecondaryConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\SecondaryModel";
            ContextKey = "SecondaryModel";
            MigrationsNamespace = "UniQode.Data.Migrations.SecondaryModel";
        }

        protected override void Seed(Models.SecondaryModel context)
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
