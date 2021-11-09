using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class MultiLineTextAnswerRepository:Repository<MultiLineTextAnswer>,IMultiLineTextAnswerRepository
    {
        public MultiLineTextAnswerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
