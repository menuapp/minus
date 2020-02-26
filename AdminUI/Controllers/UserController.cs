using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminUI.Models;
using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Domains;
using Service.Interfaces;

namespace AdminUI.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]

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
            List<UserViewModel> userViewModels = mapper.Map<List<UserViewModel>>(userService.GetAll().ToList());

            return View(userViewModels);
        }
        [Authorize(Policy = "CreateAdminUserPolicy")]
        public IActionResult Create()
        {
            return RedirectToPage("/Account/Register", new { area = "Identity" });
        }
        [Authorize(Policy = "CreateAdminUserPolicy")]
        [HttpPost]
        public IActionResult Create(UserViewModel userToCreate)
        {
            if (ModelState.IsValid && userService.Add(mapper.Map<UserViewModel, UserDomain>(userToCreate)))
            {
                return RedirectToAction("index");
            }

            return View();
        }

        public IActionResult Details(string id)
        {
            return View(mapper.Map<UserDomain, UserViewModel>(userService.GetById(id)));
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            return View(mapper.Map<UserDomain, UserViewModel>(userService.GetById(id)));
        }
        public IActionResult Edit(string id)
        {
            return View(mapper.Map<UserDomain, UserViewModel>(userService.GetById(id)));
        }

        [Authorize(Policy = "CreateAdminUserPolicy")]
        [HttpPost]
        public IActionResult Edit(UserViewModel userViewModel)
        {
            userService.Update(mapper.Map<UserViewModel, UserDomain>(userViewModel));
            return RedirectToAction("index");
        }

        public IActionResult Logout()
        {
            return RedirectToPage("/Account/Logout", new { area = "Identity" });
        }
    }
}