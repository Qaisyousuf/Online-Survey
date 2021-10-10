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
        }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }

        public int SurveyCatagoryId { get; set; }

        [ForeignKey("SurveyCatagoryId")]
        public SurveyCatagory SurveyCatagories { get; set; }

        public List<Question> MultipleChoiceQuestion { get; set; }

    }
}
