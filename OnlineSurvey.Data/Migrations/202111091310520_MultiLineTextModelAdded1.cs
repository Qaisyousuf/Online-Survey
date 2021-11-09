namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultiLineTextModelAdded1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MultiLineTexts", "MultilineTextAnswerId", c => c.Int(nullable: false));
            CreateIndex("dbo.MultiLineTexts", "MultilineTextAnswerId");
            AddForeignKey("dbo.MultiLineTexts", "MultilineTextAnswerId", "dbo.MultiLineTextAnswers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MultiLineTexts", "MultilineTextAnswerId", "dbo.MultiLineTextAnswers");
            DropIndex("dbo.MultiLineTexts", new[] { "MultilineTextAnswerId" });
            DropColumn("dbo.MultiLineTexts", "MultilineTextAnswerId");
        }
    }
}
