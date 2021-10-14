using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineSurvey.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute("Page", "{slug}", new { controller = "Home", action = "Index" }, new[] { "OnlineTrainingWeb.Controllers" });
            routes.MapRoute("Default", "", new { controller = "Home", action = "Index" }, new[] { "OnlineTrainingWeb.Controllers" });


            routes.MapRoute(
                name: "Old",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
