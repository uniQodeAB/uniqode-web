namespace UniQode.Data.Migrations.Shared
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEmployeeInformation : DbMigration
    {
        public override void Up()
        {
            SqlFile(@"Migrations\Shared\Sql\Up\insert_new_employees.sql");
        }
        
        public override void Down()
        {
        }
    }
}
