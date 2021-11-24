using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.Model
{
    public class UserComment:EntityBase
    {
        public string Title { get; set; }
        public string Comment { get; set; }
        public string Replay { get; set; }
        public DateTime Posteddate { get; set; }


        public string UserName { get; set; }
       

        public string ReplayedUser { get; set; }

     
        public virtual ApplicationUser Users { get; set; }

    }
}
