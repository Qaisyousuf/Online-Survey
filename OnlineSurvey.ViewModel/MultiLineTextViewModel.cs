using OnlineSurvey.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace OnlineSurvey.ViewModel
{
    public class MultiLineTextViewModel
    {
        public int Id { get; set; }

       
        [Display(Name ="Question title")]
        public string QuestionTitle { get; set; }
        
        [Display(Name ="Question")]
        public string Question { get; set; }


        public bool IsActive { get; set; }

        public List<Survey> Surveys { get; set; }

        public List<Response> Responses { get; set; }
    }
}
