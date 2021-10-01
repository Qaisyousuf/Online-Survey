using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
    public class Response : EntityBase
    {
        public int SurveyId { get; set; }
        public string Survey { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<Answer> Answers { get; set; }

        public int GetQuestionCount()
        {
            return Answers == null ? 0 : Answers.Count();
        }
       

       
    }
}
