using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.ViewModel
{
    public class ResponseViewModel
    {
        public ResponseViewModel()
        {
            Questions = new List<Question>();
            MultipleChoiceQuestions = new List<MultipleChoiceQuestions>();
        }
        public int Id { get; set; }
      
        public string Title { get; set; }
        public string Body { get; set; }


        [Display(Name ="Survey")]
        public int SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public Survey Surveies { get; set; }

        [Display(Name ="User Survey")]
        public int UserSurveyId { get; set; }
        [ForeignKey("UserSurveyId")]
        public UserSurveyRegistration UserSurveis { get; set; }

        public List<Question> Questions { get; set; }

        public List<MultipleChoiceQuestions> MultipleChoiceQuestions { get; set; }
    }
}
