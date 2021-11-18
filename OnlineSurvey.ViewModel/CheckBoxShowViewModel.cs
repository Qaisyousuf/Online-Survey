using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.ViewModel
{
    public class CheckBoxShowViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public bool IsActive { get; set; }

        public bool IsTypeCheckbox { get; set; }
        public bool IsTypeRadioButton { get; set; }
        public List<string> CheckoxString { get; set; }
    }
}
