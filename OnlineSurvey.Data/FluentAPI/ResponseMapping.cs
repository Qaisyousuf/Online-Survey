using OnlineSurvey.Model;
using System.Data.Entity.ModelConfiguration;

namespace OnlineSurvey.Data.FluentAPI
{
    class ResponseMapping:EntityTypeConfiguration<Response>
    {
        public ResponseMapping()
        {
            HasMany(m => m.Questions)
                 .WithMany(r=>r.Responses)
                 .Map(cs =>
                 {
                     cs.MapLeftKey("ResponseId");
                     cs.MapRightKey("QuestionId");
                     cs.ToTable("ReponseQuestion");

                 });
            HasMany(m => m.MultipleChoiceQuestions)
                .WithMany(s => s.Responses)
                .Map(rm =>
                {
                    rm.MapLeftKey("ResponseId");
                    rm.MapRightKey("MultipleChoiceId");
                    rm.ToTable("ReponseMultipleChoice");
                });
          
            HasMany(j => j.MultiLineTextQuestion)
                .WithMany(g => g.Responses)
                .Map(jg =>
                {
                    jg.MapLeftKey("responseId");
                    jg.MapRightKey("MultiLineQuestion");
                    jg.ToTable("ResponseAndMultiLineQuestion");
                });
            HasMany(p => p.MultiLineTextResponses)
                .WithMany(t => t.Responses)
                .Map(pt =>
                {
                    pt.MapLeftKey("ResponseId");
                    pt.MapRightKey("MultiLineResponse");
                    pt.ToTable("ResponseAndMultiLineTextResponse");
                });
            HasMany(x => x.YesNoQuestions)
                .WithMany(t => t.Responses)
                .Map(xt =>
                {
                    xt.MapLeftKey("ResponseId");
                    xt.MapRightKey("SingleChoiceQuestionId");
                    xt.ToTable("ResponseAndSingleChoiceQuestion");
                });
            HasMany(x => x.YesNoAnswers)
               .WithMany(p => p.Responses)
               .Map(xt =>
               {
                   xt.MapLeftKey("ResponseId");
                   xt.MapRightKey("SingleChoiceAnswerId");
                   xt.ToTable("ResponseAndSingleChoiceAnswer");
               });



        }
    }
}
