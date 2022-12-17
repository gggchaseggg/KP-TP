namespace future_academy.Models
{
    public class Test
    {
        public int id { get; set; }
        public string theme { get; set; }
        public ICollection<Question> questions { get; set; }

    }
}
