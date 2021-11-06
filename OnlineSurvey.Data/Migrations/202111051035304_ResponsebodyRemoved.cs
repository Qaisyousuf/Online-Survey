namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResponsebodyRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ResponseAndResponseBody", "ResponseId", "dbo.Responses");
            DropForeignKey("dbo.ResponseAndResponseBody", "ResponseBody", "dbo.ResponseBodies");
            DropIndex("dbo.ResponseAndResponseBody", new[] { "ResponseId" });
            DropIndex("dbo.ResponseAndResponseBody", new[] { "ResponseBody" });
            DropTable("dbo.ResponseBodies");
            DropTable("dbo.ResponseAndResponseBody");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ResponseAndResponseBody",
                c => new
                    {
                        ResponseId = c.Int(nullable: false),
                        ResponseBody = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResponseId, t.ResponseBody });
            
            CreateTable(
                "dbo.ResponseBodies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ResponseAndResponseBody", "ResponseBody");
            CreateIndex("dbo.ResponseAndResponseBody", "ResponseId");
            AddForeignKey("dbo.ResponseAndResponseBody", "ResponseBody", "dbo.ResponseBodies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ResponseAndResponseBody", "ResponseId", "dbo.Responses", "Id", cascadeDelete: true);
        }
    }
}
