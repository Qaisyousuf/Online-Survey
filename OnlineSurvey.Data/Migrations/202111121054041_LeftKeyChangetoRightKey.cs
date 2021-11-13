namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeftKeyChangetoRightKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MultilineTextAndMultilineAnswer", name: "MultilineTextAnswerId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.MultilineTextAndMultilineAnswer", name: "MultilineTextId", newName: "MultilineTextAnswerId");
            RenameColumn(table: "dbo.MultilineTextAndMultilineAnswer", name: "__mig_tmp__0", newName: "MultilineTextId");
            RenameIndex(table: "dbo.MultilineTextAndMultilineAnswer", name: "IX_MultilineTextAnswerId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.MultilineTextAndMultilineAnswer", name: "IX_MultilineTextId", newName: "IX_MultilineTextAnswerId");
            RenameIndex(table: "dbo.MultilineTextAndMultilineAnswer", name: "__mig_tmp__0", newName: "IX_MultilineTextId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MultilineTextAndMultilineAnswer", name: "IX_MultilineTextId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.MultilineTextAndMultilineAnswer", name: "IX_MultilineTextAnswerId", newName: "IX_MultilineTextId");
            RenameIndex(table: "dbo.MultilineTextAndMultilineAnswer", name: "__mig_tmp__0", newName: "IX_MultilineTextAnswerId");
            RenameColumn(table: "dbo.MultilineTextAndMultilineAnswer", name: "MultilineTextId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.MultilineTextAndMultilineAnswer", name: "MultilineTextAnswerId", newName: "MultilineTextId");
            RenameColumn(table: "dbo.MultilineTextAndMultilineAnswer", name: "__mig_tmp__0", newName: "MultilineTextAnswerId");
        }
    }
}
