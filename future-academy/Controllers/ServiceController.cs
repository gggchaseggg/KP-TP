using future_academy.Contexts;
using future_academy.Models;
using future_academy.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace future_academy.Controllers
{
    [ApiController]
    [Route("api")]
    public class ServiceController : ControllerBase
    {


        private readonly UniversityContext _context;

        public ServiceController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet("servicesinfo")]
        public ServicesInfo GetServicesInfo()
        {
            return _context.ServicesInfo.OrderBy(item => item.id).Last();
        }

        [HttpPost("appeal")]
        public async Task<Appeal> postAppeal(FooterAppealModel model)
        {
            var cookie = HttpContext.Request.Cookies["login"];

            Console.WriteLine(cookie);

            Appeal appeal = new Appeal(
                model.name,
                model.phoneNumber,
                model.email
            );

            _context.Appeals.Add(appeal);
            await _context.SaveChangesAsync();
            return appeal;
        }
    }
}