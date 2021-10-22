using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.ViewModel
{
    public class BannerViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name ="Sub title")]
        public string SubTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Button { get; set; }
        [Required]
        [Display(Name ="Button url")]
        public string ButtonUrl { get; set; }

        [Required]
        [Display(Name ="Animation url")]
        public string AnimationUrl { get; set; }
    }
}
