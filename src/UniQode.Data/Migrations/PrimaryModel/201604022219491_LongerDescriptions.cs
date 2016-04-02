namespace UniQode.Data.Migrations.PrimaryModel
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LongerDescriptions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("primary.SpotlightQuestions", "Text", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("primary.Mottos", "Description", c => c.String(nullable: false, maxLength: 1024));
            AlterColumn("primary.WorkFields", "Description", c => c.String(nullable: false, maxLength: 1024));
        }
        
        public override void Down()
        {
            AlterColumn("primary.WorkFields", "Description", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("primary.Mottos", "Description", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("primary.SpotlightQuestions", "Text", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
