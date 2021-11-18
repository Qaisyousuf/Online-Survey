namespace OnlineSurvey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckQuestionModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckBoxQuestions", "IsTypeCheckbox", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckBoxQuestions", "IsTypeRadioButton", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckBoxQuestions", "IsTypeRadioButton");
            DropColumn("dbo.CheckBoxQuestions", "IsTypeCheckbox");
        }
    }
}
