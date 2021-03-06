using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.Model
{
    public class MultiLineText:EntityBase
    {
        public MultiLineText()
        {
            Surveys = new List<Survey>();
            Responses = new List<Response>();
            MultiLineTextResponses = new List<MultiLineTextResponse>();

        }
        public string QuestionTitle { get; set; }
        public string Question { get; set; }

        public bool IsActive { get; set; }

        public List<Survey> Surveys { get; set; }

        public List<Response> Responses { get; set; }



        public List<MultiLineTextResponse>  MultiLineTextResponses { get; set; }


    }
}
