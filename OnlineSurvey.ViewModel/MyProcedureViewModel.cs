using OnlineSurvey.Model;
using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.ViewModel
{
    public class MyProcedureViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name="Procedure statues name")]
        public string ProcedureName { get; set; }


        public bool IsActive { get; set; }


        [Display(Name = "New survey")]
        public string NewSurveyLinks { get; set; }
        
    }
}
