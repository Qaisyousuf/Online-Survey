using OnlineSurvey.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.ViewModel
{
    public class UserProcedureViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public virtual ApplicationUser Users { get; set; }

        public int? MyProcedureId { get; set; }

        [ForeignKey("MyProcedureId")]
        public MyProocedure MyProocedure { get; set; }
    }
}
