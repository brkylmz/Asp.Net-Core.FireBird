using Asp.Net_Core.FireBird.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_Core.FireBird.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Customers")]
        public async Task<IActionResult> Customers()
        {
            return Ok(await _dbContext.Customers.ToListAsync());
        }
    }
}
