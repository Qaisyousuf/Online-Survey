using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineSurvey.Web.Startup))]
namespace OnlineSurvey.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
