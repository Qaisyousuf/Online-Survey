using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class SurveyCatagoryRepository:Repository<SurveyCatagory>,ISurveyCatagoryRepository
    {
        public SurveyCatagoryRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
