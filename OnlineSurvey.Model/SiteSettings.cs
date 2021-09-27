using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
    public class SiteSettings:EntityBase
    {
        public SiteSettings()
        {
            FooterLinks = new List<FooterLinks>();
        }
        public string SiteTitle { get; set; }

        public string SiteName { get; set; }

        public string SiteOwner { get; set; }

        public DateTime SiteLastUpdatedDate { get; set; }

        public string SiteContent { get; set; }

        public string DesignedBy { get; set; }

        public string Sitecopyright { get; set; }
        
        public bool IsSiteFooterActive { get; set; }

        public string AnimationUrl { get; set; }

        public List<FooterLinks> FooterLinks { get; set; }
    }
}
