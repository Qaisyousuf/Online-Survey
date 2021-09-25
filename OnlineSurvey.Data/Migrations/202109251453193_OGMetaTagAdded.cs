namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OGMetaTagAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OpenGraphMetaTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OpenGraphMetaTags");
        }
    }
}
