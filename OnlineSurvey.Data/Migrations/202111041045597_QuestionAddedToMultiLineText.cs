namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionAddedToMultiLineText : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MultiLineTexts", "Question", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MultiLineTexts", "Question");
        }
    }
}
