using OnlineSurvey.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.ViewModel
{
    public class MultiLineTextViewModel
    {

        public MultiLineTextViewModel()
        {
            Surveys = new List<Survey>();
            Responses = new List<Response>();
         
        }
        public int Id { get; set; }

       
        [Display(Name ="Question title")]
        public string QuestionTitle { get; set; }
        
        [Display(Name ="Question")]
        public string Question { get; set; }


        public bool IsActive { get; set; }

        public List<Survey> Surveys { get; set; }

        public List<Response> Responses { get; set; }

        [Display(Name ="Multi line answer")]
        public int MultilineTextAnswerId { get; set; }

        [ForeignKey("MultilineTextAnswerId")]
        public MultiLineTextAnswer MultiLineTextAnswers { get; set; }


    }
}
