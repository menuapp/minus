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

namespace AdminUI.Controllers
{
    public class HomeController : Controller
    {
        public RoleService roleService { get; set; }
        public IMapper mapper { get; set; }
        public HomeController(RoleService roleService, IMapper mapper)
        {
            this.mapper = mapper;
            this.roleService = roleService;
        }
        public IActionResult Index()
        {
            IEnumerable<RoleDomain> roles = roleService.GetAll().ToList();

            IEnumerable<RoleViewModel> model = mapper.Map<IEnumerable<RoleDomain>, IEnumerable<RoleViewModel>>(roles);

            return View(model);
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
