using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.FluentAPI
{
    public class SiteSettingMapping:EntityTypeConfiguration<SiteSettings>
    {
        public SiteSettingMapping()
        {
            HasMany(x => x.FooterLinks)
                .WithMany(s => s.SiteSettings)
                .Map(xs =>
                {
                    xs.MapLeftKey("FooterLinksId");
                    xs.MapRightKey("SiteSettingId");
                    xs.ToTable("SiteSettingFooterLinks");
                });
        }
    }
}
