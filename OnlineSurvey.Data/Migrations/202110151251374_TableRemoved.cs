namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableRemoved : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Pages", "SurveyId", "dbo.Surveys");
            //DropIndex("dbo.Pages", new[] { "SurveyId" });
            //DropColumn("dbo.Pages", "SurveyId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Pages", "SurveyId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Pages", "SurveyId");
            //AddForeignKey("dbo.Pages", "SurveyId", "dbo.Surveys", "Id", cascadeDelete: true);
        }
    }
}
