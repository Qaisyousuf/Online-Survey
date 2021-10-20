namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserSurveyIdRemoved : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Surveys", "UserSurveyId", "dbo.UserSurveyRegistrations");
            //DropIndex("dbo.Surveys", new[] { "UserSurveyId" });
            //DropColumn("dbo.Surveys", "UserSurveyId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Surveys", "UserSurveyId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Surveys", "UserSurveyId");
            //AddForeignKey("dbo.Surveys", "UserSurveyId", "dbo.UserSurveyRegistrations", "Id", cascadeDelete: true);
        }
    }
}
