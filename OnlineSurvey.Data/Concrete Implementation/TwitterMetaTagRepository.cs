using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class TwitterMetaTagRepository:Repository<TwitterMetaTag>,ITwitterMetaTagRepository
    {
        public TwitterMetaTagRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
