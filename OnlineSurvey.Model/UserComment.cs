using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OnlineSurvey.Model
{
    public class UserComment:EntityBase
    {
        public string Title { get; set; }
        
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
        public string Replay { get; set; }

        public DateTime Posteddate { get; set; }


        public string UserName { get; set; }
       

        public string ReplayedUser { get; set; }

     
        public virtual ApplicationUser Users { get; set; }

    }
}
