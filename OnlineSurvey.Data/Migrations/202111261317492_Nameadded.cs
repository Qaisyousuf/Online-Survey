namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nameadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserComments", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserComments", "Name");
        }
    }
}
