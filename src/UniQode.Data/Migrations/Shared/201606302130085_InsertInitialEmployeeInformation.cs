namespace UniQode.Data.Migrations.Shared
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertInitialEmployeeInformation : DbMigration
    {
        public override void Up()
        {
            SqlFile(@"Migrations\Shared\Sql\Up\insert_spotlightquestions.sql");
            SqlFile(@"Migrations\Shared\Sql\Up\insert_employees.sql");
        }
        
        public override void Down()
        {
        }
    }
}
