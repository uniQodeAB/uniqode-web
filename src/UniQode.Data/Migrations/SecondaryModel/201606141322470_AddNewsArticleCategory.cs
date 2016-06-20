namespace UniQode.Data.Migrations.SecondaryModel
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewsArticleCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("secondary.NewsArticles", "Category", c => c.String(nullable: false, maxLength: 32));
            CreateIndex("secondary.NewsArticles", "Category");

            Sql("UPDATE [secondary].[NewsArticles] SET Category = 'NEW HIRE'"); // all in there at this point are new hires
        }
        
        public override void Down()
        {
            DropIndex("secondary.NewsArticles", new[] { "Category" });
            DropColumn("secondary.NewsArticles", "Category");
        }
    }
}
