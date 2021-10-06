using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class MultipleChoiceQuestionsRepository:Repository<MultipleChoiceQuestions>,IMultipleChoiceQuestionsRepository
    {
        public MultipleChoiceQuestionsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
