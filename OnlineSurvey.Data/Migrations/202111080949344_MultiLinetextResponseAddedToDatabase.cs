namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultiLinetextResponseAddedToDatabase : DbMigration
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
                "dbo.ResponseAndMultiLineTextResponse",
                c => new
                    {
                        ResponseId = c.Int(nullable: false),
                        MultiLineResponse = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResponseId, t.MultiLineResponse })
                .ForeignKey("dbo.Responses", t => t.ResponseId, cascadeDelete: true)
                .ForeignKey("dbo.MultiLineTextResponses", t => t.MultiLineResponse, cascadeDelete: true)
                .Index(t => t.ResponseId)
                .Index(t => t.MultiLineResponse);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResponseAndMultiLineTextResponse", "MultiLineResponse", "dbo.MultiLineTextResponses");
            DropForeignKey("dbo.ResponseAndMultiLineTextResponse", "ResponseId", "dbo.Responses");
            DropIndex("dbo.ResponseAndMultiLineTextResponse", new[] { "MultiLineResponse" });
            DropIndex("dbo.ResponseAndMultiLineTextResponse", new[] { "ResponseId" });
            DropTable("dbo.ResponseAndMultiLineTextResponse");
            DropTable("dbo.MultiLineTextResponses");
        }
    }
}
