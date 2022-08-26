using ASPIntroWebAppMVC.Models;
using ASPIntroWebAppMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Create()
        {
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeerViewModel beerModel)
        {

            if(ModelState.IsValid)
            {
                Beer beer = new Beer()
                {
                    Name = beerModel.Name,
                    BrandId = beerModel.BrandId
                };
                _context.Beers.Add(beer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); 
            }
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name", beerModel.BrandId);
            return View(beerModel);
        }
    }
}
