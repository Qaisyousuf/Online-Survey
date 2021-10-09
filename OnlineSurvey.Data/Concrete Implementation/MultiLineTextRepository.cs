using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class MultiLineTextRepository:Repository<MultiLineText>,IMultiLineTextRepository
    {
        public MultiLineTextRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
