namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDashboardModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDashboards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        MainTitle = c.String(),
                        AnimationUrl = c.String(),
                        Content = c.String(),
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDashboards", "Users_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserDashboards", new[] { "Users_Id" });
            DropTable("dbo.UserDashboards");
        }
    }
}
