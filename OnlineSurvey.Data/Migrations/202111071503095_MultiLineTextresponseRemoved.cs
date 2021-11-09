namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultiLineTextresponseRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MultiLineTextResponseMultiLineTexts", "MultiLineTextResponse_Id", "dbo.MultiLineTextResponses");
            DropForeignKey("dbo.MultiLineTextResponseMultiLineTexts", "MultiLineText_Id", "dbo.MultiLineTexts");
            DropForeignKey("dbo.ReponseMultlinTextResponse", "ResponseId", "dbo.Responses");
            DropForeignKey("dbo.ReponseMultlinTextResponse", "MultiLinTextResponse", "dbo.MultiLineTextResponses");
            DropIndex("dbo.MultiLineTextResponseMultiLineTexts", new[] { "MultiLineTextResponse_Id" });
            DropIndex("dbo.MultiLineTextResponseMultiLineTexts", new[] { "MultiLineText_Id" });
            DropIndex("dbo.ReponseMultlinTextResponse", new[] { "ResponseId" });
            DropIndex("dbo.ReponseMultlinTextResponse", new[] { "MultiLinTextResponse" });
            DropTable("dbo.MultiLineTextResponses");
            DropTable("dbo.MultiLineTextResponseMultiLineTexts");
            DropTable("dbo.ReponseMultlinTextResponse");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReponseMultlinTextResponse",
                c => new
                    {
                        ResponseId = c.Int(nullable: false),
                        MultiLinTextResponse = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResponseId, t.MultiLinTextResponse });
            
            CreateTable(
                "dbo.MultiLineTextResponseMultiLineTexts",
                c => new
                    {
                        MultiLineTextResponse_Id = c.Int(nullable: false),
                        MultiLineText_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MultiLineTextResponse_Id, t.MultiLineText_Id });
            
            CreateTable(
                "dbo.MultiLineTextResponses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        MulitLine = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ReponseMultlinTextResponse", "MultiLinTextResponse");
            CreateIndex("dbo.ReponseMultlinTextResponse", "ResponseId");
            CreateIndex("dbo.MultiLineTextResponseMultiLineTexts", "MultiLineText_Id");
            CreateIndex("dbo.MultiLineTextResponseMultiLineTexts", "MultiLineTextResponse_Id");
            AddForeignKey("dbo.ReponseMultlinTextResponse", "MultiLinTextResponse", "dbo.MultiLineTextResponses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReponseMultlinTextResponse", "ResponseId", "dbo.Responses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MultiLineTextResponseMultiLineTexts", "MultiLineText_Id", "dbo.MultiLineTexts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MultiLineTextResponseMultiLineTexts", "MultiLineTextResponse_Id", "dbo.MultiLineTextResponses", "Id", cascadeDelete: true);
        }
    }
}
