using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.ViewModel
{
    public class MultiLineTextViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name ="Multi line text")]
        public string MultiText { get; set; }
    }
}
