namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatetimeModelAdded : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserComments", "datetime2");
        }
    }
}
