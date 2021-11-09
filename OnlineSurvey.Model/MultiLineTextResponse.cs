﻿using System.Collections.Generic;

namespace OnlineSurvey.Model
{
    public class MultiLineTextResponse:EntityBase
    {
        public MultiLineTextResponse()
        {
            Responses = new List<Response>();
           
        }
       
        public string Title { get; set; }
        public string MulitLine { get; set; }

        public List<Response> Responses { get; set; }
       

    }
}
