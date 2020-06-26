using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydroponics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class HealthCheckController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(new { ServiceStatus = "Up", Moment = DateTime.Now });
        }
    }
}
