using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
    public class YesNoAnswer:EntityBase
    {
        public YesNoAnswer()
        {
            YesNoQuestions = new List<YesNoQuestion>();
        }
        public string Title { get; set; }
        public string Answer { get; set; }
        public bool IsActive { get; set; }

        public List<YesNoQuestion> YesNoQuestions { get; set; }
    }
}
