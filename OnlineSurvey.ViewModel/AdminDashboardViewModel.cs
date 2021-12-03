using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.ViewModel
{
    public class AdminDashboardViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Required]
        public string Animaiton { get; set; }
        [Required]
        [Display(Name ="Designed by")]
        public string DesignedByCompany { get; set; }


    }
}
