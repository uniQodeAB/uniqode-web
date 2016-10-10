namespace UniQode.Data.Migrations.PrimaryModel
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewsArticleCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("primary.NewsArticles", "Category", c => c.String(nullable: false, maxLength: 32));
            CreateIndex("primary.NewsArticles", "Category");
        }
        
        public override void Down()
        {
            DropIndex("primary.NewsArticles", new[] { "Category" });
            DropColumn("primary.NewsArticles", "Category");
        }
    }
}
