using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminUI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Domains;
using Service.Interfaces;

namespace AdminUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.mapper = mapper;
            this.userService = userService;
        }
        public IActionResult Index()
        {
            List<UserViewModel> userViewModels = mapper.Map<List<UserDomain>, List<UserViewModel>>(userService.ListUsers().ToList());
            return RedirectToAction("Create");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserViewModel userToCreate)
        {
            if (ModelState.IsValid && userService.CreateUser(mapper.Map<UserViewModel, UserDomain>(userToCreate)))
            {
                return RedirectToAction("index");
            }

            return View();
        }

    }
}