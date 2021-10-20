using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.ViewModel
{
    public class SurveyViewModel:BaseViewModel
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

        [Display(Name = "Select multiple choice question ")]
        public int[] SurveyIdForMultipleChoice { get; set; }


        public List<string> SurveyMutipleChoiceTag { get; set; }

        [ForeignKey("SurveyCatagoryId")]
        public SurveyCatagory SurveyCatagories { get; set; }

        public List<Question> MultipleChoiceQuestion { get; set; }
        

    }
}
