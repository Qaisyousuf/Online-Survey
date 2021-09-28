using OnlineSurvey.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.ViewModel
{
    public class PageViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Slug { get; set; }

        [Required]
        public string Content { get; set; }


        [Display(Name ="Banner")]
        public int BannerId { get; set; }

        [ForeignKey("BannerId")]
        public Banner Banners { get; set; }
    }
}
