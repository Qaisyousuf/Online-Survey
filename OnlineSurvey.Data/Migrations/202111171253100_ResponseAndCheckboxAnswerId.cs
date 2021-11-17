namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResponseAndCheckboxAnswerId : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResponseAndCheckboxAnswer",
                c => new
                    {
                        ResponseId = c.Int(nullable: false),
                        CheckBoxAnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResponseId, t.CheckBoxAnswerId })
                .ForeignKey("dbo.Responses", t => t.ResponseId, cascadeDelete: true)
                .ForeignKey("dbo.CheckBoxAnswers", t => t.CheckBoxAnswerId, cascadeDelete: true)
                .Index(t => t.ResponseId)
                .Index(t => t.CheckBoxAnswerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResponseAndCheckboxAnswer", "CheckBoxAnswerId", "dbo.CheckBoxAnswers");
            DropForeignKey("dbo.ResponseAndCheckboxAnswer", "ResponseId", "dbo.Responses");
            DropIndex("dbo.ResponseAndCheckboxAnswer", new[] { "CheckBoxAnswerId" });
            DropIndex("dbo.ResponseAndCheckboxAnswer", new[] { "ResponseId" });
            DropTable("dbo.ResponseAndCheckboxAnswer");
        }
    }
}
