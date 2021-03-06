using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineSurvey.ViewModel
{
    public class UserCommentViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        [AllowHtml]
        public string Comment { get; set; }
        public string Replay { get; set; }

        [Display(Name ="Posted date")]
        public DateTime PostedDate { get; set; }
       
        public string UserName { get; set; }
      
        [Display(Name="Replayed user")]
        public string ReplayedUser { get; set; }

        public string Name { get; set; }


        public virtual ApplicationUser Users { get; set; }
    }
}
