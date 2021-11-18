using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.ViewModel
{
    public class EditCheckboxQuestionViewModel
    {
        public EditCheckboxQuestionViewModel()
        {
            CheckBoxItems = new List<CheckBoxItemForQuestionViewModel>();
            CheckBoxAnswers = new List<CheckBoxAnswers>();
        }
        public int Id { get; set; }

        public string Title { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Queston type checkbox")]
        public bool IsTypeCheckbox { get; set; }

        [Display(Name = "Queston type radio button")]
        public bool IsTypeRadioButton { get; set; }
        [Display(Name = "Multiple Choice ")]


        public List<CheckBoxAnswers> CheckBoxAnswers { get; set; }
        [Display(Name = "Answers")]
        public List<CheckBoxItemForQuestionViewModel> CheckBoxItems { get; set; }
    }
}
