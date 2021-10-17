namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultipleChoiceRelationAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReponseMultipleChoice",
                c => new
                    {
                        ResponseId = c.Int(nullable: false),
                        MultipleChoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResponseId, t.MultipleChoiceId })
                .ForeignKey("dbo.Responses", t => t.ResponseId, cascadeDelete: true)
                .ForeignKey("dbo.MultipleChoiceQuestions", t => t.MultipleChoiceId, cascadeDelete: true)
                .Index(t => t.ResponseId)
                .Index(t => t.MultipleChoiceId);
 
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReponseMultipleChoice", "MultipleChoiceId", "dbo.MultipleChoiceQuestions");
            DropForeignKey("dbo.ReponseMultipleChoice", "ResponseId", "dbo.Responses");
            DropIndex("dbo.ReponseMultipleChoice", new[] { "MultipleChoiceId" });
            DropIndex("dbo.ReponseMultipleChoice", new[] { "ResponseId" });
            DropTable("dbo.ReponseMultipleChoice");
        }
    }
}
