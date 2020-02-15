using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interfaces;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService productService { get; set; }
        private IProductCategoryService productCategoryService { get; set; }
        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            this.productService = productService;
            this.productCategoryService = productCategoryService;
        }

        public IActionResult Get()
        {
            var categories = productCategoryService.GetMany(cat => cat.PartnerId == 3);
            return Ok(categories);
        }
    }
}