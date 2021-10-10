namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultipleChoiceQuestionNamechanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MutipleChoiceQuesionAndAnswer", name: "MultipleChoiceQuestionId", newName: "MultipleChoiceAnswerId");
            RenameIndex(table: "dbo.MutipleChoiceQuesionAndAnswer", name: "IX_MultipleChoiceQuestionId", newName: "IX_MultipleChoiceAnswerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MutipleChoiceQuesionAndAnswer", name: "IX_MultipleChoiceAnswerId", newName: "IX_MultipleChoiceQuestionId");
            RenameColumn(table: "dbo.MutipleChoiceQuesionAndAnswer", name: "MultipleChoiceAnswerId", newName: "MultipleChoiceQuestionId");
        }
    }
}
