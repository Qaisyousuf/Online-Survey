using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
    public class CheckBoxQuestions:EntityBase
    {
        public CheckBoxQuestions()
        {
            CheckBoxAnswers = new List<CheckBoxAnswers>();
           
        }
        public string Title { get; set; }
        public string Question { get; set; }
        public bool IsActive { get; set; }

        public List<CheckBoxAnswers> CheckBoxAnswers { get; set; }

      
    }
}
