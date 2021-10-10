using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineSurvey.Model;

using System.Data.Entity.ModelConfiguration;

namespace OnlineSurvey.Data.FluentAPI
{
    class MultipleChoiceQuestionMapping:EntityTypeConfiguration<Question>
    {
        public MultipleChoiceQuestionMapping()
        {
            HasMany(m => m.MultipleChoiceQuesion)
                .WithMany(q => q.Questions)
                .Map(cs =>
                {
                    cs.MapLeftKey("MultipleChoiceQuestionId");
                    cs.MapRightKey("QuestionId");
                    cs.ToTable("MutipleChoiceQuesionAndAnswer");
                    
                });
                
        }
    }
}
