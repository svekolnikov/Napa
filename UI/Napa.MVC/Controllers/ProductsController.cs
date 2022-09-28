using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Napa.DTO;
using Napa.Interfaces;
using Napa.MVC.ViewModels;

namespace Napa.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var productsDto = await _productService.GetAllAsync();
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(productsDto);
            return View(productsViewModel);
        }

        [HttpGet]
        public IActionResult ProductCreate() => View(new ProductCreateViewModel());

        [HttpPost]
        public IActionResult ProductCreate(ProductCreateViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var productDto = _mapper.Map<ProductDto>(viewModel);

            _productService.CreateAsync(productDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ProductEdit(int id)
        {
            var productDto = await _productService.GetProductByIdAsync(id);
            var productsViewModel = _mapper.Map<ProductEditViewModel>(productDto);
            return View(productsViewModel);
        }

        [HttpPost]
        public IActionResult ProductEdit(ProductEditViewModel viewModel)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ProductDelete(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProductDelete(ProductEditViewModel viewModel)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
