﻿using Microsoft.AspNetCore.Mvc;

namespace Napa.MVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
