namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProcedureModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProcedures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Name = c.String(),
                        UserName = c.String(),
                        MyProcedureId = c.Int(nullable: false),
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyProocedures", t => t.MyProcedureId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .Index(t => t.MyProcedureId)
                .Index(t => t.Users_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProcedures", "Users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserProcedures", "MyProcedureId", "dbo.MyProocedures");
            DropIndex("dbo.UserProcedures", new[] { "Users_Id" });
            DropIndex("dbo.UserProcedures", new[] { "MyProcedureId" });
            DropTable("dbo.UserProcedures");
        }
    }
}
