namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResponseBodyModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResponseBodies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResponseAndResponseBody",
                c => new
                    {
                        ResponseId = c.Int(nullable: false),
                        ResponseBody = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResponseId, t.ResponseBody })
                .ForeignKey("dbo.Responses", t => t.ResponseId, cascadeDelete: true)
                .ForeignKey("dbo.ResponseBodies", t => t.ResponseBody, cascadeDelete: true)
                .Index(t => t.ResponseId)
                .Index(t => t.ResponseBody);
            
            DropColumn("dbo.Responses", "Title");
            DropColumn("dbo.Responses", "Body");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Responses", "Body", c => c.String());
            AddColumn("dbo.Responses", "Title", c => c.String());
            DropForeignKey("dbo.ResponseAndResponseBody", "ResponseBody", "dbo.ResponseBodies");
            DropForeignKey("dbo.ResponseAndResponseBody", "ResponseId", "dbo.Responses");
            DropIndex("dbo.ResponseAndResponseBody", new[] { "ResponseBody" });
            DropIndex("dbo.ResponseAndResponseBody", new[] { "ResponseId" });
            DropTable("dbo.ResponseAndResponseBody");
            DropTable("dbo.ResponseBodies");
        }
    }
}
