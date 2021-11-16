using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.Model
{
    public class Survey:EntityBase
    {
        public Survey()
        {
            MultipleChoiceQuestion = new List<Question>();
            MultiLineTextsQuestion = new List<MultiLineText>();
            YesNoQuestions = new List<YesNoQuestion>();
            CheckBoxQuestions = new List<CheckBoxQuestions>();
        }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }

        public int SurveyCatagoryId { get; set; }

        [ForeignKey("SurveyCatagoryId")]
        public SurveyCatagory SurveyCatagories { get; set; }

        public List<Question> MultipleChoiceQuestion { get; set; }

        public List<MultiLineText> MultiLineTextsQuestion { get; set; }

        public List<YesNoQuestion> YesNoQuestions { get; set; }

        public List<CheckBoxQuestions> CheckBoxQuestions { get; set; }

       
    }
}
