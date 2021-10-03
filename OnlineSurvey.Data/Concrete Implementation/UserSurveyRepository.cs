using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class UserSurveyRepository:Repository<UserSurvey>,IUserSurveyRepository
    {
        public UserSurveyRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
