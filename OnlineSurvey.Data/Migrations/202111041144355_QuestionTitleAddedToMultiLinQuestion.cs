namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionTitleAddedToMultiLinQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MultiLineTexts", "QuestionTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MultiLineTexts", "QuestionTitle");
        }
    }
}
