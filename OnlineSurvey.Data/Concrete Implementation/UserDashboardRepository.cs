using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class UserDashboardRepository:Repository<UserDashboard>,IUserDashboardRepository
    {
        public UserDashboardRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
