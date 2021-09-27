namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiteSettingsUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SiteSettings", "IsSiteFooterActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SiteSettings", "IsSiteFooterActive");
        }
    }
}
