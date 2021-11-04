using System.Collections.Generic;

namespace OnlineSurvey.Model
{
    public class MultiLineText:EntityBase
    {
        public MultiLineText()
        {
            Surveys = new List<Survey>();
        }
        public string QuestionTitle { get; set; }
        public string Question { get; set; }

        public string Title { get; set; }

        public string  MultiText { get; set; }

        public bool IsActive { get; set; }

        public List<Survey> Surveys { get; set; }


    }
}
