namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelPropetyRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProcedures", "MyProcedureId", "dbo.MyProocedures");
            DropIndex("dbo.UserProcedures", new[] { "MyProcedureId" });
            AlterColumn("dbo.UserProcedures", "MyProcedureId", c => c.Int());
            CreateIndex("dbo.UserProcedures", "MyProcedureId");
            AddForeignKey("dbo.UserProcedures", "MyProcedureId", "dbo.MyProocedures", "Id");
            DropColumn("dbo.UserProcedures", "Title");
            DropColumn("dbo.UserProcedures", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProcedures", "Content", c => c.String());
            AddColumn("dbo.UserProcedures", "Title", c => c.String());
            DropForeignKey("dbo.UserProcedures", "MyProcedureId", "dbo.MyProocedures");
            DropIndex("dbo.UserProcedures", new[] { "MyProcedureId" });
            AlterColumn("dbo.UserProcedures", "MyProcedureId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserProcedures", "MyProcedureId");
            AddForeignKey("dbo.UserProcedures", "MyProcedureId", "dbo.MyProocedures", "Id", cascadeDelete: true);
        }
    }
}
