using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.Model
{
    public class UserProcedure:EntityBase
    {
      
        public string Name { get; set; }
        public string UserName { get; set; }
        public virtual ApplicationUser Users { get; set; }

        public int? MyProcedureId { get; set; }

        [ForeignKey("MyProcedureId")]
        public MyProocedure MyProocedure { get; set; }


    }
}
