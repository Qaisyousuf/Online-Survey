namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultiLineTextModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MultiLineTexts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        MultiText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MultiLineTexts");
        }
    }
}
