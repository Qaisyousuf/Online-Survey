namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SingleChoiceAndResponseModelCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResponseAndSingleChoiceAnswer",
                c => new
                    {
                        ResponseId = c.Int(nullable: false),
                        SingleChoiceAnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResponseId, t.SingleChoiceAnswerId })
                .ForeignKey("dbo.Responses", t => t.ResponseId, cascadeDelete: true)
                .ForeignKey("dbo.YesNoAnswers", t => t.SingleChoiceAnswerId, cascadeDelete: true)
                .Index(t => t.ResponseId)
                .Index(t => t.SingleChoiceAnswerId);
            
            CreateTable(
                "dbo.ResponseAndSingleChoiceQuestion",
                c => new
                    {
                        ResponseId = c.Int(nullable: false),
                        SingleChoiceQuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResponseId, t.SingleChoiceQuestionId })
                .ForeignKey("dbo.Responses", t => t.ResponseId, cascadeDelete: true)
                .ForeignKey("dbo.YesNoQuestions", t => t.SingleChoiceQuestionId, cascadeDelete: true)
                .Index(t => t.ResponseId)
                .Index(t => t.SingleChoiceQuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResponseAndSingleChoiceQuestion", "SingleChoiceQuestionId", "dbo.YesNoQuestions");
            DropForeignKey("dbo.ResponseAndSingleChoiceQuestion", "ResponseId", "dbo.Responses");
            DropForeignKey("dbo.ResponseAndSingleChoiceAnswer", "SingleChoiceAnswerId", "dbo.YesNoAnswers");
            DropForeignKey("dbo.ResponseAndSingleChoiceAnswer", "ResponseId", "dbo.Responses");
            DropIndex("dbo.ResponseAndSingleChoiceQuestion", new[] { "SingleChoiceQuestionId" });
            DropIndex("dbo.ResponseAndSingleChoiceQuestion", new[] { "ResponseId" });
            DropIndex("dbo.ResponseAndSingleChoiceAnswer", new[] { "SingleChoiceAnswerId" });
            DropIndex("dbo.ResponseAndSingleChoiceAnswer", new[] { "ResponseId" });
            DropTable("dbo.ResponseAndSingleChoiceQuestion");
            DropTable("dbo.ResponseAndSingleChoiceAnswer");
        }
    }
}
