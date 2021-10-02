using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.ViewModel
{
    public class GenderViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Gender Type")]
        public string Name { get; set; }
        [Display(Name="Is Checked")]
        public bool IsSelected { get; set; }
    }
}
