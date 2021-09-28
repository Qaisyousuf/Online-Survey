using OnlineSurvey.Model;

namespace OnlineSurvey.Data.Interfaces
{
    public interface IPageRepository:IRepository<Page>,ISlug
    {
        Page GetPageBySlug(string slug);
    }
}
