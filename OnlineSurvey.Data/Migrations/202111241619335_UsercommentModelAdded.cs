namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsercommentModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Comment = c.String(),
                        Replay = c.String(),
                        UserName = c.String(),
                        ReplayedUser = c.String(),
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserComments", "Users_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserComments", new[] { "Users_Id" });
            DropTable("dbo.UserComments");
        }
    }
}
