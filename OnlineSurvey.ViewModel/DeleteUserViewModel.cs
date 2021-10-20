using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.ViewModel
{
    public class DeleteUserViewModel:BaseViewModel
    {
        public DeleteUserViewModel()
        {
            Roles = new List<ChechBoxItemViewModel>();
        }
        public string Id { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Mobile")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public List<ChechBoxItemViewModel> Roles { get; set; }
    }
}
