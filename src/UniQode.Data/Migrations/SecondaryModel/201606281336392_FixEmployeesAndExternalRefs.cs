namespace UniQode.Data.Migrations.SecondaryModel
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixEmployeesAndExternalRefs : DbMigration
    {
        public override void Up()
        {
            CreateIndex("secondary.ExternalReferences", "Type");

            DropTable("secondary.ProfilePictures");
            CreateTable(
                "secondary.ProfilePictures",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    OriginalUrl = c.String(nullable: false, maxLength: 256),
                    SquareUrl = c.String(nullable: false, maxLength: 256)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("secondary.Employees", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);

        }

        public override void Down()
        {
            DropIndex("secondary.ExternalReferences", new[] { "Type" });

            DropTable("secondary.ProfilePictures");
            CreateTable(
                "secondary.ProfilePictures",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    OriginalUrl = c.String(nullable: false, maxLength: 256),
                    SquareUrl = c.String(nullable: false, maxLength: 256),
                    Employee_Id = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("secondary.Employees", t => t.Employee_Id, cascadeDelete: true)
                .ForeignKey("secondary.Employees", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Employee_Id);
        }
    }
}
