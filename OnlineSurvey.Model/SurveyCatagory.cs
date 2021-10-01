using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
    public class SurveyCatagory:EntityBase
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        

    }
}
