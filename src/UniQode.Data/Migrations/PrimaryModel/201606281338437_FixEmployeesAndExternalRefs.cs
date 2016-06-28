namespace UniQode.Data.Migrations.PrimaryModel
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixEmployeesAndExternalRefs : DbMigration
    {
        public override void Up()
        {
            CreateIndex("primary.ExternalReferences", "Type");
            
            DropTable("primary.ProfilePictures");
            CreateTable(
                "primary.ProfilePictures",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    OriginalUrl = c.String(nullable: false, maxLength: 256),
                    SquareUrl = c.String(nullable: false, maxLength: 256)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("primary.Employees", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);

        }
        
        public override void Down()
        {
            DropIndex("primary.ExternalReferences", new[] { "Type" });
            
            DropTable("primary.ProfilePictures");
            CreateTable(
                "primary.ProfilePictures",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    OriginalUrl = c.String(nullable: false, maxLength: 256),
                    SquareUrl = c.String(nullable: false, maxLength: 256),
                    Employee_Id = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("primary.Employees", t => t.Employee_Id, cascadeDelete: true)
                .ForeignKey("primary.Employees", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Employee_Id);
        }
    }
}
