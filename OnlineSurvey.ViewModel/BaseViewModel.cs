using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.ViewModel
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            FooterLinks = new List<FooterLinks>();
        }

       
        [Display(Name = "Site title")]
        public string SiteTitle { get; set; }

       
        [Display(Name = "Site Name")]
        public string SiteName { get; set; }

       
        [Display(Name = "Site Owner")]
        public string SiteOwner { get; set; }
        public DateTime SiteLastUpdatedDate { get; set; }

        
        [Display(Name = "Site Content")]
        public string SiteContent { get; set; }

      
        [Display(Name = "Designed by")]
        public string DesignedBy { get; set; }

        
        [Display(Name = "Site copyright")]
        public string Sitecopyright { get; set; }

        
        [Display(Name = "Animation url")]
        public string AnimationUrl { get; set; }

        [Display(Name = "Is Active Site Footer")]
        public bool IsSiteFooterActive { get; set; }

        [Display(Name = "Footer Links")]
        public int[] FooterLinksId { get; set; }

        public List<string> FooterLinksTag { get; set; }

        public List<FooterLinks> FooterLinks { get; set; }
    }
}
