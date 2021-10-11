using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.ViewModel
{
    public class MenusViewModel
    {
      
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public string Url { get; set; }

        [InverseProperty("SubMenus")]
        public int? PartentId { get; set; }

        public Menus Parent { get; set; }

        [ForeignKey("PartentId")]
        public List<Menus> SubMenus { get; set; }


    }
}
