namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiteSettingAndFooterLinksAdded : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "LockoutEndDateUtc", newName: "datetime2");
            CreateTable(
                "dbo.FooterLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NavigationName = c.String(),
                        LinkUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SiteSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiteTitle = c.String(),
                        SiteName = c.String(),
                        SiteOwner = c.String(),
                        datetime2 = c.DateTime(nullable: false),
                        SiteContent = c.String(),
                        DesignedBy = c.String(),
                        Sitecopyright = c.String(),
                        AnimationUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SiteSettingFooterLinks",
                c => new
                    {
                        FooterLinksId = c.Int(nullable: false),
                        SiteSettingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FooterLinksId, t.SiteSettingId })
                .ForeignKey("dbo.SiteSettings", t => t.FooterLinksId, cascadeDelete: true)
                .ForeignKey("dbo.FooterLinks", t => t.SiteSettingId, cascadeDelete: true)
                .Index(t => t.FooterLinksId)
                .Index(t => t.SiteSettingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SiteSettingFooterLinks", "SiteSettingId", "dbo.FooterLinks");
            DropForeignKey("dbo.SiteSettingFooterLinks", "FooterLinksId", "dbo.SiteSettings");
            DropIndex("dbo.SiteSettingFooterLinks", new[] { "SiteSettingId" });
            DropIndex("dbo.SiteSettingFooterLinks", new[] { "FooterLinksId" });
            DropTable("dbo.SiteSettingFooterLinks");
            DropTable("dbo.SiteSettings");
            DropTable("dbo.FooterLinks");
            RenameColumn(table: "dbo.AspNetUsers", name: "datetime2", newName: "LockoutEndDateUtc");
        }
    }
}
