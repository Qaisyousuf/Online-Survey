using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.ViewModel
{
    public class TwitterMetaTagViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tag Name or property")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Tag Content")]
        public string Content { get; set; }
    }
}
