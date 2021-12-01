namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyProcedureModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyProocedures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        ProcedureName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        NewSurveyLinks = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyProocedures");
        }
    }
}
