using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineSurvey.Model;

namespace OnlineSurvey.ViewModel
{
    public class ListofBackendViewModel
    {
        public List<SurveyViewModel> ListofSurvey { get; set; }
        public List<AdminDashboardViewModel> ListofAdminDashboard { get; set; }
        public List<PageViewModel> ListofPageViewModel { get; set; }
        public List<ResponseViewModel> ListofResponse { get; set; }
        public List<ViewUserViewModel> ListofUsers { get; set; }
    }
}
