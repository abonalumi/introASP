using Microsoft.AspNetCore.Mvc;

namespace ASPIntroWebAppMVC.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
