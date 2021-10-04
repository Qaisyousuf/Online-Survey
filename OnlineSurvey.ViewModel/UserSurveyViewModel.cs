using OnlineSurvey.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.ViewModel
{
    public class UserSurveyViewModel
    {
       
        public int Id { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        
        [EmailAddress]
        [Required]
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
        [Display(Name ="Gender type")]
        public int GenderId { get; set; }

        [ForeignKey("GenderId")]
        public UserGender Genders { get; set; }
    }
}
