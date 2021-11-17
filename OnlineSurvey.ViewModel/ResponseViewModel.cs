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
            MultiLineTextQuestion = new List<MultiLineText>();
            MultiLineTextResponse = new List<MultiLineTextResponse>();
            YesNoQuestions = new List<YesNoQuestion>();
            YesNoAnswers = new List<YesNoAnswer>();
            CheckBoxQuestions = new List<CheckBoxQuestions>();
            CheckBoxAnswers = new List<CheckBoxAnswers>();
        }
        public int Id { get; set; }

        public string Title { get; set; }
        public string Comment { get; set; }

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


        public int[] MultiLineTextQuestionId { get; set; }

        public List<string> MultiLineTextQuestionTag { get; set; }

        public List<MultiLineText> MultiLineTextQuestion { get; set; }

        public List<MultiLineTextResponse> MultiLineTextResponse { get; set; }


        public int[] SingleChoiceId { get; set; }
        public List<string> SingleChoiceQuestionName { get; set; }
        public List<YesNoQuestion> YesNoQuestions { get; set; }


        public int[] SingleChoiceAnswerId { get; set; }
        public List<string> SingleChoiceAnswerName { get; set; }
        public List<YesNoAnswer> YesNoAnswers { get; set; }

        public int[] CheckboxQuestionId { get; set; }
        public List<string> CheckBoxQuestionTagName { get; set; }
        public List<CheckBoxQuestions> CheckBoxQuestions { get; set; }

        public int[] CheckboxAnswerId { get; set; }
        public List<string> CheckBoxAnswerName { get; set; }
        public List<CheckBoxAnswers>  CheckBoxAnswers { get; set; }





    }
}
