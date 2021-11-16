namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckBoxQuestionAndAnswerAedded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckBoxQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Question = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CheckBoxItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Checked = c.Boolean(nullable: false),
                        CheckBoxQuestions_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CheckBoxQuestions", t => t.CheckBoxQuestions_Id)
                .Index(t => t.CheckBoxQuestions_Id);
            
            CreateTable(
                "dbo.CheckBoxQuestionsAndAnswers",
                c => new
                    {
                        CheckBoxQuestionId = c.Int(nullable: false),
                        CheckboxAnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CheckBoxQuestionId, t.CheckboxAnswerId })
                .ForeignKey("dbo.CheckBoxQuestions", t => t.CheckBoxQuestionId, cascadeDelete: true)
                .ForeignKey("dbo.CheckBoxAnswers", t => t.CheckboxAnswerId, cascadeDelete: true)
                .Index(t => t.CheckBoxQuestionId)
                .Index(t => t.CheckboxAnswerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckBoxItems", "CheckBoxQuestions_Id", "dbo.CheckBoxQuestions");
            DropForeignKey("dbo.CheckBoxQuestionsAndAnswers", "CheckboxAnswerId", "dbo.CheckBoxAnswers");
            DropForeignKey("dbo.CheckBoxQuestionsAndAnswers", "CheckBoxQuestionId", "dbo.CheckBoxQuestions");
            DropIndex("dbo.CheckBoxQuestionsAndAnswers", new[] { "CheckboxAnswerId" });
            DropIndex("dbo.CheckBoxQuestionsAndAnswers", new[] { "CheckBoxQuestionId" });
            DropIndex("dbo.CheckBoxItems", new[] { "CheckBoxQuestions_Id" });
            DropTable("dbo.CheckBoxQuestionsAndAnswers");
            DropTable("dbo.CheckBoxItems");
            DropTable("dbo.CheckBoxQuestions");
        }
    }
}
