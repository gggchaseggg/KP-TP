using future_academy.Contexts;
using future_academy.Models;
using future_academy.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace future_academy.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly UniversityContext _context;

        public AdminController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet("usersWithoutRole")]
        public List<AdminTableUsersView> getAllUsersWithoutRole()
        {
            var users = _context.Accounts
                .Where(u => u.role == null)
                .Take(15)
                .ToList();

            List<AdminTableUsersView> adminViewUsers = new List<AdminTableUsersView>();

            foreach (Account user in users) adminViewUsers.Add(
                new AdminTableUsersView { login = user.login, registerDate = user.registerDate }
                );

            return adminViewUsers;
        }
        [HttpPost("setUserRole")]
        public string setUserRoleByLogin(SetRoleModel model)
        {
            var acc = _context.Accounts.Where(a => a.login == model.login).OrderBy(a => a.id).First();
            acc.role = model.role;
            if (model.role == "student") {
                _context.Students.Add(new Student { account = acc });
            }
            _context.SaveChanges();
            return "ок";
        }
    }
}