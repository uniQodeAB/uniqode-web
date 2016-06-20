namespace UniQode.Data.Migrations.SecondaryModel
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsArticles : DbMigration
    {
        public override void Up()
        {
            SqlFile(@"Migrations\SecondaryModel\Sql\Up\201606141105416_NewsArticles.sql");
        }

        public override void Down()
        {
            SqlFile(@"Migrations\SecondaryModel\Sql\Down\201606141105416_NewsArticles.sql");
        }
    }
}
