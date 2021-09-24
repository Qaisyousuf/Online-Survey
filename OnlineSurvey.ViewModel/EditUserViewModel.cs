using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.ViewModel
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Roles = new List<ChechBoxItemViewModel>();
        }
        public string Id { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Mobile")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public List<ChechBoxItemViewModel> Roles { get; set; }
    }
}
