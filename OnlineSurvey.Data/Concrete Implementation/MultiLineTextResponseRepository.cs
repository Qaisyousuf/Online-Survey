using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineSurvey.Model;
using OnlineSurvey.Data.Interfaces;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class MultiLineTextResponseRepository:Repository<MultiLineTextResponse>,IMultiLineTextResponseRepository
    {
        public MultiLineTextResponseRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
