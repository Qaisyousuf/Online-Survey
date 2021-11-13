using System.Collections.Generic;

namespace OnlineSurvey.Model
{
    public class MultiLineTextResponse:EntityBase
    {
        public MultiLineTextResponse()
        {
            Responses = new List<Response>();
            MultiLineTexts = new List<MultiLineText>();

        }
       
        public string Title { get; set; }
        public string MulitLine { get; set; }

        public List<Response> Responses { get; set; }

        public List<MultiLineText> MultiLineTexts { get; set; }
       

    }
}
