namespace future_academy.Models
{
    public class Question
    {
        public int id { get; set; }
        public string question { get; set; }
        public ICollection<Answer> answers { get; set; }
    }
}
