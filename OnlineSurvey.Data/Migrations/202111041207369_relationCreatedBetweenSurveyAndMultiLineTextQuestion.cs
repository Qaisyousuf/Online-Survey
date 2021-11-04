namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationCreatedBetweenSurveyAndMultiLineTextQuestion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SurveyMultiLineTextQuestion",
                c => new
                    {
                        SurveyId = c.Int(nullable: false),
                        MultiLineTextQuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SurveyId, t.MultiLineTextQuestionId })
                .ForeignKey("dbo.Surveys", t => t.SurveyId, cascadeDelete: true)
                .ForeignKey("dbo.MultiLineTexts", t => t.MultiLineTextQuestionId, cascadeDelete: true)
                .Index(t => t.SurveyId)
                .Index(t => t.MultiLineTextQuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurveyMultiLineTextQuestion", "MultiLineTextQuestionId", "dbo.MultiLineTexts");
            DropForeignKey("dbo.SurveyMultiLineTextQuestion", "SurveyId", "dbo.Surveys");
            DropIndex("dbo.SurveyMultiLineTextQuestion", new[] { "MultiLineTextQuestionId" });
            DropIndex("dbo.SurveyMultiLineTextQuestion", new[] { "SurveyId" });
            DropTable("dbo.SurveyMultiLineTextQuestion");
        }
    }
}
