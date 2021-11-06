namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultiLineResponseAndMultiLineTextAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MultiLineTextResponseMultiLineTexts",
                c => new
                    {
                        MultiLineTextResponse_Id = c.Int(nullable: false),
                        MultiLineText_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MultiLineTextResponse_Id, t.MultiLineText_Id })
                .ForeignKey("dbo.MultiLineTextResponses", t => t.MultiLineTextResponse_Id, cascadeDelete: true)
                .ForeignKey("dbo.MultiLineTexts", t => t.MultiLineText_Id, cascadeDelete: true)
                .Index(t => t.MultiLineTextResponse_Id)
                .Index(t => t.MultiLineText_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MultiLineTextResponseMultiLineTexts", "MultiLineText_Id", "dbo.MultiLineTexts");
            DropForeignKey("dbo.MultiLineTextResponseMultiLineTexts", "MultiLineTextResponse_Id", "dbo.MultiLineTextResponses");
            DropIndex("dbo.MultiLineTextResponseMultiLineTexts", new[] { "MultiLineText_Id" });
            DropIndex("dbo.MultiLineTextResponseMultiLineTexts", new[] { "MultiLineTextResponse_Id" });
            DropTable("dbo.MultiLineTextResponseMultiLineTexts");
        }
    }
}
