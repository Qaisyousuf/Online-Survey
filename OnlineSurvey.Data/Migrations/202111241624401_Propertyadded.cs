namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Propertyadded : DbMigration
    {
        public override void Up()
        {
         
        }
        
        public override void Down()
        {
           
            DropColumn("dbo.UserComments", "ReplayedDate");
            DropColumn("dbo.UserComments", "PostedDate");
        }
    }
}
