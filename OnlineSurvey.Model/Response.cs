using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineSurvey.Model
{
    public class Response : EntityBase
    {
        public Response()
        {
            Questions = new List<Question>();
            MultipleChoiceQuestions = new List<MultipleChoiceQuestions>();
            MultiLineTextQuestion = new List<MultiLineText>();
            MultiLineTextResponses = new List<MultiLineTextResponse>();
            YesNoQuestions = new List<YesNoQuestion>();
            YesNoAnswers = new List<YesNoAnswer>();
        }

        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime ResponseDateTime { get; set; }

        public string UserName { get; set; }

        public int SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public Survey Surveies { get; set; }

        public int UserSurveyId { get; set; }
        [ForeignKey("UserSurveyId")]
        public UserSurveyRegistration UserSurveis { get; set; }

        public List<Question> Questions { get; set; }

        public List<MultipleChoiceQuestions> MultipleChoiceQuestions { get; set; }

        public List<MultiLineText> MultiLineTextQuestion { get; set; }

        public List<MultiLineTextResponse> MultiLineTextResponses { get; set; }

        public List<YesNoQuestion> YesNoQuestions { get; set; }

        public List<YesNoAnswer> YesNoAnswers { get; set; }

     




    }
}
