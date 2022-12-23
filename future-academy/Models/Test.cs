using System.Diagnostics.Eventing.Reader;

namespace future_academy.Models
{
    public class Test
    {
        public int id { get; set; }
        public string theme { get; set; }
        public ICollection<Question> questions { get; set; }
        public ICollection<Student> passedStudents { get; set; }
        public DateTime endDate { get; set; }
        public bool isAvailable { get; set; }
    }
}
