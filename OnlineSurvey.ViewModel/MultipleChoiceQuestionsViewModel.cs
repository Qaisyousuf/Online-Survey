using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using OnlineSurvey.Model;

namespace OnlineSurvey.ViewModel
{
    public class MultipleChoiceQuestionsViewModel
    {
        public MultipleChoiceQuestionsViewModel()
        {
            Questions = new List<Question>();
        }

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Answer { get; set; }

        [Required]
        [Display(Name ="Is active")]
        public bool IsActive { get; set; }

        public List<Question> Questions { get; set; }

    }
}
