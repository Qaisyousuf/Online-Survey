namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultiLineTextModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MultiLineTexts", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MultiLineTexts", "IsActive");
        }
    }
}
