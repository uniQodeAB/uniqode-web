namespace UniQode.Data.Migrations.PrimaryModel
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsArticles : DbMigration
    {
        public override void Up()
        {
            SqlFile(@"Migrations\PrimaryModel\Sql\Up\201606141106072_NewsArticles.sql");
        }
        
        public override void Down()
        {
            SqlFile(@"Migrations\PrimaryModel\Sql\Down\201606141106072_NewsArticles.sql");
        }
    }
}
