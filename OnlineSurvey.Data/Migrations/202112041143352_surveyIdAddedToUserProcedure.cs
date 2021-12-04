namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class surveyIdAddedToUserProcedure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProcedures", "SurveyId", c => c.Int());
            CreateIndex("dbo.UserProcedures", "SurveyId");
            AddForeignKey("dbo.UserProcedures", "SurveyId", "dbo.Surveys", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProcedures", "SurveyId", "dbo.Surveys");
            DropIndex("dbo.UserProcedures", new[] { "SurveyId" });
            DropColumn("dbo.UserProcedures", "SurveyId");
        }
    }
}
