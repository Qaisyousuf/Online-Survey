namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class multilineTextUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MultiLineTexts", "MultiLineTextResponse_Id", c => c.Int());
            CreateIndex("dbo.MultiLineTexts", "MultiLineTextResponse_Id");
            AddForeignKey("dbo.MultiLineTexts", "MultiLineTextResponse_Id", "dbo.MultiLineTextResponses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MultiLineTexts", "MultiLineTextResponse_Id", "dbo.MultiLineTextResponses");
            DropIndex("dbo.MultiLineTexts", new[] { "MultiLineTextResponse_Id" });
            DropColumn("dbo.MultiLineTexts", "MultiLineTextResponse_Id");
        }
    }
}
