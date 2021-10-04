using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.Model
{
    public class UserSurveyRegistration:EntityBase
    {
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string CPRNumber { get; set; }
        public DateTime DOB { get; set; }

        public int GenderId { get; set; }

        [ForeignKey("GenderId")]
        public UserGender Genders { get; set; }

    }
}
