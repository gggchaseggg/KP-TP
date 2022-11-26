using future_academy.Models;
using Microsoft.AspNetCore.Mvc;

namespace future_academy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesInfoController : ControllerBase
    {

        [HttpGet]
        public ServicesInfo Get()
        {
            return new ServicesInfo { id = 1, openDoorsDate = DateTime.Now, programsCount = 1, teachersCount = 2, graduatesCount = 3 };

        }
    }
}