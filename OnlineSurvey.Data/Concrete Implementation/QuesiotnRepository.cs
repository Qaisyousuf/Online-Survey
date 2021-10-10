using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class QuesiotnRepository:Repository<Question>,IQuesiotnRepository
    {
        public QuesiotnRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
