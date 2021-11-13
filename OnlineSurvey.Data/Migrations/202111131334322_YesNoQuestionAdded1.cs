namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YesNoQuestionAdded1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.YesNoQuestionYesNoAnswers", newName: "YesNoQuestionAndAnswer");
            RenameColumn(table: "dbo.YesNoQuestionAndAnswer", name: "YesNoQuestion_Id", newName: "YesNoQuestionId");
            RenameColumn(table: "dbo.YesNoQuestionAndAnswer", name: "YesNoAnswer_Id", newName: "YesNoAnswerId");
            RenameIndex(table: "dbo.YesNoQuestionAndAnswer", name: "IX_YesNoQuestion_Id", newName: "IX_YesNoQuestionId");
            RenameIndex(table: "dbo.YesNoQuestionAndAnswer", name: "IX_YesNoAnswer_Id", newName: "IX_YesNoAnswerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.YesNoQuestionAndAnswer", name: "IX_YesNoAnswerId", newName: "IX_YesNoAnswer_Id");
            RenameIndex(table: "dbo.YesNoQuestionAndAnswer", name: "IX_YesNoQuestionId", newName: "IX_YesNoQuestion_Id");
            RenameColumn(table: "dbo.YesNoQuestionAndAnswer", name: "YesNoAnswerId", newName: "YesNoAnswer_Id");
            RenameColumn(table: "dbo.YesNoQuestionAndAnswer", name: "YesNoQuestionId", newName: "YesNoQuestion_Id");
            RenameTable(name: "dbo.YesNoQuestionAndAnswer", newName: "YesNoQuestionYesNoAnswers");
        }
    }
}
