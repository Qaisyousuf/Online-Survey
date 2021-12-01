using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class MyProcedureRepository:Repository<MyProocedure>,IMyProcedureRepository
    {
        public MyProcedureRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
