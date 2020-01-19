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
    public class ProductController : Controller
    {
        IMapper mapper;
        IProductService productService;
        public ProductController(IMapper mapper, IProductService productService)
        {
            this.productService = productService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            List<ProductViewModel> productViewModels = mapper.Map<List<ProductViewModel>>(productService.ListProducts());
            return View(productViewModels);
        }

        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            productService.AddProduct(mapper.Map<ProductDomain>(productViewModel));
            return RedirectToAction("Index");
        }
    }
}