namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YesNoAnswerAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.YesNoAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Answer = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.YesNoQuestionYesNoAnswers",
                c => new
                    {
                        YesNoQuestion_Id = c.Int(nullable: false),
                        YesNoAnswer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.YesNoQuestion_Id, t.YesNoAnswer_Id })
                .ForeignKey("dbo.YesNoQuestions", t => t.YesNoQuestion_Id, cascadeDelete: true)
                .ForeignKey("dbo.YesNoAnswers", t => t.YesNoAnswer_Id, cascadeDelete: true)
                .Index(t => t.YesNoQuestion_Id)
                .Index(t => t.YesNoAnswer_Id);
            
            AddColumn("dbo.YesNoQuestions", "Question", c => c.String());
            DropColumn("dbo.YesNoQuestions", "Answer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.YesNoQuestions", "Answer", c => c.String());
            DropForeignKey("dbo.YesNoQuestionYesNoAnswers", "YesNoAnswer_Id", "dbo.YesNoAnswers");
            DropForeignKey("dbo.YesNoQuestionYesNoAnswers", "YesNoQuestion_Id", "dbo.YesNoQuestions");
            DropIndex("dbo.YesNoQuestionYesNoAnswers", new[] { "YesNoAnswer_Id" });
            DropIndex("dbo.YesNoQuestionYesNoAnswers", new[] { "YesNoQuestion_Id" });
            DropColumn("dbo.YesNoQuestions", "Question");
            DropTable("dbo.YesNoQuestionYesNoAnswers");
            DropTable("dbo.YesNoAnswers");
        }
    }
}
