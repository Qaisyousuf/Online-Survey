namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenusModelchanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "PartentId", c => c.Int());
            CreateIndex("dbo.Menus", "PartentId");
            AddForeignKey("dbo.Menus", "PartentId", "dbo.Menus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "PartentId", "dbo.Menus");
            DropIndex("dbo.Menus", new[] { "PartentId" });
            DropColumn("dbo.Menus", "PartentId");
        }
    }
}
