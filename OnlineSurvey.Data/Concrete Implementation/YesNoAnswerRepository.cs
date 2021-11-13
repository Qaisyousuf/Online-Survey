using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class YesNoAnswerRepository:Repository<YesNoAnswer>,IYesNoAnswerRepository
    {
        public YesNoAnswerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
