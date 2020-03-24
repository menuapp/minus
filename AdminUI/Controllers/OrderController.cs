using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminUI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<OrderViewModel> orders = new List<OrderViewModel>();
            return View(orders);
        }
    }
}