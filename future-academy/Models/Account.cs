namespace future_academy.Models
{
    public class Account
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string? role  { get; set; }
        public DateTime registerDate { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronomic { get; set; }
        public int score { get; set; }

        public Account(string login, string password, string email, string name, string surname, string patronomic)
        {
            this.login = login;
            this.password = password;
            this.email = email;
            this.registerDate = DateTime.Now.ToUniversalTime();
            this.name = name;
            this.surname = surname;
            this.patronomic = patronomic;
        }
    }
}
