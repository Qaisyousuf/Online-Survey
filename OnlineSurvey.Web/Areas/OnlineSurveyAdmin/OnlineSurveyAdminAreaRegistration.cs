using System.Web.Mvc;

namespace OnlineSurvey.Web.Areas.OnlineSurveyAdmin
{
    
    public class OnlineSurveyAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "OnlineSurveyAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OnlineSurveyAdmin_default",
                "OnlineSurveyAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}