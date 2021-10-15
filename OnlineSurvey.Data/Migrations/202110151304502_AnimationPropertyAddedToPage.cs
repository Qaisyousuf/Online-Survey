namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimationPropertyAddedToPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "AnimationUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "AnimationUrl");
        }
    }
}
