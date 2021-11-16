using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.ViewModel
{
    public class CheckboxQuestionViewModel
    {
        public CheckboxQuestionViewModel()
        {
            CheckBoxAnswers = new List<CheckBoxAnswers>();
            CheckBoxItems = new List<CheckBoxItemForQuestionViewModel>();
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
    }
}
