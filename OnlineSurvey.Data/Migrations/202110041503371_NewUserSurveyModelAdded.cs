namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUserSurveyModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserGenders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsSelected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserSurveyRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Mobile = c.String(),
                        Address = c.String(),
                        CPRNumber = c.String(),
                        datetime2 = c.DateTime(nullable: false),
                        GenderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserGenders", t => t.GenderId, cascadeDelete: true)
                .Index(t => t.GenderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSurveyRegistrations", "GenderId", "dbo.UserGenders");
            DropIndex("dbo.UserSurveyRegistrations", new[] { "GenderId" });
            DropTable("dbo.UserSurveyRegistrations");
            DropTable("dbo.UserGenders");
        }
    }
}
