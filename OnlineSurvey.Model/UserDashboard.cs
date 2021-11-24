using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.Model
{
    public class UserDashboard : EntityBase
    {
        public string Title { get; set; }
        public string MainTitle { get; set; }
        public string AnimationUrl { get; set; }
        public string Content { get; set; }

        public virtual ApplicationUser Users { get; set; }
    }
}
