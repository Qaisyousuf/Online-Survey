using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.FluentAPI
{
    public class MultilLineTextMapping:EntityTypeConfiguration<MultiLineText>
    {
        public MultilLineTextMapping()
        {
            HasMany(x => x.MultiLineTextResponses)
                .WithMany(t => t.MultiLineTexts)
                .Map(mt =>
                {
                    mt.MapRightKey("MultilineTextResponseId");
                    mt.MapLeftKey("MultilineTextId");
                    mt.ToTable("MultilineTextAndMultilineResponse");
                });
        }
    }
}
