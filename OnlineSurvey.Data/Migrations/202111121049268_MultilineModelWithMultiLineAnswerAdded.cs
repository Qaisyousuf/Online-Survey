namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultilineModelWithMultiLineAnswerAdded : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MultilineTextAndMultilineAnswer", name: "MultilineTextResponseId", newName: "MultilineTextId");
            RenameIndex(table: "dbo.MultilineTextAndMultilineAnswer", name: "IX_MultilineTextResponseId", newName: "IX_MultilineTextId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MultilineTextAndMultilineAnswer", name: "IX_MultilineTextId", newName: "IX_MultilineTextResponseId");
            RenameColumn(table: "dbo.MultilineTextAndMultilineAnswer", name: "MultilineTextId", newName: "MultilineTextResponseId");
        }
    }
}
