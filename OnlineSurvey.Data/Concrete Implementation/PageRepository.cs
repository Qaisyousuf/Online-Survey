using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;
using System.Linq;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class PageRepository:Repository<Page>,IPageRepository
    {
        public PageRepository(ApplicationDbContext context):base(context)
        {

        }

        public Page GetPageBySlug(string slug) => _context.Pages.Where(x => x.Slug == slug).SingleOrDefault();
      

        public bool SlugExists(string slug) => _context.Pages.Any(x => x.Slug == slug);


        public bool SlugExists(int? id, string slug) => _context.Pages.Where(x => x.Id != id).Any(x => x.Id == id);
       
    }
}
