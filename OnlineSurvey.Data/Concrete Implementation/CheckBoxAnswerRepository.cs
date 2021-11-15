using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineSurvey.Data.Interfaces;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class CheckBoxAnswerRepository:Repository<CheckBoxAnswers>,ICheckBoxAnswerRepository
    {
        public CheckBoxAnswerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
