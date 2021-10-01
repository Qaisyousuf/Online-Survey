using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.Model
{
    public class Survey:EntityBase
    {
        public Survey()
        {
            Questions = new List<Question>();
           
        }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SurveryId { get; set; }
        

        public int SurveyCatagoryId { get; set; }
        [ForeignKey("SurveyCatagoryId")]
        public SurveyCatagory  SurveyCatagories { get; set; }
        public List<Question> Questions { get; set; }
        


    }
}
