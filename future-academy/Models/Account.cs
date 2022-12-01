namespace future_academy.Models
{
    public class Account
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string role  { get; set; }

        public Account(string login, string password, string email, string role = "user")
        {
            this.login = login;
            this.password = password;
            this.email = email;
            this.role = role;
        }
    }
}
