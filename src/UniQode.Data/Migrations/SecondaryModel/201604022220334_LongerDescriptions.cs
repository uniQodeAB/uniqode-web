namespace UniQode.Data.Migrations.SecondaryModel
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LongerDescriptions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("secondary.SpotlightQuestions", "Text", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("secondary.Mottos", "Description", c => c.String(nullable: false, maxLength: 1024));
            AlterColumn("secondary.WorkFields", "Description", c => c.String(nullable: false, maxLength: 1024));
        }
        
        public override void Down()
        {
            AlterColumn("secondary.WorkFields", "Description", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("secondary.Mottos", "Description", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("secondary.SpotlightQuestions", "Text", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
