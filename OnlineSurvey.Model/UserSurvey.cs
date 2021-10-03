using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
    public class UserSurvey:EntityBase
    {
        public UserSurvey()
        {
            Genders = new List<Gender>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string CPRNumber { get; set; }
        public DateTime DOB { get; set; }
        public string SelectGender { get; set; }
        public List<Gender> Genders { get; set; }

    }
}
