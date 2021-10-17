using OnlineSurvey.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.ViewModel
{
    public class PageViewModel:BaseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Slug { get; set; }

        [Required]
        public string Content { get; set; }

        [Display(Name ="Animation url")]
        public string AnimationUrlForPage { get; set; }

        [Display(Name ="Banner")]
        public int BannerId { get; set; }

        [ForeignKey("BannerId")]
        public Banner Banners { get; set; }

        [Display(Name ="Survey")]
        public int SurveyId { get; set; }

        [ForeignKey("SurveyId")]
        public Survey Surveies { get; set; }
    }
}
