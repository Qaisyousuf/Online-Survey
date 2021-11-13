namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultiLineAnswerRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MultiLineTexts", "MultilineTextAnswerId", "dbo.MultiLineTextAnswers");
            DropIndex("dbo.MultiLineTexts", new[] { "MultilineTextAnswerId" });
            DropColumn("dbo.MultiLineTexts", "MultilineTextAnswerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MultiLineTexts", "MultilineTextAnswerId", c => c.Int(nullable: false));
            CreateIndex("dbo.MultiLineTexts", "MultilineTextAnswerId");
            AddForeignKey("dbo.MultiLineTexts", "MultilineTextAnswerId", "dbo.MultiLineTextAnswers", "Id", cascadeDelete: true);
        }
    }
}
