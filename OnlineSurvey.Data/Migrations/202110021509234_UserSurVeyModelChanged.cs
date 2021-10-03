namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserSurVeyModelChanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserSurveys", name: "DOB", newName: "datetime2");
            AddColumn("dbo.UserSurveys", "FirstName", c => c.String());
            AlterColumn("dbo.UserSurveys", "datetime2", c => c.DateTime(nullable: false));
            DropColumn("dbo.UserSurveys", "FirstNName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserSurveys", "FirstNName", c => c.String());
            AlterColumn("dbo.UserSurveys", "datetime2", c => c.String());
            DropColumn("dbo.UserSurveys", "FirstName");
            RenameColumn(table: "dbo.UserSurveys", name: "datetime2", newName: "DOB");
        }
    }
}
