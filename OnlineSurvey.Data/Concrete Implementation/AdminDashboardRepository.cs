using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class AdminDashboardRepository:Repository<AdminDashboard>,IAdminDashboardRepository
    {
        public AdminDashboardRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
