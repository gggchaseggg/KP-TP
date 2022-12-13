namespace future_academy.Models.ViewModel
{
    public class UpdateUserViewModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string patronomic { get; set; }
        public string login { get; set; }
        public string newPassword { get; set; }
        public string email { get; set; }
        public string group { get; set; }
        public string departament { get; set; }

        public UpdateUserViewModel(
            string name, 
            string surname, 
            string patronomic, 
            string login, 
            string newPassword, 
            string email, 
            string group, 
            string departament
            ) {
            this.name = name;
            this.surname = surname;
            this.patronomic = patronomic;
            this.login = login;
            this.newPassword = newPassword;
            this.email = email;
            this.group = group;
            this.departament = departament;
        }
    }
}
