using future_academy.Contexts;
using future_academy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace future_academy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesInfoController : ControllerBase
    {

        private ServicesInfoContext db = new ServicesInfoContext();

        //private readonly ServicesInfoContext _context;

        //public ServicesInfoController(ServicesInfoContext context)
        //{
        //    _context = context;
        //}

        [HttpGet]
        public ServicesInfo Get()
        {
            return db.ServicesInfo.OrderBy(item => item.id).Last();
        }
    }
}