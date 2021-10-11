using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
    public class Menus:EntityBase
    {
        public Menus()
        {
            SubMenus = new List<Menus>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        [InverseProperty("SubMenus")]
        public int? PartentId { get; set; }

        public Menus Parent { get; set; }

        [ForeignKey("PartentId")]
        public List<Menus> SubMenus { get; set; }

      
    }
}
