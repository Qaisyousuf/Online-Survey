namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenderModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsSelected = c.Boolean(nullable: false),
                        UserSurvey_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSurveys", t => t.UserSurvey_Id)
                .Index(t => t.UserSurvey_Id);
            
            CreateTable(
                "dbo.UserSurveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstNName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Mobile = c.String(),
                        Address = c.String(),
                        CPRNumber = c.String(),
                        DOB = c.String(),
                        SelectGender = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genders", "UserSurvey_Id", "dbo.UserSurveys");
            DropIndex("dbo.Genders", new[] { "UserSurvey_Id" });
            DropTable("dbo.UserSurveys");
            DropTable("dbo.Genders");
        }
    }
}
