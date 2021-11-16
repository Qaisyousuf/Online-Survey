namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckBoxItemNameChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CheckBoxItems", "CheckBoxQuestions_Id", "dbo.CheckBoxQuestions");
            DropIndex("dbo.CheckBoxItems", new[] { "CheckBoxQuestions_Id" });
            DropTable("dbo.CheckBoxItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CheckBoxItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Checked = c.Boolean(nullable: false),
                        CheckBoxQuestions_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.CheckBoxItems", "CheckBoxQuestions_Id");
            AddForeignKey("dbo.CheckBoxItems", "CheckBoxQuestions_Id", "dbo.CheckBoxQuestions", "Id");
        }
    }
}
