namespace future_academy.Models
{
    public class Course
    {
        public int id { get; set; }
        public string title { get; set; }
        public ICollection<Test> tests { get; set; }
        public string teacher { get; set; }
    }
}
