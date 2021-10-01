using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.ViewModel
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public int SurveryId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
        public string Priority { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
    }
}
