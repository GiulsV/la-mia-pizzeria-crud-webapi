﻿using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_model.Controllers
{
    public class GuestController : Controller
    {
        public IActionResult Index()
        {
            ViewData["title"] = "Home";
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}