namespace UniQode.Data.Migrations.Shared
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEployeeInformation2 : DbMigration
    {
        public override void Up()
        {
            SqlFile(@"Migrations\Shared\Sql\Up\insert_new_employees2.sql");
        }
        
        public override void Down()
        {
        }
    }
}
