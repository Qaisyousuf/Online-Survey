using OnlineSurvey.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace OnlineSurvey.ViewModel
{
    public class MultiLineTextViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Question title")]
        public string QuestionTitle { get; set; }
        [Required]
        [Display(Name ="Question")]
        public string Question { get; set; }

        [Display(Name ="Answer title")]
        public string Title { get; set; }

        
        [Display(Name ="Multi line answer")]
        public string MultiText { get; set; }

        public bool IsActive { get; set; }

        public List<Survey> Surveys { get; set; }
    }
}
