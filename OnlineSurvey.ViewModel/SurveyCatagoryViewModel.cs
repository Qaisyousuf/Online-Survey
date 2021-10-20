using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.ViewModel
{
    public class SurveyCatagoryViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Survey title")]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Survey type")]
        public string Type { get; set; }

        [Required]
        [Display(Name ="Survey content")]
        public string Content { get; set; }
    }
}
