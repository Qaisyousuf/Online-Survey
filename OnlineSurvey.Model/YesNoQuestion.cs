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
        }
        public string Title { get; set; }
        public string Question { get; set; }
        public bool IsActive { get; set; }

        public List<YesNoAnswer> YesNoAnswers { get; set; }


    }
}
