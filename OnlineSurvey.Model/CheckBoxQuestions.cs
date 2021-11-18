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
            Surveys = new List<Survey>();
            Responses = new List<Response>();
        }
        public string Title { get; set; }
        public string Question { get; set; }
        public bool IsActive { get; set; }
        public bool IsTypeCheckbox { get; set; }
        public bool IsTypeRadioButton { get; set; }

        public List<CheckBoxAnswers> CheckBoxAnswers { get; set; }

        public List<Survey> Surveys { get; set; }

        public List<Response> Responses { get; set; }

      
    }
}
