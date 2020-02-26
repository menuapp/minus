using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminUI.Controllers
{
    public class ProductOptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(int productId)
        {
            return View();
        }

        public IActionResult Create(int productId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductOptionViewModel model)
        {
            return View();
        }
    }
}