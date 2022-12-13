using future_academy.Contexts;
using future_academy.Models;
using future_academy.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace future_academy.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase    
    {

        private readonly UniversityContext _context;

        public UserController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet("getStudentByLogin/{login}")]
        public async Task<StudentViewModel> getUserByLogin(string login)
        {
            try
            {
                var student = _context.Students
                .Include(a => a.account)
                .Include(g => g.group)
                .Where(a => a.account.login == login)
                .OrderBy(s => s.id)
                .First();
                return new StudentViewModel(
                    student.account.name,
                    student.account.surname,
                    student.account.patronomic,
                    student.account.login,
                    student.account.email,
                    student.group.title,
                    student.department,
                    student.account.role);
            } catch
            {
                var user = _context.Accounts
                .Where(a => a.login == login)
                .OrderBy(a => a.id)
                .First();
                return new StudentViewModel(
                    user.name,
                    user.surname,
                    user.patronomic,
                    user.login,
                    user.email,
                    "Не указано",
                    "Не указано",
                    !(user.role is null) ? user.role : "Не указано");
            }
            
        }

        [HttpGet("getname/{login}")]
        public string getUserNameByLogin(string login)
        {
            return _context.Accounts.Where(a => a.login == login).OrderBy(a => a.id).First().name;
        }

        [HttpPost("updateInfo")]
        public UpdateUserViewModel updateUserInfo(UpdateUserViewModel model)
        {
            var user = _context.Students
                .Include(a => a.account)
                .Where(a => a.account.login == model.login)
                .OrderBy(s => s.id)
                .First();

            if (user.account.password != model.newPassword &&  model.newPassword != "") user.account.password = model.newPassword;
            if (model.group != "") { 
                try {
                    var group = _context.Groups.Where(g => g.title == model.group).OrderBy(s => s.id).First();
                    user.group = group;
                } catch {
                    Console.WriteLine("Нет такой группы");
                }
            }
            if (user.department != model.departament && model.departament != "") user.department = model.departament;
            if (user.account.name != model.name && model.name != "") user.account.name = model.name;
            if (user.account.surname != model.surname && model.surname != "") user.account.surname = model.surname;
            if (user.account.patronomic != model.patronomic && model.patronomic != "") user.account.patronomic = model.patronomic;
            if (user.account.email != model.email && model.email != "") user.account.email = model.email;

            _context.SaveChanges();

            return model;
        }
    }
}
