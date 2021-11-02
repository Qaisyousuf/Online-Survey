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
            ResponseBodies = new List<ResponseBody>();
        }
      

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

        public List<ResponseBody> ResponseBodies { get; set; }


    }
}
