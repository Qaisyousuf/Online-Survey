namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SurveyAndSingleChoiceQuestionAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SurveyAndSingleChoice",
                c => new
                    {
                        SurveyId = c.Int(nullable: false),
                        SingleChoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SurveyId, t.SingleChoiceId })
                .ForeignKey("dbo.Surveys", t => t.SurveyId, cascadeDelete: true)
                .ForeignKey("dbo.YesNoQuestions", t => t.SingleChoiceId, cascadeDelete: true)
                .Index(t => t.SurveyId)
                .Index(t => t.SingleChoiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurveyAndSingleChoice", "SingleChoiceId", "dbo.YesNoQuestions");
            DropForeignKey("dbo.SurveyAndSingleChoice", "SurveyId", "dbo.Surveys");
            DropIndex("dbo.SurveyAndSingleChoice", new[] { "SingleChoiceId" });
            DropIndex("dbo.SurveyAndSingleChoice", new[] { "SurveyId" });
            DropTable("dbo.SurveyAndSingleChoice");
        }
    }
}
