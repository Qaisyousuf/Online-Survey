using OnlineSurvey.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.ViewModel
{
    public class CheckboxQuestionViewModel
    {
        public CheckboxQuestionViewModel()
        {
            CheckBoxAnswers = new List<CheckBoxAnswers>();
            CheckBoxItems = new List<CheckBoxItemForQuestionViewModel>();
            Surveys = new List<Survey>();
            Responses = new List<Response>();
        }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        [Display(Name ="Is Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Multiple Choice ")]
       


        public List<CheckBoxAnswers> CheckBoxAnswers { get; set; }
        [Display(Name ="Answers")]
        public List<CheckBoxItemForQuestionViewModel> CheckBoxItems { get; set; } 

        public List<Survey> Surveys { get; set; }

        public List<Response> Responses { get; set; }
    }
}
