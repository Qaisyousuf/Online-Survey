using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.ViewModel
{
    public class SurveyViewModel
    {
        public SurveyViewModel()
        {
            MultipleChoiceQuestion = new List<Question>();
        }
        public int Id { get; set; }

        [Required]
        [Display(Name ="Survey name")]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }

        [Display(Name="Is active")]
        public bool IsActive { get; set; }

        public int SurveyCatagoryId { get; set; }

        [Display(Name = "Multiple Choice ")]
        public int[] SurveyIdForMultipleChoice { get; set; }


        public List<string> MultipleChoiceTag { get; set; }

        [ForeignKey("SurveyCatagoryId")]
        public SurveyCatagory SurveyCatagories { get; set; }

        public List<Question> MultipleChoiceQuestion { get; set; }
    }
}
