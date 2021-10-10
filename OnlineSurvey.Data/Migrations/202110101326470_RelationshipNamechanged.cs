namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipNamechanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SurveyMultipleChoiceQuestion", name: "MultiChoiceQusetionForSurvey", newName: "QuestionId");
            RenameColumn(table: "dbo.SurveyMultipleChoiceQuestion", name: "SurveyForMultipleChoiceQustionId", newName: "SurveyId");
            RenameIndex(table: "dbo.SurveyMultipleChoiceQuestion", name: "IX_MultiChoiceQusetionForSurvey", newName: "IX_QuestionId");
            RenameIndex(table: "dbo.SurveyMultipleChoiceQuestion", name: "IX_SurveyForMultipleChoiceQustionId", newName: "IX_SurveyId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SurveyMultipleChoiceQuestion", name: "IX_SurveyId", newName: "IX_SurveyForMultipleChoiceQustionId");
            RenameIndex(table: "dbo.SurveyMultipleChoiceQuestion", name: "IX_QuestionId", newName: "IX_MultiChoiceQusetionForSurvey");
            RenameColumn(table: "dbo.SurveyMultipleChoiceQuestion", name: "SurveyId", newName: "SurveyForMultipleChoiceQustionId");
            RenameColumn(table: "dbo.SurveyMultipleChoiceQuestion", name: "QuestionId", newName: "MultiChoiceQusetionForSurvey");
        }
    }
}
