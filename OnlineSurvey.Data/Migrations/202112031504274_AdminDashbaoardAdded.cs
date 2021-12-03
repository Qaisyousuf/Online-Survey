namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminDashbaoardAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminDashboards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Animaiton = c.String(),
                        DesignedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminDashboards");
        }
    }
}
