namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YesNoQuestionAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.YesNoQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Answer = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.YesNoQuestions");
        }
    }
}
