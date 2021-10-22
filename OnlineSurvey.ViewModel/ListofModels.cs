using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.ViewModel
{
    public class ListofModels:BaseViewModel
    {
        public UserSurveyViewModel ListUserSurveyViewModel { get; set; }
        public PageViewModel PagesViewModel { get; set; }
        public List<SurveyViewModel> ListOfsurveyViewModel { get; set; }


    }
}
