namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SurveyIdAdded : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Pages", "SurveyId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Pages", "SurveyId");
            //AddForeignKey("dbo.Pages", "SurveyId", "dbo.Surveys", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "SurveyId", "dbo.Surveys");
            DropIndex("dbo.Pages", new[] { "SurveyId" });
            DropColumn("dbo.Pages", "SurveyId");
        }
    }
}
