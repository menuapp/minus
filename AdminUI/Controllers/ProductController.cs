using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AdminUI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Domains;
using Service.Interfaces;

namespace AdminUI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        IMapper mapper;
        IProductService productService;
        IProductCategoryService productCategoryService;
        private readonly IHostingEnvironment hostingEnvironment;
        public ProductController(IMapper mapper, IProductService productService, IProductCategoryService productCategoryService, IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.productService = productService;
            this.mapper = mapper;
            this.productCategoryService = productCategoryService;
        }
        public IActionResult Index()
        {
            List<ProductCategoryViewModel> productCategoryViewModels = mapper.Map<List<ProductCategoryViewModel>>(productCategoryService.GetMany(cat => cat.PartnerId == Int32.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "PartnerId").Value)));
            return View(productCategoryViewModels);
        }

        public IActionResult ListProducts(int id)
        {
            IEnumerable<ProductViewModel> productViewModels = mapper.Map<IEnumerable<ProductViewModel>>(productCategoryService.GetById(id).Products);
            ViewData["categoryId"] = id;
            return View(productViewModels);
        }

        public IActionResult CreateProduct(int id)
        {
            ViewData["categoryId"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel productViewModel)
        {
            foreach (var content in productViewModel.Files)
            {
                var fileName = Path.GetFileName(content.FileName);
                var upload = Path.Combine(hostingEnvironment.ContentRootPath, "Uploads");
                var filePath = Path.Combine(upload, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
                {
                    content.CopyTo(fileStream);
                }

                productViewModel.Contents = new List<ContentViewModel>();
                productViewModel.Contents.Add(new ContentViewModel
                {
                    PhysicalPath = filePath
                });
            }

            productViewModel.Category = mapper.Map<ProductCategoryViewModel>(productCategoryService.GetById(productViewModel.CategoryId));
            productService.Add(mapper.Map<ProductDomain>(productViewModel));
            return RedirectToAction("ListProducts", new
            {
                id = productViewModel.Category.Id
            });
        }

        public IActionResult EditProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditProduct(ProductViewModel model)
        {
            return View();
        }

        public IActionResult DeleteProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteProduct(ProductViewModel model)
        {
            return View();
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(ProductCategoryViewModel productCategoryViewModel)
        {
            productCategoryViewModel.PartnerId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "PartnerId").Value);
            productCategoryService.Add(mapper.Map<ProductCategoryDomain>(productCategoryViewModel));
            return RedirectToAction("Index");
        }

        public IActionResult EditCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditCategory(ProductCategoryViewModel model)
        {
            return View();
        }

        public IActionResult DeleteCategory(int id)
        {
            var model = mapper.Map<ProductCategoryViewModel>(productCategoryService.GetById(id));
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteCategory(ProductCategoryViewModel model)
        {
            return View();
        }
    }
}