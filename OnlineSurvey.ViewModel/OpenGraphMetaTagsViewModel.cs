using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.ViewModel
{
    public class OpenGraphMetaTagsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "OG meta tag name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "OG meta tag content")]
        public string Content { get; set; }
    }
}
