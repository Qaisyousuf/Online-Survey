using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class SiteSettingsRepository:Repository<SiteSettings>,ISiteSettingsRepository
    {
        public SiteSettingsRepository(ApplicationDbContext context):base(context)
        {

        }
        
    }
}
