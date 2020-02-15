using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminUI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Domains;
using Service.Interfaces;

namespace AdminUI.Controllers
{
    [Authorize(Policy = "PartnerOperationsPolicy")]
    public class PartnerController : Controller
    {
        IMapper mapper;
        IPartnerService partnerService;
        public PartnerController(IMapper mapper, IPartnerService partnerService)
        {
            this.mapper = mapper;
            this.partnerService = partnerService;
        }
        public IActionResult Index()
        {
            return View(mapper.Map<List<PartnerViewModel>>(partnerService.GetAll()));
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var partner = partnerService.GetByIdEagerly(id);
            var model = mapper.Map<PartnerViewModel>(partner);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(PartnerViewModel partnerViewModel)
        {
            if (ModelState.IsValid)
            {
                partnerService.Add(mapper.Map<PartnerDomain>(partnerViewModel));
            }

            return RedirectToAction("index");
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}