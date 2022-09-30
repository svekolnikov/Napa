using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Napa.Domain.Entities.Identity;
using Napa.MVC.ViewModels;

namespace Napa.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        public UsersController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel {ReturnUrl = returnUrl});
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid) return View();
            
            var loginResult = await _signInManager.PasswordSignInAsync(
                viewModel.Email,
                viewModel.Password,
                true,
                false);

            if (loginResult.Succeeded)
            {
                return LocalRedirect(viewModel.ReturnUrl ?? "/");
            }

            ModelState.AddModelError("", "Incorrect Username or Password");

            return View(viewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
