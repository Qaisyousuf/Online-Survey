using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
    public class CheckBoxAnswers:EntityBase
    {
        public CheckBoxAnswers()
        {
            CheckBoxQuestions = new List<CheckBoxQuestions>();
            Responses = new List<Response>();
        }
       
        public string Title { get; set; }
        public string Answer { get; set; }
        public bool IsChecked { get; set; }

        public List<CheckBoxQuestions> CheckBoxQuestions { get; set; }

        public List<Response> Responses { get; set; }
       
    }
}
