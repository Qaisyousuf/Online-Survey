namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResponseAndMultiLineQuestionRelationAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResponseAndMultiLineQuestion",
                c => new
                    {
                        responseId = c.Int(nullable: false),
                        MultiLineQuestion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.responseId, t.MultiLineQuestion })
                .ForeignKey("dbo.Responses", t => t.responseId, cascadeDelete: true)
                .ForeignKey("dbo.MultiLineTexts", t => t.MultiLineQuestion, cascadeDelete: true)
                .Index(t => t.responseId)
                .Index(t => t.MultiLineQuestion);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResponseAndMultiLineQuestion", "MultiLineQuestion", "dbo.MultiLineTexts");
            DropForeignKey("dbo.ResponseAndMultiLineQuestion", "responseId", "dbo.Responses");
            DropIndex("dbo.ResponseAndMultiLineQuestion", new[] { "MultiLineQuestion" });
            DropIndex("dbo.ResponseAndMultiLineQuestion", new[] { "responseId" });
            DropTable("dbo.ResponseAndMultiLineQuestion");
        }
    }
}
