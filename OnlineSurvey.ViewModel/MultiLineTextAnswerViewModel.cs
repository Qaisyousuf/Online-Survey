using OnlineSurvey.Model;
using System.Collections.Generic;

namespace OnlineSurvey.ViewModel
{
    public class MultiLineTextAnswerViewModel
    {
        public MultiLineTextAnswerViewModel()
        {
            MultiLineTexts = new List<MultiLineText>();
        }
        public int Id { get; set; }
        public string MainTitle { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }

        public List<MultiLineText> MultiLineTexts { get; set; }
    }
}
