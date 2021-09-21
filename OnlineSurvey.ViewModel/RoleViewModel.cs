using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.ViewModel
{
    public class RoleViewModel
    {
       public string Id { get; set; }

        [Display(Name="Role Name")]
        public string Name { get; set; }

    }
}
