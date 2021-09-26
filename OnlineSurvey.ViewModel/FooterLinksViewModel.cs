using OnlineSurvey.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.ViewModel
{
    public class FooterLinksViewModel
    {
        public FooterLinksViewModel()
        {
            SiteSettings = new List<SiteSettings>();
        }
        public int Id { get; set; }
        [Required]
        [Display(Name ="Navigation name")]
        public string NavigationName { get; set; }

        [Required]
        [Display(Name ="Navigation url")]
        public string LinkUrl { get; set; }

        public List<SiteSettings> SiteSettings { get; set; }
    }
}
