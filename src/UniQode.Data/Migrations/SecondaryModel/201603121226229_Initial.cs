namespace UniQode.Data.Migrations.SecondaryModel
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "secondary.Employees",
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
                "secondary.ExternalReferences",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        Url = c.String(nullable: false, maxLength: 256),
                        Employee_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("secondary.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Employee_Id);
            
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
            
            CreateTable(
                "secondary.Spotlights",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Answer = c.String(nullable: false),
                        Employee_Id = c.Guid(nullable: false),
                        SpotlightQuestion_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("secondary.Employees", t => t.Employee_Id, cascadeDelete: true)
                .ForeignKey("secondary.SpotlightQuestions", t => t.SpotlightQuestion_Id, cascadeDelete: true)
                .Index(t => t.Employee_Id)
                .Index(t => t.SpotlightQuestion_Id);
            
            CreateTable(
                "secondary.SpotlightQuestions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Text = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "secondary.Mottos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 32),
                        Description = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "secondary.NewsArticles",
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
                "secondary.WorkFields",
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
            DropForeignKey("secondary.Spotlights", "SpotlightQuestion_Id", "secondary.SpotlightQuestions");
            DropForeignKey("secondary.Spotlights", "Employee_Id", "secondary.Employees");
            DropForeignKey("secondary.ProfilePictures", "Id", "secondary.Employees");
            DropForeignKey("secondary.ProfilePictures", "Employee_Id", "secondary.Employees");
            DropForeignKey("secondary.ExternalReferences", "Employee_Id", "secondary.Employees");
            DropIndex("secondary.NewsArticles", new[] { "SearchableTitle" });
            DropIndex("secondary.Spotlights", new[] { "SpotlightQuestion_Id" });
            DropIndex("secondary.Spotlights", new[] { "Employee_Id" });
            DropIndex("secondary.ProfilePictures", new[] { "Employee_Id" });
            DropIndex("secondary.ProfilePictures", new[] { "Id" });
            DropIndex("secondary.ExternalReferences", new[] { "Employee_Id" });
            DropIndex("secondary.Employees", new[] { "Email" });
            DropTable("secondary.WorkFields");
            DropTable("secondary.NewsArticles");
            DropTable("secondary.Mottos");
            DropTable("secondary.SpotlightQuestions");
            DropTable("secondary.Spotlights");
            DropTable("secondary.ProfilePictures");
            DropTable("secondary.ExternalReferences");
            DropTable("secondary.Employees");
        }
    }
}
