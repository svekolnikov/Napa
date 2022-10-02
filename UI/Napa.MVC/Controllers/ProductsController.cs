using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Napa.DTO;
using Napa.Interfaces;
using Napa.MVC.ViewModels;

namespace Napa.MVC.Controllers
{
    [Authorize]
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
        public IActionResult ProductCreate() => View(new ProductCreateEditViewModel());

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductCreateEditViewModel editViewModel)
        {
            if (!ModelState.IsValid) return View(editViewModel);

            var productDto = _mapper.Map<ProductCreateEditDto>(editViewModel);

            await _productService.CreateAsync(productDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ProductEdit(int id)
        {
            var productDto = await _productService.GetProductByIdAsync(id);
            var productsViewModel = _mapper.Map<ProductCreateEditViewModel>(productDto);
            return View(productsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductCreateEditViewModel viewModel)
        {
            var dto = _mapper.Map<ProductCreateEditDto>(viewModel);
            await _productService.UpdateProductAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var productDto = await _productService.GetProductByIdAsync(id);
            var productsViewModel = _mapper.Map<ProductCreateEditViewModel>(productDto);
            return View(productsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ProductDeleteConfirmed(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
