namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReponseModelAdded : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Responses", "SurveyCatagoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Responses", "SurveyCatagoryId");
            AddForeignKey("dbo.Responses", "SurveyCatagoryId", "dbo.SurveyCatagories", "Id", cascadeDelete: true);
        }
    }
}
