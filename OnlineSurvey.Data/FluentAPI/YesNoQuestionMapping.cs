using OnlineSurvey.Model;
using System.Data.Entity.ModelConfiguration;

namespace OnlineSurvey.Data.FluentAPI
{
    public class YesNoQuestionMapping:EntityTypeConfiguration<YesNoQuestion>
    {
        public YesNoQuestionMapping()
        {
            HasMany(x => x.YesNoAnswers)
                .WithMany(m => m.YesNoQuestions)
                .Map(xm =>
                {
                    xm.MapLeftKey("YesNoQuestionId");
                    xm.MapRightKey("YesNoAnswerId");
                    xm.ToTable("YesNoQuestionAndAnswer");
                });
            
        }
    }
}
