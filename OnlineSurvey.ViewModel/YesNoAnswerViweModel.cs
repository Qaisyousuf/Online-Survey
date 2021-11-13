using OnlineSurvey.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.ViewModel
{
    public class YesNoAnswerViweModel
    {
        public YesNoAnswerViweModel()
        {
            YesNoQuestions = new List<YesNoQuestion>();
        }
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required]
        [Display(Name ="Is active")]
        public bool IsActive { get; set; }

        public List<YesNoQuestion> YesNoQuestions { get; set; }
    }
}
