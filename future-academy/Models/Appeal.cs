namespace future_academy.Models
{
    public class Appeal
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public DateTime date { get; set; }


        public Appeal(string name, string phoneNumber, string email)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.date = DateTime.Now.ToUniversalTime();
        }
    }
}
