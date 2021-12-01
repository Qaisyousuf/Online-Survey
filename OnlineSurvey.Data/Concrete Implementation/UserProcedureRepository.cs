using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class UserProcedureRepository:Repository<UserProcedure>,IUserProcedureRepository
    {
        public UserProcedureRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
