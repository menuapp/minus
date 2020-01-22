using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdminUI.Controllers
{
    public class ProductCategoryController : Controller
    {
        public ProductCategoryController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}