using Microsoft.AspNetCore.Mvc;

namespace Napa.MVC.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
