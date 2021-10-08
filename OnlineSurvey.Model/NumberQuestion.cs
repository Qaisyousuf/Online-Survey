namespace OnlineSurvey.Model
{
    public class NumberQuestion:EntityBase
    {
        public string Title { get; set; }
        public string Number { get; set; }
        public bool IsActive { get; set; }

    }
}
