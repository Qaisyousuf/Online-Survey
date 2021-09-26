using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.ViewModel
{
    public class SiteSettingViewModel
    {
        public SiteSettingViewModel()
        {
            FooterLinks = new List<FooterLinks>();
        }
        public int Id { get; set; }

        [Required]
        [Display(Name ="Site title")]
        public string SiteTitle { get; set; }

        [Required]
        [Display(Name ="Site Name")]
        public string SiteName { get; set; }

        [Required]
        [Display(Name ="Site Owner")]
        public string SiteOwner { get; set; }
        public DateTime SiteLastUpdatedDate { get; set; }

        [Required]
        [Display(Name ="Site Content")]
        public string SiteContent { get; set; }

        [Required]
        [Display(Name ="Designed by")]
        public string DesignedBy { get; set; }

        [Required]
        [Display(Name ="Site copyright")]
        public string Sitecopyright { get; set; }

        [Required]
        [Display(Name ="Animation url")]
        public string AnimationUrl { get; set; }

        public List<FooterLinks> FooterLinks { get; set; }
    }
}
