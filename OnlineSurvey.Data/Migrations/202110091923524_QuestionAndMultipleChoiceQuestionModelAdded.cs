namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionAndMultipleChoiceQuestionModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        Type = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionMultipleChoiceQuestions",
                c => new
                    {
                        Question_Id = c.Int(nullable: false),
                        MultipleChoiceQuestions_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_Id, t.MultipleChoiceQuestions_Id })
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .ForeignKey("dbo.MultipleChoiceQuestions", t => t.MultipleChoiceQuestions_Id, cascadeDelete: true)
                .Index(t => t.Question_Id)
                .Index(t => t.MultipleChoiceQuestions_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionMultipleChoiceQuestions", "MultipleChoiceQuestions_Id", "dbo.MultipleChoiceQuestions");
            DropForeignKey("dbo.QuestionMultipleChoiceQuestions", "Question_Id", "dbo.Questions");
            DropIndex("dbo.QuestionMultipleChoiceQuestions", new[] { "MultipleChoiceQuestions_Id" });
            DropIndex("dbo.QuestionMultipleChoiceQuestions", new[] { "Question_Id" });
            DropTable("dbo.QuestionMultipleChoiceQuestions");
            DropTable("dbo.Questions");
        }
    }
}
