using ASPIntroWebAppMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPIntroWebAppMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBeerController : ControllerBase
    {
        private readonly PubContext _context;
        public ApiBeerController(PubContext context)
        {
            _context = context;
        }

        public async Task<List<Beer>> Get() => await _context.Beers.ToListAsync();
        
    }
}
