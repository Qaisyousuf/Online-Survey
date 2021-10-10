namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SurveyAndMultiplechoiceRelationCreated : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.QuestionMultipleChoiceQuestions", newName: "MutipleChoiceQuesionAndAnswer");
            RenameColumn(table: "dbo.MutipleChoiceQuesionAndAnswer", name: "Question_Id", newName: "MultipleChoiceQuestionId");
            RenameColumn(table: "dbo.MutipleChoiceQuesionAndAnswer", name: "MultipleChoiceQuestions_Id", newName: "QuestionId");
            RenameIndex(table: "dbo.MutipleChoiceQuesionAndAnswer", name: "IX_Question_Id", newName: "IX_MultipleChoiceQuestionId");
            RenameIndex(table: "dbo.MutipleChoiceQuesionAndAnswer", name: "IX_MultipleChoiceQuestions_Id", newName: "IX_QuestionId");
            CreateTable(
                "dbo.SurveyMultipleChoiceQuestion",
                c => new
                    {
                        MultiChoiceQusetionForSurvey = c.Int(nullable: false),
                        SurveyForMultipleChoiceQustionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MultiChoiceQusetionForSurvey, t.SurveyForMultipleChoiceQustionId })
                .ForeignKey("dbo.Surveys", t => t.MultiChoiceQusetionForSurvey, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.SurveyForMultipleChoiceQustionId, cascadeDelete: true)
                .Index(t => t.MultiChoiceQusetionForSurvey)
                .Index(t => t.SurveyForMultipleChoiceQustionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurveyMultipleChoiceQuestion", "SurveyForMultipleChoiceQustionId", "dbo.Questions");
            DropForeignKey("dbo.SurveyMultipleChoiceQuestion", "MultiChoiceQusetionForSurvey", "dbo.Surveys");
            DropIndex("dbo.SurveyMultipleChoiceQuestion", new[] { "SurveyForMultipleChoiceQustionId" });
            DropIndex("dbo.SurveyMultipleChoiceQuestion", new[] { "MultiChoiceQusetionForSurvey" });
            DropTable("dbo.SurveyMultipleChoiceQuestion");
            RenameIndex(table: "dbo.MutipleChoiceQuesionAndAnswer", name: "IX_QuestionId", newName: "IX_MultipleChoiceQuestions_Id");
            RenameIndex(table: "dbo.MutipleChoiceQuesionAndAnswer", name: "IX_MultipleChoiceQuestionId", newName: "IX_Question_Id");
            RenameColumn(table: "dbo.MutipleChoiceQuesionAndAnswer", name: "QuestionId", newName: "MultipleChoiceQuestions_Id");
            RenameColumn(table: "dbo.MutipleChoiceQuesionAndAnswer", name: "MultipleChoiceQuestionId", newName: "Question_Id");
            RenameTable(name: "dbo.MutipleChoiceQuesionAndAnswer", newName: "QuestionMultipleChoiceQuestions");
        }
    }
}
