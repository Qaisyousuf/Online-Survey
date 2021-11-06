namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultilineTextAnswerRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MultiLineTexts", "Title");
            DropColumn("dbo.MultiLineTexts", "MultiText");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MultiLineTexts", "MultiText", c => c.String());
            AddColumn("dbo.MultiLineTexts", "Title", c => c.String());
        }
    }
}
