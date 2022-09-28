using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Napa.MVC.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Incorrect e-mail address")]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string Password { get; set; } = null!;

        [HiddenInput(DisplayValue = false)]
        public string? ReturnUrl { get; set; }
    }
}
