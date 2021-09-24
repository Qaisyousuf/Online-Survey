using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.ViewModel
{
    public class DetailsUserViewModel
    {
        public DetailsUserViewModel()
        {
            Roles = new List<ChechBoxItemViewModel>();
        }
        public string Id { get; set; }


        public string Email { get; set; }


        [Display(Name = "Password")]
        public string Password { get; set; }


        [Display(Name = "Confirm password")]

        public string ConfirmPassword { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Mobile")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public List<ChechBoxItemViewModel> Roles { get; set; }
    } 
}
