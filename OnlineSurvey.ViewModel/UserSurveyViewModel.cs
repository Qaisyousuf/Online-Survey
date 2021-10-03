using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.ViewModel
{
    public class UserSurveyViewModel
    {
        public UserSurveyViewModel()
        {
            Genders = new List<Gender>();
        }
        public int Id { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Mobile ")]
        public string Mobile { get; set; }

  
        public string Address { get; set; }

        [Required]
        [Display(Name ="CPR Number")]
        [DataType(DataType.PhoneNumber)]
        public string CPRNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        [Display(Name ="Data of birth")]
        public DateTime DOB { get; set; }
        public string SelectGender { get; set; }
        public List<Gender> Genders { get; set; }
    }
}
