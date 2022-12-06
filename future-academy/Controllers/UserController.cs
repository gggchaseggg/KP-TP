using future_academy.Contexts;
using future_academy.Models;
using future_academy.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace future_academy.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {

        private readonly UniversityContext _context;

        public UserController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet("{login}")]
        public async Task<StudentViewModel> getStudentByLogin(string login)
        {
            var student = _context.Students
                .Include(a => a.account)
                .Include(g => g.group)
                .Where(a => a.account.login == login)
                .OrderBy(s => s.id)
                .First();
            return new StudentViewModel(
                student.name,
                student.surname,
                student.patronomic,
                student.account.login,
                student.account.email,
                student.group.title,
                student.department,
                student.account.role);
        }
    }
}
