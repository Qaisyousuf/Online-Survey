using OnlineSurvey.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.ViewModel
{
    public class CheckboxAnswerViewModel
    {
        public CheckboxAnswerViewModel()
        {
            CheckBoxQuestions = new List<CheckBoxQuestions>();
        }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Answer { get; set; }

        [Display(Name ="Is Checked")]
        public bool IsChecked { get; set; }

        public List<CheckBoxQuestions> CheckBoxQuestions { get; set; }

        public List<CheckBoxAnswers> CheckBoxAnswers { get; set; }

    }
}
