using System.Collections.Generic;

namespace OnlineSurvey.ViewModel
{
    public class ListofModels:BaseViewModel
    {

        public UserSurveyViewModel ListUserSurveyViewModel { get; set; }
        public PageViewModel PagesViewModel { get; set; }
        public List<SurveyViewModel> ListOfsurveyViewModel { get; set; }
        public SurveyViewModel ViewModelSurvey { get; set; }
        public BannerViewModel Bannerviewmodel { get; set; }
        public ResponseViewModel ListofResponseViewModel { get; set; }
        public List<MultiLineTextViewModel> ListOfMultiLineTextQuestion { get; set; }
        public MultiLineResponseViewModel ListofMultilineTextResponse { get; set; }
        public List<YesNoQuestionViewModel> ListofSingleChoice { get; set; }
       





    }
}
