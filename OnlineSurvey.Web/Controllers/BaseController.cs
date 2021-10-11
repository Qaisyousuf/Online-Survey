using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.ViewModel;
using System.Linq;
using Unity;
using System.Web.Mvc;


namespace OnlineSurvey.Web.Controllers
{
    public class BaseController : Controller
    {
        [Dependency]
        public IUnitOfWork _uow { get; set; }
        public BaseController()
        {

        }
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            ViewResult restul = filterContext.Result as ViewResult;

            if(restul !=null)
            {
                BaseViewModel baseviewmodel = ViewData.Model as BaseViewModel;
                if(baseviewmodel !=null)
                {
                    var footerId = _uow.Context.FooterLinks.Select(x => x.Id).ToList();

                    var footerTag = _uow.Context.FooterLinks.Where(x => footerId.Contains(x.Id)).Select(x => x.NavigationName).ToList();

                    var site = _uow.Context.SiteSettings.FirstOrDefault();

                    var siteSettings = _uow.Context.SiteSettings.Include("FooterLinks").FirstOrDefault();

                    baseviewmodel.SiteTitle = siteSettings.SiteTitle;
                    baseviewmodel.SiteName = siteSettings.SiteName;
                    baseviewmodel.SiteOwner = siteSettings.SiteOwner;
                    baseviewmodel.SiteLastUpdatedDate = siteSettings.SiteLastUpdatedDate;
                    baseviewmodel.SiteContent = siteSettings.SiteContent;
                    baseviewmodel.DesignedBy = siteSettings.DesignedBy;
                    baseviewmodel.Sitecopyright = siteSettings.Sitecopyright;
                    baseviewmodel.AnimationUrl = siteSettings.AnimationUrl;
                    baseviewmodel.IsSiteFooterActive = siteSettings.IsSiteFooterActive;
                   

                    int[] footerLinksId = siteSettings.FooterLinks.Select(x => x.Id).ToArray();

                    baseviewmodel.FooterLinksId = footerLinksId;
                    baseviewmodel.FooterLinks = siteSettings.FooterLinks;

                    baseviewmodel.FooterLinksTag = footerTag;
                }
            }
        }
    }
}