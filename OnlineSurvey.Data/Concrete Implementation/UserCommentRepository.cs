using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class UserCommentRepository:Repository<UserComment>,IUserCommentRepository
    {
        public UserCommentRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
