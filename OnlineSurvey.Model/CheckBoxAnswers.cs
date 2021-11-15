using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
    public class CheckBoxAnswers:EntityBase
    {
        public string Title { get; set; }
        public string Answer { get; set; }
        public bool IsChecked { get; set; }

    }
}
