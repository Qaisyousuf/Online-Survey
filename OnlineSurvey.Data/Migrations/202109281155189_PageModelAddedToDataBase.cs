namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PageModelAddedToDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        Content = c.String(),
                        BannerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banners", t => t.BannerId, cascadeDelete: true)
                .Index(t => t.BannerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "BannerId", "dbo.Banners");
            DropIndex("dbo.Pages", new[] { "BannerId" });
            DropTable("dbo.Pages");
        }
    }
}
