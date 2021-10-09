using OnlineSurvey.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.ViewModel
{
    public class SurveyViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Survey name")]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }

        [Display(Name="Is active")]
        public bool IsActive { get; set; }

        public int SurveyCatagoryId { get; set; }

        [ForeignKey("SurveyCatagoryId")]
        public SurveyCatagory SurveyCatagories { get; set; }
    }
}
