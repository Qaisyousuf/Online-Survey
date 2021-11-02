using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class ResponseBodyRepository:Repository<ResponseBody>, IResponseBodyRepository
    {
        public ResponseBodyRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
