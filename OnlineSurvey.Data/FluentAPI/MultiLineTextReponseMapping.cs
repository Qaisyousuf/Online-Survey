using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.FluentAPI
{
    public class MultiLineTextReponseMapping:EntityTypeConfiguration<MultiLineTextResponse>
    {
        public MultiLineTextReponseMapping()
        {
            HasMany(m => m.MultiLineTexts)
                .WithMany(t => t.MultiLineTextResponses)
                .Map(mt =>
                {
                    mt.MapLeftKey("MultiLineTextResonseId");
                    mt.MapRightKey("MultiLineTextId");
                    mt.ToTable("MultiLineTextQuestionAndAnswer");
                });

               
               
        }
    }
}
