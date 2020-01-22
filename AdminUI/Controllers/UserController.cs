using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminUI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult Index()
        {
            List<UserViewModel> userViewModels = mapper.Map<List<UserDomain>, List<UserViewModel>>(userService.ListUsers().ToList());

            return View(userViewModels);
        }

        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Create(UserViewModel userToCreate)
        {
            if (ModelState.IsValid && userService.CreateUser(mapper.Map<UserViewModel, UserDomain>(userToCreate)))
            {
                return RedirectToAction("index");
            }

            return PartialView();
        }

        public IActionResult Details(int id)
        {
            return PartialView(mapper.Map<UserDomain, UserViewModel>(userService.GetUser(id)));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return PartialView(mapper.Map<UserDomain, UserViewModel>(userService.GetUser(id)));
        }
        public IActionResult Edit(int id)
        {
            return PartialView(mapper.Map<UserDomain, UserViewModel>(userService.GetUser(id)));
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel userViewModel)
        {
            userService.Update(mapper.Map<UserViewModel, UserDomain>(userViewModel));
            return RedirectToAction("index");
        }
    }
}