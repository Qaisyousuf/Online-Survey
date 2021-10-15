namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SurveyIdAdded : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "SurveyId", "dbo.Surveys");
            DropIndex("dbo.Pages", new[] { "SurveyId" });
            DropColumn("dbo.Pages", "SurveyId");
        }
    }
}
