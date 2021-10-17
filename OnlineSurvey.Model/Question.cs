using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
    public class Question:EntityBase
    {
        public Question()
        {
            MultipleChoiceQuesion = new List<MultipleChoiceQuestions>();
            Surveys = new List<Survey>();
            Responses = new List<Response>();
        }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }


        public List<MultipleChoiceQuestions> MultipleChoiceQuesion { get; set; }
        public List<Survey> Surveys { get; set; }
        public List<Response> Responses { get; set; }

    }
}
