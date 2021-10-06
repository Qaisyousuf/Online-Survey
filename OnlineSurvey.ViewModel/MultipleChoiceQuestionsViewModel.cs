using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.ViewModel
{
    public class MultipleChoiceQuestionsViewModel
    {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Answer { get; set; }

        [Required]
        [Display(Name ="Is active")]
        public bool IsActive { get; set; }

    }
}
