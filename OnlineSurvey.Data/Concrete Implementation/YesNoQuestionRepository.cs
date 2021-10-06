using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class YesNoQuestionRepository:Repository<YesNoQuestion>,IYesNoQuestionRepository
    {
        public YesNoQuestionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
