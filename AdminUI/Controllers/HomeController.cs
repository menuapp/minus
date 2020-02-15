using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminUI.Models;
using Service;
using Service.Domains;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace AdminUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IMapper mapper { get; set; }
        public HomeController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
