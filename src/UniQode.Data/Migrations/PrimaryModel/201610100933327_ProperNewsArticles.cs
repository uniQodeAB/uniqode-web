namespace UniQode.Data.Migrations.PrimaryModel
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProperNewsArticles : DbMigration
    {
        public override void Up()
        {
            SqlFile(@"Migrations\PrimaryModel\Sql\Up\201610100933327_ProperNewsArticles.sql");
        }
        
        public override void Down()
        {
            SqlFile(@"Migrations\PrimaryModel\Sql\Down\201610100933327_ProperNewsArticles.sql");
        }
    }
}
