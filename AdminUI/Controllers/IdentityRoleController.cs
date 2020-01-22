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
    public class IdentityRoleController : Controller
    {
        IIdentityRoleService identityRoleService;
        IMapper mapper;
        public IdentityRoleController(IIdentityRoleService identityRoleService, IMapper mapper)
        {
            this.identityRoleService = identityRoleService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(mapper.Map<IEnumerable<RoleViewModel>>(identityRoleService.ListRoles()));
        }

        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Create(RoleViewModel roleViewModel)
        {
            identityRoleService.AddRole(mapper.Map<IdentityRoleDomain>(roleViewModel));
            return RedirectToAction("Index");
        }
    }
}