using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using OnlineSurvey.Model;

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

        }
    }
}
