namespace UniQode.Data.Migrations.SecondaryModel
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProperNewsArticles : DbMigration
    {
        public override void Up()
        {
            SqlFile(@"Migrations\SecondaryModel\Sql\Up\201610100935470_ProperNewsArticles.sql");
        }
        
        public override void Down()
        {
            SqlFile(@"Migrations\SecondaryModel\Sql\Down\201610100935470_ProperNewsArticles.sql");
        }
    }
}
