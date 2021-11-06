namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultiLinTextResponseModelCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MultiLineTextResponses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        MulitLine = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReponseMultlinTextResponse",
                c => new
                    {
                        ResponseId = c.Int(nullable: false),
                        MultiLinTextResponse = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResponseId, t.MultiLinTextResponse })
                .ForeignKey("dbo.Responses", t => t.ResponseId, cascadeDelete: true)
                .ForeignKey("dbo.MultiLineTextResponses", t => t.MultiLinTextResponse, cascadeDelete: true)
                .Index(t => t.ResponseId)
                .Index(t => t.MultiLinTextResponse);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReponseMultlinTextResponse", "MultiLinTextResponse", "dbo.MultiLineTextResponses");
            DropForeignKey("dbo.ReponseMultlinTextResponse", "ResponseId", "dbo.Responses");
            DropIndex("dbo.ReponseMultlinTextResponse", new[] { "MultiLinTextResponse" });
            DropIndex("dbo.ReponseMultlinTextResponse", new[] { "ResponseId" });
            DropTable("dbo.ReponseMultlinTextResponse");
            DropTable("dbo.MultiLineTextResponses");
        }
    }
}
