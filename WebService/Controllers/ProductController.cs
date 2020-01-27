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
        private MinusContext context { get; set; }
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Get()
        {       
            return Ok(productService.GetAll());
        }
    }
}