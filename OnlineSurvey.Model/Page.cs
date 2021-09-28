using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
    public class Page:EntityBase
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }

        public int BannerId { get; set; }

        [ForeignKey("BannerId")]
        public Banner Banners { get; set; }

    }
}
