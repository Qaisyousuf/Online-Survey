namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class surveyModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        datetime2 = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        SurveyCatagoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyCatagories", t => t.SurveyCatagoryId, cascadeDelete: true)
                .Index(t => t.SurveyCatagoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Surveys", "SurveyCatagoryId", "dbo.SurveyCatagories");
            DropIndex("dbo.Surveys", new[] { "SurveyCatagoryId" });
            DropTable("dbo.Surveys");
        }
    }
}
