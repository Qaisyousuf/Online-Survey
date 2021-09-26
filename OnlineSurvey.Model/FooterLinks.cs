using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
   public class FooterLinks:EntityBase
    {
        public FooterLinks()
        {
            SiteSettings = new List<SiteSettings>();
        }
        public string NavigationName { get; set; }
        public string LinkUrl { get; set; }

        public List<SiteSettings> SiteSettings { get; set; }
    }
}
