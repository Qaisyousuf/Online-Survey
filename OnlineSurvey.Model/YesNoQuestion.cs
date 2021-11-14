using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.Model
{
    public class YesNoQuestion:EntityBase
    {
        public YesNoQuestion()
        {
            YesNoAnswers = new List<YesNoAnswer>();
            Surveys = new List<Survey>();
            Responses = new List<Response>();
        }
        public string Title { get; set; }
        public string Question { get; set; }
        public bool IsActive { get; set; }

        public List<YesNoAnswer> YesNoAnswers { get; set; }

        public List<Survey> Surveys { get; set; }
        public List<Response> Responses { get; set; }
    }
}
