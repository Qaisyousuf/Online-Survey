using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class SurveyRepository:Repository<Survey>,ISurveyRepository
    {
        public SurveyRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
