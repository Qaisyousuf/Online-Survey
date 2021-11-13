namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultilineTextResponseModelremoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MultilineTextAndMultilineAnswer", "MultilineTextId", "dbo.MultiLineTexts");
            DropForeignKey("dbo.MultilineTextAndMultilineAnswer", "MultilineTextAnswerId", "dbo.MultiLineTextAnswers");
            DropForeignKey("dbo.MultiLineTexts", "MultiLineTextResponse_Id", "dbo.MultiLineTextResponses");
            DropIndex("dbo.MultiLineTexts", new[] { "MultiLineTextResponse_Id" });
            DropIndex("dbo.MultilineTextAndMultilineAnswer", new[] { "MultilineTextId" });
            DropIndex("dbo.MultilineTextAndMultilineAnswer", new[] { "MultilineTextAnswerId" });
            CreateTable(
                "dbo.MultilineTextAndMultilineResponse",
                c => new
                    {
                        MultilineTextId = c.Int(nullable: false),
                        MultilineTextResponseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MultilineTextId, t.MultilineTextResponseId })
                .ForeignKey("dbo.MultiLineTexts", t => t.MultilineTextId, cascadeDelete: true)
                .ForeignKey("dbo.MultiLineTextResponses", t => t.MultilineTextResponseId, cascadeDelete: true)
                .Index(t => t.MultilineTextId)
                .Index(t => t.MultilineTextResponseId);
            
            DropColumn("dbo.MultiLineTexts", "MultiLineTextResponse_Id");
            DropTable("dbo.MultilineTextAndMultilineAnswer");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MultilineTextAndMultilineAnswer",
                c => new
                    {
                        MultilineTextId = c.Int(nullable: false),
                        MultilineTextAnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MultilineTextId, t.MultilineTextAnswerId });
            
            AddColumn("dbo.MultiLineTexts", "MultiLineTextResponse_Id", c => c.Int());
            DropForeignKey("dbo.MultilineTextAndMultilineResponse", "MultilineTextResponseId", "dbo.MultiLineTextResponses");
            DropForeignKey("dbo.MultilineTextAndMultilineResponse", "MultilineTextId", "dbo.MultiLineTexts");
            DropIndex("dbo.MultilineTextAndMultilineResponse", new[] { "MultilineTextResponseId" });
            DropIndex("dbo.MultilineTextAndMultilineResponse", new[] { "MultilineTextId" });
            DropTable("dbo.MultilineTextAndMultilineResponse");
            CreateIndex("dbo.MultilineTextAndMultilineAnswer", "MultilineTextAnswerId");
            CreateIndex("dbo.MultilineTextAndMultilineAnswer", "MultilineTextId");
            CreateIndex("dbo.MultiLineTexts", "MultiLineTextResponse_Id");
            AddForeignKey("dbo.MultiLineTexts", "MultiLineTextResponse_Id", "dbo.MultiLineTextResponses", "Id");
            AddForeignKey("dbo.MultilineTextAndMultilineAnswer", "MultilineTextAnswerId", "dbo.MultiLineTextAnswers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MultilineTextAndMultilineAnswer", "MultilineTextId", "dbo.MultiLineTexts", "Id", cascadeDelete: true);
        }
    }
}
