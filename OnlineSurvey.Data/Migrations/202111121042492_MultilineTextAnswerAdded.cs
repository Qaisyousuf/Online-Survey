namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultilineTextAnswerAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MultilineTextAndMultilineResponse", "MultilineTextId", "dbo.MultiLineTexts");
            DropForeignKey("dbo.MultilineTextAndMultilineResponse", "MultilineTextResponseId", "dbo.MultiLineTextResponses");
            DropIndex("dbo.MultilineTextAndMultilineResponse", new[] { "MultilineTextId" });
            DropIndex("dbo.MultilineTextAndMultilineResponse", new[] { "MultilineTextResponseId" });
            CreateTable(
                "dbo.MultilineTextAndMultilineAnswer",
                c => new
                    {
                        MultilineTextAnswerId = c.Int(nullable: false),
                        MultilineTextResponseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MultilineTextAnswerId, t.MultilineTextResponseId })
                .ForeignKey("dbo.MultiLineTexts", t => t.MultilineTextAnswerId, cascadeDelete: true)
                .ForeignKey("dbo.MultiLineTextAnswers", t => t.MultilineTextResponseId, cascadeDelete: true)
                .Index(t => t.MultilineTextAnswerId)
                .Index(t => t.MultilineTextResponseId);
            
            AddColumn("dbo.MultiLineTexts", "MultiLineTextResponse_Id", c => c.Int());
            CreateIndex("dbo.MultiLineTexts", "MultiLineTextResponse_Id");
            AddForeignKey("dbo.MultiLineTexts", "MultiLineTextResponse_Id", "dbo.MultiLineTextResponses", "Id");
            DropTable("dbo.MultilineTextAndMultilineResponse");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MultilineTextAndMultilineResponse",
                c => new
                    {
                        MultilineTextId = c.Int(nullable: false),
                        MultilineTextResponseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MultilineTextId, t.MultilineTextResponseId });
            
            DropForeignKey("dbo.MultiLineTexts", "MultiLineTextResponse_Id", "dbo.MultiLineTextResponses");
            DropForeignKey("dbo.MultilineTextAndMultilineAnswer", "MultilineTextResponseId", "dbo.MultiLineTextAnswers");
            DropForeignKey("dbo.MultilineTextAndMultilineAnswer", "MultilineTextAnswerId", "dbo.MultiLineTexts");
            DropIndex("dbo.MultilineTextAndMultilineAnswer", new[] { "MultilineTextResponseId" });
            DropIndex("dbo.MultilineTextAndMultilineAnswer", new[] { "MultilineTextAnswerId" });
            DropIndex("dbo.MultiLineTexts", new[] { "MultiLineTextResponse_Id" });
            DropColumn("dbo.MultiLineTexts", "MultiLineTextResponse_Id");
            DropTable("dbo.MultilineTextAndMultilineAnswer");
            CreateIndex("dbo.MultilineTextAndMultilineResponse", "MultilineTextResponseId");
            CreateIndex("dbo.MultilineTextAndMultilineResponse", "MultilineTextId");
            AddForeignKey("dbo.MultilineTextAndMultilineResponse", "MultilineTextResponseId", "dbo.MultiLineTextResponses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MultilineTextAndMultilineResponse", "MultilineTextId", "dbo.MultiLineTexts", "Id", cascadeDelete: true);
        }
    }
}
