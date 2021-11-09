namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MulitlineTextanswerModelAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MultiLineTexts", "MultiLineTextResponse_Id", "dbo.MultiLineTextResponses");
            DropIndex("dbo.MultiLineTexts", new[] { "MultiLineTextResponse_Id" });
            CreateTable(
                "dbo.MultiLineTextAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.MultiLineTexts", "MultiLineTextResponse_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MultiLineTexts", "MultiLineTextResponse_Id", c => c.Int());
            DropTable("dbo.MultiLineTextAnswers");
            CreateIndex("dbo.MultiLineTexts", "MultiLineTextResponse_Id");
            AddForeignKey("dbo.MultiLineTexts", "MultiLineTextResponse_Id", "dbo.MultiLineTextResponses", "Id");
        }
    }
}
