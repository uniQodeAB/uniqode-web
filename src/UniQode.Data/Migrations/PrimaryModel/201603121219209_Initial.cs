namespace UniQode.Data.Migrations.PrimaryModel
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "primary.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Title = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        ShortDescription = c.String(nullable: false, maxLength: 256),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "primary.ExternalReferences",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        Url = c.String(nullable: false, maxLength: 256),
                        Employee_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("primary.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Employee_Id);
            
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
            
            CreateTable(
                "primary.Spotlights",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Answer = c.String(nullable: false),
                        Employee_Id = c.Guid(nullable: false),
                        SpotlightQuestion_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("primary.Employees", t => t.Employee_Id, cascadeDelete: true)
                .ForeignKey("primary.SpotlightQuestions", t => t.SpotlightQuestion_Id, cascadeDelete: true)
                .Index(t => t.Employee_Id)
                .Index(t => t.SpotlightQuestion_Id);
            
            CreateTable(
                "primary.SpotlightQuestions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Text = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "primary.Mottos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 32),
                        Description = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "primary.NewsArticles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        SearchableTitle = c.String(nullable: false, maxLength: 100),
                        Body = c.String(nullable: false),
                        Modified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SearchableTitle, unique: true);
            
            CreateTable(
                "primary.WorkFields",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 32),
                        Description = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("primary.Spotlights", "SpotlightQuestion_Id", "primary.SpotlightQuestions");
            DropForeignKey("primary.Spotlights", "Employee_Id", "primary.Employees");
            DropForeignKey("primary.ProfilePictures", "Id", "primary.Employees");
            DropForeignKey("primary.ProfilePictures", "Employee_Id", "primary.Employees");
            DropForeignKey("primary.ExternalReferences", "Employee_Id", "primary.Employees");
            DropIndex("primary.NewsArticles", new[] { "SearchableTitle" });
            DropIndex("primary.Spotlights", new[] { "SpotlightQuestion_Id" });
            DropIndex("primary.Spotlights", new[] { "Employee_Id" });
            DropIndex("primary.ProfilePictures", new[] { "Employee_Id" });
            DropIndex("primary.ProfilePictures", new[] { "Id" });
            DropIndex("primary.ExternalReferences", new[] { "Employee_Id" });
            DropIndex("primary.Employees", new[] { "Email" });
            DropTable("primary.WorkFields");
            DropTable("primary.NewsArticles");
            DropTable("primary.Mottos");
            DropTable("primary.SpotlightQuestions");
            DropTable("primary.Spotlights");
            DropTable("primary.ProfilePictures");
            DropTable("primary.ExternalReferences");
            DropTable("primary.Employees");
        }
    }
}
