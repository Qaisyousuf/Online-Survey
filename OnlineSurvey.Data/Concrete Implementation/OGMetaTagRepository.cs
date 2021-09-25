using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class OGMetaTagRepository:Repository<OpenGraphMetaTag>,IOGMetaTagRepository
    {
        public OGMetaTagRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
