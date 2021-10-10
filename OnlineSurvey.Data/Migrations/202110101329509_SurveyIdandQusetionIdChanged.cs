namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SurveyIdandQusetionIdChanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SurveyMultipleChoiceQuestion", name: "QuestionId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.SurveyMultipleChoiceQuestion", name: "SurveyId", newName: "QuestionId");
            RenameColumn(table: "dbo.SurveyMultipleChoiceQuestion", name: "__mig_tmp__0", newName: "SurveyId");
            RenameIndex(table: "dbo.SurveyMultipleChoiceQuestion", name: "IX_QuestionId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.SurveyMultipleChoiceQuestion", name: "IX_SurveyId", newName: "IX_QuestionId");
            RenameIndex(table: "dbo.SurveyMultipleChoiceQuestion", name: "__mig_tmp__0", newName: "IX_SurveyId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SurveyMultipleChoiceQuestion", name: "IX_SurveyId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.SurveyMultipleChoiceQuestion", name: "IX_QuestionId", newName: "IX_SurveyId");
            RenameIndex(table: "dbo.SurveyMultipleChoiceQuestion", name: "__mig_tmp__0", newName: "IX_QuestionId");
            RenameColumn(table: "dbo.SurveyMultipleChoiceQuestion", name: "SurveyId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.SurveyMultipleChoiceQuestion", name: "QuestionId", newName: "SurveyId");
            RenameColumn(table: "dbo.SurveyMultipleChoiceQuestion", name: "__mig_tmp__0", newName: "QuestionId");
        }
    }
}
