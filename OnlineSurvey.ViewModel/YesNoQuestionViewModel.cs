using OnlineSurvey.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.ViewModel
{
    public class YesNoQuestionViewModel
    {
        public YesNoQuestionViewModel()
        {
            YesNoAnswers = new List<YesNoAnswer>();
            Surveys = new List<Survey>();
        }
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Question { get; set; }
        public bool IsActive { get; set; }

        [Display(Name = "Select single choice answer")]
        public int[] YesNoAnswerId { get; set; }

        public List<string> YesNoAnswerName { get; set; }

        public List<YesNoAnswer> YesNoAnswers {get;set; }

        public List<Survey> Surveys { get; set; }

    }
}
