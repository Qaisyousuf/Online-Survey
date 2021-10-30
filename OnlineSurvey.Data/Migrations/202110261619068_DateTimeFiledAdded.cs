namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeFiledAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Responses", "datetime2", c => c.DateTime(nullable: false));
            AddColumn("dbo.Responses", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Responses", "UserName");
            DropColumn("dbo.Responses", "datetime2");
        }
    }
}
