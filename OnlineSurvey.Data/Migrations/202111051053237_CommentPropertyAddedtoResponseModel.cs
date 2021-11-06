namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentPropertyAddedtoResponseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Responses", "Title", c => c.String());
            AddColumn("dbo.Responses", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Responses", "Comment");
            DropColumn("dbo.Responses", "Title");
        }
    }
}
