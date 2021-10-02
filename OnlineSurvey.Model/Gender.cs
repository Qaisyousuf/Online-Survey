using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Model
{
    public class Gender:EntityBase
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }

    }
}
