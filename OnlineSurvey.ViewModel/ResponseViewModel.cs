using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.ViewModel
{
    public class ResponseViewModel
    {
        public ResponseViewModel()
        {
            Questions = new List<Question>();
            MultipleChoiceQuestions = new List<MultipleChoiceQuestions>();
            ResponseBodies = new List<ResponseBody>();
        }
        public int Id { get; set; }
      
      

        [Display(Name ="Survey")]
        public int SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public Survey Surveies { get; set; }
        [Display(Name ="UserName")]
        public string UserName { get; set; }
        [Display(Name ="User Survey")]
        public int UserSurveyId { get; set; }
        [ForeignKey("UserSurveyId")]
        public UserSurveyRegistration UserSurveis { get; set; }

        public int[] MultipleChoiceId { get; set; }

        public List<string> MultipleChoiceTag { get; set; }

        public int[] MutipleQuestionId { get; set; }

        public List<string> MultipleQuestionTag { get; set; }

        [Display(Name ="Response Date Time")]
        [DataType(DataType.DateTime)]
        public DateTime ResponseDateTime { get; set; }

        public List<Question> Questions { get; set; }

        public List<MultipleChoiceQuestions> MultipleChoiceQuestions { get; set; }
        public List<ResponseBody> ResponseBodies { get; set; }
    }
}
