using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminUI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Domains;
using Service.Interfaces;

namespace AdminUI.Controllers
{
    public class TableController : Controller
    {

        IMapper mapper;
        ITableService tableService;
        public TableController(IMapper mapper, ITableService tableService)
        {
            this.tableService = tableService;
            this.mapper = mapper;
        }

        public IActionResult List()
        {
            return View(mapper.Map<List<TableViewModel>>(tableService.GetAll()));
        }

        public IActionResult Details(int id)
        {
            return View(mapper.Map<TableViewModel>(tableService.GetById(id)));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TableViewModel model)
        {
            model.PartnerId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "PartnerId").Value);

            tableService.Add(mapper.Map<TableDomain>(model));
            return RedirectToAction("List");
        }


        public IActionResult Delete(int id)
        {
            return View(mapper.Map<TableViewModel>(tableService.GetById(id)));
        }
        [HttpPost]
        public IActionResult Delete(TableViewModel model)
        {
            tableService.Delete(mapper.Map<TableDomain>(model));
            return RedirectToAction("List");
        }
        public IActionResult Edit(int id)
        {
            return View(mapper.Map<TableViewModel>(tableService.GetById(id)));
        }

        [HttpPost]
        public IActionResult Edit(TableViewModel model)
        {
            tableService.Update(mapper.Map<TableDomain>(model));
            return RedirectToAction("List");
        }
    }
}