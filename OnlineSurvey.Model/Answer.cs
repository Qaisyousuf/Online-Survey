using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.Model
{
    public class Answer:EntityBase
    {
        public string Value { get; set; }
        public string Comment { get; set; }
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Question Quesitons { get; set; }

       
    }

    
}
