using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
    public class Banner:EntityBase
    {
        public string MainTitle { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public string Button { get; set; }
        public string ButtonUrl { get; set; }
        public string AnimationUrl { get; set; }   


    }
}
