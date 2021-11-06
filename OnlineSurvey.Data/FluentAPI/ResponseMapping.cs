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
            HasMany(a => a.MultiLineTextResponses)
                .WithMany(p => p.Responses)
                .Map(ap =>
                {
                    ap.MapLeftKey("ResponseId");
                    ap.MapRightKey("MultiLinTextResponse");
                    ap.ToTable("ReponseMultlinTextResponse");
                });


        }
    }
}
