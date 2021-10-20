namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserSurveyIdAdded : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Surveys", "UserSurveyId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Surveys", "UserSurveyId");
            //AddForeignKey("dbo.Surveys", "UserSurveyId", "dbo.UserSurveyRegistrations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Surveys", "UserSurveyId", "dbo.UserSurveyRegistrations");
            DropIndex("dbo.Surveys", new[] { "UserSurveyId" });
            DropColumn("dbo.Surveys", "UserSurveyId");
        }
    }
}
