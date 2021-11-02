using System.Collections.Generic;

namespace OnlineSurvey.Model
{
    public class ResponseBody:EntityBase
    {
        public ResponseBody()
        {
            Responses = new List<Response>();
        }
        public string Title { get; set; }
        public string Body { get; set; }

        public List<Response> Responses { get; set; }
    }
}
