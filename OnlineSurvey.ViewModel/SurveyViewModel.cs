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
            MultiLineTextsQuestion = new List<MultiLineText>();
            YesNoQuestions = new List<YesNoQuestion>();
            CheckBoxQuestions = new List<CheckBoxQuestions>();
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


        [Display(Name = "Select Multiline text question")]
        public int[] MultiLineTextQuestionId { get; set; }

        public List<string> MultiLineTextQuestionTag { get; set; }

        public List<MultiLineText> MultiLineTextsQuestion { get; set; }

        [Display(Name = "Single Choice Questions")]
        public int[] YesNoQuestionId { get; set; }

        public List<string> YesNoQuestionName { get; set; }


        public List<YesNoQuestion> YesNoQuestions { get; set; }


        [Display(Name = "CheckBox Questions")]
        public int[] CheckBoxQuestionId { get; set; }

        public List<string> CheckBoxQuestionName { get; set; }
        public List<CheckBoxQuestions> CheckBoxQuestions { get; set; }
        

    }
}
