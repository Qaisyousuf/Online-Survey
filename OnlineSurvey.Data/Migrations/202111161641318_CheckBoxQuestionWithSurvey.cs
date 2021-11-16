namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckBoxQuestionWithSurvey : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SurveyCheckBoxQuestions", newName: "SurveyAndCheckBoxQuestion");
            RenameColumn(table: "dbo.SurveyAndCheckBoxQuestion", name: "Survey_Id", newName: "SurveyId");
            RenameColumn(table: "dbo.SurveyAndCheckBoxQuestion", name: "CheckBoxQuestions_Id", newName: "CheckBoxQuestionId");
            RenameIndex(table: "dbo.SurveyAndCheckBoxQuestion", name: "IX_Survey_Id", newName: "IX_SurveyId");
            RenameIndex(table: "dbo.SurveyAndCheckBoxQuestion", name: "IX_CheckBoxQuestions_Id", newName: "IX_CheckBoxQuestionId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SurveyAndCheckBoxQuestion", name: "IX_CheckBoxQuestionId", newName: "IX_CheckBoxQuestions_Id");
            RenameIndex(table: "dbo.SurveyAndCheckBoxQuestion", name: "IX_SurveyId", newName: "IX_Survey_Id");
            RenameColumn(table: "dbo.SurveyAndCheckBoxQuestion", name: "CheckBoxQuestionId", newName: "CheckBoxQuestions_Id");
            RenameColumn(table: "dbo.SurveyAndCheckBoxQuestion", name: "SurveyId", newName: "Survey_Id");
            RenameTable(name: "dbo.SurveyAndCheckBoxQuestion", newName: "SurveyCheckBoxQuestions");
        }
    }
}
