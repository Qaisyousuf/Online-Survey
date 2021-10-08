using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class NumberQuestionRepository:Repository<NumberQuestion>,INumberQuestionRepository
    {
        public NumberQuestionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
