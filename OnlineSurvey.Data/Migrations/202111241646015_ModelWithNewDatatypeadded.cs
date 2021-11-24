namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelWithNewDatatypeadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserComments", "datetime2", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserComments", "datetime2");
        }
    }
}
