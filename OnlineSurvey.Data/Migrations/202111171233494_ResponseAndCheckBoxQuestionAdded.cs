namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResponseAndCheckBoxQuestionAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResponseAndCheckboxQuestion",
                c => new
                    {
                        ResponseId = c.Int(nullable: false),
                        CheckBoxQuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResponseId, t.CheckBoxQuestionId })
                .ForeignKey("dbo.Responses", t => t.ResponseId, cascadeDelete: true)
                .ForeignKey("dbo.CheckBoxQuestions", t => t.CheckBoxQuestionId, cascadeDelete: true)
                .Index(t => t.ResponseId)
                .Index(t => t.CheckBoxQuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResponseAndCheckboxQuestion", "CheckBoxQuestionId", "dbo.CheckBoxQuestions");
            DropForeignKey("dbo.ResponseAndCheckboxQuestion", "ResponseId", "dbo.Responses");
            DropIndex("dbo.ResponseAndCheckboxQuestion", new[] { "CheckBoxQuestionId" });
            DropIndex("dbo.ResponseAndCheckboxQuestion", new[] { "ResponseId" });
            DropTable("dbo.ResponseAndCheckboxQuestion");
        }
    }
}
