using future_academy.Contexts;
using future_academy.Models;
using future_academy.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace future_academy.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {

        private readonly UniversityContext _context;

        public AccountController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Account> getAll()
        {
            return _context.Accounts.ToList();
        }

        [HttpGet("roleByLogin")]
        public string getRoleByLogin(string login)
        {
            var role = _context.Accounts.Where(a => a.login == login).ToList();


            return role.Count != 0 ? role.Last().role : "err";
        }

        [HttpGet("existsemail")]
        public bool getUserByEmail (string email)
        {
            return _context.Accounts.Where(a => a.email == email).ToList().Count == 0;
        }

        [HttpGet("existslogin")]
        public bool getUserByLogin(string login)
        {
            return _context.Accounts.Where(a => a.login == login).ToList().Count == 0;
        }

        [HttpPost("login")]
        public string login(LoginModel model)
        {
            var role =  _context.Accounts.Where(a => a.login == model.logLogin && a.password == model.logPassword).ToList();
            
            
            return role.Count != 0 ? role.Last().role : "err";
        }

        [HttpPost("register")]
        public async Task<Account> register(RegisterModel model)
        {
            Account account = new Account (
                model.regLogin,
                model.regPassword,
                model.regEmail,
                model.regName,
                model.regSurname,
                model.regPatronomic
            );

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }


    }
}
