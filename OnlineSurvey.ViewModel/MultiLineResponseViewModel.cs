using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.ViewModel
{
    public class MultiLineResponseViewModel
    {
        public MultiLineResponseViewModel()
        {
            Responses = new List<Response>();
            MultiLineTexts = new List<MultiLineText>();
        }
        public int Id { get; set; }

        public string Title { get; set; }
        public string MulitLine { get; set; }

        public List<Response> Responses { get; set; }


        public int[] MultiLineTextId { get; set; }

        public List<string> MultiLinetextTag { get; set; }


        public List<MultiLineText> MultiLineTexts { get; set; }
    }
}
