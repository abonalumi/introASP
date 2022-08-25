using ASPIntroWebAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPIntroWebAppMVC.Controllers
{
    public class BeerController : Controller
    {
        private readonly PubContext _context;
        public BeerController(PubContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var beers = await _context.Beers.Include(b => b.Brand).ToListAsync();
            return View(beers);
        }
    }
}
