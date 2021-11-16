namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckBoxQuestionRelationCreated : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SurveyAndCheckBoxQuestion", newName: "SurveyAndSingleChoice");
            RenameColumn(table: "dbo.SurveyAndSingleChoice", name: "CheckBoxQuestionId", newName: "SingleChoiceId");
            RenameIndex(table: "dbo.SurveyAndSingleChoice", name: "IX_CheckBoxQuestionId", newName: "IX_SingleChoiceId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SurveyAndSingleChoice", name: "IX_SingleChoiceId", newName: "IX_CheckBoxQuestionId");
            RenameColumn(table: "dbo.SurveyAndSingleChoice", name: "SingleChoiceId", newName: "CheckBoxQuestionId");
            RenameTable(name: "dbo.SurveyAndSingleChoice", newName: "SurveyAndCheckBoxQuestion");
        }
    }
}
