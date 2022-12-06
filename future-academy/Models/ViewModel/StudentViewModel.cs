namespace future_academy.Models.ViewModel
{
    public class StudentViewModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string patronomic { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public string group { get; set; }
        public string departament { get; set; }
        public string role { get; set; }

        public StudentViewModel(
            string name, 
            string surname, 
            string patronomic, 
            string login, 
            string email, 
            string group, 
            string departament,
            string role
            ) {
            this.name = name;
            this.surname = surname;
            this.patronomic = patronomic;
            this.login = login;
            this.email = email;
            this.group = group;
            this.departament = departament;
            this.role = role;
        }
    }
}
