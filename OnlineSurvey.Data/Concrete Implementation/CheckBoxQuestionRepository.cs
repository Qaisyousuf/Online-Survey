using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class CheckBoxQuestionRepository:Repository<CheckBoxQuestions>,ICheckBoxQuestionRepository
    {
        public CheckBoxQuestionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
