using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.ViewModel
{
    public class MetaTagViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Meta Tag Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Meta Tag Content")]
        public string Content { get; set; }
    }
}
