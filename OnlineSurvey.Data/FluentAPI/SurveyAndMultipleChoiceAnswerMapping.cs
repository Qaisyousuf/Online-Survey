using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.FluentAPI
{
    class SurveyAndMultipleChoiceAnswerMapping:EntityTypeConfiguration<Survey>
    {
        public SurveyAndMultipleChoiceAnswerMapping()
        {
            HasMany(x => x.MultipleChoiceQuestion)
                .WithMany(s => s.Surveys)
                .Map(cs =>
                {
                    cs.MapLeftKey("SurveyId");
                    cs.MapRightKey("QuestionId");
                    cs.ToTable("SurveyMultipleChoiceQuestion");
                });
            HasMany(m => m.MultiLineTextsQuestion)
                .WithMany(m => m.Surveys)
                .Map(tm =>
                {
                    tm.MapLeftKey("SurveyId");
                    tm.MapRightKey("MultiLineTextQuestionId");
                    tm.ToTable("SurveyMultiLineTextQuestion");
                });
            HasMany(s => s.YesNoQuestions)
                .WithMany(r => r.Surveys)
                .Map(sr =>
                {
                    sr.MapLeftKey("SurveyId");
                    sr.MapRightKey("SingleChoiceId");
                    sr.ToTable("SurveyAndSingleChoice");
                });
            HasMany(s => s.CheckBoxQuestions)
              .WithMany(r => r.Surveys)
              .Map(sr =>
              {
                  sr.MapLeftKey("SurveyId");
                  sr.MapRightKey("CheckBoxQuestionId");
                  sr.ToTable("SurveyAndCheckBoxQuestion");
              });

        }
    }
}
