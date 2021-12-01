using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
    public class MyProocedure:EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ProcedureName { get; set; }
        public bool IsActive { get; set; }
        public string NewSurveyLinks { get; set; }
      

       

    }
}
