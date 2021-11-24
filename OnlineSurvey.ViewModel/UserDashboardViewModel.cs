using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.ViewModel
{
    public class UserDashboardViewModel
    {
        
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Main title")]
        public string MainTitle { get; set; }


        [Required]
        [Display(Name ="Animation url")]
        public string AnimationUrl { get; set; }

        [Required]
        public string Content { get; set; }

        public virtual ApplicationUser Users { get; set; }
    }
}
