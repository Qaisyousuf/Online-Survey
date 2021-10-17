using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
    public class MultipleChoiceQuestions:EntityBase
    {
        public MultipleChoiceQuestions()
        {
            Questions = new List<Question>();
            Responses = new List<Response>();
        }
        public string Title { get; set; }

        public string Answer { get; set; }
        public bool IsActive { get; set; }

        public List<Question> Questions { get; set; }
        public List<Response> Responses { get; set; }

    }
}
