namespace UniQode.Data.Migrations.Shared
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveQuitters : DbMigration
    {
        public override void Up()
        {
            Sql("delete from [primary].Employees where Email = 'anna.hall.rivera@uniqode.se'");
            Sql("delete from [secondary].Employees where Email = 'anna.hall.rivera@uniqode.se'");

            Sql("delete from [primary].Employees where Email = 'gustav.linderup@uniqode.se'");
            Sql("delete from [secondary].Employees where Email = 'gustav.linderup@uniqode.se'");
        }
        
        public override void Down()
        {
        }
    }
}
