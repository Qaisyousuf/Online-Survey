namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenusModelUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "ParentId", "dbo.Menus");
            DropIndex("dbo.Menus", new[] { "ParentId" });
            DropColumn("dbo.Menus", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "ParentId", c => c.Int());
            CreateIndex("dbo.Menus", "ParentId");
            AddForeignKey("dbo.Menus", "ParentId", "dbo.Menus", "Id");
        }
    }
}
