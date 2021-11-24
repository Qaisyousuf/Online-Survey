namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelchanged : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserComments", "datetime2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserComments", "datetime2", c => c.DateTime(nullable: false));
        }
    }
}
