using Microsoft.AspNetCore.Mvc;
using Napa.MVC.ViewModels;

namespace Napa.MVC.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var vm = new List<ProductViewModel>
            {
                new(){Id = 1, Price = 345345, Quantity = 5, Title = "Samsung", PriceWithVat = 435345},
                new(){Id = 2, Price = 45345, Quantity = 2, Title = "LG", PriceWithVat = 547452},
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult ProductCreate()
        {
            return View(new ProductCreateViewModel());
        }

        [HttpPost]
        public IActionResult ProductCreate(ProductCreateViewModel viewModel)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ProductEdit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProductEdit(ProductEditViewModel viewModel)
        {
            return View();
        }
    }
}
