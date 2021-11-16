namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkBoxQuestionsAndSurveyModelCreated : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SurveyAndSingleChoice", newName: "SurveyAndCheckBoxQuestion");
            RenameColumn(table: "dbo.SurveyAndCheckBoxQuestion", name: "SingleChoiceId", newName: "CheckBoxQuestionId");
            RenameIndex(table: "dbo.SurveyAndCheckBoxQuestion", name: "IX_SingleChoiceId", newName: "IX_CheckBoxQuestionId");
            CreateTable(
                "dbo.SurveyCheckBoxQuestions",
                c => new
                    {
                        Survey_Id = c.Int(nullable: false),
                        CheckBoxQuestions_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Survey_Id, t.CheckBoxQuestions_Id })
                .ForeignKey("dbo.Surveys", t => t.Survey_Id, cascadeDelete: true)
                .ForeignKey("dbo.CheckBoxQuestions", t => t.CheckBoxQuestions_Id, cascadeDelete: true)
                .Index(t => t.Survey_Id)
                .Index(t => t.CheckBoxQuestions_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurveyCheckBoxQuestions", "CheckBoxQuestions_Id", "dbo.CheckBoxQuestions");
            DropForeignKey("dbo.SurveyCheckBoxQuestions", "Survey_Id", "dbo.Surveys");
            DropIndex("dbo.SurveyCheckBoxQuestions", new[] { "CheckBoxQuestions_Id" });
            DropIndex("dbo.SurveyCheckBoxQuestions", new[] { "Survey_Id" });
            DropTable("dbo.SurveyCheckBoxQuestions");
            RenameIndex(table: "dbo.SurveyAndCheckBoxQuestion", name: "IX_CheckBoxQuestionId", newName: "IX_SingleChoiceId");
            RenameColumn(table: "dbo.SurveyAndCheckBoxQuestion", name: "CheckBoxQuestionId", newName: "SingleChoiceId");
            RenameTable(name: "dbo.SurveyAndCheckBoxQuestion", newName: "SurveyAndSingleChoice");
        }
    }
}
