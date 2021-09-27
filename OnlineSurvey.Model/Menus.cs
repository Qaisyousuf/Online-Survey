using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
    public class Menus:EntityBase
    {
      
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

      
    }
}
