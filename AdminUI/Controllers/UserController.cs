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
    [Authorize(Roles = "Administrator,Manager,ManagerAssistant")]
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPartnerUserService partnerUserService;

        public UserController(IPartnerUserService partnerUserService, IMapper mapper)
        {
            this.mapper = mapper;
            this.partnerUserService = partnerUserService;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<UserViewModel> userViewModels = mapper.Map<List<UserViewModel>>(partnerUserService.GetAll().ToList());

            return View(userViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserViewModel userToCreate)
        {
            if (ModelState.IsValid && partnerUserService.Add(mapper.Map<UserViewModel, PartnerUserDomain>(userToCreate)))
            {
                return RedirectToAction("index");
            }

            return View();
        }

        public IActionResult Details(string id)
        {
            return View(mapper.Map<PartnerUserDomain, UserViewModel>(partnerUserService.GetById(id)));
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            return View(mapper.Map<PartnerUserDomain, UserViewModel>(partnerUserService.GetById(id)));
        }
        public IActionResult Edit(string id)
        {
            return View(mapper.Map<PartnerUserDomain, UserViewModel>(partnerUserService.GetById(id)));
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel userViewModel)
        {
            partnerUserService.Update(mapper.Map<UserViewModel, PartnerUserDomain>(userViewModel));
            return RedirectToAction("index");
        }
    }
}