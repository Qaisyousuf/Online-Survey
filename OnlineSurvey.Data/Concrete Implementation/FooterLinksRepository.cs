using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class FooterLinksRepository:Repository<FooterLinks>,IFooterLinksRepository
    {
        public FooterLinksRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
