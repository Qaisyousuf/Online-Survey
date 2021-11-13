namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationCreatedBetweenMultilineAndMultilineResponse : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MultiLineTextResponseMultiLineTexts", newName: "MultilineTextAndMultilineResponse");
            RenameColumn(table: "dbo.MultilineTextAndMultilineResponse", name: "MultiLineTextResponse_Id", newName: "MultilineTextResponseId");
            RenameColumn(table: "dbo.MultilineTextAndMultilineResponse", name: "MultiLineText_Id", newName: "MultilineTextId");
            RenameIndex(table: "dbo.MultilineTextAndMultilineResponse", name: "IX_MultiLineText_Id", newName: "IX_MultilineTextId");
            RenameIndex(table: "dbo.MultilineTextAndMultilineResponse", name: "IX_MultiLineTextResponse_Id", newName: "IX_MultilineTextResponseId");
            DropPrimaryKey("dbo.MultilineTextAndMultilineResponse");
            AddPrimaryKey("dbo.MultilineTextAndMultilineResponse", new[] { "MultilineTextId", "MultilineTextResponseId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MultilineTextAndMultilineResponse");
            AddPrimaryKey("dbo.MultilineTextAndMultilineResponse", new[] { "MultiLineTextResponse_Id", "MultiLineText_Id" });
            RenameIndex(table: "dbo.MultilineTextAndMultilineResponse", name: "IX_MultilineTextResponseId", newName: "IX_MultiLineTextResponse_Id");
            RenameIndex(table: "dbo.MultilineTextAndMultilineResponse", name: "IX_MultilineTextId", newName: "IX_MultiLineText_Id");
            RenameColumn(table: "dbo.MultilineTextAndMultilineResponse", name: "MultilineTextId", newName: "MultiLineText_Id");
            RenameColumn(table: "dbo.MultilineTextAndMultilineResponse", name: "MultilineTextResponseId", newName: "MultiLineTextResponse_Id");
            RenameTable(name: "dbo.MultilineTextAndMultilineResponse", newName: "MultiLineTextResponseMultiLineTexts");
        }
    }
}
