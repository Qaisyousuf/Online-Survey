using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    class MetaTagRepository:Repository<MetaTag>,IMetaTagRepository
    {
        public MetaTagRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
