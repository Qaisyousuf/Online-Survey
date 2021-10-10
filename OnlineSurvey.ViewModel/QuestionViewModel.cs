using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.ViewModel
{
   public class QuestionViewModel
    {
        public QuestionViewModel()
        {
            MultipleChoiceQuesion = new List<MultipleChoiceQuestions>();
            Surveys = new List<Survey>();
        }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }

        [Display(Name = "Multiple Choice ")]
        public int[] MultipleChoiceId { get; set; }

        public List<string> MultipleChoiceTag { get; set; }

        public List<MultipleChoiceQuestions> MultipleChoiceQuesion { get; set; }
        public List<Survey> Surveys { get; set; }
    }
}
