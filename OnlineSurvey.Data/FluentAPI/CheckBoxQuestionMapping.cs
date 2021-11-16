using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.FluentAPI
{
    public class CheckBoxQuestionMapping:EntityTypeConfiguration<CheckBoxQuestions>
    {
        public CheckBoxQuestionMapping()
        {
            HasMany(x => x.CheckBoxAnswers)
                .WithMany(t => t.CheckBoxQuestions)
                .Map(xt =>
                {
                    xt.MapLeftKey("CheckBoxQuestionId");
                    xt.MapRightKey("CheckboxAnswerId");
                    xt.ToTable("CheckBoxQuestionsAndAnswers");
                });
        }
    }
}
