using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class TagQuestionRepository:Repository<TagQuestion>,ITagQuestionRepository
    {
        public TagQuestionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
